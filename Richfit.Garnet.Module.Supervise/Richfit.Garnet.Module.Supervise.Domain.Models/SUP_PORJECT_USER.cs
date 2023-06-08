using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_PORJECT_USER : Entity
{
	public Guid PORJECT_USER_ID { get; set; }

	public Guid? PORJECT_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal? TYPE_ID { get; set; }

	public virtual SUP_PORJECT SUP_PORJECT { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }
}
