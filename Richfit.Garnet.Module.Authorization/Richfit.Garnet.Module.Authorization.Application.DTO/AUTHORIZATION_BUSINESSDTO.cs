using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class AUTHORIZATION_BUSINESSDTO : DTOBase
{
	public Guid ROLE_ID { get; set; }

	public Guid RESOURCES_ID { get; set; }

	public Guid RESOURCES_TYPE { get; set; }

	public string BUSINESS_NAME { get; set; }

	public string ROLE_NAME { get; set; }

	public Guid? AUTHORIZATION_ID { get; set; }

	public DateTime CREATETIME { get; set; }
}
