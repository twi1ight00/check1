namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// This is a driver delegate for the MySQL ADO.NET driver.
/// </summary>
/// <author>Marko Lahma</author>
public class MySQLDelegate : StdAdoDelegate
{
	/// <summary>
	/// Gets the select next trigger to acquire SQL clause.
	/// MySQL version with LIMIT support.
	/// </summary>
	/// <returns></returns>
	protected override string GetSelectNextTriggerToAcquireSql(int maxCount)
	{
		return StdAdoConstants.SqlSelectNextTriggerToAcquire + " LIMIT " + maxCount;
	}
}
