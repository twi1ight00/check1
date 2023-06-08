using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_INSTANCE_ACTIVITY : Entity
{
	public Guid INSTANCE_ACTIVITY_ID { get; set; }

	public Guid INSTANCE_ID { get; set; }

	public Guid ACTIVITY_ID { get; set; }

	public virtual WF_ACTIVITY WF_ACTIVITY { get; set; }

	public virtual WF_INSTANCE WF_INSTANCE { get; set; }

	public virtual ICollection<WF_INSTANCE_ACTIVITY_USER> WF_INSTANCE_ACTIVITY_USER { get; set; }

	public WF_INSTANCE_ACTIVITY()
	{
		WF_INSTANCE_ACTIVITY_USER = new HashSet<WF_INSTANCE_ACTIVITY_USER>();
	}
}
