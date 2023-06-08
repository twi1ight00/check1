using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Authorization.Domain.Models;

public class SYS_AUTHORIZATION : Entity
{
	public Guid SYS_AUTHORIZATION_ID { get; set; }

	public decimal AUTHORIZATION_TYPE { get; set; }

	public Guid ORG_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid TO_ORG_ID { get; set; }

	public Guid TO_USER_ID { get; set; }

	public DateTime START_TIME { get; set; }

	public DateTime END_TIME { get; set; }

	public string NOTE { get; set; }

	public decimal STATUS { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_AUTHORIZATION_DETAILS> SYS_AUTHORIZATION_DETAILS { get; set; }

	public SYS_AUTHORIZATION()
	{
		SYS_AUTHORIZATION_DETAILS = new HashSet<SYS_AUTHORIZATION_DETAILS>();
	}
}
