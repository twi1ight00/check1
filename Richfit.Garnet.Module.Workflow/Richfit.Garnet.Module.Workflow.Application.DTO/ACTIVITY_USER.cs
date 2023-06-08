using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class ACTIVITY_USER
{
	public Guid ACTIVITY_ID { get; set; }

	public List<User> User { get; set; }
}
