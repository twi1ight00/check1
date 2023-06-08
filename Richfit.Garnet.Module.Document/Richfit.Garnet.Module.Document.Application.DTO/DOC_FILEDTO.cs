using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Document.Application.DTO;

[Serializable]
public class DOC_FILEDTO : DTOBase
{
	public Guid DOC_FILE_ID { get; set; }

	public Guid CONTENT_ID { get; set; }

	public string DOC_FILE_NAME { get; set; }

	public string UPLOADER { get; set; }

	public DateTime? UPLOADTIME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string ATTACHMENT_TYPE { get; set; }

	public string FILE_RELATIVE_PATH { get; set; }

	public decimal? ATTACHMENT_SIZE { get; set; }

	public string ATTACHMENT_NAME { get; set; }

	public Guid CONTENT_NAME { get; set; }
}
