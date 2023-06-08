using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_ACTIVITYDTO : DTOBase
{
	public Guid ACTIVITY_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public Guid? BRANCH_ACTIVITY_ID { get; set; }

	public string ACTIVITY_NAME { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal? ACTIVITY_TYPE { get; set; }

	public string ACTIVITY_COORDINATE { get; set; }

	public decimal? ENABLE_EDIT_ATTACHMENT { get; set; }

	public decimal? FINISH_NUMBER { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<WF_ACTIVITY_PARTICIPANTDTO> WF_ACTIVITY_PARTICIPANT { get; set; }

	public List<User> HANDLERUSER { get; set; }

	public List<WF_ACTIVITY_EVENTDTO> WF_ACTIVITY_EVENT { get; set; }

	public decimal? STATUS { get; set; }

	public Guid FORM_ID { get; set; }

	public string FORM_URL { get; set; }

	public string ACTIVITY_CODE { get; set; }

	public Guid? PAGE_ID { get; set; }

	public string PAGE_URL { get; set; }

	public Guid? PARENT_PAGE_ID { get; set; }

	public Guid? PARENT_DETAIL_PAGE_ID { get; set; }

	public Guid? DETAIL_PAGE_ID { get; set; }

	public string DETAIL_PAGE_URL { get; set; }

	public string RULE_COORDINATE { get; set; }

	public decimal? SORT { get; set; }

	public Guid? INSTANCE_ID { get; set; }

	public List<TREE_NODE> HANDLER_USER { get; set; }
}
