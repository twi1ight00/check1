namespace Quartz;

/// <summary>
/// Instructs Scheduler what to do with a trigger and job.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
public enum SchedulerInstruction
{
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that the <see cref="T:Quartz.ITrigger" />
	/// has no further instructions.
	/// </summary>
	NoInstruction,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that the <see cref="T:Quartz.ITrigger" />
	/// wants the <see cref="T:Quartz.IJobDetail" /> to re-Execute
	/// immediately. If not in a 'RECOVERING' or 'FAILED_OVER' situation, the
	/// execution context will be re-used (giving the <see cref="T:Quartz.IJob" /> the
	/// ability to 'see' anything placed in the context by its last execution).
	/// </summary>      
	ReExecuteJob,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that the <see cref="T:Quartz.ITrigger" />
	/// should be put in the <see cref="F:Quartz.TriggerState.Complete" /> state.
	/// </summary>
	SetTriggerComplete,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that the <see cref="T:Quartz.ITrigger" />
	/// wants itself deleted.
	/// </summary>
	DeleteTrigger,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that all <see cref="T:Quartz.ITrigger" />
	/// s referencing the same <see cref="T:Quartz.IJobDetail" /> as
	/// this one should be put in the <see cref="F:Quartz.TriggerState.Complete" /> state.
	/// </summary>
	SetAllJobTriggersComplete,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that all <see cref="T:Quartz.ITrigger" />
	/// s referencing the same <see cref="T:Quartz.IJobDetail" /> as
	/// this one should be put in the <see cref="F:Quartz.TriggerState.Error" /> state.
	/// </summary>
	SetAllJobTriggersError,
	/// <summary>
	/// Instructs the <see cref="T:Quartz.IScheduler" /> that the <see cref="T:Quartz.ITrigger" />
	/// should be put in the <see cref="F:Quartz.TriggerState.Error" /> state.
	/// </summary>
	SetTriggerError
}
