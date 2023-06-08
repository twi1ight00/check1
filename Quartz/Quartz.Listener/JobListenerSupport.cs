using Common.Logging;

namespace Quartz.Listener;

/// <summary>
/// A helpful abstract base class for implementors of <see cref="T:Quartz.IJobListener" />.
/// </summary>
/// <remarks>
/// <para>
/// The methods in this class are empty so you only need to override the  
/// subset for the <see cref="T:Quartz.IJobListener" /> events you care about.
/// </para>
///
/// <para>
/// You are required to implement <see cref="P:Quartz.IJobListener.Name" /> 
/// to return the unique name of your <see cref="T:Quartz.IJobListener" />.  
/// </para>
/// </remarks>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.IJobListener" />
public abstract class JobListenerSupport : IJobListener
{
	private readonly ILog log;

	/// <summary>
	/// Get the <see cref="T:Common.Logging.ILog" /> for this  class's category.  
	/// This should be used by subclasses for logging.
	/// </summary>
	protected ILog Log => log;

	/// <summary>
	/// Get the name of the <see cref="T:Quartz.IJobListener" />.
	/// </summary>
	/// <value></value>
	public abstract string Name { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Listener.JobListenerSupport" /> class.
	/// </summary>
	protected JobListenerSupport()
	{
		log = LogManager.GetLogger(GetType());
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// is about to be executed (an associated <see cref="T:Quartz.ITrigger" />
	/// has occured).
	/// <para>
	/// This method will not be invoked if the execution of the Job was vetoed
	/// by a <see cref="T:Quartz.ITriggerListener" />.
	/// </para>
	/// </summary>
	/// <param name="context"></param>
	/// <seealso cref="M:Quartz.Listener.JobListenerSupport.JobExecutionVetoed(Quartz.IJobExecutionContext)" />
	public virtual void JobToBeExecuted(IJobExecutionContext context)
	{
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// was about to be executed (an associated <see cref="T:Quartz.ITrigger" />
	/// has occured), but a <see cref="T:Quartz.ITriggerListener" /> vetoed it's
	/// execution.
	/// </summary>
	/// <param name="context"></param>
	/// <seealso cref="M:Quartz.Listener.JobListenerSupport.JobToBeExecuted(Quartz.IJobExecutionContext)" />
	public virtual void JobExecutionVetoed(IJobExecutionContext context)
	{
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> after a <see cref="T:Quartz.IJobDetail" />
	/// has been executed, and be for the associated <see cref="T:Quartz.ITrigger" />'s
	/// <see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" /> method has been called.
	/// </summary>
	/// <param name="context"></param>
	/// <param name="jobException"></param>
	public virtual void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
	{
	}
}
