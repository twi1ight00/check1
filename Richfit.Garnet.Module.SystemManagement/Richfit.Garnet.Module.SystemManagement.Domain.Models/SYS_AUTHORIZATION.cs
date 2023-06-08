using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_AUTHORIZATION : Entity
{
	public Guid AUTHORIZATION_ID { get; set; }

	public Guid FROM_USER_ID { get; set; }

	public Guid TO_USER_ID { get; set; }

	public Guid? TO_ROLE_ID { get; set; }

	public Guid TO_RIGHT_ID { get; set; }

	public DateTime START_TIME { get; set; }

	public DateTime END_TIME { get; set; }

	public decimal? SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
