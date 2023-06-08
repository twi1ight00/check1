using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_USER_ROLE : Entity
{
	public Guid USER_ROLE_ID { get; set; }

	public Guid ROLE_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public virtual SYS_ROLE SYS_ROLE { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
