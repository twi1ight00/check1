using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using Quartz.Job;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Contains base functionality for ADO.NET-based JobStore implementations.
/// </summary>
/// <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public abstract class JobStoreSupport : AdoConstants, IJobStore
{
	private class NoOpJobTypeLoader : ITypeLoadHelper
	{
		public void Initialize()
		{
		}

		public Type LoadType(string name)
		{
			return typeof(NoOpJob);
		}

		public Uri GetResource(string name)
		{
			return null;
		}

		public Stream GetResourceAsStream(string name)
		{
			return null;
		}
	}

	internal class ClusterManager : QuartzThread
	{
		private readonly JobStoreSupport jobStoreSupport;

		private volatile bool shutdown;

		private int numFails;

		internal ClusterManager(JobStoreSupport jobStoreSupport)
		{
			this.jobStoreSupport = jobStoreSupport;
			base.Priority = ThreadPriority.AboveNormal;
			base.Name = $"QuartzScheduler_{jobStoreSupport.instanceName}-{jobStoreSupport.instanceId}_ClusterManager";
			base.IsBackground = jobStoreSupport.MakeThreadsDaemons;
		}

		public virtual void Initialize()
		{
			Manage();
			IThreadExecutor executor = jobStoreSupport.ThreadExecutor;
			executor.Execute(this);
		}

		public virtual void Shutdown()
		{
			shutdown = true;
			Interrupt();
		}

		private bool Manage()
		{
			bool res = false;
			try
			{
				res = jobStoreSupport.DoCheckin();
				numFails = 0;
				jobStoreSupport.Log.Debug("ClusterManager: Check-in complete.");
			}
			catch (Exception e)
			{
				if (numFails % 4 == 0)
				{
					jobStoreSupport.Log.Error("ClusterManager: Error managing cluster: " + e.Message, e);
				}
				numFails++;
			}
			return res;
		}

		public override void Run()
		{
			while (!shutdown)
			{
				if (!shutdown)
				{
					TimeSpan timeToSleep = jobStoreSupport.ClusterCheckinInterval;
					TimeSpan transpiredTime = SystemTime.UtcNow() - jobStoreSupport.lastCheckin;
					timeToSleep -= transpiredTime;
					if (timeToSleep <= TimeSpan.Zero)
					{
						timeToSleep = TimeSpan.FromMilliseconds(100.0);
					}
					if (numFails > 0)
					{
						timeToSleep = ((jobStoreSupport.DbRetryInterval > timeToSleep) ? jobStoreSupport.DbRetryInterval : timeToSleep);
					}
					try
					{
						Thread.Sleep(timeToSleep);
					}
					catch (ThreadInterruptedException)
					{
					}
					if (!shutdown && Manage())
					{
						jobStoreSupport.SignalSchedulingChangeImmediately(null);
					}
				}
			}
		}
	}

	internal class MisfireHandler : QuartzThread
	{
		private readonly JobStoreSupport jobStoreSupport;

		private volatile bool shutdown;

		private int numFails;

		internal MisfireHandler(JobStoreSupport jobStoreSupport)
		{
			this.jobStoreSupport = jobStoreSupport;
			base.Name = string.Format(CultureInfo.InvariantCulture, "QuartzScheduler_{0}-{1}_MisfireHandler", new object[2] { jobStoreSupport.instanceName, jobStoreSupport.instanceId });
			base.IsBackground = jobStoreSupport.MakeThreadsDaemons;
		}

		public virtual void Initialize()
		{
			IThreadExecutor executor = jobStoreSupport.ThreadExecutor;
			executor.Execute(this);
		}

		public virtual void Shutdown()
		{
			shutdown = true;
			Interrupt();
		}

		private RecoverMisfiredJobsResult Manage()
		{
			try
			{
				jobStoreSupport.Log.Debug("MisfireHandler: scanning for misfires...");
				RecoverMisfiredJobsResult res = jobStoreSupport.DoRecoverMisfires();
				numFails = 0;
				return res;
			}
			catch (Exception e)
			{
				if (numFails % 4 == 0)
				{
					jobStoreSupport.Log.Error("MisfireHandler: Error handling misfires: " + e.Message, e);
				}
				numFails++;
			}
			return RecoverMisfiredJobsResult.NoOp;
		}

		public override void Run()
		{
			while (!shutdown)
			{
				DateTimeOffset sTime = SystemTime.UtcNow();
				RecoverMisfiredJobsResult recoverMisfiredJobsResult = Manage();
				if (recoverMisfiredJobsResult.ProcessedMisfiredTriggerCount > 0)
				{
					jobStoreSupport.SignalSchedulingChangeImmediately(recoverMisfiredJobsResult.EarliestNewTime);
				}
				if (shutdown)
				{
					continue;
				}
				TimeSpan timeToSleep = TimeSpan.FromMilliseconds(50.0);
				if (!recoverMisfiredJobsResult.HasMoreMisfiredTriggers)
				{
					timeToSleep = jobStoreSupport.MisfireThreshold - (SystemTime.UtcNow() - sTime);
					if (timeToSleep <= TimeSpan.Zero)
					{
						timeToSleep = TimeSpan.FromMilliseconds(50.0);
					}
					if (numFails > 0)
					{
						timeToSleep = ((jobStoreSupport.DbRetryInterval > timeToSleep) ? jobStoreSupport.DbRetryInterval : timeToSleep);
					}
				}
				try
				{
					Thread.Sleep(timeToSleep);
				}
				catch (ThreadInterruptedException)
				{
				}
			}
		}
	}

	/// <summary>
	/// Helper class for returning the composite result of trying
	/// to recover misfired jobs.
	/// </summary>
	public class RecoverMisfiredJobsResult
	{
		public static readonly RecoverMisfiredJobsResult NoOp = new RecoverMisfiredJobsResult(hasMoreMisfiredTriggers: false, 0, DateTimeOffset.MaxValue);

		private readonly bool hasMoreMisfiredTriggers;

		private readonly int processedMisfiredTriggerCount;

		private readonly DateTimeOffset earliestNewTimeUtc;

		/// <summary>
		/// Gets a value indicating whether this instance has more misfired triggers.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has more misfired triggers; otherwise, <c>false</c>.
		/// </value>
		public bool HasMoreMisfiredTriggers => hasMoreMisfiredTriggers;

		/// <summary>
		/// Gets the processed misfired trigger count.
		/// </summary>
		/// <value>The processed misfired trigger count.</value>
		public int ProcessedMisfiredTriggerCount => processedMisfiredTriggerCount;

		public DateTimeOffset EarliestNewTime => earliestNewTimeUtc;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.JobStoreSupport.RecoverMisfiredJobsResult" /> class.
		/// </summary>
		/// <param name="hasMoreMisfiredTriggers">if set to <c>true</c> [has more misfired triggers].</param>
		/// <param name="processedMisfiredTriggerCount">The processed misfired trigger count.</param>
		/// <param name="earliestNewTimeUtc"></param>
		public RecoverMisfiredJobsResult(bool hasMoreMisfiredTriggers, int processedMisfiredTriggerCount, DateTimeOffset earliestNewTimeUtc)
		{
			this.hasMoreMisfiredTriggers = hasMoreMisfiredTriggers;
			this.processedMisfiredTriggerCount = processedMisfiredTriggerCount;
			this.earliestNewTimeUtc = earliestNewTimeUtc;
		}
	}

	protected const string LockTriggerAccess = "TRIGGER_ACCESS";

	protected const string LockStateAccess = "STATE_ACCESS";

	private const string KeySignalChangeForTxCompletion = "sigChangeForTxCompletion";

	private string dataSource;

	private string tablePrefix = "QRTZ_";

	private bool useProperties;

	private string instanceId;

	private string instanceName;

	protected string delegateTypeName;

	protected Type delegateType;

	protected readonly Dictionary<string, ICalendar> calendarCache = new Dictionary<string, ICalendar>();

	private IDriverDelegate driverDelegate;

	private TimeSpan misfireThreshold = TimeSpan.FromMinutes(1.0);

	private bool lockOnInsert = true;

	private ClusterManager clusterManagementThread;

	private MisfireHandler misfireHandler;

	private ITypeLoadHelper typeLoadHelper;

	private ISchedulerSignaler schedSignaler;

	private readonly ILog log;

	private IObjectSerializer objectSerializer;

	private IThreadExecutor threadExecutor = new DefaultThreadExecutor();

	private bool schedulerRunning;

	private IDbConnectionManager connectionManager = DBConnectionManager.Instance;

	private static long ftrCtr = SystemTime.UtcNow().Ticks;

	protected bool firstCheckIn = true;

	protected DateTimeOffset lastCheckin = SystemTime.UtcNow();

	/// <summary> 
	/// Get or set the datasource name.
	/// </summary>
	public virtual string DataSource
	{
		get
		{
			return dataSource;
		}
		set
		{
			dataSource = value;
		}
	}

	/// <summary> 
	/// Get or set the database connection manager.
	/// </summary>
	public virtual IDbConnectionManager ConnectionManager
	{
		get
		{
			return connectionManager;
		}
		set
		{
			connectionManager = value;
		}
	}

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	/// <summary> 
	/// Get or sets the prefix that should be pre-pended to all table names.
	/// </summary>
	public virtual string TablePrefix
	{
		get
		{
			return tablePrefix;
		}
		set
		{
			if (value == null)
			{
				value = "";
			}
			tablePrefix = value;
		}
	}

	/// <summary>
	/// Set whether string-only properties will be handled in JobDataMaps.
	/// </summary>
	public virtual string UseProperties
	{
		set
		{
			if (value == null)
			{
				value = "false";
			}
			useProperties = bool.Parse(value);
		}
	}

	/// <summary>
	/// Get or set the instance Id of the Scheduler (must be unique within a cluster).
	/// </summary>
	public virtual string InstanceId
	{
		get
		{
			return instanceId;
		}
		set
		{
			instanceId = value;
		}
	}

	/// <summary>
	/// Get or set the instance Id of the Scheduler (must be unique within this server instance).
	/// </summary>
	public virtual string InstanceName
	{
		get
		{
			return instanceName;
		}
		set
		{
			instanceName = value;
		}
	}

	public int ThreadPoolSize
	{
		set
		{
		}
	}

	public IThreadExecutor ThreadExecutor
	{
		get
		{
			return threadExecutor;
		}
		set
		{
			threadExecutor = value;
		}
	}

	public IObjectSerializer ObjectSerializer
	{
		set
		{
			objectSerializer = value;
		}
	}

	public virtual long EstimatedTimeToReleaseAndAcquireTrigger => 70L;

	/// <summary> 
	/// Get or set whether this instance is part of a cluster.
	/// </summary>
	public virtual bool Clustered { get; set; }

	/// <summary>
	/// Get or set the frequency at which this instance "checks-in"
	/// with the other instances of the cluster. -- Affects the rate of
	/// detecting failed instances.
	/// </summary>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	public virtual TimeSpan ClusterCheckinInterval { get; set; }

	/// <summary>
	/// Get or set the maximum number of misfired triggers that the misfire handling
	/// thread will try to recover at one time (within one transaction).  The
	/// default is 20.
	/// </summary>
	public virtual int MaxMisfiresToHandleAtATime { get; set; }

	/// <summary>
	/// Gets or sets the database retry interval.
	/// </summary>
	/// <value>The db retry interval.</value>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	public virtual TimeSpan DbRetryInterval { get; set; }

	/// <summary>
	/// Get or set whether this instance should use database-based thread
	/// synchronization.
	/// </summary>
	public virtual bool UseDBLocks { get; set; }

	/// <summary> 
	/// Whether or not to obtain locks when inserting new jobs/triggers.  
	/// Defaults to <see langword="true" />, which is safest - some db's (such as 
	/// MS SQLServer) seem to require this to avoid deadlocks under high load,
	/// while others seem to do fine without.  
	/// </summary>
	/// <remarks>
	/// Setting this property to <see langword="false" /> will provide a 
	/// significant performance increase during the addition of new jobs 
	/// and triggers.
	/// </remarks>
	public virtual bool LockOnInsert
	{
		get
		{
			return lockOnInsert;
		}
		set
		{
			lockOnInsert = value;
		}
	}

	/// <summary> 
	/// The time span by which a trigger must have missed its
	/// next-fire-time, in order for it to be considered "misfired" and thus
	/// have its misfire instruction applied.
	/// </summary>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	public virtual TimeSpan MisfireThreshold
	{
		get
		{
			return misfireThreshold;
		}
		set
		{
			if (value.TotalMilliseconds < 1.0)
			{
				throw new ArgumentException("MisfireThreshold must be larger than 0");
			}
			misfireThreshold = value;
		}
	}

	/// <summary> 
	/// Don't call set autocommit(false) on connections obtained from the
	/// DataSource. This can be helpfull in a few situations, such as if you
	/// have a driver that complains if it is called when it is already off.
	/// </summary>
	public virtual bool DontSetAutoCommitFalse { get; set; }

	/// <summary> 
	/// Set the transaction isolation level of DB connections to sequential.
	/// </summary>
	public virtual bool TxIsolationLevelSerializable { get; set; }

	/// <summary>
	/// Whether or not the query and update to acquire a Trigger for firing
	/// should be performed after obtaining an explicit DB lock (to avoid 
	/// possible race conditions on the trigger's db row).  This is
	/// is considered unnecessary for most databases (due to the nature of
	///  the SQL update that is performed), and therefore a superfluous performance hit.
	/// </summary>
	/// <remarks>
	/// However, if batch acquisition is used, it is important for this behavior 
	/// to be used for all dbs.
	/// </remarks>
	public bool AcquireTriggersWithinLock { get; set; }

	/// <summary> 
	/// Get or set the ADO.NET driver delegate class name.
	/// </summary>
	public virtual string DriverDelegateType
	{
		get
		{
			return delegateTypeName;
		}
		set
		{
			lock (this)
			{
				delegateTypeName = value;
			}
		}
	}

	/// <summary>
	/// The driver delegate's initialization string.
	/// </summary>
	public string DriverDelegateInitString { get; set; }

	/// <summary>
	/// set the SQL statement to use to select and lock a row in the "locks"
	/// table.
	/// </summary>
	/// <seealso cref="T:Quartz.Impl.AdoJobStore.StdRowLockSemaphore" />
	public virtual string SelectWithLockSQL { get; set; }

	protected virtual ITypeLoadHelper TypeLoadHelper => typeLoadHelper;

	/// <summary>
	/// Get whether the threads spawned by this JobStore should be
	/// marked as daemon.  Possible threads include the <see cref="T:Quartz.Impl.AdoJobStore.JobStoreSupport.MisfireHandler" /> 
	/// and the <see cref="T:Quartz.Impl.AdoJobStore.JobStoreSupport.ClusterManager" />.
	/// </summary>
	/// <returns></returns>
	public bool MakeThreadsDaemons { get; set; }

	/// <summary>
	/// Get whether to check to see if there are Triggers that have misfired
	/// before actually acquiring the lock to recover them.  This should be 
	/// set to false if the majority of the time, there are are misfired
	/// Triggers.
	/// </summary>
	/// <returns></returns>
	public bool DoubleCheckLockMisfireHandler { get; set; }

	protected DbMetadata DbMetadata => ConnectionManager.GetDbMetadata(DataSource);

	protected virtual DateTimeOffset MisfireTime
	{
		get
		{
			DateTimeOffset misfireTime = SystemTime.UtcNow();
			if (MisfireThreshold > TimeSpan.Zero)
			{
				misfireTime = misfireTime.AddMilliseconds(-1.0 * MisfireThreshold.TotalMilliseconds);
			}
			return misfireTime;
		}
	}

	/// <summary>
	/// Get the driver delegate for DB operations.
	/// </summary>
	protected virtual IDriverDelegate Delegate
	{
		get
		{
			lock (this)
			{
				if (driverDelegate == null)
				{
					try
					{
						if (delegateTypeName != null)
						{
							delegateType = TypeLoadHelper.LoadType(delegateTypeName);
						}
						IDbProvider dbProvider = ConnectionManager.GetDbProvider(DataSource);
						DelegateInitializationArgs args = new DelegateInitializationArgs();
						args.UseProperties = CanUseProperties;
						args.Logger = log;
						args.TablePrefix = tablePrefix;
						args.InstanceName = instanceName;
						args.InstanceId = instanceId;
						args.DbProvider = dbProvider;
						args.TypeLoadHelper = typeLoadHelper;
						args.ObjectSerializer = objectSerializer;
						args.InitString = DriverDelegateInitString;
						ConstructorInfo ctor = delegateType.GetConstructor(new Type[0]);
						if (ctor == null)
						{
							throw new InvalidConfigurationException("Configured delegate does not have public constructor that takes no arguments");
						}
						driverDelegate = (IDriverDelegate)ctor.Invoke(null);
						driverDelegate.Initialize(args);
					}
					catch (Exception e)
					{
						throw new NoSuchDelegateException("Couldn't instantiate delegate: " + e.Message, e);
					}
				}
			}
			return driverDelegate;
		}
	}

	private IDbProvider DbProvider => ConnectionManager.GetDbProvider(DataSource);

	protected internal virtual ISemaphore LockHandler { get; set; }

	/// <summary>
	/// Get whether String-only properties will be handled in JobDataMaps.
	/// </summary>
	public virtual bool CanUseProperties => useProperties;

	/// <summary>
	/// Indicates whether this job store supports persistence.
	/// </summary>
	/// <value></value>
	/// <returns></returns>
	public virtual bool SupportsPersistence => true;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.JobStoreSupport" /> class.
	/// </summary>
	protected JobStoreSupport()
	{
		DoubleCheckLockMisfireHandler = true;
		ClusterCheckinInterval = TimeSpan.FromMilliseconds(7500.0);
		MaxMisfiresToHandleAtATime = 20;
		DbRetryInterval = TimeSpan.FromSeconds(15.0);
		log = LogManager.GetLogger(GetType());
		delegateType = typeof(StdAdoDelegate);
	}

	protected abstract ConnectionAndTransactionHolder GetNonManagedTXConnection();

	/// <summary>
	/// Gets the connection and starts a new transaction.
	/// </summary>
	/// <returns></returns>
	protected virtual ConnectionAndTransactionHolder GetConnection()
	{
		IDbConnection conn;
		try
		{
			conn = ConnectionManager.GetConnection(DataSource);
			conn.Open();
		}
		catch (Exception e2)
		{
			throw new JobPersistenceException($"Failed to obtain DB connection from data source '{DataSource}': {e2}", e2);
		}
		if (conn == null)
		{
			throw new JobPersistenceException($"Could not get connection from DataSource '{DataSource}'");
		}
		IDbTransaction tx;
		try
		{
			tx = ((!TxIsolationLevelSerializable) ? conn.BeginTransaction(IsolationLevel.ReadCommitted) : conn.BeginTransaction(IsolationLevel.Serializable));
		}
		catch (Exception e)
		{
			conn.Close();
			throw new JobPersistenceException("Failure setting up connection.", e);
		}
		return new ConnectionAndTransactionHolder(conn, tx);
	}

	protected virtual string GetFiredTriggerRecordId()
	{
		Interlocked.Increment(ref ftrCtr);
		return InstanceId + ftrCtr;
	}

	/// <summary>
	/// Called by the QuartzScheduler before the <see cref="T:Quartz.Spi.IJobStore" /> is
	/// used, in order to give it a chance to Initialize.
	/// </summary>
	public virtual void Initialize(ITypeLoadHelper loadHelper, ISchedulerSignaler s)
	{
		if (dataSource == null)
		{
			throw new SchedulerConfigException("DataSource name not set.");
		}
		typeLoadHelper = loadHelper;
		schedSignaler = s;
		if (LockHandler == null)
		{
			if (Clustered)
			{
				UseDBLocks = true;
			}
			if (UseDBLocks)
			{
				if (Delegate is SqlServerDelegate && SelectWithLockSQL == null)
				{
					Log.InfoFormat("Detected usage of SqlServerDelegate - defaulting 'selectWithLockSQL' to 'SELECT * FROM {0}LOCKS WITH (UPDLOCK,ROWLOCK) WHERE SCHED_NAME = {1} AND LOCK_NAME = @lockName'.", TablePrefix, "'" + InstanceName + "'");
					SelectWithLockSQL = "SELECT * FROM {0}LOCKS WITH (UPDLOCK,ROWLOCK) WHERE SCHED_NAME = {1} AND LOCK_NAME = @lockName";
				}
				Log.Info("Using db table-based data access locking (synchronization).");
				LockHandler = new StdRowLockSemaphore(TablePrefix, InstanceName, SelectWithLockSQL, DbProvider);
			}
			else
			{
				Log.Info("Using thread monitor-based data access locking (synchronization).");
				LockHandler = new SimpleSemaphore();
			}
		}
		else
		{
			if (LockHandler is UpdateLockRowSemaphore && Delegate is SqlServerDelegate)
			{
				Log.Warn("Detected usage of SqlServerDelegate and UpdateLockRowSemaphore, removing 'quartz.jobStore.lockHandler.type' would allow more efficient SQL Server specific (UPDLOCK,ROWLOCK) row access");
			}
			if (DbProvider != null && DbProvider.Metadata.ConnectionType == typeof(SqlConnection) && !(Delegate is SqlServerDelegate))
			{
				Log.Warn("Detected usage of SQL Server provider without SqlServerDelegate, SqlServerDelegate would provide better performance");
			}
		}
	}

	/// <seealso cref="M:Quartz.Spi.IJobStore.SchedulerStarted" />
	public virtual void SchedulerStarted()
	{
		if (Clustered)
		{
			clusterManagementThread = new ClusterManager(this);
			clusterManagementThread.Initialize();
		}
		else
		{
			try
			{
				RecoverJobs();
			}
			catch (SchedulerException se)
			{
				throw new SchedulerConfigException("Failure occured during job recovery.", se);
			}
		}
		misfireHandler = new MisfireHandler(this);
		misfireHandler.Initialize();
		schedulerRunning = true;
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the JobStore that
	/// the scheduler has been paused.
	/// </summary>
	public void SchedulerPaused()
	{
		schedulerRunning = false;
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the JobStore that
	/// the scheduler has resumed after being paused.
	/// </summary>
	public void SchedulerResumed()
	{
		schedulerRunning = true;
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the <see cref="T:Quartz.Spi.IJobStore" /> that
	/// it should free up all of it's resources because the scheduler is
	/// shutting down.
	/// </summary>
	public virtual void Shutdown()
	{
		if (misfireHandler != null)
		{
			misfireHandler.Shutdown();
			try
			{
				misfireHandler.Join();
			}
			catch (ThreadInterruptedException)
			{
			}
		}
		if (clusterManagementThread != null)
		{
			clusterManagementThread.Shutdown();
			try
			{
				clusterManagementThread.Join();
			}
			catch (ThreadInterruptedException)
			{
			}
		}
		try
		{
			ConnectionManager.Shutdown(DataSource);
		}
		catch (Exception sqle)
		{
			Log.Warn("Database connection Shutdown unsuccessful.", sqle);
		}
	}

	protected virtual void ReleaseLock(string lockName, bool doIt)
	{
		if (doIt)
		{
			try
			{
				LockHandler.ReleaseLock(lockName);
			}
			catch (LockException le)
			{
				Log.Error("Error returning lock: " + le.Message, le);
			}
		}
	}

	/// <summary>
	/// Will recover any failed or misfired jobs and clean up the data store as
	/// appropriate.
	/// </summary>
	protected virtual void RecoverJobs()
	{
		ExecuteInNonManagedTXLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			RecoverJobs(conn);
		});
	}

	/// <summary>
	/// Will recover any failed or misfired jobs and clean up the data store as
	/// appropriate.
	/// </summary>
	protected virtual void RecoverJobs(ConnectionAndTransactionHolder conn)
	{
		try
		{
			int rows = Delegate.UpdateTriggerStatesFromOtherStates(conn, "WAITING", "ACQUIRED", "BLOCKED");
			rows += Delegate.UpdateTriggerStatesFromOtherStates(conn, "PAUSED", "PAUSED_BLOCKED", "PAUSED_BLOCKED");
			Log.Info("Freed " + rows + " triggers from 'acquired' / 'blocked' state.");
			RecoverMisfiredJobs(conn, recovering: true);
			IList<IOperableTrigger> recoveringJobTriggers = Delegate.SelectTriggersForRecoveringJobs(conn);
			Log.Info("Recovering " + recoveringJobTriggers.Count + " jobs that were in-progress at the time of the last shut-down.");
			foreach (IOperableTrigger trigger in recoveringJobTriggers)
			{
				if (JobExists(conn, trigger.JobKey))
				{
					trigger.ComputeFirstFireTimeUtc(null);
					StoreTrigger(conn, trigger, null, replaceExisting: false, "WAITING", forceState: false, recovering: true);
				}
			}
			Log.Info("Recovery complete.");
			IList<TriggerKey> triggersInState = Delegate.SelectTriggersInState(conn, "COMPLETE");
			int i = 0;
			while (triggersInState != null && i < triggersInState.Count)
			{
				RemoveTrigger(conn, triggersInState[i]);
				i++;
			}
			if (triggersInState != null)
			{
				Log.Info(string.Format(CultureInfo.InvariantCulture, "Removed {0} 'complete' triggers.", new object[1] { triggersInState.Count }));
			}
			int j = Delegate.DeleteFiredTriggers(conn);
			Log.Info("Removed " + j + " stale fired job entries.");
		}
		catch (JobPersistenceException)
		{
			throw;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't recover jobs: " + e.Message, e);
		}
	}

	public virtual RecoverMisfiredJobsResult RecoverMisfiredJobs(ConnectionAndTransactionHolder conn, bool recovering)
	{
		int maxMisfiresToHandleAtATime = (recovering ? (-1) : MaxMisfiresToHandleAtATime);
		IList<TriggerKey> misfiredTriggers = new List<TriggerKey>();
		DateTimeOffset earliestNewTime = DateTimeOffset.MaxValue;
		bool hasMoreMisfiredTriggers = Delegate.HasMisfiredTriggersInState(conn, "WAITING", MisfireTime, maxMisfiresToHandleAtATime, misfiredTriggers);
		if (hasMoreMisfiredTriggers)
		{
			Log.Info("Handling the first " + misfiredTriggers.Count + " triggers that missed their scheduled fire-time.  More misfired triggers remain to be processed.");
		}
		else
		{
			if (misfiredTriggers.Count <= 0)
			{
				Log.Debug("Found 0 triggers that missed their scheduled fire-time.");
				return RecoverMisfiredJobsResult.NoOp;
			}
			Log.Info("Handling " + misfiredTriggers.Count + " trigger(s) that missed their scheduled fire-time.");
		}
		foreach (TriggerKey triggerKey in misfiredTriggers)
		{
			IOperableTrigger trig = RetrieveTrigger(conn, triggerKey);
			if (trig != null)
			{
				DoUpdateOfMisfiredTrigger(conn, trig, forceState: false, "WAITING", recovering);
				DateTimeOffset? nextTime = trig.GetNextFireTimeUtc();
				if (nextTime.HasValue && nextTime.Value < earliestNewTime)
				{
					earliestNewTime = nextTime.Value;
				}
			}
		}
		return new RecoverMisfiredJobsResult(hasMoreMisfiredTriggers, misfiredTriggers.Count, earliestNewTime);
	}

	protected virtual bool UpdateMisfiredTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, string newStateIfNotComplete, bool forceState)
	{
		try
		{
			IOperableTrigger trig = RetrieveTrigger(conn, triggerKey);
			DateTimeOffset misfireTime = SystemTime.UtcNow();
			if (MisfireThreshold > TimeSpan.Zero)
			{
				misfireTime = misfireTime.AddMilliseconds(-1.0 * MisfireThreshold.TotalMilliseconds);
			}
			if (trig.GetNextFireTimeUtc().Value > misfireTime)
			{
				return false;
			}
			DoUpdateOfMisfiredTrigger(conn, trig, forceState, newStateIfNotComplete, recovering: false);
			return true;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException($"Couldn't update misfired trigger '{triggerKey}': {e.Message}", e);
		}
	}

	private void DoUpdateOfMisfiredTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trig, bool forceState, string newStateIfNotComplete, bool recovering)
	{
		ICalendar cal = null;
		if (trig.CalendarName != null)
		{
			cal = RetrieveCalendar(conn, trig.CalendarName);
		}
		schedSignaler.NotifyTriggerListenersMisfired(trig);
		trig.UpdateAfterMisfire(cal);
		if (!trig.GetNextFireTimeUtc().HasValue)
		{
			StoreTrigger(conn, trig, null, replaceExisting: true, "COMPLETE", forceState, recovering);
			schedSignaler.NotifySchedulerListenersFinalized(trig);
		}
		else
		{
			StoreTrigger(conn, trig, null, replaceExisting: true, newStateIfNotComplete, forceState, recovering: false);
		}
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.IJobDetail" /> and <see cref="T:Quartz.Spi.IOperableTrigger" />.
	/// </summary>
	/// <param name="newJob">Job to be stored.</param>
	/// <param name="newTrigger">Trigger to be stored.</param>
	public void StoreJobAndTrigger(IJobDetail newJob, IOperableTrigger newTrigger)
	{
		ExecuteInLock(LockOnInsert ? "TRIGGER_ACCESS" : null, delegate(ConnectionAndTransactionHolder conn)
		{
			StoreJob(conn, newJob, replaceExisting: false);
			StoreTrigger(conn, newTrigger, newJob, replaceExisting: false, "WAITING", forceState: false, recovering: false);
			return null;
		});
	}

	/// <summary>
	/// returns true if the given JobGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	public bool IsJobGroupPaused(string groupName)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// returns true if the given TriggerGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	public bool IsTriggerGroupPaused(string groupName)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Stores the given <see cref="T:Quartz.IJobDetail" />.
	/// </summary>
	/// <param name="newJob">The <see cref="T:Quartz.IJobDetail" /> to be stored.</param>
	/// <param name="replaceExisting">
	/// If <see langword="true" />, any <see cref="T:Quartz.IJob" /> existing in the
	/// <see cref="T:Quartz.Spi.IJobStore" /> with the same name &amp; group should be over-written.
	/// </param>
	public void StoreJob(IJobDetail newJob, bool replaceExisting)
	{
		ExecuteInLock((LockOnInsert || replaceExisting) ? "TRIGGER_ACCESS" : null, delegate(ConnectionAndTransactionHolder conn)
		{
			StoreJob(conn, newJob, replaceExisting);
		});
	}

	/// <summary> <para>
	/// Insert or update a job.
	/// </para>
	/// </summary>
	protected virtual void StoreJob(ConnectionAndTransactionHolder conn, IJobDetail newJob, bool replaceExisting)
	{
		bool existingJob = JobExists(conn, newJob.Key);
		try
		{
			if (existingJob)
			{
				if (!replaceExisting)
				{
					throw new ObjectAlreadyExistsException(newJob);
				}
				Delegate.UpdateJobDetail(conn, newJob);
			}
			else
			{
				Delegate.InsertJobDetail(conn, newJob);
			}
		}
		catch (IOException e2)
		{
			throw new JobPersistenceException("Couldn't store job: " + e2.Message, e2);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't store job: " + e.Message, e);
		}
	}

	/// <summary>
	/// Check existence of a given job.
	/// </summary>
	protected virtual bool JobExists(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		try
		{
			return Delegate.JobExists(conn, jobKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't determine job existence (", jobKey, "): ", e.Message), e);
		}
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="newTrigger">The <see cref="T:Quartz.ITrigger" /> to be stored.</param>
	/// <param name="replaceExisting">
	/// If <see langword="true" />, any <see cref="T:Quartz.ITrigger" /> existing in
	/// the <see cref="T:Quartz.Spi.IJobStore" /> with the same name &amp; group should
	/// be over-written.
	/// </param>
	/// <exception cref="T:Quartz.ObjectAlreadyExistsException">
	/// if a <see cref="T:Quartz.ITrigger" /> with the same name/group already
	/// exists, and replaceExisting is set to false.
	/// </exception>
	public void StoreTrigger(IOperableTrigger newTrigger, bool replaceExisting)
	{
		ExecuteInLock((LockOnInsert || replaceExisting) ? "TRIGGER_ACCESS" : null, delegate(ConnectionAndTransactionHolder conn)
		{
			StoreTrigger(conn, newTrigger, null, replaceExisting, "WAITING", forceState: false, recovering: false);
		});
	}

	/// <summary>
	/// Insert or update a trigger.
	/// </summary>
	protected virtual void StoreTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger newTrigger, IJobDetail job, bool replaceExisting, string state, bool forceState, bool recovering)
	{
		bool existingTrigger = TriggerExists(conn, newTrigger.Key);
		if (existingTrigger && !replaceExisting)
		{
			throw new ObjectAlreadyExistsException(newTrigger);
		}
		try
		{
			if (!forceState)
			{
				bool shouldBepaused = Delegate.IsTriggerGroupPaused(conn, newTrigger.Key.Group);
				if (!shouldBepaused)
				{
					shouldBepaused = Delegate.IsTriggerGroupPaused(conn, "_$_ALL_GROUPS_PAUSED_$_");
					if (shouldBepaused)
					{
						Delegate.InsertPausedTriggerGroup(conn, newTrigger.Key.Group);
					}
				}
				if (shouldBepaused && (state.Equals("WAITING") || state.Equals("ACQUIRED")))
				{
					state = "PAUSED";
				}
			}
			if (job == null)
			{
				job = Delegate.SelectJobDetail(conn, newTrigger.JobKey, TypeLoadHelper);
			}
			if (job == null)
			{
				throw new JobPersistenceException(string.Concat("The job (", newTrigger.JobKey, ") referenced by the trigger does not exist."));
			}
			if (job.ConcurrentExecutionDisallowed && !recovering)
			{
				state = CheckBlockedState(conn, job.Key, state);
			}
			if (existingTrigger)
			{
				Delegate.UpdateTrigger(conn, newTrigger, state, job);
			}
			else
			{
				Delegate.InsertTrigger(conn, newTrigger, state, job);
			}
		}
		catch (Exception e)
		{
			string message = $"Couldn't store trigger '{newTrigger.Key}' for '{newTrigger.JobKey}' job: {e.Message}";
			throw new JobPersistenceException(message, e);
		}
	}

	/// <summary>
	/// Check existence of a given trigger.
	/// </summary>
	protected virtual bool TriggerExists(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			return Delegate.TriggerExists(conn, triggerKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't determine trigger existence (", triggerKey, "): ", e.Message), e);
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.IJob" /> with the given
	/// name, and any <see cref="T:Quartz.ITrigger" /> s that reference
	/// it.
	/// </summary>
	///
	/// <remarks>
	/// If removal of the <see cref="T:Quartz.IJob" /> results in an empty group, the
	/// group should be removed from the <see cref="T:Quartz.Spi.IJobStore" />'s list of
	/// known group names.
	/// </remarks>
	/// <returns>
	/// <see langword="true" /> if a <see cref="T:Quartz.IJob" /> with the given name &amp;
	/// group was found and removed from the store.
	/// </returns>
	public bool RemoveJob(JobKey jobKey)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => RemoveJob(conn, jobKey, activeDeleteSafe: true));
	}

	protected virtual bool RemoveJob(ConnectionAndTransactionHolder conn, JobKey jobKey, bool activeDeleteSafe)
	{
		try
		{
			IList<TriggerKey> jobTriggers = Delegate.SelectTriggerNamesForJob(conn, jobKey);
			foreach (TriggerKey jobTrigger in jobTriggers)
			{
				DeleteTriggerAndChildren(conn, jobTrigger);
			}
			return DeleteJobAndChildren(conn, jobKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't remove job: " + e.Message, e);
		}
	}

	public bool RemoveJobs(IList<JobKey> jobKeys)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			bool flag = true;
			foreach (JobKey current in jobKeys)
			{
				flag = RemoveJob(conn, current, activeDeleteSafe: true) && flag;
			}
			return flag;
		});
	}

	public bool RemoveTriggers(IList<TriggerKey> triggerKeys)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			bool flag = true;
			foreach (TriggerKey current in triggerKeys)
			{
				flag = RemoveTrigger(conn, current) && flag;
			}
			return flag;
		});
	}

	public void StoreJobsAndTriggers(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace)
	{
		ExecuteInLock((LockOnInsert || replace) ? "TRIGGER_ACCESS" : null, delegate(ConnectionAndTransactionHolder conn)
		{
			foreach (IJobDetail current in triggersAndJobs.Keys)
			{
				StoreJob(conn, current, replace);
				foreach (ITrigger current2 in triggersAndJobs[current])
				{
					StoreTrigger(conn, (IOperableTrigger)current2, current, replace, "WAITING", forceState: false, recovering: false);
				}
			}
		});
	}

	/// <summary>
	/// Delete a job and its listeners.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.RemoveJob(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,Quartz.JobKey,System.Boolean)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.RemoveTrigger(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,Quartz.TriggerKey)" />
	private bool DeleteJobAndChildren(ConnectionAndTransactionHolder conn, JobKey key)
	{
		return Delegate.DeleteJobDetail(conn, key) > 0;
	}

	/// <summary>
	/// Delete a trigger, its listeners, and its Simple/Cron/BLOB sub-table entry.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.RemoveJob(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,Quartz.JobKey,System.Boolean)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.RemoveTrigger(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,Quartz.TriggerKey)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ReplaceTrigger(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,Quartz.TriggerKey,Quartz.Spi.IOperableTrigger)" />
	private bool DeleteTriggerAndChildren(ConnectionAndTransactionHolder conn, TriggerKey key)
	{
		IDriverDelegate del = Delegate;
		return del.DeleteTrigger(conn, key) > 0;
	}

	/// <summary>
	/// Retrieve the <see cref="T:Quartz.IJobDetail" /> for the given
	/// <see cref="T:Quartz.IJob" />.
	/// </summary>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <returns>The desired <see cref="T:Quartz.IJob" />, or null if there is no match.</returns>
	public IJobDetail RetrieveJob(JobKey jobKey)
	{
		return (IJobDetail)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => RetrieveJob(conn, jobKey));
	}

	protected virtual IJobDetail RetrieveJob(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		try
		{
			return Delegate.SelectJobDetail(conn, jobKey, TypeLoadHelper);
		}
		catch (IOException e2)
		{
			throw new JobPersistenceException("Couldn't retrieve job because the BLOB couldn't be deserialized: " + e2.Message, e2);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't retrieve job: " + e.Message, e);
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ITrigger" /> with the
	/// given name.
	/// </summary>
	///
	/// <remarks>
	/// <para>
	/// If removal of the <see cref="T:Quartz.ITrigger" /> results in an empty group, the
	/// group should be removed from the <see cref="T:Quartz.Spi.IJobStore" />'s list of
	/// known group names.
	/// </para>
	///
	/// <para>
	/// If removal of the <see cref="T:Quartz.ITrigger" /> results in an 'orphaned' <see cref="T:Quartz.IJob" />
	/// that is not 'durable', then the <see cref="T:Quartz.IJob" /> should be deleted
	/// also.
	/// </para>
	/// </remarks>
	/// <param name="triggerKey">The key identifying the trigger.</param>
	/// <returns>
	/// <see langword="true" /> if a <see cref="T:Quartz.ITrigger" /> with the given
	/// name &amp; group was found and removed from the store.
	///             </returns>
	public bool RemoveTrigger(TriggerKey triggerKey)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => RemoveTrigger(conn, triggerKey));
	}

	protected virtual bool RemoveTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		bool removedTrigger;
		try
		{
			IJobDetail job = Delegate.SelectJobForTrigger(conn, triggerKey, new NoOpJobTypeLoader());
			removedTrigger = DeleteTriggerAndChildren(conn, triggerKey);
			if (job != null && !job.Durable && Delegate.SelectNumTriggersForJob(conn, job.Key) == 0)
			{
				DeleteJobAndChildren(conn, job.Key);
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't remove trigger: " + e.Message, e);
		}
		return removedTrigger;
	}

	/// <see cref="M:Quartz.Spi.IJobStore.ReplaceTrigger(Quartz.TriggerKey,Quartz.Spi.IOperableTrigger)" />
	public bool ReplaceTrigger(TriggerKey triggerKey, IOperableTrigger newTrigger)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => ReplaceTrigger(conn, triggerKey, newTrigger));
	}

	protected virtual bool ReplaceTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, IOperableTrigger newTrigger)
	{
		try
		{
			IJobDetail job = Delegate.SelectJobForTrigger(conn, triggerKey, TypeLoadHelper);
			if (job == null)
			{
				return false;
			}
			if (!newTrigger.JobKey.Equals(job.Key))
			{
				throw new JobPersistenceException("New trigger is not related to the same job as the old trigger.");
			}
			bool removedTrigger = DeleteTriggerAndChildren(conn, triggerKey);
			StoreTrigger(conn, newTrigger, job, replaceExisting: false, "WAITING", forceState: false, recovering: false);
			return removedTrigger;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't remove trigger: " + e.Message, e);
		}
	}

	/// <summary>
	/// Retrieve the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="triggerKey">The key identifying the trigger.</param>
	/// <returns>The desired <see cref="T:Quartz.ITrigger" />, or null if there is no match.</returns>
	public IOperableTrigger RetrieveTrigger(TriggerKey triggerKey)
	{
		return (IOperableTrigger)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => RetrieveTrigger(conn, triggerKey));
	}

	protected virtual IOperableTrigger RetrieveTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			return Delegate.SelectTrigger(conn, triggerKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't retrieve trigger: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the current state of the identified <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <seealso cref="F:Quartz.TriggerState.Normal" />
	/// <seealso cref="F:Quartz.TriggerState.Paused" />
	/// <seealso cref="F:Quartz.TriggerState.Complete" />
	/// <seealso cref="F:Quartz.TriggerState.Error" />
	/// <seealso cref="F:Quartz.TriggerState.None" />
	public TriggerState GetTriggerState(TriggerKey triggerKey)
	{
		return (TriggerState)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetTriggerState(conn, triggerKey));
	}

	/// <summary>
	/// Gets the state of the trigger.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="triggerKey">The key identifying the trigger.</param>
	/// <returns></returns>
	public virtual TriggerState GetTriggerState(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			string ts = Delegate.SelectTriggerState(conn, triggerKey);
			if (ts == null)
			{
				return TriggerState.None;
			}
			if (ts.Equals("DELETED"))
			{
				return TriggerState.None;
			}
			if (ts.Equals("COMPLETE"))
			{
				return TriggerState.Complete;
			}
			if (ts.Equals("PAUSED"))
			{
				return TriggerState.Paused;
			}
			if (ts.Equals("PAUSED_BLOCKED"))
			{
				return TriggerState.Blocked;
			}
			if (ts.Equals("ERROR"))
			{
				return TriggerState.Error;
			}
			if (ts.Equals("BLOCKED"))
			{
				return TriggerState.Blocked;
			}
			return TriggerState.Normal;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't determine state of trigger (", triggerKey, "): ", e.Message), e);
		}
	}

	/// <summary>
	/// Store the given <see cref="T:Quartz.ICalendar" />.
	/// </summary>
	/// <param name="calName">The name of the calendar.</param>
	/// <param name="calendar">The <see cref="T:Quartz.ICalendar" /> to be stored.</param>
	/// <param name="replaceExisting">
	/// If <see langword="true" />, any <see cref="T:Quartz.ICalendar" /> existing
	/// in the <see cref="T:Quartz.Spi.IJobStore" /> with the same name &amp; group
	/// should be over-written.
	/// </param>
	/// <param name="updateTriggers"></param>
	/// <exception cref="T:Quartz.ObjectAlreadyExistsException">
	///           if a <see cref="T:Quartz.ICalendar" /> with the same name already
	///           exists, and replaceExisting is set to false.
	/// </exception>
	public void StoreCalendar(string calName, ICalendar calendar, bool replaceExisting, bool updateTriggers)
	{
		ExecuteInLock((LockOnInsert || updateTriggers) ? "TRIGGER_ACCESS" : null, delegate(ConnectionAndTransactionHolder conn)
		{
			StoreCalendar(conn, calName, calendar, replaceExisting, updateTriggers);
		});
	}

	protected virtual void StoreCalendar(ConnectionAndTransactionHolder conn, string calName, ICalendar calendar, bool replaceExisting, bool updateTriggers)
	{
		try
		{
			bool existingCal = CalendarExists(conn, calName);
			if (existingCal && !replaceExisting)
			{
				throw new ObjectAlreadyExistsException("Calendar with name '" + calName + "' already exists.");
			}
			if (existingCal)
			{
				if (Delegate.UpdateCalendar(conn, calName, calendar) < 1)
				{
					throw new JobPersistenceException("Couldn't store calendar.  Update failed.");
				}
				if (updateTriggers)
				{
					IList<IOperableTrigger> triggers = Delegate.SelectTriggersForCalendar(conn, calName);
					foreach (IOperableTrigger trigger in triggers)
					{
						trigger.UpdateWithNewCalendar(calendar, MisfireThreshold);
						StoreTrigger(conn, trigger, null, replaceExisting: true, "WAITING", forceState: false, recovering: false);
					}
				}
			}
			else if (Delegate.InsertCalendar(conn, calName, calendar) < 1)
			{
				throw new JobPersistenceException("Couldn't store calendar.  Insert failed.");
			}
			if (!Clustered)
			{
				calendarCache[calName] = calendar;
			}
		}
		catch (IOException e2)
		{
			throw new JobPersistenceException("Couldn't store calendar because the BLOB couldn't be serialized: " + e2.Message, e2);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't store calendar: " + e.Message, e);
		}
	}

	protected virtual bool CalendarExists(ConnectionAndTransactionHolder conn, string calName)
	{
		try
		{
			return Delegate.CalendarExists(conn, calName);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't determine calendar existence (" + calName + "): " + e.Message, e);
		}
	}

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ICalendar" /> with the given name.
	/// </summary>
	/// <remarks>
	/// If removal of the <see cref="T:Quartz.ICalendar" /> would result in
	/// <see cref="T:Quartz.ITrigger" />s pointing to non-existent calendars, then a
	/// <see cref="T:Quartz.JobPersistenceException" /> will be thrown.
	/// </remarks>
	/// <param name="calName">The name of the <see cref="T:Quartz.ICalendar" /> to be removed.</param>
	/// <returns>
	/// <see langword="true" /> if a <see cref="T:Quartz.ICalendar" /> with the given name
	/// was found and removed from the store.
	///             </returns>
	public bool RemoveCalendar(string calName)
	{
		return (bool)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => RemoveCalendar(conn, calName));
	}

	protected virtual bool RemoveCalendar(ConnectionAndTransactionHolder conn, string calName)
	{
		try
		{
			if (Delegate.CalendarIsReferenced(conn, calName))
			{
				throw new JobPersistenceException("Calender cannot be removed if it referenced by a trigger!");
			}
			if (!Clustered)
			{
				calendarCache.Remove(calName);
			}
			return Delegate.DeleteCalendar(conn, calName) > 0;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't remove calendar: " + e.Message, e);
		}
	}

	/// <summary>
	/// Retrieve the given <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <param name="calName">The name of the <see cref="T:Quartz.ICalendar" /> to be retrieved.</param>
	/// <returns>The desired <see cref="T:Quartz.ICalendar" />, or null if there is no match.</returns>
	public ICalendar RetrieveCalendar(string calName)
	{
		return (ICalendar)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => RetrieveCalendar(conn, calName));
	}

	protected virtual ICalendar RetrieveCalendar(ConnectionAndTransactionHolder conn, string calName)
	{
		ICalendar cal = null;
		if (!Clustered)
		{
			calendarCache.TryGetValue(calName, out cal);
		}
		if (cal != null)
		{
			return cal;
		}
		try
		{
			cal = Delegate.SelectCalendar(conn, calName);
			if (!Clustered)
			{
				calendarCache[calName] = cal;
			}
			return cal;
		}
		catch (IOException e2)
		{
			throw new JobPersistenceException("Couldn't retrieve calendar because the BLOB couldn't be deserialized: " + e2.Message, e2);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't retrieve calendar: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.IJob" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public int GetNumberOfJobs()
	{
		return (int)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetNumberOfJobs(conn));
	}

	protected virtual int GetNumberOfJobs(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectNumJobs(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain number of jobs: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.ITrigger" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public int GetNumberOfTriggers()
	{
		return (int)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetNumberOfTriggers(conn));
	}

	protected virtual int GetNumberOfTriggers(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectNumTriggers(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain number of triggers: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the number of <see cref="T:Quartz.ICalendar" /> s that are
	/// stored in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	public int GetNumberOfCalendars()
	{
		return (int)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetNumberOfCalendars(conn));
	}

	protected virtual int GetNumberOfCalendars(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectNumCalendars(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain number of calendars: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.IJob" /> s that
	/// have the given group name.
	/// </summary>
	/// <remarks>
	/// If there are no jobs in the given group name, the result should be a
	/// zero-length array (not <see langword="null" />).
	/// </remarks>
	public Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
	{
		return (Quartz.Collection.ISet<JobKey>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetJobNames(conn, matcher));
	}

	protected virtual Quartz.Collection.ISet<JobKey> GetJobNames(ConnectionAndTransactionHolder conn, GroupMatcher<JobKey> matcher)
	{
		try
		{
			return Delegate.SelectJobsInGroup(conn, matcher);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain job names: " + e.Message, e);
		}
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.IJob" /> with the given identifier already
	/// exists within the scheduler.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobKey">the identifier to check for</param>
	/// <returns>true if a Job exists with the given identifier</returns>
	public bool CheckExists(JobKey jobKey)
	{
		return (bool)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => CheckExists(conn, jobKey));
	}

	protected bool CheckExists(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		try
		{
			return Delegate.JobExists(conn, jobKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't check for existence of job: " + e.Message, e);
		}
	}

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.ITrigger" /> with the given identifier already
	/// exists within the scheduler.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="triggerKey">the identifier to check for</param>
	/// <returns>true if a Trigger exists with the given identifier</returns>
	public bool CheckExists(TriggerKey triggerKey)
	{
		return (bool)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => CheckExists(conn, triggerKey));
	}

	protected bool CheckExists(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			return Delegate.TriggerExists(conn, triggerKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't check for existence of job: " + e.Message, e);
		}
	}

	/// <summary>
	/// Clear (delete!) all scheduling data - all <see cref="T:Quartz.IJob" />s, <see cref="T:Quartz.ITrigger" />s
	/// <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	/// <remarks>
	/// </remarks>
	public void ClearAllSchedulingData()
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			ClearAllSchedulingData(conn);
		});
	}

	protected void ClearAllSchedulingData(ConnectionAndTransactionHolder conn)
	{
		try
		{
			Delegate.ClearData(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Error clearing scheduling data: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ITrigger" /> s
	/// that have the given group name.
	/// </summary>
	/// <remarks>
	/// If there are no triggers in the given group name, the result should be a
	/// zero-length array (not <see langword="null" />).
	/// </remarks>
	public Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
	{
		return (Quartz.Collection.ISet<TriggerKey>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetTriggerNames(conn, matcher));
	}

	protected virtual Quartz.Collection.ISet<TriggerKey> GetTriggerNames(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		try
		{
			return Delegate.SelectTriggersInGroup(conn, matcher);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain trigger names: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.IJob" />
	/// groups.
	/// </summary>
	///
	/// <remarks>
	/// If there are no known group names, the result should be a zero-length
	/// array (not <see langword="null" />).
	/// </remarks>
	public IList<string> GetJobGroupNames()
	{
		return (IList<string>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetJobGroupNames(conn));
	}

	protected virtual IList<string> GetJobGroupNames(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectJobGroups(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain job groups: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ITrigger" />
	/// groups.
	/// </summary>
	///
	/// <remarks>
	/// If there are no known group names, the result should be a zero-length
	/// array (not <see langword="null" />).
	/// </remarks>
	public IList<string> GetTriggerGroupNames()
	{
		return (IList<string>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetTriggerGroupNames(conn));
	}

	protected virtual IList<string> GetTriggerGroupNames(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectTriggerGroups(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain trigger groups: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get the names of all of the <see cref="T:Quartz.ICalendar" /> s
	/// in the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </summary>
	/// <remarks>
	/// If there are no Calendars in the given group name, the result should be
	/// a zero-length array (not <see langword="null" />).
	/// </remarks>
	public IList<string> GetCalendarNames()
	{
		return (IList<string>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetCalendarNames(conn));
	}

	protected virtual IList<string> GetCalendarNames(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectCalendars(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain trigger groups: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get all of the Triggers that are associated to the given Job.
	/// </summary>
	/// <remarks>
	/// If there are no matches, a zero-length array should be returned.
	/// </remarks>
	public IList<IOperableTrigger> GetTriggersForJob(JobKey jobKey)
	{
		return (IList<IOperableTrigger>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetTriggersForJob(conn, jobKey));
	}

	protected virtual IList<IOperableTrigger> GetTriggersForJob(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		try
		{
			return Delegate.SelectTriggersForJob(conn, jobKey);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't obtain triggers for job: " + e.Message, e);
		}
	}

	/// <summary>
	/// Pause the <see cref="T:Quartz.ITrigger" /> with the given name.
	/// </summary>
	public void PauseTrigger(TriggerKey triggerKey)
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			PauseTrigger(conn, triggerKey);
		});
	}

	/// <summary>
	/// Pause the <see cref="T:Quartz.ITrigger" /> with the given name.
	/// </summary>
	public virtual void PauseTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			string oldState = Delegate.SelectTriggerState(conn, triggerKey);
			if (oldState.Equals("WAITING") || oldState.Equals("ACQUIRED"))
			{
				Delegate.UpdateTriggerState(conn, triggerKey, "PAUSED");
			}
			else if (oldState.Equals("BLOCKED"))
			{
				Delegate.UpdateTriggerState(conn, triggerKey, "PAUSED_BLOCKED");
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't pause trigger '", triggerKey, "': ", e.Message), e);
		}
	}

	/// <summary>
	/// Pause the <see cref="T:Quartz.IJob" /> with the given name - by
	/// pausing all of its current <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeJob(Quartz.JobKey)" />
	public virtual void PauseJob(JobKey jobKey)
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			IList<IOperableTrigger> triggersForJob = GetTriggersForJob(conn, jobKey);
			foreach (IOperableTrigger current in triggersForJob)
			{
				PauseTrigger(conn, current.Key);
			}
		});
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.IJob" />s in the given
	/// group - by pausing all of their <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeJobs(Quartz.Impl.Matchers.GroupMatcher{Quartz.JobKey})" />
	public virtual IList<string> PauseJobs(GroupMatcher<JobKey> matcher)
	{
		return (IList<string>)ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			Quartz.Collection.ISet<string> set = new Quartz.Collection.HashSet<string>();
			Quartz.Collection.ISet<JobKey> jobNames = GetJobNames(conn, matcher);
			foreach (JobKey current in jobNames)
			{
				IList<IOperableTrigger> triggersForJob = GetTriggersForJob(conn, current);
				foreach (IOperableTrigger current2 in triggersForJob)
				{
					PauseTrigger(conn, current2.Key);
				}
				set.Add(current.Group);
			}
			return new List<string>(set);
		});
	}

	/// <summary>
	/// Determines if a Trigger for the given job should be blocked.  
	/// State can only transition to StatePausedBlocked/StateBlocked from 
	/// StatePaused/StateWaiting respectively.
	/// </summary>
	/// <returns>StatePausedBlocked, StateBlocked, or the currentState. </returns>
	protected virtual string CheckBlockedState(ConnectionAndTransactionHolder conn, JobKey jobKey, string currentState)
	{
		if (!currentState.Equals("WAITING") && !currentState.Equals("PAUSED"))
		{
			return currentState;
		}
		try
		{
			IList<FiredTriggerRecord> lst = Delegate.SelectFiredTriggerRecordsByJob(conn, jobKey.Name, jobKey.Group);
			if (lst.Count > 0)
			{
				FiredTriggerRecord rec = lst[0];
				if (rec.JobDisallowsConcurrentExecution)
				{
					return "PAUSED".Equals(currentState) ? "PAUSED_BLOCKED" : "BLOCKED";
				}
			}
			return currentState;
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't determine if trigger should be in a blocked state '", jobKey, "': ", e.Message), e);
		}
	}

	public virtual void ResumeTrigger(TriggerKey triggerKey)
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			ResumeTrigger(conn, triggerKey);
		});
	}

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.ITrigger" /> with the
	/// given name.
	/// </summary>
	/// <remarks>
	/// If the <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	public virtual void ResumeTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		try
		{
			TriggerStatus status = Delegate.SelectTriggerStatus(conn, triggerKey);
			if (status == null || !status.NextFireTimeUtc.HasValue || status.NextFireTimeUtc == DateTimeOffset.MinValue)
			{
				return;
			}
			bool blocked = "PAUSED_BLOCKED".Equals(status.Status);
			string newState = CheckBlockedState(conn, status.JobKey, "WAITING");
			bool misfired = false;
			if (schedulerRunning && status.NextFireTimeUtc.Value < SystemTime.UtcNow())
			{
				misfired = UpdateMisfiredTrigger(conn, triggerKey, newState, forceState: true);
			}
			if (!misfired)
			{
				if (blocked)
				{
					Delegate.UpdateTriggerStateFromOtherState(conn, triggerKey, newState, "PAUSED_BLOCKED");
				}
				else
				{
					Delegate.UpdateTriggerStateFromOtherState(conn, triggerKey, newState, "PAUSED");
				}
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't resume trigger '", triggerKey, "': ", e.Message), e);
		}
	}

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.IJob" /> with the
	/// given name.
	/// </summary>
	/// <remarks>
	/// If any of the <see cref="T:Quartz.IJob" />'s <see cref="T:Quartz.ITrigger" /> s missed one
	/// or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s misfire
	/// instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.PauseJob(Quartz.JobKey)" />
	public virtual void ResumeJob(JobKey jobKey)
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			IList<IOperableTrigger> triggersForJob = GetTriggersForJob(conn, jobKey);
			foreach (IOperableTrigger current in triggersForJob)
			{
				ResumeTrigger(conn, current.Key);
			}
		});
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.IJob" />s in
	/// the given group.
	/// </summary>
	/// <remarks>
	/// If any of the <see cref="T:Quartz.IJob" /> s had <see cref="T:Quartz.ITrigger" /> s that
	/// missed one or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s
	/// misfire instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.PauseJobs(Quartz.Impl.Matchers.GroupMatcher{Quartz.JobKey})" />
	public virtual Quartz.Collection.ISet<string> ResumeJobs(GroupMatcher<JobKey> matcher)
	{
		return (Quartz.Collection.ISet<string>)ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			Quartz.Collection.ISet<JobKey> jobNames = GetJobNames(conn, matcher);
			Quartz.Collection.ISet<string> set = new Quartz.Collection.HashSet<string>();
			foreach (JobKey current in jobNames)
			{
				IList<IOperableTrigger> triggersForJob = GetTriggersForJob(conn, current);
				foreach (IOperableTrigger current2 in triggersForJob)
				{
					ResumeTrigger(conn, current2.Key);
				}
				set.Add(current.Group);
			}
			return set;
		});
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the given group.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	public virtual Quartz.Collection.ISet<string> PauseTriggers(GroupMatcher<TriggerKey> matcher)
	{
		return (Quartz.Collection.ISet<string>)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => PauseTriggerGroup(conn, matcher));
	}

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the given group.
	/// </summary>
	public virtual Quartz.Collection.ISet<string> PauseTriggerGroup(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		try
		{
			Delegate.UpdateTriggerGroupStateFromOtherStates(conn, matcher, "PAUSED", "ACQUIRED", "WAITING", "WAITING");
			Delegate.UpdateTriggerGroupStateFromOtherState(conn, matcher, "PAUSED_BLOCKED", "BLOCKED");
			IList<string> groups = Delegate.SelectTriggerGroups(conn, matcher);
			StringOperator op = matcher.CompareWithOperator;
			if (op.Equals(StringOperator.Equality) && !groups.Contains(matcher.CompareToValue))
			{
				groups.Add(matcher.CompareToValue);
			}
			foreach (string group in groups)
			{
				if (!Delegate.IsTriggerGroupPaused(conn, group))
				{
					Delegate.InsertPausedTriggerGroup(conn, group);
				}
			}
			return new Quartz.Collection.HashSet<string>(groups);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't pause trigger group '", matcher, "': ", e.Message), e);
		}
	}

	public Quartz.Collection.ISet<string> GetPausedTriggerGroups()
	{
		return (Quartz.Collection.ISet<string>)ExecuteWithoutLock((ConnectionAndTransactionHolder conn) => GetPausedTriggerGroups(conn));
	}

	/// <summary> 
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the
	/// given group.
	/// </summary>
	public virtual Quartz.Collection.ISet<string> GetPausedTriggerGroups(ConnectionAndTransactionHolder conn)
	{
		try
		{
			return Delegate.SelectPausedTriggerGroups(conn);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't determine paused trigger groups: " + e.Message, e);
		}
	}

	public virtual IList<string> ResumeTriggers(GroupMatcher<TriggerKey> matcher)
	{
		return (IList<string>)ExecuteInLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => ResumeTriggers(conn, matcher));
	}

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.ITrigger" />s
	/// in the given group.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	public virtual IList<string> ResumeTriggers(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		try
		{
			Delegate.DeletePausedTriggerGroup(conn, matcher);
			Quartz.Collection.HashSet<string> groups = new Quartz.Collection.HashSet<string>();
			Quartz.Collection.ISet<TriggerKey> keys = Delegate.SelectTriggersInGroup(conn, matcher);
			foreach (TriggerKey key in keys)
			{
				ResumeTrigger(conn, key);
				groups.Add(key.Group);
			}
			return new List<string>(groups);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException(string.Concat("Couldn't pause trigger group '", matcher, "': ", e.Message), e);
		}
	}

	public virtual void PauseAll()
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			PauseAll(conn);
		});
	}

	/// <summary>
	/// Pause all triggers - equivalent of calling <see cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group.
	/// <para>
	/// When <see cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeAll" /> is called (to un-pause), trigger misfire
	/// instructions WILL be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeAll" />
	/// <seealso cref="T:System.String" />
	public virtual void PauseAll(ConnectionAndTransactionHolder conn)
	{
		IList<string> groupNames = GetTriggerGroupNames(conn);
		foreach (string groupName in groupNames)
		{
			PauseTriggerGroup(conn, GroupMatcher<TriggerKey>.GroupEquals(groupName));
		}
		try
		{
			if (!Delegate.IsTriggerGroupPaused(conn, "_$_ALL_GROUPS_PAUSED_$_"))
			{
				Delegate.InsertPausedTriggerGroup(conn, "_$_ALL_GROUPS_PAUSED_$_");
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't pause all trigger groups: " + e.Message, e);
		}
	}

	/// <summary>
	/// Resume (un-pause) all triggers - equivalent of calling <see cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group.
	/// </summary>
	/// <remarks>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.PauseAll" />
	public virtual void ResumeAll()
	{
		ExecuteInLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			ResumeAll(conn);
		});
	}

	/// <summary>
	/// Resume (un-pause) all triggers - equivalent of calling <see cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group.
	/// <para>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.PauseAll" />
	public virtual void ResumeAll(ConnectionAndTransactionHolder conn)
	{
		IList<string> triggerGroupNames = GetTriggerGroupNames(conn);
		foreach (string groupName in triggerGroupNames)
		{
			ResumeTriggers(conn, GroupMatcher<TriggerKey>.GroupEquals(groupName));
		}
		try
		{
			Delegate.DeletePausedTriggerGroup(conn, "_$_ALL_GROUPS_PAUSED_$_");
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't resume all trigger groups: " + e.Message, e);
		}
	}

	/// <summary>
	/// Get a handle to the next N triggers to be fired, and mark them as 'reserved'
	/// by the calling scheduler.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ReleaseAcquiredTrigger(Quartz.Spi.IOperableTrigger)" />
	public virtual IList<IOperableTrigger> AcquireNextTriggers(DateTimeOffset noLaterThan, int maxCount, TimeSpan timeWindow)
	{
		if (AcquireTriggersWithinLock || maxCount > 1)
		{
			return (IList<IOperableTrigger>)ExecuteInNonManagedTXLock("TRIGGER_ACCESS", (ConnectionAndTransactionHolder conn) => AcquireNextTrigger(conn, noLaterThan, maxCount, timeWindow));
		}
		return (IList<IOperableTrigger>)ExecuteInNonManagedTXLock(null, (ConnectionAndTransactionHolder conn) => AcquireNextTrigger(conn, noLaterThan, maxCount, timeWindow));
	}

	protected virtual IList<IOperableTrigger> AcquireNextTrigger(ConnectionAndTransactionHolder conn, DateTimeOffset noLaterThan, int maxCount, TimeSpan timeWindow)
	{
		List<IOperableTrigger> acquiredTriggers = new List<IOperableTrigger>();
		Quartz.Collection.ISet<JobKey> acquiredJobKeysForNoConcurrentExec = new Quartz.Collection.HashSet<JobKey>();
		int currentLoopCount = 0;
		DateTimeOffset? firstAcquiredTriggerFireTime = null;
		while (true)
		{
			currentLoopCount++;
			try
			{
				IList<TriggerKey> keys = ((!(timeWindow > TimeSpan.Zero)) ? Delegate.SelectTriggerToAcquire(conn, noLaterThan, MisfireTime, maxCount) : Delegate.SelectTriggerToAcquire(conn, noLaterThan + timeWindow, MisfireTime, maxCount));
				if (keys == null || keys.Count == 0)
				{
					return acquiredTriggers;
				}
				foreach (TriggerKey triggerKey in keys)
				{
					IOperableTrigger nextTrigger = RetrieveTrigger(conn, triggerKey);
					if (nextTrigger == null)
					{
						continue;
					}
					if (firstAcquiredTriggerFireTime.HasValue && nextTrigger.GetNextFireTimeUtc() > firstAcquiredTriggerFireTime.Value + timeWindow)
					{
						break;
					}
					JobKey jobKey = nextTrigger.JobKey;
					IJobDetail job = Delegate.SelectJobDetail(conn, jobKey, TypeLoadHelper);
					if (job.ConcurrentExecutionDisallowed)
					{
						if (acquiredJobKeysForNoConcurrentExec.Contains(jobKey))
						{
							continue;
						}
						acquiredJobKeysForNoConcurrentExec.Add(jobKey);
					}
					int rowsUpdated = Delegate.UpdateTriggerStateFromOtherState(conn, triggerKey, "ACQUIRED", "WAITING");
					if (rowsUpdated > 0)
					{
						nextTrigger.FireInstanceId = GetFiredTriggerRecordId();
						Delegate.InsertFiredTrigger(conn, nextTrigger, "ACQUIRED", null);
						acquiredTriggers.Add(nextTrigger);
						if (!firstAcquiredTriggerFireTime.HasValue)
						{
							firstAcquiredTriggerFireTime = nextTrigger.GetNextFireTimeUtc();
						}
					}
				}
				if (acquiredTriggers.Count == 0 && currentLoopCount < 3)
				{
					continue;
				}
			}
			catch (Exception e)
			{
				throw new JobPersistenceException("Couldn't acquire next trigger: " + e.Message, e);
			}
			break;
		}
		return acquiredTriggers;
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> that the scheduler no longer plans to
	/// fire the given <see cref="T:Quartz.ITrigger" />, that it had previously acquired
	/// (reserved).
	/// </summary>
	public void ReleaseAcquiredTrigger(IOperableTrigger trigger)
	{
		ExecuteInNonManagedTXLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			ReleaseAcquiredTrigger(conn, trigger);
		});
	}

	protected virtual void ReleaseAcquiredTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger)
	{
		try
		{
			Delegate.UpdateTriggerStateFromOtherState(conn, trigger.Key, "WAITING", "ACQUIRED");
			Delegate.DeleteFiredTrigger(conn, trigger.FireInstanceId);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't release acquired trigger: " + e.Message, e);
		}
	}

	public virtual IList<TriggerFiredResult> TriggersFired(IList<IOperableTrigger> triggers)
	{
		return (IList<TriggerFiredResult>)ExecuteInNonManagedTXLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			List<TriggerFiredResult> list = new List<TriggerFiredResult>();
			foreach (IOperableTrigger current in triggers)
			{
				TriggerFiredResult item;
				try
				{
					TriggerFiredBundle triggerFiredBundle = TriggerFired(conn, current);
					item = new TriggerFiredResult(triggerFiredBundle);
				}
				catch (JobPersistenceException ex)
				{
					log.ErrorFormat("Caught job persistence exception: " + ex.Message, ex);
					item = new TriggerFiredResult(ex);
				}
				catch (Exception ex2)
				{
					log.ErrorFormat("Caught exception: " + ex2.Message, ex2);
					item = new TriggerFiredResult(ex2);
				}
				list.Add(item);
			}
			return list;
		});
	}

	protected virtual TriggerFiredBundle TriggerFired(ConnectionAndTransactionHolder conn, IOperableTrigger trigger)
	{
		ICalendar cal = null;
		try
		{
			string state = Delegate.SelectTriggerState(conn, trigger.Key);
			if (!state.Equals("ACQUIRED"))
			{
				return null;
			}
		}
		catch (Exception e3)
		{
			throw new JobPersistenceException("Couldn't select trigger state: " + e3.Message, e3);
		}
		IJobDetail job;
		try
		{
			job = RetrieveJob(conn, trigger.JobKey);
			if (job == null)
			{
				return null;
			}
		}
		catch (JobPersistenceException jpe)
		{
			try
			{
				Log.Error("Error retrieving job, setting trigger state to ERROR.", jpe);
				Delegate.UpdateTriggerState(conn, trigger.Key, "ERROR");
			}
			catch (Exception sqle)
			{
				Log.Error("Unable to set trigger state to ERROR.", sqle);
			}
			throw;
		}
		if (trigger.CalendarName != null)
		{
			cal = RetrieveCalendar(conn, trigger.CalendarName);
			if (cal == null)
			{
				return null;
			}
		}
		try
		{
			Delegate.UpdateFiredTrigger(conn, trigger, "EXECUTING", job);
		}
		catch (Exception e2)
		{
			throw new JobPersistenceException("Couldn't insert fired trigger: " + e2.Message, e2);
		}
		DateTimeOffset? prevFireTime = trigger.GetPreviousFireTimeUtc();
		trigger.Triggered(cal);
		string state2 = "WAITING";
		bool force = true;
		if (job.ConcurrentExecutionDisallowed)
		{
			state2 = "BLOCKED";
			force = false;
			try
			{
				Delegate.UpdateTriggerStatesForJobFromOtherState(conn, job.Key, "BLOCKED", "WAITING");
				Delegate.UpdateTriggerStatesForJobFromOtherState(conn, job.Key, "BLOCKED", "ACQUIRED");
				Delegate.UpdateTriggerStatesForJobFromOtherState(conn, job.Key, "PAUSED_BLOCKED", "PAUSED");
			}
			catch (Exception e)
			{
				throw new JobPersistenceException("Couldn't update states of blocked triggers: " + e.Message, e);
			}
		}
		if (!trigger.GetNextFireTimeUtc().HasValue)
		{
			state2 = "COMPLETE";
			force = true;
		}
		StoreTrigger(conn, trigger, job, replaceExisting: true, state2, force, recovering: false);
		job.JobDataMap.ClearDirtyFlag();
		return new TriggerFiredBundle(job, trigger, cal, trigger.Key.Group.Equals("RECOVERING_JOBS"), SystemTime.UtcNow(), trigger.GetPreviousFireTimeUtc(), prevFireTime, trigger.GetNextFireTimeUtc());
	}

	/// <summary>
	/// Inform the <see cref="T:Quartz.Spi.IJobStore" /> that the scheduler has completed the
	/// firing of the given <see cref="T:Quartz.ITrigger" /> (and the execution its
	/// associated <see cref="T:Quartz.IJob" />), and that the <see cref="T:Quartz.JobDataMap" />
	/// in the given <see cref="T:Quartz.IJobDetail" /> should be updated if the <see cref="T:Quartz.IJob" />
	/// is stateful.
	/// </summary>
	public virtual void TriggeredJobComplete(IOperableTrigger trigger, IJobDetail jobDetail, SchedulerInstruction triggerInstCode)
	{
		ExecuteInNonManagedTXLock("TRIGGER_ACCESS", delegate(ConnectionAndTransactionHolder conn)
		{
			TriggeredJobComplete(conn, trigger, jobDetail, triggerInstCode);
		});
	}

	protected virtual void TriggeredJobComplete(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, IJobDetail jobDetail, SchedulerInstruction triggerInstCode)
	{
		try
		{
			switch (triggerInstCode)
			{
			case SchedulerInstruction.DeleteTrigger:
				if (!trigger.GetNextFireTimeUtc().HasValue)
				{
					TriggerStatus stat = Delegate.SelectTriggerStatus(conn, trigger.Key);
					if (stat != null && !stat.NextFireTimeUtc.HasValue)
					{
						RemoveTrigger(conn, trigger.Key);
					}
				}
				else
				{
					RemoveTrigger(conn, trigger.Key);
					SignalSchedulingChangeOnTxCompletion(null);
				}
				break;
			case SchedulerInstruction.SetTriggerComplete:
				Delegate.UpdateTriggerState(conn, trigger.Key, "COMPLETE");
				SignalSchedulingChangeOnTxCompletion(null);
				break;
			case SchedulerInstruction.SetTriggerError:
				Log.Info(string.Concat("Trigger ", trigger.Key, " set to ERROR state."));
				Delegate.UpdateTriggerState(conn, trigger.Key, "ERROR");
				SignalSchedulingChangeOnTxCompletion(null);
				break;
			case SchedulerInstruction.SetAllJobTriggersComplete:
				Delegate.UpdateTriggerStatesForJob(conn, trigger.JobKey, "COMPLETE");
				SignalSchedulingChangeOnTxCompletion(null);
				break;
			case SchedulerInstruction.SetAllJobTriggersError:
				Log.Info(string.Concat("All triggers of Job ", trigger.JobKey, " set to ERROR state."));
				Delegate.UpdateTriggerStatesForJob(conn, trigger.JobKey, "ERROR");
				SignalSchedulingChangeOnTxCompletion(null);
				break;
			}
			if (jobDetail.ConcurrentExecutionDisallowed)
			{
				Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jobDetail.Key, "WAITING", "BLOCKED");
				Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jobDetail.Key, "PAUSED", "PAUSED_BLOCKED");
				SignalSchedulingChangeOnTxCompletion(null);
			}
			if (jobDetail.PersistJobDataAfterExecution)
			{
				try
				{
					if (jobDetail.JobDataMap.Dirty)
					{
						Delegate.UpdateJobData(conn, jobDetail);
					}
				}
				catch (IOException e4)
				{
					throw new JobPersistenceException("Couldn't serialize job data: " + e4.Message, e4);
				}
				catch (Exception e3)
				{
					throw new JobPersistenceException("Couldn't update job data: " + e3.Message, e3);
				}
			}
		}
		catch (Exception e2)
		{
			throw new JobPersistenceException("Couldn't update trigger state(s): " + e2.Message, e2);
		}
		try
		{
			Delegate.DeleteFiredTrigger(conn, trigger.FireInstanceId);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Couldn't delete fired trigger: " + e.Message, e);
		}
	}

	protected RecoverMisfiredJobsResult DoRecoverMisfires()
	{
		bool transOwner = false;
		ConnectionAndTransactionHolder conn = GetNonManagedTXConnection();
		try
		{
			RecoverMisfiredJobsResult result = RecoverMisfiredJobsResult.NoOp;
			if ((DoubleCheckLockMisfireHandler ? Delegate.CountMisfiredTriggersInState(conn, "WAITING", MisfireTime) : int.MaxValue) == 0)
			{
				Log.Debug("Found 0 triggers that missed their scheduled fire-time.");
			}
			else
			{
				transOwner = LockHandler.ObtainLock(DbProvider.Metadata, conn, "TRIGGER_ACCESS");
				result = RecoverMisfiredJobs(conn, recovering: false);
			}
			CommitConnection(conn, openNewTransaction: false);
			return result;
		}
		catch (JobPersistenceException)
		{
			RollbackConnection(conn);
			throw;
		}
		catch (Exception e)
		{
			RollbackConnection(conn);
			throw new JobPersistenceException("Database error recovering from misfires.", e);
		}
		finally
		{
			try
			{
				ReleaseLock("TRIGGER_ACCESS", transOwner);
			}
			finally
			{
				CleanupConnection(conn);
			}
		}
	}

	protected virtual void SignalSchedulingChangeOnTxCompletion(DateTimeOffset? candidateNewNextFireTime)
	{
		DateTimeOffset? sigTime = LogicalThreadContext.GetData<DateTimeOffset?>("sigChangeForTxCompletion");
		if (!sigTime.HasValue && candidateNewNextFireTime.HasValue)
		{
			LogicalThreadContext.SetData("sigChangeForTxCompletion", candidateNewNextFireTime);
		}
		else if (!sigTime.HasValue || candidateNewNextFireTime < sigTime)
		{
			LogicalThreadContext.SetData("sigChangeForTxCompletion", candidateNewNextFireTime);
		}
	}

	protected virtual DateTimeOffset? ClearAndGetSignalSchedulingChangeOnTxCompletion()
	{
		DateTimeOffset? t = LogicalThreadContext.GetData<DateTimeOffset?>("sigChangeForTxCompletion");
		LogicalThreadContext.FreeNamedDataSlot("sigChangeForTxCompletion");
		return t;
	}

	protected virtual void SignalSchedulingChangeImmediately(DateTimeOffset? candidateNewNextFireTime)
	{
		schedSignaler.SignalSchedulingChange(candidateNewNextFireTime);
	}

	protected virtual bool DoCheckin()
	{
		bool transOwner = false;
		bool transStateOwner = false;
		bool recovered = false;
		ConnectionAndTransactionHolder conn = GetNonManagedTXConnection();
		try
		{
			IList<SchedulerStateRecord> failedRecords = null;
			if (!firstCheckIn)
			{
				failedRecords = ClusterCheckIn(conn);
				CommitConnection(conn, openNewTransaction: true);
			}
			if (firstCheckIn || (failedRecords != null && failedRecords.Count > 0))
			{
				LockHandler.ObtainLock(DbProvider.Metadata, conn, "STATE_ACCESS");
				transStateOwner = true;
				failedRecords = (firstCheckIn ? ClusterCheckIn(conn) : FindFailedInstances(conn));
				if (failedRecords.Count > 0)
				{
					LockHandler.ObtainLock(DbProvider.Metadata, conn, "TRIGGER_ACCESS");
					transOwner = true;
					ClusterRecover(conn, failedRecords);
					recovered = true;
				}
			}
			CommitConnection(conn, openNewTransaction: false);
		}
		catch (JobPersistenceException)
		{
			RollbackConnection(conn);
			throw;
		}
		finally
		{
			try
			{
				ReleaseLock("TRIGGER_ACCESS", transOwner);
			}
			finally
			{
				try
				{
					ReleaseLock("STATE_ACCESS", transStateOwner);
				}
				finally
				{
					CleanupConnection(conn);
				}
			}
		}
		firstCheckIn = false;
		return recovered;
	}

	/// <summary>
	/// Get a list of all scheduler instances in the cluster that may have failed.
	/// This includes this scheduler if it is checking in for the first time.
	/// </summary>
	protected virtual IList<SchedulerStateRecord> FindFailedInstances(ConnectionAndTransactionHolder conn)
	{
		try
		{
			List<SchedulerStateRecord> failedInstances = new List<SchedulerStateRecord>();
			bool foundThisScheduler = false;
			IList<SchedulerStateRecord> states = Delegate.SelectSchedulerStateRecords(conn, null);
			foreach (SchedulerStateRecord rec in states)
			{
				if (rec.SchedulerInstanceId.Equals(InstanceId))
				{
					foundThisScheduler = true;
					if (firstCheckIn)
					{
						failedInstances.Add(rec);
					}
				}
				else if (CalcFailedIfAfter(rec) < SystemTime.UtcNow())
				{
					failedInstances.Add(rec);
				}
			}
			if (firstCheckIn)
			{
				failedInstances.AddRange(FindOrphanedFailedInstances(conn, states));
			}
			if (!foundThisScheduler && !firstCheckIn)
			{
				Log.Warn("This scheduler instance (" + InstanceId + ") is still active but was recovered by another instance in the cluster.  This may cause inconsistent behavior.");
			}
			return failedInstances;
		}
		catch (Exception e)
		{
			lastCheckin = SystemTime.UtcNow();
			throw new JobPersistenceException("Failure identifying failed instances when checking-in: " + e.Message, e);
		}
	}

	/// <summary>
	/// Create dummy <see cref="T:Quartz.Impl.AdoJobStore.SchedulerStateRecord" /> objects for fired triggers
	/// that have no scheduler state record.  Checkin timestamp and interval are
	/// left as zero on these dummy <see cref="T:Quartz.Impl.AdoJobStore.SchedulerStateRecord" /> objects.
	/// </summary>
	/// <param name="conn"></param>
	/// <param name="schedulerStateRecords">List of all current <see cref="T:Quartz.Impl.AdoJobStore.SchedulerStateRecord" />s</param>
	private IList<SchedulerStateRecord> FindOrphanedFailedInstances(ConnectionAndTransactionHolder conn, IList<SchedulerStateRecord> schedulerStateRecords)
	{
		IList<SchedulerStateRecord> orphanedInstances = new List<SchedulerStateRecord>();
		Quartz.Collection.ISet<string> allFiredTriggerInstanceNames = Delegate.SelectFiredTriggerInstanceNames(conn);
		if (allFiredTriggerInstanceNames.Count > 0)
		{
			foreach (SchedulerStateRecord rec in schedulerStateRecords)
			{
				allFiredTriggerInstanceNames.Remove(rec.SchedulerInstanceId);
			}
			foreach (string name in allFiredTriggerInstanceNames)
			{
				SchedulerStateRecord orphanedInstance = new SchedulerStateRecord();
				orphanedInstance.SchedulerInstanceId = name;
				orphanedInstances.Add(orphanedInstance);
				Log.Warn("Found orphaned fired triggers for instance: " + orphanedInstance.SchedulerInstanceId);
			}
		}
		return orphanedInstances;
	}

	protected DateTimeOffset CalcFailedIfAfter(SchedulerStateRecord rec)
	{
		TimeSpan passed = SystemTime.UtcNow() - lastCheckin;
		TimeSpan ts = ((rec.CheckinInterval > passed) ? rec.CheckinInterval : passed);
		return rec.CheckinTimestamp.Add(ts).Add(TimeSpan.FromMilliseconds(7500.0));
	}

	protected virtual IList<SchedulerStateRecord> ClusterCheckIn(ConnectionAndTransactionHolder conn)
	{
		IList<SchedulerStateRecord> failedInstances = FindFailedInstances(conn);
		try
		{
			lastCheckin = SystemTime.UtcNow();
			if (Delegate.UpdateSchedulerState(conn, InstanceId, lastCheckin) == 0)
			{
				Delegate.InsertSchedulerState(conn, InstanceId, lastCheckin, ClusterCheckinInterval);
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Failure updating scheduler state when checking-in: " + e.Message, e);
		}
		return failedInstances;
	}

	protected virtual void ClusterRecover(ConnectionAndTransactionHolder conn, IList<SchedulerStateRecord> failedInstances)
	{
		if (failedInstances.Count <= 0)
		{
			return;
		}
		long recoverIds = SystemTime.UtcNow().Ticks;
		LogWarnIfNonZero(failedInstances.Count, "ClusterManager: detected " + failedInstances.Count + " failed or restarted instances.");
		try
		{
			foreach (SchedulerStateRecord rec in failedInstances)
			{
				Log.Info("ClusterManager: Scanning for instance \"" + rec.SchedulerInstanceId + "\"'s failed in-progress jobs.");
				IList<FiredTriggerRecord> firedTriggerRecs = Delegate.SelectInstancesFiredTriggerRecords(conn, rec.SchedulerInstanceId);
				int acquiredCount = 0;
				int recoveredCount = 0;
				int otherCount = 0;
				Quartz.Collection.HashSet<TriggerKey> triggerKeys = new Quartz.Collection.HashSet<TriggerKey>();
				foreach (FiredTriggerRecord ftRec in firedTriggerRecs)
				{
					TriggerKey tKey = ftRec.TriggerKey;
					JobKey jKey = ftRec.JobKey;
					triggerKeys.Add(tKey);
					if (ftRec.FireInstanceState.Equals("BLOCKED"))
					{
						Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jKey, "WAITING", "BLOCKED");
					}
					else if (ftRec.FireInstanceState.Equals("PAUSED_BLOCKED"))
					{
						Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jKey, "PAUSED", "PAUSED_BLOCKED");
					}
					if (ftRec.FireInstanceState.Equals("ACQUIRED"))
					{
						Delegate.UpdateTriggerStateFromOtherState(conn, tKey, "WAITING", "ACQUIRED");
						acquiredCount++;
					}
					else if (ftRec.JobRequestsRecovery)
					{
						if (JobExists(conn, jKey))
						{
							SimpleTriggerImpl rcvryTrig = new SimpleTriggerImpl("recover_" + rec.SchedulerInstanceId + "_" + Convert.ToString(recoverIds++, CultureInfo.InvariantCulture), "RECOVERING_JOBS", ftRec.FireTimestamp);
							rcvryTrig.JobName = jKey.Name;
							rcvryTrig.JobGroup = jKey.Group;
							rcvryTrig.MisfireInstruction = 1;
							rcvryTrig.Priority = ftRec.Priority;
							JobDataMap jd = Delegate.SelectTriggerJobDataMap(conn, tKey);
							jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_NAME", tKey.Name);
							jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_GROUP", tKey.Group);
							jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_FIRETIME_IN_MILLISECONDS_AS_STRING", Convert.ToString(ftRec.FireTimestamp, CultureInfo.InvariantCulture));
							rcvryTrig.JobDataMap = jd;
							rcvryTrig.ComputeFirstFireTimeUtc(null);
							StoreTrigger(conn, rcvryTrig, null, replaceExisting: false, "WAITING", forceState: false, recovering: true);
							recoveredCount++;
						}
						else
						{
							Log.Warn(string.Concat("ClusterManager: failed job '", jKey, "' no longer exists, cannot schedule recovery."));
							otherCount++;
						}
					}
					else
					{
						otherCount++;
					}
					if (ftRec.JobDisallowsConcurrentExecution)
					{
						Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jKey, "WAITING", "BLOCKED");
						Delegate.UpdateTriggerStatesForJobFromOtherState(conn, jKey, "PAUSED", "PAUSED_BLOCKED");
					}
				}
				Delegate.DeleteFiredTriggers(conn, rec.SchedulerInstanceId);
				int completeCount = 0;
				foreach (TriggerKey triggerKey in triggerKeys)
				{
					if (Delegate.SelectTriggerState(conn, triggerKey).Equals("COMPLETE"))
					{
						IList<FiredTriggerRecord> firedTriggers = Delegate.SelectFiredTriggerRecords(conn, triggerKey.Name, triggerKey.Group);
						if (firedTriggers.Count == 0 && RemoveTrigger(conn, triggerKey))
						{
							completeCount++;
						}
					}
				}
				LogWarnIfNonZero(acquiredCount, "ClusterManager: ......Freed " + acquiredCount + " acquired trigger(s).");
				LogWarnIfNonZero(completeCount, "ClusterManager: ......Deleted " + completeCount + " complete triggers(s).");
				LogWarnIfNonZero(recoveredCount, "ClusterManager: ......Scheduled " + recoveredCount + " recoverable job(s) for recovery.");
				LogWarnIfNonZero(otherCount, "ClusterManager: ......Cleaned-up " + otherCount + " other failed job(s).");
				if (!rec.SchedulerInstanceId.Equals(InstanceId))
				{
					Delegate.DeleteSchedulerState(conn, rec.SchedulerInstanceId);
				}
			}
		}
		catch (Exception e)
		{
			throw new JobPersistenceException("Failure recovering jobs: " + e.Message, e);
		}
	}

	protected virtual void LogWarnIfNonZero(int val, string warning)
	{
		if (val > 0)
		{
			Log.Info(warning);
		}
		else
		{
			Log.Debug(warning);
		}
	}

	/// <summary>
	/// Cleanup the given database connection.  This means restoring
	/// any modified auto commit or transaction isolation connection
	/// attributes, and then closing the underlying connection.
	/// </summary>
	///
	/// <remarks>
	/// This is separate from closeConnection() because the Spring 
	/// integration relies on being able to overload closeConnection() and
	/// expects the same connection back that it originally returned
	/// from the datasource. 
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.CloseConnection(Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder)" />
	protected virtual void CleanupConnection(ConnectionAndTransactionHolder conn)
	{
		if (conn != null)
		{
			CloseConnection(conn);
		}
	}

	/// <summary> 
	/// Closes the supplied connection.
	/// </summary>
	/// <param name="cth">(Optional)</param>
	protected virtual void CloseConnection(ConnectionAndTransactionHolder cth)
	{
		if (cth.Connection != null)
		{
			try
			{
				cth.Connection.Close();
			}
			catch (Exception e)
			{
				Log.Error("Unexpected exception closing Connection.  This is often due to a Connection being returned after or during shutdown.", e);
			}
		}
	}

	/// <summary>
	/// Rollback the supplied connection.
	/// </summary>
	/// <param name="cth">(Optional)
	/// </param>
	/// <throws>  JobPersistenceException thrown if a SQLException occurs when the </throws>
	/// <summary> connection is rolled back
	/// </summary>
	protected virtual void RollbackConnection(ConnectionAndTransactionHolder cth)
	{
		if (cth == null)
		{
			log.Warn("ConnectionAndTransactionHolder passed to RollbackConnection was null, ignoring");
		}
		else if (cth.Transaction != null)
		{
			try
			{
				CheckNotZombied(cth);
				cth.Transaction.Rollback();
			}
			catch (Exception e)
			{
				Log.Error("Couldn't rollback ADO.NET connection. " + e.Message, e);
			}
		}
	}

	/// <summary>
	/// Commit the supplied connection.
	/// </summary>
	/// <param name="cth">The CTH.</param>
	/// <param name="openNewTransaction">if set to <c>true</c> opens a new transaction.</param>
	/// <throws>JobPersistenceException thrown if a SQLException occurs when the </throws>
	protected virtual void CommitConnection(ConnectionAndTransactionHolder cth, bool openNewTransaction)
	{
		if (cth == null)
		{
			log.Error("ConnectionAndTransactionHolder passed to CommitConnection was null, ignoring");
		}
		else
		{
			if (cth.Transaction == null)
			{
				return;
			}
			try
			{
				CheckNotZombied(cth);
				IsolationLevel il = cth.Transaction.IsolationLevel;
				cth.Transaction.Commit();
				if (openNewTransaction)
				{
					cth.Transaction = cth.Connection.BeginTransaction(il);
				}
			}
			catch (Exception e)
			{
				throw new JobPersistenceException("Couldn't commit ADO.NET transaction. " + e.Message, e);
			}
		}
	}

	/// <summary>
	/// Execute the given callback in a transaction. Depending on the JobStore, 
	/// the surrounding transaction may be assumed to be already present 
	/// (managed).  
	/// </summary>
	/// <remarks>
	/// This method just forwards to ExecuteInLock() with a null lockName.
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInLock(System.String,System.Action{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder})" />
	protected object ExecuteWithoutLock(Func<ConnectionAndTransactionHolder, object> txCallback)
	{
		return ExecuteInLock(null, txCallback);
	}

	/// <summary>
	/// Execute the given callback having acquired the given lock.  
	/// Depending on the JobStore, the surrounding transaction may be 
	/// assumed to be already present (managed).  This version is just a 
	/// handy wrapper around executeInLock that doesn't require a return
	/// value.
	/// </summary>
	/// <param name="lockName">
	/// The name of the lock to acquire, for example 
	/// "TRIGGER_ACCESS".  If null, then no lock is acquired, but the
	/// lockCallback is still executed in a transaction. 
	/// </param>
	/// <param name="txCallback">
	/// The callback to excute after having acquired the given lock.
	/// </param>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInLock(System.String,System.Func{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.Object})" />
	protected void ExecuteInLock(string lockName, Action<ConnectionAndTransactionHolder> txCallback)
	{
		ExecuteInLock(lockName, delegate(ConnectionAndTransactionHolder conn)
		{
			txCallback(conn);
			return null;
		});
	}

	/// <summary>
	/// Execute the given callback having acquired the given lock.  
	/// Depending on the JobStore, the surrounding transaction may be 
	/// assumed to be already present (managed).
	/// </summary> 
	/// <param name="lockName">
	/// The name of the lock to acquire, for example 
	/// "TRIGGER_ACCESS".  If null, then no lock is acquired, but the
	/// lockCallback is still executed in a transaction. 
	/// </param>
	/// <param name="txCallback">
	/// The callback to excute after having acquired the given lock.
	/// </param>
	protected abstract object ExecuteInLock(string lockName, Func<ConnectionAndTransactionHolder, object> txCallback);

	/// <summary>
	/// Execute the given callback having optionally acquired the given lock.
	/// This uses the non-managed transaction connection.  This version is just a 
	/// handy wrapper around executeInNonManagedTXLock that doesn't require a return
	/// value.
	/// </summary>
	/// <param name="lockName">
	/// The name of the lock to acquire, for example 
	/// "TRIGGER_ACCESS".  If null, then no lock is acquired, but the
	/// lockCallback is still executed in a non-managed transaction. 
	/// </param>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInNonManagedTXLock(System.String,System.Func{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.Object})" />
	/// <param name="txCallback">
	/// The callback to excute after having acquired the given lock.
	/// </param>
	protected void ExecuteInNonManagedTXLock(string lockName, Action<ConnectionAndTransactionHolder> txCallback)
	{
		ExecuteInNonManagedTXLock(lockName, delegate(ConnectionAndTransactionHolder conn)
		{
			txCallback(conn);
			return null;
		});
	}

	/// <summary>
	/// Execute the given callback having optionally acquired the given lock.
	/// This uses the non-managed transaction connection.
	/// </summary>
	/// <param name="lockName">
	/// The name of the lock to acquire, for example 
	/// "TRIGGER_ACCESS".  If null, then no lock is acquired, but the
	/// lockCallback is still executed in a non-managed transaction. 
	/// </param>
	/// <param name="txCallback">
	/// The callback to excute after having acquired the given lock.
	/// </param>
	protected object ExecuteInNonManagedTXLock(string lockName, Func<ConnectionAndTransactionHolder, object> txCallback)
	{
		bool transOwner = false;
		ConnectionAndTransactionHolder conn = null;
		try
		{
			if (lockName != null)
			{
				if (LockHandler.RequiresConnection)
				{
					conn = GetNonManagedTXConnection();
				}
				transOwner = LockHandler.ObtainLock(DbProvider.Metadata, conn, lockName);
			}
			if (conn == null)
			{
				conn = GetNonManagedTXConnection();
			}
			object result = txCallback(conn);
			CommitConnection(conn, openNewTransaction: false);
			DateTimeOffset? sigTime = ClearAndGetSignalSchedulingChangeOnTxCompletion();
			if (sigTime.HasValue)
			{
				SignalSchedulingChangeImmediately(sigTime);
			}
			return result;
		}
		catch (JobPersistenceException)
		{
			RollbackConnection(conn);
			throw;
		}
		catch (Exception e)
		{
			RollbackConnection(conn);
			throw new JobPersistenceException("Unexpected runtime exception: " + e.Message, e);
		}
		finally
		{
			try
			{
				ReleaseLock(lockName, transOwner);
			}
			finally
			{
				CleanupConnection(conn);
			}
		}
	}

	private static void CheckNotZombied(ConnectionAndTransactionHolder cth)
	{
		if (cth == null)
		{
			throw new ArgumentNullException("cth", "Connnection-transaction pair cannot be null");
		}
		if (cth.Transaction != null && cth.Transaction.Connection == null)
		{
			throw new DataException("Transaction not connected, or was disconnected");
		}
	}
}
