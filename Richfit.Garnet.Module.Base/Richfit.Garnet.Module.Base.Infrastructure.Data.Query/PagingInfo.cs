using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 分页信息
/// </summary>
public class PagingInfo
{
	private int pageCount;

	/// <summary>
	/// 排序属性，对象查询时候必须与POCO对象属性名称相同，SQL查询时候必须与字段名称相同，多个属性逗号分割
	/// </summary>
	public string SortBy { get; set; }

	/// <summary>
	/// 对应排序属性的排序顺序，多个逗号分割，只能是asc，desc形式，参考QuerySortOrder常量定义类
	/// </summary>
	public string SortOrder { get; set; }

	/// <summary>
	/// 当前页索引值
	/// </summary>
	public int PageIndex { get; set; }

	/// <summary>
	/// 单页记录数
	/// </summary>
	public int PageCount
	{
		get
		{
			if (pageCount == 0)
			{
				return int.MaxValue;
			}
			return pageCount;
		}
		set
		{
			pageCount = value;
		}
	}

	/// <summary>
	/// 获得PageingInfo对象
	/// </summary>
	/// <param name="jsonText"></param>
	/// <returns>PageingInfo对象</returns>
	public static PagingInfo DeserializeFromJson(string jsonText)
	{
		if (!string.IsNullOrWhiteSpace(jsonText))
		{
			return jsonText.JsonDeserialize<PagingInfo>(new JsonConverter[0]);
		}
		return null;
	}

	/// <summary>
	/// 得到SQL语句中的排序字符
	/// </summary>
	/// <returns></returns>
	public string GetSortDesc()
	{
		if (!string.IsNullOrWhiteSpace(SortBy) && !string.IsNullOrWhiteSpace(SortOrder))
		{
			string[] sortBys = SortBy.Split(new string[1] { "," }, StringSplitOptions.None);
			string[] sortOrders = SortOrder.Split(new string[1] { "," }, StringSplitOptions.None);
			if (sortBys.Any() && sortOrders.Any() && sortBys.Length == sortOrders.Length)
			{
				StringBuilder sortDesc = new StringBuilder();
				int count = sortBys.Length;
				for (int i = 0; i < count; i++)
				{
					sortDesc.Append(sortBys[i] + " " + sortOrders[i] + ",");
				}
				return sortDesc.Remove(sortDesc.Length - 1, 1).ToString();
			}
		}
		return string.Empty;
	}
}
