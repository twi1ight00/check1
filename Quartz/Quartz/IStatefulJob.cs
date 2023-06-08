using System;

namespace Quartz;

/// <summary>
/// A marker interface for <see cref="T:Quartz.IJobDetail" /> s that
/// wish to have their state maintained between executions.
/// </summary>
/// <remarks>
/// <see cref="T:Quartz.IStatefulJob" /> instances follow slightly different rules from
/// regular <see cref="T:Quartz.IJob" /> instances. The key difference is that their
/// associated <see cref="T:Quartz.JobDataMap" /> is re-persisted after every
/// execution of the job, thus preserving state for the next execution. The
/// other difference is that stateful jobs are not allowed to Execute
/// concurrently, which means new triggers that occur before the completion of
/// the <see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method will be delayed.
/// </remarks>
/// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute" />
/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.IJobDetail" />
/// <seealso cref="T:Quartz.JobDataMap" />
/// <seealso cref="T:Quartz.IScheduler" /> 
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Obsolete("Use DisallowConcurrentExecutionAttribute and/or PersistJobDataAfterExecutionAttribute annotations instead.", true)]
public interface IStatefulJob : IJob
{
}
