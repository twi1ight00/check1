using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Fundation.Domain.Models;

public class SYS_DOMAIN : Entity
{
	public Guid DOMAIN_ID { get; set; }

	public string DOMAIN_NAME { get; set; }

	public string DOMAIN_ADDRESS { get; set; }

	public string DOMAIN_ACCOUNT { get; set; }

	public string DOMAIN_PWD { get; set; }

	public decimal? SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_USER> SYS_USER { get; set; }

	public SYS_DOMAIN()
	{
		SYS_USER = new HashSet<SYS_USER>();
	}
}
