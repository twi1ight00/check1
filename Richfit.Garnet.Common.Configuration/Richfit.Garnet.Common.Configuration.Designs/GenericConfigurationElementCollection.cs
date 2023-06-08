using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 泛型配置元素集合
/// </summary>
/// <typeparam name="E">配置元素的类型</typeparam>
/// <typeparam name="K">配置元素键的类型</typeparam>
public abstract class GenericConfigurationElementCollection<E, K> : ConfigurationElementCollection, IEnumerable<E>, IEnumerable where E : ConfigurationElement, new()
{
	/// <summary>
	/// 集合类型，分为BasicMap和AddRemoveClearMap
	/// 默认情况下，配置元素集合为AddRemoveClearMap
	/// </summary>
	private ConfigurationElementCollectionType collectionType = ConfigurationElementCollectionType.AddRemoveClearMap;

	/// <summary>
	/// 配置元素名称，默认是空字符串
	/// </summary>
	private string elementName = string.Empty;

	/// <summary>
	/// 获取配置元素集合类型
	/// </summary>
	public override ConfigurationElementCollectionType CollectionType => collectionType;

	/// <summary>
	/// 获取配置元素名称
	/// </summary>
	protected override string ElementName => elementName;

	/// <summary>
	/// 创建命名配置元素集合，配置元素名称区分大小写
	/// </summary>
	public GenericConfigurationElementCollection()
	{
	}

	/// <summary>
	/// 按指定参数创建配置元素集合
	/// </summary>
	/// <param name="collectionType">配置元素集合类型</param>
	/// <param name="comparer">配置元素键值比较器</param>
	/// <param name="elementName">配置元素名称</param>
	public GenericConfigurationElementCollection(ConfigurationElementCollectionType collectionType, IComparer comparer, string elementName)
		: base(comparer)
	{
		elementName.GuardNotNull();
		this.elementName = elementName;
		this.collectionType = collectionType;
	}

	/// <summary>
	/// 对集合中的每一个配置元素进行指定的操作
	/// </summary>
	/// <param name="action">执行的操作</param>
	public void ForEach(Action<E> action)
	{
		for (int i = 0; i < base.Count; i++)
		{
			action(Get(i));
		}
	}

	/// <summary>
	/// 将指定的配置元素添加到集合中
	/// </summary>
	/// <param name="element">配置元素</param>
	/// <returns>添加的配置元素</returns>
	public E Add(E element)
	{
		BaseAdd(element);
		return element;
	}

	/// <summary>
	/// 清空配置元素集合
	/// </summary>
	public void Clear()
	{
		BaseClear();
	}

	/// <summary>
	/// 判断指定名称的配置元素是否存在
	/// </summary>
	/// <param name="key">配置元素的键值</param>
	/// <returns>如果指定键值的配置元素存在则返回true，否则返回false</returns>
	public bool Contains(K key)
	{
		return BaseGet(key) != null;
	}

	/// <summary>
	/// 获取指定索引位置的配置元素
	/// </summary>
	/// <param name="index">配置元素的索引</param>
	/// <returns>指定配置元素的索引</returns>
	public E Get(int index)
	{
		return (E)BaseGet(index);
	}

	/// <summary>
	/// 获取指定名称的配置元素
	/// </summary>
	/// <param name="key">配置元素的名称</param>
	/// <returns>指定的名称的配置元素</returns>
	public E Get(K key)
	{
		return (E)BaseGet(key);
	}

	/// <summary>
	/// 移除指定名称的配置元素
	/// </summary>
	/// <param name="key">需要移除的配置元素的名称</param>
	/// <returns>返回被移除的配置元素；如果指定的配置元素不存在，返回null。</returns>
	public E Remove(K key)
	{
		ConfigurationElement element = BaseGet(key);
		if (element.IsNotNull())
		{
			BaseRemove(key);
		}
		return (E)element;
	}

	/// <summary>
	/// 移除指定的配置元素
	/// </summary>
	/// <param name="element">需要移除的配置元素</param>
	/// <returns>移除的配置元素</returns>
	public E Remove(E element)
	{
		K key = GetElementKey(element);
		return Remove(key);
	}

	/// <summary>
	/// 重新填充配置元素集合
	/// </summary>
	/// <param name="elements">重新填充的配置元素集合</param>
	public void ResetCollection(IEnumerable<E> elements)
	{
		Clear();
		foreach (E element in elements)
		{
			Add(element);
		}
	}

	/// <summary>
	/// 创建新的配置元素
	/// </summary>
	/// <returns>新的配置元素</returns>
	protected override ConfigurationElement CreateNewElement()
	{
		return new E();
	}

	/// <summary>
	/// 获取集合元素键值
	/// </summary>
	/// <param name="element">获取键值的配置元素</param>
	/// <returns>配置元素的键值</returns>
	protected sealed override object GetElementKey(ConfigurationElement element)
	{
		return GetElementKey((E)element);
	}

	/// <summary>
	/// 获取集合元素键值
	/// </summary>
	/// <param name="element">获取键值的配置元素</param>
	/// <returns>配置元素的键值</returns>
	protected abstract K GetElementKey(E element);

	/// <summary>
	/// 获取配置元素的枚举器
	/// </summary>
	/// <returns>配置元素的枚举器</returns>
	public new IEnumerator<E> GetEnumerator()
	{
		foreach (object element in (IEnumerable)this)
		{
			yield return (E)element;
		}
	}
}
