using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ROLE : Entity
{
	public Guid ROLE_ID { get; set; }

	public string ROLE_NAME { get; set; }

	public decimal ROLE_TYPE { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_PRIVILEGE> SYS_PRIVILEGE { get; set; }

	public virtual ICollection<SYS_ROLE_ORG> SYS_ROLE_ORG { get; set; }

	public virtual ICollection<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }

	public SYS_ROLE()
	{
		SYS_PRIVILEGE = new HashSet<SYS_PRIVILEGE>();
		SYS_ROLE_ORG = new HashSet<SYS_ROLE_ORG>();
		SYS_USER_ROLE = new HashSet<SYS_USER_ROLE>();
	}
}
