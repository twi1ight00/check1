using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_RULEDTO : DTOBase
{
	public Guid RULE_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string RULE_NAME { get; set; }

	public decimal? IS_DEFAULT { get; set; }

	public string DESCRIPTION { get; set; }

	public string RULE_CONDITION { get; set; }

	public string RULE_COORDINATE { get; set; }

	public Guid FROM_ACTIVITY_ID { get; set; }

	public Guid TO_ACTIVITY_ID { get; set; }

	public decimal? LINE_TYPE { get; set; }

	public decimal? RULE_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
