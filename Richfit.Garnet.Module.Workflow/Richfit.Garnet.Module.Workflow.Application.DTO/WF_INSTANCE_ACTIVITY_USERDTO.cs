using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_INSTANCE_ACTIVITY_USERDTO : DTOBase
{
	public Guid WF_INSTANCE_ACTIVITY_USER_ID { get; set; }

	public Guid INSTANCE_ACTIVITY_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }
}
