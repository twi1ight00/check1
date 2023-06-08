using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_MATERIALDTO : DTOBase
{
	public Guid IT_MATERIAL_ID { get; set; }

	public string MATERIAL_NAME { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? MATERIAL_TYPE_ID { get; set; }

	public string MATERIAL_TYPE_NAME { get; set; }

	public DateTime? BUY_DATE { get; set; }

	public string ASSURANCE_YEAR { get; set; }

	public decimal? BUY_PRICE { get; set; }

	public decimal? STOCK_QUANTITY { get; set; }

	public decimal? IS_AVAILABLE { get; set; }

	public decimal? IS_BUY { get; set; }

	public decimal? IS_CHECK { get; set; }

	public decimal? LEFT_NO { get; set; }

	public decimal? CHECK_IN_NO { get; set; }

	public decimal? MATERIAL_NUMBER { get; set; }

	public decimal? CHECK_IN_NO_APPLY { get; set; }

	public decimal? CHECK_IN_NO_COMPLETE { get; set; }

	public decimal? MATERIAL_NUMBER_APPLY { get; set; }

	public decimal? MATERIAL_NUMBER_COMPLETE { get; set; }

	public decimal? MATERIAL_NUMBER_LEFT { get; set; }

	public List<IT_MATERIAL_CHECKINDTO> IT_MATERIAL_CHECKIN { get; set; }
}
