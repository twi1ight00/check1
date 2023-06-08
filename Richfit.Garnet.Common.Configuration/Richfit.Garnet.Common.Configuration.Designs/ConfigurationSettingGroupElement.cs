using System.Configuration;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 配置设置组
/// </summary>
public class ConfigurationSettingGroupElement : NamedConfigurationElement
{
	/// <summary>
	/// 配置设置项目集合
	/// </summary>
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<ConfigurationSettingElement, string>), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public KeyedConfigurationElementCollection<ConfigurationSettingElement, string> Settings => (KeyedConfigurationElementCollection<ConfigurationSettingElement, string>)base[string.Empty];
}
