using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Job;
using Quartz.Simpl;
using Quartz.Spi;
using Quartz.Util;
using Quartz.Xml;

namespace Quartz.Plugin.Xml;

/// <summary> 
/// This plugin loads XML file(s) to add jobs and schedule them with triggers
/// as the scheduler is initialized, and can optionally periodically scan the
/// file for changes.
///             </summary>
/// <remarks>
/// The periodically scanning of files for changes is not currently supported in a 
/// clustered environment.
/// </remarks> 
/// <author>James House</author>
/// <author>Pierre Awaragi</author>
public class XMLSchedulingDataProcessorPlugin : ISchedulerPlugin, IFileScanListener
{
	/// <summary>
	/// Information about a file that should be processed by <see cref="T:Quartz.Xml.XMLSchedulingDataProcessor" />. 
	/// </summary>
	public class JobFile
	{
		private readonly string fileName;

		private string filePath;

		private string fileBasename;

		private bool fileFound;

		private readonly XMLSchedulingDataProcessorPlugin plugin;

		public string FileName => fileName;

		public bool FileFound => fileFound;

		public string FilePath => filePath;

		public string FileBasename => fileBasename;

		public JobFile(XMLSchedulingDataProcessorPlugin plugin, string fileName)
		{
			this.plugin = plugin;
			this.fileName = fileName;
			Initialize();
		}

		public void Initialize()
		{
			Stream f = null;
			try
			{
				string furl = null;
				string fName = FileName;
				fName = FileUtil.ResolveFile(fName);
				FileInfo file = new FileInfo(fName);
				if (!file.Exists)
				{
					Uri url = plugin.typeLoadHelper.GetResource(FileName);
					if (url != null)
					{
						furl = HttpUtility.UrlDecode(url.AbsolutePath);
						file = new FileInfo(furl);
						try
						{
							f = WebRequest.Create(url).GetResponse().GetResponseStream();
						}
						catch (IOException)
						{
						}
					}
				}
				else
				{
					try
					{
						f = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
					}
					catch (FileNotFoundException)
					{
					}
				}
				if (f == null)
				{
					if (plugin.FailOnFileNotFound)
					{
						throw new SchedulerException("File named '" + FileName + "' does not exist.");
					}
					plugin.Log.Warn(string.Format(CultureInfo.InvariantCulture, "File named '{0}' does not exist.", new object[1] { FileName }));
				}
				else
				{
					fileFound = true;
				}
				filePath = furl ?? file.FullName;
				fileBasename = file.Name;
			}
			finally
			{
				try
				{
					f?.Dispose();
				}
				catch (IOException ioe)
				{
					plugin.Log.Warn("Error closing jobs file " + FileName, ioe);
				}
			}
		}
	}

	private const int MaxJobTriggerNameLength = 80;

	private const string JobInitializationPluginName = "XMLSchedulingDataProcessorPlugin";

	private const char FileNameDelimiter = ',';

	private readonly ILog log;

	private bool failOnFileNotFound = true;

	private string fileNames = "quartz_jobs.xml";

	private readonly List<KeyValuePair<string, JobFile>> jobFiles = new List<KeyValuePair<string, JobFile>>();

	private TimeSpan scanInterval = TimeSpan.Zero;

	private bool started;

	private ITypeLoadHelper typeLoadHelper;

	private readonly Quartz.Collection.HashSet<string> jobTriggerNameSet = new Quartz.Collection.HashSet<string>();

	private IScheduler scheduler;

	private string name;

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	public string Name => name;

	public IScheduler Scheduler => scheduler;

	protected ITypeLoadHelper TypeLoadHelper => typeLoadHelper;

	/// <summary> 
	/// Comma separated list of file names (with paths) to the XML files that should be read.
	/// </summary>
	public virtual string FileNames
	{
		get
		{
			return fileNames;
		}
		set
		{
			fileNames = value;
		}
	}

	/// <summary> 
	/// The interval at which to scan for changes to the file.  
	/// If the file has been changed, it is re-loaded and parsed.   The default 
	/// value for the interval is 0, which disables scanning.
	/// </summary>
	[TimeSpanParseRule(TimeSpanParseRule.Seconds)]
	public virtual TimeSpan ScanInterval
	{
		get
		{
			return scanInterval;
		}
		set
		{
			scanInterval = value;
		}
	}

	/// <summary> 
	/// Whether or not initialization of the plugin should fail (throw an
	/// exception) if the file cannot be found. Default is <see langword="true" />.
	/// </summary>
	public virtual bool FailOnFileNotFound
	{
		get
		{
			return failOnFileNotFound;
		}
		set
		{
			failOnFileNotFound = value;
		}
	}

	public IEnumerable<KeyValuePair<string, JobFile>> JobFiles => jobFiles;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin" /> class.
	/// </summary>
	public XMLSchedulingDataProcessorPlugin()
	{
		log = LogManager.GetLogger(typeof(XMLSchedulingDataProcessorPlugin));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="fName"></param>
	public virtual void FileUpdated(string fName)
	{
		if (started)
		{
			ProcessFile(fName);
		}
	}

	/// <summary>
	/// Called during creation of the <see cref="T:Quartz.IScheduler" /> in order to give
	/// the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> a chance to initialize.
	/// </summary>
	/// <param name="pluginName">The name.</param>
	/// <param name="sched">The scheduler.</param>
	/// <throws>SchedulerConfigException </throws>
	public virtual void Initialize(string pluginName, IScheduler sched)
	{
		name = pluginName;
		scheduler = sched;
		typeLoadHelper = new SimpleTypeLoadHelper();
		typeLoadHelper.Initialize();
		Log.Info("Registering Quartz Job Initialization Plug-in.");
		IEnumerable<string> tokens = from x in fileNames.Split(',')
			select x.TrimStart();
		foreach (string token in tokens)
		{
			JobFile jobFile = new JobFile(this, token);
			jobFiles.Add(new KeyValuePair<string, JobFile>(jobFile.FilePath, jobFile));
		}
	}

	/// <summary>
	/// Called when the associated <see cref="T:Quartz.IScheduler" /> is started, in order
	/// to let the plug-in know it can now make calls into the scheduler if it
	/// needs to.
	/// </summary>
	public virtual void Start()
	{
		try
		{
			if (jobFiles.Count <= 0)
			{
				return;
			}
			if (scanInterval > TimeSpan.Zero)
			{
				scheduler.Context.Put("XMLSchedulingDataProcessorPlugin" + '_' + Name, this);
			}
			foreach (KeyValuePair<string, JobFile> jobFile2 in jobFiles)
			{
				JobFile jobFile = jobFile2.Value;
				if (scanInterval > TimeSpan.Zero)
				{
					string jobTriggerName = BuildJobTriggerName(jobFile.FileBasename);
					TriggerKey tKey = new TriggerKey(jobTriggerName, "XMLSchedulingDataProcessorPlugin");
					Scheduler.UnscheduleJob(tKey);
					SimpleTriggerImpl trig = (SimpleTriggerImpl)Scheduler.GetTrigger(tKey);
					trig = new SimpleTriggerImpl();
					trig.Name = jobTriggerName;
					trig.Group = "XMLSchedulingDataProcessorPlugin";
					trig.StartTimeUtc = SystemTime.UtcNow();
					trig.EndTimeUtc = null;
					trig.RepeatCount = -1;
					trig.RepeatInterval = scanInterval;
					JobDetailImpl job = new JobDetailImpl(jobTriggerName, "XMLSchedulingDataProcessorPlugin", typeof(FileScanJob));
					job.JobDataMap.Put("FILE_NAME", jobFile.FilePath);
					job.JobDataMap.Put("FILE_SCAN_LISTENER_NAME", "XMLSchedulingDataProcessorPlugin" + '_' + Name);
					scheduler.ScheduleJob(job, trig);
					Log.DebugFormat("Scheduled file scan job for data file: {0}, at interval: {1}", jobFile.FileName, scanInterval);
				}
				ProcessFile(jobFile);
			}
		}
		catch (SchedulerException se)
		{
			Log.Error("Error starting background-task for watching jobs file.", se);
		}
		finally
		{
			started = true;
		}
	}

	/// <summary>
	/// Helper method for generating unique job/trigger name for the  
	/// file scanning jobs (one per FileJob).  The unique names are saved
	/// in jobTriggerNameSet.
	/// </summary>
	/// <param name="fileBasename"></param>
	/// <returns></returns>
	private string BuildJobTriggerName(string fileBasename)
	{
		string jobTriggerName = "XMLSchedulingDataProcessorPlugin" + '_' + Name + '_' + fileBasename.Replace('.', '_');
		if (jobTriggerName.Length > 80)
		{
			jobTriggerName = jobTriggerName.Substring(0, 80);
		}
		int currentIndex = 1;
		while (!jobTriggerNameSet.Add(jobTriggerName))
		{
			if (currentIndex > 1)
			{
				jobTriggerName = jobTriggerName.Substring(0, jobTriggerName.LastIndexOf('_'));
			}
			string numericSuffix = "_" + currentIndex++;
			if (jobTriggerName.Length > 80 - numericSuffix.Length)
			{
				jobTriggerName = jobTriggerName.Substring(0, 80 - numericSuffix.Length);
			}
			jobTriggerName += numericSuffix;
		}
		return jobTriggerName;
	}

	/// <summary>
	/// Called in order to inform the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> that it
	/// should free up all of it's resources because the scheduler is shutting
	/// down.
	/// </summary>
	public virtual void Shutdown()
	{
	}

	private void ProcessFile(JobFile jobFile)
	{
		if (jobFile == null || !jobFile.FileFound)
		{
			return;
		}
		try
		{
			XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(TypeLoadHelper);
			processor.AddJobGroupToNeverDelete("XMLSchedulingDataProcessorPlugin");
			processor.AddTriggerGroupToNeverDelete("XMLSchedulingDataProcessorPlugin");
			processor.ProcessFileAndScheduleJobs(jobFile.FileName, jobFile.FileName, scheduler);
		}
		catch (Exception e)
		{
			Log.Error("Error scheduling jobs: " + e.Message, e);
		}
	}

	public void ProcessFile(string filePath)
	{
		JobFile file = null;
		int idx = jobFiles.FindIndex((KeyValuePair<string, JobFile> pair) => pair.Key == filePath);
		if (idx >= 0)
		{
			file = jobFiles[idx].Value;
		}
		ProcessFile(file);
	}
}
