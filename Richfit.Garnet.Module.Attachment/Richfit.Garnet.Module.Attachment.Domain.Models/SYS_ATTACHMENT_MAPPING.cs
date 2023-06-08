using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Attachment.Domain.Models;

public class SYS_ATTACHMENT_MAPPING : Entity
{
	public Guid ATTACHMENT_MAPPING_ID { get; set; }

	public Guid ATTACHMENT_ID { get; set; }

	public Guid OBJECT_ID { get; set; }

	public string OBJECT_TABLE_NAME { get; set; }

	public decimal? DOC_TYPE { get; set; }

	public virtual SYS_ATTACHMENT SYS_ATTACHMENT { get; set; }
}
