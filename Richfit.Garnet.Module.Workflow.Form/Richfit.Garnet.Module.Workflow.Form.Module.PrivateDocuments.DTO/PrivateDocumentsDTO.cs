using System;
using System.Runtime.CompilerServices;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PrivateDocuments.DTO;

[Serializable]
public class PrivateDocumentsDTO : DTOExt, IDTO
{
	private HR_PRIVATE_DOCUMENTS _hr_private_documents;

	public virtual HR_PRIVATE_DOCUMENTS HR_PRIVATE_DOCUMENTS
	{
		get
		{
			return _hr_private_documents;
		}
		set
		{
			_hr_private_documents = value;
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
