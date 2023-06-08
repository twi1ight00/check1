using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class AUTHORIZATION_USERLISTDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public Guid TO_ORG_ID { get; set; }

	public Guid TO_USER_ID { get; set; }

	public string TO_USER_NAME { get; set; }

	public string TO_ORG_NAME { get; set; }

	public string TO_POSITION { get; set; }

	public string TO_POSITION_NAME { get; set; }

	public decimal IS_EXCLUSIVE { get; set; }

	public decimal SORT { get; set; }
}
