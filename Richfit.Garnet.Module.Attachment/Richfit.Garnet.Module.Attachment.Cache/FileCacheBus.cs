using System;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Cache.Provider;

namespace Richfit.Garnet.Module.Attachment.Cache;

public class FileCacheBus : CacheBusBase
{
	private static readonly Lazy<FileCacheBus> lazy = new Lazy<FileCacheBus>(() => new FileCacheBus());

	private IProvider provider;

	/// <summary>
	/// 获取系统缓存总线实例
	/// </summary>
	public static FileCacheBus Instance => lazy.Value;

	/// <summary>
	/// 获取缓存对象
	/// </summary>
	public override ICacheProvider Provider
	{
		get
		{
			if (provider == null)
			{
				provider = new MemoryCacheProviderEx();
			}
			return provider;
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private FileCacheBus()
	{
	}
}
