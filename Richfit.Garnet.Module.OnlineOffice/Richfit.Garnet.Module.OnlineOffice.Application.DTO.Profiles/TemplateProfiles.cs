using AutoMapper;
using Richfit.Garnet.Module.OnlineOffice.Domain.Models;

namespace Richfit.Garnet.Module.OnlineOffice.Application.DTO.Profiles;

public class TemplateProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<OL_OFFICE, OL_OFFICEDTO>();
		Mapper.CreateMap<OL_OFFICEDTO, OL_OFFICE>();
		Mapper.CreateMap<OL_TEMPLATE_FILE, OL_TEMPLATE_FILEDTO>();
		Mapper.CreateMap<OL_TEMPLATE_FILEDTO, OL_TEMPLATE_FILE>();
		Mapper.CreateMap<OL_TEMPLATE_FILE_MAPPING, OL_TEMPLATE_FILE_MAPPINGDTO>();
		Mapper.CreateMap<OL_TEMPLATE_FILE_MAPPINGDTO, OL_TEMPLATE_FILE_MAPPING>();
	}
}
