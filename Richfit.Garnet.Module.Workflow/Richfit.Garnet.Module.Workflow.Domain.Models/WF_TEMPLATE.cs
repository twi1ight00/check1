using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_TEMPLATE : Entity
{
	public Guid TEMPLATE_ID { get; set; }

	public Guid PACKAGE_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string TEMPLATE_NAME { get; set; }

	public string TEMPLATE_CODE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid VERSION_ID { get; set; }

	public decimal VERSION_NUM { get; set; }

	public decimal? SORT { get; set; }

	public string IMGURL { get; set; }

	public decimal? ISACTIVE { get; set; }

	public Guid? PARENT_TEMPLATE_ID { get; set; }

	public string TEMPLATE_CODE_PATH { get; set; }

	public string PACKAGE_NAME { get; set; }

	public virtual ICollection<WF_ACTIVITY> WF_ACTIVITY { get; set; }

	public virtual ICollection<WF_INSTANCE> WF_INSTANCE { get; set; }

	public virtual ICollection<WF_META_TABLE> WF_META_TABLE { get; set; }

	public virtual WF_PACKAGE WF_PACKAGE { get; set; }

	public virtual ICollection<WF_PAGE> WF_PAGE { get; set; }

	public virtual ICollection<WF_RULE> WF_RULE { get; set; }

	public virtual ICollection<WF_TEMPLATE_AUTHORIZATION> WF_TEMPLATE_AUTHORIZATION { get; set; }

	public WF_TEMPLATE()
	{
		WF_ACTIVITY = new HashSet<WF_ACTIVITY>();
		WF_INSTANCE = new HashSet<WF_INSTANCE>();
		WF_META_TABLE = new HashSet<WF_META_TABLE>();
		WF_PAGE = new HashSet<WF_PAGE>();
		WF_RULE = new HashSet<WF_RULE>();
		WF_TEMPLATE_AUTHORIZATION = new HashSet<WF_TEMPLATE_AUTHORIZATION>();
	}
}
