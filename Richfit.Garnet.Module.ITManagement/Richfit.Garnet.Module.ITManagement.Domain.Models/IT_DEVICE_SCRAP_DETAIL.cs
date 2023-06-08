using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_DEVICE_SCRAP_DETAIL : Entity
{
	public Guid IT_DEVICE_SCRAP_DETAIL_ID { get; set; }

	public Guid? IT_DEVICE_SCRAP_ID { get; set; }

	public Guid? IT_DEVICE_ID { get; set; }

	public decimal? SORT { get; set; }

	public Guid? BUYER_ID { get; set; }

	public DateTime? BUY_DATE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public string REMARK { get; set; }

	public decimal? NOT_BUY { get; set; }

	public decimal? PAYMENT_STATUS { get; set; }

	public DateTime? PAYMENT_DATE { get; set; }

	public virtual IT_DEVICE_SCRAP IT_DEVICE_SCRAP { get; set; }
}
