using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class ReturnConstraintActivitys
{
	public WF_ACTIVITYDTO Activity { get; set; }

	public List<WF_ACTIVITYDTO> ConstraintActivitys { get; set; }
}
