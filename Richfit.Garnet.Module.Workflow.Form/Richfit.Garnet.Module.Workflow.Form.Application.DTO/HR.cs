using System;

namespace Richfit.Garnet.Module.Workflow.Form.Application.DTO;

[Serializable]
public class HR
{
	public string EMPLOYEE_NAME { get; set; }

	public Guid? USER_ID { get; set; }

	public string MAIL { get; set; }
}
