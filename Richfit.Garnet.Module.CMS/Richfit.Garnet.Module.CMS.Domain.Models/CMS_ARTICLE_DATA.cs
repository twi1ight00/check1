using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_ARTICLE_DATA : Entity
{
	public Guid ID { get; set; }

	public string CONTENT { get; set; }

	public virtual CMS_ARTICLE CMS_ARTICLE { get; set; }
}
