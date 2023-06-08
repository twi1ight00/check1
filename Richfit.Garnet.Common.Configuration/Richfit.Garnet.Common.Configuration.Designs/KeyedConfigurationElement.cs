using System;
using System.Configuration;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 标识的配置元素
/// </summary>
/// <typeparam name="K">配置元素键值类型</typeparam>
public class KeyedConfigurationElement<K> : ConfigurationElement
{
	/// <summary>
	/// 获取配置元素标识
	/// 此属性应在继承的元素中进行重写
	/// </summary>
	public virtual K Key
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// 获取配置元素的值
	/// 此属性应在继承的元素中进行重写
	/// </summary>
	public virtual object KeyedValue
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}
