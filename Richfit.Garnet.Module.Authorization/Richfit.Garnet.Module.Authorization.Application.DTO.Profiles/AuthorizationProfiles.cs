using AutoMapper;
using Richfit.Garnet.Module.Authorization.Domain.Models;

namespace Richfit.Garnet.Module.Authorization.Application.DTO.Profiles;

public class AuthorizationProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<SYS_AUTHORIZATION_DETAILS, SYS_AUTHORIZATION_DETAILSDTO>();
		Mapper.CreateMap<SYS_AUTHORIZATION_DETAILSDTO, SYS_AUTHORIZATION_DETAILS>();
		Mapper.CreateMap<SYS_AUTHORIZATIONDTO, SYS_AUTHORIZATION>();
		Mapper.CreateMap<SYS_AUTHORIZATION, SYS_AUTHORIZATIONDTO>();
		Mapper.CreateMap<SYS_AUTHORIZATION_SPECIALDTO, SYS_AUTHORIZATION_SPECIAL>();
		Mapper.CreateMap<SYS_AUTHORIZATION_SPECIAL, SYS_AUTHORIZATION_SPECIALDTO>();
	}
}
