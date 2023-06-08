using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_DEVICE : Entity
{
	public Guid IT_DEVICE_ID { get; set; }

	public string SN { get; set; }

	public Guid? TYPE_ID { get; set; }

	public string SERIES { get; set; }

	public decimal? SUB_CENTER { get; set; }

	public DateTime? PURCHASE_DATE { get; set; }

	public DateTime? DEPRECIATE_DATE { get; set; }

	public string WARRANTY_PERIOD { get; set; }

	public decimal? ORIGINAL_VALUE { get; set; }

	public decimal? REMAIN_VALUE { get; set; }

	public decimal? USE_STATUS { get; set; }

	public decimal? PRE_SCRAP { get; set; }

	public DateTime? PRE_SCRAP_DATE { get; set; }

	public DateTime? ASSIGN_DATE { get; set; }

	public Guid? USER_ID { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public decimal? SCRAP { get; set; }

	public DateTime? SCRAP_DATE { get; set; }
}
