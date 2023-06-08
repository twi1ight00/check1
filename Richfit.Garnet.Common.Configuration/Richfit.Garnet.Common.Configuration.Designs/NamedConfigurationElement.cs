using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 已命名的文本块配置元素
/// </summary>
public class NamedConfigurationElement : KeyedConfigurationElement<string>
{
	/// <summary>
	/// 配置元素名称属性名
	/// </summary>
	public const string NameProperty = "name";

	/// <summary>
	/// 获取或者设置配置元素名称
	/// </summary>
	[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string Name
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
	/// 获取配置元素标识
	/// </summary>
	public override string Key => Name;

	/// <summary>
	/// 生成具有默认名称的配置元素
	/// </summary>
	public NamedConfigurationElement()
	{
		Name = string.Empty;
	}

	/// <summary>
	/// 生成指定名称的配置元素
	/// </summary>
	/// <param name="name">配置元素名称</param>
	public NamedConfigurationElement(string name)
	{
		Name = name;
	}
}
