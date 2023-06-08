using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.DTO;

public class CNPCTaskListDTO : DTOBase
{
	public string Result { get; set; }

	public string Desc { get; set; }

	public string TaskType { get; set; }

	public string TaskCount { get; set; }

	public string Ht_TaskCount { get; set; }

	public string Gw_TaskCount { get; set; }

	public string Bx_TaskCount { get; set; }

	public CNPCTaskDTO[] datainfo { get; set; }
}
