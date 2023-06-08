using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Fundation.Domain.Models;

public class SYS_USER_ORG : Entity
{
	public Guid USER_ORG_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public decimal? USER_IDENTITY_TYPE { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
