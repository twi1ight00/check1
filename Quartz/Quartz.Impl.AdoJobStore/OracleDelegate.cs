using System;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// This is a driver delegate for the Oracle database.
/// </summary>
/// <author>Marko Lahma</author>
public class OracleDelegate : StdAdoDelegate
{
	/// <summary>
	/// Creates the SQL for select next trigger to acquire.
	/// </summary>
	protected override string GetSelectNextTriggerToAcquireSql(int maxCount)
	{
		string sqlSelectNextTriggerToAcquire = StdAdoConstants.SqlSelectNextTriggerToAcquire;
		int whereEndIdx = sqlSelectNextTriggerToAcquire.IndexOf("WHERE") + 6;
		string beginningAndWhere = sqlSelectNextTriggerToAcquire.Substring(0, whereEndIdx);
		string theRest = sqlSelectNextTriggerToAcquire.Substring(whereEndIdx);
		return beginningAndWhere + " rownum <= " + maxCount + " AND " + theRest;
	}

	/// <summary>
	/// Gets the db presentation for boolean value. For Oracle we use true/false of "1"/"0".
	/// </summary>
	/// <param name="booleanValue">Value to map to database.</param>
	/// <returns></returns>
	public override object GetDbBooleanValue(bool booleanValue)
	{
		if (!booleanValue)
		{
			return "0";
		}
		return "1";
	}

	public override bool GetBooleanFromDbValue(object columnValue)
	{
		if (columnValue != null && columnValue != DBNull.Value)
		{
			return Convert.ToInt32(columnValue) == 1;
		}
		throw new ArgumentException("Value must be non-null.");
	}
}
