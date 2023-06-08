using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_MODULE : Entity
{
	public Guid MODULE_ID { get; set; }

	public string MODULE_NAME { get; set; }
}
