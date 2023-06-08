using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_PAGEDTO : DTOBase
{
	public IList<WF_PAGEDTO> pageList;

	public Guid PAGE_ID { get; set; }

	public string PAGE_NAME { get; set; }

	public string HTML { get; set; }

	public string JS { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public string VERSION_NAME { get; set; }

	public decimal? VERSION_NUM { get; set; }

	public Guid? VERSION_ID { get; set; }

	public decimal? ISACTIVE { get; set; }

	public int IS_MOBILE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? PARENT_PAGE_ID { get; set; }

	public string PAGE_URL { get; set; }

	public SaveModel SaveModel { get; set; }

	public virtual List<WF_FORMDTO> WF_FORM { get; set; }

	public bool CREATE_FILE { get; set; }

	public WF_PAGEDTO()
	{
		pageList = new List<WF_PAGEDTO>();
	}
}
