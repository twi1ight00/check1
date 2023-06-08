using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class CreateParameter_V2
{
	public WF_INSTANCE WF_INSTANCE { get; set; }

	public SubmitDTO SUBMIT { get; set; }
}
