using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 事件处理器列表
/// 根据键值对事件处理委托进行分类
/// 每个事件处理委托在一个分类中只能存在一个
/// 列表不是线程安全的，调用者应负责同步
/// </summary>
public class EventHandlerSet : IDisposable
{
	/// <summary>
	/// 事件处理委托分类列表
	/// </summary>
	private Dictionary<object, List<Delegate>> cache = new Dictionary<object, List<Delegate>>();

	/// <summary>
	/// 获取指定分类的多路广播委托
	/// </summary>
	/// <param name="key">委托分类键</param>
	/// <returns>指定的委托分类下的多路广播</returns>
	public Delegate this[object key]
	{
		get
		{
			key.GuardNotNull();
			return GetHandler(key);
		}
	}

	/// <summary>
	/// 获取指定分类的多路广播委托
	/// </summary>
	/// <param name="key">委托分类键</param>
	/// <returns>指定的委托分类下的多路广播</returns>
	public Delegate GetHandler(object key)
	{
		key.GuardNotNull();
		if (GetCount(key) == 0)
		{
			return null;
		}
		return Delegate.Combine(cache[key].WhereNotNull().ToArray());
	}

	/// <summary>
	/// 获取指定分类的单路委托列表
	/// </summary>
	/// <param name="key">委托分类键</param>
	/// <returns>指定的委托分类下的单路广播数组</returns>
	public Delegate[] GetHandlers(object key)
	{
		key.GuardNotNull();
		if (GetCount(key) == 0)
		{
			return new Delegate[0];
		}
		return cache[key].WhereNotNull().ToArray();
	}

	/// <summary>
	/// 获取指定分类的单路委托数量
	/// </summary>
	/// <param name="key">委托分类键</param>
	/// <returns></returns>
	public int GetCount(object key)
	{
		key.GuardNotNull();
		if (!cache.ContainsKey(key))
		{
			return 0;
		}
		return cache[key].WhereNotNull().Count();
	}

	/// <summary>
	/// 添加事件处理委托
	/// </summary>
	/// <param name="key">分类键</param>
	/// <param name="handler">处理委托</param>
	public void AddHandler(object key, Delegate handler)
	{
		key.GuardNotNull();
		if (!cache.ContainsKey(key))
		{
			cache.Add(key, new List<Delegate>());
		}
		List<Delegate> list = cache[key];
		if (!handler.IsNotNull())
		{
			return;
		}
		Delegate[] handlers = handler.GetInvocationList();
		Delegate[] array = handlers;
		foreach (Delegate h in array)
		{
			if (!list.Contains(h, (Delegate x, Delegate y) => x == y))
			{
				list.Add(handler);
			}
		}
	}

	/// <summary>
	/// 移除分类下所有的事件处理委托，并删除分类
	/// </summary>
	/// <param name="key"></param>
	public void RemoveHandler(object key)
	{
		key.GuardNotNull();
		if (cache.ContainsKey(key))
		{
			cache[key].Clear();
			cache.Remove(key);
		}
	}

	/// <summary>
	/// 移除指定分类中的事件处理委托
	/// </summary>
	/// <param name="key">分类键</param>
	/// <param name="handler">处理委托</param>
	public void RemoveHandler(object key, Delegate handler)
	{
		key.GuardNotNull();
		if (!cache.ContainsKey(key))
		{
			return;
		}
		List<Delegate> list = cache[key];
		if (!handler.IsNotNull())
		{
			return;
		}
		Delegate[] handlers = handler.GetInvocationList();
		Delegate[] array = handlers;
		foreach (Delegate h in array)
		{
			list.RemoveAll(h, (Delegate x, Delegate y) => x == y);
		}
	}

	/// <summary>
	/// 清除所有分类的事件处理委托
	/// </summary>
	public void Clear()
	{
		cache.Values.ForEach(delegate(List<Delegate> list)
		{
			list.Clear();
		});
		cache.Clear();
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public void Dispose()
	{
		Clear();
	}
}
