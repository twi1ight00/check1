using System;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace Richfit.Garnet.Common.Cache.Provider;

/// <summary>
/// 基于 Memcached 的分布式缓存提供者
/// </summary>
public class MemcachedCacheProvider : ICacheProvider
{
	private MemcachedClient memcachedClient = null;

	/// <summary>
	/// 初始化分布式缓存提供者
	/// </summary>
	public MemcachedCacheProvider()
	{
		memcachedClient = new MemcachedClient("enyim/memcached");
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目常驻内存不过期
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	public void Set(string key, object value)
	{
		memcachedClient.Store(StoreMode.Set, key, value);
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目驻留 <paramref name="slidingSpan" /> 指定的时间
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	/// <param name="slidingSpan">项目在缓存中驻留的时间</param>
	public void Set(string key, object value, TimeSpan slidingSpan)
	{
		memcachedClient.Store(StoreMode.Set, key, value, (TimeSpan)slidingSpan);
	}

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目的值由处理函数 <paramref name="valueUpdating" /> 提供
	/// </summary>
	/// <typeparam name="T">添加的缓存项目的类型</typeparam>
	/// <param name="key">缓存项目的键</param>
	/// <param name="valueUpdating">缓存项目的值处理函数</param>
	public void Set<T>(string key, Func<T, T> valueUpdating)
	{
		ulong version;
		T newValue;
		do
		{
			CasResult<T> result = memcachedClient.GetWithCas<T>(key);
			T value = result.Result;
			version = result.Cas;
			newValue = valueUpdating(value);
		}
		while (!memcachedClient.Cas(StoreMode.Set, key, newValue, version).Result);
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
		ulong version;
		T newValue;
		do
		{
			CasResult<T> result = memcachedClient.GetWithCas<T>(key);
			T value = result.Result;
			version = result.Cas;
			newValue = valueUpdating(value);
		}
		while (!memcachedClient.Cas(StoreMode.Set, key, newValue, (TimeSpan)slidingSpan, version).Result);
	}

	/// <summary>
	/// 获取具有指定键的缓存项目的值
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>获取的缓存项目的值</returns>
	public object Get(string key)
	{
		return memcachedClient.Get(key);
	}

	/// <summary>
	/// 根据键值移除缓存对象
	/// </summary>
	/// <param name="key">移除的缓存项目的键</param>
	/// <returns>如果成功移除返回移除的项目值，否则返回空</returns>
	public object Remove(string key)
	{
		return memcachedClient.Remove(key);
	}

	/// <summary>
	/// 移除缓存中的所有项目
	/// </summary>
	public void RemoveAll()
	{
		memcachedClient.FlushAll();
	}

	/// <summary>
	/// 检测缓存中是否存在具有指定的键的项目
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>如果存在返回true，否则返回false。</returns>
	public bool Contains(string key)
	{
		object o;
		return memcachedClient.TryGet(key, out o);
	}
}
