using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Richfit.Garnet.Common.Cache.Provider;

/// <summary>
/// 基于内存的缓存提供器
/// </summary>
public class MemoryCacheProvider : ICacheProvider
{
	/// <summary>
	/// 获取缓存对象
	/// </summary>
	protected MemoryCache Cache => MemoryCache.Default;

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目常驻内存不过期
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	public void Set(string key, object value)
	{
		if (value != null)
		{
			CacheItemPolicy cacheItemPolicy = GetPermanentMemoryPolicy();
			Cache.Set(key, value, cacheItemPolicy);
		}
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目驻留 <paramref name="slidingSpan" /> 指定的时间
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	/// <param name="slidingSpan">项目在缓存中驻留的时间</param>
	public void Set(string key, object value, TimeSpan slidingSpan)
	{
		if (value != null)
		{
			CacheItemPolicy cacheItemPolicy = GetMemoryPolicy(slidingSpan);
			Cache.Set(key, value, cacheItemPolicy);
		}
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目的值由处理函数 <paramref name="valueUpdating" /> 提供
	/// </summary>
	/// <typeparam name="T">添加的缓存项目的类型</typeparam>
	/// <param name="key">缓存项目的键</param>
	/// <param name="valueUpdating">缓存项目的值处理函数</param>
	public void Set<T>(string key, Func<T, T> valueUpdating)
	{
		object o = Cache.Get(key);
		T value = ((o == null) ? default(T) : ((T)o));
		value = valueUpdating(value);
		Set(key, value);
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目驻留 <paramref name="slidingSpan" /> 指定的时间；缓存项目的值由处理函数 <paramref name="valueUpdating" /> 提供
	/// </summary>
	/// <typeparam name="T">添加的缓存项目的类型</typeparam>
	/// <param name="key">缓存项目的键</param>
	/// <param name="slidingSpan">驻留内存时间</param>
	/// <param name="valueUpdating">缓存项目的值处理函数</param>
	public void Set<T>(string key, TimeSpan slidingSpan, Func<T, T> valueUpdating)
	{
		object o = Cache.Get(key);
		T value = ((o == null) ? default(T) : ((T)o));
		value = valueUpdating(value);
		Set(key, value, slidingSpan);
	}

	/// <summary>
	/// 获取具有指定键的缓存项目的值
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>获取的缓存项目的值</returns>
	public object Get(string key)
	{
		return Cache.Get(key);
	}

	/// <summary>
	/// 根据键值移除缓存对象
	/// </summary>
	/// <param name="key">移除的缓存项目的键</param>
	/// <returns>如果成功移除返回移除的项目值，否则返回空</returns>
	public object Remove(string key)
	{
		return Cache.Remove(key);
	}

	/// <summary>
	/// 检测缓存中是否存在具有指定的键的项目
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>如果存在返回true，否则返回false。</returns>
	public bool Contains(string key)
	{
		return Cache.Contains(key);
	}

	/// <summary>
	/// 移除缓存中的所有项目
	/// </summary>
	public void RemoveAll()
	{
		IList<string> cacheKeys = Cache.Select((KeyValuePair<string, object> kvp) => kvp.Key).ToList();
		foreach (string cacheKey in cacheKeys)
		{
			Cache.Remove(cacheKey);
		}
	}

	/// <summary>
	/// 获得常驻内存的策略
	/// </summary>
	/// <returns></returns>
	public CacheItemPolicy GetPermanentMemoryPolicy()
	{
		CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
		cacheItemPolicy.Priority = CacheItemPriority.NotRemovable;
		cacheItemPolicy.AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
		cacheItemPolicy.SlidingExpiration = ObjectCache.NoSlidingExpiration;
		return cacheItemPolicy;
	}

	/// <summary>
	/// 获取内存缓存过期策略，根据指定的slidingSpan
	/// </summary>
	/// <param name="slidingSpan"></param>
	/// <returns></returns>
	public CacheItemPolicy GetMemoryPolicy(TimeSpan slidingSpan)
	{
		CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
		cacheItemPolicy.Priority = CacheItemPriority.Default;
		cacheItemPolicy.AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
		cacheItemPolicy.SlidingExpiration = slidingSpan;
		return cacheItemPolicy;
	}
}
