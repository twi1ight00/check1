namespace Quartz;

/// <summary>
/// The interface to be implemented by classes that want to be informed when a
/// <see cref="T:Quartz.IJobDetail" /> executes. In general,  applications that use a 
/// <see cref="T:Quartz.IScheduler" /> will not have use for this mechanism.
/// </summary>
/// <seealso cref="M:Quartz.IListenerManager.AddJobListener(Quartz.IJobListener,System.Collections.Generic.IList{Quartz.IMatcher{Quartz.JobKey}})" />
/// <seealso cref="T:Quartz.IMatcher`1" />
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <seealso cref="T:Quartz.JobExecutionException" />
/// <seealso cref="T:Quartz.ITriggerListener" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IJobListener
{
	/// <summary>
	/// Get the name of the <see cref="T:Quartz.IJobListener" />.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// is about to be executed (an associated <see cref="T:Quartz.ITrigger" />
	/// has occurred).
	/// <para>
	/// This method will not be invoked if the execution of the Job was vetoed
	/// by a <see cref="T:Quartz.ITriggerListener" />.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.IJobListener.JobExecutionVetoed(Quartz.IJobExecutionContext)" />
	void JobToBeExecuted(IJobExecutionContext context);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
	/// was about to be executed (an associated <see cref="T:Quartz.ITrigger" />
	/// has occurred), but a <see cref="T:Quartz.ITriggerListener" /> vetoed it's 
	/// execution.
	/// </summary>
	/// <seealso cref="M:Quartz.IJobListener.JobToBeExecuted(Quartz.IJobExecutionContext)" />
	void JobExecutionVetoed(IJobExecutionContext context);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> after a <see cref="T:Quartz.IJobDetail" />
	/// has been executed, and be for the associated <see cref="T:Quartz.Spi.IOperableTrigger" />'s
	/// <see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" /> method has been called.
	/// </summary>
	void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException);
}
