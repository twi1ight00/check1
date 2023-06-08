using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_RULE : Entity
{
	public Guid RULE_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string RULE_NAME { get; set; }

	public string RULE_CONDITION { get; set; }

	public string RULE_COORDINATE { get; set; }

	public Guid FROM_ACTIVITY_ID { get; set; }

	public Guid TO_ACTIVITY_ID { get; set; }

	public decimal? RULE_TYPE { get; set; }

	public decimal? LINE_TYPE { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }
}
