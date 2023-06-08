using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 配置设置组节
/// </summary>
public class ConfigurationSettingGroupSection : ConfigurationSection
{
	/// <summary>
	/// 默认设置名称元素名称
	/// </summary>
	public const string DefaultProperty = "default";

	/// <summary>
	/// 获取或者设置默认设置名称
	/// </summary>
	[ConfigurationProperty("default", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
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
	/// 配置设置组集合
	/// </summary>
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<ConfigurationSettingGroupElement, string>), AddItemName = "group", ClearItemsName = "clear", RemoveItemName = "remove")]
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public KeyedConfigurationElementCollection<ConfigurationSettingGroupElement, string> Groups => (KeyedConfigurationElementCollection<ConfigurationSettingGroupElement, string>)base[string.Empty];
}
