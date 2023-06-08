using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_STOCK_IN_DETAIL : Entity
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

	public Guid? IT_PURCHASING_APPLY_DETAIL_ID { get; set; }

	public virtual IT_STOCK_IN IT_STOCK_IN { get; set; }
}
