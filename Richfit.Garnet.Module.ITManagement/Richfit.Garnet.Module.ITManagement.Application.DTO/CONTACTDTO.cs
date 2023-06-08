using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class CONTACTDTO : DTOBase
{
	public Guid CONTACT_ID { get; set; }

	public string CONTACT_NAME { get; set; }

	public string MOBILE { get; set; }

	public string MAIL { get; set; }

	public string POST { get; set; }

	public Guid? USER_ID { get; set; }
}
