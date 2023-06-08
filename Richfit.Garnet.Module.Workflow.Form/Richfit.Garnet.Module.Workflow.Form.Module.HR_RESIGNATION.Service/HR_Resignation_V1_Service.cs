using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_RESIGNATION.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_RESIGNATION.Service;

public class HR_Resignation_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			HR_RESIGNATIONDTO _hr_resignationdto = dataJson.JsonDeserialize<HR_RESIGNATIONDTO>(new JsonConverter[0]);
		}
		else
		{
			HR_RESIGNATIONDTO _hr_resignationdto = (HR_RESIGNATIONDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		_ = activity.ACTIVITY_CODE;
		return true;
	}

	public string InstanceName(string templateName, string dataJson)
	{
		HR_RESIGNATIONDTO _hr_resignationdto = dataJson.JsonDeserialize<HR_RESIGNATIONDTO>(new JsonConverter[0]);
		return $"{templateName}[{_hr_resignationdto.HR_RESIGNATION.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		HR_RESIGNATIONDTO _hr_resignationdto = dataJson.JsonDeserialize<HR_RESIGNATIONDTO>(new JsonConverter[0]);
		if (_hr_resignationdto.IsCreate)
		{
			Add(_hr_resignationdto.HR_RESIGNATION);
		}
		else
		{
			Update(_hr_resignationdto.HR_RESIGNATION);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		HR_RESIGNATIONDTO _hr_resignationdto = new HR_RESIGNATIONDTO();
		_hr_resignationdto.HR_RESIGNATION = FindByInstanceId<Richfit.Garnet.Module.Workflow.Form.Module.HR_RESIGNATION.DTO.HR_RESIGNATION>(instanceId);
		return _hr_resignationdto;
	}
}
