using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

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

	public virtual ICollection<AB_ORG_CONTACT> AB_ORG_CONTACT { get; set; }

	public virtual ICollection<HR_EMPLOYEE> HR_EMPLOYEE { get; set; }

	public virtual ICollection<SYS_ORG> SYS_ORG1 { get; set; }

	public virtual SYS_ORG SYS_ORG2 { get; set; }

	public SYS_ORG()
	{
		AB_ORG_CONTACT = new HashSet<AB_ORG_CONTACT>();
		HR_EMPLOYEE = new HashSet<HR_EMPLOYEE>();
		SYS_ORG1 = new HashSet<SYS_ORG>();
	}
}
