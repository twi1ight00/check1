using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_TEMPLATE_AUTHORIZATIONDTO : DTOBase
{
	public Guid TEMPLATEAUTHORIZATION_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid PROXY_USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string PROXY_USER_NAME { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public DateTime START_TIME { get; set; }

	public DateTime END_TIME { get; set; }
}
