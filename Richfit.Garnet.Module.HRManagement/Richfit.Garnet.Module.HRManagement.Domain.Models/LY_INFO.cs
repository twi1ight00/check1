using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.HRManagement.Domain.Models;

public class LY_INFO : Entity
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

	public virtual HR_EMPLOYEE HR_EMPLOYEE { get; set; }
}
