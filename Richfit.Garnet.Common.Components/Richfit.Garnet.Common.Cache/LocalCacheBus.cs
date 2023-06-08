using System;
using Richfit.Garnet.Common.Cache.Provider;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 本地缓存总线，一般用于存放只在本应用中共享的内容，不需要分布式共享
/// 存储的数据一般是系统运行过程中不会发生变化的数据，如菜单、业务信息
/// </summary>
public class LocalCacheBus : CacheBusBase
{
	private static readonly Lazy<LocalCacheBus> lazy = new Lazy<LocalCacheBus>(() => new LocalCacheBus());

	private ICacheProvider provider;

	/// <summary>
	/// 获取本地缓存总线实例
	/// </summary>
	public static LocalCacheBus Instance => lazy.Value;

	/// <summary>
	/// 获取缓存对象
	/// </summary>
	public override ICacheProvider Provider
	{
		get
		{
			if (provider == null)
			{
				provider = new MemoryCacheProvider();
			}
			return provider;
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private LocalCacheBus()
	{
	}
}
