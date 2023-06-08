using System;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 通用配置节元素对象
/// </summary>
public class ConfigurationSourceSection : ConfigurationSection
{
	/// <summary>
	/// 配置源组存储路径
	/// </summary>
	public const string LocationProperty = "location";

	/// <summary>
	/// 配置源组名称
	/// </summary>
	public const string SourceProperty = "source";

	/// <summary>
	/// 配置源组类型属性名称
	/// </summary>
	public const string TypeProperty = "type";

	/// <summary>
	/// 配置源组命名集合
	/// </summary>
	public const string SourcesProperty = "sources";

	/// <summary>
	/// 属性值类型缓存
	/// </summary>
	private Type type;

	/// <summary>
	/// 获取或者设置配置文件保存路径，路径应以"\"结尾
	/// </summary>
	[ConfigurationProperty("location", IsRequired = false)]
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
	/// 获取或者设置配置文件中默认的配置源的名称
	/// 配置源可以为文件、配置节名称等
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("source", IsRequired = false)]
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
	/// 获取或配置源集合
	/// </summary>
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<ConfigurationSourceElement, string>), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
	[ConfigurationProperty("sources")]
	public virtual KeyedConfigurationElementCollection<ConfigurationSourceElement, string> Sources => (KeyedConfigurationElementCollection<ConfigurationSourceElement, string>)base["sources"];

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
