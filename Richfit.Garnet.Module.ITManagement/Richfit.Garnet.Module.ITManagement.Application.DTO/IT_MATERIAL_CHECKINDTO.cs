using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_MATERIAL_CHECKINDTO : DTOBase
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

	public decimal? MATERIAL_NUMBER { get; set; }

	public Guid MATERIAL_TYPE_ID { get; set; }

	public string MATERIAL_TYPE_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public string MATERIAL_NAME { get; set; }

	public DateTime? APPLY_TIME { get; set; }

	public string MATERIAL_REMARK { get; set; }

	public string RUN_STATE { get; set; }
}
