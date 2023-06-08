using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_GROUP_CONTACTDTO : DTOBase
{
	public Guid GROUP_CONTACT_ID { get; set; }

	public Guid? GROUP_ID { get; set; }

	public Guid CONTACT_ID { get; set; }

	public Guid USER_ID { get; set; }

	public AB_CONTACTDTO AB_CONTACT { get; set; }

	public AB_PERSONAL_GROUPDTO AB_PERSONAL_GROUP { get; set; }
}
