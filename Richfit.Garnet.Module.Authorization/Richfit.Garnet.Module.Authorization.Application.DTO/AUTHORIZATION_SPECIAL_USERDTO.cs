using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class AUTHORIZATION_SPECIAL_USERDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public List<SYS_AUTHORIZATION_SPECIALDTO> SYS_AUTHORIZATION_SPECIAL { get; set; }
}
