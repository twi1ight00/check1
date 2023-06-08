using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ACTION_GROUP : Entity
{
	public Guid ACTION_GROUP_ID { get; set; }

	public Guid BUSINESS_ID { get; set; }

	public string GROUP_NAME { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SYS_BUSINESS SYS_BUSINESS { get; set; }

	public virtual ICollection<SYS_ACTION_GROUP_ACTION> SYS_ACTION_GROUP_ACTION { get; set; }

	public SYS_ACTION_GROUP()
	{
		SYS_ACTION_GROUP_ACTION = new HashSet<SYS_ACTION_GROUP_ACTION>();
	}
}
