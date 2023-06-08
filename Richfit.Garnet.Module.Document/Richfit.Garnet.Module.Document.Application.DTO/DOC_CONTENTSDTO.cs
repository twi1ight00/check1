using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Document.Application.DTO;

[Serializable]
public class DOC_CONTENTSDTO : DTOBase
{
	public Guid CONTENT_ID { get; set; }

	public string CONTENT_NAME { get; set; }

	public Guid? PARENT_CONTENT_ID { get; set; }

	public decimal? STATUS { get; set; }

	public decimal? SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal CONTENT_CHILD_COUNT { get; set; }

	public string PARENT_CONTENT_NAME { get; set; }

	public string PATH { get; set; }
}
