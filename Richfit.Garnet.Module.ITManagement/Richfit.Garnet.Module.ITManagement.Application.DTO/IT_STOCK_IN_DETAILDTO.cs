using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_STOCK_IN_DETAILDTO : DTOBase
{
	public Guid IT_STOCK_IN_DETAIL_ID { get; set; }

	public Guid IT_STOCK_IN_ID { get; set; }

	public Guid? MATERIAL_ID { get; set; }

	public string MATERIAL_NAME { get; set; }

	public decimal? MATERIAL_NUMBER { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? STOCK_QUANTITY { get; set; }

	public Guid? INSTANCE_ID { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public Guid? ACTIVITY_ID { get; set; }

	public string USER_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? IT_PURCHASING_APPLY_DETAIL_ID { get; set; }
}
