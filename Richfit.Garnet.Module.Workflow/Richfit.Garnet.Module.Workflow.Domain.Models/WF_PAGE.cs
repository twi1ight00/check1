using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_PAGE : Entity
{
	public Guid PAGE_ID { get; set; }

	public string PAGE_NAME { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public string VERSION_NAME { get; set; }

	public decimal? VERSION_NUM { get; set; }

	public Guid? VERSION_ID { get; set; }

	public decimal? ISACTIVE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? PARENT_PAGE_ID { get; set; }

	public string PAGE_URL { get; set; }

	public virtual ICollection<WF_FORM> WF_FORM { get; set; }

	public virtual ICollection<WF_PAGE_EVENT> WF_PAGE_EVENT { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }

	public WF_PAGE()
	{
		WF_FORM = new HashSet<WF_FORM>();
		WF_PAGE_EVENT = new HashSet<WF_PAGE_EVENT>();
	}
}
