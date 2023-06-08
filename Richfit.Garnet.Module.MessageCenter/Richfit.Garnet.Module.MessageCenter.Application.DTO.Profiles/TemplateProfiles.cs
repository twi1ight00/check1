using AutoMapper;
using Richfit.Garnet.Module.MessageCenter.Domain.Models;

namespace Richfit.Garnet.Module.MessageCenter.Application.DTO.Profiles;

public class TemplateProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<MSG_CENTER, MSG_CENTERDTO>();
		Mapper.CreateMap<MSG_CENTERDTO, MSG_CENTER>();
		Mapper.CreateMap<MSG_CENTER_USER, MSG_CENTER_USERDTO>();
		Mapper.CreateMap<MSG_CENTER_USERDTO, MSG_CENTER_USER>();
	}
}
