using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_CATEGORY : Entity
{
	public Guid CATEGORY_ID { get; set; }

	public string CATEGORY_NAME { get; set; }

	public string CATEGORY_TYPE { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<AB_PERSONAL_GROUP> AB_PERSONAL_GROUP { get; set; }

	public AB_CATEGORY()
	{
		AB_PERSONAL_GROUP = new HashSet<AB_PERSONAL_GROUP>();
	}
}
