using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.Services;

/// <summary>
/// 码表缓存加载
/// </summary>
public class CodeTableCacheLoader : ICacheLoader
{
	/// <summary>
	/// Cache Key ParentIdToChildrenCacheKey
	/// </summary>
	public const string ParentIdToChildrenCacheKey = "ParentIdToChildrenCacheKey-{0}";

	/// <summary>
	/// Cache Key CodeToIdDictionaryCacheKey
	/// </summary>
	public const string CodeIdToIdCacheKey = "CodeToIdDictionaryCacheKey-{0}";

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
			SetParentIdToChildrenCache();
			SetCodeIdToIdCache();
		});
	}

	private void SetParentIdToChildrenCache()
	{
		ListMapping<Guid, CodeTableDTO> codeTableMapping = new ListMapping<Guid, CodeTableDTO>();
		ICodeTableAppService codeTableService = ServiceLocator.Instance.GetService<ICodeTableAppService>();
		IList<CodeTableDTO> codeTableList = codeTableService.GetAllCodeTable();
		if (codeTableList != null && codeTableList.Any())
		{
			codeTableList.ForEach(delegate(CodeTableDTO x)
			{
				codeTableMapping.Add((!x.PARENT_CODE_TABLE_ID.HasValue) ? Guid.Empty : x.PARENT_CODE_TABLE_ID.Value, x);
			});
		}
		codeTableMapping.ForEach(delegate(KeyValuePair<Guid, List<CodeTableDTO>> x)
		{
			SystemCacheBus.Instance.Set($"ParentIdToChildrenCacheKey-{x.Key}", x.Value, delegate(object p)
			{
				codeTableList = codeTableService.GetFirstLevelChild(p as Guid?);
				return codeTableList;
			}, x.Key);
		});
	}

	private void SetCodeIdToIdCache()
	{
		ICodeTableAppService codeTableService = ServiceLocator.Instance.GetService<ICodeTableAppService>();
		IList<CodeTableDTO> codeTableList = codeTableService.GetSystemCodeTable();
		if (codeTableList == null || !codeTableList.Any())
		{
			return;
		}
		codeTableList.ForEach(delegate(CodeTableDTO x)
		{
			if (!x.CODE_ID.IsNullOrWhiteSpace())
			{
				LocalCacheBus.Instance.Set($"CodeToIdDictionaryCacheKey-{x.CODE_ID}", x.CODE_TABLE_ID);
			}
		});
	}
}
