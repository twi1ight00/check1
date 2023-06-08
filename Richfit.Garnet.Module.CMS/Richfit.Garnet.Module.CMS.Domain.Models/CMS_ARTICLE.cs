using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS_ARTICLE : Entity
{
	public Guid ID { get; set; }

	public Guid CATEGORY_ID { get; set; }

	public string TITLE { get; set; }

	public string KEYWORDS { get; set; }

	public decimal? WEIGHT { get; set; }

	public decimal? WEIGHT_SORT { get; set; }

	public decimal? HITS { get; set; }

	public decimal? AUDIT_STATUS { get; set; }

	public decimal? IS_SHORT_MESSAGE { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public DateTime? AUDIT_DATE { get; set; }

	public decimal? IS_COMMENT { get; set; }

	public Guid? PARENT_ID { get; set; }

	public DateTime? ENDDATE { get; set; }

	public decimal? IS_ENDDATE { get; set; }

	public decimal? IS_DELETEDATE { get; set; }

	public decimal? IS_MAINPAGE { get; set; }

	public decimal? IS_IMAGE { get; set; }

	public decimal? IS_TOP { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? NOTICE_TYPE { get; set; }

	public decimal? IS_PUBLISH { get; set; }

	public virtual ICollection<CMS_AUDIT> CMS_AUDIT { get; set; }

	public virtual CMS_ARTICLE_DATA CMS_ARTICLE_DATA { get; set; }

	public virtual CMS_CATEGORY CMS_CATEGORY { get; set; }

	public virtual ICollection<CMS_COMMENT> CMS_COMMENT { get; set; }

	public virtual ICollection<CMS_VIEW_AUDIT> CMS_VIEW_AUDIT { get; set; }

	public virtual ICollection<CMS_PUBLISH_USERS> CMS_PUBLISH_USERS { get; set; }

	public CMS_ARTICLE()
	{
		CMS_AUDIT = new HashSet<CMS_AUDIT>();
		CMS_COMMENT = new HashSet<CMS_COMMENT>();
		CMS_VIEW_AUDIT = new HashSet<CMS_VIEW_AUDIT>();
		CMS_PUBLISH_USERS = new HashSet<CMS_PUBLISH_USERS>();
	}
}
