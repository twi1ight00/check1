using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_INSTANCE : Entity
{
	public Guid INSTANCE_ID { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string INSTANCE_NAME { get; set; }

	public string TABLE_NAME { get; set; }

	public decimal? RUN_STATE { get; set; }

	public Guid START_USER_ID { get; set; }

	public string START_USER_NAME { get; set; }

	public Guid? PARENT_INSTANCE_ID { get; set; }

	public DateTime? START_TIME { get; set; }

	public DateTime? FINISH_TIME { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string CURRENT_ACTIVITY { get; set; }

	public string CURRENT_HANDLER_ID { get; set; }

	public string CURRENT_HANDLER_NAME { get; set; }

	public string TEMPLATE_NAME { get; set; }

	public string PACKAGE_NAME { get; set; }

	public Guid? PACKAGE_ID { get; set; }

	public virtual ICollection<WF_INSTANCE_ACTIVITY> WF_INSTANCE_ACTIVITY { get; set; }

	public virtual ICollection<WF_WORKITEM> WF_WORKITEM { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }

	public WF_INSTANCE()
	{
		WF_INSTANCE_ACTIVITY = new HashSet<WF_INSTANCE_ACTIVITY>();
		WF_WORKITEM = new HashSet<WF_WORKITEM>();
	}
}
