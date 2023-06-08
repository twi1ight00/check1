using System;
using System.Data;
using System.Globalization;
using System.Threading;
using Quartz.Impl.AdoJobStore.Common;

namespace Quartz.Impl.AdoJobStore;

/// <summary> 
/// Internal database based lock handler for providing thread/resource locking 
/// in order to protect resources from being altered by multiple threads at the 
/// same time.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class StdRowLockSemaphore : DBSemaphore
{
	public static readonly string SelectForLock = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @lockName FOR UPDATE", "{0}", "LOCKS", "SCHED_NAME", "{1}", "LOCK_NAME");

	public static readonly string InsertLock = string.Format(CultureInfo.InstalledUICulture, "INSERT INTO {0}{1}({2}, {3}) VALUES ({4}, @lockName)", "{0}", "LOCKS", "SCHED_NAME", "LOCK_NAME", "{1}");

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.StdRowLockSemaphore" /> class.
	/// </summary>
	/// <param name="tablePrefix">The table prefix.</param>
	/// <param name="schedName">the scheduler name</param>
	/// <param name="selectWithLockSQL">The select with lock SQL.</param>
	/// <param name="dbProvider"></param>
	public StdRowLockSemaphore(string tablePrefix, string schedName, string selectWithLockSQL, IDbProvider dbProvider)
		: base(tablePrefix, schedName, selectWithLockSQL ?? SelectForLock, InsertLock, dbProvider)
	{
	}

	/// <summary>
	/// Execute the SQL select for update that will lock the proper database row.
	/// </summary>
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
				bool found;
				using (IDataReader rs = cmd.ExecuteReader())
				{
					if (base.Log.IsDebugEnabled)
					{
						base.Log.DebugFormat("Lock '{0}' is being obtained: {1}", lockName, Thread.CurrentThread.Name);
					}
					found = rs.Read();
				}
				if (found)
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
