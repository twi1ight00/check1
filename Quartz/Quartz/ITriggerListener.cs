namespace Quartz;

/// <summary>
/// The interface to be implemented by classes that want to be informed when a
/// <see cref="T:Quartz.ITrigger" /> fires. In general, applications that use a
/// <see cref="T:Quartz.IScheduler" /> will not have use for this mechanism.
/// </summary>
/// <seealso cref="T:Quartz.IListenerManager" />
/// <seealso cref="T:Quartz.IMatcher`1" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <seealso cref="T:Quartz.IJobListener" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ITriggerListener
{
	/// <summary>
	/// Get the name of the <see cref="T:Quartz.ITriggerListener" />.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has fired, and it's associated <see cref="T:Quartz.IJobDetail" />
	/// is about to be executed.
	/// <para>
	/// It is called before the <see cref="M:Quartz.ITriggerListener.VetoJobExecution(Quartz.ITrigger,Quartz.IJobExecutionContext)" /> method of this
	/// interface.
	/// </para>
	/// </summary>
	/// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has fired.</param>
	/// <param name="context">
	///     The <see cref="T:Quartz.IJobExecutionContext" /> that will be passed to the <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.
	/// </param>
	void TriggerFired(ITrigger trigger, IJobExecutionContext context);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has fired, and it's associated <see cref="T:Quartz.IJobDetail" />
	/// is about to be executed.
	/// <para>
	/// It is called after the <see cref="M:Quartz.ITriggerListener.TriggerFired(Quartz.ITrigger,Quartz.IJobExecutionContext)" /> method of this
	/// interface.  If the implementation vetos the execution (via
	/// returning <see langword="true" />), the job's execute method will not be called.
	/// </para>
	/// </summary>
	/// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has fired.</param>
	/// <param name="context">The <see cref="T:Quartz.IJobExecutionContext" /> that will be passed to
	/// the <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.</param>
	/// <returns>Returns true if job execution should be vetoed, false otherwise.</returns>
	bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has misfired.
	/// <para>
	/// Consideration should be given to how much time is spent in this method,
	/// as it will affect all triggers that are misfiring.  If you have lots
	/// of triggers misfiring at once, it could be an issue it this method
	/// does a lot.
	/// </para>
	/// </summary>
	/// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has misfired.</param>
	void TriggerMisfired(ITrigger trigger);

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// has fired, it's associated <see cref="T:Quartz.IJobDetail" />
	/// has been executed, and it's <see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" /> method has been
	/// called.
	/// </summary>
	/// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that was fired.</param>
	/// <param name="context">
	/// The <see cref="T:Quartz.IJobExecutionContext" /> that was passed to the
	/// <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.
	/// </param>
	/// <param name="triggerInstructionCode">
	/// The result of the call on the <see cref="T:Quartz.ITrigger" />'s<see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" />  method.
	/// </param>
	void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode);
}
