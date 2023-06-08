using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.DTO;

public class SCH_PARTICIPANTS_USERDTO : DTOBase
{
	public Guid PARTICIPANTS_USER_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? SCHEDULE_ID { get; set; }

	public SCH_INFODTO SCH_INFO { get; set; }

	public SYS_USERDTO SYS_USER { get; set; }
}
