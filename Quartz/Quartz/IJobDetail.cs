using System;

namespace Quartz;

/// <summary>
/// Conveys the detail properties of a given job instance. 
/// JobDetails are to be created/defined with <see cref="T:Quartz.JobBuilder" />.
/// </summary>
/// <remarks>
/// Quartz does not store an actual instance of a <see cref="T:Quartz.IJob" /> type, but
/// instead allows you to define an instance of one, through the use of a <see cref="T:Quartz.IJobDetail" />.
/// <para>
/// <see cref="T:Quartz.IJob" />s have a name and group associated with them, which
/// should uniquely identify them within a single <see cref="T:Quartz.IScheduler" />.
/// </para>
/// <para>
/// <see cref="T:Quartz.ITrigger" /> s are the 'mechanism' by which <see cref="T:Quartz.IJob" /> s
/// are scheduled. Many <see cref="T:Quartz.ITrigger" /> s can point to the same <see cref="T:Quartz.IJob" />,
/// but a single <see cref="T:Quartz.ITrigger" /> can only point to one <see cref="T:Quartz.IJob" />.
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute" />
/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
/// <seealso cref="T:Quartz.JobDataMap" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IJobDetail : ICloneable
{
	/// <summary>
	/// The key that identifies this jobs uniquely.
	/// </summary>
	JobKey Key { get; }

	/// <summary>
	/// Get or set the description given to the <see cref="T:Quartz.IJob" /> instance by its
	/// creator (if any).
	/// </summary>
	string Description { get; }

	/// <summary>
	/// Get or sets the instance of <see cref="T:Quartz.IJob" /> that will be executed.
	/// </summary>
	Type JobType { get; }

	/// <summary>
	/// Get or set the <see cref="P:Quartz.IJobDetail.JobDataMap" /> that is associated with the <see cref="T:Quartz.IJob" />.
	/// </summary>
	JobDataMap JobDataMap { get; }

	/// <summary>
	/// Whether or not the <see cref="T:Quartz.IJob" /> should remain stored after it is
	/// orphaned (no <see cref="T:Quartz.ITrigger" />s point to it).
	/// </summary>
	/// <remarks>
	/// If not explicitly set, the default value is <see langword="false" />.
	/// </remarks>
	/// <returns> 
	/// <see langword="true" /> if the Job should remain persisted after being orphaned.
	/// </returns>
	bool Durable { get; }

	/// <summary>
	/// Whether the associated Job class carries the <see cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />.
	/// </summary>
	/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
	bool PersistJobDataAfterExecution { get; }

	/// <summary>
	/// Whether the associated Job class carries the <see cref="T:Quartz.DisallowConcurrentExecutionAttribute" />.
	/// </summary>
	/// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute" />
	bool ConcurrentExecutionDisallowed { get; }

	/// <summary>
	/// Set whether or not the the <see cref="T:Quartz.IScheduler" /> should re-Execute
	/// the <see cref="T:Quartz.IJob" /> if a 'recovery' or 'fail-over' situation is
	/// encountered.
	/// </summary>
	/// <remarks>
	/// If not explicitly set, the default value is <see langword="false" />.
	/// </remarks>
	/// <seealso cref="P:Quartz.IJobExecutionContext.Recovering" />
	bool RequestsRecovery { get; }

	/// <summary>
	/// Get a <see cref="T:Quartz.JobBuilder" /> that is configured to produce a 
	/// <see cref="T:Quartz.IJobDetail" /> identical to this one.
	/// </summary>
	JobBuilder GetJobBuilder();
}
