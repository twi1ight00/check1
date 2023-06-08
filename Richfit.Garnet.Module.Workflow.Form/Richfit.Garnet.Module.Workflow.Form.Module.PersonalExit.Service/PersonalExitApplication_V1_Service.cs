using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.PersonalExit.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PersonalExit.Service;

public class PersonalExitApplication_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			PersonalExitDTO _personalexitdto = dataJson.JsonDeserialize<PersonalExitDTO>(new JsonConverter[0]);
		}
		else
		{
			PersonalExitDTO _personalexitdto = (PersonalExitDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"HR_PD_APPLY" => true, 
			"HR_PD_ORG" => true, 
			"HR_PD_MGR" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		PersonalExitDTO _personalexitdto = dataJson.JsonDeserialize<PersonalExitDTO>(new JsonConverter[0]);
		return $"{templateName}[{_personalexitdto.HR_PERSONAL_EXIT.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		PersonalExitDTO _personalexitdto = dataJson.JsonDeserialize<PersonalExitDTO>(new JsonConverter[0]);
		if (_personalexitdto.IsCreate)
		{
			Add(_personalexitdto.HR_PERSONAL_EXIT);
		}
		else
		{
			Update(_personalexitdto.HR_PERSONAL_EXIT);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		PersonalExitDTO _personalexitdto = new PersonalExitDTO();
		_personalexitdto.HR_PERSONAL_EXIT = FindByInstanceId<HR_PERSONAL_EXIT>(instanceId);
		return _personalexitdto;
	}
}
