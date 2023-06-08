using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 强类型的查询参数与QueryItem对象映射的配置属性
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ParameterConfigAttribute : Attribute
{
	/// <summary>
	/// 列名称或者对象属性名称
	/// </summary>
	private string columnName;

	/// <summary>
	/// 对应的QueryType类型
	/// </summary>
	private string type;

	/// <summary>
	/// 对应的QueryMethod类型
	/// </summary>
	private string method;

	/// <summary>
	/// 列名称或者对象属性名称
	/// </summary>
	public string ColumnName
	{
		get
		{
			return columnName;
		}
		set
		{
			columnName = value;
		}
	}

	/// <summary>
	/// 对应的QueryType类型,参考QueryType类
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
	/// 对应的QueryMethod类型,参考QueryMethod类
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
	/// 构造函数
	/// </summary>
	/// <param name="columnName"></param>
	/// <param name="type"></param>
	/// <param name="method"></param>
	public ParameterConfigAttribute(string columnName, string type = "string", string method = " = ")
	{
		ColumnName = columnName;
		Type = type;
		Method = method;
	}
}
