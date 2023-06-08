using System;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Core;

/// <summary> 
/// An interface to be used by <see cref="T:Quartz.Spi.IJobStore" /> instances in order to
/// communicate signals back to the <see cref="T:Quartz.Core.QuartzScheduler" />.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class SchedulerSignalerImpl : ISchedulerSignaler
{
	private readonly ILog log = LogManager.GetLogger(typeof(SchedulerSignalerImpl));

	protected readonly QuartzScheduler sched;

	protected readonly QuartzSchedulerThread schedThread;

	public SchedulerSignalerImpl(QuartzScheduler sched, QuartzSchedulerThread schedThread)
	{
		this.sched = sched;
		this.schedThread = schedThread;
		log.Info("Initialized Scheduler Signaller of type: " + GetType());
	}

	/// <summary>
	/// Notifies the scheduler about misfired trigger.
	/// </summary>
	/// <param name="trigger">The trigger that misfired.</param>
	public virtual void NotifyTriggerListenersMisfired(ITrigger trigger)
	{
		try
		{
			sched.NotifyTriggerListenersMisfired(trigger);
		}
		catch (SchedulerException se)
		{
			log.Error("Error notifying listeners of trigger misfire.", se);
			sched.NotifySchedulerListenersError("Error notifying listeners of trigger misfire.", se);
		}
	}

	/// <summary>
	/// Notifies the scheduler about finalized trigger.
	/// </summary>
	/// <param name="trigger">The trigger that has finalized.</param>
	public void NotifySchedulerListenersFinalized(ITrigger trigger)
	{
		sched.NotifySchedulerListenersFinalized(trigger);
	}

	/// <summary>
	/// Signals the scheduling change.
	/// </summary>
	public void SignalSchedulingChange(DateTimeOffset? candidateNewNextFireTime)
	{
		schedThread.SignalSchedulingChange(candidateNewNextFireTime);
	}

	public void NotifySchedulerListenersJobDeleted(JobKey jobKey)
	{
		sched.NotifySchedulerListenersJobDeleted(jobKey);
	}
}
