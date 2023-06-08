using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class AUTHORIZATION_ROLEDTO : DTOBase
{
	public Guid ROLE_ID { get; set; }

	public Guid USER_ID { get; set; }

	public decimal ROLE_TYPE { get; set; }

	public string ROLE_NAME { get; set; }

	public string NOTE { get; set; }

	public DateTime CREATETIME { get; set; }
}
