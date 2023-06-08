using System;
using System.Data;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// A SQL Server specific driver delegate.
/// </summary>
/// <author>Marko Lahma</author>
public class SqlServerDelegate : StdAdoDelegate
{
	/// <summary>
	/// Gets the select next trigger to acquire SQL clause.
	/// SQL Server specific version with TOP functionality
	/// </summary>
	/// <returns></returns>
	protected override string GetSelectNextTriggerToAcquireSql(int maxCount)
	{
		string sqlSelectNextTriggerToAcquire = StdAdoConstants.SqlSelectNextTriggerToAcquire;
		return "SELECT TOP " + maxCount + " " + sqlSelectNextTriggerToAcquire.Substring(6);
	}

	public override void AddCommandParameter(IDbCommand cmd, string paramName, object paramValue, Enum dataType)
	{
		if (paramValue is bool && dataType == null)
		{
			paramValue = (((bool)paramValue) ? 1 : 0);
		}
		base.AddCommandParameter(cmd, paramName, paramValue, dataType);
	}
}
