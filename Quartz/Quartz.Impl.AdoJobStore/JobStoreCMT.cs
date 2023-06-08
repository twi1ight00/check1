using System;
using System.Data;
using System.Data.SqlClient;
using Quartz.Spi;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
///  <see cref="T:Quartz.Impl.AdoJobStore.JobStoreCMT" /> is meant to be used in an application-server
///  or other software framework environment that provides 
///  container-managed-transactions. No commit / rollback will be handled by this class.
///  </summary>
///  <remarks>
///  If you need commit / rollback, use <see cref="T:Quartz.Impl.AdoJobStore.JobStoreTX" />
///  instead.
///  </remarks>
///  <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
///  <author>James House</author>
///  <author>Srinivas Venkatarangaiah</author>
///  <author>Marko Lahma (.NET)</author>
public class JobStoreCMT : JobStoreSupport
{
	/// <summary>
	/// Instructs this job store whether connections should be automatically opened.
	/// </summary>
	public virtual bool OpenConnection { protected get; set; }

	/// <summary>
	/// Called by the QuartzScheduler before the <see cref="T:Quartz.Spi.IJobStore" /> is
	/// used, in order to give the it a chance to Initialize.
	/// </summary>
	/// <param name="loadHelper"></param>
	/// <param name="signaler"></param>
	public override void Initialize(ITypeLoadHelper loadHelper, ISchedulerSignaler signaler)
	{
		if (LockHandler == null)
		{
			UseDBLocks = true;
		}
		base.Initialize(loadHelper, signaler);
		base.Log.Info("JobStoreCMT initialized.");
	}

	/// <summary>
	/// Called by the QuartzScheduler to inform the <see cref="T:Quartz.Spi.IJobStore" /> that
	/// it should free up all of it's resources because the scheduler is
	/// shutting down.
	/// </summary>
	public override void Shutdown()
	{
		base.Shutdown();
		try
		{
			ConnectionManager.Shutdown(DataSource);
		}
		catch (SqlException sqle)
		{
			base.Log.Warn("Database connection shutdown unsuccessful.", sqle);
		}
	}

	/// <summary>
	/// Gets the non managed TX connection.
	/// </summary>
	/// <returns></returns>
	protected override ConnectionAndTransactionHolder GetNonManagedTXConnection()
	{
		IDbConnection conn;
		try
		{
			conn = ConnectionManager.GetConnection(DataSource);
			if (OpenConnection)
			{
				conn.Open();
			}
		}
		catch (SqlException sqle)
		{
			throw new JobPersistenceException($"Failed to obtain DB connection from data source '{DataSource}': {sqle}", sqle);
		}
		catch (Exception e)
		{
			throw new JobPersistenceException($"Failed to obtain DB connection from data source '{DataSource}': {e}", e);
		}
		if (conn == null)
		{
			throw new JobPersistenceException($"Could not get connection from DataSource '{DataSource}'");
		}
		return new ConnectionAndTransactionHolder(conn, null);
	}

	/// <summary>
	/// Execute the given callback having optionally acquired the given lock.  
	/// Because CMT assumes that the connection is already part of a managed
	/// transaction, it does not attempt to commit or rollback the 
	/// enclosing transaction.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInNonManagedTXLock(System.String,System.Func{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.Object})" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreTX.ExecuteInLock(System.String,System.Func{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.Object})" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.GetNonManagedTXConnection" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.GetConnection" />
	/// <param name="lockName">
	/// The name of the lock to acquire, for example 
	/// "TRIGGER_ACCESS".  If null, then no lock is acquired, but the
	/// txCallback is still executed in a transaction.
	/// </param>
	/// <param name="txCallback">Callback to execute.</param>
	protected override object ExecuteInLock(string lockName, Func<ConnectionAndTransactionHolder, object> txCallback)
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
				transOwner = LockHandler.ObtainLock(base.DbMetadata, conn, lockName);
			}
			if (conn == null)
			{
				conn = GetNonManagedTXConnection();
			}
			return txCallback(conn);
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
}
