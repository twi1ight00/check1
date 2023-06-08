using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_ARTICLEDTO : DTOBase
{
	public Guid ID { get; set; }

	public List<Guid> IDs { get; set; }

	public Guid? PARENT_ID { get; set; }

	public decimal? IS_PUBLISH { get; set; }

	public Guid? USER_ORG_ID { get; set; }

	public Guid CATEGORY_ID { get; set; }

	public string CATEGORY_NAME { get; set; }

	public Guid NOTICE_TYPE { get; set; }

	public string NOTICE_TYPE_NAME { get; set; }

	public string P_NAME { get; set; }

	public string TITLE { get; set; }

	public string KEYWORDS { get; set; }

	public decimal? WEIGHT { get; set; }

	public decimal? WEIGHT_SORT { get; set; }

	public decimal? HITS { get; set; }

	public decimal? AUDIT_STATUS { get; set; }

	public decimal? IS_COMMENT { get; set; }

	public decimal? IS_NOTIFY { get; set; }

	public decimal? IS_SHORT_MESSAGE { get; set; }

	public decimal? IS_MOBILE_MESSAGE { get; set; }

	public decimal? IS_ADMIN { get; set; }

	public decimal? IS_BIRTHDAY { get; set; }

	public string BIRTHDAY_USER { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public string CREATOR_NAME { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? AUDIT_USER_ID { get; set; }

	public string AUDIT_USER_NAME { get; set; }

	public DateTime? AUDIT_DATE { get; set; }

	public CMS_ARTICLE_DATADTO CMS_ARTICLE_DATA { get; set; }

	public List<CMS_COMMENTDTO> CMS_COMMENT { get; set; }

	public List<CMS_VIEW_AUDITDTO> CMS_VIEW_AUDIT { get; set; }

	public decimal? COUNT { get; set; }

	public decimal? CNT { get; set; }

	public string IMAGE { get; set; }

	public string CONTENT { get; set; }

	public DateTime? STARTDATE { get; set; }

	public DateTime? ENDDATE { get; set; }

	public decimal? IS_ENDDATE { get; set; }

	public decimal? IS_DELETEDATE { get; set; }

	public decimal? IS_MAINPAGE { get; set; }

	public decimal? IS_IMAGE { get; set; }

	public decimal? IS_TOP { get; set; }

	public string IS_TOP_NAME { get; set; }

	public List<CMS_PUBLISH_USERSDTO> CMS_PUBLISH_USERS { get; set; }

	public List<CMS_AUDITDTO> CMS_AUDIT { get; set; }

	public decimal? PAGEINDEX { get; set; }
}
