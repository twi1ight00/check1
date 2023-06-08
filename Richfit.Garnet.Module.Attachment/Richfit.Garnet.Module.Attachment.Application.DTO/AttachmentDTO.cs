using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Attachment.Application.DTO;

public class AttachmentDTO : DTOBase
{
	public string Catalog { get; set; }

	public double CurrentPosition { get; set; }

	public Guid Token { get; set; }

	public Guid? ATTACHMENT_ID { get; set; }

	public string OBJECT_TABLE_NAME { get; set; }

	public Guid? OBJECT_ID { get; set; }

	public string ATTACHMENT_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public string ATTACHMENT_TYPE { get; set; }

	public decimal? ATTACHMENT_SIZE { get; set; }

	public string ATTACHMENTSIZENAME { get; set; }

	public byte[] ATTACHMENT_CONTENT { get; set; }

	public decimal? STORAGE_LOCATION { get; set; }

	public string FILE_RELATIVE_PATH { get; set; }

	public string FILE_NETWORK_PATH { get; set; }

	public string NOTE { get; set; }

	public string FILE_NO { get; set; }

	public decimal IS_EFFECTIVE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public string CREATORNAME { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<AttachmentMappingDTO> ATTACHMENTMAPPINGDTO { get; set; }

	public string CONTENT_NAME { get; set; }

	public Guid? CONTENT_ID { get; set; }
}
