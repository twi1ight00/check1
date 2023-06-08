using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

[Serializable]
public class IT_MATERIAL_APPLYDTO : DTOExt, IDTO
{
	private IT_MATERIAL_APPLY _it_material_apply;

	public virtual IT_MATERIAL_APPLY IT_MATERIAL_APPLY
	{
		get
		{
			return _it_material_apply;
		}
		set
		{
			_it_material_apply = value;
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
