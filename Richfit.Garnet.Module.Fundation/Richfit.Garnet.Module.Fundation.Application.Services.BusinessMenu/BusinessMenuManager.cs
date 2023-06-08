using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 业务和菜单管理类
/// </summary>
public class BusinessMenuManager
{
	/// <summary>
	///  获得当前用户所能操作的业务功能，先缓存匹配，如果缓存没有，从数据库查找
	/// </summary>
	/// <returns></returns>
	public static IList<BusinessDTO> GetCurrentUserBusiness()
	{
		IList<BusinessDTO> userBusinessList = new List<BusinessDTO>();
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null && !userSessionInfo.IsSuperUser)
		{
			BusinessMenuCacheLoader.SyncLocker.Read(delegate
			{
				IList<Guid> userBusinessIds = GetUserBusinessIds(userSessionInfo.UserID, userSessionInfo.BelongToOrgID);
				if (userBusinessIds != null && userBusinessIds.Any())
				{
					Dictionary<Guid, BusinessDTO> businesDictionary = LocalCacheBus.Instance.Get("BusinessCacheKey") as Dictionary<Guid, BusinessDTO>;
					if (businesDictionary != null)
					{
						userBusinessIds.ForEach(delegate(Guid x)
						{
							if (businesDictionary.ContainsKey(x))
							{
								userBusinessList.Add(businesDictionary[x]);
							}
						});
					}
				}
			});
		}
		return userBusinessList;
	}

	/// <summary>
	/// 根据用户的Token获得用户的菜单
	/// </summary>
	/// <returns></returns>
	public static IList<MenuDTO> GetCurrentUserMenus()
	{
		IList<MenuDTO> userMenuList = new List<MenuDTO>();
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			userMenuList = ((!userSessionInfo.IsSuperUser) ? GetUserMenus(userSessionInfo.UserID, userSessionInfo.BelongToOrgID) : GetAllMenus());
			userMenuList = (from x in userMenuList
				orderby x.PARENTMENUID, x.SORT
				select x).ToList();
			TranslateMenus(userMenuList);
		}
		return userMenuList;
	}

	/// <summary>
	/// 获取用户在某机构下所能操作的业务ID
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="userOrgId"></param>
	/// <returns></returns>
	public static IList<Guid> GetUserBusinessIds(Guid userId, Guid userOrgId)
	{
		return BusinessMenuCacheLoader.SyncLocker.Read(delegate
		{
			IList<Guid> businessIdList = SystemCacheBus.Instance.Get($"UserBusinessCacheKey-{userId}-{userOrgId}") as IList<Guid>;
			if (businessIdList == null)
			{
				BusinessMenuCacheLoader.SyncLocker.Write(delegate
				{
					IUserBusinessService service = ServiceLocator.Instance.GetService<IUserBusinessService>();
					businessIdList = service.GetUserBusinessId(userId, userOrgId);
					if (businessIdList != null && businessIdList.Any())
					{
						SystemCacheBus.Instance.Set($"UserBusinessCacheKey-{userId}-{userOrgId}", businessIdList);
					}
				});
			}
			if (!SystemCacheBus.Instance.IsDistributed && businessIdList != null && businessIdList.Any())
			{
				businessIdList = businessIdList.ToList();
			}
			return businessIdList;
		});
	}

	/// <summary>
	///  缓存中移除用户的业务操作信息，当人员删除，人员角色对应变化，角色对应的业务变化的时候调用此方法移除缓存
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <param name="orgId">用户所在机构ID</param>
	public static void RemoveUserBusiness(Guid userId, Guid orgId)
	{
		BusinessMenuCacheLoader.SyncLocker.Write(delegate
		{
			SystemCacheBus.Instance.Remove($"UserBusinessCacheKey-{userId}-{orgId}");
		});
	}

	/// <summary>
	/// 缓存中移除用户的业务操作信息，当人员删除，人员角色对应变化，角色对应的业务变化的时候调用此方法移除缓存
	/// </summary>
	/// <param name="userId">用户Id</param>
	/// <param name="orgIds">用户对应的组织机构Id</param>
	public static void RemoveUserBusiness(Guid userId, IList<Guid> orgIds)
	{
		BusinessMenuCacheLoader.SyncLocker.Write(delegate
		{
			orgIds.ForEach(delegate(Guid orgId)
			{
				SystemCacheBus.Instance.Remove($"UserBusinessCacheKey-{userId}-{orgId}");
			});
		});
	}

	/// <summary>
	/// 缓存中移除用户的业务操作信息，当人员删除，人员角色对应变化，角色对应的业务变化的时候调用此方法移除缓存
	/// </summary>
	/// <param name="userIds">用户Id列表</param>
	/// <param name="orgId">用户对应的组织机构Id</param>
	public static void RemoveUserBusiness(IList<Guid> userIds, Guid orgId)
	{
		BusinessMenuCacheLoader.SyncLocker.Write(delegate
		{
			userIds.ForEach(delegate(Guid userId)
			{
				SystemCacheBus.Instance.Remove($"UserBusinessCacheKey-{userId}-{orgId}");
			});
		});
	}

	/// <summary>
	/// 缓存中移除用户的业务操作信息，当人员删除，人员角色对应变化，角色对应的业务变化的时候调用此方法移除缓存
	/// </summary>
	/// <param name="userOrgIds">用户和组织机构Mapping结构</param>
	public static void RemoveUserBusiness(ListMapping<Guid, Guid> userOrgIds)
	{
		BusinessMenuCacheLoader.SyncLocker.Write(delegate
		{
			userOrgIds.ForEach(delegate(KeyValuePair<Guid, List<Guid>> x)
			{
				Guid userId = x.Key;
				List<Guid> value = x.Value;
				value.ForEach(delegate(Guid orgId)
				{
					SystemCacheBus.Instance.Remove($"UserBusinessCacheKey-{userId}-{orgId}");
				});
			});
		});
	}

	/// <summary>
	/// 添加某业务的菜单列表，根据parentId递归上找
	/// </summary>
	/// <param name="businessId"></param>
	/// <param name="menuDictionary"></param>
	/// <param name="businessDictionary"></param>
	/// <param name="userMenuList"></param>
	private static void PutMenuByBusiness(Guid businessId, Dictionary<Guid, MenuDTO> menuDictionary, Dictionary<Guid, BusinessDTO> businessDictionary, IList<MenuDTO> userMenuList)
	{
		if (menuDictionary.ContainsKey(businessId))
		{
			MenuDTO menuDTO = null;
			if (menuDictionary.TryGetValue(businessId, out menuDTO) && !userMenuList.Contains(menuDTO))
			{
				userMenuList.Add(menuDTO);
			}
		}
		BusinessDTO businessDTO = null;
		if (businessDictionary.TryGetValue(businessId, out businessDTO) && businessDTO != null && businessDTO.PARENT_BUSINESS_ID.HasValue)
		{
			businessId = businessDTO.PARENT_BUSINESS_ID.Value;
			PutMenuByBusiness(businessId, menuDictionary, businessDictionary, userMenuList);
		}
	}

	/// <summary>
	/// 菜单多语翻译
	/// </summary>
	/// <param name="userMenuList"></param>
	private static void TranslateMenus(IList<MenuDTO> userMenuList)
	{
		if (userMenuList == null || !userMenuList.Any())
		{
			return;
		}
		IList<SYS_LOCALIZINGDTO> menuLocal = LocalizingCacheManager.GetLocalizing(LocalizingType.Menu);
		userMenuList.ForEach(delegate(MenuDTO x)
		{
			SYS_LOCALIZINGDTO sYS_LOCALIZINGDTO = LocalizingCacheManager.FetchByKey(menuLocal, x.MENU_ID.ToString());
			if (sYS_LOCALIZINGDTO != null && sYS_LOCALIZINGDTO != null)
			{
				x.MENUTEXT = sYS_LOCALIZINGDTO.STRING_KEY_DESC;
			}
		});
	}

	/// <summary>
	/// 获得所有菜单
	/// </summary>
	/// <returns></returns>
	private static IList<MenuDTO> GetAllMenus()
	{
		IList<MenuDTO> userMenuList = new List<MenuDTO>();
		BusinessMenuCacheLoader.SyncLocker.Read(delegate
		{
			if (LocalCacheBus.Instance.Get("MenuCacheKey") is Dictionary<Guid, MenuDTO> dictionary && dictionary.Any())
			{
				userMenuList = dictionary.Values.ToList();
				MenuDTO[] array = userMenuList.FindAll((MenuDTO a) => !string.IsNullOrEmpty(a.MENU_URL) && a.MENU_URL.ToLower().Contains("aut"));
				if (array != null && array.Count() <= 0)
				{
				}
			}
		});
		return userMenuList;
	}

	/// <summary>
	/// 得到某用户在某机构下的菜单
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="userOrgId"></param>
	/// <returns></returns>
	private static IList<MenuDTO> GetUserMenus(Guid userId, Guid userOrgId)
	{
		IList<MenuDTO> userMenuList = new List<MenuDTO>();
		BusinessMenuCacheLoader.SyncLocker.Read(delegate
		{
			IList<Guid> userBusinessIds = GetUserBusinessIds(userId, userOrgId);
			Dictionary<Guid, MenuDTO> dictionary = LocalCacheBus.Instance.Get("MenuCacheKey") as Dictionary<Guid, MenuDTO>;
			Dictionary<Guid, BusinessDTO> dictionary2 = LocalCacheBus.Instance.Get("BusinessCacheKey") as Dictionary<Guid, BusinessDTO>;
			if (userBusinessIds != null && userBusinessIds.Any() && dictionary != null && dictionary.Any() && dictionary2 != null && dictionary2.Any())
			{
				foreach (Guid current in userBusinessIds)
				{
					PutMenuByBusiness(current, dictionary, dictionary2, userMenuList);
				}
			}
		});
		return userMenuList;
	}
}
