using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_PRIVILEGE : Entity
{
	public Guid PRIVILEGE_ID { get; set; }

	public Guid BUSINESS_ID { get; set; }

	public Guid ROLE_ID { get; set; }

	public virtual SYS_BUSINESS SYS_BUSINESS { get; set; }

	public virtual SYS_ROLE SYS_ROLE { get; set; }
}
