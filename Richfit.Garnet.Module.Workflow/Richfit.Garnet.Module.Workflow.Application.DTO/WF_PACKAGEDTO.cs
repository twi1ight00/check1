using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_PACKAGEDTO : DTOBase
{
	public Guid PACKAGE_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public string PACKAGE_NAME { get; set; }

	public string DESCRIPTION { get; set; }

	public string IMG { get; set; }

	public decimal ISDEL { get; set; }

	public decimal? SORT { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<WF_TEMPLATEDTO> WF_TEMPLATE { get; set; }
}
