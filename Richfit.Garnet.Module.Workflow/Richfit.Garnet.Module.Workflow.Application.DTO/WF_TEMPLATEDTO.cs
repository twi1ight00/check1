using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_TEMPLATEDTO : DTOBase
{
	public Guid TEMPLATE_ID { get; set; }

	public Guid VERSION_ID { get; set; }

	public decimal VERSION_NUM { get; set; }

	public Guid? PACKAGE_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string TEMPLATE_NAME { get; set; }

	public string TEMPLATE_CODE { get; set; }

	public string TEMPLATE_CODE_PATH { get; set; }

	public string IMGURL { get; set; }

	public decimal SORT { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<WF_ACTIVITYDTO> WF_ACTIVITY { get; set; }

	public List<WF_RULEDTO> WF_RULE { get; set; }

	public string URL { get; set; }

	public string FORM_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public Guid FORM_ID { get; set; }

	public string TEMPLATE_VERSION_CODE { get; set; }

	public WF_INSTANCEDTO WF_INSTANCEDTO { get; set; }

	public Guid? PARENT_TEMPLATE_ID { get; set; }

	public IList<Driver> NEXT_DRIVER { get; set; }

	public IList<Driver> BACK_DRIVER { get; set; }

	public decimal? ISACTIVE { get; set; }

	public bool CREATE_FILE { get; set; }

	public int HavePermission { get; set; }
}
