using System;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// Sql Server 查询转换器
/// </summary>
public class SqlServerQueryConverter : SqlQueryConvertBase
{
	/// <inheritdoc />
	protected override string ParameterFlag => "@p";

	/// <inheritdoc />
	public override string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		if (string.IsNullOrWhiteSpace(sqlExpress))
		{
			return sqlExpress;
		}
		if (queryCondition.IsNotNull())
		{
			string sqlWith = string.Empty;
			int endWithIndex = sqlExpress.IndexOf("#EndWith#", StringComparison.OrdinalIgnoreCase);
			if (endWithIndex > 0)
			{
				sqlWith = sqlExpress.Substring(0, endWithIndex);
				sqlExpress = sqlExpress.Substring(endWithIndex + 9);
			}
			QueryCondition condition = new QueryCondition();
			condition.QueryItems = queryCondition.QueryItems;
			string sqlStatement = GetSql(sqlExpress, condition, indexOrder, formatParameters, parameterStartIndex);
			if (!string.IsNullOrEmpty(sqlStatement))
			{
				return sqlWith + $" select count(*) from ( {sqlStatement}) tc";
			}
		}
		else if (formatParameters.IsNotNull())
		{
			string sqlWith = string.Empty;
			int endWithIndex = sqlExpress.IndexOf("#EndWith#", StringComparison.OrdinalIgnoreCase);
			if (endWithIndex > 0)
			{
				sqlWith = sqlExpress.Substring(0, endWithIndex);
				sqlExpress = sqlExpress.Substring(endWithIndex + 9);
			}
			string sqlStatement = GetSql(sqlExpress, null, indexOrder, formatParameters, parameterStartIndex);
			if (!string.IsNullOrEmpty(sqlStatement))
			{
				return sqlWith + $" select count(*) from ( {sqlStatement}) tc";
			}
		}
		return sqlExpress;
	}

	/// <inheritdoc />
	public override string GetSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		if (string.IsNullOrWhiteSpace(sqlExpress))
		{
			return sqlExpress;
		}
		if (queryCondition.IsNull())
		{
			queryCondition = new QueryCondition();
		}
		string sqlWhereDefault = string.Empty;
		if (sqlExpress.IndexOf("where", StringComparison.OrdinalIgnoreCase) < 0)
		{
			sqlWhereDefault = " where 1=1";
		}
		PagingInfo pagingInfo = queryCondition.PagingSetting;
		string sqlWith = string.Empty;
		if (pagingInfo != null)
		{
			int endWithIndex = sqlExpress.IndexOf("#EndWith#", StringComparison.OrdinalIgnoreCase);
			if (endWithIndex > 0)
			{
				sqlWith = sqlExpress.Substring(0, endWithIndex);
				sqlExpress = sqlExpress.Substring(endWithIndex + 9);
			}
			sqlExpress = sqlExpress.Substring(sqlExpress.IndexOf("Select", StringComparison.OrdinalIgnoreCase) + 6);
		}
		else
		{
			int endWithIndex = sqlExpress.IndexOf("#EndWith#", StringComparison.OrdinalIgnoreCase);
			if (endWithIndex > 0)
			{
				sqlExpress = sqlExpress.Replace("#EndWith#", string.Empty);
			}
		}
		string sqlStatement;
		if (formatParameters != null)
		{
			string sqlWhere = sqlWhereDefault + GetWhereSqlClause(queryCondition.QueryItems, indexOrder, parameterStartIndex);
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				formatParameters = IEnumerableTExtensions.Prepend(formatParameters, sqlWhere).ToArray();
			}
			else if (Utility.GetMaxStringFormatIndex(sqlExpress) > formatParameters.Length - 1)
			{
				formatParameters = IEnumerableTExtensions.Prepend(formatParameters, sqlWhere).ToArray();
			}
			sqlStatement = string.Format(sqlExpress, formatParameters);
		}
		else
		{
			sqlStatement = string.Format(sqlExpress, sqlWhereDefault + GetWhereSqlClause(queryCondition.QueryItems, indexOrder, parameterStartIndex));
		}
		if (pagingInfo != null && !string.IsNullOrEmpty(sqlStatement))
		{
			return string.Format(sqlWith + " SELECT * FROM (\r\n                        select top 100 percent ROW_NUMBER() OVER (ORDER BY " + pagingInfo.GetSortDesc() + ") AS RowNum," + sqlStatement + " order by " + pagingInfo.GetSortDesc() + "\r\n                        ) T2\r\n                        WHERE RowNum >  {1} * {0} AND RowNum <=  {0}*({1}+1)", pagingInfo.PageCount, pagingInfo.PageIndex);
		}
		return sqlStatement;
	}

	/// <inheritdoc />
	protected override object ToDBGuidValue(string guid)
	{
		if (string.IsNullOrWhiteSpace(guid))
		{
			return Guid.Empty;
		}
		return new Guid(guid);
	}
}
