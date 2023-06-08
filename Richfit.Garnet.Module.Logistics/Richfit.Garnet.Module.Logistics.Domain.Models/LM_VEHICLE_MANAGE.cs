using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Logistics.Domain.Models;

public class LM_VEHICLE_MANAGE : Entity
{
	public Guid VEHICLE_ID { get; set; }

	public string VEHICLE_NO { get; set; }

	public string DRIVER { get; set; }

	public string VEHICLE_NAME { get; set; }

	public decimal? IS_ENABLED { get; set; }

	public string ODOMETER_NO { get; set; }

	public decimal? IS_BOUND_DRIVE { get; set; }

	public Guid? URER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public decimal? IS_DEL { get; set; }
}
