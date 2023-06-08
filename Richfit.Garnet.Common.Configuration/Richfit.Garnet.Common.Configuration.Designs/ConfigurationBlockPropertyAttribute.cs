using System;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 文本块配置属性特性
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ConfigurationBlockPropertyAttribute : Attribute
{
	/// <summary>
	/// 文本内容的最小长度
	/// </summary>
	public int MinLength { get; set; }

	/// <summary>
	/// 文本内容的最大长度
	/// </summary>
	public int MaxLength { get; set; }

	/// <summary>
	/// 初始化
	/// </summary>
	public ConfigurationBlockPropertyAttribute()
	{
		MinLength = 0;
		MaxLength = 0;
	}
}
