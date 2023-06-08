using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_GROUP_CONTACT : Entity
{
	public Guid GROUP_CONTACT_ID { get; set; }

	public Guid? GROUP_ID { get; set; }

	public Guid CONTACT_ID { get; set; }

	public Guid USER_ID { get; set; }

	public virtual AB_CONTACT AB_CONTACT { get; set; }

	public virtual AB_PERSONAL_GROUP AB_PERSONAL_GROUP { get; set; }
}
