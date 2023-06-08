using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Authorization.Domain.Models;

public class SYS_AUTHORIZATION_SPECIAL : Entity
{
	public Guid SYS_AUTHORIZATION_SPECIAL_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid TO_USER_ID { get; set; }

	public string TO_USER_NAME { get; set; }

	public Guid TO_ORG_ID { get; set; }

	public string TO_ORG_NAME { get; set; }

	public Guid? TO_POSITION { get; set; }

	public string TO_POSITION_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal IS_EXCLUSIVE { get; set; }
}
