using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Office_Supplies.DTO;

[Serializable]
public class LM_Office_SuppliesDTO : DTOExt, IDTO
{
	private LM_OFFICE_SUPPLIES _lm_office_supplies;

	public virtual LM_OFFICE_SUPPLIES LM_OFFICE_SUPPLIES
	{
		get
		{
			return _lm_office_supplies;
		}
		set
		{
			_lm_office_supplies = value;
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
