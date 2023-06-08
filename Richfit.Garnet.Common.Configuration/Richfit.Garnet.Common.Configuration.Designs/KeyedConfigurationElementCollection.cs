using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 基础配置元素集合
/// </summary>
/// <typeparam name="E">集合元素类型</typeparam>
/// <typeparam name="K">集合元素键类型</typeparam>
public class KeyedConfigurationElementCollection<E, K> : GenericConfigurationElementCollection<E, K> where E : KeyedConfigurationElement<K>, new()
{
	/// <summary>
	/// 创建基础配置元素集合，配置元素名称区分大小写
	/// </summary>
	public KeyedConfigurationElementCollection()
		: base(ConfigurationElementCollectionType.AddRemoveClearMap, (IComparer)StringComparer.CurrentCulture, string.Empty)
	{
	}

	/// <summary>
	/// 创建基础配置元素集合
	/// </summary>
	/// <param name="collectionType"></param>
	/// <param name="comparer"></param>
	/// <param name="elementName"></param>
	public KeyedConfigurationElementCollection(ConfigurationElementCollectionType collectionType, IComparer comparer, string elementName)
		: base(collectionType, comparer, elementName)
	{
	}

	/// <summary>
	/// 获取指定配置元素的名称
	/// </summary>
	/// <param name="element"></param>
	/// <returns></returns>
	protected override K GetElementKey(E element)
	{
		return element.Key;
	}

	/// <summary>
	/// 将自定义配置元素集合转换为字典
	/// </summary>
	/// <returns></returns>
	public Dictionary<K, object> ToDictionary()
	{
		Dictionary<K, object> dict = new Dictionary<K, object>(base.Count);
		using (IEnumerator<E> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				E element = enumerator.Current;
				dict.Add(element.Key, element.KeyedValue);
			}
		}
		return dict;
	}
}
