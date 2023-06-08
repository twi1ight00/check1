using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_MATERIAL_APPLY_DETAIL : Entity
{
	public string REMARK { get; set; }

	public Guid? MATERIAL_TYPE_ID { get; set; }

	public string MATERIAL_TYPE_NAME { get; set; }

	public decimal? MATERIAL_NUMBER { get; set; }

	public string MATERIAL_USER_ID { get; set; }

	public string MATERIAL_USER_NAME { get; set; }

	public Guid IT_MATERIAL_APPLY_DETAIL_ID { get; set; }

	public Guid? IT_MATERIAL_APPLY_ID { get; set; }
}
