using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_VehicleScheduling.DTO;

[Serializable]
public class AC_LM_VehicleSchedulingDTO : DTOExt, IDTO
{
	private LM_VEHICLE_SCHEDULING _lm_vehicle_scheduling;

	public virtual LM_VEHICLE_SCHEDULING LM_VEHICLE_SCHEDULING
	{
		get
		{
			return _lm_vehicle_scheduling;
		}
		set
		{
			_lm_vehicle_scheduling = value;
		}
	}

	[SpecialName]
	int IDTO.get_SearchType()
	{
		return base.SearchType;
	}

	[SpecialName]
	void IDTO.set_SearchType(int value)
	{
		base.SearchType = value;
	}
}
