using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PersonalExit.DTO;

[Serializable]
public class AC_PersonalExitDTO : DTOExt, IDTO
{
	private HR_PERSONAL_EXIT _hr_personal_exit;

	public virtual HR_PERSONAL_EXIT HR_PERSONAL_EXIT
	{
		get
		{
			return _hr_personal_exit;
		}
		set
		{
			_hr_personal_exit = value;
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
