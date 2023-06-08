using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_CHANGE : Entity
{
	public Guid CHANGE_ID { get; set; }

	public Guid? ASSIGN_TASK_ID { get; set; }

	public decimal? CHANGE_TYPE { get; set; }

	public DateTime? CHANGE_END_TIME { get; set; }

	public string CHANGE_REASON { get; set; }

	public DateTime? CHANGE_TIME { get; set; }

	public decimal? CHANGE_STATUS { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SUP_ASSIGN_TASK SUP_ASSIGN_TASK { get; set; }
}
