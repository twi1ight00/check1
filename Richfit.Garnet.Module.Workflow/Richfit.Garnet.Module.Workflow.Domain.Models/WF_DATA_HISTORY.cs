using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_DATA_HISTORY : Entity
{
	public Guid HISTORY_ID { get; set; }

	public Guid WORKITEM_ID { get; set; }

	public string FORM_DATA { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual WF_WORKITEM WF_WORKITEM { get; set; }
}
