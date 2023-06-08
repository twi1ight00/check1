using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.FA_TravelExpense.DTO;

[Serializable]
public class FA_TravelExpenseDTO : DTOExt, IDTO
{
	private FA_TRAVELEXPENSE _fa_travelexpense;

	public virtual FA_TRAVELEXPENSE FA_TRAVELEXPENSE
	{
		get
		{
			return _fa_travelexpense;
		}
		set
		{
			_fa_travelexpense = value;
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
