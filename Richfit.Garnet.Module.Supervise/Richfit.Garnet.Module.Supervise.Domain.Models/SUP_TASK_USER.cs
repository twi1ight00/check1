using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_TASK_USER : Entity
{
	public Guid TASK_USER_ID { get; set; }

	public Guid? ASSIGN_TASK_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal? TYPE_ID { get; set; }

	public virtual SUP_ASSIGN_TASK SUP_ASSIGN_TASK { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
