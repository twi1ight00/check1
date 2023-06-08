using Common.Logging;

namespace Quartz.Listener;

/// <summary>
///  A helpful abstract base class for implementors of 
/// <see cref="T:Quartz.ISchedulerListener" />.
/// </summary>
/// <remarks>
/// The methods in this class are empty so you only need to override the  
/// subset for the <see cref="T:Quartz.ISchedulerListener" /> events you care about.
/// </remarks>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.ISchedulerListener" />
public abstract class SchedulerListenerSupport : ISchedulerListener
{
	private readonly ILog log;

	/// <summary>
	/// Get the <see cref="T:Common.Logging.ILog" /> for this
	/// type's category.  This should be used by subclasses for logging.
	/// </summary>
	protected ILog Log => log;

	protected SchedulerListenerSupport()
	{
		log = LogManager.GetLogger(GetType());
	}

	public virtual void JobScheduled(ITrigger trigger)
	{
	}

	public virtual void JobUnscheduled(TriggerKey triggerKey)
	{
	}

	public virtual void TriggerFinalized(ITrigger trigger)
	{
	}

	public virtual void TriggersPaused(string triggerGroup)
	{
	}

	public virtual void TriggerPaused(TriggerKey triggerKey)
	{
	}

	public virtual void TriggersResumed(string triggerGroup)
	{
	}

	public virtual void TriggerResumed(TriggerKey triggerKey)
	{
	}

	public virtual void JobAdded(IJobDetail jobDetail)
	{
	}

	public virtual void JobDeleted(JobKey jobKey)
	{
	}

	public virtual void JobsPaused(string jobGroup)
	{
	}

	public virtual void JobPaused(JobKey jobKey)
	{
	}

	public virtual void JobsResumed(string jobGroup)
	{
	}

	public virtual void JobResumed(JobKey jobKey)
	{
	}

	public virtual void SchedulerError(string msg, SchedulerException cause)
	{
	}

	public virtual void SchedulerInStandbyMode()
	{
	}

	public virtual void SchedulerStarted()
	{
	}

	public void SchedulerStarting()
	{
	}

	public virtual void SchedulerShutdown()
	{
	}

	public virtual void SchedulerShuttingdown()
	{
	}

	public virtual void SchedulingDataCleared()
	{
	}
}
