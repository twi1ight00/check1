using System;
using System.Collections.Generic;
using System.Globalization;
using Quartz.Spi;

namespace Quartz.Impl;

/// <summary>
/// A context bundle containing handles to various environment information, that
/// is given to a <see cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> instance as it is
/// executed, and to a <see cref="T:Quartz.ITrigger" /> instance after the
/// execution completes.
/// </summary>
/// <remarks>
/// <para>
/// The <see cref="T:Quartz.JobDataMap" /> found on this object (via the 
/// <see cref="P:Quartz.Impl.JobExecutionContextImpl.MergedJobDataMap" /> method) serves as a convenience -
/// it is a merge of the <see cref="T:Quartz.JobDataMap" /> found on the 
/// <see cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> and the one found on the <see cref="T:Quartz.ITrigger" />, with 
/// the value in the latter overriding any same-named values in the former.
/// <i>It is thus considered a 'best practice' that the Execute code of a Job
/// retrieve data from the JobDataMap found on this object</i> 
/// </para>
/// <para>
/// NOTE: Do not
/// expect value 'set' into this JobDataMap to somehow be set back onto a
/// job's own JobDataMap.
/// </para>
///
/// <para>
/// <see cref="T:Quartz.IJobExecutionContext" /> s are also returned from the 
/// <see cref="M:Quartz.IScheduler.GetCurrentlyExecutingJobs" />
/// method. These are the same instances as those past into the jobs that are
/// currently executing within the scheduler. The exception to this is when your
/// application is using Quartz remotely (i.e. via remoting or WCF) - in which case you get
/// a clone of the <see cref="T:Quartz.IJobExecutionContext" />s, and their references to
/// the <see cref="T:Quartz.IScheduler" /> and <see cref="T:Quartz.IJob" /> instances have been lost (a
/// clone of the <see cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> is still available - just not a handle
/// to the job instance that is running).
/// </para>
/// </remarks>
/// <seealso cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> 
/// <seealso cref="T:Quartz.IScheduler" />
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <seealso cref="T:Quartz.JobDataMap" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class JobExecutionContextImpl : IJobExecutionContext
{
	[NonSerialized]
	private readonly IScheduler scheduler;

	private readonly ITrigger trigger;

	private readonly IJobDetail jobDetail;

	private readonly JobDataMap jobDataMap;

	[NonSerialized]
	private readonly IJob job;

	private readonly ICalendar calendar;

	private readonly bool recovering;

	private int numRefires;

	private readonly DateTimeOffset? fireTimeUtc;

	private readonly DateTimeOffset? scheduledFireTimeUtc;

	private readonly DateTimeOffset? prevFireTimeUtc;

	private readonly DateTimeOffset? nextFireTimeUtc;

	private TimeSpan jobRunTime = TimeSpan.MinValue;

	private object result;

	private readonly IDictionary<object, object> data = new Dictionary<object, object>();

	/// <summary>
	/// Get a handle to the <see cref="T:Quartz.IScheduler" /> instance that fired the
	/// <see cref="T:Quartz.IJob" />.
	/// </summary>
	public virtual IScheduler Scheduler => scheduler;

	/// <summary>
	/// Get a handle to the <see cref="T:Quartz.ITrigger" /> instance that fired the
	/// <see cref="T:Quartz.IJob" />.
	/// </summary>
	public virtual ITrigger Trigger => trigger;

	/// <summary>
	/// Get a handle to the <see cref="T:Quartz.ICalendar" /> referenced by the <see cref="T:Quartz.ITrigger" />
	/// instance that fired the <see cref="T:Quartz.IJob" />.
	/// </summary>
	public virtual ICalendar Calendar => calendar;

	/// <summary>
	/// If the <see cref="T:Quartz.IJob" /> is being re-executed because of a 'recovery'
	/// situation, this method will return <see langword="true" />.
	/// </summary>
	public virtual bool Recovering => recovering;

	/// <summary>
	/// Gets the refire count.
	/// </summary>
	/// <value>The refire count.</value>
	public virtual int RefireCount => numRefires;

	/// <summary>
	/// Get the convenience <see cref="T:Quartz.JobDataMap" /> of this execution context.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <see cref="T:Quartz.JobDataMap" /> found on this object serves as a convenience -
	/// it is a merge of the <see cref="T:Quartz.JobDataMap" /> found on the 
	/// <see cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> and the one found on the <see cref="T:Quartz.ITrigger" />, with 
	/// the value in the latter overriding any same-named values in the former.
	/// <i>It is thus considered a 'best practice' that the Execute code of a Job
	/// retrieve data from the JobDataMap found on this object.</i>
	/// </para>
	/// <para>
	/// NOTE: Do not expect value 'set' into this JobDataMap to somehow be 
	/// set back onto a job's own JobDataMap.
	/// </para>
	/// <para>
	/// Attempts to change the contents of this map typically result in an 
	/// illegal state.
	/// </para>
	/// </remarks>
	public virtual JobDataMap MergedJobDataMap => jobDataMap;

	/// <summary>
	/// Get the <see cref="P:Quartz.Impl.JobExecutionContextImpl.JobDetail" /> associated with the <see cref="T:Quartz.IJob" />.
	/// </summary>
	public virtual IJobDetail JobDetail => jobDetail;

	/// <summary>
	/// Get the instance of the <see cref="T:Quartz.IJob" /> that was created for this
	/// execution.
	/// <para>
	/// Note: The Job instance is not available through remote scheduler
	/// interfaces.
	/// </para>
	/// </summary>
	public virtual IJob JobInstance => job;

	/// <summary>
	/// The actual time the trigger fired. For instance the scheduled time may
	/// have been 10:00:00 but the actual fire time may have been 10:00:03 if
	/// the scheduler was too busy.
	/// </summary>
	/// <returns> Returns the fireTimeUtc.</returns>
	/// <seealso cref="P:Quartz.Impl.JobExecutionContextImpl.ScheduledFireTimeUtc" />
	public DateTimeOffset? FireTimeUtc => fireTimeUtc;

	/// <summary> 
	/// The scheduled time the trigger fired for. For instance the scheduled
	/// time may have been 10:00:00 but the actual fire time may have been
	/// 10:00:03 if the scheduler was too busy.
	/// </summary>
	/// <returns> Returns the scheduledFireTimeUtc.</returns>
	/// <seealso cref="P:Quartz.Impl.JobExecutionContextImpl.FireTimeUtc" />
	public DateTimeOffset? ScheduledFireTimeUtc => scheduledFireTimeUtc;

	/// <summary>
	/// Gets the previous fire time.
	/// </summary>
	/// <value>The previous fire time.</value>
	public DateTimeOffset? PreviousFireTimeUtc => prevFireTimeUtc;

	/// <summary>
	/// Gets the next fire time.
	/// </summary>
	/// <value>The next fire time.</value>
	public DateTimeOffset? NextFireTimeUtc => nextFireTimeUtc;

	/// <summary>
	/// Returns the result (if any) that the <see cref="T:Quartz.IJob" /> set before its 
	/// execution completed (the type of object set as the result is entirely up 
	/// to the particular job).
	/// </summary>
	/// <remarks>
	/// <para>
	/// The result itself is meaningless to Quartz, but may be informative
	/// to <see cref="T:Quartz.IJobListener" />s or 
	/// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's 
	/// execution.
	/// </para> 
	///
	/// Set the result (if any) of the <see cref="T:Quartz.IJob" />'s execution (the type of 
	/// object set as the result is entirely up to the particular job).
	///
	/// <para>
	/// The result itself is meaningless to Quartz, but may be informative
	/// to <see cref="T:Quartz.IJobListener" />s or 
	/// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's 
	/// execution.
	/// </para> 
	/// </remarks>
	public virtual object Result
	{
		get
		{
			return result;
		}
		set
		{
			result = value;
		}
	}

	/// <summary> 
	/// The amount of time the job ran for.  The returned 
	/// value will be <see cref="F:System.TimeSpan.MinValue" /> until the job has actually completed (or thrown an 
	/// exception), and is therefore generally only useful to 
	/// <see cref="T:Quartz.IJobListener" />s and <see cref="T:Quartz.ITriggerListener" />s.
	/// </summary>
	public virtual TimeSpan JobRunTime
	{
		get
		{
			return jobRunTime;
		}
		set
		{
			jobRunTime = value;
		}
	}

	/// <summary>
	/// Returns the fire instace id.
	/// </summary>
	public string FireInstanceId => ((IOperableTrigger)trigger).FireInstanceId;

	/// <summary>
	/// Create a JobExcecutionContext with the given context data.
	/// </summary>
	public JobExecutionContextImpl(IScheduler scheduler, TriggerFiredBundle firedBundle, IJob job)
	{
		this.scheduler = scheduler;
		trigger = firedBundle.Trigger;
		calendar = firedBundle.Calendar;
		jobDetail = firedBundle.JobDetail;
		this.job = job;
		recovering = firedBundle.Recovering;
		fireTimeUtc = firedBundle.FireTimeUtc;
		scheduledFireTimeUtc = firedBundle.ScheduledFireTimeUtc;
		prevFireTimeUtc = firedBundle.PrevFireTimeUtc;
		nextFireTimeUtc = firedBundle.NextFireTimeUtc;
		jobDataMap = new JobDataMap();
		jobDataMap.PutAll(jobDetail.JobDataMap);
		jobDataMap.PutAll(trigger.JobDataMap);
	}

	/// <summary>
	/// Increments the refire count.
	/// </summary>
	public virtual void IncrementRefireCount()
	{
		numRefires++;
	}

	/// <summary>
	/// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JobExecutionContext: trigger: '{0}' job: '{1}' fireTimeUtc: '{2:r}' scheduledFireTimeUtc: '{3:r}' previousFireTimeUtc: '{4:r}' nextFireTimeUtc: '{5:r}' recovering: {6} refireCount: {7}", Trigger.Key, JobDetail.Key, FireTimeUtc, ScheduledFireTimeUtc, PreviousFireTimeUtc, NextFireTimeUtc, Recovering, RefireCount);
	}

	/// <summary> 
	/// Put the specified value into the context's data map with the given key.
	/// Possibly useful for sharing data between listeners and jobs.
	/// <para>
	/// NOTE: this data is volatile - it is lost after the job execution
	/// completes, and all TriggerListeners and JobListeners have been 
	/// notified.
	/// </para> 
	/// </summary>
	/// <param name="key">
	/// </param>
	/// <param name="objectValue">
	/// </param>
	public virtual void Put(object key, object objectValue)
	{
		data[key] = objectValue;
	}

	/// <summary> 
	/// Get the value with the given key from the context's data map.
	/// </summary>
	/// <param name="key">
	/// </param>
	public virtual object Get(object key)
	{
		data.TryGetValue(key, out var retValue);
		return retValue;
	}
}
