using AutoMapper;
using Richfit.Garnet.Module.MeetingManagement.Domain.Models;

namespace Richfit.Garnet.Module.MeetingManagement.Application.DTO.Profiles;

public class MeetingManageProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<MM_MEETING_APPLY, MM_MEETING_APPLYDTO>();
		Mapper.CreateMap<MM_MEETING_APPLYDTO, MM_MEETING_APPLY>();
		Mapper.CreateMap<MM_MEETING_PARTICIPANTS, MM_MEETING_PARTICIPANTSDTO>();
		Mapper.CreateMap<MM_MEETING_PARTICIPANTSDTO, MM_MEETING_PARTICIPANTS>();
	}
}
