using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_InfoAuditing.DTO;

[Serializable]
public class PM_InfoAuditingDTO : DTOExt, IDTO
{
	private PM_INFOAUDITING _pm_infoauditing;

	public virtual PM_INFOAUDITING PM_INFOAUDITING
	{
		get
		{
			return _pm_infoauditing;
		}
		set
		{
			_pm_infoauditing = value;
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
