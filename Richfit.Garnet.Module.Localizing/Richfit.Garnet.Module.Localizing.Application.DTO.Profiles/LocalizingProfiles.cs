using AutoMapper;
using Richfit.Garnet.Module.Localizing.Domain.Models;

namespace Richfit.Garnet.Module.Localizing.Application.DTO.Profiles;

/// <summary>
/// 多语对象映射配置
/// </summary>
public class LocalizingProfiles : Profile
{
	/// <summary>
	/// 映射DTO和POCO
	/// </summary>
	protected override void Configure()
	{
		IMappingExpression<SYS_LANGUAGEDTO, SYS_LANGUAGE> mapLanguageDTO2POCO = Mapper.CreateMap<SYS_LANGUAGEDTO, SYS_LANGUAGE>();
		IMappingExpression<SYS_LANGUAGE, SYS_LANGUAGEDTO> mapLanguagePOCO2DTO = Mapper.CreateMap<SYS_LANGUAGE, SYS_LANGUAGEDTO>();
		IMappingExpression<SYS_LOCALIZINGDTO, SYS_LOCALIZING> mapLocalizingDTO2POCO = Mapper.CreateMap<SYS_LOCALIZINGDTO, SYS_LOCALIZING>();
		IMappingExpression<SYS_LOCALIZING, SYS_LOCALIZINGDTO> mapLocalizingPOCO2DTO = Mapper.CreateMap<SYS_LOCALIZING, SYS_LOCALIZINGDTO>();
	}
}
