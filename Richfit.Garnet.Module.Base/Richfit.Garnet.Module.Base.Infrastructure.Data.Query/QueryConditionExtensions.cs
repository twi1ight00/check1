using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 查询条件扩展类
/// </summary>
public static class QueryConditionExtensions
{
	/// <summary>
	/// 从查询列表结构转化为查询对象
	/// </summary>
	/// <param name="queryItemList"></param>
	/// <returns></returns>
	public static QueryCondition TransformCondition(this IList<QueryItem> queryItemList)
	{
		QueryCondition condition = new QueryCondition();
		if (queryItemList != null && queryItemList.Any())
		{
			condition.QueryItems = queryItemList;
		}
		return condition;
	}

	/// <summary>
	/// 从列表中查询某键值对象
	/// </summary>
	/// <param name="queryItemList"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	public static IList<QueryItem> GetByKey(this IList<QueryItem> queryItemList, string key)
	{
		if (queryItemList != null && queryItemList.Any() && !string.IsNullOrEmpty(key))
		{
			return queryItemList.Where((QueryItem x) => x.Key == key).ToList();
		}
		return null;
	}

	/// <summary>
	/// 从列表中删除某键值对象
	/// </summary>
	/// <param name="queryItemList"></param>
	/// <param name="key"></param>
	public static void RemoveByKey(this IList<QueryItem> queryItemList, string key)
	{
		IList<QueryItem> items = queryItemList.GetByKey(key);
		if (items == null)
		{
			return;
		}
		foreach (QueryItem item in items)
		{
			queryItemList.Remove(item);
		}
	}
}
