using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_DEVICE_SCRAP_DETAILDTO : DTOBase
{
	public Guid IT_DEVICE_SCRAP_DETAIL_ID { get; set; }

	public Guid? IT_DEVICE_SCRAP_ID { get; set; }

	public Guid? IT_DEVICE_ID { get; set; }

	public decimal? SORT { get; set; }

	public Guid? BUYER_ID { get; set; }

	public string BUYER_NAME { get; set; }

	public DateTime? BUY_DATE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public string SN { get; set; }

	public string TYPE_NAME { get; set; }

	public string SERIES { get; set; }

	public decimal? SUB_CENTER { get; set; }

	public DateTime? PURCHASE_DATE { get; set; }

	public DateTime? DEPRECIATE_DATE { get; set; }

	public string WARRANTY_PERIOD { get; set; }

	public decimal? ORIGINAL_VALUE { get; set; }

	public decimal? REMAIN_VALUE { get; set; }

	public decimal? USE_STATUS { get; set; }

	public DateTime? ASSIGN_DATE { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public string DESCRIPTION { get; set; }

	public decimal? NOT_BUY { get; set; }

	public decimal? PAYMENT_STATUS { get; set; }

	public DateTime? PAYMENT_DATE { get; set; }
}
