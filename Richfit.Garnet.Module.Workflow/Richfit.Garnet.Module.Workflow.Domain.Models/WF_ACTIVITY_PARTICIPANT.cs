using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_ACTIVITY_PARTICIPANT : Entity
{
	public Guid ACTIVITY_PARTICIPANT_ID { get; set; }

	public Guid? ACTIVITY_ID { get; set; }

	public decimal PARTICIPANT_TYPE { get; set; }

	public Guid PARTICIPANT_ID { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual WF_ACTIVITY WF_ACTIVITY { get; set; }
}
