using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Portal.Domain.Models;

public class SYS_PORTAL : Entity
{
	public Guid PORTAL_ID { get; set; }

	public string PORTAL_URL { get; set; }

	public string IMAGE_URL { get; set; }

	public decimal? SORT { get; set; }

	public decimal? IS_REFRESH { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_USER_PORTAL> SYS_USER_PORTAL { get; set; }

	public SYS_PORTAL()
	{
		SYS_USER_PORTAL = new HashSet<SYS_USER_PORTAL>();
	}
}
