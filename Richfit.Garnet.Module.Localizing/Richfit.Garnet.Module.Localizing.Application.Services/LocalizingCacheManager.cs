using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.Localizing.Application.Services;

/// <summary>
/// 多语缓存管理
/// </summary>
public class LocalizingCacheManager
{
	/// <summary>
	/// 根据CULTURE得到语言的ID
	/// </summary>
	/// <param name="culture"></param>
	/// <returns></returns>
	public static Guid GetLanguageIdByCulture(string culture)
	{
		return LocalizingCacheLoader.SyncLocker.Read(delegate
		{
			if (LocalCacheBus.Instance.Get("LanguageCacheKey") is IList<SYS_LANGUAGEDTO> source && source.Any())
			{
				SYS_LANGUAGEDTO sYS_LANGUAGEDTO = source.Where((SYS_LANGUAGEDTO x) => x.CULTURE.Equals(culture, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
				if (sYS_LANGUAGEDTO != null)
				{
					return sYS_LANGUAGEDTO.LANGUAGE_ID;
				}
			}
			return Guid.Empty;
		});
	}

	/// <summary>
	/// 根据语言的ID得到CULTURE
	/// </summary>
	/// <param name="languageId"></param>
	/// <returns></returns>
	public static string GetCultureByLanguageId(Guid languageId)
	{
		return LocalizingCacheLoader.SyncLocker.Read(delegate
		{
			if (LocalCacheBus.Instance.Get("LanguageCacheKey") is IList<SYS_LANGUAGEDTO> source && source.Any())
			{
				SYS_LANGUAGEDTO sYS_LANGUAGEDTO = source.Where((SYS_LANGUAGEDTO x) => x.LANGUAGE_ID == languageId).FirstOrDefault();
				if (sYS_LANGUAGEDTO != null)
				{
					return sYS_LANGUAGEDTO.CULTURE;
				}
			}
			return string.Empty;
		});
	}

	/// <summary>
	/// 得到当前用户的语言ID
	/// </summary>
	/// <returns></returns>
	public static Guid GetCurrentUserLanguageId()
	{
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo == null)
		{
			return Guid.Empty;
		}
		string culture = userSessionInfo.LanguageCulture;
		return GetLanguageIdByCulture(culture);
	}

	/// <summary>
	/// 从缓存获得所有语言
	/// </summary>
	/// <returns></returns>
	public static IList<SYS_LANGUAGEDTO> GetAllLanguage()
	{
		IList<SYS_LANGUAGEDTO> languageList = new List<SYS_LANGUAGEDTO>();
		LocalizingCacheLoader.SyncLocker.Read(delegate
		{
			languageList = LocalCacheBus.Instance.Get("LanguageCacheKey") as IList<SYS_LANGUAGEDTO>;
			if (languageList != null && languageList.Any())
			{
				languageList = languageList.ToList();
			}
			else
			{
				languageList = new List<SYS_LANGUAGEDTO>();
			}
		});
		return languageList;
	}

	/// <summary>
	/// 从缓存获得当前语言的某种类型的多语信息
	/// </summary>
	/// <param name="localizingType">多语类型</param>
	/// <returns></returns>
	public static IList<SYS_LOCALIZINGDTO> GetLocalizing(LocalizingType localizingType)
	{
		Guid languageId = GetCurrentUserLanguageId();
		return GetLocalizing(languageId, localizingType);
	}

	/// <summary>
	/// 从缓存获得某模块某页面的多语信息
	/// </summary>
	/// <param name="moduleName">模块名称</param>
	/// <param name="pageName">页名称</param>
	/// <param name="culture">语言信息（如：Zh_CN）</param>
	/// <returns></returns>
	public static IList<SYS_LOCALIZINGDTO> GetLocalizing(string moduleName, string pageName, string culture)
	{
		Guid languageId = GetLanguageIdByCulture(culture);
		List<SYS_LOCALIZINGDTO> localizingDTOList = new List<SYS_LOCALIZINGDTO>();
		IList<SYS_LOCALIZINGDTO> localizingDTOs = GetLocalizing(languageId, LocalizingType.Control);
		localizingDTOList.AddRange(localizingDTOs.Where((SYS_LOCALIZINGDTO x) => !string.IsNullOrWhiteSpace(x.INSTANCE) && x.INSTANCE.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrWhiteSpace(x.PAGENAME) && x.PAGENAME.Equals(pageName, StringComparison.CurrentCultureIgnoreCase)).ToList());
		localizingDTOs = GetLocalizing(languageId, LocalizingType.GridView);
		localizingDTOList.AddRange(localizingDTOs.Where((SYS_LOCALIZINGDTO x) => !string.IsNullOrWhiteSpace(x.INSTANCE) && x.INSTANCE.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrWhiteSpace(x.PAGENAME) && x.PAGENAME.Equals(pageName, StringComparison.CurrentCultureIgnoreCase)).ToList());
		localizingDTOs = GetLocalizing(languageId, LocalizingType.Message);
		localizingDTOList.AddRange(localizingDTOs.Where((SYS_LOCALIZINGDTO x) => !string.IsNullOrWhiteSpace(x.INSTANCE) && x.INSTANCE.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrWhiteSpace(x.PAGENAME) && x.PAGENAME.Equals(pageName, StringComparison.CurrentCultureIgnoreCase)).ToList());
		return localizingDTOList;
	}

	/// <summary>
	/// 在多语集合中根据key值获取对应的多语对象
	/// </summary>
	/// <param name="localizingList">多语实体集合</param>
	/// <param name="stringKey">stringKey</param>
	/// <returns></returns>
	public static SYS_LOCALIZINGDTO FetchByKey(IList<SYS_LOCALIZINGDTO> localizingList, string stringKey)
	{
		stringKey = Utility.GetGuidString(stringKey);
		return localizingList.Where((SYS_LOCALIZINGDTO x) => x.STRING_KEY.Equals(stringKey)).FirstOrDefault();
	}

	/// <summary>
	/// 在多语集合中根据key值获得多语值
	/// </summary>
	/// <param name="localizingList">多语实体集合</param>
	/// <param name="stringKey">stringKey</param>
	/// <returns></returns>
	public static string TranslateByKey(IList<SYS_LOCALIZINGDTO> localizingList, string stringKey)
	{
		SYS_LOCALIZINGDTO localizing = FetchByKey(localizingList, stringKey);
		if (localizing != null)
		{
			return localizing.STRING_KEY_DESC;
		}
		return string.Empty;
	}

	/// <summary>
	/// 移除多语缓存
	/// </summary>
	/// <param name="localizingType"></param>
	/// <param name="stringKey"></param>
	public static void RemoveLocalizingByCondition(LocalizingType localizingType, string stringKey)
	{
		if (string.IsNullOrEmpty(stringKey))
		{
			return;
		}
		LocalizingCacheLoader.SyncLocker.Write(delegate
		{
			SystemCacheBus.Instance.Set($"LocalizingCacheKey-{localizingType}", delegate(List<SYS_LOCALIZINGDTO> list)
			{
				if (list != null && list.Any())
				{
					list.RemoveAll((SYS_LOCALIZINGDTO x) => x.STRING_KEY.Equals(stringKey));
				}
				return list;
			});
		});
	}

	/// <summary>
	/// 添加多语缓存
	/// </summary>
	/// <param name="localizingList"></param>
	public static void AddLocalizing(IList<SYS_LOCALIZINGDTO> localizingList)
	{
		if (localizingList == null || !localizingList.Any())
		{
			return;
		}
		LocalizingCacheLoader.SyncLocker.Write(delegate
		{
			IEnumerable<IGrouping<decimal, SYS_LOCALIZINGDTO>> source = from x in localizingList
				group x by x.LOCALIZING_TYPE;
			source.ForEach(delegate(IGrouping<decimal, SYS_LOCALIZINGDTO> t)
			{
				LocalizingType localizingType = t.Key.ConvertToEnum<LocalizingType>();
				SystemCacheBus.Instance.Set($"LocalizingCacheKey-{localizingType}", delegate(List<SYS_LOCALIZINGDTO> list)
				{
					if (list != null && list.Any())
					{
						list.AddRange(t);
					}
					else
					{
						list = new List<SYS_LOCALIZINGDTO>();
						list.AddRange(t);
					}
					return list;
				});
			});
		});
	}

	/// <summary>
	/// 添加多语缓存，单个对象
	/// </summary>
	/// <param name="localizingDTO"></param>
	public static void AddLocalizing(SYS_LOCALIZINGDTO localizingDTO)
	{
		if (localizingDTO == null)
		{
			return;
		}
		LocalizingCacheLoader.SyncLocker.Write(delegate
		{
			LocalizingType localizingType = localizingDTO.LOCALIZING_TYPE.ConvertToEnum<LocalizingType>();
			SystemCacheBus.Instance.Set($"LocalizingCacheKey-{localizingType}", delegate(List<SYS_LOCALIZINGDTO> list)
			{
				if (list != null && list.Any())
				{
					list.Add(localizingDTO);
				}
				else
				{
					list = new List<SYS_LOCALIZINGDTO>();
					list.Add(localizingDTO);
				}
				return list;
			});
		});
	}

	/// <summary>
	/// 获取前端UI用到的多语信息。注：语言为当前Session用户的语言
	/// </summary>
	/// <returns></returns>
	public static IList<SYS_LOCALIZINGDTO> GetUserUILocalizing()
	{
		Guid languageId = GetCurrentUserLanguageId();
		List<SYS_LOCALIZINGDTO> localizingDTOList = new List<SYS_LOCALIZINGDTO>();
		localizingDTOList.AddRange(GetLocalizing(languageId, LocalizingType.Control));
		localizingDTOList.AddRange(GetLocalizing(languageId, LocalizingType.GridView));
		localizingDTOList.AddRange(GetLocalizing(languageId, LocalizingType.Message));
		return localizingDTOList;
	}

	/// <summary>
	/// 码表多语翻译，用于后台查询列表中码表列的翻译。注：语言为当前Session用户的语言
	/// </summary>
	/// <param name="stringKey"></param>
	/// <returns></returns>
	public static string TranslateCodeTable(string stringKey)
	{
		SYS_LOCALIZINGDTO localizingDTO = GetLocalizing(LocalizingType.CodeTable, stringKey, GetCurrentUserLanguageId());
		if (localizingDTO != null)
		{
			return localizingDTO.STRING_KEY_DESC;
		}
		return string.Empty;
	}

	/// <summary>
	/// 码表多语翻译，用于后台查询列表中码表列的翻译
	/// </summary>
	/// <param name="stringKey"></param>
	/// <param name="culture">语言Culture，如zh-CN</param>
	/// <returns></returns>
	public static string TranslateCodeTable(string stringKey, string culture)
	{
		SYS_LOCALIZINGDTO localizingDTO = GetLocalizing(LocalizingType.CodeTable, stringKey, GetLanguageIdByCulture(culture));
		if (localizingDTO != null)
		{
			return localizingDTO.STRING_KEY_DESC;
		}
		return string.Empty;
	}

	/// <summary>
	/// 系统数据翻译，用于后台查询列表中系统数据列的翻译，如系统管理中角色类型等。注：语言为当前Session用户的语言
	/// </summary>
	/// <param name="stringKey"></param>
	/// <param name="systemDataType"></param>
	/// <returns></returns>
	public static string TranslateSystemData(string stringKey, string systemDataType)
	{
		if (!string.IsNullOrEmpty(stringKey) && !string.IsNullOrEmpty(systemDataType))
		{
			Guid languageId = GetCurrentUserLanguageId();
			stringKey = Utility.GetGuidString(stringKey);
			IList<SYS_LOCALIZINGDTO> localizingDTOs = GetLocalizing(languageId, LocalizingType.SystemData);
			SYS_LOCALIZINGDTO localizingDTO = localizingDTOs.Where((SYS_LOCALIZINGDTO x) => x.PAGENAME.Equals(systemDataType) && x.STRING_KEY.Equals(stringKey)).FirstOrDefault();
			return localizingDTO.STRING_KEY_DESC;
		}
		return string.Empty;
	}

	/// <summary>
	/// 获得某系统数据的绑定列表，用于前台数据绑定。注：语言为当前Session用户的语言
	/// </summary>
	/// <param name="systemDataType"></param>
	/// <returns></returns>
	public static IList<SYS_LOCALIZINGDTO> GetSystemData(string systemDataType)
	{
		IList<SYS_LOCALIZINGDTO> localizingDTOList = new List<SYS_LOCALIZINGDTO>();
		if (!string.IsNullOrEmpty(systemDataType))
		{
			Guid languageId = GetCurrentUserLanguageId();
			IList<SYS_LOCALIZINGDTO> localizingDTOs = GetLocalizing(languageId, LocalizingType.SystemData);
			localizingDTOList = localizingDTOs.Where((SYS_LOCALIZINGDTO x) => x.PAGENAME.Equals(systemDataType)).ToList();
		}
		return localizingDTOList;
	}

	/// <summary>
	/// 获得指定culture的某系统数据的绑定列表
	/// </summary>
	/// <param name="systemDataType"></param>
	/// <param name="culture"></param>
	/// <returns></returns>
	public static IList<SYS_LOCALIZINGDTO> GetSystemData(string systemDataType, string culture)
	{
		IList<SYS_LOCALIZINGDTO> localizingDTOList = new List<SYS_LOCALIZINGDTO>();
		if (!string.IsNullOrEmpty(systemDataType))
		{
			Guid languageId = GetLanguageIdByCulture(culture);
			IList<SYS_LOCALIZINGDTO> localizingDTOs = GetLocalizing(languageId, LocalizingType.SystemData);
			localizingDTOList = localizingDTOs.Where((SYS_LOCALIZINGDTO x) => x.PAGENAME.Equals(systemDataType)).ToList();
		}
		return localizingDTOList;
	}

	/// <summary>
	/// 获得某种语言类型的某键值的某种语言的多语信息
	/// </summary>
	/// <param name="localizingType"></param>
	/// <param name="stringKey"></param>
	/// <param name="languageId"></param>
	/// <returns></returns>
	private static SYS_LOCALIZINGDTO GetLocalizing(LocalizingType localizingType, string stringKey, Guid languageId)
	{
		if (languageId == Guid.Empty || string.IsNullOrEmpty(stringKey))
		{
			return null;
		}
		return LocalizingCacheLoader.SyncLocker.Read(delegate
		{
			stringKey = Utility.GetGuidString(stringKey);
			IList<SYS_LOCALIZINGDTO> localizing = GetLocalizing(languageId, localizingType);
			return localizing.Where((SYS_LOCALIZINGDTO x) => x.STRING_KEY.Equals(stringKey)).FirstOrDefault();
		});
	}

	/// <summary>
	/// 从缓存获得多语表信息
	/// </summary>
	/// <param name="languageId">语言ID</param>
	/// <param name="localizingType">多语类型</param>
	/// <returns></returns>
	private static IList<SYS_LOCALIZINGDTO> GetLocalizing(Guid languageId, LocalizingType localizingType)
	{
		return LocalizingCacheLoader.SyncLocker.Read(() => (SystemCacheBus.Instance.Get($"LocalizingCacheKey-{localizingType}") is IList<SYS_LOCALIZINGDTO> source && source.Any()) ? source.Where((SYS_LOCALIZINGDTO x) => x.LANGUAGE_ID == languageId).ToList() : new List<SYS_LOCALIZINGDTO>());
	}
}
