using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Domain.Models;

namespace Richfit.Garnet.Module.Localizing.Application.Services;

/// <summary>
/// 多语服务接口实现
/// </summary>
public class LocalizingService : ServiceBase, ILocalizingService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<SYS_LOCALIZING> localizingRepository;

	private readonly IRepository<SYS_LANGUAGE> languageRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryLocalizing"></param>
	/// <param name="repositoryLanguage"></param>
	public LocalizingService(IRepository<SYS_LOCALIZING> repositoryLocalizing, IRepository<SYS_LANGUAGE> repositoryLanguage)
	{
		localizingRepository = repositoryLocalizing;
		languageRepository = repositoryLanguage;
	}

	public IList<SYS_LOCALIZINGDTO> GetAllLocalizing()
	{
		Specification<SYS_LOCALIZING> specification = new ExpressionSpecification<SYS_LOCALIZING>((SYS_LOCALIZING x) => x.ISDEL == 0m && x.SYS_LANGUAGE.IS_USE == 1m);
		IEnumerable<SYS_LOCALIZING> localizingPOCOList = localizingRepository.FindAll(specification);
		return localizingPOCOList.AdaptAsDTO<SYS_LOCALIZINGDTO>();
	}

	public IList<SYS_LANGUAGEDTO> GetAllLanguage()
	{
		Specification<SYS_LANGUAGE> specification = new ExpressionSpecification<SYS_LANGUAGE>((SYS_LANGUAGE x) => x.IS_USE == 1m);
		IEnumerable<SYS_LANGUAGE> languagePOCOList = languageRepository.FindAll(specification);
		return languagePOCOList.AdaptAsDTO<SYS_LANGUAGEDTO>();
	}

	public IList<SYS_LOCALIZINGDTO> GetLocalizingByCondition(LocalizingType localizingType, string stringKey)
	{
		Specification<SYS_LOCALIZING> specification = new ExpressionSpecification<SYS_LOCALIZING>((SYS_LOCALIZING x) => x.LOCALIZING_TYPE == (decimal)(int)localizingType && x.SYS_LANGUAGE.IS_USE == 1m);
		if (!string.IsNullOrEmpty(stringKey))
		{
			specification &= (Specification<SYS_LOCALIZING>)new ExpressionSpecification<SYS_LOCALIZING>((SYS_LOCALIZING x) => x.STRING_KEY.Equals(stringKey));
		}
		IEnumerable<SYS_LOCALIZING> localizingPOCOList = localizingRepository.FindAll(specification);
		return localizingPOCOList.AdaptAsDTO<SYS_LOCALIZINGDTO>();
	}

	/// <summary>
	/// 添加多语信息
	/// </summary>
	/// <param name="localizingDTO">码表信息DTO对象</param>
	/// <returns>返回新增的码表DTO对象</returns>
	public SYS_LOCALIZINGDTO AddLocalizing(SYS_LOCALIZINGDTO localizingDTO)
	{
		if (localizingDTO == null)
		{
			throw new ArgumentException("AddLocalizing方法参数不能为空！");
		}
		if (localizingDTO.IsValid())
		{
			SYS_LOCALIZING localizingPOCO = localizingDTO.AdaptAsEntity<SYS_LOCALIZING>();
			localizingRepository.AddCommit(localizingPOCO);
			localizingDTO = localizingPOCO.AdaptAsDTO<SYS_LOCALIZINGDTO>();
			LocalizingCacheManager.AddLocalizing(localizingDTO);
			return localizingDTO;
		}
		throw new ValidationException(localizingDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 批量新增多语信息
	/// </summary>
	/// <param name="localizingDTOList"></param>
	/// <returns></returns>
	public IList<SYS_LOCALIZINGDTO> AddLocalizing(IList<SYS_LOCALIZINGDTO> localizingDTOList)
	{
		if (localizingDTOList == null)
		{
			throw new ArgumentException("AddLocalizing方法参数不能为空！");
		}
		IList<SYS_LOCALIZINGDTO> localizingDTOListReturn = new List<SYS_LOCALIZINGDTO>();
		foreach (SYS_LOCALIZINGDTO localizingDTO in localizingDTOList)
		{
			SYS_LOCALIZING localizingPOCO = localizingDTO.AdaptAsEntity<SYS_LOCALIZING>();
			localizingRepository.Add(localizingPOCO);
			localizingDTOListReturn.Add(localizingPOCO.AdaptAsDTO<SYS_LOCALIZINGDTO>());
		}
		localizingRepository.DbContext.Commit();
		LocalizingCacheManager.AddLocalizing(localizingDTOListReturn);
		return localizingDTOListReturn;
	}

	/// <summary>
	/// 删除码表多语信息
	/// </summary>
	/// <param name="stringKey">码表多语对应的StringKey</param>
	public void RemoveCodeTableLocalizingByStringKey(string stringKey)
	{
		if (!string.IsNullOrEmpty(stringKey))
		{
			Specification<SYS_LOCALIZING> specification = new ExpressionSpecification<SYS_LOCALIZING>((SYS_LOCALIZING x) => x.LOCALIZING_TYPE == 1m && x.SYS_LANGUAGE.IS_USE == 1m);
			specification &= (Specification<SYS_LOCALIZING>)new ExpressionSpecification<SYS_LOCALIZING>((SYS_LOCALIZING x) => x.STRING_KEY.Equals(stringKey));
			IList<SYS_LOCALIZING> delLocalizingList = localizingRepository.FindAll(specification);
			if (delLocalizingList != null && delLocalizingList.Any())
			{
				localizingRepository.RemoveCommit(delLocalizingList);
				LocalizingCacheManager.RemoveLocalizingByCondition(LocalizingType.CodeTable, stringKey);
			}
		}
	}
}
