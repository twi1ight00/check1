using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Attachment.Application.DTO;

public class AttachmentMappingDTO : DTOBase
{
	public Guid ATTACHMENT_MAPPING_ID { get; set; }

	public Guid? ATTACHMENT_ID { get; set; }

	public Guid? OBJECT_ID { get; set; }

	public string OBJECT_TABLE_NAME { get; set; }

	public decimal? DOC_TYPE { get; set; }
}
