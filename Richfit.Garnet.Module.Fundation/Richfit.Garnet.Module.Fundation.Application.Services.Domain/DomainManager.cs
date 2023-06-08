using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Domain;

/// <summary>
/// LDAP Domain管理类
/// </summary>
public class DomainManager
{
	/// <summary>
	/// 从缓存获取域的对应信息
	/// </summary>
	/// <returns></returns>
	public static IList<DomainDTO> GetAllDomain()
	{
		return DomainCacheLoader.SyncLocker.Read(() => (LocalCacheBus.Instance.Get("DomainCacheKey") is Dictionary<Guid, DomainDTO> dictionary && dictionary.Any()) ? dictionary.Values.ToList() : null);
	}

	/// <summary>
	/// 根据DomainId得到DomainDTO
	/// </summary>
	/// <param name="domainId"></param>
	/// <returns></returns>
	public static DomainDTO GetDomainById(Guid domainId)
	{
		return DomainCacheLoader.SyncLocker.Read(delegate
		{
			Dictionary<Guid, DomainDTO> dictionary = LocalCacheBus.Instance.Get("DomainCacheKey") as Dictionary<Guid, DomainDTO>;
			DomainDTO value = null;
			if (dictionary != null && dictionary.Any())
			{
				dictionary.TryGetValue(domainId, out value);
			}
			return value;
		});
	}

	/// <summary>
	/// 根据域地址查找域信息
	/// </summary>
	/// <param name="domainAddress"></param>
	/// <returns></returns>
	public static DomainDTO GetDomainByAddress(string domainAddress)
	{
		IList<DomainDTO> domainList = GetAllDomain();
		if (domainList != null && domainList.Any())
		{
			return domainList.Where((DomainDTO x) => x.DOMAIN_ADDRESS.Equals(domainAddress)).FirstOrDefault();
		}
		return null;
	}
}
