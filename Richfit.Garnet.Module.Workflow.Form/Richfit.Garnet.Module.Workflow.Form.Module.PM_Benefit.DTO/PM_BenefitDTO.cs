using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_Benefit.DTO;

[Serializable]
public class PM_BenefitDTO : DTOExt, IDTO
{
	private PM_BENEFIT _pm_benefit;

	public virtual PM_BENEFIT PM_BENEFIT
	{
		get
		{
			return _pm_benefit;
		}
		set
		{
			_pm_benefit = value;
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
