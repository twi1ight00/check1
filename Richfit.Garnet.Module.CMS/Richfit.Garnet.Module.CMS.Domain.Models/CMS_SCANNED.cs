using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_SCANNED : Entity
{
	public Guid ID { get; set; }

	public Guid ARTICLE_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
