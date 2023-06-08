using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.HRManagement.Domain.Models;

public class HR_DONATE_BLOOD : Entity
{
	public Guid DONATE_BLOOD_ID { get; set; }

	public Guid? EMPLOYEE_ID { get; set; }

	public string EMPLOYEE_NAME { get; set; }

	public string DONATE_NUMBER { get; set; }

	public string DONATE_LOCATION { get; set; }

	public DateTime? DONATE_DATE { get; set; }

	public string REMARK { get; set; }

	public Guid? CREATOR { get; set; }

	public decimal? ISDEL { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public string EXTEND1 { get; set; }

	public string EXTEND2 { get; set; }

	public string EXTEND3 { get; set; }

	public string EXTEND4 { get; set; }

	public string EXTEND5 { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string USER_NAME { get; set; }
}
