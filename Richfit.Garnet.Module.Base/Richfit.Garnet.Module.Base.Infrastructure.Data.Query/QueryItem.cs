using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 查询条件，描述sql语句中的一个where条件key=value或者对象实体linq查询中的一个条件c=&gt;c.key=value
/// </summary>
public class QueryItem
{
	private string key;

	private string value;

	private string type = "string";

	private string method = " Like ";

	/// <summary>
	/// 查询项
	/// </summary>
	public string Key
	{
		get
		{
			return key;
		}
		set
		{
			key = value;
		}
	}

	/// <summary>
	/// 查询内容
	/// </summary>
	public string Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	/// <summary>
	/// 查询类型,由QueryType定义
	/// </summary>
	public string Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	/// <summary>
	/// 查询操作符，由QueryMethod定义
	/// </summary>
	public string Method
	{
		get
		{
			return method;
		}
		set
		{
			method = value;
		}
	}

	/// <summary>
	/// 是否做过日期时区处理的标识
	/// </summary>
	internal bool HasZoneHandled { get; set; }

	/// <summary>
	/// 转换日期数据为UTC时间
	/// </summary>
	internal void DateTimeToUtc()
	{
		if (Type.Equals("date", StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrEmpty(Value) && !HasZoneHandled)
		{
			DateTime dateTime = DateTime.Parse(Value);
			Value = TimeZoneHelper.LocalTimeToUtc(dateTime).ToString();
			HasZoneHandled = true;
		}
	}

	/// <summary>
	/// 获取查询条件集合
	/// </summary>
	/// <param name="jsonText">查询条件的json字符串</param>
	/// <returns></returns>
	public static IList<QueryItem> GetQueryCollection(string jsonText)
	{
		IList<QueryItem> queryList = new List<QueryItem>();
		if (!string.IsNullOrWhiteSpace(jsonText))
		{
			queryList = jsonText.JsonDeserializeToList<QueryItem>(new JsonConverter[0]);
		}
		return queryList;
	}

	/// <summary>
	/// 构造查询条件
	/// </summary>
	/// <param name="key">键</param>
	/// <param name="value">值</param>
	/// <param name="type">类型，由QueryType定义</param>
	/// <param name="method">方法，由QueryMethod定义</param>
	/// <returns></returns>
	public static QueryItem GetQueryItem(string key, string value, string type, string method)
	{
		QueryItem queryItem = new QueryItem();
		queryItem.Key = key;
		queryItem.Value = value;
		queryItem.Type = type;
		queryItem.Method = method;
		return queryItem;
	}
}
