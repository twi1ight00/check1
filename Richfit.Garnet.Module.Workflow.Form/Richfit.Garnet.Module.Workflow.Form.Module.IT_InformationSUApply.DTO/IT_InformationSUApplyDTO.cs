using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_InformationSUApply.DTO;

[Serializable]
public class IT_InformationSUApplyDTO : DTOExt, IDTO
{
	private IT_ISU_APPLY _it_isu_apply;

	public virtual IT_ISU_APPLY IT_ISU_APPLY
	{
		get
		{
			return _it_isu_apply;
		}
		set
		{
			_it_isu_apply = value;
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
