using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_WORKITEM_HANDLER : Entity
{
	public Guid WORKITEM_HANDLER_ID { get; set; }

	public Guid WORKITEM_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? HANDLE_USER_ID { get; set; }

	public string HANDLE_USER_NAME { get; set; }

	public decimal? HANDLE_RESULT { get; set; }

	public string HANDLE_SUGGESTION { get; set; }

	public DateTime? HANDLE_TIME { get; set; }

	public decimal? SIGNATURE_MODE { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? INSTANCE_ID { get; set; }

	public string WORKITEM_NAME { get; set; }

	public virtual WF_WORKITEM WF_WORKITEM { get; set; }
}
