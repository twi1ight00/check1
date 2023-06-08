using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_INSTANCE_ACTIVITYDTO : DTOBase
{
	public Guid INSTANCE_ACTIVITY_ID { get; set; }

	public Guid INSTANCE_ID { get; set; }

	public Guid ACTIVITY_ID { get; set; }

	public List<WF_INSTANCE_ACTIVITY_USERDTO> WF_INSTANCE_ACTIVITY_USER { get; set; }
}
