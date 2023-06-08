using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class HR_EMPLOYEEDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public string FULL_NAME { get; set; }

	public string MAIL { get; set; }

	public string PHONE { get; set; }
}
