using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class DriverParameter
{
	public IList<Driver> BACK_DRIVER { get; set; }

	public IList<Driver> NEXT_DRIVER { get; set; }
}
