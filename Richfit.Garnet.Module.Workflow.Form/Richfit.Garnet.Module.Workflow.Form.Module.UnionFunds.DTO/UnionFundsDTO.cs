using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.UnionFunds.DTO;

[Serializable]
public class UnionFundsDTO : DTOExt, IDTO
{
	private PT_UNION_FUNDS _pt_union_funds;

	public virtual PT_UNION_FUNDS PT_UNION_FUNDS
	{
		get
		{
			return _pt_union_funds;
		}
		set
		{
			_pt_union_funds = value;
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
