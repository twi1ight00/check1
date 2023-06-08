using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Portal.Domain.Models;

public class SYS_USER_PORTAL : Entity
{
	public Guid USER_PORTAL_ID { get; set; }

	public Guid? PORTAL_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public decimal? COL_NUMBER { get; set; }

	public decimal? SORT { get; set; }

	public virtual SYS_PORTAL SYS_PORTAL { get; set; }
}
