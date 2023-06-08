using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Dining_Apply.DTO;

[Serializable]
public class Dining_ApplyDTO : DTOExt, IDTO
{
	private LM_DINING_APPLY _lm_dining_apply;

	public virtual LM_DINING_APPLY LM_DINING_APPLY
	{
		get
		{
			return _lm_dining_apply;
		}
		set
		{
			_lm_dining_apply = value;
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
