using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Logging;

namespace Quartz.Job;

/// <summary>
///  Inspects a directory and compares whether any files' "last modified dates" 
///  have changed since the last time it was inspected.  If one or more files 
///  have been updated (or created), the job invokes a "call-back" method on an 
///  identified <see cref="T:Quartz.Job.IDirectoryScanListener" /> that can be found in the
///  <see cref="T:Quartz.SchedulerContext" />.
///  </summary>
///  <author>pl47ypus</author>
///  <author>James House</author>
///  <author>Marko Lahma (.NET)</author>
[DisallowConcurrentExecution]
[PersistJobDataAfterExecution]
public class DirectoryScanJob : IJob
{
	/// <see cref="T:Quartz.JobDataMap" /> key with which to specify the directory to be 
	///  monitored - an absolute path is recommended. 
	public const string DirectoryName = "DIRECTORY_NAME";

	/// <see cref="T:Quartz.JobDataMap" /> key with which to specify the 
	/// <see cref="T:Quartz.Job.IDirectoryScanListener" /> to be 
	/// notified when the directory contents change.  
	public const string DirectoryScanListenerName = "DIRECTORY_SCAN_LISTENER_NAME";

	/// <see cref="T:Quartz.JobDataMap" /> key with which to specify a <see cref="T:System.Int64" />
	/// value that represents the minimum number of milliseconds that must have
	/// passed since the file's last modified time in order to consider the file
	/// new/altered.  This is necessary because another process may still be
	/// in the middle of writing to the file when the scan occurs, and the
	///  file may therefore not yet be ready for processing.
	/// <para>If this parameter is not specified, a default value of 5000 (five seconds) will be used.</para>
	public const string MinimumUpdateAge = "MINIMUM_UPDATE_AGE";

	private const string LastModifiedTime = "LAST_MODIFIED_TIME";

	private readonly ILog log;

	public DirectoryScanJob()
	{
		log = LogManager.GetLogger(GetType());
	}

	/// <summary>
	/// This is the main entry point for job execution. The scheduler will call this method on the 
	/// job once it is triggered.
	/// </summary>
	/// <param name="context">The <see cref="T:Quartz.IJobExecutionContext" /> that 
	/// the job will use during execution.</param>
	public void Execute(IJobExecutionContext context)
	{
		JobDataMap mergedJobDataMap = context.MergedJobDataMap;
		SchedulerContext schedCtxt;
		try
		{
			schedCtxt = context.Scheduler.Context;
		}
		catch (SchedulerException e)
		{
			throw new JobExecutionException("Error obtaining scheduler context.", e, refireImmediately: false);
		}
		string dirName = mergedJobDataMap.GetString("DIRECTORY_NAME");
		string listenerName = mergedJobDataMap.GetString("DIRECTORY_SCAN_LISTENER_NAME");
		if (dirName == null)
		{
			throw new JobExecutionException("Required parameter 'DIRECTORY_NAME' not found in merged JobDataMap");
		}
		if (listenerName == null)
		{
			throw new JobExecutionException("Required parameter 'DIRECTORY_SCAN_LISTENER_NAME' not found in merged JobDataMap");
		}
		schedCtxt.TryGetValue(listenerName, out var temp);
		IDirectoryScanListener listener = (IDirectoryScanListener)temp;
		if (listener == null)
		{
			throw new JobExecutionException("DirectoryScanListener named '" + listenerName + "' not found in SchedulerContext");
		}
		DateTime lastDate = DateTime.MinValue;
		if (mergedJobDataMap.ContainsKey("LAST_MODIFIED_TIME"))
		{
			lastDate = mergedJobDataMap.GetDateTime("LAST_MODIFIED_TIME");
		}
		TimeSpan minAge = TimeSpan.FromSeconds(5.0);
		if (mergedJobDataMap.ContainsKey("MINIMUM_UPDATE_AGE"))
		{
			minAge = TimeSpan.FromMilliseconds(mergedJobDataMap.GetLong("MINIMUM_UPDATE_AGE"));
		}
		DateTime maxAgeDate = DateTime.Now - minAge;
		IEnumerable<FileInfo> updatedFiles = GetUpdatedOrNewFiles(dirName, lastDate, maxAgeDate);
		if (updatedFiles == null)
		{
			log.Warn("Directory '" + dirName + "' does not exist.");
			return;
		}
		DateTime latestMod = lastDate;
		foreach (FileInfo updFile in updatedFiles)
		{
			DateTime lm = updFile.LastWriteTime;
			latestMod = ((lm > latestMod) ? lm : latestMod);
		}
		if (updatedFiles.Any())
		{
			log.Info("Directory '" + dirName + "' contents updated, notifying listener.");
			listener.FilesUpdatedOrAdded(updatedFiles);
		}
		else if (log.IsDebugEnabled)
		{
			log.Debug("Directory '" + dirName + "' contents unchanged.");
		}
		context.JobDetail.JobDataMap.Put("LAST_MODIFIED_TIME", latestMod);
	}

	protected static IEnumerable<FileInfo> GetUpdatedOrNewFiles(string dirName, DateTime lastDate, DateTime maxAgeDate)
	{
		DirectoryInfo dir = new DirectoryInfo(dirName);
		if (!dir.Exists)
		{
			return null;
		}
		FileInfo[] files = dir.GetFiles();
		return files.Where((FileInfo fileInfo) => fileInfo.LastWriteTime > lastDate && fileInfo.LastWriteTime < maxAgeDate);
	}
}
