using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ACTION : Entity
{
	public Guid ACTION_ID { get; set; }

	public Guid HANDLER_ID { get; set; }

	public string ACTION_CODE { get; set; }

	public string ACTION_NAME { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public decimal PRIVIGE_VALIDATE_TYPE { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_ACTION_GROUP_ACTION> SYS_ACTION_GROUP_ACTION { get; set; }

	public virtual SYS_HANDLER SYS_HANDLER { get; set; }

	public SYS_ACTION()
	{
		SYS_ACTION_GROUP_ACTION = new HashSet<SYS_ACTION_GROUP_ACTION>();
	}
}
