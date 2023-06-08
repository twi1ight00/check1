using System.Collections.Generic;

namespace Quartz.Listener;

/// <summary>
/// Holds a List of references to SchedulerListener instances and broadcasts all
///  events to them (in order).
///             </summary>
/// <remarks>
/// This may be more convenient than registering all of the listeners
/// directly with the Scheduler, and provides the flexibility of easily changing
/// which listeners get notified.
/// </remarks>
/// <see cref="M:Quartz.Listener.BroadcastSchedulerListener.AddListener(Quartz.ISchedulerListener)" />
/// <see cref="M:Quartz.Listener.BroadcastSchedulerListener.RemoveListener(Quartz.ISchedulerListener)" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class BroadcastSchedulerListener : ISchedulerListener
{
	private readonly List<ISchedulerListener> listeners;

	public BroadcastSchedulerListener()
	{
		listeners = new List<ISchedulerListener>();
	}

	/// <summary>
	/// Construct an instance with the given List of listeners.
	/// </summary>
	/// <param name="listeners">The initial List of SchedulerListeners to broadcast to.</param>
	public BroadcastSchedulerListener(IEnumerable<ISchedulerListener> listeners)
	{
		this.listeners.AddRange(listeners);
	}

	public void AddListener(ISchedulerListener listener)
	{
		listeners.Add(listener);
	}

	public bool RemoveListener(ISchedulerListener listener)
	{
		return listeners.Remove(listener);
	}

	public IList<ISchedulerListener> GetListeners()
	{
		return listeners.AsReadOnly();
	}

	public void JobAdded(IJobDetail jobDetail)
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.JobAdded(jobDetail);
		}
	}

	public void JobDeleted(JobKey jobKey)
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.JobDeleted(jobKey);
		}
	}

	public void JobScheduled(ITrigger trigger)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobScheduled(trigger);
		}
	}

	public void JobUnscheduled(TriggerKey triggerKey)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobUnscheduled(triggerKey);
		}
	}

	public void TriggerFinalized(ITrigger trigger)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.TriggerFinalized(trigger);
		}
	}

	public void TriggersPaused(string triggerGroup)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.TriggersPaused(triggerGroup);
		}
	}

	public void TriggerPaused(TriggerKey triggerKey)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.TriggerPaused(triggerKey);
		}
	}

	public void TriggersResumed(string triggerGroup)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.TriggersResumed(triggerGroup);
		}
	}

	public void SchedulingDataCleared()
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.SchedulingDataCleared();
		}
	}

	public void TriggerResumed(TriggerKey triggerKey)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.TriggerResumed(triggerKey);
		}
	}

	public void JobsPaused(string jobGroup)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobsPaused(jobGroup);
		}
	}

	public void JobPaused(JobKey jobKey)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobPaused(jobKey);
		}
	}

	public void JobsResumed(string jobGroup)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobsResumed(jobGroup);
		}
	}

	public void JobResumed(JobKey jobKey)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.JobResumed(jobKey);
		}
	}

	public void SchedulerError(string msg, SchedulerException cause)
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.SchedulerError(msg, cause);
		}
	}

	public void SchedulerStarted()
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.SchedulerStarted();
		}
	}

	public void SchedulerStarting()
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.SchedulerStarting();
		}
	}

	public void SchedulerInStandbyMode()
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.SchedulerInStandbyMode();
		}
	}

	public void SchedulerShutdown()
	{
		foreach (ISchedulerListener i in listeners)
		{
			i.SchedulerShutdown();
		}
	}

	public void SchedulerShuttingdown()
	{
		foreach (ISchedulerListener listener in listeners)
		{
			listener.SchedulerShuttingdown();
		}
	}
}
