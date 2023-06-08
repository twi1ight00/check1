using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_TEMPLATE_AUTHORIZATION : Entity
{
	public Guid TEMPLATEAUTHORIZATION_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public Guid ROLE_ID { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }
}
