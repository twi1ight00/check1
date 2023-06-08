using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_INSTANCE_ACTIVITY_USER : Entity
{
	public Guid INSTANCE_ACTIVITY_USER_ID { get; set; }

	public Guid INSTANCE_ACTIVITY_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public virtual WF_INSTANCE_ACTIVITY WF_INSTANCE_ACTIVITY { get; set; }
}
