using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_AUDIT : Entity
{
	public Guid AUDIT_ID { get; set; }

	public Guid ARTICLE_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public virtual CMS_ARTICLE CMS_ARTICLE { get; set; }
}
