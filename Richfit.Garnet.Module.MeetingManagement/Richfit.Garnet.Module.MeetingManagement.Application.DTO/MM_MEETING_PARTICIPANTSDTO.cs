using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.MeetingManagement.Application.DTO;

public class MM_MEETING_PARTICIPANTSDTO : DTOBase
{
	public Guid MEETING_PARTICIPANTS_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? MEETING_APPLY_ID { get; set; }
}
