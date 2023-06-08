using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_FORM_DEFINITION_DATA : Entity
{
	public Guid FORM_DEFINITION_DATA_ID { get; set; }

	public Guid FORM_DEFINITION_ID { get; set; }

	public string ACTION { get; set; }

	public string PARAM { get; set; }

	public string FIELD_TEXT { get; set; }

	public string FIELD_VALUE { get; set; }

	public decimal TYPE { get; set; }

	public string LOCAL_TEXT { get; set; }

	public virtual WF_FORM_DEFINITION WF_FORM_DEFINITION { get; set; }
}
