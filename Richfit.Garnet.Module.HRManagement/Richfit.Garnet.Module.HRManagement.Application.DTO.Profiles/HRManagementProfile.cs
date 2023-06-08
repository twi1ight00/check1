using AutoMapper;
using Richfit.Garnet.Module.HRManagement.Domain.Models;

namespace Richfit.Garnet.Module.HRManagement.Application.DTO.Profiles;

internal class HRManagementProfile : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<HR_EMPLOYEE, HR_EMPLOYEEDTO>();
		Mapper.CreateMap<HR_EMPLOYEEDTO, HR_EMPLOYEE>();
		Mapper.CreateMap<AB_CONTACT, AB_CONTACTDTO>();
		Mapper.CreateMap<AB_CONTACTDTO, AB_CONTACT>();
		Mapper.CreateMap<AB_ORG_CONTACT, AB_ORG_CONTACTDTO>();
		Mapper.CreateMap<AB_ORG_CONTACTDTO, AB_ORG_CONTACT>();
		Mapper.CreateMap<S_TEMP_STO_HRMANAGEMENT, S_TEMP_STO_HRMANAGEMENTDTO>();
		Mapper.CreateMap<S_TEMP_STO_HRMANAGEMENTDTO, S_TEMP_STO_HRMANAGEMENT>();
		Mapper.CreateMap<LY_INFO, LY_INFODTO>();
		Mapper.CreateMap<LY_INFODTO, LY_INFO>();
		Mapper.CreateMap<HR_DONATE_BLOOD, HR_DONATE_BLOODDTO>();
		Mapper.CreateMap<HR_DONATE_BLOODDTO, HR_DONATE_BLOOD>();
	}
}
