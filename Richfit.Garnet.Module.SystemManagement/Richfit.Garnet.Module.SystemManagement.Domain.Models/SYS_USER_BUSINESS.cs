using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_USER_BUSINESS : Entity
{
	public Guid USER_BUSINESS_ID { get; set; }

	public Guid BUSINESS_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public virtual SYS_BUSINESS SYS_BUSINESS { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
