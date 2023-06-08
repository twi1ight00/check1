using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Common.Logging;
using Quartz.Impl.Matchers;
using Quartz.Spi;
using Quartz.Util;
using Quartz.Xml.JobSchedulingData20;

namespace Quartz.Xml;

/// <summary> 
/// Parses an XML file that declares Jobs and their schedules (Triggers).
/// </summary>
/// <remarks>
/// <para>
/// The xml document must conform to the format defined in "job_scheduling_data_2_0.xsd"
/// </para>
///
/// <para>
/// After creating an instance of this class, you should call one of the <see cref="M:Quartz.Xml.XMLSchedulingDataProcessor.ProcessFile" />
/// functions, after which you may call the ScheduledJobs()
/// function to get a handle to the defined Jobs and Triggers, which can then be
/// scheduled with the <see cref="T:Quartz.IScheduler" />. Alternatively, you could call
/// the <see cref="M:Quartz.Xml.XMLSchedulingDataProcessor.ProcessFileAndScheduleJobs(Quartz.IScheduler)" /> function to do all of this
/// in one step.
/// </para>
///
/// <para>
/// The same instance can be used again and again, with the list of defined Jobs
/// being cleared each time you call a <see cref="M:Quartz.Xml.XMLSchedulingDataProcessor.ProcessFile" /> method,
/// however a single instance is not thread-safe.
/// </para>
/// </remarks>
/// <author><a href="mailto:bonhamcm@thirdeyeconsulting.com">Chris Bonham</a></author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class XMLSchedulingDataProcessor
{
	/// <summary>
	/// Helper class to map constant names to their values.
	/// </summary>
	internal class Constants
	{
		private readonly Type[] types;

		public Constants(params Type[] reflectedTypes)
		{
			types = reflectedTypes;
		}

		public int AsNumber(string field)
		{
			Type[] array = types;
			foreach (Type type in array)
			{
				FieldInfo fi = type.GetField(field);
				if (fi != null)
				{
					return Convert.ToInt32(fi.GetValue(null), CultureInfo.InvariantCulture);
				}
			}
			throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unknown field '{0}'", new object[1] { field }));
		}
	}

	public const string PropertyQuartzSystemIdDir = "quartz.system.id.dir";

	public const string QuartzXmlFileName = "quartz_jobs.xml";

	public const string QuartzSchema = "http://quartznet.sourceforge.net/xml/job_scheduling_data_2_0.xsd";

	public const string QuartzXsdResourceName = "Quartz.Xml.job_scheduling_data_2_0.xsd";

	protected const string ThreadLocalKeyScheduler = "quartz_scheduler";

	private readonly ILog log;

	private readonly IList<string> jobGroupsToDelete = new List<string>();

	private readonly IList<string> triggerGroupsToDelete = new List<string>();

	private readonly IList<JobKey> jobsToDelete = new List<JobKey>();

	private readonly IList<TriggerKey> triggersToDelete = new List<TriggerKey>();

	private readonly List<IJobDetail> loadedJobs = new List<IJobDetail>();

	private readonly List<ITrigger> loadedTriggers = new List<ITrigger>();

	private readonly IList<Exception> validationExceptions = new List<Exception>();

	protected readonly ITypeLoadHelper typeLoadHelper;

	private readonly IList<string> jobGroupsToNeverDelete = new List<string>();

	private readonly IList<string> triggerGroupsToNeverDelete = new List<string>();

	/// <summary>
	/// Whether the existing scheduling data (with same identifiers) will be 
	/// overwritten. 
	/// </summary>
	/// <remarks>
	/// If false, and <see cref="P:Quartz.Xml.XMLSchedulingDataProcessor.IgnoreDuplicates" /> is not false, and jobs or 
	/// triggers with the same names already exist as those in the file, an 
	/// error will occur.
	/// </remarks> 
	/// <seealso cref="P:Quartz.Xml.XMLSchedulingDataProcessor.IgnoreDuplicates" />
	public bool OverWriteExistingData { get; set; }

	/// <summary>
	/// If true (and <see cref="P:Quartz.Xml.XMLSchedulingDataProcessor.OverWriteExistingData" /> is false) then any 
	/// job/triggers encountered in this file that have names that already exist 
	/// in the scheduler will be ignored, and no error will be produced.
	/// </summary>
	/// <seealso cref="P:Quartz.Xml.XMLSchedulingDataProcessor.OverWriteExistingData" />
	public bool IgnoreDuplicates { get; set; }

	/// <summary>
	/// If true (and <see cref="P:Quartz.Xml.XMLSchedulingDataProcessor.OverWriteExistingData" /> is true) then any 
	/// job/triggers encountered in this file that already exist is scheduler
	/// will be updated with start time relative to old trigger. Effectively
	/// new trigger's last fire time will be updated to old trigger's last fire time
	/// and trigger's next fire time will updated to be next from this last fire time.
	/// </summary>
	public bool ScheduleTriggerRelativeToReplacedTrigger { get; set; }

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	protected IList<IJobDetail> LoadedJobs => loadedJobs.AsReadOnly();

	protected IList<ITrigger> LoadedTriggers => loadedTriggers.AsReadOnly();

	/// <summary>
	/// Constructor for XMLSchedulingDataProcessor.
	/// </summary>
	public XMLSchedulingDataProcessor(ITypeLoadHelper typeLoadHelper)
	{
		OverWriteExistingData = true;
		IgnoreDuplicates = false;
		log = LogManager.GetLogger(GetType());
		this.typeLoadHelper = typeLoadHelper;
	}

	/// <summary> 
	/// Process the xml file in the default location (a file named
	/// "quartz_jobs.xml" in the current working directory).
	/// </summary>
	public virtual void ProcessFile()
	{
		ProcessFile("quartz_jobs.xml");
	}

	/// <summary>
	/// Process the xml file named <see param="fileName" />.
	/// </summary>
	/// <param name="fileName">meta data file name.</param>
	public virtual void ProcessFile(string fileName)
	{
		ProcessFile(fileName, fileName);
	}

	/// <summary>
	/// Process the xmlfile named <see param="fileName" /> with the given system
	/// ID.
	/// </summary>
	/// <param name="fileName">Name of the file.</param>
	/// <param name="systemId">The system id.</param>
	public virtual void ProcessFile(string fileName, string systemId)
	{
		fileName = FileUtil.ResolveFile(fileName);
		Log.InfoFormat(CultureInfo.InvariantCulture, "Parsing XML file: {0} with systemId: {1}", fileName, systemId);
		using StreamReader sr = new StreamReader(fileName);
		ProcessInternal(sr.ReadToEnd());
	}

	/// <summary>
	/// Process the xmlfile named <see param="fileName" /> with the given system
	/// ID.
	/// </summary>
	/// <param name="stream">The stream.</param>
	/// <param name="systemId">The system id.</param>
	public virtual void ProcessStream(Stream stream, string systemId)
	{
		Log.InfoFormat(CultureInfo.InvariantCulture, "Parsing XML from stream with systemId: {0}", systemId);
		using StreamReader sr = new StreamReader(stream);
		ProcessInternal(sr.ReadToEnd());
	}

	protected virtual void PrepForProcessing()
	{
		ClearValidationExceptions();
		OverWriteExistingData = true;
		IgnoreDuplicates = false;
		jobGroupsToDelete.Clear();
		jobsToDelete.Clear();
		triggerGroupsToDelete.Clear();
		triggersToDelete.Clear();
		loadedJobs.Clear();
		loadedTriggers.Clear();
	}

	protected virtual void ProcessInternal(string xml)
	{
		PrepForProcessing();
		ValidateXml(xml);
		MaybeThrowValidationException();
		XmlSerializer xs = new XmlSerializer(typeof(QuartzXmlConfiguration20));
		QuartzXmlConfiguration20 data = (QuartzXmlConfiguration20)xs.Deserialize(new StringReader(xml));
		if (data == null)
		{
			throw new SchedulerConfigException("Job definition data from XML was null after deserialization");
		}
		if (data.preprocessingcommands != null)
		{
			preprocessingcommandsType[] preprocessingcommands = data.preprocessingcommands;
			foreach (preprocessingcommandsType command in preprocessingcommands)
			{
				if (command.deletejobsingroup != null)
				{
					string[] deletejobsingroup = command.deletejobsingroup;
					foreach (string s4 in deletejobsingroup)
					{
						string deleteJobGroup = s4.NullSafeTrim();
						if (!string.IsNullOrEmpty(deleteJobGroup))
						{
							jobGroupsToDelete.Add(deleteJobGroup);
						}
					}
				}
				if (command.deletetriggersingroup != null)
				{
					string[] deletejobsingroup = command.deletetriggersingroup;
					foreach (string s3 in deletejobsingroup)
					{
						string deleteTriggerGroup = s3.NullSafeTrim();
						if (!string.IsNullOrEmpty(deleteTriggerGroup))
						{
							triggerGroupsToDelete.Add(deleteTriggerGroup);
						}
					}
				}
				if (command.deletejob != null)
				{
					preprocessingcommandsTypeDeletejob[] deletejob = command.deletejob;
					foreach (preprocessingcommandsTypeDeletejob s2 in deletejob)
					{
						string name2 = s2.name.TrimEmptyToNull();
						string group2 = s2.group.TrimEmptyToNull();
						if (name2 == null)
						{
							throw new SchedulerConfigException("Encountered a 'delete-job' command without a name specified.");
						}
						jobsToDelete.Add(new JobKey(name2, group2));
					}
				}
				if (command.deletetrigger == null)
				{
					continue;
				}
				preprocessingcommandsTypeDeletetrigger[] deletetrigger = command.deletetrigger;
				foreach (preprocessingcommandsTypeDeletetrigger s in deletetrigger)
				{
					string name = s.name.TrimEmptyToNull();
					string group = s.group.TrimEmptyToNull();
					if (name == null)
					{
						throw new SchedulerConfigException("Encountered a 'delete-trigger' command without a name specified.");
					}
					triggersToDelete.Add(new TriggerKey(name, group));
				}
			}
		}
		if (log.IsDebugEnabled)
		{
			log.Debug("Found " + jobGroupsToDelete.Count + " delete job group commands.");
			log.Debug("Found " + triggerGroupsToDelete.Count + " delete trigger group commands.");
			log.Debug("Found " + jobsToDelete.Count + " delete job commands.");
			log.Debug("Found " + triggersToDelete.Count + " delete trigger commands.");
		}
		if (data.processingdirectives != null && data.processingdirectives.Length > 0)
		{
			bool overWrite = data.processingdirectives[0].overwriteexistingdata;
			log.Debug("Directive 'overwrite-existing-data' specified as: " + overWrite);
			OverWriteExistingData = overWrite;
		}
		else
		{
			log.Debug("Directive 'ignore-duplicates' not specified, defaulting to " + IgnoreDuplicates);
		}
		if (data.processingdirectives != null && data.processingdirectives.Length > 0)
		{
			bool ignoreduplicates = data.processingdirectives[0].ignoreduplicates;
			log.Debug("Directive 'ignore-duplicates' specified as: " + ignoreduplicates);
			IgnoreDuplicates = ignoreduplicates;
		}
		else
		{
			log.Debug("Directive 'overwrite-existing-data' not specified, defaulting to " + OverWriteExistingData);
		}
		if (data.processingdirectives != null && data.processingdirectives.Length > 0)
		{
			bool scheduleRelative = data.processingdirectives[0].scheduletriggerrelativetoreplacedtrigger;
			log.Debug("Directive 'schedule-trigger-relative-to-replaced-trigger' specified as: " + scheduleRelative);
			ScheduleTriggerRelativeToReplacedTrigger = scheduleRelative;
		}
		else
		{
			log.Debug("Directive 'schedule-trigger-relative-to-replaced-trigger' not specified, defaulting to " + ScheduleTriggerRelativeToReplacedTrigger);
		}
		List<jobdetailType> jobNodes = new List<jobdetailType>();
		if (data.schedule != null && data.schedule.Length > 0 && data.schedule[0].job != null)
		{
			jobNodes.AddRange(data.schedule[0].job);
		}
		log.Debug("Found " + jobNodes.Count + " job definitions.");
		foreach (jobdetailType jobDetailType in jobNodes)
		{
			string jobName = jobDetailType.name.TrimEmptyToNull();
			string jobGroup = jobDetailType.group.TrimEmptyToNull();
			string jobDescription = jobDetailType.description.TrimEmptyToNull();
			string jobTypeName = jobDetailType.jobtype.TrimEmptyToNull();
			bool jobDurability = jobDetailType.durable;
			bool jobRecoveryRequested = jobDetailType.recover;
			Type jobType = typeLoadHelper.LoadType(jobTypeName);
			IJobDetail jobDetail = JobBuilder.Create(jobType).WithIdentity(jobName, jobGroup).WithDescription(jobDescription)
				.StoreDurably(jobDurability)
				.RequestRecovery(jobRecoveryRequested)
				.Build();
			if (jobDetailType.jobdatamap != null && jobDetailType.jobdatamap.entry != null)
			{
				entryType[] entry3 = jobDetailType.jobdatamap.entry;
				foreach (entryType entry2 in entry3)
				{
					string key2 = entry2.key.TrimEmptyToNull();
					string value2 = entry2.value.TrimEmptyToNull();
					jobDetail.JobDataMap.Add(key2, value2);
				}
			}
			if (log.IsDebugEnabled)
			{
				log.Debug("Parsed job definition: " + jobDetail);
			}
			AddJobToSchedule(jobDetail);
		}
		List<triggerType> triggerEntries = new List<triggerType>();
		if (data.schedule != null && data.schedule.Length > 0 && data.schedule[0].trigger != null)
		{
			triggerEntries.AddRange(data.schedule[0].trigger);
		}
		log.Debug("Found " + triggerEntries.Count + " trigger definitions.");
		foreach (triggerType triggerNode in triggerEntries)
		{
			string triggerName = triggerNode.Item.name.TrimEmptyToNull();
			string triggerGroup = triggerNode.Item.group.TrimEmptyToNull();
			string triggerDescription = triggerNode.Item.description.TrimEmptyToNull();
			string triggerCalendarRef = triggerNode.Item.calendarname.TrimEmptyToNull();
			string triggerJobName = triggerNode.Item.jobname.TrimEmptyToNull();
			string triggerJobGroup = triggerNode.Item.jobgroup.TrimEmptyToNull();
			int triggerPriority = 5;
			if (!triggerNode.Item.priority.IsNullOrWhiteSpace())
			{
				triggerPriority = Convert.ToInt32(triggerNode.Item.priority);
			}
			DateTimeOffset triggerStartTime = SystemTime.UtcNow();
			if (triggerNode.Item.Item != null)
			{
				triggerStartTime = ((!(triggerNode.Item.Item is DateTime)) ? triggerStartTime.AddSeconds(Convert.ToInt32(triggerNode.Item.Item)) : new DateTimeOffset((DateTime)triggerNode.Item.Item));
			}
			DateTime? triggerEndTime = (triggerNode.Item.endtimeSpecified ? new DateTime?(triggerNode.Item.endtime) : null);
			IScheduleBuilder sched;
			if (triggerNode.Item is simpleTriggerType)
			{
				simpleTriggerType simpleTrigger = (simpleTriggerType)triggerNode.Item;
				string repeatCountString = simpleTrigger.repeatcount.TrimEmptyToNull();
				string repeatIntervalString2 = simpleTrigger.repeatinterval.TrimEmptyToNull();
				int repeatCount = ParseSimpleTriggerRepeatCount(repeatCountString);
				TimeSpan repeatInterval2 = ((repeatIntervalString2 == null) ? TimeSpan.Zero : TimeSpan.FromMilliseconds(Convert.ToInt64(repeatIntervalString2)));
				sched = SimpleScheduleBuilder.Create().WithInterval(repeatInterval2).WithRepeatCount(repeatCount);
				if (!simpleTrigger.misfireinstruction.IsNullOrWhiteSpace())
				{
					((SimpleScheduleBuilder)sched).WithMisfireHandlingInstruction(ReadMisfireInstructionFromString(simpleTrigger.misfireinstruction));
				}
			}
			else if (triggerNode.Item is cronTriggerType)
			{
				cronTriggerType cronTrigger = (cronTriggerType)triggerNode.Item;
				string cronExpression = cronTrigger.cronexpression.TrimEmptyToNull();
				string timezoneString = cronTrigger.timezone.TrimEmptyToNull();
				TimeZoneInfo tz = ((timezoneString != null) ? TimeZoneInfo.FindSystemTimeZoneById(timezoneString) : null);
				sched = CronScheduleBuilder.CronSchedule(cronExpression).InTimeZone(tz);
				if (!cronTrigger.misfireinstruction.IsNullOrWhiteSpace())
				{
					((CronScheduleBuilder)sched).WithMisfireHandlingInstruction(ReadMisfireInstructionFromString(cronTrigger.misfireinstruction));
				}
			}
			else
			{
				if (!(triggerNode.Item is calendarIntervalTriggerType))
				{
					throw new SchedulerConfigException("Unknown trigger type in XML configuration");
				}
				calendarIntervalTriggerType calendarIntervalTrigger = (calendarIntervalTriggerType)triggerNode.Item;
				string repeatIntervalString = calendarIntervalTrigger.repeatinterval.TrimEmptyToNull();
				IntervalUnit intervalUnit = ParseDateIntervalTriggerIntervalUnit(calendarIntervalTrigger.repeatintervalunit.TrimEmptyToNull());
				int repeatInterval = ((repeatIntervalString != null) ? Convert.ToInt32(repeatIntervalString) : 0);
				sched = CalendarIntervalScheduleBuilder.Create().WithInterval(repeatInterval, intervalUnit);
				if (!calendarIntervalTrigger.misfireinstruction.IsNullOrWhiteSpace())
				{
					((CalendarIntervalScheduleBuilder)sched).WithMisfireHandlingInstruction(ReadMisfireInstructionFromString(calendarIntervalTrigger.misfireinstruction));
				}
			}
			IMutableTrigger trigger = (IMutableTrigger)TriggerBuilder.Create().WithIdentity(triggerName, triggerGroup).WithDescription(triggerDescription)
				.ForJob(triggerJobName, triggerJobGroup)
				.StartAt(triggerStartTime)
				.EndAt(triggerEndTime)
				.WithPriority(triggerPriority)
				.ModifiedByCalendar(triggerCalendarRef)
				.WithSchedule(sched)
				.Build();
			if (triggerNode.Item.jobdatamap != null && triggerNode.Item.jobdatamap.entry != null)
			{
				entryType[] entry3 = triggerNode.Item.jobdatamap.entry;
				foreach (entryType entry in entry3)
				{
					string key = entry.key.TrimEmptyToNull();
					string value = entry.value.TrimEmptyToNull();
					trigger.JobDataMap.Add(key, value);
				}
			}
			if (log.IsDebugEnabled)
			{
				log.Debug("Parsed trigger definition: " + trigger);
			}
			AddTriggerToSchedule(trigger);
		}
	}

	protected virtual void AddJobToSchedule(IJobDetail job)
	{
		loadedJobs.Add(job);
	}

	protected virtual void AddTriggerToSchedule(IMutableTrigger trigger)
	{
		loadedTriggers.Add(trigger);
	}

	protected virtual int ParseSimpleTriggerRepeatCount(string repeatcount)
	{
		return Convert.ToInt32(repeatcount, CultureInfo.InvariantCulture);
	}

	protected virtual int ReadMisfireInstructionFromString(string misfireinstruction)
	{
		Constants c = new Constants(typeof(MisfireInstruction), typeof(MisfireInstruction.CronTrigger), typeof(MisfireInstruction.SimpleTrigger));
		return c.AsNumber(misfireinstruction);
	}

	protected virtual IntervalUnit ParseDateIntervalTriggerIntervalUnit(string intervalUnit)
	{
		if (string.IsNullOrEmpty(intervalUnit))
		{
			return IntervalUnit.Day;
		}
		if (!TryParseEnum<IntervalUnit>(intervalUnit, out var retValue))
		{
			throw new SchedulerConfigException("Unknown interval unit for DateIntervalTrigger: " + intervalUnit);
		}
		return retValue;
	}

	protected virtual bool TryParseEnum<T>(string str, out T value) where T : struct
	{
		string[] names = Enum.GetNames(typeof(T));
		value = (Enum.GetValues(typeof(T)) as T[])[0];
		string[] array = names;
		foreach (string name in array)
		{
			if (name == str)
			{
				value = (T)Enum.Parse(typeof(T), name);
				return true;
			}
		}
		return false;
	}

	private void ValidateXml(string xml)
	{
		try
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationType = ValidationType.Schema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
			Stream stream = GetType().Assembly.GetManifestResourceStream("Quartz.Xml.job_scheduling_data_2_0.xsd");
			XmlSchema schema = XmlSchema.Read(stream, XmlValidationCallBack);
			settings.Schemas.Add(schema);
			settings.ValidationEventHandler += XmlValidationCallBack;
			using XmlReader reader = XmlReader.Create(new StringReader(xml), settings);
			while (reader.Read())
			{
			}
		}
		catch (Exception ex)
		{
			log.Warn("Unable to validate XML with schema: " + ex.Message, ex);
		}
	}

	private void XmlValidationCallBack(object sender, ValidationEventArgs e)
	{
		if (e.Severity == XmlSeverityType.Error)
		{
			validationExceptions.Add(e.Exception);
		}
		else
		{
			Log.Warn(e.Message);
		}
	}

	/// <summary>
	/// Process the xml file in the default location, and schedule all of the jobs defined within it.
	/// </summary>
	/// <remarks>Note that we will set overWriteExistingJobs after the default xml is parsed.</remarks>
	/// <param name="sched"></param>
	/// <param name="overWriteExistingJobs"></param>
	public void ProcessFileAndScheduleJobs(IScheduler sched, bool overWriteExistingJobs)
	{
		ProcessFile("quartz_jobs.xml", "quartz_jobs.xml");
		OverWriteExistingData = overWriteExistingJobs;
		ExecutePreProcessCommands(sched);
		ScheduleJobs(sched);
	}

	/// <summary> 
	/// Process the xml file in the default location, and schedule all of the
	/// jobs defined within it.
	/// </summary>
	public virtual void ProcessFileAndScheduleJobs(IScheduler sched)
	{
		ProcessFileAndScheduleJobs("quartz_jobs.xml", sched);
	}

	/// <summary>
	/// Process the xml file in the given location, and schedule all of the
	/// jobs defined within it.
	/// </summary>
	/// <param name="fileName">meta data file name.</param>
	/// <param name="sched">The scheduler.</param>
	public virtual void ProcessFileAndScheduleJobs(string fileName, IScheduler sched)
	{
		ProcessFileAndScheduleJobs(fileName, fileName, sched);
	}

	/// <summary>
	/// Process the xml file in the given location, and schedule all of the
	/// jobs defined within it.
	/// </summary>
	/// <param name="fileName">Name of the file.</param>
	/// <param name="systemId">The system id.</param>
	/// <param name="sched">The sched.</param>
	public virtual void ProcessFileAndScheduleJobs(string fileName, string systemId, IScheduler sched)
	{
		LogicalThreadContext.SetData("quartz_scheduler", sched);
		try
		{
			ProcessFile(fileName, systemId);
			ExecutePreProcessCommands(sched);
			ScheduleJobs(sched);
		}
		finally
		{
			LogicalThreadContext.FreeNamedDataSlot("quartz_scheduler");
		}
	}

	/// <summary>
	/// Schedules the given sets of jobs and triggers.
	/// </summary>
	/// <param name="sched">The sched.</param>
	public virtual void ScheduleJobs(IScheduler sched)
	{
		List<IJobDetail> jobs = new List<IJobDetail>(LoadedJobs);
		List<ITrigger> triggers = new List<ITrigger>(LoadedTriggers);
		log.Info("Adding " + jobs.Count + " jobs, " + triggers.Count + " triggers.");
		IDictionary<JobKey, List<IMutableTrigger>> triggersByFQJobName = BuildTriggersByFQJobNameMap(triggers);
		while (jobs.Count > 0)
		{
			IJobDetail detail = jobs[0];
			jobs.Remove(detail);
			IJobDetail dupeJ = sched.GetJobDetail(detail.Key);
			if (dupeJ != null)
			{
				if (!OverWriteExistingData && IgnoreDuplicates)
				{
					log.Info("Not overwriting existing job: " + dupeJ.Key);
					continue;
				}
				if (!OverWriteExistingData && !IgnoreDuplicates)
				{
					throw new ObjectAlreadyExistsException(detail);
				}
			}
			if (dupeJ != null)
			{
				log.Info("Replacing job: " + detail.Key);
			}
			else
			{
				log.Info("Adding job: " + detail.Key);
			}
			triggersByFQJobName.TryGetValue(detail.Key, out var triggersOfJob);
			if (!detail.Durable && (triggersOfJob == null || triggersOfJob.Count == 0))
			{
				if (dupeJ == null)
				{
					throw new SchedulerException("A new job defined without any triggers must be durable: " + detail.Key);
				}
				if (dupeJ.Durable && sched.GetTriggersOfJob(detail.Key).Count == 0)
				{
					throw new SchedulerException("Can't change existing durable job without triggers to non-durable: " + detail.Key);
				}
			}
			if (dupeJ != null || detail.Durable)
			{
				sched.AddJob(detail, replace: true);
				continue;
			}
			bool addJobWithFirstSchedule = true;
			while (triggersOfJob.Count > 0)
			{
				IMutableTrigger trigger = triggersOfJob[0];
				triggersOfJob.Remove(trigger);
				ITrigger dupeT = sched.GetTrigger(trigger.Key);
				if (dupeT != null)
				{
					if (OverWriteExistingData)
					{
						if (log.IsDebugEnabled)
						{
							log.DebugFormat("Rescheduling job: {0} with updated trigger: {1}", trigger.JobKey, trigger.Key);
						}
						if (!dupeT.JobKey.Equals(trigger.JobKey))
						{
							log.WarnFormat("Possibly duplicately named ({0}) triggers in jobs xml file! ", trigger.Key);
						}
						DoRescheduleJob(sched, trigger, dupeT);
					}
					else
					{
						if (!IgnoreDuplicates)
						{
							throw new ObjectAlreadyExistsException(trigger);
						}
						log.Info("Not overwriting existing trigger: " + dupeT.Key);
					}
					continue;
				}
				if (log.IsDebugEnabled)
				{
					log.DebugFormat("Scheduling job: {0} with trigger: {1}", trigger.JobKey, trigger.Key);
				}
				try
				{
					if (addJobWithFirstSchedule)
					{
						sched.ScheduleJob(detail, trigger);
						addJobWithFirstSchedule = false;
					}
					else
					{
						sched.ScheduleJob(trigger);
					}
				}
				catch (ObjectAlreadyExistsException)
				{
					if (log.IsDebugEnabled)
					{
						log.DebugFormat("Adding trigger: {0} for job: {1} failed because the trigger already existed.  This is likely due to a race condition between multiple instances in the cluster.  Will try to reschedule instead.", trigger.Key, detail.Key);
					}
					DoRescheduleJob(sched, trigger, sched.GetTrigger(trigger.Key));
				}
			}
		}
		foreach (IMutableTrigger trigger2 in triggers)
		{
			ITrigger dupeT2 = sched.GetTrigger(trigger2.Key);
			if (dupeT2 != null)
			{
				if (OverWriteExistingData)
				{
					if (log.IsDebugEnabled)
					{
						log.DebugFormat(string.Concat("Rescheduling job: ", trigger2.JobKey, " with updated trigger: ", trigger2.Key));
					}
					if (!dupeT2.JobKey.Equals(trigger2.JobKey))
					{
						log.WarnFormat("Possibly duplicately named ({0}) triggers in jobs xml file! ", trigger2.Key);
					}
					DoRescheduleJob(sched, trigger2, dupeT2);
				}
				else
				{
					if (!IgnoreDuplicates)
					{
						throw new ObjectAlreadyExistsException(trigger2);
					}
					log.Info("Not overwriting existing trigger: " + dupeT2.Key);
				}
				continue;
			}
			if (log.IsDebugEnabled)
			{
				log.DebugFormat("Scheduling job: {0} with trigger: {1}", trigger2.JobKey, trigger2.Key);
			}
			try
			{
				sched.ScheduleJob(trigger2);
			}
			catch (ObjectAlreadyExistsException)
			{
				if (log.IsDebugEnabled)
				{
					log.Debug(string.Concat("Adding trigger: ", trigger2.Key, " for job: ", trigger2.JobKey, " failed because the trigger already existed.  This is likely due to a race condition between multiple instances in the cluster.  Will try to reschedule instead."));
				}
				DoRescheduleJob(sched, trigger2, sched.GetTrigger(trigger2.Key));
			}
		}
	}

	private void DoRescheduleJob(IScheduler sched, IMutableTrigger trigger, ITrigger oldTrigger)
	{
		if (oldTrigger != null && trigger.StartTimeUtc - SystemTime.UtcNow() < TimeSpan.FromSeconds(5.0) && ScheduleTriggerRelativeToReplacedTrigger)
		{
			Log.DebugFormat("Using relative scheduling for trigger with key {0}", trigger.Key);
			DateTimeOffset? oldTriggerPreviousFireTime = oldTrigger.GetPreviousFireTimeUtc();
			trigger.StartTimeUtc = oldTrigger.StartTimeUtc;
			((IOperableTrigger)trigger).SetPreviousFireTimeUtc(oldTriggerPreviousFireTime);
			((IOperableTrigger)trigger).SetNextFireTimeUtc(trigger.GetFireTimeAfter(oldTriggerPreviousFireTime));
		}
		sched.RescheduleJob(trigger.Key, trigger);
	}

	protected virtual IDictionary<JobKey, List<IMutableTrigger>> BuildTriggersByFQJobNameMap(List<ITrigger> triggers)
	{
		IDictionary<JobKey, List<IMutableTrigger>> triggersByFQJobName = new Dictionary<JobKey, List<IMutableTrigger>>();
		foreach (IMutableTrigger trigger in triggers)
		{
			if (!triggersByFQJobName.TryGetValue(trigger.JobKey, out var triggersOfJob))
			{
				triggersOfJob = new List<IMutableTrigger>();
				triggersByFQJobName[trigger.JobKey] = triggersOfJob;
			}
			triggersOfJob.Add(trigger);
		}
		return triggersByFQJobName;
	}

	protected void ExecutePreProcessCommands(IScheduler scheduler)
	{
		foreach (string group2 in jobGroupsToDelete)
		{
			if (group2.Equals("*"))
			{
				log.Info("Deleting all jobs in ALL groups.");
				foreach (string groupName2 in scheduler.GetJobGroupNames())
				{
					if (jobGroupsToNeverDelete.Contains(groupName2))
					{
						continue;
					}
					foreach (JobKey key6 in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName2)))
					{
						scheduler.DeleteJob(key6);
					}
				}
			}
			else
			{
				if (jobGroupsToNeverDelete.Contains(group2))
				{
					continue;
				}
				log.InfoFormat("Deleting all jobs in group: {}", group2);
				foreach (JobKey key5 in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(group2)))
				{
					scheduler.DeleteJob(key5);
				}
			}
		}
		foreach (string group in triggerGroupsToDelete)
		{
			if (group.Equals("*"))
			{
				log.Info("Deleting all triggers in ALL groups.");
				foreach (string groupName in scheduler.GetTriggerGroupNames())
				{
					if (triggerGroupsToNeverDelete.Contains(groupName))
					{
						continue;
					}
					foreach (TriggerKey key4 in scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(groupName)))
					{
						scheduler.UnscheduleJob(key4);
					}
				}
			}
			else
			{
				if (triggerGroupsToNeverDelete.Contains(group))
				{
					continue;
				}
				log.InfoFormat("Deleting all triggers in group: {0}", group);
				foreach (TriggerKey key3 in scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(group)))
				{
					scheduler.UnscheduleJob(key3);
				}
			}
		}
		foreach (JobKey key2 in jobsToDelete)
		{
			if (!jobGroupsToNeverDelete.Contains(key2.Group))
			{
				log.InfoFormat("Deleting job: {0}", key2);
				scheduler.DeleteJob(key2);
			}
		}
		foreach (TriggerKey key in triggersToDelete)
		{
			if (!triggerGroupsToNeverDelete.Contains(key.Group))
			{
				log.InfoFormat("Deleting trigger: {0}", key);
				scheduler.UnscheduleJob(key);
			}
		}
	}

	/// <summary>
	/// Adds a detected validation exception.
	/// </summary>
	/// <param name="e">The exception.</param>
	protected virtual void AddValidationException(XmlException e)
	{
		validationExceptions.Add(e);
	}

	/// <summary>
	/// Resets the the number of detected validation exceptions.
	/// </summary>
	protected virtual void ClearValidationExceptions()
	{
		validationExceptions.Clear();
	}

	/// <summary>
	/// Throws a ValidationException if the number of validationExceptions
	/// detected is greater than zero.
	/// </summary>
	/// <exception cref="T:Quartz.Xml.ValidationException"> 
	/// DTD validation exception.
	/// </exception>
	protected virtual void MaybeThrowValidationException()
	{
		if (validationExceptions.Count > 0)
		{
			throw new ValidationException(validationExceptions);
		}
	}

	public void AddJobGroupToNeverDelete(string jobGroupName)
	{
		jobGroupsToNeverDelete.Add(jobGroupName);
	}

	public void AddTriggerGroupToNeverDelete(string triggerGroupName)
	{
		triggerGroupsToNeverDelete.Add(triggerGroupName);
	}
}
