using System;
using Richfit.Garnet.Common.Cache.Provider;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 缓存总线基础类，处理缓存的添加，修改，获取，删除的操作
/// </summary>
public abstract class CacheBusBase
{
	/// <summary>
	/// 日志对象
	/// </summary>
	internal static readonly ILogger log = LoggerManager.GetLogger();

	/// <summary>
	/// 获取缓存对象
	/// </summary>
	public abstract ICacheProvider Provider { get; }

	/// <summary>
	/// 指示缓存总线是否是分布式缓存
	/// </summary>
	public bool IsDistributed => Provider is MemoryCacheProvider;

	/// <summary>
	/// 向缓存总线添加指定逻辑处理后的值，该值常驻内存，如果指定的键已经存在将替换值
	/// </summary>
	/// <typeparam name="T">键值类型</typeparam>
	/// <param name="key">缓存的键</param>
	/// <param name="valueUpdating">键值设置方法</param>
	public void Set<T>(string key, Func<T, T> valueUpdating)
	{
		Provider.Set(key, valueUpdating);
	}

	/// <summary>
	/// 向缓存总线添加指定逻辑处理后的值，该值驻留内存时间由 <paramref name="slidingSpan" /> 设定，如果指定的键已经存在将替换值
	/// </summary>
	/// <typeparam name="T">键值类型</typeparam>
	/// <param name="key">缓存的键</param>
	/// <param name="slidingSpan">缓存项目驻留时间</param>
	/// <param name="valueUpdating">键值设置方法</param>
	public void Set<T>(string key, TimeSpan slidingSpan, Func<T, T> valueUpdating)
	{
		Provider.Set(key, slidingSpan, valueUpdating);
	}

	/// <summary>
	/// 向缓存总线添加缓存值，如果指定的键已经存在将替换值
	/// </summary>
	/// <param name="key">缓存的键</param>
	/// <param name="value">缓存的值</param>
	public void Set(string key, object value)
	{
		if (value.IsNotNull())
		{
			Provider.Set(key, value);
		}
	}

	/// <summary>
	/// 向缓存总线添加缓存值，该值驻留内存时间由 <paramref name="slidingSpan" /> 设定，如果指定的键已经存在将替换值
	/// </summary>
	/// <param name="key">缓存的键</param>
	/// <param name="value">缓存的值</param>
	/// <param name="slidingSpan">缓存项目驻留时间</param>
	public void Set(string key, object value, TimeSpan slidingSpan)
	{
		if (value.IsNotNull())
		{
			Provider.Set(key, value, slidingSpan);
		}
	}

	/// <summary>
	/// 向缓存总线添加缓存值，同时提供当缓存值找不到的时候重新加载方法，如果指定的键已经存在将替换值
	/// </summary>
	/// <param name="key">缓存的键</param>
	/// <param name="value">缓存的值</param>
	/// <param name="valueLoading">当缓存值找不到的时候重新加载方法</param>
	/// <param name="param">加载方法调用的参数</param>
	public void Set(string key, object value, Func<object, object> valueLoading, object param)
	{
		if (value.IsNotNull())
		{
			Provider.Set(key, value);
			CacheEntryBox.SetCacheEntry(key, valueLoading, param);
		}
	}

	/// <summary>
	/// 向缓存总线添加缓存值加载的委托方法，由总线加载缓存值，添加时候即时加载，如果指定的键已经存在将替换值
	/// 缓存项常驻内存，当通过Get方法得不到值时，会自动调用委托加载方法，再次加入缓存，除非调用Remove方法才能移除
	/// </summary>
	/// <param name="key">缓存项目的键值</param>
	/// <param name="loadDelegate">缓存加载委托</param>
	public void Set(string key, CacheEntry.LoaderDelegate loadDelegate)
	{
		object value = null;
		if (!loadDelegate.IsNull())
		{
			try
			{
				log.Debug(loadDelegate.Target.ToString() + "-" + loadDelegate.Method.ToString() + "执行开始");
				value = loadDelegate();
				log.Debug(loadDelegate.Target.ToString() + "-" + loadDelegate.Method.ToString() + "执行成功");
			}
			catch
			{
				log.Debug(loadDelegate.Target.ToString() + "-" + loadDelegate.Method.ToString() + "执行失败");
				throw;
			}
			if (value.IsNotNull())
			{
				Provider.Set(key, value);
				CacheEntryBox.SetCacheEntry(key, loadDelegate);
			}
		}
	}

	/// <summary>
	/// 在缓存总线中获取指定的键的缓存值
	/// </summary>
	/// <typeparam name="T">缓存值的类型</typeparam>
	/// <param name="key">获取缓存值的键</param>
	/// <returns>获取指定键的缓存值，如果未找到则返回缓存值类型的默认值</returns>
	public T Get<T>(string key)
	{
		return Get(key).IfNull(default(T)).As<T>();
	}

	/// <summary>
	/// 在缓存总线中获取指定的键的缓存值；如果不存在缓存的指定键则调用该键定义的加载方法（如果已定义）
	/// </summary>
	/// <param name="key">获取缓存值的键</param>
	/// <returns>获取指定键的缓存值，如果未找到则返回空。</returns>
	public object Get(string key)
	{
		object value = Provider.Get(key);
		if (value.IsNull())
		{
			CacheEntry entry = CacheEntryBox.GetCacheEntry(key);
			if (entry.IsNotNull())
			{
				CacheEntry.LoaderDelegate cacheLoader = entry.LoadDelegate;
				if (cacheLoader.IsNotNull())
				{
					try
					{
						value = cacheLoader();
					}
					catch
					{
						CacheEntryBox.RemoveCacheEntry(key);
						throw;
					}
				}
				else if (entry.LoadFunction.IsNotNull())
				{
					try
					{
						value = entry.LoadFunction(entry.FuntionParam);
					}
					catch
					{
						CacheEntryBox.RemoveCacheEntry(key);
						throw;
					}
				}
				if (value != null)
				{
					Provider.Set(key, value);
				}
			}
		}
		return value;
	}

	/// <summary>
	/// 在缓存总线中移除指定键名的缓存项目
	/// </summary>
	/// <param name="key">移除的缓存项目的键名</param>
	/// <returns>如果指定键名的缓存项目存在则返回移除的缓存项目的值，否则返回空。</returns>
	public object Remove(string key)
	{
		CacheEntryBox.RemoveCacheEntry(key);
		return Provider.Remove(key);
	}

	/// <summary>
	/// 检测在缓存总线中指定键名的缓存项目是否存在
	/// </summary>
	/// <param name="key">缓存项目的键名</param>
	/// <returns>如果在缓存总线中指定键名的缓存项目存在返回true，否则返回false。</returns>
	public bool Contains(string key)
	{
		return Provider.Contains(key);
	}

	/// <summary>
	/// 移除缓存总线中所有的缓存项目
	/// </summary>
	internal void RemoveAll()
	{
		CacheEntryBox.RemoveAllCacheEntry();
		Provider.RemoveAll();
	}
}
