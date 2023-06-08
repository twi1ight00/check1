using System;
using Richfit.Garnet.Common.Cache.Provider;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 整个系统缓存总线，一般用于存放在整个系统中共享的内容，即使系统分布式部署
/// 存储的数据一般是系统运行过程中会发生变化的数据，如Session信息，组织机构信息，人员信息
/// </summary>
public class SystemCacheBus : CacheBusBase
{
	private static readonly Lazy<SystemCacheBus> lazy = new Lazy<SystemCacheBus>(() => new SystemCacheBus());

	private ICacheProvider provider;

	/// <summary>
	/// 获取系统缓存总线实例
	/// </summary>
	public static SystemCacheBus Instance => lazy.Value;

	/// <summary>
	/// 获取缓存对象
	/// </summary>
	public override ICacheProvider Provider
	{
		get
		{
			if (provider == null)
			{
				string cacheProvider = CacheConfig.CacheProvider;
				if (cacheProvider.EqualOrdinal("Memory", ignoreCase: true))
				{
					provider = new MemoryCacheProvider();
				}
				else
				{
					if (!cacheProvider.EqualOrdinal("Memcached", ignoreCase: true))
					{
						throw new Exception("系统缓存初始化错误！");
					}
					provider = new MemcachedCacheProvider();
				}
			}
			return provider;
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private SystemCacheBus()
	{
	}
}
