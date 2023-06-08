using Common.Logging;

namespace Quartz.Listener;

/// <summary>
///  A helpful abstract base class for implementors of 
/// <see cref="T:Quartz.ITriggerListener" />.
///  </summary>
/// <remarks>
/// <para>
/// The methods in this class are empty so you only need to override the  
/// subset for the <see cref="T:Quartz.ITriggerListener" /> events
/// you care about.
/// </para>
///
/// <para>
/// You are required to implement <see cref="P:Quartz.ITriggerListener.Name" /> 
/// to return the unique name of your <see cref="T:Quartz.ITriggerListener" />.  
/// </para>
///             </remarks>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.ITriggerListener" />
public abstract class TriggerListenerSupport : ITriggerListener
{
	private readonly ILog log;

	/// <summary>
	/// Get the <see cref="T:Common.Logging.ILog" /> for this
	/// class's category.  This should be used by subclasses for logging.
	/// </summary>
	protected ILog Log => log;

	/// <summary>
	/// Get the name of the <see cref="T:Quartz.ITriggerListener" />.
	/// </summary>
	/// <value></value>
	public abstract string Name { get; }

	protected TriggerListenerSupport()
	{
		log = LogManager.GetLogger(GetType());
	}

	public virtual void TriggerFired(ITrigger trigger, IJobExecutionContext context)
	{
	}

	public virtual bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
	{
		return false;
	}

	public virtual void TriggerMisfired(ITrigger trigger)
	{
	}

	public virtual void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
	{
	}
}
