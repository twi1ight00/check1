using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_WORKITEMOLDDTO : DTOBase
{
	public string Title { get; set; }

	public string ApplyUser { get; set; }

	public DateTime ApplyTime { get; set; }

	public DateTime WorkItemTime { get; set; }

	public string CurrentAct { get; set; }

	public string Link { get; set; }
}
