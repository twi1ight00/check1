using System;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 目标拦截器配置元素
/// </summary>
public class InterceptionTargetInterceptorElement : AutoNamedConfigurationElement
{
	/// <summary>
	/// 目标拦截器类型名称
	/// </summary>
	public const string InterceptorTypeProperty = "type";

	/// <summary>
	/// 拦截器类型
	/// </summary>
	private Type interceptorType;

	/// <summary>
	/// 获取或者设置目标拦截器类型
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true)]
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
			interceptorType = null;
		}
	}

	/// <summary>
	/// 获取连接器配置属性集合
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<ConfigurationSettingElement, string>), AddItemName = "setting", ClearItemsName = "clear", RemoveItemName = "remove")]
	public KeyedConfigurationElementCollection<ConfigurationSettingElement, string> Settings => (KeyedConfigurationElementCollection<ConfigurationSettingElement, string>)base[string.Empty];

	/// <summary>
	/// 获取或者设置拦截器类型
	/// </summary>
	public virtual Type Type
	{
		get
		{
			if (interceptorType.IsNull())
			{
				interceptorType = ConfigurationManager.ResolveType(TypeName);
			}
			return interceptorType;
		}
		set
		{
			TypeName = (value.IsNull() ? string.Empty : value.AssemblyQualifiedName);
			interceptorType = value;
		}
	}
}
