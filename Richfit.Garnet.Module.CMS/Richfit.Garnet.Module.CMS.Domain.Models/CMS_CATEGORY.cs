using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_CATEGORY : Entity
{
	public Guid ID { get; set; }

	public Guid? PARENT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public string NAME { get; set; }

	public string IMAGE { get; set; }

	public string HREF { get; set; }

	public string DESCRIPTION { get; set; }

	public string KEYWORDS { get; set; }

	public decimal? ALLOW_COMMENT { get; set; }

	public decimal? IS_AUDIT { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? IS_NOTIFY { get; set; }

	public virtual ICollection<CMS_ARTICLE> CMS_ARTICLE { get; set; }

	public CMS_CATEGORY()
	{
		CMS_ARTICLE = new HashSet<CMS_ARTICLE>();
	}
}
