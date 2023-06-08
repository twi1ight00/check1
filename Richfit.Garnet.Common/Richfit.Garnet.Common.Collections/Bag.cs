using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 用于计算对象被添加到列表中次数的集合
/// </summary>
/// <typeparam name="T">比较器基础类型</typeparam>
public class Bag<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	/// <summary>
	/// 列表元素数量
	/// </summary>
	public virtual int Count => Items.Count;

	/// <summary>
	/// 指示列表是否为只读
	/// </summary>
	public virtual bool IsReadOnly => false;

	/// <summary>
	/// 获取指定项目的计数
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	public virtual int this[T item]
	{
		get
		{
			return Items[item];
		}
		set
		{
			Items[item] = value;
		}
	}

	/// <summary>
	/// 记录对象添加次数的容器
	/// </summary>
	protected virtual Dictionary<T, int> Items { get; set; }

	/// <summary>
	/// Constructor
	/// </summary>
	public Bag()
	{
		Items = new Dictionary<T, int>();
	}

	/// <summary>
	/// 向对象列表中添加对象，记录被添加的次数
	/// </summary>
	/// <param name="item"></param>
	public virtual void Add(T item)
	{
		if (Items.ContainsKey(item))
		{
			Items[item]++;
		}
		else
		{
			Items.Add(item, 1);
		}
	}

	/// <summary>
	/// 向对象列表中添加一系列的对象
	/// </summary>
	/// <param name="items"></param>
	public virtual void Add(IEnumerable<T> items)
	{
		if (items == null)
		{
			return;
		}
		foreach (T item in items)
		{
			Add(item);
		}
	}

	/// <summary>
	/// 清空列表
	/// </summary>
	public virtual void Clear()
	{
		Items.Clear();
	}

	/// <summary>
	/// 列表中是否包含某对象
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	public virtual bool Contains(T item)
	{
		return Items.ContainsKey(item);
	}

	/// <summary>
	/// 将列表中的对象复制到数组
	/// </summary>
	/// <param name="array">Not used</param>
	/// <param name="arrayIndex">Not used</param>
	public virtual void CopyTo(T[] array, int arrayIndex)
	{
		Array.Copy(Items.Keys.ToArray(), 0, array, arrayIndex, Count);
	}

	/// <summary>
	/// 在列表中移除某对象
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	public virtual bool Remove(T item)
	{
		return Items.Remove(item);
	}

	/// <summary>
	/// 获取枚举器
	/// </summary>
	/// <returns></returns>
	public virtual IEnumerator<T> GetEnumerator()
	{
		foreach (T key in Items.Keys)
		{
			yield return key;
		}
	}

	/// <summary>
	/// 获取枚举器
	/// </summary>
	/// <returns></returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (T key in Items.Keys)
		{
			yield return key;
		}
	}
}
