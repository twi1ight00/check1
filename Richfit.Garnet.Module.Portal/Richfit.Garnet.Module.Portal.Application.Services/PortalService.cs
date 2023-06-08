using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;
using Richfit.Garnet.Module.Portal.Application.DTO;
using Richfit.Garnet.Module.Portal.Domain.Models;

namespace Richfit.Garnet.Module.Portal.Application.Services;

public class PortalService : ServiceBase, IPortalService
{
	private readonly IRepository<SYS_USER_PORTAL> sysUserPortalRepository;

	private readonly IRepository<SYS_PORTAL> sysPortalRepository;

	public PortalService(IRepository<SYS_PORTAL> sysPortalRepository, IRepository<SYS_USER_PORTAL> sysUserPortalRepository)
	{
		this.sysPortalRepository = sysPortalRepository;
		this.sysUserPortalRepository = sysUserPortalRepository;
	}

	public QueryResult<SYS_PORTALDTO> GetPortals()
	{
		QueryResult<SYS_PORTALDTO> result = new QueryResult<SYS_PORTALDTO>();
		List<SYS_PORTAL> portalList = sysPortalRepository.FindAll() as List<SYS_PORTAL>;
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			List<BusinessDTO> busList = new List<BusinessDTO>();
			if (userSessionInfo.IsSuperUser)
			{
				BusinessMenuCacheLoader.SyncLocker.Read(delegate
				{
					if (LocalCacheBus.Instance.Get("BusinessCacheKey") is Dictionary<Guid, BusinessDTO> dictionary && dictionary.Any())
					{
						busList = dictionary.Values.ToList();
					}
				});
			}
			else
			{
				busList = BusinessMenuManager.GetCurrentUserBusiness() as List<BusinessDTO>;
			}
			foreach (BusinessDTO businessDTO in busList)
			{
				Guid businessID = businessDTO.BUSINESS_ID;
				foreach (SYS_PORTAL portal in portalList)
				{
					if (businessID == portal.PORTAL_ID && portal.ISDEL == 0m)
					{
						result.List.Add(portal.AdaptAsDTO<SYS_PORTALDTO>());
					}
				}
			}
			result.List = result.List.OrderBy((SYS_PORTALDTO p) => p.SORT).ToList();
			IList<SYS_LOCALIZINGDTO> menuLocal = LocalizingCacheManager.GetLocalizing(LocalizingType.Menu);
			result.List.ForEach(delegate(SYS_PORTALDTO x)
			{
				SYS_LOCALIZINGDTO sYS_LOCALIZINGDTO = LocalizingCacheManager.FetchByKey(menuLocal, x.PORTAL_ID.ToString());
				if (sYS_LOCALIZINGDTO != null && sYS_LOCALIZINGDTO != null)
				{
					x.PORTAL_TEXT = sYS_LOCALIZINGDTO.STRING_KEY_DESC;
				}
			});
		}
		return result;
	}

	public QueryResult<SYS_USER_PORTALDTO> GetMyPortals()
	{
		QueryResult<SYS_USER_PORTALDTO> result = new QueryResult<SYS_USER_PORTALDTO>();
		ISpecification<SYS_USER_PORTAL> specification = new ExpressionSpecification<SYS_USER_PORTAL>((SYS_USER_PORTAL s) => s.USER_ID == SessionContext.UserInfo.UserID);
		IEnumerable<SYS_USER_PORTAL> shortcutList = sysUserPortalRepository.FindAll(specification);
		List<SYS_USER_PORTALDTO> list = shortcutList.AdaptAsDTO<SYS_USER_PORTALDTO>();
		list.Sort();
		result.List = list;
		return result;
	}

	public void UpdateMyPortals(List<SYS_USER_PORTALDTO> userPortalDTOs)
	{
		ISpecification<SYS_USER_PORTAL> specification = new ExpressionSpecification<SYS_USER_PORTAL>((SYS_USER_PORTAL s) => s.USER_ID == SessionContext.UserInfo.UserID);
		List<SYS_USER_PORTAL> portalList = sysUserPortalRepository.FindAll(specification) as List<SYS_USER_PORTAL>;
		List<Guid> idlist = new List<Guid>();
		foreach (SYS_USER_PORTAL portal in portalList)
		{
			Guid portaluserid2 = portal.USER_PORTAL_ID;
			if (userPortalDTOs.FindIndex((SYS_USER_PORTALDTO a) => a.USER_PORTAL_ID == portaluserid2) == -1)
			{
				idlist.Add(portaluserid2);
			}
		}
		foreach (Guid portaluserid in idlist)
		{
			SYS_USER_PORTAL poco = sysUserPortalRepository.GetByKey(portaluserid);
			sysUserPortalRepository.Remove(poco);
		}
		foreach (SYS_USER_PORTALDTO dto in userPortalDTOs)
		{
			switch (dto.RecordState)
			{
			case RecordState.Added:
			{
				SYS_USER_PORTAL poco = dto.AdaptAsEntity<SYS_USER_PORTAL>();
				poco.USER_ID = SessionContext.UserInfo.UserID;
				sysUserPortalRepository.Add(poco);
				break;
			}
			case RecordState.Modified:
			{
				SYS_USER_PORTAL poco = sysUserPortalRepository.GetByKey(dto.USER_PORTAL_ID);
				poco.SORT = dto.SORT;
				poco.COL_NUMBER = dto.COL_NUMBER;
				poco.USER_ID = SessionContext.UserInfo.UserID;
				sysUserPortalRepository.Update(poco);
				break;
			}
			case RecordState.Deleted:
			{
				SYS_USER_PORTAL poco = sysUserPortalRepository.GetByKey(dto.USER_PORTAL_ID);
				sysUserPortalRepository.Remove(poco);
				break;
			}
			}
		}
		sysUserPortalRepository.DbContext.Commit();
	}
}
