using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Module.CodeTableManagement.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.Services;

/// <summary>
/// 码表缓存管理
/// </summary>
public class CodeTableCacheManager
{
	/// <summary>
	/// 增加码表缓存，新增码表时调用
	/// </summary>
	/// <param name="codeTableDTO"></param>
	public static void AddCache(CodeTableDTO codeTableDTO)
	{
		if (codeTableDTO == null)
		{
			return;
		}
		Guid? parentCodeTableId = codeTableDTO.PARENT_CODE_TABLE_ID;
		if (!parentCodeTableId.HasValue || !(parentCodeTableId.Value != Guid.Empty))
		{
			return;
		}
		CodeTableCacheLoader.SyncLocker.Write(delegate
		{
			SystemCacheBus.Instance.Set($"ParentIdToChildrenCacheKey-{parentCodeTableId.Value}", delegate(IList<CodeTableDTO> list)
			{
				if (list != null && list.Any())
				{
					list.Add(codeTableDTO);
				}
				else
				{
					list = new List<CodeTableDTO>();
					list.Add(codeTableDTO);
				}
				return list;
			});
		});
	}

	/// <summary>
	/// 修改码表缓存，修改码表时调用
	/// </summary>
	/// <param name="codeTableDTO"></param>
	public static void UpdateCache(CodeTableDTO codeTableDTO)
	{
		if (codeTableDTO == null)
		{
			return;
		}
		Guid? parentCodeTableId = codeTableDTO.PARENT_CODE_TABLE_ID;
		CodeTableCacheLoader.SyncLocker.Write(delegate
		{
			SystemCacheBus.Instance.Set($"ParentIdToChildrenCacheKey-{parentCodeTableId.Value}", delegate(List<CodeTableDTO> list)
			{
				if (list != null && list.Any())
				{
					list.RemoveAll((CodeTableDTO x) => x.CODE_TABLE_ID == codeTableDTO.CODE_TABLE_ID);
					list.Add(codeTableDTO);
				}
				return list;
			});
		});
	}

	/// <summary>
	/// 移除某码表的缓存，删除码表时调用
	/// </summary>
	/// <param name="codeTableDTO"></param>
	public static void RemoveCache(CodeTableDTO codeTableDTO)
	{
		if (codeTableDTO == null)
		{
			return;
		}
		Guid? parentCodeTableId = codeTableDTO.PARENT_CODE_TABLE_ID;
		CodeTableCacheLoader.SyncLocker.Write(delegate
		{
			SystemCacheBus.Instance.Set($"ParentIdToChildrenCacheKey-{parentCodeTableId.Value}", delegate(List<CodeTableDTO> list)
			{
				if (list != null && list.Any())
				{
					list.RemoveAll((CodeTableDTO x) => x.CODE_TABLE_ID == codeTableDTO.CODE_TABLE_ID);
				}
				return list;
			});
		});
	}

	/// <summary>
	/// 根据父码表的编码值获得码表的绑定数据，关联多语
	/// </summary>
	/// <param name="systemCode">系统编码</param>
	/// <returns></returns>
	public static IList<CodeTableDTO> GetBindingData(string systemCode)
	{
		IList<CodeTableDTO> codeTableListReturn = new List<CodeTableDTO>();
		if (!string.IsNullOrEmpty(systemCode))
		{
			CodeTableCacheLoader.SyncLocker.Read(delegate
			{
				object obj = LocalCacheBus.Instance.Get($"CodeToIdDictionaryCacheKey-{systemCode}");
				if (obj != null)
				{
					Guid value = (Guid)obj;
					codeTableListReturn = GetAllChildCodeTableWithLocalizing(value);
				}
			});
		}
		return codeTableListReturn;
	}

	/// <summary>
	/// 获取码表的描述，如男/女的描述
	/// </summary>
	/// <param name="systemCode">系统编码（系统固定的某类码表的编码）</param>
	/// <param name="businessCode">业务编码,如0、1、2等</param>
	/// <param name="culture">语言，如zh-CN</param>
	/// <returns></returns>
	public static string GetCodeTableDesc(string systemCode, string businessCode, string culture)
	{
		if (!string.IsNullOrEmpty(systemCode) && !string.IsNullOrEmpty(businessCode) && !string.IsNullOrEmpty(culture))
		{
			return CodeTableCacheLoader.SyncLocker.Read(delegate
			{
				object obj = LocalCacheBus.Instance.Get($"CodeToIdDictionaryCacheKey-{systemCode}");
				if (obj != null)
				{
					Guid value = (Guid)obj;
					CodeTableDTO codeTableDTO = GetAllChildCodeTableByParentId(value).FirstOrDefault((CodeTableDTO x) => x.CODE_BUSINESS_NO.Equals(businessCode));
					if (codeTableDTO != null)
					{
						return LocalizingCacheManager.TranslateCodeTable(codeTableDTO.CODE_TABLE_ID.ToString(), culture);
					}
				}
				return string.Empty;
			});
		}
		return string.Empty;
	}

	/// <summary>
	/// 获取码表的描述，如男/女的描述。注：语言为当前Session用户的语言
	/// </summary>
	/// <param name="systemCode">系统编码</param>
	/// <param name="businessCode">业务编码,如0、1、2等</param>
	/// <returns></returns>
	public static string GetCodeTableDesc(string systemCode, string businessCode)
	{
		if (!string.IsNullOrEmpty(systemCode) && !string.IsNullOrEmpty(businessCode))
		{
			return CodeTableCacheLoader.SyncLocker.Read(delegate
			{
				object obj = LocalCacheBus.Instance.Get($"CodeToIdDictionaryCacheKey-{systemCode}");
				if (obj != null)
				{
					Guid value = (Guid)obj;
					CodeTableDTO codeTableDTO = GetAllChildCodeTableByParentId(value).FirstOrDefault((CodeTableDTO x) => x.CODE_BUSINESS_NO.Equals(businessCode));
					if (codeTableDTO != null)
					{
						return LocalizingCacheManager.TranslateCodeTable(codeTableDTO.CODE_TABLE_ID.ToString());
					}
				}
				return string.Empty;
			});
		}
		return string.Empty;
	}

	/// <summary>
	/// 根据码表的父ID获得一级子码表的列表
	/// </summary>
	/// <param name="parentCodeTableId"></param>
	/// <returns></returns>
	private static List<CodeTableDTO> GetFirstLevelCodeTableByParentId(Guid? parentCodeTableId)
	{
		List<CodeTableDTO> codeTableList = new List<CodeTableDTO>();
		if (parentCodeTableId.HasValue && parentCodeTableId.Value != Guid.Empty)
		{
			CodeTableCacheLoader.SyncLocker.Read(delegate
			{
				codeTableList = SystemCacheBus.Instance.Get($"ParentIdToChildrenCacheKey-{parentCodeTableId.Value}") as List<CodeTableDTO>;
				if (!SystemCacheBus.Instance.IsDistributed && codeTableList != null && codeTableList.Any())
				{
					codeTableList = codeTableList.ToList();
				}
				if (codeTableList != null && codeTableList.Any())
				{
					codeTableList = codeTableList.OrderBy((CodeTableDTO x) => x.SORT).ToList();
				}
			});
		}
		return codeTableList;
	}

	/// <summary>
	/// 根据码表的父ID获取以下所有级别码表的列表
	/// </summary>
	/// <param name="parentCodeTableId"></param>
	/// <returns></returns>
	private static List<CodeTableDTO> GetAllChildCodeTableByParentId(Guid? parentCodeTableId)
	{
		List<CodeTableDTO> codeTableDTOList = new List<CodeTableDTO>();
		List<CodeTableDTO> codeTableList = GetFirstLevelCodeTableByParentId(parentCodeTableId);
		if (codeTableList != null && codeTableList.Any())
		{
			codeTableDTOList.AddRange(codeTableList);
			codeTableList.ForEach(delegate(CodeTableDTO x)
			{
				codeTableDTOList.AddRange(GetAllChildCodeTableByParentId(x.CODE_TABLE_ID));
			});
		}
		return codeTableDTOList;
	}

	/// <summary>
	/// 递归获取某码表下的所有码表，码表语言为当前Session语言
	/// </summary>
	/// <param name="parentCodeTableId"></param>
	private static IList<CodeTableDTO> GetAllChildCodeTableWithLocalizing(Guid? parentCodeTableId)
	{
		IList<CodeTableDTO> codeTableList = GetAllChildCodeTableByParentId(parentCodeTableId);
		if (codeTableList.Any())
		{
			IList<SYS_LOCALIZINGDTO> codeTableLocal = LocalizingCacheManager.GetLocalizing(LocalizingType.CodeTable);
			foreach (CodeTableDTO dto in codeTableList)
			{
				SYS_LOCALIZINGDTO localizingDTO = LocalizingCacheManager.FetchByKey(codeTableLocal, dto.CODE_TABLE_ID.ToString());
				if (localizingDTO != null)
				{
					dto.CODEDESC = localizingDTO.STRING_KEY_DESC;
				}
				else
				{
					dto.CODEDESC = dto.CODE_ID;
				}
			}
		}
		return codeTableList;
	}
}
