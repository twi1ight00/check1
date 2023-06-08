using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_MATERIAL : Entity
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

	public decimal? IS_BUY { get; set; }

	public decimal? IS_CHECK { get; set; }

	public decimal? STOCK_QUANTITY { get; set; }

	public decimal? IS_AVAILABLE { get; set; }

	public virtual ICollection<IT_MATERIAL_CHECKIN> IT_MATERIAL_CHECKIN { get; set; }

	public IT_MATERIAL()
	{
		IT_MATERIAL_CHECKIN = new HashSet<IT_MATERIAL_CHECKIN>();
	}
}
