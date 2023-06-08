using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

[Serializable]
public class HR_VacationDTO : DTOExt, IDTO
{
	private HR_VACATION _hr_vacation;

	public virtual HR_VACATION HR_VACATION
	{
		get
		{
			return _hr_vacation;
		}
		set
		{
			_hr_vacation = value;
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
