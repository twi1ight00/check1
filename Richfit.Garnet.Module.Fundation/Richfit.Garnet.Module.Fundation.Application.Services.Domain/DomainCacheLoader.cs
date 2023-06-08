using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Domain.Models;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Domain;

/// <summary>
/// LDAP Domain缓存加载
/// </summary>
public class DomainCacheLoader : ICacheLoader
{
	/// <summary>
	/// DomainCacheKey
	/// </summary>
	public const string DomainCacheKey = "DomainCacheKey";

	/// <summary>
	/// 同步锁
	/// </summary>
	internal static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 缓存加载
	/// </summary>
	public void Load()
	{
		SyncLocker.Write(delegate
		{
			LocalCacheBus.Instance.Set("DomainCacheKey", GetAllDomainMapping);
		});
	}

	/// <summary>
	/// 获得域ID和对象对应的Dictionary
	/// </summary>
	/// <returns></returns>
	private Dictionary<Guid, DomainDTO> GetAllDomainMapping()
	{
		Dictionary<Guid, DomainDTO> domainDictionary = new Dictionary<Guid, DomainDTO>();
		IRepository<SYS_DOMAIN> domainRepository = ServiceLocator.Instance.GetService<IRepository<SYS_DOMAIN>>();
		Specification<SYS_DOMAIN> specification = new ExpressionSpecification<SYS_DOMAIN>((SYS_DOMAIN x) => x.ISDEL == 0m);
		IList<SYS_DOMAIN> domains = domainRepository.FindAll(specification, "Sort asc");
		if (domains != null && domains.Any())
		{
			IList<DomainDTO> domainDTOList = domains.AdaptAsDTO<DomainDTO>();
			if (domainDTOList != null)
			{
				foreach (DomainDTO dto in domainDTOList)
				{
					domainDictionary.Add(dto.DOMAIN_ID, dto);
				}
			}
		}
		return domainDictionary;
	}
}
