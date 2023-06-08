using System;
using System.Reflection;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 查询参数对象基类
/// </summary>
public class QueryObjectBase : IQueryParameter
{
	/// <summary>
	/// 分页索引
	/// </summary>
	private int pageIndex = 1;

	/// <summary>
	/// 最大分页数量
	/// </summary>
	private int pageSize = 9999;

	/// <summary>
	/// 排序项目
	/// </summary>
	private string sortBy = string.Empty;

	/// <summary>
	/// 排序顺序
	/// </summary>
	private string sortOrder = string.Empty;

	/// <summary>
	/// 是否启用分页查询
	/// </summary>
	private bool isPager = false;

	private int startRow;

	private int endRow;

	public int StartRow => pageIndex * pageSize + 1;

	public int EndRow => (pageIndex + 1) * pageSize;

	/// <summary>
	/// 获取或者设置是否启用分页查询
	/// </summary>
	public bool IsPager
	{
		get
		{
			return isPager;
		}
		set
		{
			isPager = value;
		}
	}

	/// <summary>
	/// 索引页.缺省1
	/// </summary>
	public int PageIndex
	{
		get
		{
			return pageIndex;
		}
		set
		{
			pageIndex = value;
		}
	}

	/// <summary>
	/// 单页记录数.缺省9999
	/// </summary>
	public int PageSize
	{
		get
		{
			return pageSize;
		}
		set
		{
			pageSize = value;
		}
	}

	/// <summary>
	/// 排序属性，对象查询时候必须与POCO对象属性名称相同，SQL查询时候必须与字段名称相同，多个属性逗号分割
	/// </summary>
	public string SortBy
	{
		get
		{
			return sortBy;
		}
		set
		{
			sortBy = value;
		}
	}

	/// <summary>
	/// 对应排序属性的排序顺序，多个逗号分割，只能是asc，desc形式，参考QuerySortOrder常量定义类
	/// </summary>
	public string SortOrder
	{
		get
		{
			return sortOrder;
		}
		set
		{
			sortOrder = value;
		}
	}

	/// <summary>
	/// 查询参数对象转化为QueryCondition对象
	/// </summary>
	/// <returns></returns>
	public QueryCondition ToQueryCondition()
	{
		QueryCondition queryCondition = new QueryCondition();
		if (IsPager)
		{
			queryCondition.PagingSetting = new PagingInfo
			{
				PageCount = PageSize,
				PageIndex = PageIndex,
				SortBy = SortBy,
				SortOrder = SortOrder
			};
		}
		PropertyInfo[] PropertyInfoCollection = GetType().GetProperties();
		PropertyInfo[] array = PropertyInfoCollection;
		foreach (PropertyInfo propertyInfo in array)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(inherit: true);
			for (int j = 0; j < customAttributes.Length; j++)
			{
				Attribute attribute = (Attribute)customAttributes[j];
				if (!(attribute is ParameterConfigAttribute column))
				{
					continue;
				}
				string method = column.Method;
				if (propertyInfo.GetValue(this, null) != null)
				{
					if (column.Method == " Is Null ")
					{
						method = " Like ";
					}
					queryCondition.Add(new QueryItem
					{
						Key = column.ColumnName,
						Method = method,
						Type = column.Type,
						Value = ((propertyInfo.GetValue(this, null) == null) ? string.Empty : propertyInfo.GetValue(this, null).ToString())
					});
				}
			}
		}
		return queryCondition;
	}
}
