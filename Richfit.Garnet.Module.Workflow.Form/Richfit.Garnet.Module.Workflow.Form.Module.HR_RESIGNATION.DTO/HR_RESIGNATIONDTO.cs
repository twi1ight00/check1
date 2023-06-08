using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_RESIGNATION.DTO;

[Serializable]
public class HR_RESIGNATIONDTO : DTOExt, IDTO
{
	private HR_RESIGNATION _hr_resignation;

	public virtual HR_RESIGNATION HR_RESIGNATION
	{
		get
		{
			return _hr_resignation;
		}
		set
		{
			_hr_resignation = value;
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
