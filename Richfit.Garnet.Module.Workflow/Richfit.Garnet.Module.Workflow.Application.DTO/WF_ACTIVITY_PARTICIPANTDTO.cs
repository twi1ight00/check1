using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_ACTIVITY_PARTICIPANTDTO : DTOBase
{
	public Guid ACTIVITY_PARTICIPANT_ID { get; set; }

	public Guid ACTIVITY_ID { get; set; }

	public decimal PARTICIPANT_TYPE { get; set; }

	public Guid PARTICIPANT_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
