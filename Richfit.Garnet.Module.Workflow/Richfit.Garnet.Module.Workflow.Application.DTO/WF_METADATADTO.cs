using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_METADATADTO : DTOBase
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
}
