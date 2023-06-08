using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_ACTION_GROUP_ACTION : Entity
{
	public Guid ACTION_GROUP_ACTION_ID { get; set; }

	public Guid ACTION_ID { get; set; }

	public Guid ACTION_GROUP_ID { get; set; }

	public virtual SYS_ACTION SYS_ACTION { get; set; }

	public virtual SYS_ACTION_GROUP SYS_ACTION_GROUP { get; set; }
}
