using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_FORM : Entity
{
	public Guid FORM_ID { get; set; }

	public string FORM_NAME { get; set; }

	public string TABLE_DB_NAME { get; set; }

	public Guid? PARENT_FORM_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? SORT { get; set; }

	public decimal? FORM_VERSION { get; set; }

	public Guid? META_TABLE_ID { get; set; }

	public decimal? COLNUMBER { get; set; }

	public Guid? PAGE_ID { get; set; }

	public virtual ICollection<WF_FORM_DEFINITION> WF_FORM_DEFINITION { get; set; }

	public virtual WF_PAGE WF_PAGE { get; set; }

	public virtual WF_META_TABLE WF_META_TABLE { get; set; }

	public WF_FORM()
	{
		WF_FORM_DEFINITION = new HashSet<WF_FORM_DEFINITION>();
	}
}
