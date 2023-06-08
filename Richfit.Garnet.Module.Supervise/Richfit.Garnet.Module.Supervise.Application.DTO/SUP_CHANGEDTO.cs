using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_CHANGEDTO : DTOBase
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

	public string USERNAME { get; set; }
}
