using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_DEVICE_SCRAP : Entity
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

	public DateTime? START_DATE { get; set; }

	public DateTime? BUY_DATE_PRIOR { get; set; }

	public DateTime? BUY_DATE_END { get; set; }

	public decimal? RUN_STATE { get; set; }

	public Guid? CONFIRMED_BY { get; set; }

	public DateTime? CONFIRM_DATE { get; set; }

	public Guid? CLOSED_BY { get; set; }

	public DateTime? CLOSE_DATE { get; set; }

	public virtual ICollection<IT_DEVICE_SCRAP_DETAIL> IT_DEVICE_SCRAP_DETAIL { get; set; }

	public IT_DEVICE_SCRAP()
	{
		IT_DEVICE_SCRAP_DETAIL = new HashSet<IT_DEVICE_SCRAP_DETAIL>();
	}
}
