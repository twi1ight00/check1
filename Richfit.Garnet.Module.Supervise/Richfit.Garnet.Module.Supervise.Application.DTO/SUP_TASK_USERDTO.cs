using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_TASK_USERDTO : DTOBase
{
	public Guid TASK_USER_ID { get; set; }

	public Guid? ASSIGN_TASK_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal TYPE_ID { get; set; }
}
