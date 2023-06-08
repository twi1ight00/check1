using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.DTO;

public class CNPCTaskDTO : DTOBase
{
	public string System { get; set; }

	public string TaskId { get; set; }

	public string WorkflowName { get; set; }

	public string TaskName { get; set; }

	public string CaseName { get; set; }

	public string CreateDate { get; set; }

	public string TaskUrl { get; set; }

	public int Step { get; set; }
}
