using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_META_TABLEDTO : DTOBase
{
	public Guid META_TABLE_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string TABLE_NAME { get; set; }

	public string TABLE_DB_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? PARENT_TABLE_ID { get; set; }

	public virtual ICollection<WF_METADATA> WF_METADATA { get; set; }

	public virtual WF_TEMPLATE WF_TEMPLATE { get; set; }

	public WF_META_TABLEDTO()
	{
		WF_METADATA = new HashSet<WF_METADATA>();
	}
}
