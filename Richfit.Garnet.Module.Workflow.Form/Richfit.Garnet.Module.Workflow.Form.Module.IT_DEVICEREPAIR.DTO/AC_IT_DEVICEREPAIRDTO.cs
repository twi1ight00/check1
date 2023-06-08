using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_DEVICEREPAIR.DTO;

[Serializable]
public class AC_IT_DEVICEREPAIRDTO : DTOExt, IDTO
{
	private IT_DEVICE_REPAIR _it_device_repair;

	public virtual IT_DEVICE_REPAIR IT_DEVICE_REPAIR
	{
		get
		{
			return _it_device_repair;
		}
		set
		{
			_it_device_repair = value;
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
