using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Authorization.Domain.Models;

public class SYS_AUTHORIZATION_DETAILS : Entity
{
	public Guid SYS_AUTHORIZATION_DETAILS_ID { get; set; }

	public Guid? AUTHORIZATION_ID { get; set; }

	public Guid? RESOURCES_TYPE { get; set; }

	public Guid? RESOURCES_ID { get; set; }

	public Guid? ROLE_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SYS_AUTHORIZATION SYS_AUTHORIZATION { get; set; }
}
