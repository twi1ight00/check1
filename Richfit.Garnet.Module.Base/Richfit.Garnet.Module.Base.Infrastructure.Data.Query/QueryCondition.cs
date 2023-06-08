using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 查询条件对象，包含查询条目和分页设置等信息
/// </summary>
public class QueryCondition
{
	/// <summary>
	/// 初始化
	/// </summary>
	private IList<QueryItem> queryItems;

	/// <summary>
	/// 查询条件，按照实体属性查询条件设置或者SQL字段查询条件设置
	/// </summary>
	public IList<QueryItem> QueryItems
	{
		get
		{
			if (queryItems == null)
			{
				queryItems = new List<QueryItem>();
			}
			return queryItems;
		}
		set
		{
			queryItems = value;
		}
	}

	/// <summary>
	/// 分页设置
	/// </summary>
	public PagingInfo PagingSetting { get; set; }

	/// <summary>
	/// 把json字符串转成QueryCondition对象
	/// </summary>
	/// <param name="jsonText"></param>
	/// <returns></returns>
	public static QueryCondition DeserializeFromJson(string jsonText)
	{
		if (string.IsNullOrEmpty(jsonText))
		{
			return null;
		}
		return jsonText.JsonDeserialize<QueryCondition>(new JsonConverter[0]);
	}

	/// <summary>
	/// 从条件列表中查询某键值对象
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public QueryItem GetByKey(string key)
	{
		if (QueryItems != null && QueryItems.Any() && !string.IsNullOrEmpty(key))
		{
			return QueryItems.FirstOrDefault((QueryItem x) => x.Key == key);
		}
		return new QueryItem();
	}

	/// <summary>
	/// 从条件列表中删除某键值对象
	/// </summary>
	/// <param name="key"></param>
	public void RemoveByKey(string key)
	{
		QueryItems.RemoveByKey(key);
	}

	/// <summary>
	/// 删除某个查询条件项
	/// </summary>
	/// <param name="queryItem"></param>
	public void Remove(QueryItem queryItem)
	{
		if (QueryItems != null && QueryItems.Any() && queryItem != null)
		{
			QueryItems.Remove(queryItem);
		}
	}

	/// <summary>
	/// 将查询条件移到列表某索引指定的位置
	/// </summary>
	/// <param name="index">索引</param>
	/// <param name="queryItem"></param>
	public void MoveTo(int index, QueryItem queryItem)
	{
		Remove(queryItem);
		Insert(index, queryItem);
	}

	/// <summary>
	/// 将QueryItem插入到列表中的指定位置
	/// </summary>
	/// <param name="index"></param>
	/// <param name="queryItem"></param>
	public void Insert(int index, QueryItem queryItem)
	{
		if (QueryItems != null && queryItem != null)
		{
			QueryItems.Insert(index, queryItem);
		}
	}

	/// <summary>
	/// 增加查询条件
	/// </summary>
	/// <param name="queryItem"></param>
	public void Add(QueryItem queryItem)
	{
		if (QueryItems != null && queryItem != null)
		{
			QueryItems.Add(queryItem);
		}
	}
}
