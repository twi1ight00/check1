using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_USER_BUSINESSDTO : DTOBase
{
	public Guid USER_BUSINESS_ID { get; set; }

	public Guid BUSINESS_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid ORG_ID { get; set; }
}
