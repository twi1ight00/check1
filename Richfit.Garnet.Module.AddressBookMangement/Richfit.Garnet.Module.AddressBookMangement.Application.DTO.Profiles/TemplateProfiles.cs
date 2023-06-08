using AutoMapper;
using Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO.Profiles;

public class TemplateProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<AB_CONTACT, AB_CONTACTDTO>();
		Mapper.CreateMap<AB_CONTACTDTO, AB_CONTACT>();
		Mapper.CreateMap<AB_CATEGORY, AB_CATEGORYDTO>();
		Mapper.CreateMap<AB_CATEGORYDTO, AB_CATEGORY>();
		Mapper.CreateMap<AB_GROUP_CONTACT, AB_GROUP_CONTACTDTO>();
		Mapper.CreateMap<AB_GROUP_CONTACTDTO, AB_GROUP_CONTACT>();
		Mapper.CreateMap<SYS_ORG, SYS_ORGDTO>();
		Mapper.CreateMap<SYS_ORGDTO, SYS_ORG>();
		Mapper.CreateMap<AB_VIRTUAL_ORG, AB_VIRTUAL_ORGDTO>();
		Mapper.CreateMap<AB_VIRTUAL_ORGDTO, AB_VIRTUAL_ORG>();
		Mapper.CreateMap<AB_ORG_CONTACT, AB_ORG_CONTACTDTO>();
		Mapper.CreateMap<AB_ORG_CONTACTDTO, AB_ORG_CONTACT>();
		Mapper.CreateMap<AB_PERSONAL_GROUP, AB_PERSONAL_GROUPDTO>();
		Mapper.CreateMap<AB_PERSONAL_GROUPDTO, AB_PERSONAL_GROUP>();
		Mapper.CreateMap<AB_VIRTUAL_CONTACT, AB_VIRTUAL_CONTACTDTO>();
		Mapper.CreateMap<AB_VIRTUAL_CONTACTDTO, AB_VIRTUAL_CONTACT>();
		Mapper.CreateMap<HR_EMPLOYEE, HR_EMPLOYEEDTO>();
		Mapper.CreateMap<HR_EMPLOYEEDTO, HR_EMPLOYEE>();
	}
}
