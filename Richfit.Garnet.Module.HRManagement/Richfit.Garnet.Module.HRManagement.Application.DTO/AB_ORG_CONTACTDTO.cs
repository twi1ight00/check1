using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.DTO;

public class AB_ORG_CONTACTDTO : DTOBase
{
	public Guid ORG_CONTACT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public Guid? CONTACT_ID { get; set; }

	public SYS_ORGDTO SYS_ORG { get; set; }
}
