using System;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// Oracle查询转换器
/// </summary>
public class OracleQueryConverter : SqlQueryConvertBase
{
	/// <inheritdoc />
	protected override string ParameterFlag => ":p";

	/// <inheritdoc />
	public override string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		if (string.IsNullOrWhiteSpace(sqlExpress))
		{
			return sqlExpress;
		}
		if (queryCondition.IsNotNull())
		{
			QueryCondition condition = new QueryCondition();
			condition.QueryItems = queryCondition.QueryItems;
			string sqlStatement = GetSql(sqlExpress, condition, indexOrder, formatParameters, parameterStartIndex);
			if (!string.IsNullOrEmpty(sqlStatement))
			{
				return $"select count(*) from ({sqlStatement}) tc";
			}
		}
		else if (formatParameters.IsNotNull())
		{
			string sqlStatement = GetSql(sqlExpress, null, indexOrder, formatParameters, parameterStartIndex);
			if (!string.IsNullOrEmpty(sqlStatement))
			{
				return $"select count(*) from ({sqlStatement}) tc";
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
		if (sqlExpress.IndexOf("where", StringComparison.OrdinalIgnoreCase) < 0 && sqlExpress.IndexOf("start with", StringComparison.OrdinalIgnoreCase) < 0)
		{
			sqlWhereDefault = " where 1=1";
		}
		PagingInfo pagingInfo = queryCondition.PagingSetting;
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
		if (pagingInfo != null)
		{
			return string.Format("SELECT * FROM (SELECT A.*, ROWNUM RN FROM (" + sqlStatement + " ORDER BY " + pagingInfo.GetSortDesc() + ") A) WHERE RN <= {0}*({1}+1) AND RN > {1} * {0} ", pagingInfo.PageCount, pagingInfo.PageIndex);
		}
		return sqlStatement;
	}

	/// <inheritdoc />
	protected override object ToDBGuidValue(string guid)
	{
		if (string.IsNullOrWhiteSpace(guid))
		{
			return Guid.Empty.ToByteArray();
		}
		return new Guid(guid).ToByteArray();
	}
}
