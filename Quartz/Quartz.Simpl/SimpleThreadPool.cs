using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// This is class is a simple implementation of a thread pool, based on the
/// <see cref="T:Quartz.Spi.IThreadPool" /> interface.
/// </summary>
/// <remarks>
/// <see cref="T:Quartz.IThreadRunnable" /> objects are sent to the pool with the <see cref="M:Quartz.Simpl.SimpleThreadPool.RunInThread(Quartz.IThreadRunnable)" />
/// method, which blocks until a <see cref="T:System.Threading.Thread" /> becomes available.
///
/// The pool has a fixed number of <see cref="T:System.Threading.Thread" />s, and does not grow or
/// shrink based on demand.
/// </remarks>
/// <author>James House</author>
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
public class SimpleThreadPool : IThreadPool
{
	/// <summary>
	/// A Worker loops, waiting to Execute tasks.
	/// </summary>
	protected class WorkerThread : QuartzThread
	{
		private volatile bool run = true;

		private IThreadRunnable runnable;

		private readonly SimpleThreadPool tp;

		private readonly bool runOnce;

		/// <summary>
		/// Create a worker thread and start it. Waiting for the next Runnable,
		/// executing it, and waiting for the next Runnable, until the Shutdown
		/// flag is set.
		/// </summary>
		internal WorkerThread(SimpleThreadPool tp, string name, ThreadPriority prio, bool isDaemon)
			: this(tp, name, prio, isDaemon, null)
		{
		}

		/// <summary>
		/// Create a worker thread, start it, Execute the runnable and terminate
		/// the thread (one time execution).
		/// </summary>
		internal WorkerThread(SimpleThreadPool tp, string name, ThreadPriority prio, bool isDaemon, IThreadRunnable runnable)
			: base(name)
		{
			this.tp = tp;
			this.runnable = runnable;
			if (runnable != null)
			{
				runOnce = true;
			}
			base.Priority = prio;
			base.IsBackground = isDaemon;
		}

		/// <summary>
		/// Signal the thread that it should terminate.
		/// </summary>
		internal virtual void Shutdown()
		{
			run = false;
		}

		public void Run(IThreadRunnable newRunnable)
		{
			lock (this)
			{
				if (runnable != null)
				{
					throw new ArgumentException("Already running a Runnable!");
				}
				runnable = newRunnable;
				Monitor.PulseAll(this);
			}
		}

		/// <summary>
		/// Loop, executing targets as they are received.
		/// </summary>
		public override void Run()
		{
			bool ran = false;
			while (run)
			{
				try
				{
					lock (this)
					{
						while (runnable == null && run)
						{
							Monitor.Wait(this, 500);
						}
						if (runnable != null)
						{
							ran = true;
							runnable.Run();
						}
					}
				}
				catch (Exception exceptionInRunnable)
				{
					log.Error("Error while executing the Runnable: ", exceptionInRunnable);
				}
				finally
				{
					lock (this)
					{
						runnable = null;
					}
					base.Priority = tp.ThreadPriority;
					if (runOnce)
					{
						run = false;
						tp.ClearFromBusyWorkersList(this);
					}
					else if (ran)
					{
						ran = false;
						tp.MakeAvailable(this);
					}
				}
			}
			log.Debug("WorkerThread is shut down");
		}
	}

	private const int DefaultThreadPoolSize = 10;

	private static readonly ILog log = LogManager.GetLogger(typeof(SimpleThreadPool));

	private readonly object nextRunnableLock = new object();

	private readonly LinkedList<WorkerThread> availWorkers = new LinkedList<WorkerThread>();

	private readonly LinkedList<WorkerThread> busyWorkers = new LinkedList<WorkerThread>();

	private int count = 10;

	private bool handoffPending;

	private bool isShutdown;

	private ThreadPriority prio = ThreadPriority.Normal;

	private string threadNamePrefix;

	private readonly string schedulerInstanceName;

	private List<WorkerThread> workers;

	/// <summary>
	/// Gets or sets the number of worker threads in the pool.
	/// Set  has no effect after <see cref="M:Quartz.Simpl.SimpleThreadPool.Initialize" /> has been called.
	/// </summary>
	public int ThreadCount
	{
		get
		{
			return count;
		}
		set
		{
			count = value;
		}
	}

	/// <summary>
	/// Get or set the thread priority of worker threads in the pool.
	/// Set operation has no effect after <see cref="M:Quartz.Simpl.SimpleThreadPool.Initialize" /> has been called.
	/// </summary>
	public ThreadPriority ThreadPriority
	{
		get
		{
			return prio;
		}
		set
		{
			prio = value;
		}
	}

	/// <summary>
	/// Gets or sets the thread name prefix.
	/// </summary>
	/// <value>The thread name prefix.</value>
	public virtual string ThreadNamePrefix
	{
		get
		{
			if (threadNamePrefix == null)
			{
				threadNamePrefix = schedulerInstanceName + "-SimpleThreadPoolWorker";
			}
			return threadNamePrefix;
		}
		set
		{
			threadNamePrefix = value;
		}
	}

	/// <summary> 
	/// Gets or sets the value of makeThreadsDaemons.
	/// </summary>
	public virtual bool MakeThreadsDaemons { get; set; }

	/// <summary>
	/// Gets the size of the pool.
	/// </summary>
	/// <value>The size of the pool.</value>
	public virtual int PoolSize => ThreadCount;

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IThreadPool" /> of the Scheduler instance's Id, 
	/// prior to initialize being invoked.
	/// </summary>
	public virtual string InstanceId
	{
		set
		{
		}
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IThreadPool" /> of the Scheduler instance's name, 
	/// prior to initialize being invoked.
	/// </summary>
	public virtual string InstanceName
	{
		set
		{
		}
	}

	/// <summary> 
	/// Create a new (unconfigured) <see cref="T:Quartz.Simpl.SimpleThreadPool" />.
	/// </summary>
	public SimpleThreadPool()
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Quartz.Simpl.SimpleThreadPool" /> with the specified number
	/// of <see cref="T:System.Threading.Thread" /> s that have the given priority.
	/// </summary>
	/// <param name="threadCount">
	/// the number of worker <see cref="T:System.Threading.Thread" />s in the pool, must
	/// be &gt; 0.
	/// </param>
	/// <param name="threadPriority">
	/// the thread priority for the worker threads.
	///
	/// </param>
	public SimpleThreadPool(int threadCount, ThreadPriority threadPriority)
	{
		ThreadCount = threadCount;
		ThreadPriority = threadPriority;
	}

	/// <summary>
	/// Called by the QuartzScheduler before the <see cref="T:System.Threading.ThreadPool" /> is
	/// used, in order to give the it a chance to Initialize.
	/// </summary>
	public virtual void Initialize()
	{
		if (workers != null && workers.Count > 0)
		{
			return;
		}
		if (count <= 0)
		{
			throw new SchedulerConfigException("Thread count must be > 0");
		}
		foreach (WorkerThread wt in CreateWorkerThreads(count))
		{
			wt.Start();
			availWorkers.AddLast(wt);
		}
	}

	/// <summary>
	/// Terminate any worker threads in this thread group.
	/// Jobs currently in progress will complete.
	/// </summary>
	public virtual void Shutdown(bool waitForJobsToComplete)
	{
		lock (nextRunnableLock)
		{
			log.Debug("Shutting down threadpool...");
			isShutdown = true;
			if (workers == null)
			{
				return;
			}
			foreach (WorkerThread worker in workers)
			{
				worker?.Shutdown();
			}
			Monitor.PulseAll(nextRunnableLock);
			if (waitForJobsToComplete)
			{
				while (handoffPending)
				{
					try
					{
						Monitor.Wait(nextRunnableLock, 100);
					}
					catch (ThreadInterruptedException)
					{
					}
				}
				while (busyWorkers.Count > 0)
				{
					LinkedListNode<WorkerThread> wt = busyWorkers.First;
					try
					{
						log.DebugFormat(CultureInfo.InvariantCulture, "Waiting for thread {0} to shut down", wt.Value.Name);
						Monitor.Wait(nextRunnableLock, 2000);
					}
					catch (ThreadInterruptedException)
					{
					}
				}
				while (workers.Count > 0)
				{
					int index = workers.Count - 1;
					WorkerThread wt2 = workers[index];
					try
					{
						wt2.Join();
						workers.RemoveAt(index);
					}
					catch (ThreadStateException)
					{
					}
				}
				log.Debug("No executing jobs remaining, all threads stopped.");
			}
			log.Debug("Shutdown of threadpool complete.");
		}
	}

	/// <summary>
	/// Run the given <see cref="T:Quartz.IThreadRunnable" /> object in the next available
	/// <see cref="T:System.Threading.Thread" />. If while waiting the thread pool is asked to
	/// shut down, the Runnable is executed immediately within a new additional
	/// thread.
	/// </summary>
	/// <param name="runnable">The <see cref="T:Quartz.IThreadRunnable" /> to be added.</param>
	public virtual bool RunInThread(IThreadRunnable runnable)
	{
		if (runnable == null)
		{
			return false;
		}
		lock (nextRunnableLock)
		{
			handoffPending = true;
			while (availWorkers.Count < 1 && !isShutdown)
			{
				try
				{
					Monitor.Wait(nextRunnableLock, 500);
				}
				catch (ThreadInterruptedException)
				{
				}
			}
			if (!isShutdown)
			{
				WorkerThread wt2 = availWorkers.First.Value;
				availWorkers.RemoveFirst();
				busyWorkers.AddLast(wt2);
				wt2.Run(runnable);
			}
			else
			{
				WorkerThread wt = new WorkerThread(this, "WorkerThread-LastJob", prio, MakeThreadsDaemons, runnable);
				busyWorkers.AddLast(wt);
				workers.Add(wt);
				wt.Start();
			}
			Monitor.PulseAll(nextRunnableLock);
			handoffPending = false;
		}
		return true;
	}

	public int BlockForAvailableThreads()
	{
		lock (nextRunnableLock)
		{
			while ((availWorkers.Count < 1 || handoffPending) && !isShutdown)
			{
				try
				{
					Monitor.Wait(nextRunnableLock, 500);
				}
				catch (ThreadInterruptedException)
				{
				}
			}
			return availWorkers.Count;
		}
	}

	protected void MakeAvailable(WorkerThread wt)
	{
		lock (nextRunnableLock)
		{
			if (!isShutdown)
			{
				availWorkers.AddLast(wt);
			}
			busyWorkers.Remove(wt);
			Monitor.PulseAll(nextRunnableLock);
		}
	}

	/// <summary>
	/// Creates the worker threads.
	/// </summary>
	/// <param name="threadCount">The thread count.</param>
	/// <returns></returns>
	protected virtual IList<WorkerThread> CreateWorkerThreads(int threadCount)
	{
		workers = new List<WorkerThread>();
		for (int i = 1; i <= threadCount; i++)
		{
			WorkerThread wt = new WorkerThread(this, string.Format(CultureInfo.InvariantCulture, "{0}-{1}", new object[2] { ThreadNamePrefix, i }), ThreadPriority, MakeThreadsDaemons);
			workers.Add(wt);
		}
		return workers;
	}

	/// <summary>
	/// Terminate any worker threads in this thread group.
	/// Jobs currently in progress will complete.
	/// </summary>
	public virtual void Shutdown()
	{
		Shutdown(waitForJobsToComplete: true);
	}

	protected virtual void ClearFromBusyWorkersList(WorkerThread wt)
	{
		lock (nextRunnableLock)
		{
			busyWorkers.Remove(wt);
			Monitor.PulseAll(nextRunnableLock);
		}
	}
}
