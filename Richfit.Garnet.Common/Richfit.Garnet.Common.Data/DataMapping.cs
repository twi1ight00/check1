using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// 数据映射定义类
/// </summary>
public class DataMapping
{
	/// <summary>
	/// 映射的数据列名称
	/// </summary>
	private string columnName = string.Empty;

	/// <summary>
	/// 映射的对象属性名称
	/// </summary>
	private string propertyName = string.Empty;

	/// <summary>
	/// 获取或者设置映射的数据列名称
	/// </summary>
	public string ColumnName
	{
		get
		{
			return columnName;
		}
		set
		{
			columnName = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置映射的对象属性名称
	/// </summary>
	public string PropertyName
	{
		get
		{
			return propertyName;
		}
		set
		{
			propertyName = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 初始化映射定义
	/// </summary>
	/// <param name="columnName">映射的数据列名称</param>
	/// <param name="propertyName">映射的对象属性名称</param>
	public DataMapping(string columnName, string propertyName)
	{
		ColumnName = columnName;
		PropertyName = propertyName;
	}
}
