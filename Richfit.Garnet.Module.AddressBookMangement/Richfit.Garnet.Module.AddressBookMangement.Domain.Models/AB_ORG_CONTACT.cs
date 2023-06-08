using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_ORG_CONTACT : Entity
{
	public Guid ORG_CONTACT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public Guid? CONTACT_ID { get; set; }

	public virtual AB_CONTACT AB_CONTACT { get; set; }

	public virtual SYS_ORG SYS_ORG { get; set; }
}
