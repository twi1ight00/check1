using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.Service;

public class HR_VACATION_Service : RunWorkflow, IRunWorkflow
{
	private bool isChuZhang = false;

	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (string.IsNullOrEmpty(dataJson) && activity.ACTIVITY_CODE == "XXCSL")
		{
			isChuZhang = true;
		}
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			HR_VacationDTO _hr_vacationdto = dataJson.JsonDeserialize<HR_VacationDTO>(new JsonConverter[0]);
		}
		else
		{
			HR_VacationDTO _hr_vacationdto = (HR_VacationDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		_ = activity.ACTIVITY_CODE;
		return true;
	}

	public string InstanceName(string templateName, string dataJson)
	{
		HR_VacationDTO _hr_vacationdto = dataJson.JsonDeserialize<HR_VacationDTO>(new JsonConverter[0]);
		return $"{templateName}[{_hr_vacationdto.HR_VACATION.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (isChuZhang)
		{
			return true;
		}
		HR_VacationDTO _hr_vacationdto = dataJson.JsonDeserialize<HR_VacationDTO>(new JsonConverter[0]);
		if (_hr_vacationdto.IsCreate)
		{
			Add(_hr_vacationdto.HR_VACATION);
		}
		else
		{
			Update(_hr_vacationdto.HR_VACATION);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		HR_VacationDTO _hr_vacationdto = new HR_VacationDTO();
		_hr_vacationdto.HR_VACATION = FindByInstanceId<HR_VACATION>(instanceId);
		return _hr_vacationdto;
	}
}
