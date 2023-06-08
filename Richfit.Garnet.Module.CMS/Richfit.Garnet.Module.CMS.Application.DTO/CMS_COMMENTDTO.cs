using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_COMMENTDTO : DTOBase
{
	public Guid ID { get; set; }

	public Guid? ARTICLE_ID { get; set; }

	public string CONTENT { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string IP { get; set; }

	public decimal? IS_COMMENT { get; set; }

	public DateTime? CREATE_DATE { get; set; }

	public Guid? AUDIT_USER_ID { get; set; }

	public DateTime? AUDIT_DATE { get; set; }

	public string AUDIT_USER_NAME { get; set; }
}
