using System;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 自动命名的配置元素
/// </summary>
public class AutoNamedConfigurationElement : KeyedConfigurationElement<string>
{
	/// <summary>
	/// 配置元素名称属性名
	/// </summary>
	public const string NameProperty = "name";

	/// <summary>
	/// 获取或者设置配置元素名称
	/// </summary>
	[ConfigurationProperty("name", IsKey = true, IsRequired = false)]
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
	public AutoNamedConfigurationElement()
	{
		Name = Guid.NewGuid().ToString();
	}

	/// <summary>
	/// 生成指定名称的配置元素
	/// </summary>
	/// <param name="name">配置元素的名称</param>
	public AutoNamedConfigurationElement(string name)
	{
		Name = name.IfNull(Guid.NewGuid().ToString());
	}
}
