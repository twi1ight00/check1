using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Logistics.Application.DTO;

public class LM_VEHICLE_MANAGEDTO : DTOBase
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

	public LM_VEHICLE_MANAGEDTO()
	{
	}

	public LM_VEHICLE_MANAGEDTO(Guid vEHICLE_ID, string vEHICLE_NO, string dRIVER, string vEHICLE_NAME, decimal? iS_ENABLED, string oDOMETER_NO, decimal? iS_BOUND_DRIVE, Guid? uRER_ID, string uSER_NAME, Guid? oRG_ID, string oRG_NAME, Guid? cREATOR, DateTime? cREATETIME, Guid? mODIFIER, DateTime? mODIFYTIME, decimal? iS_DEL)
	{
		VEHICLE_ID = vEHICLE_ID;
		VEHICLE_NO = vEHICLE_NO;
		DRIVER = dRIVER;
		VEHICLE_NAME = vEHICLE_NAME;
		IS_ENABLED = iS_ENABLED;
		ODOMETER_NO = oDOMETER_NO;
		IS_BOUND_DRIVE = iS_BOUND_DRIVE;
		URER_ID = uRER_ID;
		USER_NAME = uSER_NAME;
		ORG_ID = oRG_ID;
		ORG_NAME = oRG_NAME;
		CREATOR = cREATOR;
		CREATETIME = cREATETIME;
		MODIFIER = mODIFIER;
		MODIFYTIME = mODIFYTIME;
		IS_DEL = iS_DEL;
	}
}
