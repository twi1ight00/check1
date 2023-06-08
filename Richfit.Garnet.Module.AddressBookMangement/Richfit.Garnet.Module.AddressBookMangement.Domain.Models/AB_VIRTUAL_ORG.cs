using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_VIRTUAL_ORG : Entity
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

	public virtual ICollection<AB_VIRTUAL_CONTACT> AB_VIRTUAL_CONTACT { get; set; }

	public AB_VIRTUAL_ORG()
	{
		AB_VIRTUAL_CONTACT = new HashSet<AB_VIRTUAL_CONTACT>();
	}
}
