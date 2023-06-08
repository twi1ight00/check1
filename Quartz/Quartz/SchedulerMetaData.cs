using System;
using System.Text;

namespace Quartz;

/// <summary>
/// Describes the settings and capabilities of a given <see cref="T:Quartz.IScheduler" />
/// instance.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class SchedulerMetaData
{
	private readonly string schedName;

	private readonly string schedInst;

	private readonly Type schedType;

	private readonly bool isRemote;

	private readonly bool started;

	private readonly bool isInStandbyMode;

	private readonly bool shutdown;

	private readonly DateTimeOffset? startTime;

	private readonly int numberOfJobsExec;

	private readonly Type jsType;

	private readonly bool jsPersistent;

	private readonly bool jsClustered;

	private readonly Type tpType;

	private readonly int tpSize;

	private readonly string version;

	/// <summary>
	/// Returns the name of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual string SchedulerName => schedName;

	/// <summary>
	/// Returns the instance Id of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual string SchedulerInstanceId => schedInst;

	/// <summary>
	/// Returns the class-name of the <see cref="T:Quartz.IScheduler" /> instance.
	/// </summary>
	public virtual Type SchedulerType => schedType;

	/// <summary>
	/// Returns whether the <see cref="T:Quartz.IScheduler" /> is being used remotely (via remoting).
	/// </summary>
	public virtual bool SchedulerRemote => isRemote;

	/// <summary>
	/// Returns whether the scheduler has been started.
	/// </summary>
	/// <remarks>
	/// Note: <see cref="P:Quartz.SchedulerMetaData.Started" /> may return <see langword="true" /> even if
	/// <see cref="P:Quartz.SchedulerMetaData.InStandbyMode" /> returns <see langword="true" />.
	/// </remarks>
	public virtual bool Started => started;

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> is in standby mode.
	/// </summary>
	/// <remarks>
	/// Note: <see cref="P:Quartz.SchedulerMetaData.Started" /> may return <see langword="true" /> even if
	/// <see cref="P:Quartz.SchedulerMetaData.InStandbyMode" /> returns <see langword="true" />.
	/// </remarks>
	public virtual bool InStandbyMode => isInStandbyMode;

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> has been Shutdown.
	/// </summary>
	public virtual bool Shutdown => shutdown;

	/// <summary>
	/// Returns the class-name of the <see cref="T:Quartz.Spi.IJobStore" /> instance that is
	/// being used by the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual Type JobStoreType => jsType;

	/// <summary>
	/// Returns the type name of the <see cref="T:System.Threading.ThreadPool" /> instance that is
	/// being used by the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual Type ThreadPoolType => tpType;

	/// <summary> 
	/// Returns the number of threads currently in the <see cref="T:Quartz.IScheduler" />'s
	/// </summary>
	public virtual int ThreadPoolSize => tpSize;

	/// <summary>
	/// Returns the version of Quartz that is running.
	/// </summary>
	public virtual string Version => version;

	/// <summary> 
	/// Returns the <see cref="T:System.DateTimeOffset" /> at which the Scheduler started running.
	/// </summary>
	/// <returns> null if the scheduler has not been started.
	/// </returns>
	public virtual DateTimeOffset? RunningSince => startTime;

	/// <summary>
	/// Returns the number of jobs executed since the <see cref="T:Quartz.IScheduler" />
	/// started..
	/// </summary>
	public virtual int NumberOfJobsExecuted => numberOfJobsExec;

	/// <summary>
	/// Returns whether or not the <see cref="T:Quartz.IScheduler" />'s<see cref="T:Quartz.Spi.IJobStore" />
	/// instance supports persistence.
	/// </summary>
	public virtual bool JobStoreSupportsPersistence => jsPersistent;

	/// <summary>
	/// Returns whether or not the <see cref="T:Quartz.IScheduler" />'s <see cref="T:Quartz.Spi.IJobStore" />
	/// is clustered.
	/// </summary>
	public virtual bool JobStoreClustered => jsClustered;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerMetaData" /> class.
	/// </summary>
	/// <param name="schedName">Name of the scheduler.</param>
	/// <param name="schedInst">The scheduler instance.</param>
	/// <param name="schedType">The scheduler type.</param>
	/// <param name="isRemote">if set to <c>true</c>, scheduler is a remote scheduler.</param>
	/// <param name="started">if set to <c>true</c>, scheduler is started.</param>
	/// <param name="isInStandbyMode">if set to <c>true</c>, scheduler is in standby mode.</param>
	/// <param name="shutdown">if set to <c>true</c>, scheduler is shutdown.</param>
	/// <param name="startTime">The start time.</param>
	/// <param name="numberOfJobsExec">The number of jobs executed.</param>
	/// <param name="jsType">The job store type.</param>
	/// <param name="jsPersistent">if set to <c>true</c>, job store is persistent.</param>
	/// <param name="jsClustered">if set to <c>true</c>, the job store is clustered</param>
	/// <param name="tpType">The thread pool type.</param>
	/// <param name="tpSize">Size of the thread pool.</param>
	/// <param name="version">The version string.</param>
	public SchedulerMetaData(string schedName, string schedInst, Type schedType, bool isRemote, bool started, bool isInStandbyMode, bool shutdown, DateTimeOffset? startTime, int numberOfJobsExec, Type jsType, bool jsPersistent, bool jsClustered, Type tpType, int tpSize, string version)
	{
		this.schedName = schedName;
		this.schedInst = schedInst;
		this.schedType = schedType;
		this.isRemote = isRemote;
		this.started = started;
		this.isInStandbyMode = isInStandbyMode;
		this.shutdown = shutdown;
		this.startTime = startTime;
		this.numberOfJobsExec = numberOfJobsExec;
		this.jsType = jsType;
		this.jsPersistent = jsPersistent;
		this.jsClustered = jsClustered;
		this.tpType = tpType;
		this.tpSize = tpSize;
		this.version = version;
	}

	/// <summary>
	/// Returns a formatted (human readable) string describing all the <see cref="T:Quartz.IScheduler" />'s
	/// meta-data values.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The format of the string looks something like this:
	/// <pre>
	/// Quartz Scheduler 'SchedulerName' with instanceId 'SchedulerInstanceId' Scheduler class: 'Quartz.Impl.StdScheduler' - running locally. Running since: '11:33am on Jul 19, 2002' Not currently paused. Number of Triggers fired: '123' Using thread pool 'Quartz.Simpl.SimpleThreadPool' - with '8' threads Using job-store 'Quartz.Impl.JobStore' - which supports persistence.
	/// </pre>
	/// </para>
	/// </remarks>
	public string GetSummary()
	{
		StringBuilder str = new StringBuilder("Quartz Scheduler (v");
		str.Append(Version);
		str.Append(") '");
		str.Append(SchedulerName);
		str.Append("' with instanceId '");
		str.Append(SchedulerInstanceId);
		str.Append("'\n");
		str.Append("  Scheduler class: '");
		str.Append(SchedulerType.FullName);
		str.Append("'");
		if (SchedulerRemote)
		{
			str.Append(" - access via remote incovation.");
		}
		else
		{
			str.Append(" - running locally.");
		}
		str.Append("\n");
		if (!Shutdown)
		{
			if (RunningSince.HasValue)
			{
				str.Append("  Running since: ");
				str.Append(RunningSince);
			}
			else
			{
				str.Append("  NOT STARTED.");
			}
			str.Append("\n");
			if (InStandbyMode)
			{
				str.Append("  Currently in standby mode.");
			}
			else
			{
				str.Append("  Not currently in standby mode.");
			}
		}
		else
		{
			str.Append("  Scheduler has been SHUTDOWN.");
		}
		str.Append("\n");
		str.Append("  Number of jobs executed: ");
		str.Append(NumberOfJobsExecuted);
		str.Append("\n");
		str.Append("  Using thread pool '");
		str.Append(ThreadPoolType.FullName);
		str.Append("' - with ");
		str.Append(ThreadPoolSize);
		str.Append(" threads.");
		str.Append("\n");
		str.Append("  Using job-store '");
		str.Append(JobStoreType.FullName);
		str.Append("' - which ");
		if (JobStoreSupportsPersistence)
		{
			str.Append("supports persistence.");
		}
		else
		{
			str.Append("does not support persistence.");
		}
		if (JobStoreClustered)
		{
			str.Append(" and is clustered.");
		}
		else
		{
			str.Append(" and is not clustered.");
		}
		str.Append("\n");
		return str.ToString();
	}

	/// <summary>
	/// Return a simple string representation of this object.
	/// </summary>
	public override string ToString()
	{
		try
		{
			return GetSummary();
		}
		catch (SchedulerException)
		{
			return "SchedulerMetaData: undeterminable.";
		}
	}
}
