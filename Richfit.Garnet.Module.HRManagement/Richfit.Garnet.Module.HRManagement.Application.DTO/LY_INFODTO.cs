using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.DTO;

public class LY_INFODTO : DTOBase
{
	public Guid LY_ID { get; set; }

	public Guid? EMPLOYEE_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string CURRENT_YEAR { get; set; }

	public string LAST_LY_YEAR { get; set; }

	public decimal? IS_HAVE_LY { get; set; }

	public string VACATION_DAYS { get; set; }

	public string REMARK { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string IS_HAVE_LY_NAME { get; set; }
}
