using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.SealApply.DTO;

[Serializable]
public class SealApplyDTO : DTOExt, IDTO
{
	private SEALAPPLY _sealapply;

	public virtual SEALAPPLY SEALAPPLY
	{
		get
		{
			return _sealapply;
		}
		set
		{
			_sealapply = value;
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
