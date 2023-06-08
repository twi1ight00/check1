using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.Enums;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class BatchCommitParamter
{
	public IList<WF_WORKITEMDTO> WF_WORKITEMDTOS { get; set; }

	public string ORG_NAME { get; set; }

	public HANDLE_RESULT HANDLE_RESULT { get; set; }
}
