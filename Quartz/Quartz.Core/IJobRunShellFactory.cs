using Quartz.Spi;

namespace Quartz.Core;

/// <summary>
/// Responsible for creating the instances of <see cref="T:Quartz.Core.JobRunShell" />
/// to be used within the <see cref="T:Quartz.Core.QuartzScheduler" /> instance.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IJobRunShellFactory
{
	/// <summary>
	/// Initialize the factory, providing a handle to the <see cref="T:Quartz.IScheduler" />
	/// that should be made available within the <see cref="T:Quartz.Core.JobRunShell" /> and 
	/// the <see cref="T:Quartz.IJobExecutionContext" />s within it.
	/// </summary>
	void Initialize(IScheduler sched);

	/// <summary>
	/// Called by the <see cref="T:Quartz.Core.QuartzSchedulerThread" />
	/// to obtain instances of <see cref="T:Quartz.Core.JobRunShell" />.
	/// </summary>
	JobRunShell CreateJobRunShell(TriggerFiredBundle bndle);
}
