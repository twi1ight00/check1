using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Converter;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// Sql查询转换器基类
/// </summary>
public abstract class SqlQueryConvertBase : ISqlQueryConverter, IDynamicQueryConverter
{
	/// <summary>
	/// 参数标识
	/// </summary>
	/// <returns></returns>
	protected abstract string ParameterFlag { get; }

	/// <summary>
	/// 转换Guid为数据库适当的存储形式
	/// </summary>
	/// <param name="guid"></param>
	/// <returns></returns>
	protected abstract object ToDBGuidValue(string guid);

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int parameterStartIndex = 0)
	{
		if (queryItemList != null && queryItemList.Any())
		{
			return GetWhereSqlClause(queryItemList, 0, queryItemList.Count, parameterStartIndex);
		}
		return string.Empty;
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int[] indexOrder, int parameterStartIndex = 0)
	{
		StringBuilder sql = new StringBuilder();
		if (queryItemList != null && queryItemList.Any())
		{
			IList<QueryItem> validQueryList = new List<QueryItem>();
			if (indexOrder != null && indexOrder.Any())
			{
				foreach (int idx in indexOrder)
				{
					if (idx <= queryItemList.Count - 1)
					{
						validQueryList.Add(queryItemList[idx]);
					}
				}
				int i = parameterStartIndex;
				foreach (QueryItem item in validQueryList)
				{
					if (string.IsNullOrWhiteSpace(item.Key) || string.IsNullOrWhiteSpace(item.Type))
					{
						continue;
					}
					if (string.IsNullOrWhiteSpace(item.Value))
					{
						if (item.Method.EqualOrdinal(" Is Null ", ignoreCase: true) || item.Method.EqualOrdinal(" Is Not Null ", ignoreCase: true))
						{
							sql.Append(" and ").Append(item.Key).Append(item.Method);
						}
						continue;
					}
					sql.Append(" and ").Append(item.Key);
					if (!string.IsNullOrWhiteSpace(item.Method))
					{
						sql.Append($" {item.Method.Trim()} ");
					}
					else if (item.Type.EqualOrdinal("string", ignoreCase: true))
					{
						sql.Append(" Like ");
					}
					else
					{
						sql.Append(" = ");
					}
					if (item.Method.EqualOrdinal(" In ", ignoreCase: true))
					{
						string[] stringValues = item.Value.Split(',');
						IList<string> valueList = new List<string>();
						stringValues.ForEach(delegate(string x)
						{
							valueList.Add(Utility.GetGuidString(x));
						});
						sql.Append(string.Format(" ({0})", valueList.JoinString("'{0}'", ",")));
					}
					else
					{
						sql.Append(ParameterFlag + i);
						i++;
					}
				}
			}
		}
		return sql.ToString();
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> queryItemList, int beginIndex, int length, int parameterStartIndex = 0)
	{
		int[] indexOrder = null;
		if (queryItemList != null && queryItemList.Any())
		{
			if (beginIndex < 0)
			{
				beginIndex = 0;
			}
			if (beginIndex < queryItemList.Count && length > 0)
			{
				if (beginIndex + length > queryItemList.Count)
				{
					length = queryItemList.Count - beginIndex;
				}
				indexOrder = new int[length];
				for (int i = 0; i < length; i++)
				{
					indexOrder[i] = beginIndex + i;
				}
			}
		}
		return GetWhereSqlClause(queryItemList, indexOrder, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetSql(string sqlExpress, QueryCondition queryCondition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return GetSql(sqlExpress, queryCondition, 0, queryCondition.QueryItems.Count, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public abstract string GetSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <inheritdoc />
	public string GetSql(string sqlExpress, QueryCondition queryCondition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		if (queryCondition.IsNotNull())
		{
			int[] indexOrder = null;
			IList<QueryItem> queryItemList = queryCondition.QueryItems;
			if (queryItemList != null && queryItemList.Any())
			{
				if (beginIndex < 0)
				{
					beginIndex = 0;
				}
				if (beginIndex < queryItemList.Count && length > 0)
				{
					if (beginIndex + length > queryItemList.Count)
					{
						length = queryItemList.Count - beginIndex;
					}
					indexOrder = new int[length];
					for (int i = 0; i < length; i++)
					{
						indexOrder[i] = beginIndex + i;
					}
				}
			}
			return GetSql(sqlExpress, queryCondition, indexOrder, formatParameters, parameterStartIndex);
		}
		if (formatParameters.IsNotNull())
		{
			return GetSql(sqlExpress, null, null, formatParameters, parameterStartIndex);
		}
		return sqlExpress;
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return GetTotalCountSql(sqlExpress, queryCondition, 0, queryCondition.QueryItems.Count, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public abstract string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <inheritdoc />
	public string GetTotalCountSql(string sqlExpress, QueryCondition queryCondition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		if (queryCondition != null)
		{
			int[] indexOrder = null;
			IList<QueryItem> queryItemList = queryCondition.QueryItems;
			if (queryItemList != null && queryItemList.Any())
			{
				if (beginIndex < 0)
				{
					beginIndex = 0;
				}
				if (beginIndex < queryItemList.Count && length > 0)
				{
					if (beginIndex + length > queryItemList.Count)
					{
						length = queryItemList.Count - beginIndex;
					}
					indexOrder = new int[length];
					for (int i = 0; i < length; i++)
					{
						indexOrder[i] = beginIndex + i;
					}
				}
			}
			return GetTotalCountSql(sqlExpress, queryCondition, indexOrder, formatParameters, parameterStartIndex);
		}
		if (formatParameters.IsNotNull())
		{
			return GetTotalCountSql(sqlExpress, null, null, formatParameters, parameterStartIndex);
		}
		return sqlExpress;
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int valueStartIndex = 0, int defaultParameterCount = 0)
	{
		if (queryItemList != null)
		{
			return GetWhereSqlParamValue(queryItemList, valueStartIndex, queryItemList.Count, defaultParameterCount);
		}
		return null;
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int[] indexOrder, int defaultParameterCount = 0)
	{
		IList<object> list = new List<object>();
		if (queryItemList != null && queryItemList.Any())
		{
			IList<QueryItem> validQueryList = new List<QueryItem>();
			if (indexOrder != null && indexOrder.Any())
			{
				foreach (int idx in indexOrder)
				{
					if (idx <= queryItemList.Count - 1)
					{
						validQueryList.Add(queryItemList[idx]);
					}
				}
				int index = 0;
				foreach (QueryItem item in validQueryList)
				{
					index++;
					if (string.IsNullOrWhiteSpace(item.Type) || (string.IsNullOrWhiteSpace(item.Value) && (!string.IsNullOrWhiteSpace(item.Value) || index > defaultParameterCount)))
					{
						continue;
					}
					if (item.Type.EqualOrdinal("string", ignoreCase: true) && !string.IsNullOrWhiteSpace(item.Value) && !item.Method.EqualOrdinal(" Like ", ignoreCase: true) && Guid.TryParse(item.Value, out var _))
					{
						item.Type = "guid";
					}
					item.DateTimeToUtc();
					if (item.Method.EqualOrdinal(" In ", ignoreCase: true))
					{
						continue;
					}
					if (item.Type.EqualOrdinal("guid", ignoreCase: true))
					{
						list.Add(ToDBGuidValue(item.Value));
					}
					else if (item.Type.EqualOrdinal("date", ignoreCase: true))
					{
						if (!string.IsNullOrWhiteSpace(item.Value))
						{
							list.Add(DateTime.Parse(item.Value));
						}
						else
						{
							list.Add(DateTime.MinValue);
						}
					}
					else if (item.Type.EqualOrdinal("string", ignoreCase: true) && (string.IsNullOrWhiteSpace(item.Method) || item.Method.EqualOrdinal(" Like ", ignoreCase: true)))
					{
						list.Add($"%{item.Value}%");
					}
					else if (item.Type.EqualOrdinal("number", ignoreCase: true))
					{
						if (!string.IsNullOrWhiteSpace(item.Value))
						{
							list.Add(item.Value);
						}
						else
						{
							list.Add(int.MinValue);
						}
					}
					else
					{
						list.Add(item.Value);
					}
				}
			}
		}
		return list.ToArray();
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList, int beginIndex, int length, int defaultParameterCount)
	{
		int[] indexOrder = null;
		if (queryItemList != null && queryItemList.Any())
		{
			if (beginIndex < 0)
			{
				beginIndex = 0;
			}
			if (beginIndex < queryItemList.Count && length > 0)
			{
				if (beginIndex + length > queryItemList.Count)
				{
					length = queryItemList.Count - beginIndex;
				}
				indexOrder = new int[length];
				for (int i = 0; i < length; i++)
				{
					indexOrder[i] = beginIndex + i;
				}
			}
		}
		return GetWhereSqlParamValue(queryItemList, indexOrder, defaultParameterCount);
	}

	private string GetWhereSqlClause(IQueryBlock queryBlock, ref int parameterIndex)
	{
		StringBuilder sbSql = new StringBuilder();
		if (queryBlock.BlockItems != null && queryBlock.BlockItems.Any())
		{
			foreach (IQueryBlock block in queryBlock.BlockItems)
			{
				string blockSql = GetWhereSqlClause(block, ref parameterIndex);
				if (!string.IsNullOrWhiteSpace(blockSql))
				{
					if (sbSql.Length > 0)
					{
						sbSql.Append(queryBlock.RelationMark);
					}
					sbSql.Append($"({blockSql})");
				}
			}
		}
		if (queryBlock.QueryItems != null && queryBlock.QueryItems.Any())
		{
			string itemSql = GetWhereSqlClause(queryBlock.QueryItems, queryBlock.RelationMark, ref parameterIndex);
			if (!string.IsNullOrWhiteSpace(itemSql))
			{
				if (sbSql.Length > 0)
				{
					sbSql.Append(queryBlock.RelationMark);
				}
				sbSql.Append(itemSql);
			}
		}
		return sbSql.ToString();
	}

	private string GetWhereSqlClause(IList<QueryItem> queryItemList, string relationMark, ref int parameterIndex)
	{
		StringBuilder sql = new StringBuilder();
		foreach (QueryItem item in queryItemList)
		{
			if (string.IsNullOrWhiteSpace(item.Key) || string.IsNullOrWhiteSpace(item.Type) || string.IsNullOrWhiteSpace(item.Key) || string.IsNullOrWhiteSpace(item.Type))
			{
				continue;
			}
			if (string.IsNullOrWhiteSpace(item.Value))
			{
				if (item.Method.EqualOrdinal(" Is Null ", ignoreCase: true) || item.Method.EqualOrdinal(" Is Not Null ", ignoreCase: true))
				{
					if (sql.Length > 0)
					{
						sql.Append(relationMark);
					}
					sql.Append(item.Key).Append(item.Method);
				}
				continue;
			}
			if (sql.Length > 0)
			{
				sql.Append(relationMark);
			}
			sql.Append(item.Key);
			if (!string.IsNullOrWhiteSpace(item.Method))
			{
				sql.Append($" {item.Method.Trim()} ");
			}
			else if (item.Type.EqualOrdinal("string", ignoreCase: true))
			{
				sql.Append(" Like ");
			}
			else
			{
				sql.Append(" = ");
			}
			sql.Append(ParameterFlag + parameterIndex);
			parameterIndex++;
		}
		return sql.ToString();
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IQueryBlock queryBlock)
	{
		int paraIndex = 0;
		return queryBlock.RelationMark + GetWhereSqlClause(queryBlock, ref paraIndex);
	}

	private object[] GetWhereSqlParamValue(IList<QueryItem> queryItemList)
	{
		IList<object> list = new List<object>();
		if (queryItemList != null && queryItemList.Any())
		{
			foreach (QueryItem item in queryItemList)
			{
				if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && !string.IsNullOrWhiteSpace(item.Type))
				{
					if (item.Type.EqualOrdinal("string", ignoreCase: true) && Guid.TryParse(item.Value, out var _))
					{
						item.Type = "guid";
					}
					item.DateTimeToUtc();
					if (item.Type.EqualOrdinal("guid", ignoreCase: true))
					{
						list.Add(ToDBGuidValue(item.Value));
					}
					else if (item.Type.EqualOrdinal("date", ignoreCase: true))
					{
						list.Add(DateTime.Parse(item.Value));
					}
					else if (item.Type.EqualOrdinal("string", ignoreCase: true) && (string.IsNullOrWhiteSpace(item.Method) || item.Method.EqualOrdinal(" Like ", ignoreCase: true)))
					{
						list.Add($"%{item.Value}%");
					}
					else if (item.Type.EqualOrdinal("number", ignoreCase: true))
					{
						list.Add(item.Value);
					}
					else
					{
						list.Add(item.Value);
					}
				}
			}
		}
		return list.ToArray();
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IQueryBlock queryBlock)
	{
		IList<object> list = new List<object>();
		if (queryBlock.BlockItems != null && queryBlock.BlockItems.Any())
		{
			foreach (IQueryBlock block in queryBlock.BlockItems)
			{
				object[] blockArray = GetWhereSqlParamValue(block);
				if (blockArray.Any())
				{
					blockArray.ForEach(delegate(object x)
					{
						list.Add(x);
					});
				}
			}
		}
		if (queryBlock.QueryItems != null && queryBlock.QueryItems.Any())
		{
			object[] itemArray = GetWhereSqlParamValue(queryBlock.QueryItems);
			if (itemArray.Any())
			{
				itemArray.ForEach(delegate(object x)
				{
					list.Add(x);
				});
			}
		}
		return list.ToArray();
	}
}
