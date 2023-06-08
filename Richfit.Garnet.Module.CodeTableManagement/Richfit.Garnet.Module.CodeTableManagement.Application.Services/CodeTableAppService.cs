using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.CodeTableManagement.Application.DTO;
using Richfit.Garnet.Module.CodeTableManagement.Domain.Models;
using Richfit.Garnet.Module.CodeTableManagement.Domain.Specifications;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;
using Richfit.Garnet.Module.Localizing.Domain.Models;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.Services;

/// <summary>
/// 码表Service
/// </summary>
public class CodeTableAppService : ServiceBase, ICodeTableAppService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<SYS_CODE_TABLE> codeTableRepository;

	private readonly IRepository<SYS_LANGUAGE> languageRepository;

	private ILocalizingService localizingAppService = ServiceLocator.Instance.GetService<ILocalizingService>();

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryCodeTable"></param>
	/// <param name="repositoryLanguage"></param>
	public CodeTableAppService(IRepository<SYS_CODE_TABLE> repositoryCodeTable, IRepository<SYS_LANGUAGE> repositoryLanguage)
	{
		codeTableRepository = repositoryCodeTable;
		languageRepository = repositoryLanguage;
	}

	public CodeTableDTO AddCodeTable(CodeTableAdapterDTO codeTableAdapterDTO)
	{
		if (codeTableAdapterDTO.IsValid())
		{
			CodeTableDTO codeTableDTO = new CodeTableDTO();
			codeTableDTO.PARENT_CODE_TABLE_ID = codeTableAdapterDTO.PARENT_CODE_TABLE_ID;
			codeTableDTO.STATUS = codeTableAdapterDTO.STATUS;
			codeTableDTO.CODE_BUSINESS_NO = codeTableAdapterDTO.CODE_BUSINESS_NO;
			codeTableDTO.SORT = codeTableAdapterDTO.SORT;
			SYS_CODE_TABLE codeTablePOCO = codeTableDTO.AdaptAsEntity<SYS_CODE_TABLE>();
			codeTableRepository.AddCommit(codeTablePOCO);
			if (codeTableAdapterDTO.CULTURELIST.Any())
			{
				codeTableAdapterDTO.CULTURELIST.ForEach(delegate(SYS_LOCALIZINGDTO x)
				{
					x.LOCALIZING_TYPE = 1m;
					x.LANGUAGE_ID = LocalizingCacheManager.GetLanguageIdByCulture(x.CULTURE);
					x.STRING_KEY = GetGuidString(codeTablePOCO.CODE_TABLE_ID, codeTableRepository.DbContext);
					x.STRING_KEY_TIP_DESC = "CodeTableDesc";
				});
				localizingAppService.AddLocalizing(codeTableAdapterDTO.CULTURELIST);
			}
			codeTableDTO = codeTablePOCO.AdaptAsDTO<CodeTableDTO>();
			CodeTableCacheManager.AddCache(codeTableDTO);
			return codeTableDTO;
		}
		throw new ValidationException(codeTableAdapterDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 更新码表信息
	/// </summary>
	/// <param name="codeTableAdapterDTO">码表信息DTO对象</param>
	/// <returns>返回修改后的码表DTO对象</returns>
	public void UpdateCodeTable(CodeTableAdapterDTO codeTableAdapterDTO)
	{
		if (codeTableAdapterDTO.IsValid())
		{
			SYS_CODE_TABLE persisted = codeTableRepository.GetByKey(codeTableAdapterDTO.CODE_TABLE_ID);
			if (persisted == null)
			{
				return;
			}
			persisted.STATUS = codeTableAdapterDTO.STATUS;
			persisted.CODE_BUSINESS_NO = codeTableAdapterDTO.CODE_BUSINESS_NO;
			persisted.SORT = codeTableAdapterDTO.SORT;
			codeTableRepository.UpdateCommit(persisted);
			if (codeTableAdapterDTO.CULTURELIST.Any())
			{
				localizingAppService.RemoveCodeTableLocalizingByStringKey(GetGuidString(persisted.CODE_TABLE_ID, codeTableRepository.DbContext));
				codeTableAdapterDTO.CULTURELIST.ForEach(delegate(SYS_LOCALIZINGDTO x)
				{
					x.LOCALIZING_TYPE = 1m;
					x.LANGUAGE_ID = LocalizingCacheManager.GetLanguageIdByCulture(x.CULTURE);
					x.STRING_KEY = GetGuidString(persisted.CODE_TABLE_ID, codeTableRepository.DbContext);
					x.STRING_KEY_TIP_DESC = "CodeTableDesc";
				});
				localizingAppService.AddLocalizing(codeTableAdapterDTO.CULTURELIST);
			}
			CodeTableDTO newCodeTableDTO = persisted.AdaptAsDTO<CodeTableDTO>();
			CodeTableCacheManager.UpdateCache(newCodeTableDTO);
			return;
		}
		throw new ValidationException(codeTableAdapterDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 逻辑批量删除码表信息通过主键Id
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	public void RemoveCodeTable(string codeTableIds)
	{
		if (string.IsNullOrEmpty(codeTableIds))
		{
			return;
		}
		IList<CodeTableDTO> delCodeTableDTOList = new List<CodeTableDTO>();
		string[] codeTableIdArray = codeTableIds.Split(',');
		if (!codeTableIdArray.Any())
		{
			return;
		}
		codeTableIdArray.ForEach(delegate(string codeTableId)
		{
			SYS_CODE_TABLE byKey = codeTableRepository.GetByKey(Guid.Parse(codeTableId));
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				codeTableRepository.Update(byKey);
				delCodeTableDTOList.Add(byKey.AdaptAsDTO<CodeTableDTO>());
			}
		});
		codeTableRepository.DbContext.Commit();
		delCodeTableDTOList.ForEach(delegate(CodeTableDTO x)
		{
			CodeTableCacheManager.RemoveCache(x);
		});
		codeTableIdArray.ForEach(delegate(string x)
		{
			localizingAppService.RemoveCodeTableLocalizingByStringKey(GetGuidString(new Guid(x), codeTableRepository.DbContext));
		});
	}

	/// <summary>
	/// 通过SqlKey和查询条件查找码表信息
	/// </summary>
	/// <returns>返回包含码表信息的QueryResult</returns>
	public QueryResult<CodeTableListDTO> QueryCodeTableList()
	{
		string sqlKey = "GetCodeTableList";
		QueryResult<CodeTableListDTO> queryResult = new QueryResult<CodeTableListDTO>();
		string sqlExpress = codeTableRepository.GetSqlConfig(sqlKey, GetType());
		IEnumerable<CodeTableCultureDTO> codeTableCultureList = codeTableRepository.ExecuteQuery<CodeTableCultureDTO>(sqlExpress, new object[0]);
		List<CodeTableListDTO> listDTO = new List<CodeTableListDTO>();
		List<string> listCodeTableID = new List<string>();
		codeTableCultureList.ForEach(delegate(CodeTableCultureDTO cultureDTO)
		{
			if (!listCodeTableID.Contains(cultureDTO.CODE_TABLE_ID.ToString()))
			{
				listCodeTableID.Add(cultureDTO.CODE_TABLE_ID.ToString());
			}
		});
		listCodeTableID.ForEach(delegate(string id)
		{
			CodeTableListDTO codeTableListDTO = new CodeTableListDTO();
			IEnumerable<CodeTableCultureDTO> source = codeTableCultureList.Where((CodeTableCultureDTO x) => x.CODE_TABLE_ID == Guid.Parse(id));
			CodeTableCultureDTO topDTO = source.First();
			codeTableListDTO.CODE_TABLE_ID = topDTO.CODE_TABLE_ID;
			codeTableListDTO.PARENT_CODE_TABLE_ID = topDTO.PARENT_CODE_TABLE_ID;
			codeTableListDTO.STATUS = topDTO.STATUS;
			codeTableListDTO.CODE_BUSINESS_NO = topDTO.CODE_BUSINESS_NO;
			codeTableListDTO.SORT = topDTO.SORT;
			codeTableListDTO.CODE_ID = topDTO.CODE_ID;
			IEnumerable<CodeTableCultureDTO> source2 = codeTableCultureList.Where(delegate(CodeTableCultureDTO x)
			{
				Guid cODE_TABLE_ID = x.CODE_TABLE_ID;
				Guid? pARENT_CODE_TABLE_ID = topDTO.PARENT_CODE_TABLE_ID;
				return cODE_TABLE_ID == pARENT_CODE_TABLE_ID && x.CULTURE == SessionContext.UserInfo.LanguageCulture;
			});
			if (source2.Count() > 0)
			{
				codeTableListDTO.PARENTNAME = source2.First().STRING_KEY_DESC;
			}
			source.ForEach(delegate(CodeTableCultureDTO cultureDTO)
			{
				if (!string.IsNullOrEmpty(cultureDTO.CULTURE))
				{
					codeTableListDTO.SetPropertyValue(cultureDTO.CULTURE.Replace('-', '_').ToUpper(), cultureDTO.STRING_KEY_DESC, ignoreCase: false, ignoreMissing: true);
				}
			});
			listDTO.Add(codeTableListDTO);
		});
		queryResult.List = listDTO;
		return queryResult;
	}

	/// <summary>
	/// 启用码表信息通过主键Id
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	public void EnableCodeTable(string codeTableIds)
	{
		if (string.IsNullOrEmpty(codeTableIds))
		{
			return;
		}
		IList<CodeTableDTO> enableCodeTableDTOList = new List<CodeTableDTO>();
		string[] codeTableDTOIds = codeTableIds.Split(',');
		if (codeTableDTOIds.Any())
		{
			codeTableDTOIds.ForEach(delegate(string codeTableId)
			{
				SYS_CODE_TABLE byKey = codeTableRepository.GetByKey(Guid.Parse(codeTableId));
				byKey.STATUS = 1m;
				codeTableRepository.Update(byKey);
				enableCodeTableDTOList.Add(byKey.AdaptAsDTO<CodeTableDTO>());
			});
			codeTableRepository.DbContext.Commit();
			enableCodeTableDTOList.ForEach(delegate(CodeTableDTO x)
			{
				CodeTableCacheManager.RemoveCache(x);
			});
			enableCodeTableDTOList.ForEach(delegate(CodeTableDTO x)
			{
				CodeTableCacheManager.AddCache(x);
			});
		}
	}

	/// <summary>
	/// 禁用码表信息通过主键Id
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	public void DisableCodeTable(string codeTableIds)
	{
		if (string.IsNullOrEmpty(codeTableIds))
		{
			return;
		}
		IList<CodeTableDTO> disableCodeTableDTOList = new List<CodeTableDTO>();
		string[] codeTableDTOIds = codeTableIds.Split(',');
		if (codeTableDTOIds.Any())
		{
			string[] array = codeTableDTOIds;
			foreach (string codeTableId in array)
			{
				SYS_CODE_TABLE codeTablePOCO = codeTableRepository.GetByKey(Guid.Parse(codeTableId));
				codeTablePOCO.STATUS = 2m;
				codeTableRepository.Update(codeTablePOCO);
				disableCodeTableDTOList.Add(codeTablePOCO.AdaptAsDTO<CodeTableDTO>());
			}
			codeTableRepository.DbContext.Commit();
			disableCodeTableDTOList.ForEach(delegate(CodeTableDTO x)
			{
				CodeTableCacheManager.RemoveCache(x);
			});
		}
	}

	public IList<CodeTableDTO> GetAllCodeTable()
	{
		ISpecification<SYS_CODE_TABLE> specification = CodeTableSpecifications.IsDelSpecification(0);
		specification = specification.And(CodeTableSpecifications.StatusSpecification(1));
		IEnumerable<SYS_CODE_TABLE> codeTablePOCOList = codeTableRepository.FindAll(specification);
		codeTablePOCOList = from x in codeTablePOCOList
			orderby x.PARENT_CODE_TABLE_ID, x.SORT
			select x;
		return codeTablePOCOList.AdaptAsDTO<CodeTableDTO>();
	}

	public IList<CodeTableDTO> GetFirstLevelChild(Guid? parentId)
	{
		ISpecification<SYS_CODE_TABLE> specification = CodeTableSpecifications.IsDelSpecification(0);
		specification = specification.And(CodeTableSpecifications.StatusSpecification(1));
		specification = specification.And(new ExpressionSpecification<SYS_CODE_TABLE>((SYS_CODE_TABLE c) => c.PARENT_CODE_TABLE_ID == parentId));
		IEnumerable<SYS_CODE_TABLE> codeTablePOCOList = codeTableRepository.FindAll(specification);
		codeTablePOCOList = codeTablePOCOList.OrderBy((SYS_CODE_TABLE x) => x.SORT);
		return codeTablePOCOList.AdaptAsDTO<CodeTableDTO>();
	}

	public IList<CodeTableDTO> GetSystemCodeTable()
	{
		ISpecification<SYS_CODE_TABLE> specification = CodeTableSpecifications.SystemSpecification();
		IEnumerable<SYS_CODE_TABLE> codeTablePOCOList = codeTableRepository.FindAll(specification);
		return codeTablePOCOList.AdaptAsDTO<CodeTableDTO>();
	}

	public IList<CodeTableNameDTO> GetCodeTableName(string CodeTableId)
	{
		Guid CodeTable_Id = (string.IsNullOrEmpty(CodeTableId) ? Guid.Empty : Guid.Parse(CodeTableId));
		return SqlQuery<CodeTableNameDTO>("GetCodeTableName", new
		{
			CODE_TABLE_ID = CodeTable_Id
		});
	}
}
