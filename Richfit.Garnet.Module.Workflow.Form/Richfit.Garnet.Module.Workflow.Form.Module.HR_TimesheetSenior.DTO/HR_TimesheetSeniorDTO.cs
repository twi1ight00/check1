using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_TimesheetSenior.DTO;

[Serializable]
public class HR_TimesheetSeniorDTO : DTOExt, IDTO
{
	private HR_TIMESHEETSENIOR _hr_timesheetsenior;

	public virtual HR_TIMESHEETSENIOR HR_TIMESHEETSENIOR
	{
		get
		{
			return _hr_timesheetsenior;
		}
		set
		{
			_hr_timesheetsenior = value;
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
