namespace Quartz;

/// <summary>
/// The interface to be implemented by <see cref="T:Quartz.IJob" />s that provide a 
/// mechanism for having their execution interrupted.  It is NOT a requirement
/// for jobs to implement this interface - in fact, for most people, none of
/// their jobs will.
/// </summary>
/// <remarks>
/// <para>
/// The means of actually interrupting the Job must be implemented within the
/// <see cref="T:Quartz.IJob" /> itself (the <see cref="M:Quartz.IInterruptableJob.Interrupt" /> method of this 
/// interface is simply a means for the scheduler to inform the <see cref="T:Quartz.IJob" />
/// that a request has been made for it to be interrupted). The mechanism that
/// your jobs use to interrupt themselves might vary between implementations.
/// However the principle idea in any implementation should be to have the
/// body of the job's <see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> periodically check some flag to
/// see if an interruption has been requested, and if the flag is set, somehow
/// abort the performance of the rest of the job's work.  An example of 
/// interrupting a job can be found in the source for the class Example7's DumbInterruptableJob 
/// It is legal to use
/// some combination of <see cref="M:System.Threading.Monitor.Wait(System.Object)" /> and <see cref="M:System.Threading.Monitor.Pulse(System.Object)" /> 
/// synchronization within <see cref="M:System.Threading.Thread.Interrupt" /> and <see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" />
/// in order to have the <see cref="M:System.Threading.Thread.Interrupt" /> method block until the
/// <see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> signals that it has noticed the set flag.
/// </para>
///
/// <para>
/// If the Job performs some form of blocking I/O or similar functions, you may
/// want to consider having the <see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method store a
/// reference to the calling <see cref="T:System.Threading.Thread" /> as a member variable.  Then the
/// implementation of this interfaces <see cref="M:System.Threading.Thread.Interrupt" /> method can call 
/// <see cref="M:System.Threading.Thread.Interrupt" /> on that Thread.   Before attempting this, make
/// sure that you fully understand what <see cref="M:System.Threading.Thread.Interrupt" /> 
/// does and doesn't do.  Also make sure that you clear the Job's member 
/// reference to the Thread when the Execute(..) method exits (preferably in a
/// <see langword="finally" /> block.
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="M:Quartz.IScheduler.Interrupt(Quartz.JobKey)" />
/// <seealso cref="M:Quartz.IScheduler.Interrupt(System.String)" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IInterruptableJob : IJob
{
	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a user
	/// interrupts the <see cref="T:Quartz.IJob" />.
	/// </summary>
	/// <returns> void (nothing) if job interrupt is successful.</returns>
	void Interrupt();
}
