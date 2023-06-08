using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.PrivateDocuments.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PrivateDocuments.Service;

public class PrivateDocuments_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			PrivateDocumentsDTO _privatedocumentsdto = dataJson.JsonDeserialize<PrivateDocumentsDTO>(new JsonConverter[0]);
		}
		else
		{
			PrivateDocumentsDTO _privatedocumentsdto = (PrivateDocumentsDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"HR_PD_APPLY" => true, 
			"HR_PD_MGR" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		PrivateDocumentsDTO _privatedocumentsdto = dataJson.JsonDeserialize<PrivateDocumentsDTO>(new JsonConverter[0]);
		return $"{templateName}[{_privatedocumentsdto.HR_PRIVATE_DOCUMENTS.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		PrivateDocumentsDTO _privatedocumentsdto = dataJson.JsonDeserialize<PrivateDocumentsDTO>(new JsonConverter[0]);
		if (_privatedocumentsdto.IsCreate)
		{
			Add(_privatedocumentsdto.HR_PRIVATE_DOCUMENTS);
		}
		else
		{
			Update(_privatedocumentsdto.HR_PRIVATE_DOCUMENTS);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		PrivateDocumentsDTO _privatedocumentsdto = new PrivateDocumentsDTO();
		_privatedocumentsdto.HR_PRIVATE_DOCUMENTS = FindByInstanceId<HR_PRIVATE_DOCUMENTS>(instanceId);
		return _privatedocumentsdto;
	}
}
