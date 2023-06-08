using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_TEMPLATE_FORMDTO : DTOBase
{
	public Guid TEMPLATE_ID { get; set; }

	public Guid TEMPLATE_FORM_ID { get; set; }

	public Guid FORM_ID { get; set; }

	public string DESCRIPTION { get; set; }
}
