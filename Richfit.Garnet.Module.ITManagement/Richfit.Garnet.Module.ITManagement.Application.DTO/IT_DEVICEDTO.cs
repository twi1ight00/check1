using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_DEVICEDTO : DTOBase
{
	public Guid IT_DEVICE_ID { get; set; }

	public string SN { get; set; }

	public Guid? TYPE_ID { get; set; }

	public string TYPE_NAME { get; set; }

	public string SERIES { get; set; }

	public decimal? SUB_CENTER { get; set; }

	public decimal? SUB_CENTER_PARM { get; set; }

	public decimal? SETS { get; set; }

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

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public decimal? SCRAP { get; set; }

	public DateTime? SCRAP_DATE { get; set; }
}
