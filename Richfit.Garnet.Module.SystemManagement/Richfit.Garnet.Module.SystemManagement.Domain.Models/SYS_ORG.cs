using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ORG : Entity
{
	public Guid ORG_ID { get; set; }

	public Guid? PARENT_ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public decimal SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string EXTEND1 { get; set; }

	public string EXTEND2 { get; set; }

	public string EXTEND3 { get; set; }

	public string EXTEND4 { get; set; }

	public string EXTEND5 { get; set; }

	public virtual ICollection<SYS_ORG> SYS_ORG1 { get; set; }

	public virtual SYS_ORG SYS_ORG2 { get; set; }

	public virtual ICollection<SYS_ROLE_ORG> SYS_ROLE_ORG { get; set; }

	public virtual ICollection<SYS_USER_ORG> SYS_USER_ORG { get; set; }

	public SYS_ORG()
	{
		SYS_ORG1 = new HashSet<SYS_ORG>();
		SYS_ROLE_ORG = new HashSet<SYS_ROLE_ORG>();
		SYS_USER_ORG = new HashSet<SYS_USER_ORG>();
	}
}
