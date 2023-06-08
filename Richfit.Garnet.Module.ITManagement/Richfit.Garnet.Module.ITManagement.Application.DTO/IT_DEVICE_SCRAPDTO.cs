using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_DEVICE_SCRAPDTO : DTOBase
{
	public Guid IT_DEVICE_SCRAP_ID { get; set; }

	public decimal? YEAR { get; set; }

	public decimal? SUB_CENTER { get; set; }

	public string TITLE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public List<IT_DEVICE_SCRAP_DETAILDTO> IT_DEVICE_SCRAP_DETAIL { get; set; }

	public DateTime? START_DATE { get; set; }

	public DateTime? BUY_DATE_PRIOR { get; set; }

	public DateTime? BUY_DATE_END { get; set; }

	public decimal? RUN_STATE { get; set; }

	public Guid? CONFIRMED_BY { get; set; }

	public DateTime? CONFIRM_DATE { get; set; }

	public Guid? CLOSED_BY { get; set; }

	public DateTime? CLOSE_DATE { get; set; }
}
