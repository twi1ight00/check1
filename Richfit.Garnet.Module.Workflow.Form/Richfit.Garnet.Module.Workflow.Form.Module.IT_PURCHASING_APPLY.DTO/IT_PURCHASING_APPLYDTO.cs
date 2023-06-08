using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.DTO;

[Serializable]
public class IT_PURCHASING_APPLYDTO : DTOExt, IDTO
{
	private IT_PURCHASING_APPLY _it_purchasing_apply;

	public virtual IT_PURCHASING_APPLY IT_PURCHASING_APPLY
	{
		get
		{
			return _it_purchasing_apply;
		}
		set
		{
			_it_purchasing_apply = value;
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
