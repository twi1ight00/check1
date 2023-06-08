using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ScheduleManagement.Domain.Models;

public class SCH_BELONGER_USER : Entity
{
	public Guid BELONGER_USER_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? SCHEDULE_ID { get; set; }

	public virtual SCH_INFO SCH_INFO { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
