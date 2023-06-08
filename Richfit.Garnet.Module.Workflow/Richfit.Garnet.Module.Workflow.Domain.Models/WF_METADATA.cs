using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class WF_METADATA : Entity
{
	public Guid METADATA_ID { get; set; }

	public Guid META_TABLE_ID { get; set; }

	public decimal? DATATYPE { get; set; }

	public string FIELD_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string FIELD_DB_NAME { get; set; }

	public decimal? SORT { get; set; }

	public decimal? METATYPE { get; set; }

	public string DATALENGTH { get; set; }

	public decimal? STATUS { get; set; }

	public virtual WF_META_TABLE WF_META_TABLE { get; set; }
}
