using AutoMapper;
using Richfit.Garnet.Module.ScheduleManagement.Domain.Models;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.DTO.Profiles;

public class ScheduleManagementProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<SCH_INFO, SCH_INFODTO>();
		Mapper.CreateMap<SCH_INFODTO, SCH_INFO>();
		Mapper.CreateMap<SCH_BELONGER_USER, SCH_BELONGER_USERDTO>();
		Mapper.CreateMap<SCH_BELONGER_USERDTO, SCH_BELONGER_USER>();
		Mapper.CreateMap<SCH_PARTICIPANTS_USER, SCH_PARTICIPANTS_USERDTO>();
		Mapper.CreateMap<SCH_PARTICIPANTS_USERDTO, SCH_PARTICIPANTS_USER>();
		Mapper.CreateMap<SYS_USER, SYS_USERDTO>();
		Mapper.CreateMap<SYS_USERDTO, SYS_USER>();
	}
}
