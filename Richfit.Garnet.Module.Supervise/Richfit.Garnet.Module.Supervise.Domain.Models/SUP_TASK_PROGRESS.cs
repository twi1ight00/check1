using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_TASK_PROGRESS : Entity
{
	public Guid PROGRESS_ID { get; set; }

	public Guid? ASSIGN_TASK_ID { get; set; }

	public Guid? PROGRESS_USER_ID { get; set; }

	public string PROGRESS_USER_NAME { get; set; }

	public string PROGRESS_CONTENT { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SUP_ASSIGN_TASK SUP_ASSIGN_TASK { get; set; }
}
