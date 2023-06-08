using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_VIRTUAL_CONTACTDTO : DTOBase
{
	public Guid VIRTUAL_CONTACT_ID { get; set; }

	public Guid? CONTACT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public AB_VIRTUAL_ORGDTO AB_VIRTUAL_ORG { get; set; }
}
