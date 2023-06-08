using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// This class implements a <see cref="T:Quartz.Spi.IJobStore" /> that
/// utilizes RAM as its storage device.
/// <para>
/// As you should know, the ramification of this is that access is extrememly
/// fast, but the data is completely volatile - therefore this <see cref="T:Quartz.Spi.IJobStore" />
/// should not be used if true persistence between program shutdowns is
/// required.
/// </para>
/// </summary>
/// <author>James House</author>
/// <author>Sharada Jambula</author>
/// <author>Marko Lahma (.NET)</author>
public class RAMJobStore : IJobStore
{
	private readonly Dictionary<JobKey, JobWrapper> jobsByKey = new Dictionary<JobKey, JobWrapper>(1000);

	private readonly Dictionary<TriggerKey, TriggerWrapper> triggersByKey = new Dictionary<TriggerKey, TriggerWrapper>(1000);

	private readonly Dictionary<string, IDictionary<JobKey, JobWrapper>> jobsByGroup = new Dictionary<string, IDictionary<JobKey, JobWrapper>>(25);

	private readonly Dictionary<string, IDictionary<TriggerKey, TriggerWrapper>> triggersByGroup = new Dictionary<string, IDictionary<TriggerKey, TriggerWrapper>>(25);

	private readonly TreeSet<TriggerWrapper> timeTriggers = new TreeSet<TriggerWrapper>(new TriggerWrapperComparator());

	private readonly Dictionary<string, ICalendar> calendarsByName = new Dictionary<string, ICalendar>(5);

	private readonly List<TriggerWrapper> triggers = new List<TriggerWrapper>(1000);

	private readonly object lockObject = new object();

	private readonly Quartz.Collection.HashSet<string> pausedTriggerGroups = new Quartz.Collection.HashSet<string>();

	private readonly Quartz.Collection.HashSet<string> pausedJobGroups = new Quartz.Collection.HashSet<string>();

	private readonly Quartz.Collection.HashSet<JobKey> blockedJobs = new Quartz.Collection.HashSet<JobKey>();

	private TimeSpan misfireThreshold = TimeSpan.FromSeconds(5.0);

	private ISchedulerSignaler signaler;

	private readonly ILog log;

	private static long ftrCtr = SystemTime.UtcNow().Ticks;

	/// <summary> 
	/// The time span by which a trigger must have missed its
	/// next-fire-time, in order for it to be considered "misfired" and thus
	/// have its misfire instruction applied.
	/// </summary>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	public virtual TimeSpan MisfireThreshold
	{
		get
		{
			return misfireThreshold;
		}
		set
		{
			if (value.TotalMilliseconds < 1.0)
			{
				throw new ArgumentException("Misfirethreashold must be larger than 0");
			}
			misfireThreshold = value;
		}
	}

	/// <summary>
	/// Returns whether this instance supports persistence.
	/// </summary>
	/// <value></value>
	/// <returns></returns>
	public virtual bool SupportsPersistence => false;

	protected ILog Log => log;

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> of the Scheduler instance's Id, 
	/// prior to initialize being invoked.
	/// </summary>
	public virtual string InstanceId
	{
		set
		{
		}
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> of the Scheduler instance's name, 
	/// prior to initialize being invoked.
	/// </summary>
	public virtual string InstanceName
	{
		set
		{
		}
	}

	public int ThreadPoolSize
	{
		set
		{
		}
	}

	public long EstimatedTimeToReleaseAndAcquireTrigger => 5L;

	public bool Clustered => false;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Simpl.RAMJobStore" /> class.
	/// </summary>
	public RAMJobStore()
	{
		log = LogManager.GetLogger(GetType());
	}

	/// <summary>
	/// Gets the fired trigger record id.
	/// </summary>
	/// <returns>The fired trigger record id.</returns>
	protected virtual string GetFiredTriggerRecordId()
	{
		long value = Interlocked.Increment(ref ftrCtr);
		return Convert.ToString(value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Called by the QuartzScheduler before the <see cref="T:Quartz.Spi.IJobStore" /> is
	/// used, in order to give the it a chance to Initialize.
	/// </summary>
	public virtual void Initialize(ITypeLoadHelper loadHelper, ISchedulerSignaler s)
	{
		signaler = s;
		Log.Info("RAMJobStore initialized.");
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the <see cref="T:Quartz.Spi.IJobStore" /> that
	/// the scheduler has started.
	/// </summary>
	public virtual void SchedulerStarted()
	{
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the JobStore that
	/// the scheduler has been paused.
	/// </summary>
	public void SchedulerPaused()
	{
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the JobStore that
	/// the scheduler has resumed after being paused.
	/// </summary>
	public void SchedulerResumed()
	{
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the <see cref="T:Quartz.Spi.IJobStore" /> that
	/// it should free up all of it's resources because the scheduler is
	/// shutting down.
	/// </summary>
	public virtual void Shutdown()
	{
	}

	/// <summary>
	/// Clears (deletes!) all scheduling data - all <see cref="T:Quartz.IJob" />s, <see cref="T:Quartz.ITrigger" />s
	/// <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	public void ClearAllSchedulingData()
	{
		lock (lockObject)
		{
			IList<string> lst = GetTriggerGroupNames();
			foreach (string group2 in lst)
			{
				Quartz.Collection.ISet<TriggerKey> keys2 = GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(group2));
				foreach (TriggerKey key2 in keys2)
				{
					RemoveTrigger(key2);
				}
			}
			lst = GetJobGroupNames();
			foreach (string group in lst)
			{
				Quartz.Collection.ISet<JobKey> keys = GetJobKeys(GroupMatcher<JobKey>.GroupEquals(group));
				foreach (JobKey key in keys)
				{
					RemoveJob(key);
				}
			}
			lst = GetCalendarNames();
			foreach (string name in lst)
			{
				RemoveCalendar(name);
			}
		}
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.IJobDetail" /> and <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="newJob">The <see cref="T:Quartz.IJobDetail" /> to be stored.</param>
	/// <param name="newTrigger">The <see cref="T:Quartz.ITrigger" /> to be stored.</param>
	public virtual void StoreJobAndTrigger(IJobDetail newJob, IOperableTrigger newTrigger)
	{
		StoreJob(newJob, replaceExisting: false);
		StoreTrigger(newTrigger, replaceExisting: false);
	}

	/// <summary>
	/// Returns true if the given job group is paused.
	/// </summary>
	/// <param name="groupName">Job group name</param>
	/// <returns></returns>
	public virtual bool IsJobGroupPaused(string groupName)
	{
		return pausedJobGroups.Contains(groupName);
	}

	/// <summary>
	/// returns true if the given TriggerGroup is paused.
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	public virtual bool IsTriggerGroupPaused(string groupName)
	{
		return pausedTriggerGroups.Contains(groupName);
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.IJob" />.
	/// </summary>
	/// <param name="newJob">The <see cref="T:Quartz.IJob" /> to be stored.</param>
	/// <param name="replaceExisting">If <see langword="true" />, any <see cref="T:Quartz.IJob" /> existing in the
	/// <see cref="T:Quartz.Spi.IJobStore" /> with the same name and group should be
	/// over-written.</param>
	public virtual void StoreJob(IJobDetail newJob, bool replaceExisting)
	{
		JobWrapper jw = new JobWrapper((IJobDetail)newJob.Clone());
		bool repl = false;
		lock (lockObject)
		{
			if (jobsByKey.ContainsKey(jw.key))
			{
				if (!replaceExisting)
				{
					throw new ObjectAlreadyExistsException(newJob);
				}
				repl = true;
			}
			if (!repl)
			{
				if (!jobsByGroup.TryGetValue(newJob.Key.Group, out var grpMap))
				{
					grpMap = new Dictionary<JobKey, JobWrapper>(100);
					jobsByGroup[newJob.Key.Group] = grpMap;
				}
				grpMap[newJob.Key] = jw;
				jobsByKey[jw.key] = jw;
			}
			else
			{
				JobWrapper orig = jobsByKey[jw.key];
				orig.jobDetail = jw.jobDetail;
			}
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.IJob" /> with the given
	/// name, and any <see cref="T:Quartz.ITrigger" /> s that reference
	/// it.
	/// </summary>
	/// <returns>
	/// 	<see langword="true" /> if a <see cref="T:Quartz.IJob" /> with the given name and
	/// group was found and removed from the store.
	/// </returns>
	public virtual bool RemoveJob(JobKey jobKey)
	{
		bool found = false;
		lock (lockObject)
		{
			IList<IOperableTrigger> triggersForJob = GetTriggersForJob(jobKey);
			foreach (IOperableTrigger trigger in triggersForJob)
			{
				RemoveTrigger(trigger.Key);
				found = true;
			}
			if (jobsByKey.TryGetValue(jobKey, out var tempObject))
			{
				jobsByKey.Remove(jobKey);
			}
			found = tempObject != null || found;
			if (found)
			{
				jobsByGroup.TryGetValue(jobKey.Group, out var grpMap);
				if (grpMap != null)
				{
					grpMap.Remove(jobKey);
					if (grpMap.Count == 0)
					{
						jobsByGroup.Remove(jobKey.Group);
					}
				}
			}
		}
		return found;
	}

	public bool RemoveJobs(IList<JobKey> jobKeys)
	{
		bool allFound = true;
		lock (lockObject)
		{
			foreach (JobKey key in jobKeys)
			{
				allFound = RemoveJob(key) && allFound;
			}
			return allFound;
		}
	}

	public bool RemoveTriggers(IList<TriggerKey> triggerKeys)
	{
		bool allFound = true;
		lock (lockObject)
		{
			foreach (TriggerKey key in triggerKeys)
			{
				allFound = RemoveTrigger(key) && allFound;
			}
			return allFound;
		}
	}

	public void StoreJobsAndTriggers(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace)
	{
		lock (lockObject)
		{
			if (!replace)
			{
				foreach (IJobDetail job2 in triggersAndJobs.Keys)
				{
					if (CheckExists(job2.Key))
					{
						throw new ObjectAlreadyExistsException(job2);
					}
					foreach (ITrigger trigger2 in triggersAndJobs[job2])
					{
						if (CheckExists(trigger2.Key))
						{
							throw new ObjectAlreadyExistsException(trigger2);
						}
					}
				}
			}
			foreach (IJobDetail job in triggersAndJobs.Keys)
			{
				StoreJob(job, replaceExisting: true);
				foreach (ITrigger trigger in triggersAndJobs[job])
				{
					StoreTrigger((IOperableTrigger)trigger, replaceExisting: true);
				}
			}
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ITrigger" /> with the
	/// given name.
	/// </summary>
	/// <returns>
	/// 	<see langword="true" /> if a <see cref="T:Quartz.ITrigger" /> with the given
	/// name and group was found and removed from the store.
	/// </returns>
	public virtual bool RemoveTrigger(TriggerKey triggerKey)
	{
		return RemoveTrigger(triggerKey, removeOrphanedJob: true);
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="newTrigger">The <see cref="T:Quartz.ITrigger" /> to be stored.</param>
	/// <param name="replaceExisting">If <see langword="true" />, any <see cref="T:Quartz.ITrigger" /> existing in
	/// the <see cref="T:Quartz.Spi.IJobStore" /> with the same name and group should
	/// be over-written.</param>
	public virtual void StoreTrigger(IOperableTrigger newTrigger, bool replaceExisting)
	{
		TriggerWrapper tw = new TriggerWrapper((IOperableTrigger)newTrigger.Clone());
		lock (lockObject)
		{
			if (triggersByKey.TryGetValue(tw.key, out var _))
			{
				if (!replaceExisting)
				{
					throw new ObjectAlreadyExistsException(newTrigger);
				}
				RemoveTrigger(newTrigger.Key, removeOrphanedJob: false);
			}
			if (RetrieveJob(newTrigger.JobKey) == null)
			{
				throw new JobPersistenceException(string.Concat("The job (", newTrigger.JobKey, ") referenced by the trigger does not exist."));
			}
			triggers.Add(tw);
			triggersByGroup.TryGetValue(newTrigger.Key.Group, out var grpMap);
			if (grpMap == null)
			{
				grpMap = new Dictionary<TriggerKey, TriggerWrapper>(100);
				triggersByGroup[newTrigger.Key.Group] = grpMap;
			}
			grpMap[newTrigger.Key] = tw;
			triggersByKey[tw.key] = tw;
			if (pausedTriggerGroups.Contains(newTrigger.Key.Group) || pausedJobGroups.Contains(newTrigger.JobKey.Group))
			{
				tw.state = InternalTriggerState.Paused;
				if (blockedJobs.Contains(tw.jobKey))
				{
					tw.state = InternalTriggerState.PausedAndBlocked;
				}
			}
			else if (blockedJobs.Contains(tw.jobKey))
			{
				tw.state = InternalTriggerState.Blocked;
			}
			else
			{
				timeTriggers.Add(tw);
			}
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ITrigger" /> with the
	/// given name.
	///
	/// </summary>
	/// <returns>
	/// 	<see langword="true" /> if a <see cref="T:Quartz.ITrigger" /> with the given
	/// name and group was found and removed from the store.
	/// </returns>
	/// <param name="key">The <see cref="T:Quartz.ITrigger" /> to be removed.</param>
	/// <param name="removeOrphanedJob">Whether to delete orpahaned job details from scheduler if job becomes orphaned from removing the trigger.</param>
	public virtual bool RemoveTrigger(TriggerKey key, bool removeOrphanedJob)
	{
		bool found;
		lock (lockObject)
		{
			found = triggersByKey.Remove(key);
			if (found)
			{
				TriggerWrapper tw = null;
				if (triggersByGroup.TryGetValue(key.Group, out var grpMap))
				{
					grpMap.Remove(key);
					if (grpMap.Count == 0)
					{
						triggersByGroup.Remove(key.Group);
					}
				}
				for (int i = 0; i < triggers.Count; i++)
				{
					tw = triggers[i];
					if (key.Equals(tw.key))
					{
						triggers.RemoveAt(i);
						break;
					}
				}
				timeTriggers.Remove(tw);
				if (removeOrphanedJob)
				{
					JobWrapper jw = jobsByKey[tw.jobKey];
					IList<IOperableTrigger> trigs = GetTriggersForJob(tw.jobKey);
					if ((trigs == null || trigs.Count == 0) && !jw.jobDetail.Durable && RemoveJob(jw.key))
					{
						signaler.NotifySchedulerListenersJobDeleted(jw.key);
					}
				}
			}
		}
		return found;
	}

	/// <summary>
	/// Replaces the trigger.
	/// </summary>
	/// <param name="triggerKey">The <see cref="T:Quartz.TriggerKey" /> of the <see cref="T:Quartz.ITrigger" /> to be replaced.</param>
	/// <param name="newTrigger">The new trigger.</param>
	/// <returns></returns>
	public virtual bool ReplaceTrigger(TriggerKey triggerKey, IOperableTrigger newTrigger)
	{
		bool found;
		lock (lockObject)
		{
			if (triggersByKey.TryGetValue(triggerKey, out var tw))
			{
				triggersByKey.Remove(triggerKey);
			}
			found = tw != null;
			if (found)
			{
				if (!tw.trigger.JobKey.Equals(newTrigger.JobKey))
				{
					throw new JobPersistenceException("New trigger is not related to the same job as the old trigger.");
				}
				tw = null;
				triggersByGroup.TryGetValue(triggerKey.Group, out var grpMap);
				if (grpMap != null)
				{
					grpMap.Remove(triggerKey);
					if (grpMap.Count == 0)
					{
						triggersByGroup.Remove(triggerKey.Group);
					}
				}
				for (int i = 0; i < triggers.Count; i++)
				{
					tw = triggers[i];
					if (triggerKey.Equals(tw.key))
					{
						triggers.RemoveAt(i);
						break;
					}
				}
				timeTriggers.Remove(tw);
				try
				{
					StoreTrigger(newTrigger, replaceExisting: false);
				}
				catch (JobPersistenceException)
				{
					StoreTrigger(tw.trigger, replaceExisting: false);
					throw;
				}
			}
		}
		return found;
	}

	/// <summary>
	/// Retrieve the <see cref="T:Quartz.IJobDetail" /> for the given
	/// <see cref="T:Quartz.IJob" />.
	/// </summary>
	/// <returns>
	/// The desired <see cref="T:Quartz.IJob" />, or null if there is no match.
	/// </returns>
	public virtual IJobDetail RetrieveJob(JobKey jobKey)
	{
		lock (lockObject)
		{
			jobsByKey.TryGetValue(jobKey, out var jw);
			return (jw != null) ? ((IJobDetail)jw.jobDetail.Clone()) : null;
		}
	}

	/// <summary>
	/// Retrieve the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <returns>
	/// The desired <see cref="T:Quartz.ITrigger" />, or null if there is no match.
	/// </returns>
	public virtual IOperableTrigger RetrieveTrigger(TriggerKey triggerKey)
	{
		lock (lockObject)
		{
			triggersByKey.TryGetValue(triggerKey, out var tw);
			return (tw != null) ? ((IOperableTrigger)tw.trigger.Clone()) : null;
		}
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.IJob" /> with the given identifier already 
	/// exists within the scheduler.
	/// </summary>
	/// <param name="jobKey">the identifier to check for</param>
	/// <returns>true if a Job exists with the given identifier</returns>
	public bool CheckExists(JobKey jobKey)
	{
		lock (lockObject)
		{
			return jobsByKey.ContainsKey(jobKey);
		}
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.ITrigger" /> with the given identifier already 
	/// exists within the scheduler.
	/// </summary>
	/// <param name="triggerKey">triggerKey the identifier to check for</param>
	/// <returns>true if a Trigger exists with the given identifier</returns>
	public bool CheckExists(TriggerKey triggerKey)
	{
		lock (lockObject)
		{
			return triggersByKey.ContainsKey(triggerKey);
		}
	}

	/// <summary>
	/// Get the current state of the identified <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <seealso cref="F:Quartz.TriggerState.Normal" />
	/// <seealso cref="F:Quartz.TriggerState.Paused" />
	/// <seealso cref="F:Quartz.TriggerState.Complete" />
	/// <seealso cref="F:Quartz.TriggerState.Error" />
	/// <seealso cref="F:Quartz.TriggerState.Blocked" />
	/// <seealso cref="F:Quartz.TriggerState.None" />
	public virtual TriggerState GetTriggerState(TriggerKey triggerKey)
	{
		lock (lockObject)
		{
			triggersByKey.TryGetValue(triggerKey, out var tw);
			if (tw == null)
			{
				return TriggerState.None;
			}
			if (tw.state == InternalTriggerState.Complete)
			{
				return TriggerState.Complete;
			}
			if (tw.state == InternalTriggerState.Paused)
			{
				return TriggerState.Paused;
			}
			if (tw.state == InternalTriggerState.PausedAndBlocked)
			{
				return TriggerState.Paused;
			}
			if (tw.state == InternalTriggerState.Blocked)
			{
				return TriggerState.Blocked;
			}
			if (tw.state == InternalTriggerState.Error)
			{
				return TriggerState.Error;
			}
			return TriggerState.Normal;
		}
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.ICalendar" />.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="calendar">The <see cref="T:Quartz.ICalendar" /> to be stored.</param>
	/// <param name="replaceExisting">If <see langword="true" />, any <see cref="T:Quartz.ICalendar" /> existing
	/// in the <see cref="T:Quartz.Spi.IJobStore" /> with the same name and group
	/// should be over-written.</param>
	/// <param name="updateTriggers">If <see langword="true" />, any <see cref="T:Quartz.ITrigger" />s existing
	/// in the <see cref="T:Quartz.Spi.IJobStore" /> that reference an existing
	/// Calendar with the same name with have their next fire time
	/// re-computed with the new <see cref="T:Quartz.ICalendar" />.</param>
	public virtual void StoreCalendar(string name, ICalendar calendar, bool replaceExisting, bool updateTriggers)
	{
		calendar = (ICalendar)calendar.Clone();
		lock (lockObject)
		{
			calendarsByName.TryGetValue(name, out var obj);
			if (obj != null && !replaceExisting)
			{
				throw new ObjectAlreadyExistsException(string.Format(CultureInfo.InvariantCulture, "Calendar with name '{0}' already exists.", new object[1] { name }));
			}
			if (obj != null)
			{
				calendarsByName.Remove(name);
			}
			calendarsByName[name] = calendar;
			if (obj == null || !updateTriggers)
			{
				return;
			}
			List<TriggerWrapper> trigs = GetTriggerWrappersForCalendar(name);
			foreach (TriggerWrapper tw in trigs)
			{
				IOperableTrigger trig = tw.trigger;
				bool removed = timeTriggers.Remove(tw);
				trig.UpdateWithNewCalendar(calendar, MisfireThreshold);
				if (removed)
				{
					timeTriggers.Add(tw);
				}
			}
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ICalendar" /> with the
	/// given name.
	/// <para>
	/// If removal of the <see cref="T:Quartz.ICalendar" /> would result in
	/// <see cref="T:Quartz.ITrigger" />s pointing to non-existent calendars, then a
	/// <see cref="T:Quartz.JobPersistenceException" /> will be thrown.</para>
	/// </summary>
	/// <param name="calName">The name of the <see cref="T:Quartz.ICalendar" /> to be removed.</param>
	/// <returns>
	/// 	<see langword="true" /> if a <see cref="T:Quartz.ICalendar" /> with the given name
	/// was found and removed from the store.
	/// </returns>
	public virtual bool RemoveCalendar(string calName)
	{
		int numRefs = 0;
		lock (lockObject)
		{
			foreach (TriggerWrapper triggerWrapper in triggers)
			{
				IOperableTrigger trigg = triggerWrapper.trigger;
				if (trigg.CalendarName != null && trigg.CalendarName.Equals(calName))
				{
					numRefs++;
				}
			}
		}
		if (numRefs > 0)
		{
			throw new JobPersistenceException("Calender cannot be removed if it referenced by a Trigger!");
		}
		return calendarsByName.Remove(calName);
	}

	/// <summary>
	/// Retrieve the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="calName">The name of the <see cref="T:Quartz.ICalendar" /> to be retrieved.</param>
	/// <returns>
	/// The desired <see cref="T:Quartz.ICalendar" />, or null if there is no match.
	/// </returns>
	public virtual ICalendar RetrieveCalendar(string calName)
	{
		lock (lockObject)
		{
			calendarsByName.TryGetValue(calName, out var calendar);
			if (calendar != null)
			{
				return (ICalendar)calendar.Clone();
			}
			return null;
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.IJobDetail" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public virtual int GetNumberOfJobs()
	{
		lock (lockObject)
		{
			return jobsByKey.Count;
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.ITrigger" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public virtual int GetNumberOfTriggers()
	{
		lock (lockObject)
		{
			return triggers.Count;
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.ICalendar" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public virtual int GetNumberOfCalendars()
	{
		lock (lockObject)
		{
			return calendarsByName.Count;
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.IJob" /> s that
	/// match the given group matcher.
	/// </summary>
	public virtual Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
	{
		Quartz.Collection.ISet<JobKey> outList = null;
		lock (lockObject)
		{
			StringOperator op = matcher.CompareWithOperator;
			string compareToValue = matcher.CompareToValue;
			if (op == StringOperator.Equality)
			{
				jobsByGroup.TryGetValue(compareToValue, out var grpMap);
				if (grpMap != null)
				{
					outList = new Quartz.Collection.HashSet<JobKey>();
					foreach (JobWrapper jw in grpMap.Values)
					{
						if (jw != null)
						{
							outList.Add(jw.jobDetail.Key);
						}
					}
				}
			}
			else
			{
				foreach (KeyValuePair<string, IDictionary<JobKey, JobWrapper>> entry in jobsByGroup)
				{
					if (!op.Evaluate(entry.Key, compareToValue) || entry.Value == null)
					{
						continue;
					}
					if (outList == null)
					{
						outList = new Quartz.Collection.HashSet<JobKey>();
					}
					foreach (JobWrapper jobWrapper in entry.Value.Values)
					{
						if (jobWrapper != null)
						{
							outList.Add(jobWrapper.jobDetail.Key);
						}
					}
				}
			}
		}
		return outList ?? new Quartz.Collection.HashSet<JobKey>();
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ICalendar" /> s
	/// in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// <para>
	/// If there are no ICalendars in the given group name, the result should be
	/// a zero-length array (not <see langword="null" />).
	/// </para>
	/// </summary>
	public virtual IList<string> GetCalendarNames()
	{
		lock (lockObject)
		{
			return new List<string>(calendarsByName.Keys);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ITrigger" /> s
	/// that have the given group name.
	/// </summary>
	public virtual Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
	{
		Quartz.Collection.ISet<TriggerKey> outList = null;
		lock (lockObject)
		{
			StringOperator op = matcher.CompareWithOperator;
			string compareToValue = matcher.CompareToValue;
			if (op == StringOperator.Equality)
			{
				triggersByGroup.TryGetValue(compareToValue, out var grpMap);
				if (grpMap != null)
				{
					outList = new Quartz.Collection.HashSet<TriggerKey>();
					foreach (TriggerWrapper tw in grpMap.Values)
					{
						if (tw != null)
						{
							outList.Add(tw.trigger.Key);
						}
					}
				}
			}
			else
			{
				foreach (KeyValuePair<string, IDictionary<TriggerKey, TriggerWrapper>> entry in triggersByGroup)
				{
					if (!op.Evaluate(entry.Key, compareToValue) || entry.Value == null)
					{
						continue;
					}
					if (outList == null)
					{
						outList = new Quartz.Collection.HashSet<TriggerKey>();
					}
					foreach (TriggerWrapper triggerWrapper in entry.Value.Values)
					{
						if (triggerWrapper != null)
						{
							outList.Add(triggerWrapper.trigger.Key);
						}
					}
				}
			}
		}
		return outList ?? new Quartz.Collection.HashSet<TriggerKey>();
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.IJob" />
	/// groups.
	/// </summary>
	public virtual IList<string> GetJobGroupNames()
	{
		lock (lockObject)
		{
			return new List<string>(jobsByGroup.Keys);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ITrigger" /> groups.
	/// </summary>
	public virtual IList<string> GetTriggerGroupNames()
	{
		lock (lockObject)
		{
			return new List<string>(triggersByGroup.Keys);
		}
	}

	/// <summary>
	/// Get all of the Triggers that are associated to the given Job.
	/// <para>
	/// If there are no matches, a zero-length array should be returned.
	/// </para>
	/// </summary>
	public virtual IList<IOperableTrigger> GetTriggersForJob(JobKey jobKey)
	{
		List<IOperableTrigger> trigList = new List<IOperableTrigger>();
		lock (lockObject)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				TriggerWrapper tw = triggers[i];
				if (tw.jobKey.Equals(jobKey))
				{
					trigList.Add((IOperableTrigger)tw.trigger.Clone());
				}
			}
			return trigList;
		}
	}

	/// <summary>
	/// Gets the trigger wrappers for job.
	/// </summary>
	/// <returns></returns>
	protected virtual List<TriggerWrapper> GetTriggerWrappersForJob(JobKey jobKey)
	{
		List<TriggerWrapper> trigList = new List<TriggerWrapper>();
		lock (lockObject)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				TriggerWrapper tw = triggers[i];
				if (tw.jobKey.Equals(jobKey))
				{
					trigList.Add(tw);
				}
			}
			return trigList;
		}
	}

	/// <summary>
	/// Gets the trigger wrappers for calendar.
	/// </summary>
	/// <param name="calName">Name of the cal.</param>
	/// <returns></returns>
	protected virtual List<TriggerWrapper> GetTriggerWrappersForCalendar(string calName)
	{
		List<TriggerWrapper> trigList = new List<TriggerWrapper>();
		lock (lockObject)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				TriggerWrapper tw = triggers[i];
				string tcalName = tw.trigger.CalendarName;
				if (tcalName != null && tcalName.Equals(calName))
				{
					trigList.Add(tw);
				}
			}
			return trigList;
		}
	}

	/// <summary> 
	/// Pause the <see cref="T:Quartz.ITrigger" /> with the given name.
	/// </summary>
	public virtual void PauseTrigger(TriggerKey triggerKey)
	{
		lock (lockObject)
		{
			if (triggersByKey.TryGetValue(triggerKey, out var tw) && tw.trigger != null && tw.state != InternalTriggerState.Complete)
			{
				if (tw.state == InternalTriggerState.Blocked)
				{
					tw.state = InternalTriggerState.PausedAndBlocked;
				}
				else
				{
					tw.state = InternalTriggerState.Paused;
				}
				timeTriggers.Remove(tw);
			}
		}
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the given group.
	/// <para>
	/// The JobStore should "remember" that the group is paused, and impose the
	/// pause on any new triggers that are added to the group while the group is
	/// paused.
	/// </para>
	/// </summary>
	public virtual Quartz.Collection.ISet<string> PauseTriggers(GroupMatcher<TriggerKey> matcher)
	{
		IList<string> pausedGroups;
		lock (lockObject)
		{
			pausedGroups = new List<string>();
			StringOperator op = matcher.CompareWithOperator;
			if (op == StringOperator.Equality)
			{
				if (pausedTriggerGroups.Add(matcher.CompareToValue))
				{
					pausedGroups.Add(matcher.CompareToValue);
				}
			}
			else
			{
				foreach (string group in triggersByGroup.Keys)
				{
					if (op.Evaluate(group, matcher.CompareToValue) && pausedTriggerGroups.Add(matcher.CompareToValue))
					{
						pausedGroups.Add(group);
					}
				}
			}
			foreach (string pausedGroup in pausedGroups)
			{
				Quartz.Collection.ISet<TriggerKey> keys = GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(pausedGroup));
				foreach (TriggerKey key in keys)
				{
					PauseTrigger(key);
				}
			}
		}
		return new Quartz.Collection.HashSet<string>(pausedGroups);
	}

	/// <summary> 
	/// Pause the <see cref="T:Quartz.IJobDetail" /> with the given
	/// name - by pausing all of its current <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	public virtual void PauseJob(JobKey jobKey)
	{
		lock (lockObject)
		{
			IList<IOperableTrigger> triggersForJob = GetTriggersForJob(jobKey);
			foreach (IOperableTrigger trigger in triggersForJob)
			{
				PauseTrigger(trigger.Key);
			}
		}
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.IJobDetail" />s in the
	/// given group - by pausing all of their <see cref="T:Quartz.ITrigger" />s.
	/// <para>
	/// The JobStore should "remember" that the group is paused, and impose the
	/// pause on any new jobs that are added to the group while the group is
	/// paused.
	/// </para>
	/// </summary>
	public virtual IList<string> PauseJobs(GroupMatcher<JobKey> matcher)
	{
		List<string> pausedGroups = new List<string>();
		lock (lockObject)
		{
			StringOperator op = matcher.CompareWithOperator;
			if (op == StringOperator.Equality)
			{
				if (pausedJobGroups.Add(matcher.CompareToValue))
				{
					pausedGroups.Add(matcher.CompareToValue);
				}
			}
			else
			{
				foreach (string group in jobsByGroup.Keys)
				{
					if (op.Evaluate(group, matcher.CompareToValue) && pausedJobGroups.Add(group))
					{
						pausedGroups.Add(group);
					}
				}
			}
			foreach (string groupName in pausedGroups)
			{
				foreach (JobKey jobKey in GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName)))
				{
					IList<IOperableTrigger> triggers = GetTriggersForJob(jobKey);
					foreach (IOperableTrigger trigger in triggers)
					{
						PauseTrigger(trigger.Key);
					}
				}
			}
			return pausedGroups;
		}
	}

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.ITrigger" /> with the given key.
	/// </summary>
	/// <remarks>
	/// If the <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	public virtual void ResumeTrigger(TriggerKey triggerKey)
	{
		lock (lockObject)
		{
			if (!triggersByKey.TryGetValue(triggerKey, out var tw) || tw.trigger == null)
			{
				return;
			}
			IOperableTrigger trig = tw.trigger;
			if (tw.state == InternalTriggerState.Paused || tw.state == InternalTriggerState.PausedAndBlocked)
			{
				if (blockedJobs.Contains(trig.JobKey))
				{
					tw.state = InternalTriggerState.Blocked;
				}
				else
				{
					tw.state = InternalTriggerState.Waiting;
				}
				ApplyMisfire(tw);
				if (tw.state == InternalTriggerState.Waiting)
				{
					timeTriggers.Add(tw);
				}
			}
		}
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.ITrigger" />s in the
	/// given group.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual IList<string> ResumeTriggers(GroupMatcher<TriggerKey> matcher)
	{
		Quartz.Collection.ISet<string> groups = new Quartz.Collection.HashSet<string>();
		lock (lockObject)
		{
			Quartz.Collection.ISet<TriggerKey> keys = GetTriggerKeys(matcher);
			foreach (TriggerKey triggerKey in keys)
			{
				groups.Add(triggerKey.Group);
				if (triggersByKey.TryGetValue(triggerKey, out var tw))
				{
					string jobGroup = tw.jobKey.Group;
					if (pausedJobGroups.Contains(jobGroup))
					{
						continue;
					}
				}
				ResumeTrigger(triggerKey);
			}
			foreach (string group in groups)
			{
				pausedTriggerGroups.Remove(group);
			}
		}
		return new List<string>(groups);
	}

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.IJobDetail" /> with
	/// the given name.
	/// <para>
	/// If any of the <see cref="T:Quartz.IJob" />'s<see cref="T:Quartz.ITrigger" /> s missed one
	/// or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s misfire
	/// instruction will be applied.
	/// </para>
	/// </summary>
	public virtual void ResumeJob(JobKey jobKey)
	{
		lock (lockObject)
		{
			IList<IOperableTrigger> triggersForJob = GetTriggersForJob(jobKey);
			foreach (IOperableTrigger trigger in triggersForJob)
			{
				ResumeTrigger(trigger.Key);
			}
		}
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.IJobDetail" />s
	/// in the given group.
	/// <para>
	/// If any of the <see cref="T:Quartz.IJob" /> s had <see cref="T:Quartz.ITrigger" /> s that
	/// missed one or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s
	/// misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual Quartz.Collection.ISet<string> ResumeJobs(GroupMatcher<JobKey> matcher)
	{
		Quartz.Collection.ISet<string> resumedGroups = new Quartz.Collection.HashSet<string>();
		lock (lockObject)
		{
			Quartz.Collection.ISet<JobKey> keys = GetJobKeys(matcher);
			foreach (string pausedJobGroup in pausedJobGroups)
			{
				if (matcher.CompareWithOperator.Evaluate(pausedJobGroup, matcher.CompareToValue))
				{
					resumedGroups.Add(pausedJobGroup);
				}
			}
			foreach (string resumedGroup in resumedGroups)
			{
				pausedJobGroups.Remove(resumedGroup);
			}
			foreach (JobKey key in keys)
			{
				IList<IOperableTrigger> triggers = GetTriggersForJob(key);
				foreach (IOperableTrigger trigger in triggers)
				{
					ResumeTrigger(trigger.Key);
				}
			}
			return resumedGroups;
		}
	}

	/// <summary>
	/// Pause all triggers - equivalent of calling <see cref="M:Quartz.Simpl.RAMJobStore.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group.
	/// <para>
	/// When <see cref="M:Quartz.Simpl.RAMJobStore.ResumeAll" /> is called (to un-pause), trigger misfire
	/// instructions WILL be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Simpl.RAMJobStore.ResumeAll" /> 
	public virtual void PauseAll()
	{
		lock (lockObject)
		{
			IList<string> triggerGroupNames = GetTriggerGroupNames();
			foreach (string groupName in triggerGroupNames)
			{
				PauseTriggers(GroupMatcher<TriggerKey>.GroupEquals(groupName));
			}
		}
	}

	/// <summary>
	/// Resume (un-pause) all triggers - equivalent of calling <see cref="M:Quartz.Simpl.RAMJobStore.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every trigger group and setting all job groups unpaused /&gt;.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Simpl.RAMJobStore.PauseAll" />
	public virtual void ResumeAll()
	{
		lock (lockObject)
		{
			pausedJobGroups.Clear();
			IList<string> triggerGroupNames = GetTriggerGroupNames();
			foreach (string groupName in triggerGroupNames)
			{
				ResumeTriggers(GroupMatcher<TriggerKey>.GroupEquals(groupName));
			}
		}
	}

	/// <summary>
	/// Applies the misfire.
	/// </summary>
	/// <param name="tw">The trigger wrapper.</param>
	/// <returns></returns>
	protected virtual bool ApplyMisfire(TriggerWrapper tw)
	{
		DateTimeOffset misfireTime = SystemTime.UtcNow();
		if (MisfireThreshold > TimeSpan.Zero)
		{
			misfireTime = misfireTime.AddMilliseconds(-1.0 * MisfireThreshold.TotalMilliseconds);
		}
		DateTimeOffset? tnft = tw.trigger.GetNextFireTimeUtc();
		if (!tnft.HasValue || tnft.Value > misfireTime || tw.trigger.MisfireInstruction == -1)
		{
			return false;
		}
		ICalendar cal = null;
		if (tw.trigger.CalendarName != null)
		{
			cal = RetrieveCalendar(tw.trigger.CalendarName);
		}
		signaler.NotifyTriggerListenersMisfired((IOperableTrigger)tw.trigger.Clone());
		tw.trigger.UpdateAfterMisfire(cal);
		if (!tw.trigger.GetNextFireTimeUtc().HasValue)
		{
			tw.state = InternalTriggerState.Complete;
			signaler.NotifySchedulerListenersFinalized(tw.trigger);
			lock (lockObject)
			{
				timeTriggers.Remove(tw);
			}
		}
		else if (tnft.Equals(tw.trigger.GetNextFireTimeUtc()))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// Get a handle to the next trigger to be fired, and mark it as 'reserved'
	/// by the calling scheduler.
	/// </summary>
	/// <seealso cref="T:Quartz.ITrigger" />
	public virtual IList<IOperableTrigger> AcquireNextTriggers(DateTimeOffset noLaterThan, int maxCount, TimeSpan timeWindow)
	{
		lock (lockObject)
		{
			List<IOperableTrigger> result = new List<IOperableTrigger>();
			Quartz.Collection.ISet<JobKey> acquiredJobKeysForNoConcurrentExec = new Quartz.Collection.HashSet<JobKey>();
			Quartz.Collection.ISet<TriggerWrapper> excludedTriggers = new Quartz.Collection.HashSet<TriggerWrapper>();
			DateTimeOffset? firstAcquiredTriggerFireTime = null;
			if (timeTriggers.Count == 0)
			{
				return result;
			}
			while (true)
			{
				TriggerWrapper tw = timeTriggers.First();
				if (tw == null || !timeTriggers.Remove(tw))
				{
					break;
				}
				if (!tw.trigger.GetNextFireTimeUtc().HasValue)
				{
					continue;
				}
				if (firstAcquiredTriggerFireTime.HasValue && tw.trigger.GetNextFireTimeUtc() > firstAcquiredTriggerFireTime.Value + timeWindow)
				{
					timeTriggers.Add(tw);
					break;
				}
				if (ApplyMisfire(tw))
				{
					if (tw.trigger.GetNextFireTimeUtc().HasValue)
					{
						timeTriggers.Add(tw);
					}
					continue;
				}
				if (tw.trigger.GetNextFireTimeUtc() > noLaterThan + timeWindow)
				{
					timeTriggers.Add(tw);
					break;
				}
				JobKey jobKey = tw.trigger.JobKey;
				IJobDetail job = jobsByKey[tw.trigger.JobKey].jobDetail;
				if (job.ConcurrentExecutionDisallowed)
				{
					if (acquiredJobKeysForNoConcurrentExec.Contains(jobKey))
					{
						excludedTriggers.Add(tw);
						continue;
					}
					acquiredJobKeysForNoConcurrentExec.Add(jobKey);
				}
				tw.state = InternalTriggerState.Acquired;
				tw.trigger.FireInstanceId = GetFiredTriggerRecordId();
				IOperableTrigger trig = (IOperableTrigger)tw.trigger.Clone();
				result.Add(trig);
				if (!firstAcquiredTriggerFireTime.HasValue)
				{
					firstAcquiredTriggerFireTime = tw.trigger.GetNextFireTimeUtc();
				}
				if (result.Count == maxCount)
				{
					break;
				}
			}
			if (excludedTriggers.Count > 0)
			{
				timeTriggers.AddAll(excludedTriggers);
			}
			return result;
		}
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> that the scheduler no longer plans to
	/// fire the given <see cref="T:Quartz.ITrigger" />, that it had previously acquired
	/// (reserved).
	/// </summary>
	public virtual void ReleaseAcquiredTrigger(IOperableTrigger trigger)
	{
		lock (lockObject)
		{
			if (triggersByKey.TryGetValue(trigger.Key, out var tw) && tw.state == InternalTriggerState.Acquired)
			{
				tw.state = InternalTriggerState.Waiting;
				timeTriggers.Add(tw);
			}
		}
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> that the scheduler is now firing the
	/// given <see cref="T:Quartz.ITrigger" /> (executing its associated <see cref="T:Quartz.IJob" />),
	/// that it had previously acquired (reserved).
	/// </summary>
	public virtual IList<TriggerFiredResult> TriggersFired(IList<IOperableTrigger> triggers)
	{
		lock (lockObject)
		{
			List<TriggerFiredResult> results = new List<TriggerFiredResult>();
			foreach (IOperableTrigger trigger in triggers)
			{
				if (!triggersByKey.TryGetValue(trigger.Key, out var tw) || tw.trigger == null || tw.state != InternalTriggerState.Acquired)
				{
					continue;
				}
				ICalendar cal = null;
				if (tw.trigger.CalendarName != null)
				{
					cal = RetrieveCalendar(tw.trigger.CalendarName);
					if (cal == null)
					{
						continue;
					}
				}
				DateTimeOffset? prevFireTime = trigger.GetPreviousFireTimeUtc();
				timeTriggers.Remove(tw);
				tw.trigger.Triggered(cal);
				trigger.Triggered(cal);
				tw.state = InternalTriggerState.Waiting;
				TriggerFiredBundle bndle = new TriggerFiredBundle(RetrieveJob(trigger.JobKey), trigger, cal, jobIsRecovering: false, SystemTime.UtcNow(), trigger.GetPreviousFireTimeUtc(), prevFireTime, trigger.GetNextFireTimeUtc());
				IJobDetail job = bndle.JobDetail;
				if (job.ConcurrentExecutionDisallowed)
				{
					List<TriggerWrapper> trigs = GetTriggerWrappersForJob(job.Key);
					foreach (TriggerWrapper ttw in trigs)
					{
						if (ttw.state == InternalTriggerState.Waiting)
						{
							ttw.state = InternalTriggerState.Blocked;
						}
						if (ttw.state == InternalTriggerState.Paused)
						{
							ttw.state = InternalTriggerState.PausedAndBlocked;
						}
						timeTriggers.Remove(ttw);
					}
					blockedJobs.Add(job.Key);
				}
				else if (tw.trigger.GetNextFireTimeUtc().HasValue)
				{
					lock (lockObject)
					{
						timeTriggers.Add(tw);
					}
				}
				results.Add(new TriggerFiredResult(bndle));
			}
			return results;
		}
	}

	/// <summary> 
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> that the scheduler has completed the
	/// firing of the given <see cref="T:Quartz.ITrigger" /> (and the execution its
	/// associated <see cref="T:Quartz.IJob" />), and that the <see cref="T:Quartz.JobDataMap" />
	/// in the given <see cref="T:Quartz.IJobDetail" /> should be updated if the <see cref="T:Quartz.IJob" />
	/// is stateful.
	/// </summary>
	public virtual void TriggeredJobComplete(IOperableTrigger trigger, IJobDetail jobDetail, SchedulerInstruction triggerInstCode)
	{
		lock (lockObject)
		{
			triggersByKey.TryGetValue(trigger.Key, out var tw);
			if (jobsByKey.TryGetValue(jobDetail.Key, out var jw))
			{
				IJobDetail jd = jw.jobDetail;
				if (jobDetail.PersistJobDataAfterExecution)
				{
					JobDataMap newData = jobDetail.JobDataMap;
					if (newData != null)
					{
						newData = (JobDataMap)newData.Clone();
						newData.ClearDirtyFlag();
					}
					((JobDetailImpl)jd).JobDataMap = newData;
				}
				if (jd.ConcurrentExecutionDisallowed)
				{
					blockedJobs.Remove(jd.Key);
					List<TriggerWrapper> trigs = GetTriggerWrappersForJob(jd.Key);
					foreach (TriggerWrapper ttw in trigs)
					{
						if (ttw.state == InternalTriggerState.Blocked)
						{
							ttw.state = InternalTriggerState.Waiting;
							timeTriggers.Add(ttw);
						}
						if (ttw.state == InternalTriggerState.PausedAndBlocked)
						{
							ttw.state = InternalTriggerState.Paused;
						}
					}
					signaler.SignalSchedulingChange(null);
				}
			}
			else
			{
				blockedJobs.Remove(jobDetail.Key);
			}
			if (tw == null)
			{
				return;
			}
			switch (triggerInstCode)
			{
			case SchedulerInstruction.DeleteTrigger:
				log.Debug("Deleting trigger");
				if (!trigger.GetNextFireTimeUtc().HasValue)
				{
					if (!tw.trigger.GetNextFireTimeUtc().HasValue)
					{
						RemoveTrigger(trigger.Key);
					}
					else
					{
						log.Debug("Deleting cancelled - trigger still active");
					}
				}
				else
				{
					RemoveTrigger(trigger.Key);
					signaler.SignalSchedulingChange(null);
				}
				break;
			case SchedulerInstruction.SetTriggerComplete:
				tw.state = InternalTriggerState.Complete;
				timeTriggers.Remove(tw);
				signaler.SignalSchedulingChange(null);
				break;
			case SchedulerInstruction.SetTriggerError:
				Log.Info(string.Format(CultureInfo.InvariantCulture, "Trigger {0} set to ERROR state.", new object[1] { trigger.Key }));
				tw.state = InternalTriggerState.Error;
				signaler.SignalSchedulingChange(null);
				break;
			case SchedulerInstruction.SetAllJobTriggersError:
				Log.Info(string.Format(CultureInfo.InvariantCulture, "All triggers of Job {0} set to ERROR state.", new object[1] { trigger.JobKey }));
				SetAllTriggersOfJobToState(trigger.JobKey, InternalTriggerState.Error);
				signaler.SignalSchedulingChange(null);
				break;
			case SchedulerInstruction.SetAllJobTriggersComplete:
				SetAllTriggersOfJobToState(trigger.JobKey, InternalTriggerState.Complete);
				signaler.SignalSchedulingChange(null);
				break;
			}
		}
	}

	/// <summary>
	/// Sets the state of all triggers of job to specified state.
	/// </summary>
	protected virtual void SetAllTriggersOfJobToState(JobKey jobKey, InternalTriggerState state)
	{
		List<TriggerWrapper> tws = GetTriggerWrappersForJob(jobKey);
		foreach (TriggerWrapper tw in tws)
		{
			tw.state = state;
			if (state != 0)
			{
				timeTriggers.Remove(tw);
			}
		}
	}

	/// <summary>
	/// Peeks the triggers.
	/// </summary>
	/// <returns></returns>
	protected internal virtual string PeekTriggers()
	{
		StringBuilder str = new StringBuilder();
		lock (lockObject)
		{
			foreach (TriggerWrapper tw2 in triggersByKey.Values)
			{
				str.Append(tw2.trigger.Key.Name);
				str.Append("/");
			}
		}
		str.Append(" | ");
		lock (lockObject)
		{
			foreach (TriggerWrapper tw in timeTriggers)
			{
				str.Append(tw.trigger.Key.Name);
				str.Append("->");
			}
		}
		return str.ToString();
	}

	/// <seealso cref="M:Quartz.Spi.IJobStore.GetPausedTriggerGroups" />
	public virtual Quartz.Collection.ISet<string> GetPausedTriggerGroups()
	{
		return new Quartz.Collection.HashSet<string>(pausedTriggerGroups);
	}
}
