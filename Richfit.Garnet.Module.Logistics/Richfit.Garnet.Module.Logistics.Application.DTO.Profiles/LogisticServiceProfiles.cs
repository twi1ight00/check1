using AutoMapper;
using Richfit.Garnet.Module.Logistics.Domain.Models;

namespace Richfit.Garnet.Module.Logistics.Application.DTO.Profiles;

public class LogisticServiceProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<LM_VEHICLE_MANAGEDTO, LM_VEHICLE_MANAGE>();
		Mapper.CreateMap<LM_VEHICLE_MANAGE, LM_VEHICLE_MANAGEDTO>();
	}
}
