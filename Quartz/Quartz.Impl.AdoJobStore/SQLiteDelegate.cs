namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// This is a driver delegate for the SQLiteDelegate ADO.NET driver.
/// </summary>
/// <author>Marko Lahma</author>
public class SQLiteDelegate : StdAdoDelegate
{
	/// <summary>
	/// Gets the select next trigger to acquire SQL clause.
	/// SQLite version with LIMIT support.
	/// </summary>
	/// <returns></returns>
	protected override string GetSelectNextTriggerToAcquireSql(int maxCount)
	{
		return StdAdoConstants.SqlSelectNextTriggerToAcquire + " LIMIT " + maxCount;
	}
}
