using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_COMMENT : Entity
{
	public Guid ID { get; set; }

	public Guid? ARTICLE_ID { get; set; }

	public string CONTENT { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string IP { get; set; }

	public DateTime? CREATE_DATE { get; set; }

	public Guid? AUDIT_USER_ID { get; set; }

	public DateTime? AUDIT_DATE { get; set; }

	public string AUDIT_USER_NAME { get; set; }

	public decimal? IS_COMMENT { get; set; }

	public virtual CMS_ARTICLE CMS_ARTICLE { get; set; }
}
