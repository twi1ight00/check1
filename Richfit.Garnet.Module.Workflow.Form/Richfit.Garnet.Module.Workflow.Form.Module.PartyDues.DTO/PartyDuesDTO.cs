using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PartyDues.DTO;

[Serializable]
public class PartyDuesDTO : DTOExt, IDTO
{
	private PT_PARTY_DUES _pt_party_dues;

	public virtual PT_PARTY_DUES PT_PARTY_DUES
	{
		get
		{
			return _pt_party_dues;
		}
		set
		{
			_pt_party_dues = value;
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
