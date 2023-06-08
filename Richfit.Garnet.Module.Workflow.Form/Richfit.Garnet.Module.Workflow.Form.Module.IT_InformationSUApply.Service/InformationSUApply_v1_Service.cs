using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.IT_InformationSUApply.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_InformationSUApply.Service;

public class InformationSUApply_v1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			IT_InformationSUApplyDTO _it_informationsuapplydto = dataJson.JsonDeserialize<IT_InformationSUApplyDTO>(new JsonConverter[0]);
		}
		else
		{
			IT_InformationSUApplyDTO _it_informationsuapplydto = (IT_InformationSUApplyDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"IT_ISUA_FK" => true, 
			"IT_ISUA_SQ" => true, 
			"IT_ISUA_XXCSP" => true, 
			"IT_ISUA_LDSP" => true, 
			"IT_ISUA_END" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		IT_InformationSUApplyDTO _it_informationsuapplydto = dataJson.JsonDeserialize<IT_InformationSUApplyDTO>(new JsonConverter[0]);
		return $"{templateName}[{_it_informationsuapplydto.IT_ISU_APPLY.APPLICANT}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		IT_InformationSUApplyDTO _it_informationsuapplydto = dataJson.JsonDeserialize<IT_InformationSUApplyDTO>(new JsonConverter[0]);
		if (_it_informationsuapplydto.IsCreate)
		{
			Add(_it_informationsuapplydto.IT_ISU_APPLY);
		}
		else
		{
			Update(_it_informationsuapplydto.IT_ISU_APPLY);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		IT_InformationSUApplyDTO _it_informationsuapplydto = new IT_InformationSUApplyDTO();
		_it_informationsuapplydto.IT_ISU_APPLY = FindByInstanceId<IT_ISU_APPLY>(instanceId);
		return _it_informationsuapplydto;
	}
}
