using System.Configuration;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 包信息配置节
/// 包信息配置节在包的配置文件中只能有一个
/// </summary>
public class PackageConfigurationSection : ConfigurationSection
{
	/// <summary>
	/// 包描述配置元素名称
	/// </summary>
	public const string PackageProperty = "package";

	/// <summary>
	/// 包中程序集配置元素集合名称
	/// </summary>
	public const string AssembliesProperty = "assemblies";

	/// <summary>
	/// 获取包描述配置元素
	/// </summary>
	[ConfigurationProperty("package", IsRequired = true)]
	public PackageConfigurationElement Package => (PackageConfigurationElement)base["package"];

	/// <summary>
	/// 获取配置元素集合
	/// </summary>
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<PackageConfigurationAssemblyElement, string>), AddItemName = "assembly", ClearItemsName = "clear", RemoveItemName = "remove")]
	[ConfigurationProperty("assemblies", IsRequired = true)]
	public KeyedConfigurationElementCollection<PackageConfigurationAssemblyElement, string> Assemblies => (KeyedConfigurationElementCollection<PackageConfigurationAssemblyElement, string>)base["assemblies"];
}
