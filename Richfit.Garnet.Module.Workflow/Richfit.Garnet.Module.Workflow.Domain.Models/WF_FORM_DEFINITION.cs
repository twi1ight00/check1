using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_FORM_DEFINITION : Entity
{
	public Guid FORM_DEFINITION_ID { get; set; }

	public Guid FORM_ID { get; set; }

	public Guid METADATA_ID { get; set; }

	public decimal? COLSPAN { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? COLNUMBER { get; set; }

	public decimal? ROWNUMBER { get; set; }

	public string TAGNAME { get; set; }

	public decimal? REQUIRED { get; set; }

	public string FORM_DEFINITION_NAME { get; set; }

	public string PLACEHOLDER { get; set; }

	public decimal? READONLY { get; set; }

	public decimal? SORT { get; set; }

	public virtual WF_FORM WF_FORM { get; set; }

	public virtual ICollection<WF_FORM_DEFINITION_DATA> WF_FORM_DEFINITION_DATA { get; set; }

	public WF_FORM_DEFINITION()
	{
		WF_FORM_DEFINITION_DATA = new HashSet<WF_FORM_DEFINITION_DATA>();
	}
}
