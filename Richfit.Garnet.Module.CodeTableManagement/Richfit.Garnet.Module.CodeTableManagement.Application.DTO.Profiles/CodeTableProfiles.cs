using AutoMapper;
using Richfit.Garnet.Module.CodeTableManagement.Domain.Models;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.DTO.Profiles;

/// <summary>
/// DTO映射定义
/// </summary>
public class CodeTableProfiles : Profile
{
	/// <summary>
	/// 映射DTO和POCO
	/// </summary>
	protected override void Configure()
	{
		IMappingExpression<CodeTableDTO, SYS_CODE_TABLE> codeTableDTO2POCO = Mapper.CreateMap<CodeTableDTO, SYS_CODE_TABLE>();
		IMappingExpression<SYS_CODE_TABLE, CodeTableDTO> codeTablePOCO2DTO = Mapper.CreateMap<SYS_CODE_TABLE, CodeTableDTO>();
	}
}
