using System;
using System.Globalization;
using System.Threading;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

/// <summary> 
/// Internal in-memory lock handler for providing thread/resource locking in 
/// order to protect resources from being altered by multiple threads at the 
/// same time.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class SimpleSemaphore : ISemaphore
{
	private const string KeyThreadLockOwners = "qrtz_ssemaphore_lock_owners";

	private readonly ILog log;

	private readonly HashSet<string> locks = new HashSet<string>();

	/// <summary>
	/// Gets the thread locks.
	/// </summary>
	/// <value>The thread locks.</value>
	private static HashSet<string> ThreadLocks
	{
		get
		{
			HashSet<string> threadLocks = LogicalThreadContext.GetData<HashSet<string>>("qrtz_ssemaphore_lock_owners");
			if (threadLocks == null)
			{
				threadLocks = new HashSet<string>();
				LogicalThreadContext.SetData("qrtz_ssemaphore_lock_owners", threadLocks);
			}
			return threadLocks;
		}
	}

	/// <summary>
	/// Whether this Semaphore implementation requires a database connection for
	/// its lock management operations.
	/// </summary>
	/// <value></value>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.SimpleSemaphore.IsLockOwner(System.String)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.SimpleSemaphore.ObtainLock(Quartz.Impl.AdoJobStore.Common.DbMetadata,Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.String)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.SimpleSemaphore.ReleaseLock(System.String)" />
	public bool RequiresConnection => false;

	public SimpleSemaphore()
	{
		log = LogManager.GetLogger(GetType());
	}

	/// <summary> 
	/// Grants a lock on the identified resource to the calling thread (blocking
	/// until it is available).
	/// </summary>
	/// <returns>True if the lock was obtained.</returns>
	public virtual bool ObtainLock(DbMetadata metadata, ConnectionAndTransactionHolder conn, string lockName)
	{
		lock (this)
		{
			lockName = string.Intern(lockName);
			if (log.IsDebugEnabled)
			{
				log.Debug("Lock '" + lockName + "' is desired by: " + Thread.CurrentThread.Name);
			}
			if (!IsLockOwner(lockName))
			{
				if (log.IsDebugEnabled)
				{
					log.Debug("Lock '" + lockName + "' is being obtained: " + Thread.CurrentThread.Name);
				}
				while (locks.Contains(lockName))
				{
					try
					{
						Monitor.Wait(this);
					}
					catch (ThreadInterruptedException)
					{
						if (log.IsDebugEnabled)
						{
							log.Debug("Lock '" + lockName + "' was not obtained by: " + Thread.CurrentThread.Name);
						}
					}
				}
				if (log.IsDebugEnabled)
				{
					log.Debug(string.Format(CultureInfo.InvariantCulture, "Lock '{0}' given to: {1}", new object[2]
					{
						lockName,
						Thread.CurrentThread.Name
					}));
				}
				ThreadLocks.Add(lockName);
				locks.Add(lockName);
			}
			else if (log.IsDebugEnabled)
			{
				log.Debug(string.Format(CultureInfo.InvariantCulture, "Lock '{0}' already owned by: {1} -- but not owner!", new object[2]
				{
					lockName,
					Thread.CurrentThread.Name
				}), new Exception("stack-trace of wrongful returner"));
			}
			return true;
		}
	}

	/// <summary> Release the lock on the identified resource if it is held by the calling
	/// thread.
	/// </summary>
	public virtual void ReleaseLock(string lockName)
	{
		lock (this)
		{
			lockName = string.Intern(lockName);
			if (IsLockOwner(lockName))
			{
				if (log.IsDebugEnabled)
				{
					log.Debug(string.Format(CultureInfo.InvariantCulture, "Lock '{0}' retuned by: {1}", new object[2]
					{
						lockName,
						Thread.CurrentThread.Name
					}));
				}
				ThreadLocks.Remove(lockName);
				locks.Remove(lockName);
				Monitor.PulseAll(this);
			}
			else if (log.IsDebugEnabled)
			{
				log.Debug(string.Format(CultureInfo.InvariantCulture, "Lock '{0}' attempt to retun by: {1} -- but not owner!", new object[2]
				{
					lockName,
					Thread.CurrentThread.Name
				}), new Exception("stack-trace of wrongful returner"));
			}
		}
	}

	/// <summary> 
	/// Determine whether the calling thread owns a lock on the identified
	/// resource.
	/// </summary>
	public virtual bool IsLockOwner(string lockName)
	{
		lock (this)
		{
			lockName = string.Intern(lockName);
			return ThreadLocks.Contains(lockName);
		}
	}
}
