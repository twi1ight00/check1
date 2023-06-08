using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Text;
using System.Threading;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using Quartz.Simpl;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Core;

/// <summary>
/// This is the heart of Quartz, an indirect implementation of the <see cref="T:Quartz.IScheduler" />
/// interface, containing methods to schedule <see cref="T:Quartz.IJob" />s,
/// register <see cref="T:Quartz.IJobListener" /> instances, etc.
/// </summary>
/// <seealso cref="T:Quartz.IScheduler" />
/// <seealso cref="T:Quartz.Core.QuartzSchedulerThread" />
/// <seealso cref="T:Quartz.Spi.IJobStore" />
/// <seealso cref="T:Quartz.Spi.IThreadPool" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class QuartzScheduler : MarshalByRefObject, IRemotableQuartzScheduler
{
	/// <summary>
	/// Helper class to start scheduler in a delayed fashion.
	/// </summary>
	private class DelayedSchedulerStarter
	{
		private readonly QuartzScheduler scheduler;

		private readonly TimeSpan delay;

		private readonly ILog logger;

		public DelayedSchedulerStarter(QuartzScheduler scheduler, TimeSpan delay, ILog logger)
		{
			this.scheduler = scheduler;
			this.delay = delay;
			this.logger = logger;
		}

		public void Run()
		{
			try
			{
				Thread.Sleep(delay);
			}
			catch (ThreadInterruptedException)
			{
			}
			try
			{
				scheduler.Start();
			}
			catch (SchedulerException se)
			{
				logger.Error("Unable to start secheduler after startup delay.", se);
			}
		}
	}

	private readonly ILog log;

	private static readonly Version version;

	private readonly QuartzSchedulerResources resources;

	private readonly QuartzSchedulerThread schedThread;

	private readonly SchedulerContext context = new SchedulerContext();

	private readonly IListenerManager listenerManager = new ListenerManagerImpl();

	private readonly IDictionary<string, IJobListener> internalJobListeners = new Dictionary<string, IJobListener>(10);

	private readonly IDictionary<string, ITriggerListener> internalTriggerListeners = new Dictionary<string, ITriggerListener>(10);

	private readonly IList<ISchedulerListener> internalSchedulerListeners = new List<ISchedulerListener>(10);

	private IJobFactory jobFactory = new PropertySettingJobFactory();

	private readonly ExecutingJobsManager jobMgr;

	private readonly ErrorLogger errLogger;

	private readonly ISchedulerSignaler signaler;

	private readonly Random random = new Random();

	private readonly List<object> holdToPreventGc = new List<object>(5);

	private bool signalOnSchedulingChange = true;

	private volatile bool closed;

	private volatile bool shuttingDown;

	private DateTimeOffset? initialStart;

	private bool boundRemotely;

	private readonly TimeSpan dbRetryInterval;

	/// <summary>
	/// Gets the version of the Quartz Scheduler.
	/// </summary>
	/// <value>The version.</value>
	public string Version => version.ToString();

	/// <summary>
	/// Gets the version major.
	/// </summary>
	/// <value>The version major.</value>
	public static string VersionMajor => version.Major.ToString(CultureInfo.InvariantCulture);

	/// <summary>
	/// Gets the version minor.
	/// </summary>
	/// <value>The version minor.</value>
	public static string VersionMinor => version.Minor.ToString(CultureInfo.InvariantCulture);

	/// <summary>
	/// Gets the version iteration.
	/// </summary>
	/// <value>The version iteration.</value>
	public static string VersionIteration => version.Build.ToString(CultureInfo.InvariantCulture);

	/// <summary>
	/// Gets the scheduler signaler.
	/// </summary>
	/// <value>The scheduler signaler.</value>
	public virtual ISchedulerSignaler SchedulerSignaler => signaler;

	/// <summary>
	/// Returns the name of the <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual string SchedulerName => resources.Name;

	/// <summary> 
	/// Returns the instance Id of the <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual string SchedulerInstanceId => resources.InstanceId;

	/// <summary>
	/// Returns the <see cref="P:Quartz.Core.QuartzScheduler.SchedulerContext" /> of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual SchedulerContext SchedulerContext => context;

	/// <summary>
	/// Gets or sets a value indicating whether to signal on scheduling change.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if schduler should signal on scheduling change; otherwise, <c>false</c>.
	/// </value>
	public virtual bool SignalOnSchedulingChange
	{
		get
		{
			return signalOnSchedulingChange;
		}
		set
		{
			signalOnSchedulingChange = value;
		}
	}

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> is paused.
	/// </summary>
	public virtual bool InStandbyMode => schedThread.Paused;

	/// <summary>
	/// Gets the job store class.
	/// </summary>
	/// <value>The job store class.</value>
	public virtual Type JobStoreClass => resources.JobStore.GetType();

	/// <summary>
	/// Gets the thread pool class.
	/// </summary>
	/// <value>The thread pool class.</value>
	public virtual Type ThreadPoolClass => resources.ThreadPool.GetType();

	/// <summary>
	/// Gets the size of the thread pool.
	/// </summary>
	/// <value>The size of the thread pool.</value>
	public virtual int ThreadPoolSize => resources.ThreadPool.PoolSize;

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> has been Shutdown.
	/// </summary>
	public virtual bool IsShutdown => closed;

	public virtual bool IsShuttingDown => shuttingDown;

	public virtual bool IsStarted
	{
		get
		{
			if (!shuttingDown && !closed && !InStandbyMode)
			{
				return initialStart.HasValue;
			}
			return false;
		}
	}

	/// <summary>
	/// Return a list of <see cref="T:Quartz.IJobExecutionContext" /> objects that
	/// represent all currently executing Jobs in this Scheduler instance.
	/// <para>
	/// This method is not cluster aware.  That is, it will only return Jobs
	/// currently executing in this Scheduler instance, not across the entire
	/// cluster.
	/// </para>
	/// <para>
	/// Note that the list returned is an 'instantaneous' snap-shot, and that as
	/// soon as it's returned, the true list of executing jobs may be different.
	/// </para>
	/// </summary>
	public virtual IList<IJobExecutionContext> CurrentlyExecutingJobs => jobMgr.ExecutingJobs;

	/// <summary>
	/// Get a List containing all of the <i>internal</i> <see cref="T:Quartz.ISchedulerListener" />s
	/// registered with the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public IList<ISchedulerListener> InternalSchedulerListeners
	{
		get
		{
			lock (internalSchedulerListeners)
			{
				return new List<ISchedulerListener>(internalSchedulerListeners).AsReadOnly();
			}
		}
	}

	/// <summary>
	/// Gets or sets the job factory.
	/// </summary>
	/// <value>The job factory.</value>
	public virtual IJobFactory JobFactory
	{
		get
		{
			return jobFactory;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("JobFactory cannot be set to null!");
			}
			log.Info("JobFactory set to: " + value);
			jobFactory = value;
		}
	}

	public TimeSpan DbRetryInterval => dbRetryInterval;

	/// <summary>
	/// Gets the running since.
	/// </summary>
	/// <value>The running since.</value>
	public virtual DateTimeOffset? RunningSince => initialStart;

	/// <summary>
	/// Gets the number of jobs executed.
	/// </summary>
	/// <value>The number of jobs executed.</value>
	public virtual int NumJobsExecuted => jobMgr.NumJobsFired;

	/// <summary>
	/// Gets a value indicating whether this scheduler supports persistence.
	/// </summary>
	/// <value><c>true</c> if supports persistence; otherwise, <c>false</c>.</value>
	public virtual bool SupportsPersistence => resources.JobStore.SupportsPersistence;

	public bool Clustered => resources.JobStore.Clustered;

	public IListenerManager ListenerManager => listenerManager;

	/// <summary>
	/// Get a List containing all of the <see cref="T:Quartz.IJobListener" />s
	/// in the <see cref="T:Quartz.IScheduler" />'s <i>internal</i> list.
	/// </summary>
	/// <returns></returns>
	public IList<IJobListener> InternalJobListeners
	{
		get
		{
			lock (internalJobListeners)
			{
				return new List<IJobListener>(internalJobListeners.Values).AsReadOnly();
			}
		}
	}

	/// <summary>
	/// Get a list containing all of the <see cref="T:Quartz.ITriggerListener" />s
	/// in the <see cref="T:Quartz.IScheduler" />'s <i>internal</i> list.
	/// </summary>
	public IList<ITriggerListener> InternalTriggerListeners
	{
		get
		{
			lock (internalTriggerListeners)
			{
				return new List<ITriggerListener>(internalTriggerListeners.Values).AsReadOnly();
			}
		}
	}

	/// <summary>
	/// Initializes the <see cref="T:Quartz.Core.QuartzScheduler" /> class.
	/// </summary>
	static QuartzScheduler()
	{
		Assembly asm = Assembly.GetAssembly(typeof(QuartzScheduler));
		if (asm != null)
		{
			version = asm.GetName().Version;
		}
	}

	/// <summary>
	/// Register the given <see cref="T:Quartz.ISchedulerListener" /> with the
	/// <see cref="T:Quartz.IScheduler" />'s list of internal listeners.
	/// </summary>
	/// <param name="schedulerListener"></param>
	public void AddInternalSchedulerListener(ISchedulerListener schedulerListener)
	{
		lock (internalSchedulerListeners)
		{
			internalSchedulerListeners.Add(schedulerListener);
		}
	}

	/// <summary>
	/// Remove the given <see cref="T:Quartz.ISchedulerListener" /> from the
	/// <see cref="T:Quartz.IScheduler" />'s list of internal listeners.
	/// </summary>
	/// <param name="schedulerListener"></param>
	/// <returns>true if the identified listener was found in the list, andremoved.</returns>
	public bool RemoveInternalSchedulerListener(ISchedulerListener schedulerListener)
	{
		lock (internalSchedulerListeners)
		{
			return internalSchedulerListeners.Remove(schedulerListener);
		}
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Core.QuartzScheduler" /> with the given configuration
	/// properties.
	/// </summary>
	/// <seealso cref="T:Quartz.Core.QuartzSchedulerResources" />
	public QuartzScheduler(QuartzSchedulerResources resources, TimeSpan idleWaitTime, TimeSpan dbRetryInterval)
	{
		log = LogManager.GetLogger(GetType());
		this.resources = resources;
		if (resources.JobStore is IJobListener)
		{
			AddInternalJobListener((IJobListener)resources.JobStore);
		}
		schedThread = new QuartzSchedulerThread(this, resources);
		IThreadExecutor schedThreadExecutor = resources.ThreadExecutor;
		schedThreadExecutor.Execute(schedThread);
		if (idleWaitTime > TimeSpan.Zero)
		{
			schedThread.IdleWaitTime = idleWaitTime;
		}
		if (dbRetryInterval > TimeSpan.Zero)
		{
			schedThread.DbFailureRetryInterval = dbRetryInterval;
		}
		jobMgr = new ExecutingJobsManager();
		AddInternalJobListener(jobMgr);
		errLogger = new ErrorLogger();
		AddInternalSchedulerListener(errLogger);
		signaler = new SchedulerSignalerImpl(this, schedThread);
		this.dbRetryInterval = dbRetryInterval;
		log.InfoFormat(CultureInfo.InvariantCulture, "Quartz Scheduler v.{0} created.", Version);
	}

	public void Initialize()
	{
		try
		{
			Bind();
		}
		catch (Exception re)
		{
			throw new SchedulerException("Unable to bind scheduler to remoting.", re);
		}
		log.Info("Scheduler meta-data: " + new SchedulerMetaData(SchedulerName, SchedulerInstanceId, GetType(), boundRemotely, RunningSince.HasValue, InStandbyMode, IsShutdown, RunningSince, NumJobsExecuted, JobStoreClass, SupportsPersistence, Clustered, ThreadPoolClass, ThreadPoolSize, Version));
	}

	/// <summary>
	/// Bind the scheduler to remoting infrastructure.
	/// </summary>
	private void Bind()
	{
		if (resources.SchedulerExporter != null)
		{
			resources.SchedulerExporter.Bind(this);
			boundRemotely = true;
		}
	}

	/// <summary>
	/// Un-bind the scheduler from remoting infrastructure.
	/// </summary>
	private void UnBind()
	{
		if (resources.SchedulerExporter != null)
		{
			resources.SchedulerExporter.UnBind(this);
		}
	}

	/// <summary>
	/// Adds an object that should be kept as reference to prevent
	/// it from being garbage collected.
	/// </summary>
	/// <param name="obj">The obj.</param>
	public virtual void AddNoGCObject(object obj)
	{
		holdToPreventGc.Add(obj);
	}

	/// <summary>
	/// Removes the object from garbae collection protected list.
	/// </summary>
	/// <param name="obj">The obj.</param>
	/// <returns></returns>
	public virtual bool RemoveNoGCObject(object obj)
	{
		return holdToPreventGc.Remove(obj);
	}

	/// <summary>
	/// Starts the <see cref="T:Quartz.Core.QuartzScheduler" />'s threads that fire <see cref="T:Quartz.ITrigger" />s.
	/// <para>
	/// All <see cref="T:Quartz.ITrigger" />s that have misfired will
	/// be passed to the appropriate TriggerListener(s).
	/// </para>
	/// </summary>
	public virtual void Start()
	{
		if (shuttingDown || closed)
		{
			throw new SchedulerException("The Scheduler cannot be restarted after Shutdown() has been called.");
		}
		NotifySchedulerListenersStarting();
		if (!initialStart.HasValue)
		{
			initialStart = SystemTime.UtcNow();
			resources.JobStore.SchedulerStarted();
			StartPlugins();
		}
		else
		{
			resources.JobStore.SchedulerResumed();
		}
		schedThread.TogglePause(pause: false);
		log.Info(string.Format(CultureInfo.InvariantCulture, "Scheduler {0} started.", new object[1] { resources.GetUniqueIdentifier() }));
		NotifySchedulerListenersStarted();
	}

	public void StartDelayed(TimeSpan delay)
	{
		if (shuttingDown || closed)
		{
			throw new SchedulerException("The Scheduler cannot be restarted after Shutdown() has been called.");
		}
		DelayedSchedulerStarter starter = new DelayedSchedulerStarter(this, delay, log);
		Thread t = new Thread(starter.Run);
		t.Start();
	}

	/// <summary>
	/// Temporarily halts the <see cref="T:Quartz.Core.QuartzScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s.
	/// <para>
	/// The scheduler is not destroyed, and can be re-started at any time.
	/// </para>
	/// </summary>
	public virtual void Standby()
	{
		resources.JobStore.SchedulerPaused();
		schedThread.TogglePause(pause: true);
		log.Info(string.Format(CultureInfo.InvariantCulture, "Scheduler {0} paused.", new object[1] { resources.GetUniqueIdentifier() }));
		NotifySchedulerListenersInStandbyMode();
	}

	/// <summary>
	/// Halts the <see cref="T:Quartz.Core.QuartzScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s,
	/// and cleans up all resources associated with the QuartzScheduler.
	/// Equivalent to <see cref="M:Quartz.Core.QuartzScheduler.Shutdown(System.Boolean)" />.
	/// <para>
	/// The scheduler cannot be re-started.
	/// </para>
	/// </summary>
	public virtual void Shutdown()
	{
		Shutdown(waitForJobsToComplete: false);
	}

	/// <summary>
	/// Halts the <see cref="T:Quartz.Core.QuartzScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s,
	/// and cleans up all resources associated with the QuartzScheduler.
	/// <para>
	/// The scheduler cannot be re-started.
	/// </para>
	/// </summary>
	/// <param name="waitForJobsToComplete">
	/// if <see langword="true" /> the scheduler will not allow this method
	/// to return until all currently executing jobs have completed.
	/// </param>
	public virtual void Shutdown(bool waitForJobsToComplete)
	{
		if (shuttingDown || closed)
		{
			return;
		}
		shuttingDown = true;
		log.Info(string.Format(CultureInfo.InvariantCulture, "Scheduler {0} shutting down.", new object[1] { resources.GetUniqueIdentifier() }));
		Standby();
		schedThread.Halt();
		NotifySchedulerListenersShuttingdown();
		if ((resources.InterruptJobsOnShutdown && !waitForJobsToComplete) || (resources.InterruptJobsOnShutdownWithWait && waitForJobsToComplete))
		{
			IList<IJobExecutionContext> jobs = CurrentlyExecutingJobs;
			foreach (IJobExecutionContext job in jobs)
			{
				if (job.JobInstance is IInterruptableJob)
				{
					try
					{
						((IInterruptableJob)job.JobInstance).Interrupt();
					}
					catch (Exception ex)
					{
						log.WarnFormat("Encountered error when interrupting job {0} during shutdown: {1}", job.JobDetail.Key, ex);
					}
				}
			}
		}
		resources.ThreadPool.Shutdown(waitForJobsToComplete);
		if (waitForJobsToComplete)
		{
			while (jobMgr.NumJobsCurrentlyExecuting > 0)
			{
				try
				{
					Thread.Sleep(100);
				}
				catch (ThreadInterruptedException)
				{
				}
			}
		}
		try
		{
			schedThread.Join();
		}
		catch (ThreadInterruptedException)
		{
		}
		closed = true;
		if (boundRemotely)
		{
			try
			{
				UnBind();
			}
			catch (RemotingException)
			{
			}
		}
		ShutdownPlugins();
		resources.JobStore.Shutdown();
		NotifySchedulerListenersShutdown();
		SchedulerRepository.Instance.Remove(resources.Name);
		holdToPreventGc.Clear();
		log.Info(string.Format(CultureInfo.InvariantCulture, "Scheduler {0} Shutdown complete.", new object[1] { resources.GetUniqueIdentifier() }));
	}

	/// <summary>
	/// Validates the state.
	/// </summary>
	public virtual void ValidateState()
	{
		if (IsShutdown)
		{
			throw new SchedulerException("The Scheduler has been Shutdown.");
		}
	}

	/// <summary> 
	/// Add the <see cref="T:Quartz.IJob" /> identified by the given
	/// <see cref="T:Quartz.IJobDetail" /> to the Scheduler, and
	/// associate the given <see cref="T:Quartz.ITrigger" /> with it.
	/// <para>
	/// If the given Trigger does not reference any <see cref="T:Quartz.IJob" />, then it
	/// will be set to reference the Job passed with it into this method.
	/// </para>
	/// </summary>
	public virtual DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
	{
		ValidateState();
		if (jobDetail == null)
		{
			throw new SchedulerException("JobDetail cannot be null");
		}
		if (trigger == null)
		{
			throw new SchedulerException("Trigger cannot be null");
		}
		if (jobDetail.Key == null)
		{
			throw new SchedulerException("Job's key cannot be null");
		}
		if (jobDetail.JobType == null)
		{
			throw new SchedulerException("Job's class cannot be null");
		}
		IOperableTrigger trig = (IOperableTrigger)trigger;
		if (trigger.JobKey == null)
		{
			trig.JobKey = jobDetail.Key;
		}
		else if (!trigger.JobKey.Equals(jobDetail.Key))
		{
			throw new SchedulerException("Trigger does not reference given job!");
		}
		trig.Validate();
		ICalendar cal = null;
		if (trigger.CalendarName != null)
		{
			cal = resources.JobStore.RetrieveCalendar(trigger.CalendarName);
			if (cal == null)
			{
				throw new SchedulerException(string.Format(CultureInfo.InvariantCulture, "Calendar not found: {0}", new object[1] { trigger.CalendarName }));
			}
		}
		DateTimeOffset? ft = trig.ComputeFirstFireTimeUtc(cal);
		if (!ft.HasValue)
		{
			string message = $"Based on configured schedule, the given trigger '{trigger.Key}' will never fire.";
			throw new SchedulerException(message);
		}
		resources.JobStore.StoreJobAndTrigger(jobDetail, trig);
		NotifySchedulerListenersJobAdded(jobDetail);
		NotifySchedulerThread(trigger.GetNextFireTimeUtc());
		NotifySchedulerListenersScheduled(trigger);
		return ft.Value;
	}

	/// <summary>
	/// Schedule the given <see cref="T:Quartz.ITrigger" /> with the
	/// <see cref="T:Quartz.IJob" /> identified by the <see cref="T:Quartz.ITrigger" />'s settings.
	/// </summary>
	public virtual DateTimeOffset ScheduleJob(ITrigger trigger)
	{
		ValidateState();
		if (trigger == null)
		{
			throw new SchedulerException("Trigger cannot be null");
		}
		IOperableTrigger trig = (IOperableTrigger)trigger;
		trig.Validate();
		ICalendar cal = null;
		if (trigger.CalendarName != null)
		{
			cal = resources.JobStore.RetrieveCalendar(trigger.CalendarName);
			if (cal == null)
			{
				throw new SchedulerException(string.Format(CultureInfo.InvariantCulture, "Calendar not found: {0}", new object[1] { trigger.CalendarName }));
			}
		}
		DateTimeOffset? ft = trig.ComputeFirstFireTimeUtc(cal);
		if (!ft.HasValue)
		{
			string message = $"Based on configured schedule, the given trigger '{trigger.Key}' will never fire.";
			throw new SchedulerException(message);
		}
		resources.JobStore.StoreTrigger(trig, replaceExisting: false);
		NotifySchedulerThread(trigger.GetNextFireTimeUtc());
		NotifySchedulerListenersScheduled(trigger);
		return ft.Value;
	}

	/// <summary>
	/// Add the given <see cref="T:Quartz.IJob" /> to the Scheduler - with no associated
	/// <see cref="T:Quartz.ITrigger" />. The <see cref="T:Quartz.IJob" /> will be 'dormant' until
	/// it is scheduled with a <see cref="T:Quartz.ITrigger" />, or <see cref="M:Quartz.IScheduler.TriggerJob(Quartz.JobKey)" />
	/// is called for it.
	/// <para>
	/// The <see cref="T:Quartz.IJob" /> must by definition be 'durable', if it is not,
	/// SchedulerException will be thrown.
	/// </para>
	/// </summary>
	public virtual void AddJob(IJobDetail jobDetail, bool replace)
	{
		ValidateState();
		if (!jobDetail.Durable && !replace)
		{
			throw new SchedulerException("Jobs added with no trigger must be durable.");
		}
		resources.JobStore.StoreJob(jobDetail, replace);
		NotifySchedulerThread(null);
		NotifySchedulerListenersJobAdded(jobDetail);
	}

	/// <summary>
	/// Delete the identified <see cref="T:Quartz.IJob" /> from the Scheduler - and any
	/// associated <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <returns> true if the Job was found and deleted.</returns>
	public virtual bool DeleteJob(JobKey jobKey)
	{
		ValidateState();
		bool result = false;
		IList<ITrigger> triggers = GetTriggersOfJob(jobKey);
		foreach (ITrigger trigger in triggers)
		{
			if (!UnscheduleJob(trigger.Key))
			{
				StringBuilder sb = new StringBuilder().Append("Unable to unschedule trigger [").Append(trigger.Key).Append("] while deleting job [")
					.Append(jobKey)
					.Append("]");
				throw new SchedulerException(sb.ToString());
			}
			result = true;
		}
		result = resources.JobStore.RemoveJob(jobKey) || result;
		if (result)
		{
			NotifySchedulerThread(null);
			NotifySchedulerListenersJobDeleted(jobKey);
		}
		return result;
	}

	public bool DeleteJobs(IList<JobKey> jobKeys)
	{
		ValidateState();
		bool result = resources.JobStore.RemoveJobs(jobKeys);
		NotifySchedulerThread(null);
		foreach (JobKey key in jobKeys)
		{
			NotifySchedulerListenersJobDeleted(key);
		}
		return result;
	}

	public void ScheduleJobs(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace)
	{
		ValidateState();
		foreach (IJobDetail job2 in triggersAndJobs.Keys)
		{
			if (job2 == null)
			{
				continue;
			}
			Quartz.Collection.ISet<ITrigger> triggers = triggersAndJobs[job2];
			if (triggers == null)
			{
				continue;
			}
			foreach (IOperableTrigger trigger in triggers)
			{
				trigger.JobKey = job2.Key;
				trigger.Validate();
				ICalendar cal = null;
				if (trigger.CalendarName != null)
				{
					cal = resources.JobStore.RetrieveCalendar(trigger.CalendarName);
					if (cal == null)
					{
						throw new SchedulerException("Calendar '" + trigger.CalendarName + "' not found for trigger: " + trigger.Key);
					}
				}
				if (!trigger.ComputeFirstFireTimeUtc(cal).HasValue)
				{
					string message = $"Based on configured schedule, the given trigger '{trigger.Key}' will never fire.";
					throw new SchedulerException(message);
				}
			}
		}
		resources.JobStore.StoreJobsAndTriggers(triggersAndJobs, replace);
		NotifySchedulerThread(null);
		foreach (IJobDetail job in triggersAndJobs.Keys)
		{
			NotifySchedulerListenersJobAdded(job);
		}
	}

	public void ScheduleJob(IJobDetail jobDetail, Quartz.Collection.ISet<ITrigger> triggersForJob, bool replace)
	{
		Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();
		triggersAndJobs.Add(jobDetail, triggersForJob);
		ScheduleJobs(triggersAndJobs, replace);
	}

	public bool UnscheduleJobs(IList<TriggerKey> triggerKeys)
	{
		ValidateState();
		bool result = resources.JobStore.RemoveTriggers(triggerKeys);
		NotifySchedulerThread(null);
		foreach (TriggerKey key in triggerKeys)
		{
			NotifySchedulerListenersUnscheduled(key);
		}
		return result;
	}

	/// <summary>
	/// Remove the indicated <see cref="T:Quartz.ITrigger" /> from the
	/// scheduler.
	/// </summary>
	public virtual bool UnscheduleJob(TriggerKey triggerKey)
	{
		ValidateState();
		if (resources.JobStore.RemoveTrigger(triggerKey))
		{
			NotifySchedulerThread(null);
			NotifySchedulerListenersUnscheduled(triggerKey);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ITrigger" /> with the
	/// given name, and store the new given one - which must be associated
	/// with the same job.
	/// </summary>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <param name="newTrigger">The new <see cref="T:Quartz.ITrigger" /> to be stored.</param>
	/// <returns>
	/// 	<see langword="null" /> if a <see cref="T:Quartz.ITrigger" /> with the given
	/// name and group was not found and removed from the store, otherwise
	/// the first fire time of the newly scheduled trigger.
	/// </returns>
	public virtual DateTimeOffset? RescheduleJob(TriggerKey triggerKey, ITrigger newTrigger)
	{
		ValidateState();
		if (triggerKey == null)
		{
			throw new ArgumentException("triggerKey cannot be null");
		}
		if (newTrigger == null)
		{
			throw new ArgumentException("newTrigger cannot be null");
		}
		IOperableTrigger trigger = (IOperableTrigger)newTrigger;
		ITrigger oldTrigger = GetTrigger(triggerKey);
		if (oldTrigger == null)
		{
			return null;
		}
		trigger.JobKey = oldTrigger.JobKey;
		trigger.Validate();
		ICalendar cal = null;
		if (newTrigger.CalendarName != null)
		{
			cal = resources.JobStore.RetrieveCalendar(newTrigger.CalendarName);
		}
		DateTimeOffset? ft = trigger.ComputeFirstFireTimeUtc(cal);
		if (!ft.HasValue)
		{
			string message = $"Based on configured schedule, the given trigger '{trigger.Key}' will never fire.";
			throw new SchedulerException(message);
		}
		if (resources.JobStore.ReplaceTrigger(triggerKey, trigger))
		{
			NotifySchedulerThread(newTrigger.GetNextFireTimeUtc());
			NotifySchedulerListenersUnscheduled(triggerKey);
			NotifySchedulerListenersScheduled(newTrigger);
			return ft;
		}
		return null;
	}

	private string NewTriggerId()
	{
		long r = NextLong(random);
		if (r < 0)
		{
			r = -r;
		}
		return "MT_" + Convert.ToString(r, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Creates a new positive random number 
	/// </summary>
	/// <param name="random">The last random obtained</param>
	/// <returns>Returns a new positive random number</returns>
	public static long NextLong(Random random)
	{
		long temporaryLong = random.Next();
		temporaryLong = (temporaryLong << 32) + random.Next();
		if (random.Next(-1, 1) < 0)
		{
			return -temporaryLong;
		}
		return temporaryLong;
	}

	/// <summary>
	/// Trigger the identified <see cref="T:Quartz.IJob" /> (Execute it now) - with a non-volatile trigger.
	/// </summary>
	public virtual void TriggerJob(JobKey jobKey, JobDataMap data)
	{
		ValidateState();
		IOperableTrigger trig = new SimpleTriggerImpl(NewTriggerId(), "DEFAULT", jobKey.Name, jobKey.Group, SystemTime.UtcNow(), null, 0, TimeSpan.Zero);
		trig.ComputeFirstFireTimeUtc(null);
		if (data != null)
		{
			trig.JobDataMap = data;
		}
		bool collision = true;
		while (collision)
		{
			try
			{
				resources.JobStore.StoreTrigger(trig, replaceExisting: false);
				collision = false;
			}
			catch (ObjectAlreadyExistsException)
			{
				trig.Key = new TriggerKey(NewTriggerId(), "DEFAULT");
			}
		}
		NotifySchedulerThread(trig.GetNextFireTimeUtc());
		NotifySchedulerListenersScheduled(trig);
	}

	/// <summary>
	/// Store and schedule the identified <see cref="T:Quartz.Spi.IOperableTrigger" />
	/// </summary>
	/// <param name="trig"></param>
	public void TriggerJob(IOperableTrigger trig)
	{
		ValidateState();
		trig.ComputeFirstFireTimeUtc(null);
		bool collision = true;
		while (collision)
		{
			try
			{
				resources.JobStore.StoreTrigger(trig, replaceExisting: false);
				collision = false;
			}
			catch (ObjectAlreadyExistsException)
			{
				trig.Key = new TriggerKey(NewTriggerId(), "DEFAULT");
			}
		}
		NotifySchedulerThread(trig.GetNextFireTimeUtc());
		NotifySchedulerListenersScheduled(trig);
	}

	/// <summary>
	/// Pause the <see cref="T:Quartz.ITrigger" /> with the given name.
	/// </summary>
	public virtual void PauseTrigger(TriggerKey triggerKey)
	{
		ValidateState();
		resources.JobStore.PauseTrigger(triggerKey);
		NotifySchedulerThread(null);
		NotifySchedulerListenersPausedTrigger(triggerKey);
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the given group.
	/// </summary>
	public virtual void PauseTriggers(GroupMatcher<TriggerKey> matcher)
	{
		ValidateState();
		if (matcher == null)
		{
			matcher = GroupMatcher<TriggerKey>.GroupEquals("DEFAULT");
		}
		ICollection<string> pausedGroups = resources.JobStore.PauseTriggers(matcher);
		NotifySchedulerThread(null);
		foreach (string pausedGroup in pausedGroups)
		{
			NotifySchedulerListenersPausedTriggers(pausedGroup);
		}
	}

	/// <summary> 
	/// Pause the <see cref="T:Quartz.IJobDetail" /> with the given
	/// name - by pausing all of its current <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	public virtual void PauseJob(JobKey jobKey)
	{
		ValidateState();
		resources.JobStore.PauseJob(jobKey);
		NotifySchedulerThread(null);
		NotifySchedulerListenersPausedJob(jobKey);
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.IJobDetail" />s in the
	/// given group - by pausing all of their <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	public virtual void PauseJobs(GroupMatcher<JobKey> groupMatcher)
	{
		ValidateState();
		if (groupMatcher == null)
		{
			groupMatcher = GroupMatcher<JobKey>.GroupEquals("DEFAULT");
		}
		ICollection<string> pausedGroups = resources.JobStore.PauseJobs(groupMatcher);
		NotifySchedulerThread(null);
		foreach (string pausedGroup in pausedGroups)
		{
			NotifySchedulerListenersPausedJobs(pausedGroup);
		}
	}

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.ITrigger" /> with the given
	/// name.
	/// <para>
	/// If the <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual void ResumeTrigger(TriggerKey triggerKey)
	{
		ValidateState();
		resources.JobStore.ResumeTrigger(triggerKey);
		NotifySchedulerThread(null);
		NotifySchedulerListenersResumedTrigger(triggerKey);
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.ITrigger" />s in the
	/// matching groups.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual void ResumeTriggers(GroupMatcher<TriggerKey> matcher)
	{
		ValidateState();
		if (matcher == null)
		{
			matcher = GroupMatcher<TriggerKey>.GroupEquals("DEFAULT");
		}
		ICollection<string> pausedGroups = resources.JobStore.ResumeTriggers(matcher);
		NotifySchedulerThread(null);
		foreach (string pausedGroup in pausedGroups)
		{
			NotifySchedulerListenersResumedTriggers(pausedGroup);
		}
	}

	/// <summary>
	/// Gets the paused trigger groups.
	/// </summary>
	/// <returns></returns>
	public virtual Quartz.Collection.ISet<string> GetPausedTriggerGroups()
	{
		return resources.JobStore.GetPausedTriggerGroups();
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
		ValidateState();
		resources.JobStore.ResumeJob(jobKey);
		NotifySchedulerThread(null);
		NotifySchedulerListenersResumedJob(jobKey);
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.IJobDetail" />s
	/// in the matching groups.
	/// <para>
	/// If any of the <see cref="T:Quartz.IJob" /> s had <see cref="T:Quartz.ITrigger" /> s that
	/// missed one or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s
	/// misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual void ResumeJobs(GroupMatcher<JobKey> matcher)
	{
		ValidateState();
		if (matcher == null)
		{
			matcher = GroupMatcher<JobKey>.GroupEquals("DEFAULT");
		}
		ICollection<string> resumedGroups = resources.JobStore.ResumeJobs(matcher);
		NotifySchedulerThread(null);
		foreach (string pausedGroup in resumedGroups)
		{
			NotifySchedulerListenersResumedJobs(pausedGroup);
		}
	}

	/// <summary>
	/// Pause all triggers - equivalent of calling <see cref="M:Quartz.Core.QuartzScheduler.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// with a matcher matching all known groups.
	/// <para>
	/// When <see cref="M:Quartz.Core.QuartzScheduler.ResumeAll" /> is called (to un-pause), trigger misfire
	/// instructions WILL be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Core.QuartzScheduler.ResumeAll" />
	/// <seealso cref="M:Quartz.Core.QuartzScheduler.PauseJob(Quartz.JobKey)" />
	public virtual void PauseAll()
	{
		ValidateState();
		resources.JobStore.PauseAll();
		NotifySchedulerThread(null);
		NotifySchedulerListenersPausedTriggers(null);
	}

	/// <summary>
	/// Resume (un-pause) all triggers - equivalent of calling <see cref="M:Quartz.Core.QuartzScheduler.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Core.QuartzScheduler.PauseAll" />
	public virtual void ResumeAll()
	{
		ValidateState();
		resources.JobStore.ResumeAll();
		NotifySchedulerThread(null);
		NotifySchedulerListenersResumedTriggers(null);
	}

	/// <summary>
	/// Get the names of all known <see cref="T:Quartz.IJob" /> groups.
	/// </summary>
	public virtual IList<string> GetJobGroupNames()
	{
		ValidateState();
		return resources.JobStore.GetJobGroupNames();
	}

	/// <summary>
	/// Get the names of all the <see cref="T:Quartz.IJob" />s in the
	/// given group.
	/// </summary>
	public virtual Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
	{
		ValidateState();
		if (matcher == null)
		{
			matcher = GroupMatcher<JobKey>.GroupEquals("DEFAULT");
		}
		return resources.JobStore.GetJobKeys(matcher);
	}

	/// <summary> 
	/// Get all <see cref="T:Quartz.ITrigger" /> s that are associated with the
	/// identified <see cref="T:Quartz.IJobDetail" />.
	/// </summary>
	public virtual IList<ITrigger> GetTriggersOfJob(JobKey jobKey)
	{
		ValidateState();
		IList<IOperableTrigger> triggersForJob = resources.JobStore.GetTriggersForJob(jobKey);
		List<ITrigger> retValue = new List<ITrigger>(triggersForJob.Count);
		foreach (IOperableTrigger trigger in triggersForJob)
		{
			retValue.Add(trigger);
		}
		return retValue;
	}

	/// <summary>
	/// Get the names of all known <see cref="T:Quartz.ITrigger" />
	/// groups.
	/// </summary>
	public virtual IList<string> GetTriggerGroupNames()
	{
		ValidateState();
		return resources.JobStore.GetTriggerGroupNames();
	}

	/// <summary>
	/// Get the names of all the <see cref="T:Quartz.ITrigger" />s in
	/// the matching groups.
	/// </summary>
	public virtual Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
	{
		ValidateState();
		if (matcher == null)
		{
			matcher = GroupMatcher<TriggerKey>.GroupEquals("DEFAULT");
		}
		return resources.JobStore.GetTriggerKeys(matcher);
	}

	/// <summary> 
	/// Get the <see cref="T:Quartz.IJobDetail" /> for the <see cref="T:Quartz.IJob" />
	/// instance with the given name and group.
	/// </summary>
	public virtual IJobDetail GetJobDetail(JobKey jobKey)
	{
		ValidateState();
		return resources.JobStore.RetrieveJob(jobKey);
	}

	/// <summary>
	/// Get the <see cref="T:Quartz.ITrigger" /> instance with the given name and
	/// group.
	/// </summary>
	public virtual ITrigger GetTrigger(TriggerKey triggerKey)
	{
		ValidateState();
		return resources.JobStore.RetrieveTrigger(triggerKey);
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.IJob" /> with the given identifier already
	/// exists within the scheduler.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobKey">the identifier to check for</param>
	/// <returns>true if a Job exists with the given identifier</returns>
	public bool CheckExists(JobKey jobKey)
	{
		ValidateState();
		return resources.JobStore.CheckExists(jobKey);
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.ITrigger" /> with the given identifier already
	/// exists within the scheduler.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="triggerKey">the identifier to check for</param>
	/// <returns>true if a Trigger exists with the given identifier</returns>
	public bool CheckExists(TriggerKey triggerKey)
	{
		ValidateState();
		return resources.JobStore.CheckExists(triggerKey);
	}

	/// <summary>
	/// Clears (deletes!) all scheduling data - all <see cref="T:Quartz.IJob" />s, <see cref="T:Quartz.ITrigger" />s
	/// <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	public void Clear()
	{
		ValidateState();
		resources.JobStore.ClearAllSchedulingData();
		NotifySchedulerListenersUnscheduled(null);
	}

	/// <summary>
	/// Get the current state of the identified <see cref="T:Quartz.ITrigger" />.  
	/// </summary>
	/// <seealso cref="T:Quartz.TriggerState" />
	public virtual TriggerState GetTriggerState(TriggerKey triggerKey)
	{
		ValidateState();
		return resources.JobStore.GetTriggerState(triggerKey);
	}

	/// <summary>
	/// Add (register) the given <see cref="T:Quartz.ICalendar" /> to the Scheduler.
	/// </summary>
	public virtual void AddCalendar(string calName, ICalendar calendar, bool replace, bool updateTriggers)
	{
		ValidateState();
		resources.JobStore.StoreCalendar(calName, calendar, replace, updateTriggers);
	}

	/// <summary>
	/// Delete the identified <see cref="T:Quartz.ICalendar" /> from the Scheduler.
	/// </summary>
	/// <returns> true if the Calendar was found and deleted.</returns>
	public virtual bool DeleteCalendar(string calName)
	{
		ValidateState();
		return resources.JobStore.RemoveCalendar(calName);
	}

	/// <summary> 
	/// Get the <see cref="T:Quartz.ICalendar" /> instance with the given name.
	/// </summary>
	public virtual ICalendar GetCalendar(string calName)
	{
		ValidateState();
		return resources.JobStore.RetrieveCalendar(calName);
	}

	/// <summary>
	/// Get the names of all registered <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	public virtual IList<string> GetCalendarNames()
	{
		ValidateState();
		return resources.JobStore.GetCalendarNames();
	}

	/// <summary>
	/// Add the given <see cref="T:Quartz.IJobListener" /> to the
	/// <see cref="T:Quartz.IScheduler" />'s <i>internal</i> list.
	/// </summary>
	/// <param name="jobListener"></param>
	public void AddInternalJobListener(IJobListener jobListener)
	{
		if (jobListener.Name.IsNullOrWhiteSpace())
		{
			throw new ArgumentException("JobListener name cannot be empty.", "jobListener");
		}
		lock (internalJobListeners)
		{
			internalJobListeners[jobListener.Name] = jobListener;
		}
	}

	/// <summary>
	/// Remove the identified <see cref="T:Quartz.IJobListener" /> from the <see cref="T:Quartz.IScheduler" />'s
	/// list of <i>internal</i> listeners.
	/// </summary>
	/// <param name="name"></param>
	/// <returns>true if the identified listener was found in the list, and removed.</returns>
	public bool RemoveInternalJobListener(string name)
	{
		lock (internalJobListeners)
		{
			return internalJobListeners.Remove(name);
		}
	}

	/// <summary>
	/// Get the <i>internal</i> <see cref="T:Quartz.IJobListener" />
	/// that has the given name.
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public IJobListener GetInternalJobListener(string name)
	{
		lock (internalJobListeners)
		{
			internalJobListeners.TryGetValue(name, out var listener);
			return listener;
		}
	}

	/// <summary>
	/// Add the given <see cref="T:Quartz.ITriggerListener" /> to the
	/// <see cref="T:Quartz.IScheduler" />'s <i>internal</i> list.
	/// </summary>
	/// <param name="triggerListener"></param>
	public void AddInternalTriggerListener(ITriggerListener triggerListener)
	{
		if (triggerListener.Name.IsNullOrWhiteSpace())
		{
			throw new ArgumentException("TriggerListener name cannot be empty.", "triggerListener");
		}
		lock (internalTriggerListeners)
		{
			internalTriggerListeners[triggerListener.Name] = triggerListener;
		}
	}

	/// <summary>
	/// Remove the identified <see cref="T:Quartz.ITriggerListener" /> from the <see cref="T:Quartz.IScheduler" />'s
	/// list of <i>internal</i> listeners.
	/// </summary>
	/// <param name="name"></param>
	/// <returns>true if the identified listener was found in the list, and removed.</returns>
	public bool RemoveinternalTriggerListener(string name)
	{
		lock (internalTriggerListeners)
		{
			return internalTriggerListeners.Remove(name);
		}
	}

	/// <summary>
	/// Get the <i>internal</i> <see cref="T:Quartz.ITriggerListener" /> that
	/// has the given name.
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public ITriggerListener GetInternalTriggerListener(string name)
	{
		lock (internalTriggerListeners)
		{
			internalTriggerListeners.TryGetValue(name, out var triggerListener);
			return triggerListener;
		}
	}

	protected internal void NotifyJobStoreJobVetoed(IOperableTrigger trigger, IJobDetail detail, SchedulerInstruction instCode)
	{
		resources.JobStore.TriggeredJobComplete(trigger, detail, instCode);
	}

	/// <summary>
	/// Notifies the job store job complete.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	/// <param name="detail">The detail.</param>
	/// <param name="instCode">The instruction code.</param>
	protected internal virtual void NotifyJobStoreJobComplete(IOperableTrigger trigger, IJobDetail detail, SchedulerInstruction instCode)
	{
		resources.JobStore.TriggeredJobComplete(trigger, detail, instCode);
	}

	/// <summary>
	/// Notifies the scheduler thread.
	/// </summary>
	protected virtual void NotifySchedulerThread(DateTimeOffset? candidateNewNextFireTimeUtc)
	{
		if (SignalOnSchedulingChange)
		{
			schedThread.SignalSchedulingChange(candidateNewNextFireTimeUtc);
		}
	}

	private IEnumerable<ITriggerListener> BuildTriggerListenerList()
	{
		List<ITriggerListener> listeners = new List<ITriggerListener>();
		listeners.AddRange(ListenerManager.GetTriggerListeners());
		listeners.AddRange(InternalTriggerListeners);
		return listeners;
	}

	private IEnumerable<IJobListener> BuildJobListenerList()
	{
		List<IJobListener> listeners = new List<IJobListener>();
		listeners.AddRange(ListenerManager.GetJobListeners());
		listeners.AddRange(InternalJobListeners);
		return listeners;
	}

	private IList<ISchedulerListener> BuildSchedulerListenerList()
	{
		List<ISchedulerListener> allListeners = new List<ISchedulerListener>();
		allListeners.AddRange(ListenerManager.GetSchedulerListeners());
		allListeners.AddRange(InternalSchedulerListeners);
		return allListeners;
	}

	private bool MatchJobListener(IJobListener listener, JobKey key)
	{
		IList<IMatcher<JobKey>> matchers = ListenerManager.GetJobListenerMatchers(listener.Name);
		if (matchers == null)
		{
			return true;
		}
		foreach (IMatcher<JobKey> matcher in matchers)
		{
			if (matcher.IsMatch(key))
			{
				return true;
			}
		}
		return false;
	}

	private bool MatchTriggerListener(ITriggerListener listener, TriggerKey key)
	{
		return ListenerManager.GetTriggerListenerMatchers(listener.Name)?.Any((IMatcher<TriggerKey> matcher) => matcher.IsMatch(key)) ?? true;
	}

	/// <summary>
	/// Notifies the trigger listeners about fired trigger.
	/// </summary>
	/// <param name="jec">The job execution context.</param>
	/// <returns></returns>
	public virtual bool NotifyTriggerListenersFired(IJobExecutionContext jec)
	{
		bool vetoedExecution = false;
		IEnumerable<ITriggerListener> listeners = BuildTriggerListenerList();
		foreach (ITriggerListener tl in listeners)
		{
			if (!MatchTriggerListener(tl, jec.Trigger.Key))
			{
				continue;
			}
			try
			{
				tl.TriggerFired(jec.Trigger, jec);
				if (tl.VetoJobExecution(jec.Trigger, jec))
				{
					vetoedExecution = true;
				}
			}
			catch (Exception e)
			{
				SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "TriggerListener '{0}' threw exception: {1}", new object[2] { tl.Name, e.Message }), e);
				throw se;
			}
		}
		return vetoedExecution;
	}

	/// <summary>
	/// Notifies the trigger listeners about misfired trigger.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	public virtual void NotifyTriggerListenersMisfired(ITrigger trigger)
	{
		IEnumerable<ITriggerListener> listeners = BuildTriggerListenerList();
		foreach (ITriggerListener tl in listeners)
		{
			if (MatchTriggerListener(tl, trigger.Key))
			{
				try
				{
					tl.TriggerMisfired(trigger);
				}
				catch (Exception e)
				{
					SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "TriggerListener '{0}' threw exception: {1}", new object[2] { tl.Name, e.Message }), e);
					throw se;
				}
			}
		}
	}

	/// <summary>
	/// Notifies the trigger listeners of completion.
	/// </summary>
	/// <param name="jec">The job executution context.</param>
	/// <param name="instCode">The instruction code to report to triggers.</param>
	public virtual void NotifyTriggerListenersComplete(IJobExecutionContext jec, SchedulerInstruction instCode)
	{
		IEnumerable<ITriggerListener> listeners = BuildTriggerListenerList();
		foreach (ITriggerListener tl in listeners)
		{
			if (MatchTriggerListener(tl, jec.Trigger.Key))
			{
				try
				{
					tl.TriggerComplete(jec.Trigger, jec, instCode);
				}
				catch (Exception e)
				{
					SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "TriggerListener '{0}' threw exception: {1}", new object[2] { tl.Name, e.Message }), e);
					throw se;
				}
			}
		}
	}

	/// <summary>
	/// Notifies the job listeners about job to be executed.
	/// </summary>
	/// <param name="jec">The jec.</param>
	public virtual void NotifyJobListenersToBeExecuted(IJobExecutionContext jec)
	{
		IEnumerable<IJobListener> listeners = BuildJobListenerList();
		foreach (IJobListener jl in listeners)
		{
			if (MatchJobListener(jl, jec.JobDetail.Key))
			{
				try
				{
					jl.JobToBeExecuted(jec);
				}
				catch (Exception e)
				{
					SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "JobListener '{0}' threw exception: {1}", new object[2] { jl.Name, e.Message }), e);
					throw se;
				}
			}
		}
	}

	/// <summary>
	/// Notifies the job listeners that job exucution was vetoed.
	/// </summary>
	/// <param name="jec">The job execution context.</param>
	public virtual void NotifyJobListenersWasVetoed(IJobExecutionContext jec)
	{
		IEnumerable<IJobListener> listeners = BuildJobListenerList();
		foreach (IJobListener jl in listeners)
		{
			if (MatchJobListener(jl, jec.JobDetail.Key))
			{
				try
				{
					jl.JobExecutionVetoed(jec);
				}
				catch (Exception e)
				{
					SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "JobListener '{0}' threw exception: {1}", new object[2] { jl.Name, e.Message }), e);
					throw se;
				}
			}
		}
	}

	/// <summary>
	/// Notifies the job listeners that job was executed.
	/// </summary>
	/// <param name="jec">The jec.</param>
	/// <param name="je">The je.</param>
	public virtual void NotifyJobListenersWasExecuted(IJobExecutionContext jec, JobExecutionException je)
	{
		IEnumerable<IJobListener> listeners = BuildJobListenerList();
		foreach (IJobListener jl in listeners)
		{
			if (MatchJobListener(jl, jec.JobDetail.Key))
			{
				try
				{
					jl.JobWasExecuted(jec, je);
				}
				catch (Exception e)
				{
					SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "JobListener '{0}' threw exception: {1}", new object[2] { jl.Name, e.Message }), e);
					throw se;
				}
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about scheduler error.
	/// </summary>
	/// <param name="msg">The MSG.</param>
	/// <param name="se">The se.</param>
	public virtual void NotifySchedulerListenersError(string msg, SchedulerException se)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.SchedulerError(msg, se);
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of error: ", e);
				log.Error("  Original error (for notification) was: " + msg, se);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about job that was scheduled.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	public virtual void NotifySchedulerListenersScheduled(ITrigger trigger)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.JobScheduled(trigger);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of scheduled job. Trigger={0}", new object[1] { trigger.Key }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about job that was unscheduled.
	/// </summary>
	public virtual void NotifySchedulerListenersUnscheduled(TriggerKey triggerKey)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				if (triggerKey == null)
				{
					sl.SchedulingDataCleared();
				}
				else
				{
					sl.JobUnscheduled(triggerKey);
				}
			}
			catch (Exception e)
			{
				log.ErrorFormat(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of unscheduled job. Trigger={0}", e, (triggerKey == null) ? "ALL DATA" : triggerKey.ToString());
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about finalized trigger.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	public virtual void NotifySchedulerListenersFinalized(ITrigger trigger)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.TriggerFinalized(trigger);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of finalized trigger. Trigger={0}", new object[1] { trigger.Key }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about paused trigger.
	/// </summary>
	/// <param name="group">The group.</param>
	public virtual void NotifySchedulerListenersPausedTriggers(string group)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.TriggersPaused(group);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of paused group: {0}", new object[1] { group }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about paused trigger.
	/// </summary>
	public virtual void NotifySchedulerListenersPausedTrigger(TriggerKey triggerKey)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.TriggerPaused(triggerKey);
			}
			catch (Exception e)
			{
				log.ErrorFormat(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of paused trigger. Trigger={0}", e, triggerKey);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners resumed trigger.
	/// </summary>
	/// <param name="group">The group.</param>
	public virtual void NotifySchedulerListenersResumedTriggers(string group)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.TriggersResumed(group);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of resumed group: {0}", new object[1] { group }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners resumed trigger.
	/// </summary>
	public virtual void NotifySchedulerListenersResumedTrigger(TriggerKey triggerKey)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.TriggerResumed(triggerKey);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of resumed trigger. Trigger={0}", new object[1] { triggerKey }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about paused job.
	/// </summary>
	public virtual void NotifySchedulerListenersPausedJob(JobKey jobKey)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.JobPaused(jobKey);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of paused job. Job={0}", new object[1] { jobKey }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about paused job.
	/// </summary>
	/// <param name="group">The group.</param>
	public virtual void NotifySchedulerListenersPausedJobs(string group)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.JobsPaused(group);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of paused group: {0}", new object[1] { group }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about resumed job.
	/// </summary>
	public virtual void NotifySchedulerListenersResumedJob(JobKey jobKey)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.JobResumed(jobKey);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of resumed job: {0}", new object[1] { jobKey }), e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about resumed job.
	/// </summary>
	/// <param name="group">The group.</param>
	public virtual void NotifySchedulerListenersResumedJobs(string group)
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.JobsResumed(group);
			}
			catch (Exception e)
			{
				log.Error(string.Format(CultureInfo.InvariantCulture, "Error while notifying SchedulerListener of resumed group: {0}", new object[1] { group }), e);
			}
		}
	}

	public void NotifySchedulerListenersInStandbyMode()
	{
		foreach (ISchedulerListener listener in BuildSchedulerListenerList())
		{
			try
			{
				listener.SchedulerInStandbyMode();
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of inStandByMode.", e);
			}
		}
	}

	public virtual void NotifySchedulerListenersStarted()
	{
		foreach (ISchedulerListener listener in BuildSchedulerListenerList())
		{
			try
			{
				listener.SchedulerStarted();
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of startup.", e);
			}
		}
	}

	public virtual void NotifySchedulerListenersStarting()
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.SchedulerStarting();
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of scheduler starting.", e);
			}
		}
	}

	/// <summary>
	/// Notifies the scheduler listeners about scheduler shutdown.
	/// </summary>
	public virtual void NotifySchedulerListenersShutdown()
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.SchedulerShutdown();
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of Shutdown.", e);
			}
		}
	}

	public virtual void NotifySchedulerListenersShuttingdown()
	{
		IList<ISchedulerListener> schedListeners = BuildSchedulerListenerList();
		foreach (ISchedulerListener sl in schedListeners)
		{
			try
			{
				sl.SchedulerShuttingdown();
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of shutdown.", e);
			}
		}
	}

	public virtual void NotifySchedulerListenersJobAdded(IJobDetail jobDetail)
	{
		foreach (ISchedulerListener listener in BuildSchedulerListenerList())
		{
			try
			{
				listener.JobAdded(jobDetail);
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of JobAdded.", e);
			}
		}
	}

	public virtual void NotifySchedulerListenersJobDeleted(JobKey jobKey)
	{
		foreach (ISchedulerListener listener in BuildSchedulerListenerList())
		{
			try
			{
				listener.JobDeleted(jobKey);
			}
			catch (Exception e)
			{
				log.Error("Error while notifying SchedulerListener of job deletion.", e);
			}
		}
	}

	/// <summary>
	/// Interrupt all instances of the identified InterruptableJob.
	/// </summary>
	public virtual bool Interrupt(JobKey jobKey)
	{
		IList<IJobExecutionContext> jobs = CurrentlyExecutingJobs;
		bool interrupted = false;
		foreach (IJobExecutionContext jec in jobs)
		{
			IJobDetail jobDetail = jec.JobDetail;
			if (jobKey.Equals(jobDetail.Key))
			{
				IJob job = jec.JobInstance;
				if (!(job is IInterruptableJob))
				{
					throw new UnableToInterruptJobException(string.Format(CultureInfo.InvariantCulture, "Job '{0}' can not be interrupted, since it does not implement {1}", new object[2]
					{
						jobDetail.Key,
						typeof(IInterruptableJob).FullName
					}));
				}
				((IInterruptableJob)job).Interrupt();
				interrupted = true;
			}
		}
		return interrupted;
	}

	/// <summary>
	/// Interrupt all instances of the identified InterruptableJob executing in this Scheduler instance.
	/// </summary>
	/// <remarks>
	/// This method is not cluster aware.  That is, it will only interrupt 
	/// instances of the identified InterruptableJob currently executing in this 
	/// Scheduler instance, not across the entire cluster.
	/// </remarks>
	/// <seealso cref="M:Quartz.Simpl.IRemotableQuartzScheduler.Interrupt(Quartz.JobKey)" />
	/// <param name="fireInstanceId"></param>
	/// <returns></returns>
	public bool Interrupt(string fireInstanceId)
	{
		IList<IJobExecutionContext> jobs = CurrentlyExecutingJobs;
		foreach (IJobExecutionContext jec in jobs)
		{
			if (jec.FireInstanceId.Equals(fireInstanceId))
			{
				IJob job = jec.JobInstance;
				if (job is IInterruptableJob)
				{
					((IInterruptableJob)job).Interrupt();
					return true;
				}
				throw new UnableToInterruptJobException(string.Concat("Job ", jec.JobDetail.Key, " can not be interrupted, since it does not implement ", typeof(IInterruptableJob).Name));
			}
		}
		return false;
	}

	private void ShutdownPlugins()
	{
		foreach (ISchedulerPlugin plugin in resources.SchedulerPlugins)
		{
			plugin.Shutdown();
		}
	}

	private void StartPlugins()
	{
		foreach (ISchedulerPlugin plugin in resources.SchedulerPlugins)
		{
			plugin.Start();
		}
	}

	public bool IsJobGroupPaused(string groupName)
	{
		return resources.JobStore.IsJobGroupPaused(groupName);
	}

	public bool IsTriggerGroupPaused(string groupName)
	{
		return resources.JobStore.IsTriggerGroupPaused(groupName);
	}

	/// <summary>
	/// Obtains a lifetime service object to control the lifetime policy for this instance.
	/// </summary>
	[SecurityCritical]
	public override object InitializeLifetimeService()
	{
		return null;
	}
}
