using System;
using System.Data;
using System.Globalization;
using System.Threading;
using Quartz.Impl.AdoJobStore.Common;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Provide thread/resource locking in order to protect
/// resources from being altered by multiple threads at the same time using
/// a db row update.
/// </summary>
/// <remarks>
/// <para>
/// <b>Note:</b> This Semaphore implementation is useful for databases that do
/// not support row locking via "SELECT FOR UPDATE" or SQL Server's type syntax.
/// </para>
/// <para>
/// As of Quartz.NET 2.0 version there is no need to use this implementation for 
/// SQL Server databases.
/// </para>
/// </remarks>
/// <author>Marko Lahma (.NET)</author>
public class UpdateLockRowSemaphore : DBSemaphore
{
	public static readonly string SqlUpdateForLock = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = {3} WHERE {4} = {5} AND {6} = @lockName", "{0}", "LOCKS", "LOCK_NAME", "LOCK_NAME", "SCHED_NAME", "{1}", "LOCK_NAME");

	public static readonly string SqlInsertLock = string.Format("INSERT INTO {0}{1}({2}, {3}) VALUES ({4}, @lockName)", "{0}", "LOCKS", "SCHED_NAME", "LOCK_NAME", "{1}");

	protected string UpdateLockRowSQL
	{
		get
		{
			return base.SQL;
		}
		set
		{
			base.SQL = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore" /> class.
	/// </summary>
	public UpdateLockRowSemaphore(IDbProvider provider)
		: base("QRTZ_", null, SqlUpdateForLock, SqlInsertLock, provider)
	{
	}

	/// <summary>
	/// Execute the SQL that will lock the proper database row.
	/// </summary>
	/// <param name="conn"></param>
	/// <param name="lockName"></param>
	/// <param name="expandedSQL"></param>
	/// <param name="expandedInsertSQL"></param>
	protected override void ExecuteSQL(ConnectionAndTransactionHolder conn, string lockName, string expandedSQL, string expandedInsertSQL)
	{
		int count = 0;
		do
		{
			count++;
			try
			{
				using IDbCommand cmd = base.AdoUtil.PrepareCommand(conn, expandedSQL);
				base.AdoUtil.AddCommandParameter(cmd, "lockName", lockName);
				if (base.Log.IsDebugEnabled)
				{
					base.Log.DebugFormat("Lock '{0}' is being obtained: {1}", lockName, Thread.CurrentThread.Name);
				}
				int numUpdate = cmd.ExecuteNonQuery();
				if (numUpdate >= 1)
				{
					continue;
				}
				if (base.Log.IsDebugEnabled)
				{
					base.Log.DebugFormat("Inserting new lock row for lock: '{0}' being obtained by thread: {1}", lockName, Thread.CurrentThread.Name);
				}
				using IDbCommand cmd2 = base.AdoUtil.PrepareCommand(conn, expandedInsertSQL);
				base.AdoUtil.AddCommandParameter(cmd2, "lockName", lockName);
				int res = cmd2.ExecuteNonQuery();
				if (res != 1)
				{
					if (count < 3)
					{
						try
						{
							Thread.Sleep(TimeSpan.FromSeconds(1.0));
						}
						catch (ThreadInterruptedException)
						{
							Thread.CurrentThread.Interrupt();
						}
						continue;
					}
					throw new Exception(AdoJobStoreUtil.ReplaceTablePrefix("No row exists, and one could not be inserted in table {0}LOCKS for lock named: " + lockName, base.TablePrefix, base.SchedulerNameLiteral));
				}
				break;
			}
			catch (Exception sqle)
			{
				if (base.Log.IsDebugEnabled)
				{
					base.Log.DebugFormat("Lock '{0}' was not obtained by: {1}{2}", lockName, Thread.CurrentThread.Name, (count < 3) ? " - will try again." : "");
				}
				if (count < 3)
				{
					try
					{
						Thread.Sleep(TimeSpan.FromSeconds(1.0));
					}
					catch (ThreadInterruptedException)
					{
						Thread.CurrentThread.Interrupt();
					}
					continue;
				}
				throw new LockException("Failure obtaining db row lock: " + sqle.Message, sqle);
			}
		}
		while (count < 2);
	}
}
