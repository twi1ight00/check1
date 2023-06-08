using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 查询返回结果
/// </summary>
public class QueryResult
{
	/// <summary>
	/// 查询结果列表
	/// </summary>
	private IList list;

	/// <summary>
	/// 结果数据
	/// </summary>
	public IList List
	{
		get
		{
			return list;
		}
		set
		{
			list = value;
		}
	}

	/// <summary>
	/// 查询满足条件的总记录数，用于分页查询总数返回，可以为空
	/// </summary>
	public int RecordCount { get; set; }

	/// <summary>
	/// 序列化方法
	/// </summary>
	/// <returns></returns>
	public string ToJson()
	{
		return this.JsonSerialize();
	}
}
/// <summary>
/// 查询返回结果，泛型
/// </summary>
/// <typeparam name="T"></typeparam>
public class QueryResult<T>
{
	/// <summary>
	/// 查询结果列表
	/// </summary>
	private IList<T> list;

	/// <summary>
	/// 结果数据
	/// </summary>
	public IList<T> List
	{
		get
		{
			return list;
		}
		set
		{
			list = value;
		}
	}

	/// <summary>
	/// 查询满足条件的总记录数，用于分页查询总数返回，可以为空
	/// </summary>
	public int RecordCount { get; set; }

	/// <summary>
	/// 构造函数
	/// </summary>
	public QueryResult()
	{
		list = new List<T>();
	}

	/// <summary>
	/// 查询结果单记录返回
	/// </summary>
	/// <returns></returns>
	public T GetSingle()
	{
		if (list != null && list.Any())
		{
			return list.First();
		}
		return default(T);
	}

	/// <summary>
	/// 序列化方法
	/// </summary>
	/// <returns></returns>
	public string ToJson()
	{
		return this.JsonSerialize();
	}
}
