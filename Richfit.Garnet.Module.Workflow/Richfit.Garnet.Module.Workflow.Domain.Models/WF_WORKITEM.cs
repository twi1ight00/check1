using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_WORKITEM : Entity
{
	public Guid WORKITEM_ID { get; set; }

	public Guid ACTIVITY_ID { get; set; }

	public Guid INSTANCE_ID { get; set; }

	public Guid? PARENT_WORKITEM_ID { get; set; }

	public Guid? SENDER_USER_ID { get; set; }

	public string SENDER_USER_NAME { get; set; }

	public string WORKITEM_NAME { get; set; }

	public DateTime? SEND_TIME { get; set; }

	public decimal? WORKITEM_RUN_STATE { get; set; }

	public decimal? HANDLE_RESULT { get; set; }

	public decimal? GENERATE_TYPE { get; set; }

	public string SEND_TOKEN { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? SORT { get; set; }

	public Guid? RULE_ID { get; set; }

	public virtual WF_ACTIVITY WF_ACTIVITY { get; set; }

	public virtual ICollection<WF_DATA_HISTORY> WF_DATA_HISTORY { get; set; }

	public virtual WF_INSTANCE WF_INSTANCE { get; set; }

	public virtual ICollection<WF_WORKITEM_HANDLER> WF_WORKITEM_HANDLER { get; set; }

	public WF_WORKITEM()
	{
		WF_DATA_HISTORY = new HashSet<WF_DATA_HISTORY>();
		WF_WORKITEM_HANDLER = new HashSet<WF_WORKITEM_HANDLER>();
	}
}
