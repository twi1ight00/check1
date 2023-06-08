using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Attachment.Domain.Models;

public class SYS_ATTACHMENT : Entity
{
	public Guid ATTACHMENT_ID { get; set; }

	public string ATTACHMENT_NAME { get; set; }

	public string ATTACHMENT_TYPE { get; set; }

	public decimal? ATTACHMENT_SIZE { get; set; }

	public byte[] ATTACHMENT_CONTENT { get; set; }

	public decimal? STORAGE_LOCATION { get; set; }

	public string FILE_RELATIVE_PATH { get; set; }

	public string FILE_NETWORK_PATH { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string FILE_NO { get; set; }

	public decimal? IS_EFFECTIVE { get; set; }

	public virtual ICollection<SYS_ATTACHMENT_MAPPING> SYS_ATTACHMENT_MAPPING { get; set; }

	public SYS_ATTACHMENT()
	{
		SYS_ATTACHMENT_MAPPING = new HashSet<SYS_ATTACHMENT_MAPPING>();
	}
}
