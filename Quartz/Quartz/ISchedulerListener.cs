namespace Quartz;

/// <summary>
/// The interface to be implemented by classes that want to be informed of major
/// <see cref="T:Quartz.IScheduler" /> events.
/// </summary>
/// <seealso cref="T:Quartz.IScheduler" />
/// <seealso cref="T:Quartz.IJobListener" />
/// <seealso cref="T:Quartz.ITriggerListener" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISchedulerListener
{
	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// is scheduled.
	/// </summary>
	void JobScheduled(ITrigger trigger);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// is unscheduled.
	/// </summary>
	/// <seealso cref="M:Quartz.ISchedulerListener.SchedulingDataCleared" />
	void JobUnscheduled(TriggerKey triggerKey);

	/// <summary> 
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has reached the condition in which it will never fire again.
	/// </summary>
	void TriggerFinalized(ITrigger trigger);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> a <see cref="T:Quartz.ITrigger" />s has been paused.
	/// </summary>
	void TriggerPaused(TriggerKey triggerKey);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> a group of 
	/// <see cref="T:Quartz.ITrigger" />s has been paused.
	/// </summary>
	/// <remarks>
	/// If a all groups were paused, then the <see param="triggerName" /> parameter
	/// will be null.
	/// </remarks>
	/// <param name="triggerGroup">The trigger group.</param>
	void TriggersPaused(string triggerGroup);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has been un-paused.
	/// </summary>
	void TriggerResumed(TriggerKey triggerKey);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a
	/// group of <see cref="T:Quartz.ITrigger" />s has been un-paused.
	/// </summary>
	/// <remarks>
	/// If all groups were resumed, then the <see param="triggerName" /> parameter
	/// will be null.
	/// </remarks>
	/// <param name="triggerGroup">The trigger group.</param>
	void TriggersResumed(string triggerGroup);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// has been added.
	/// </summary>
	/// <param name="jobDetail"></param>
	void JobAdded(IJobDetail jobDetail);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// has been deleted.
	/// </summary>
	void JobDeleted(JobKey jobKey);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// has been  paused.
	/// </summary>
	void JobPaused(JobKey jobKey);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a
	/// group of <see cref="T:Quartz.IJobDetail" />s has been  paused.
	/// <para>
	/// If all groups were paused, then the <see param="jobName" /> parameter will be
	/// null. If all jobs were paused, then both parameters will be null.
	/// </para>
	/// </summary>
	/// <param name="jobGroup">The job group.</param>
	void JobsPaused(string jobGroup);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// has been  un-paused.
	/// </summary>
	void JobResumed(JobKey jobKey);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// has been  un-paused.
	/// </summary>
	/// <param name="jobGroup">The job group.</param>
	void JobsResumed(string jobGroup);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a serious error has
	/// occurred within the scheduler - such as repeated failures in the <see cref="T:Quartz.Spi.IJobStore" />,
	/// or the inability to instantiate a <see cref="T:Quartz.IJob" /> instance when its
	/// <see cref="T:Quartz.ITrigger" /> has fired.
	/// </summary>
	void SchedulerError(string msg, SchedulerException cause);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
	/// that it has move to standby mode.
	/// </summary>
	void SchedulerInStandbyMode();

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
	/// that it has started.
	/// </summary>
	void SchedulerStarted();

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener that it is starting.
	/// </summary>
	void SchedulerStarting();

	/// <summary> 
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
	/// that it has Shutdown.
	/// </summary>
	void SchedulerShutdown();

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
	/// that it has begun the shutdown sequence.
	/// </summary>
	void SchedulerShuttingdown();

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
	/// that all jobs, triggers and calendars were deleted.
	/// </summary>
	void SchedulingDataCleared();
}
