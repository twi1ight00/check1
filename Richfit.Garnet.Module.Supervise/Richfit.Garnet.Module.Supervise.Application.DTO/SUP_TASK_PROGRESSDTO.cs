using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_TASK_PROGRESSDTO : DTOBase
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
}
