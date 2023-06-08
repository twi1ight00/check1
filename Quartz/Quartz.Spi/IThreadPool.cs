namespace Quartz.Spi;

/// <summary>
/// The interface to be implemented by classes that want to provide a thread
/// pool for the <see cref="T:Quartz.IScheduler" />'s use.
/// </summary>
/// <remarks>
/// <see cref="T:Quartz.Spi.IThreadPool" /> implementation instances should ideally be made
/// for the sole use of Quartz.  Most importantly, when the method
///  <see cref="M:Quartz.Spi.IThreadPool.BlockForAvailableThreads" /> returns a value of 1 or greater,
/// there must still be at least one available thread in the pool when the
/// method  <see cref="M:Quartz.Spi.IThreadPool.RunInThread(Quartz.IThreadRunnable)" /> is called a few moments (or
/// many moments) later.  If this assumption does not hold true, it may
/// result in extra JobStore queries and updates, and if clustering features
/// are being used, it may result in greater imballance of load.
/// </remarks>
/// <seealso cref="T:Quartz.Core.QuartzScheduler" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IThreadPool
{
	/// <summary>
	/// Get the current number of threads in the <see cref="T:Quartz.Spi.IThreadPool" />.
	/// </summary>
	int PoolSize { get; }

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IThreadPool" /> of the Scheduler instance's Id, 
	/// prior to initialize being invoked.
	/// </summary>
	string InstanceId { set; }

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IThreadPool" /> of the Scheduler instance's name, 
	/// prior to initialize being invoked.
	/// </summary>
	string InstanceName { set; }

	/// <summary>
	/// Execute the given <see cref="T:Quartz.IThreadRunnable" /> in the next
	/// available <see cref="T:System.Threading.Thread" />.
	/// </summary>
	/// <remarks>
	/// The implementation of this interface should not throw exceptions unless
	/// there is a serious problem (i.e. a serious misconfiguration). If there
	/// are no available threads, rather it should either queue the Runnable, or
	/// block until a thread is available, depending on the desired strategy.
	/// </remarks>
	bool RunInThread(IThreadRunnable runnable);

	/// <summary>
	/// Determines the number of threads that are currently available in in
	/// the pool.  Useful for determining the number of times
	/// <see cref="M:Quartz.Spi.IThreadPool.RunInThread(Quartz.IThreadRunnable)" />  can be called before returning
	/// false.
	/// </summary>
	///             <remarks>
	/// The implementation of this method should block until there is at
	/// least one available thread.
	///             </remarks>
	/// <returns>the number of currently available threads</returns>
	int BlockForAvailableThreads();

	/// <summary>
	/// Must be called before the <see cref="T:System.Threading.ThreadPool" /> is
	/// used, in order to give the it a chance to Initialize.
	/// </summary>
	/// <remarks>
	/// Typically called by the <see cref="T:Quartz.ISchedulerFactory" />.
	/// </remarks>
	void Initialize();

	/// <summary>
	/// Called by the QuartzScheduler to inform the <see cref="T:System.Threading.ThreadPool" />
	/// that it should free up all of it's resources because the scheduler is
	/// shutting down.
	/// </summary>
	void Shutdown(bool waitForJobsToComplete);
}
