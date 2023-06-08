using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Authorization.Application.DTO;

public class SYS_AUTHORIZATIONDTO : DTOBase
{
	public Guid SYS_AUTHORIZATION_ID { get; set; }

	public decimal AUTHORIZATION_TYPE { get; set; }

	public Guid ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid TO_ORG_ID { get; set; }

	public string TO_ORG_NAME { get; set; }

	public Guid TO_USER_ID { get; set; }

	public string TO_USER_NAME { get; set; }

	public DateTime START_TIME { get; set; }

	public DateTime END_TIME { get; set; }

	public string NOTE { get; set; }

	public decimal STATUS { get; set; }

	public string STATUS_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<SYS_AUTHORIZATION_DETAILSDTO> SYS_AUTHORIZATION_DETAILS { get; set; }
}
