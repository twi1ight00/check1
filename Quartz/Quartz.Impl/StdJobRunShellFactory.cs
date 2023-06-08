using Quartz.Core;
using Quartz.Spi;

namespace Quartz.Impl;

/// <summary> 
/// Responsible for creating the instances of <see cref="T:Quartz.Core.JobRunShell" />
/// to be used within the <see cref="T:Quartz.Core.QuartzScheduler" /> instance.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class StdJobRunShellFactory : IJobRunShellFactory
{
	private IScheduler scheduler;

	/// <summary>
	/// Initialize the factory, providing a handle to the <see cref="T:Quartz.IScheduler" />
	/// that should be made available within the <see cref="T:Quartz.Core.JobRunShell" /> and
	/// the <see cref="T:Quartz.IJobExecutionContext" /> s within it.
	/// </summary>
	public virtual void Initialize(IScheduler sched)
	{
		scheduler = sched;
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.Core.QuartzSchedulerThread" /> to obtain instances of 
	/// <see cref="T:Quartz.Core.JobRunShell" />.
	/// </summary>
	public virtual JobRunShell CreateJobRunShell(TriggerFiredBundle bndle)
	{
		return new JobRunShell(scheduler, bndle);
	}
}
