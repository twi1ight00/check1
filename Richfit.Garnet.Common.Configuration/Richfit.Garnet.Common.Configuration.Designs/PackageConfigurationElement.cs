using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 包描述配置元素
/// </summary>
public class PackageConfigurationElement : ConfigurationElement
{
	/// <summary>
	/// 包名称配置属性名称
	/// </summary>
	public const string NameProperty = "name";

	/// <summary>
	/// 包版本配置属性名称
	/// </summary>
	public const string VersionProperty = "version";

	/// <summary>
	/// 包描述配置属性名称
	/// </summary>
	public const string DescriptionProperty = "description";

	/// <summary>
	/// 包配置源属性名称
	/// </summary>
	public const string PackageConfigurationProperty = "packageConfiguration";

	/// <summary>
	/// 获取或者设置功能包名称
	/// </summary>
	[ConfigurationProperty("name", IsRequired = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public string Name
	{
		get
		{
			return base["name"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["name"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置功能包版本
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("version", IsRequired = false)]
	public string Version
	{
		get
		{
			return base["version"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["version"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置功能包描述
	/// </summary>
	[ConfigurationProperty("description", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public string Description
	{
		get
		{
			return base["description"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["description"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置包配置源属性名称
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("packageConfiguration", IsRequired = false, DefaultValue = "Config\\")]
	public string PackageConfiguration
	{
		get
		{
			return base["packageConfiguration"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["packageConfiguration"] = value.IfNull(string.Empty);
		}
	}
}
