using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_MATERIAL_CHECKIN : Entity
{
	public Guid IT_MATERIAL_CHECKIN_ID { get; set; }

	public Guid IT_MATERIAL_ID { get; set; }

	public decimal? CHECK_IN_NO { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public Guid? IT_MATERIAL_APPLY_ID { get; set; }

	public string IT_MATERIAL_NAME { get; set; }

	public virtual IT_MATERIAL IT_MATERIAL { get; set; }
}
