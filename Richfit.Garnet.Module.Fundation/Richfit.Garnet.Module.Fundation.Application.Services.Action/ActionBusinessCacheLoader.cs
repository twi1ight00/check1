using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Action;

/// <summary>
/// Action和业务对应关系的缓存，用于判断用户是否能执行某action
/// </summary>
public class ActionBusinessCacheLoader : ICacheLoader
{
	/// <summary>
	/// ActionBusinessCacheKey
	/// </summary>
	public const string ActionBusinessCacheKey = "ActionBusinessCacheKey-{0}-{1}";

	/// <summary>
	/// ActionHandlerCacheKey
	/// </summary>
	public const string ActionHandlerCacheKey = "ActionHandlerCacheKey-{0}";

	/// <summary>
	/// ActionValidateTypeCacheKey
	/// </summary>
	public const string ActionValidateTypeCacheKey = "ActionValidateTypeCacheKey-{0}";

	/// <summary>
	/// 同步锁
	/// </summary>
	internal static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 加载缓存
	/// </summary>
	public void Load()
	{
		SyncLocker.Write(delegate
		{
			SetActionBusinessCache();
			SetActionHandlerCache();
		});
	}

	private void SetActionBusinessCache()
	{
		IActionService actionService = ServiceLocator.Instance.GetService<IActionService>();
		IList<ActionBusinessDTO> actionBusinessList = actionService.GetAllActionBusinessMapping();
		if (actionBusinessList == null || !actionBusinessList.Any())
		{
			return;
		}
		IBusinessMenuService businessService = ServiceLocator.Instance.GetService<IBusinessMenuService>();
		IList<BusinessDTO> businessList = businessService.GetAllBusiness();
		foreach (ActionBusinessDTO dto in actionBusinessList)
		{
			List<Guid> buninessIdList = GetBusinessIdList(dto.BUSINESS_ID, businessList);
			Action<Guid> action = delegate(Guid x)
			{
				LocalCacheBus.Instance.Set($"ActionBusinessCacheKey-{dto.ACTION_CODE}-{x}", true);
			};
			buninessIdList.ForEach(action);
		}
	}

	/// <summary>
	/// 获取某BusinessID对应的一串继承的BusinessID
	/// </summary>
	/// <param name="businessId"></param>
	/// <param name="businessList"></param>
	/// <returns></returns>
	private List<Guid> GetBusinessIdList(Guid businessId, IList<BusinessDTO> businessList)
	{
		List<Guid> listReturn = new List<Guid>();
		listReturn.Add(businessId);
		if (businessList != null && businessList.Any())
		{
			businessList.Where((BusinessDTO x) => x.PARENT_BUSINESS_ID == businessId).ForEach(delegate(BusinessDTO x)
			{
				listReturn.AddRange(GetBusinessIdList(x.BUSINESS_ID, businessList));
			});
		}
		return listReturn;
	}

	private void SetActionHandlerCache()
	{
		IActionService actionService = ServiceLocator.Instance.GetService<IActionService>();
		IList<ActionHandlerDTO> actionHandlerList = actionService.GetAllActionHandlerMapping();
		if (actionHandlerList == null || !actionHandlerList.Any())
		{
			return;
		}
		foreach (ActionHandlerDTO dto in actionHandlerList)
		{
			LocalCacheBus.Instance.Set($"ActionHandlerCacheKey-{dto.ACTION_CODE}", dto.ASSEMBLY_NAME);
			LocalCacheBus.Instance.Set($"ActionValidateTypeCacheKey-{dto.ACTION_CODE}", dto.PRIVIGE_VALIDATE_TYPE);
		}
	}
}
