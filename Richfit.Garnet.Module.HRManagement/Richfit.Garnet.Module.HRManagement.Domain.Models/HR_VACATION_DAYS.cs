using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.HRManagement.Domain.Models;

public class HR_VACATION_DAYS : Entity
{
	public Guid HR_VACATION_DAYS_ID { get; set; }

	public Guid? EMPLOYEE_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string YEAR { get; set; }

	public decimal? VACATION_DAYS { get; set; }

	public decimal? LEFT_VACATION_DAYS { get; set; }

	public decimal? APPLY_VACATION_DAYS { get; set; }

	public decimal? WORK_AGE { get; set; }
}
