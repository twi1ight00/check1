using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Common.Logging;
using Quartz.Core;
using Quartz.Simpl;
using Quartz.Spi;

namespace Quartz.Impl;

/// <summary>
/// A singleton implementation of <see cref="T:Quartz.ISchedulerFactory" />.
/// </summary>
/// <remarks>
/// Here are some examples of using this class:
/// <para>
/// To create a scheduler that does not write anything to the database (is not
/// persistent), you can call <see cref="M:Quartz.Impl.DirectSchedulerFactory.CreateVolatileScheduler(System.Int32)" />:
/// </para>
/// <code>
/// DirectSchedulerFactory.Instance.CreateVolatileScheduler(10); // 10 threads 
/// // don't forget to start the scheduler: 
/// DirectSchedulerFactory.Instance.GetScheduler().Start();
/// </code>
/// <para>
/// Several create methods are provided for convenience. All create methods
/// eventually end up calling the create method with all the parameters:
/// </para>
/// <code>
/// public void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IJobStore jobStore)
/// </code>
/// <para>
/// Here is an example of using this method:
/// </para>
/// <code>
/// // create the thread pool 
/// SimpleThreadPool threadPool = new SimpleThreadPool(maxThreads, ThreadPriority.Normal); 
/// threadPool.Initialize(); 
/// // create the job store 
/// JobStore jobStore = new RAMJobStore(); 
///
/// DirectSchedulerFactory.Instance.CreateScheduler("My Quartz Scheduler", "My Instance", threadPool, jobStore); 
/// // don't forget to start the scheduler: 
/// DirectSchedulerFactory.Instance.GetScheduler("My Quartz Scheduler", "My Instance").Start();
/// </code>
/// </remarks>&gt;
/// <author>Mohammad Rezaei</author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.Spi.IJobStore" />
/// <seealso cref="T:System.Threading.ThreadPool" />
public class DirectSchedulerFactory : ISchedulerFactory
{
	public const string DefaultInstanceId = "SIMPLE_NON_CLUSTERED";

	public const string DefaultSchedulerName = "SimpleQuartzScheduler";

	private const int DefaultBatchMaxSize = 1;

	private readonly ILog log;

	private static readonly DefaultThreadExecutor DefaultThreadExecutor = new DefaultThreadExecutor();

	private readonly TimeSpan DefaultBatchTimeWindow = TimeSpan.Zero;

	private bool initialized;

	private static readonly DirectSchedulerFactory instance = new DirectSchedulerFactory();

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	public ILog Log => log;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static DirectSchedulerFactory Instance => instance;

	/// <summary> <para>
	/// Returns a handle to all known Schedulers (made by any
	/// StdSchedulerFactory instance.).
	/// </para>
	/// </summary>
	public virtual ICollection<IScheduler> AllSchedulers => SchedulerRepository.Instance.LookupAll();

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.DirectSchedulerFactory" /> class.
	/// </summary>
	protected DirectSchedulerFactory()
	{
		log = LogManager.GetLogger(GetType());
	}

	/// <summary>
	/// Creates an in memory job store (<see cref="T:Quartz.Simpl.RAMJobStore" />)
	/// The thread priority is set to Thread.NORM_PRIORITY
	/// </summary>
	/// <param name="maxThreads">The number of threads in the thread pool</param>
	public virtual void CreateVolatileScheduler(int maxThreads)
	{
		SimpleThreadPool threadPool = new SimpleThreadPool(maxThreads, ThreadPriority.Normal);
		threadPool.Initialize();
		IJobStore jobStore = new RAMJobStore();
		CreateScheduler(threadPool, jobStore);
	}

	/// <summary>
	/// Creates a proxy to a remote scheduler. This scheduler can be retrieved
	/// via <see cref="M:Quartz.Impl.DirectSchedulerFactory.GetScheduler" />.
	/// </summary>
	/// <throws>  SchedulerException </throws>
	public virtual void CreateRemoteScheduler(string proxyAddress)
	{
		CreateRemoteScheduler("SimpleQuartzScheduler", "SIMPLE_NON_CLUSTERED", proxyAddress);
	}

	/// <summary>
	/// Same as <see cref="M:Quartz.Impl.DirectSchedulerFactory.CreateRemoteScheduler(System.String)" />,
	/// with the addition of specifying the scheduler name and instance ID. This
	/// scheduler can only be retrieved via <see cref="M:Quartz.Impl.DirectSchedulerFactory.GetScheduler(System.String)" />.
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="proxyAddress"></param>
	/// <throws>  SchedulerException </throws>
	protected virtual void CreateRemoteScheduler(string schedulerName, string schedulerInstanceId, string proxyAddress)
	{
		string uid = QuartzSchedulerResources.GetUniqueIdentifier(schedulerName, schedulerInstanceId);
		RemotingSchedulerProxyFactory proxyBuilder = new RemotingSchedulerProxyFactory();
		proxyBuilder.Address = proxyAddress;
		RemoteScheduler remoteScheduler = new RemoteScheduler(uid, proxyBuilder);
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		schedRep.Bind(remoteScheduler);
		initialized = true;
	}

	/// <summary> 
	/// Creates a scheduler using the specified thread pool and job store. This
	/// scheduler can be retrieved via DirectSchedulerFactory#GetScheduler()
	/// </summary>
	/// <param name="threadPool">
	/// The thread pool for executing jobs
	/// </param>
	/// <param name="jobStore">
	/// The type of job store
	/// </param>
	/// <throws>  SchedulerException </throws>
	/// <summary>           if initialization failed
	/// </summary>
	public virtual void CreateScheduler(IThreadPool threadPool, IJobStore jobStore)
	{
		CreateScheduler("SimpleQuartzScheduler", "SIMPLE_NON_CLUSTERED", threadPool, jobStore);
		initialized = true;
	}

	/// <summary>
	/// Same as DirectSchedulerFactory#createScheduler(ThreadPool threadPool, JobStore jobStore),
	/// with the addition of specifying the scheduler name and instance ID. This
	/// scheduler can only be retrieved via DirectSchedulerFactory#getScheduler(String)
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="threadPool">The thread pool for executing jobs</param>
	/// <param name="jobStore">The type of job store</param>
	public virtual void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IJobStore jobStore)
	{
		CreateScheduler(schedulerName, schedulerInstanceId, threadPool, jobStore, TimeSpan.Zero, TimeSpan.Zero);
	}

	/// <summary>
	/// Creates a scheduler using the specified thread pool and job store and
	/// binds it for remote access.
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="threadPool">The thread pool for executing jobs</param>
	/// <param name="jobStore">The type of job store</param>
	/// <param name="idleWaitTime">The idle wait time. You can specify "-1" for
	/// the default value, which is currently 30000 ms.</param>
	/// <param name="dbFailureRetryInterval">The db failure retry interval.</param>
	public virtual void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IJobStore jobStore, TimeSpan idleWaitTime, TimeSpan dbFailureRetryInterval)
	{
		CreateScheduler(schedulerName, schedulerInstanceId, threadPool, jobStore, null, idleWaitTime, dbFailureRetryInterval);
	}

	/// <summary>
	/// Creates a scheduler using the specified thread pool and job store and
	/// binds it for remote access.
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="threadPool">The thread pool for executing jobs</param>
	/// <param name="jobStore">The type of job store</param>
	/// <param name="schedulerPluginMap"></param>
	/// <param name="idleWaitTime">The idle wait time. You can specify TimeSpan.Zero for
	/// the default value, which is currently 30000 ms.</param>
	/// <param name="dbFailureRetryInterval">The db failure retry interval.</param>
	public virtual void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IJobStore jobStore, IDictionary<string, ISchedulerPlugin> schedulerPluginMap, TimeSpan idleWaitTime, TimeSpan dbFailureRetryInterval)
	{
		CreateScheduler(schedulerName, schedulerInstanceId, threadPool, DefaultThreadExecutor, jobStore, schedulerPluginMap, idleWaitTime, dbFailureRetryInterval);
	}

	/// <summary>
	/// Creates a scheduler using the specified thread pool and job store and
	/// binds it for remote access.
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="threadPool">The thread pool for executing jobs</param>
	/// <param name="threadExecutor">Thread executor.</param>
	/// <param name="jobStore">The type of job store</param>
	/// <param name="schedulerPluginMap"></param>
	/// <param name="idleWaitTime">The idle wait time. You can specify TimeSpan.Zero for
	/// the default value, which is currently 30000 ms.</param>
	/// <param name="dbFailureRetryInterval">The db failure retry interval.</param>
	public virtual void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IThreadExecutor threadExecutor, IJobStore jobStore, IDictionary<string, ISchedulerPlugin> schedulerPluginMap, TimeSpan idleWaitTime, TimeSpan dbFailureRetryInterval)
	{
		CreateScheduler(schedulerName, schedulerInstanceId, threadPool, threadExecutor, jobStore, schedulerPluginMap, idleWaitTime, dbFailureRetryInterval, 1, DefaultBatchTimeWindow);
	}

	/// <summary>
	/// Creates a scheduler using the specified thread pool and job store and
	/// binds it for remote access.
	/// </summary>
	/// <param name="schedulerName">The name for the scheduler.</param>
	/// <param name="schedulerInstanceId">The instance ID for the scheduler.</param>
	/// <param name="threadPool">The thread pool for executing jobs</param>
	/// <param name="threadExecutor">Thread executor.</param>
	/// <param name="jobStore">The type of job store</param>
	/// <param name="schedulerPluginMap"></param>
	/// <param name="idleWaitTime">The idle wait time. You can specify TimeSpan.Zero for
	/// the default value, which is currently 30000 ms.</param>
	/// <param name="dbFailureRetryInterval">The db failure retry interval.</param>
	/// <param name="maxBatchSize">The maximum batch size of triggers, when acquiring them</param>
	/// <param name="batchTimeWindow">The time window for which it is allowed to "pre-acquire" triggers to fire</param>
	public virtual void CreateScheduler(string schedulerName, string schedulerInstanceId, IThreadPool threadPool, IThreadExecutor threadExecutor, IJobStore jobStore, IDictionary<string, ISchedulerPlugin> schedulerPluginMap, TimeSpan idleWaitTime, TimeSpan dbFailureRetryInterval, int maxBatchSize, TimeSpan batchTimeWindow)
	{
		IJobRunShellFactory jrsf = new StdJobRunShellFactory();
		threadPool.Initialize();
		QuartzSchedulerResources qrs = new QuartzSchedulerResources();
		qrs.Name = schedulerName;
		qrs.InstanceId = schedulerInstanceId;
		SchedulerDetailsSetter.SetDetails(threadPool, schedulerName, schedulerInstanceId);
		qrs.JobRunShellFactory = jrsf;
		qrs.ThreadPool = threadPool;
		qrs.ThreadExecutor = threadExecutor;
		qrs.JobStore = jobStore;
		qrs.MaxBatchSize = maxBatchSize;
		qrs.BatchTimeWindow = batchTimeWindow;
		if (schedulerPluginMap != null)
		{
			foreach (ISchedulerPlugin plugin in schedulerPluginMap.Values)
			{
				qrs.AddSchedulerPlugin(plugin);
			}
		}
		QuartzScheduler qs = new QuartzScheduler(qrs, idleWaitTime, dbFailureRetryInterval);
		ITypeLoadHelper cch = new SimpleTypeLoadHelper();
		cch.Initialize();
		SchedulerDetailsSetter.SetDetails(jobStore, schedulerName, schedulerInstanceId);
		jobStore.Initialize(cch, qs.SchedulerSignaler);
		IScheduler scheduler = new StdScheduler(qs);
		jrsf.Initialize(scheduler);
		qs.Initialize();
		if (schedulerPluginMap != null)
		{
			foreach (KeyValuePair<string, ISchedulerPlugin> pluginEntry in schedulerPluginMap)
			{
				pluginEntry.Value.Initialize(pluginEntry.Key, scheduler);
			}
		}
		Log.Info(string.Format(CultureInfo.InvariantCulture, "Quartz scheduler '{0}", new object[1] { scheduler.SchedulerName }));
		Log.Info(string.Format(CultureInfo.InvariantCulture, "Quartz scheduler version: {0}", new object[1] { qs.Version }));
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		qs.AddNoGCObject(schedRep);
		schedRep.Bind(scheduler);
		initialized = true;
	}

	/// <summary>
	/// Returns a handle to the Scheduler produced by this factory.
	/// <para>
	/// you must call createRemoteScheduler or createScheduler methods before
	/// calling getScheduler()
	/// </para>
	/// </summary>
	/// <returns></returns>
	/// <throws>  SchedulerException </throws>
	public virtual IScheduler GetScheduler()
	{
		if (!initialized)
		{
			throw new SchedulerException("you must call createRemoteScheduler or createScheduler methods before calling getScheduler()");
		}
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		return schedRep.Lookup("SimpleQuartzScheduler");
	}

	/// <summary>
	/// Returns a handle to the Scheduler with the given name, if it exists.
	/// </summary>
	public virtual IScheduler GetScheduler(string schedName)
	{
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		return schedRep.Lookup(schedName);
	}
}
