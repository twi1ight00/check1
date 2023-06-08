using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class SYS_AUTHORIZATION_PERSONDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string USER_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public string POSITION_NAME { get; set; }

	public DateTime CREATETIME { get; set; }

	public string STATUS { get; set; }

	public Guid SYS_AUTHORIZATION_ID { get; set; }
}
