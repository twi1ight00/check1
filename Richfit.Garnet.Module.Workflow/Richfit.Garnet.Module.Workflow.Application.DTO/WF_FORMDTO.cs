using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class WF_FORMDTO : DTOBase
{
	private SaveModel saveModel;

	public decimal? COLNUMBER { get; set; }

	public Guid FORM_ID { get; set; }

	public string FORM_NAME { get; set; }

	public string TABLE_DB_NAME { get; set; }

	public string HTML { get; set; }

	public Guid? PARENT_FORM_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? SORT { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public decimal? FORM_VERSION { get; set; }

	public Guid? ACTIVITY_ID { get; set; }

	public Guid? META_TABLE_ID { get; set; }

	public List<WF_FORM_DEFINITIONDTO> WF_FORM_DEFINITION { get; set; }

	public List<WF_METADATADTO> WF_METADATA { get; set; }

	public List<WF_FORMDTO> subform { get; set; }

	public Guid? PAGE_ID { get; set; }

	public SaveModel SaveModel
	{
		get
		{
			return saveModel;
		}
		set
		{
			saveModel = value;
		}
	}

	public WF_FORMDTO()
	{
		WF_FORM_DEFINITION = new List<WF_FORM_DEFINITIONDTO>();
		WF_METADATA = new List<WF_METADATADTO>();
	}
}
