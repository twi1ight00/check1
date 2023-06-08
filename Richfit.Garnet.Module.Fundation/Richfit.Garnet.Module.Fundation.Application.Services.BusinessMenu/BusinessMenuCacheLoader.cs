using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 业务和菜单缓存加载
/// </summary>
public class BusinessMenuCacheLoader : ICacheLoader
{
	/// <summary>
	/// BusinessCacheKey
	/// </summary>
	public const string BusinessCacheKey = "BusinessCacheKey";

	/// <summary>
	/// MenuCacheKey
	/// </summary>
	public const string MenuCacheKey = "MenuCacheKey";

	/// <summary>
	/// UserBusinessCacheKey
	/// </summary>
	public const string UserBusinessCacheKey = "UserBusinessCacheKey-{0}-{1}";

	/// <summary>
	/// 同步锁
	/// </summary>
	public static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 加载缓存
	/// </summary>
	public void Load()
	{
		SyncLocker.Write(delegate
		{
			LocalCacheBus.Instance.Set("BusinessCacheKey", GetBusinessDictionary);
			LocalCacheBus.Instance.Set("MenuCacheKey", GetMenuDictionary);
		});
	}

	/// <summary>
	/// 菜单缓存字典，存储菜单ID和菜单DTO对象之间的对应关系
	/// </summary>
	/// <returns></returns>
	private Dictionary<Guid, MenuDTO> GetMenuDictionary()
	{
		IBusinessMenuService menuService = ServiceLocator.Instance.GetService<IBusinessMenuService>();
		IList<MenuDTO> menuList = menuService.GetAllMenus();
		Dictionary<Guid, MenuDTO> menuDictionary = new Dictionary<Guid, MenuDTO>();
		if (menuList != null && menuList.Any())
		{
			menuList.ForEach(delegate(MenuDTO x)
			{
				menuDictionary.Add(x.MENU_ID, x);
			});
		}
		return menuDictionary;
	}

	/// <summary>
	/// 业务缓存字典，存储业务ID与业务DTO的关系
	/// </summary>
	/// <returns></returns>
	private Dictionary<Guid, BusinessDTO> GetBusinessDictionary()
	{
		IBusinessMenuService businessService = ServiceLocator.Instance.GetService<IBusinessMenuService>();
		IList<BusinessDTO> businessList = businessService.GetAllBusiness();
		Dictionary<Guid, BusinessDTO> businessDictionary = new Dictionary<Guid, BusinessDTO>();
		if (businessList != null && businessList.Any())
		{
			businessList.ForEach(delegate(BusinessDTO x)
			{
				businessDictionary.Add(x.BUSINESS_ID, x);
			});
		}
		return businessDictionary;
	}
}
