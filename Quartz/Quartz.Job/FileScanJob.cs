using System;
using System.Globalization;
using System.IO;
using Common.Logging;

namespace Quartz.Job;

/// <summary> 
/// Inspects a file and compares whether it's "last modified date" has changed
/// since the last time it was inspected.  If the file has been updated, the
/// job invokes a "call-back" method on an identified 
/// <see cref="T:Quartz.Job.IFileScanListener" /> that can be found in the 
/// <see cref="T:Quartz.SchedulerContext" />.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.Job.IFileScanListener" />
[DisallowConcurrentExecution]
[PersistJobDataAfterExecution]
public class FileScanJob : IJob
{
	/// <summary>
	/// JobDataMap key with which to specify the name of the file to monitor.
	/// </summary>
	public const string FileName = "FILE_NAME";

	/// <summary>
	/// JobDataMap key with which to specify the <see cref="T:Quartz.Job.IFileScanListener" />
	/// to be notified when the file contents change. 
	/// </summary>
	public const string FileScanListenerName = "FILE_SCAN_LISTENER_NAME";

	/// <summary>
	/// <see cref="T:Quartz.JobDataMap" /> key with which to specify a long
	/// value that represents the minimum number of milliseconds that must have
	/// past since the file's last modified time in order to consider the file
	/// new/altered.  This is necessary because another process may still be
	/// in the middle of writing to the file when the scan occurs, and the
	/// file may therefore not yet be ready for processing.
	///
	/// <para>If this parameter is not specified, a default value of 
	/// 5000 (five seconds) will be used.</para>
	/// </summary>
	public const string MinimumUpdateAge = "MINIMUM_UPDATE_AGE";

	private const string LastModifiedTime = "LAST_MODIFIED_TIME";

	private readonly ILog log;

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Job.FileScanJob" /> class.
	/// </summary>
	public FileScanJob()
	{
		log = LogManager.GetLogger(typeof(FileScanJob));
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// fires that is associated with the <see cref="T:Quartz.IJob" />.
	/// <para>
	/// The implementation may wish to set a  result object on the
	/// JobExecutionContext before this method exits.  The result itself
	/// is meaningless to Quartz, but may be informative to
	/// <see cref="T:Quartz.IJobListener" />s or
	/// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's
	/// execution.
	/// </para>
	/// </summary>
	/// <param name="context">The execution context.</param>
	/// <seealso cref="T:Quartz.IJob">
	/// </seealso>
	public virtual void Execute(IJobExecutionContext context)
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
		string fileName = mergedJobDataMap.GetString("FILE_NAME");
		string listenerName = mergedJobDataMap.GetString("FILE_SCAN_LISTENER_NAME");
		if (fileName == null)
		{
			throw new JobExecutionException(string.Format(CultureInfo.InvariantCulture, "Required parameter '{0}' not found in JobDataMap", new object[1] { "FILE_NAME" }));
		}
		if (listenerName == null)
		{
			throw new JobExecutionException(string.Format(CultureInfo.InvariantCulture, "Required parameter '{0}' not found in JobDataMap", new object[1] { "FILE_SCAN_LISTENER_NAME" }));
		}
		IFileScanListener listener = (IFileScanListener)schedCtxt[listenerName];
		if (listener == null)
		{
			throw new JobExecutionException(string.Format(CultureInfo.InvariantCulture, "FileScanListener named '{0}' not found in SchedulerContext", new object[1] { listenerName }));
		}
		DateTime lastDate = DateTime.MinValue;
		if (mergedJobDataMap.ContainsKey("LAST_MODIFIED_TIME"))
		{
			lastDate = mergedJobDataMap.GetDateTime("LAST_MODIFIED_TIME");
		}
		long minAge = 5000L;
		if (mergedJobDataMap.ContainsKey("MINIMUM_UPDATE_AGE"))
		{
			minAge = mergedJobDataMap.GetLong("MINIMUM_UPDATE_AGE");
		}
		DateTime maxAgeDate = DateTime.Now.AddMilliseconds(minAge);
		DateTime newDate = GetLastModifiedDate(fileName);
		if (newDate == DateTime.MinValue)
		{
			Log.Warn(string.Format(CultureInfo.InvariantCulture, "File '{0}' does not exist.", new object[1] { fileName }));
			return;
		}
		if (lastDate != DateTime.MinValue && newDate != lastDate && newDate < maxAgeDate)
		{
			Log.Info(string.Format(CultureInfo.InvariantCulture, "File '{0}' updated, notifying listener.", new object[1] { fileName }));
			listener.FileUpdated(fileName);
		}
		else
		{
			Log.Debug(string.Format(CultureInfo.InvariantCulture, "File '{0}' unchanged.", new object[1] { fileName }));
		}
		context.JobDetail.JobDataMap.Put("LAST_MODIFIED_TIME", newDate);
	}

	/// <summary>
	/// Gets the last modified date.
	/// </summary>
	/// <param name="fileName">Name of the file.</param>
	/// <returns></returns>
	protected virtual DateTime GetLastModifiedDate(string fileName)
	{
		FileInfo file = new FileInfo(fileName);
		if (!File.Exists(file.FullName) && !Directory.Exists(file.FullName))
		{
			return DateTime.MinValue;
		}
		return file.LastWriteTime;
	}
}
