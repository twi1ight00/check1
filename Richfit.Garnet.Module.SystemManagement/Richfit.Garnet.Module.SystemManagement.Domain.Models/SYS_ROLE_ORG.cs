using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ROLE_ORG : Entity
{
	public Guid ROLE_ORG_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public Guid ROLE_ID { get; set; }

	public decimal? IS_CREATE_BY_SELF_ORG { get; set; }

	public Guid SOURCE_ORG_ID { get; set; }

	public virtual SYS_ORG SYS_ORG { get; set; }

	public virtual SYS_ROLE SYS_ROLE { get; set; }
}
