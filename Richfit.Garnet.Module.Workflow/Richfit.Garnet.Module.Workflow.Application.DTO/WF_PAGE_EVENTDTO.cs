using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_PAGE_EVENTDTO : DTOBase
{
	public Guid PAGE_EVENT_ID { get; set; }

	public Guid? PAGE_ID { get; set; }

	public string EVENT_TYPE { get; set; }

	public string JSSTRING { get; set; }
}
