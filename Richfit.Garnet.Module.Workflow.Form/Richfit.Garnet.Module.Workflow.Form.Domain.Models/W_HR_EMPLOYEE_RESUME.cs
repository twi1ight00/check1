using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Workflow.Form.Domain.Models;

public class W_HR_EMPLOYEE_RESUME : Entity
{
	public Guid W_HR_EMPLOYEE_RESUME_ID { get; set; }

	public string USER_NAME { get; set; }

	public string USER_CODE { get; set; }

	public Guid? USER_SEX { get; set; }

	public string BIRTH_PLACE { get; set; }

	public DateTime? BIRTHDAY { get; set; }

	public Guid? POLITIC_STATUS { get; set; }

	public DateTime? ENTRY_DATE { get; set; }

	public string CURRENT_STATUS { get; set; }

	public Guid? FIRST_DEGREE { get; set; }

	public string FIRST_SCHOOL { get; set; }

	public string MAJOR { get; set; }

	public Guid? TOP_DEGREE { get; set; }

	public string TOP_SCHOOL { get; set; }

	public string TOP_MAJOR { get; set; }

	public string IPHONE { get; set; }

	public string TRAIN { get; set; }

	public string WORK_EXPER_PRE { get; set; }

	public string WORK_EXPER_ENTER { get; set; }

	public string IMAGE_URL { get; set; }

	public string STUDY_MODE_FIRST { get; set; }

	public string STUDY_MODE_TOP { get; set; }

	public string SELF_ASSESS { get; set; }

	public DateTime? FIRST_DATE { get; set; }

	public DateTime? TOP_DATE { get; set; }

	public Guid? USER_ID { get; set; }
}
