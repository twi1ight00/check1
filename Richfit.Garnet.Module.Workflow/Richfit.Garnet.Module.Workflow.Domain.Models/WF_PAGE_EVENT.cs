using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_PAGE_EVENT : Entity
{
	public Guid PAGE_EVENT_ID { get; set; }

	public Guid? PAGE_ID { get; set; }

	public string EVENT_TYPE { get; set; }

	public string JSSTRING { get; set; }

	public virtual WF_PAGE WF_PAGE { get; set; }
}
