using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_VIRTUAL_CONTACT : Entity
{
	public Guid VIRTUAL_CONTACT_ID { get; set; }

	public Guid? CONTACT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public virtual AB_CONTACT AB_CONTACT { get; set; }

	public virtual AB_VIRTUAL_ORG AB_VIRTUAL_ORG { get; set; }
}
