using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_CATEGORYDTO : DTOBase
{
	public Guid ID { get; set; }

	public Guid? PARENT_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public string NAME { get; set; }

	public string IMAGE { get; set; }

	public string HREF { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal? MSG_CENTER_TYPE_ID { get; set; }

	public decimal? IS_NOTIFY { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<CMS_ARTICLEDTO> CMS_ARTICLE { get; set; }
}
