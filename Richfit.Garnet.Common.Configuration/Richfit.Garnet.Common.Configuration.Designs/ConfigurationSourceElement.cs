using System;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 配置源元素对象
/// </summary>
public class ConfigurationSourceElement : AutoNamedConfigurationElement
{
	/// <summary>
	/// 配置源文件路径属性名称
	/// </summary>
	public const string LocationProperty = "location";

	/// <summary>
	/// 配置源文件配置源属性名称
	/// </summary>
	public const string SourceProperty = "source";

	/// <summary>
	/// 配置源类型属性名称
	/// </summary>
	public const string TypeProperty = "type";

	/// <summary>
	/// 属性值类型缓存
	/// </summary>
	private Type type;

	/// <summary>
	/// 获取或者设置配置源的配置文件位置
	/// </summary>
	[ConfigurationProperty("location", IsRequired = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string Location
	{
		get
		{
			return base["location"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["location"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置配置源文件名称
	/// </summary>
	[ConfigurationProperty("source", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string Source
	{
		get
		{
			return base["source"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["source"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置配置源名称
	/// 配置源类型名称必须是类型的完全限定名称
	/// </summary>
	[ConfigurationProperty("type", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string TypeName
	{
		get
		{
			return base["type"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["type"] = value.IfNull(string.Empty);
			type = null;
		}
	}

	/// <summary>
	/// 获取或者设置配置元素值类型
	/// </summary>
	public virtual Type Type
	{
		get
		{
			return type.IfNull(TypeName.IsNullOrEmpty() ? null : TypeName.ResolveType());
		}
		set
		{
			TypeName = (value.IsNull() ? string.Empty : value.AssemblyQualifiedName);
			type = value;
		}
	}
}
