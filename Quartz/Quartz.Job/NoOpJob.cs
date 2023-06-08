namespace Quartz.Job;

/// <summary>
/// An implementation of Job, that does absolutely nothing - useful for system
/// which only wish to use <see cref="T:Quartz.ITriggerListener" />s
/// and <see cref="T:Quartz.IJobListener" />s, rather than writing
/// Jobs that perform work.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class NoOpJob : IJob
{
	/// <summary>
	/// Do nothing.
	/// </summary>
	public void Execute(IJobExecutionContext context)
	{
	}
}
