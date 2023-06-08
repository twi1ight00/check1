using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.PM_Benefit.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_Benefit.Service;

public class PM_Benefit_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			PM_BenefitDTO _pm_benefitdto = dataJson.JsonDeserialize<PM_BenefitDTO>(new JsonConverter[0]);
		}
		else
		{
			PM_BenefitDTO _pm_benefitdto = (PM_BenefitDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"FQ" => true, 
			"DQ" => true, 
			"GHZX" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		PM_BenefitDTO _pm_benefitdto = dataJson.JsonDeserialize<PM_BenefitDTO>(new JsonConverter[0]);
		return $"{templateName}[{_pm_benefitdto.PM_BENEFIT.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		PM_BenefitDTO _pm_benefitdto = dataJson.JsonDeserialize<PM_BenefitDTO>(new JsonConverter[0]);
		if (_pm_benefitdto.IsCreate)
		{
			Add(_pm_benefitdto.PM_BENEFIT);
		}
		else
		{
			Update(_pm_benefitdto.PM_BENEFIT);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		PM_BenefitDTO _pm_benefitdto = new PM_BenefitDTO();
		_pm_benefitdto.PM_BENEFIT = FindByInstanceId<PM_BENEFIT>(instanceId);
		return _pm_benefitdto;
	}
}
