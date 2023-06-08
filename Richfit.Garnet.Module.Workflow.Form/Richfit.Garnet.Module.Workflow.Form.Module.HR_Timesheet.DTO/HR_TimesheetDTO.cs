using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.DTO;

[Serializable]
public class HR_TimesheetDTO : DTOExt, IDTO
{
	private HR_TIMESHEET _hr_timesheet;

	public virtual HR_TIMESHEET HR_Timesheet
	{
		get
		{
			return _hr_timesheet;
		}
		set
		{
			_hr_timesheet = value;
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
