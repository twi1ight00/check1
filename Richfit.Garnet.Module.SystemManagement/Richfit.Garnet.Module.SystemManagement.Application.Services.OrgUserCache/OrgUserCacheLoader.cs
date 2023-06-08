using System.Collections.Generic;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

/// <summary>
/// 机构和人员数据缓存加载
/// </summary>
public class OrgUserCacheLoader : ICacheLoader
{
	/// <summary>
	/// OrgUserTreeCacheKey
	/// </summary>
	public const string OrgUserTreeCacheKey = "OrgUserTreeCacheKey";

	/// <summary>
	/// OrgUserChangedCacheKey
	/// </summary>
	public const string OrgUserChangedCacheKey = "OrgUserChangedCacheKey-{0}";

	/// <summary>
	/// 同步锁
	/// </summary>
	public static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	public void Load()
	{
		if (IsCache())
		{
			SyncLocker.Write(delegate
			{
				LocalCacheBus.Instance.Set("OrgUserTreeCacheKey", GetOrgUserTreeCache);
			});
		}
	}

	private IList<OrgDTO> GetOrgUserTreeCache()
	{
		IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
		return orgUserService.LoadOrgUserTreeCacheData();
	}

	/// <summary>
	/// 判断组织机构人员是否缓存
	/// </summary>
	/// <returns></returns>
	public static bool IsCache()
	{
		string isCacheOrgUserTree = ConfigurationManager.CurrentPackage.Settings["CacheOrgUserTree"].ToString();
		return isCacheOrgUserTree.EqualOrdinal("true", ignoreCase: true);
	}
}
