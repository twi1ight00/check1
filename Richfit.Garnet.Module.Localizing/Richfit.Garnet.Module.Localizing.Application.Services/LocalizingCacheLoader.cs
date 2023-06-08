using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.Localizing.Application.Services;

/// <summary>
/// 多语信息加入Cache
/// </summary>
public class LocalizingCacheLoader : ICacheLoader
{
	/// <summary>
	/// LocalizingCacheKey
	/// </summary>
	public const string LocalizingCacheKey = "LocalizingCacheKey-{0}";

	/// <summary>
	/// LanguageCacheKey
	/// </summary>
	public const string LanguageCacheKey = "LanguageCacheKey";

	/// <summary>
	/// 同步锁
	/// </summary>
	internal static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 加载
	/// </summary>
	public void Load()
	{
		SyncLocker.Write(delegate
		{
			LocalCacheBus.Instance.Set("LanguageCacheKey", GetAllLanguage);
			SetLocalizingCache();
		});
	}

	private void SetLocalizingCache()
	{
		ILocalizingService localizingAppService = ServiceLocator.Instance.GetService<ILocalizingService>();
		IList<SYS_LOCALIZINGDTO> localizingList = localizingAppService.GetAllLocalizing();
		Array array = Enum.GetValues(typeof(LocalizingType));
		foreach (object item in array)
		{
			decimal localizingType = (int)item.ToString().ConvertToEnum<LocalizingType>();
			IList<SYS_LOCALIZINGDTO> typeLocalizingList = localizingList.Where((SYS_LOCALIZINGDTO x) => x.LOCALIZING_TYPE == localizingType).ToList();
			SystemCacheBus.Instance.Set($"LocalizingCacheKey-{item}", typeLocalizingList, delegate(object p)
			{
				localizingList = localizingAppService.GetLocalizingByCondition((LocalizingType)p, null);
				return localizingList;
			}, item);
		}
	}

	/// <summary>
	/// 获得所有语言
	/// </summary>
	/// <returns></returns>
	private IList<SYS_LANGUAGEDTO> GetAllLanguage()
	{
		ILocalizingService localizingAppService = ServiceLocator.Instance.GetService<ILocalizingService>();
		return localizingAppService.GetAllLanguage();
	}
}
