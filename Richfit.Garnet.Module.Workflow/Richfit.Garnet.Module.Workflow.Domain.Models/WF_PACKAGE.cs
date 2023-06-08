using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_PACKAGE : Entity
{
	public Guid PACKAGE_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public string PACKAGE_NAME { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string IMG { get; set; }

	public decimal? SORT { get; set; }

	public virtual ICollection<WF_TEMPLATE> WF_TEMPLATE { get; set; }

	public WF_PACKAGE()
	{
		WF_TEMPLATE = new HashSet<WF_TEMPLATE>();
	}
}
