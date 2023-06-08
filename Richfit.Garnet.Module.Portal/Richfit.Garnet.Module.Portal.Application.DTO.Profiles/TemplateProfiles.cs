using AutoMapper;
using Richfit.Garnet.Module.Portal.Domain.Models;

namespace Richfit.Garnet.Module.Portal.Application.DTO.Profiles;

/// <summary>
/// Template对象映射配置
/// </summary>
public class TemplateProfiles : Profile
{
	/// <summary>
	/// 映射DTO和POCO
	/// </summary>
	protected override void Configure()
	{
		Mapper.CreateMap<SYS_PORTAL, SYS_PORTALDTO>();
		Mapper.CreateMap<SYS_PORTALDTO, SYS_PORTAL>();
		Mapper.CreateMap<SYS_SHORTCUT, SYS_SHORTCUTDTO>();
		Mapper.CreateMap<SYS_SHORTCUTDTO, SYS_SHORTCUT>();
		Mapper.CreateMap<SYS_USER_PORTAL, SYS_USER_PORTALDTO>();
		Mapper.CreateMap<SYS_USER_PORTALDTO, SYS_USER_PORTAL>();
	}
}
