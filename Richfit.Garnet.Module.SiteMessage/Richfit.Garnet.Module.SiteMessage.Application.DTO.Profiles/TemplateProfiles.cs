using AutoMapper;
using Richfit.Garnet.Module.SiteMessage.Domain.Models;

namespace Richfit.Garnet.Module.SiteMessage.Application.DTO.Profiles;

public class TemplateProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<MSG_MESSAGE, MSG_MESSAGEDTO>();
		Mapper.CreateMap<MSG_MESSAGEDTO, MSG_MESSAGE>();
		Mapper.CreateMap<MSG_MESSAGE_USER, MSG_MESSAGE_USERDTO>();
		Mapper.CreateMap<MSG_MESSAGE_USERDTO, MSG_MESSAGE_USER>();
	}
}
