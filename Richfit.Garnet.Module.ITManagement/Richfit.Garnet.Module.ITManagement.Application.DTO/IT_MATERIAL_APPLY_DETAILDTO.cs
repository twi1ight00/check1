using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_MATERIAL_APPLY_DETAILDTO : DTOBase
{
	public Guid IT_MATERIAL_APPLY_ID { get; set; }

	public Guid IT_MATERIAL_APPLY_DETAIL_ID { get; set; }

	public Guid MATERIAL_TYPE_ID { get; set; }

	public string MATERIAL_TYPE_NAME { get; set; }

	public decimal MATERIAL_NUMBER { get; set; }

	public Guid? INSTANCE_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? MATERIAL_USER_ID { get; set; }

	public string MATERIAL_USER_NAME { get; set; }

	public DateTime? APPLY_TIME { get; set; }
}
