using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Application.DTO;

[Serializable]
public class WF_MAILDTO : DTOBase
{
	public string TYPE { get; set; }

	public string NAME { get; set; }

	public string TITLE { get; set; }

	public string BODY { get; set; }
}
