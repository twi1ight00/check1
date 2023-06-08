using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 缓存同步容器
/// </summary>
internal class CacheEntryBox
{
	/// <summary>
	/// 读取同步锁
	/// </summary>
	private static readonly ReadWriteLocker syncLocker;

	/// <summary>
	/// 缓存容器
	/// </summary>
	private static readonly Dictionary<string, CacheEntry> container;

	/// <summary>
	/// 获取缓存容器
	/// </summary>
	private static Dictionary<string, CacheEntry> Instance => container;

	/// <summary>
	/// 获取缓存容器中项目的键列表
	/// </summary>
	public static Dictionary<string, CacheEntry>.KeyCollection Keys => syncLocker.Read(() => Instance.Keys);

	/// <summary>
	/// 静态初始化
	/// 强制CLR仅在首次调用本类前才进行初始化，不可提前初始化
	/// </summary>
	static CacheEntryBox()
	{
		syncLocker = new ReadWriteLocker();
		container = new Dictionary<string, CacheEntry>();
	}

	/// <summary>
	/// 创建实例
	/// </summary>
	private CacheEntryBox()
	{
	}

	/// <summary>
	/// 检测缓存中是否包含指定键的项目
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public static bool ContainsCacheEntry(string key)
	{
		return syncLocker.Read(() => Instance.ContainsKey(key));
	}

	/// <summary>
	/// 添加缓存项目
	/// </summary>
	/// <param name="key">缓存项目的键值</param>
	/// <param name="cacheLoader">缓存加载委托</param>
	public static void SetCacheEntry(string key, CacheEntry.LoaderDelegate cacheLoader)
	{
		syncLocker.Write(delegate
		{
			CacheEntry value = new CacheEntry
			{
				LoadDelegate = cacheLoader
			};
			Instance.Remove(key);
			Instance.Add(key, value);
		});
	}

	/// <summary>
	/// 添加缓存项目
	/// </summary>
	/// <param name="key">缓存项目的键值</param>
	/// <param name="cacheLoader">缓存加载函数</param>
	/// <param name="param">缓存加载函数参数</param>
	public static void SetCacheEntry(string key, Func<object, object> cacheLoader, object param)
	{
		syncLocker.Write(delegate
		{
			CacheEntry value = new CacheEntry
			{
				LoadFunction = cacheLoader,
				FuntionParam = param
			};
			Instance.Remove(key);
			Instance.Add(key, value);
		});
	}

	/// <summary>
	/// 移除缓存项目
	/// </summary>
	/// <param name="key">缓存项目的键值</param>
	public static void RemoveCacheEntry(string key)
	{
		syncLocker.Write(delegate
		{
			Instance.Remove(key);
		});
	}

	/// <summary>
	/// 移除所有项目
	/// </summary>
	public static void RemoveAllCacheEntry()
	{
		syncLocker.Write(delegate
		{
			Instance.Clear();
		});
	}

	/// <summary>
	/// 获取缓存项目
	/// </summary>
	/// <param name="key">缓存项目的键值</param>
	/// <returns>制定键值的缓存项目</returns>
	public static CacheEntry GetCacheEntry(string key)
	{
		return syncLocker.Read(() => ContainsCacheEntry(key) ? Instance[key] : null);
	}
}
