using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 配置设置节
/// </summary>
public class ConfigurationSettingSection : ConfigurationSection
{
	/// <summary>
	/// 默认设置名称元素名称
	/// </summary>
	public const string DefaultProperty = "default";

	/// <summary>
	/// 获取或者设置默认设置名称
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("default", IsRequired = false)]
	public string Default
	{
		get
		{
			return (string)base["default"];
		}
		set
		{
			base["default"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 配置设置项目集合
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<ConfigurationSettingElement, string>), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
	public KeyedConfigurationElementCollection<ConfigurationSettingElement, string> Settings => (KeyedConfigurationElementCollection<ConfigurationSettingElement, string>)base[string.Empty];
}
