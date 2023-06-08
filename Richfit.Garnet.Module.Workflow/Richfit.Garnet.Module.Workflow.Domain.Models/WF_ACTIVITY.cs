using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_ACTIVITY : Entity
{
	public Guid ACTIVITY_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string ACTIVITY_NAME { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal? ACTIVITY_TYPE { get; set; }

	public Guid? BRANCH_ACTIVITY_ID { get; set; }

	public string ACTIVITY_COORDINATE { get; set; }

	public decimal? FINISH_NUMBER { get; set; }

	public string CONDITION { get; set; }

	public decimal? IS_MERGR { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? STATUS { get; set; }

	public string ACTIVITY_CODE { get; set; }

	public decimal? FORM_VERSION { get; set; }

	public Guid? PAGE_ID { get; set; }

	public string PAGE_URL { get; set; }

	public Guid? PARENT_PAGE_ID { get; set; }

	public Guid? PARENT_DETAIL_PAGE_ID { get; set; }

	public Guid? DETAIL_PAGE_ID { get; set; }

	public string DETAIL_PAGE_URL { get; set; }

	public decimal? SORT { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }

	public virtual ICollection<WF_ACTIVITY_PARTICIPANT> WF_ACTIVITY_PARTICIPANT { get; set; }

	public virtual ICollection<WF_INSTANCE_ACTIVITY> WF_INSTANCE_ACTIVITY { get; set; }

	public virtual ICollection<WF_WORKITEM> WF_WORKITEM { get; set; }

	public WF_ACTIVITY()
	{
		WF_ACTIVITY_PARTICIPANT = new HashSet<WF_ACTIVITY_PARTICIPANT>();
		WF_INSTANCE_ACTIVITY = new HashSet<WF_INSTANCE_ACTIVITY>();
		WF_WORKITEM = new HashSet<WF_WORKITEM>();
	}
}
