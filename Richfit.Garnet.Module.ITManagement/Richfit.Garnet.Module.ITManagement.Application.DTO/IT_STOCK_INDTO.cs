using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_STOCK_INDTO : DTOBase
{
	public Guid IT_STOCK_IN_ID { get; set; }

	public decimal? TOTALMONEY { get; set; }

	public DateTime? APPLY_DATE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string REMARK { get; set; }

	public string IT_STOCK_IN_NO { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public string MATERIAL_DETAIL { get; set; }

	public Guid? ORG_ID { get; set; }

	public List<IT_STOCK_IN_DETAILDTO> IT_STOCK_IN_DETAIL { get; set; }
}
