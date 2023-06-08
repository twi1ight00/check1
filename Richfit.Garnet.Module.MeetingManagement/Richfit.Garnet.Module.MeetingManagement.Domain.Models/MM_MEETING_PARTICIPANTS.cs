using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.MeetingManagement.Domain.Models;

public class MM_MEETING_PARTICIPANTS : Entity
{
	public Guid MEETING_PARTICIPANTS_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? MEETING_APPLY_ID { get; set; }

	public virtual MM_MEETING_APPLY MM_MEETING_APPLY { get; set; }
}
