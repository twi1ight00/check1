using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 配置源映射特性
/// </summary>
[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class ConfigurationSourceMappingAttribute : Attribute
{
	/// <summary>
	/// 映射的配置源类型
	/// </summary>
	private Type sourceType;

	/// <summary>
	/// 映射的配置源名称
	/// </summary>
	private string sourceName;

	/// <summary>
	/// 获取或者设置映射的配置源类型
	/// </summary>
	public Type SourceType
	{
		get
		{
			return sourceType;
		}
		set
		{
			sourceType = value.GuardNotNull();
		}
	}

	/// <summary>
	/// 获取或者设置配置源名称
	/// </summary>
	public string SourceName
	{
		get
		{
			return sourceName;
		}
		set
		{
			sourceName = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 默认初始化
	/// </summary>
	public ConfigurationSourceMappingAttribute()
	{
		sourceName = string.Empty;
	}

	/// <summary>
	/// 指定配置源类型名称初始化
	/// </summary>
	/// <param name="sourceType">配置源类型名称</param>
	public ConfigurationSourceMappingAttribute(string sourceType)
		: this()
	{
		sourceType.GuardNotNullAndEmpty();
		SourceType = Type.GetType(sourceType);
	}

	/// <summary>
	/// 指定配置源类型对象初始化
	/// </summary>
	/// <param name="sourceType">配置源类型</param>
	public ConfigurationSourceMappingAttribute(Type sourceType)
		: this()
	{
		sourceType.GuardNotNull();
		SourceType = sourceType;
	}
}
