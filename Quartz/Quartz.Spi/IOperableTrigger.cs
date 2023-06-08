using System;

namespace Quartz.Spi;

/// <summary>
/// Internal interface for managing triggers. This interface should not be used by the Quartz client.
/// </summary>
public interface IOperableTrigger : IMutableTrigger, ITrigger, ICloneable, IComparable<ITrigger>
{
	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Usable by <see cref="T:Quartz.Spi.IJobStore" />
	/// implementations, in order to facilitate 'recognizing' instances of fired
	/// <see cref="T:Quartz.ITrigger" /> s as their jobs complete execution.
	/// </remarks>
	string FireInstanceId { get; set; }

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Called when the <see cref="T:Quartz.IScheduler" /> has decided to 'fire'
	/// the trigger (Execute the associated <see cref="T:Quartz.IJob" />), in order to
	/// give the <see cref="T:Quartz.ITrigger" /> a chance to update itself for its next
	/// triggering (if any).
	/// </remarks>
	/// <seealso cref="T:Quartz.JobExecutionException" />
	void Triggered(ICalendar calendar);

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Called by the scheduler at the time a <see cref="T:Quartz.ITrigger" /> is first
	/// added to the scheduler, in order to have the <see cref="T:Quartz.ITrigger" />
	/// compute its first fire time, based on any associated calendar.
	/// </para>
	///
	/// <para>
	/// After this method has been called, <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" />
	/// should return a valid answer.
	/// </para>
	/// </remarks>
	/// <returns> 
	/// The first time at which the <see cref="T:Quartz.ITrigger" /> will be fired
	/// by the scheduler, which is also the same value <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" />
	/// will return (until after the first firing of the <see cref="T:Quartz.ITrigger" />).
	/// </returns>     
	DateTimeOffset? ComputeFirstFireTimeUtc(ICalendar calendar);

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Called after the <see cref="T:Quartz.IScheduler" /> has executed the
	/// <see cref="T:Quartz.IJobDetail" /> associated with the <see cref="T:Quartz.ITrigger" />
	/// in order to get the final instruction code from the trigger.
	/// </remarks>
	/// <param name="context">
	/// is the <see cref="T:Quartz.IJobExecutionContext" /> that was used by the
	/// <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.</param>
	/// <param name="result">is the <see cref="T:Quartz.JobExecutionException" /> thrown by the
	/// <see cref="T:Quartz.IJob" />, if any (may be null).
	/// </param>
	/// <returns>
	/// One of the <see cref="T:Quartz.SchedulerInstruction" /> members.
	/// </returns>
	/// <seealso cref="F:Quartz.SchedulerInstruction.NoInstruction" />
	/// <seealso cref="F:Quartz.SchedulerInstruction.ReExecuteJob" />
	/// <seealso cref="F:Quartz.SchedulerInstruction.DeleteTrigger" />
	/// <seealso cref="F:Quartz.SchedulerInstruction.SetTriggerComplete" />
	/// <seealso cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" />
	SchedulerInstruction ExecutionComplete(IJobExecutionContext context, JobExecutionException result);

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// <para>
	/// To be implemented by the concrete classes that extend this class.
	/// </para>
	/// <para>
	/// The implementation should update the <see cref="T:Quartz.ITrigger" />'s state
	/// based on the MISFIRE_INSTRUCTION_XXX that was selected when the <see cref="T:Quartz.ITrigger" />
	/// was created.
	/// </para>
	/// </summary>
	void UpdateAfterMisfire(ICalendar cal);

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// <para>
	/// The implementation should update the <see cref="T:Quartz.ITrigger" />'s state
	/// based on the given new version of the associated <see cref="T:Quartz.ICalendar" />
	/// (the state should be updated so that it's next fire time is appropriate
	/// given the Calendar's new settings). 
	/// </para>
	/// </summary>
	/// <param name="cal"> </param>
	/// <param name="misfireThreshold"></param>
	void UpdateWithNewCalendar(ICalendar cal, TimeSpan misfireThreshold);

	/// <summary>
	/// Validates whether the properties of the <see cref="T:Quartz.IJobDetail" /> are
	/// valid for submission into a <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	void Validate();

	void SetNextFireTimeUtc(DateTimeOffset? value);

	void SetPreviousFireTimeUtc(DateTimeOffset? value);
}
