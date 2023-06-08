using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_ARTICLE_DATA_TEMP : Entity
{
	public Guid ID { get; set; }

	public string CONTENT { get; set; }
}
