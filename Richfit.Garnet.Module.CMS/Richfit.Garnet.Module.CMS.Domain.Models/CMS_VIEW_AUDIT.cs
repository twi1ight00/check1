using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_VIEW_AUDIT : Entity
{
	public Guid ID { get; set; }

	public Guid ARTICLE_ID { get; set; }

	public Guid VIEW_ID { get; set; }

	public decimal VIEW_TYPE { get; set; }

	public string VIEW_NAME { get; set; }

	public virtual CMS_ARTICLE CMS_ARTICLE { get; set; }
}
