using System;

namespace Quartz.Spi;

/// <summary> 
/// An interface to be used by <see cref="T:Quartz.Spi.IJobStore" /> instances in order to
/// communicate signals back to the <see cref="T:Quartz.Core.QuartzScheduler" />.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISchedulerSignaler
{
	/// <summary>
	/// Notifies the scheduler about misfired trigger.
	/// </summary>
	/// <param name="trigger">The trigger that misfired.</param>
	void NotifyTriggerListenersMisfired(ITrigger trigger);

	/// <summary>
	/// Notifies the scheduler about finalized trigger.
	/// </summary>
	/// <param name="trigger">The trigger that has finalized.</param>
	void NotifySchedulerListenersFinalized(ITrigger trigger);

	void NotifySchedulerListenersJobDeleted(JobKey jobKey);

	/// <summary>
	/// Signals the scheduling change.
	/// </summary>
	void SignalSchedulingChange(DateTimeOffset? candidateNewNextFireTimeUtc);
}
