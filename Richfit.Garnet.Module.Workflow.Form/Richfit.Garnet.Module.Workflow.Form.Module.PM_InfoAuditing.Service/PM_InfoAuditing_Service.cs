using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.PM_InfoAuditing.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_InfoAuditing.Service;

public class PM_InfoAuditing_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			PM_InfoAuditingDTO _pm_infoauditingdto = dataJson.JsonDeserialize<PM_InfoAuditingDTO>(new JsonConverter[0]);
		}
		else
		{
			PM_InfoAuditingDTO _pm_infoauditingdto = (PM_InfoAuditingDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"FQ" => true, 
			"DM" => true, 
			"DQSH" => true, 
			"DQCZ" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		PM_InfoAuditingDTO _pm_infoauditingdto = dataJson.JsonDeserialize<PM_InfoAuditingDTO>(new JsonConverter[0]);
		return $"{templateName}[{_pm_infoauditingdto.PM_INFOAUDITING.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		PM_InfoAuditingDTO _pm_infoauditingdto = dataJson.JsonDeserialize<PM_InfoAuditingDTO>(new JsonConverter[0]);
		if (_pm_infoauditingdto.IsCreate)
		{
			Add(_pm_infoauditingdto.PM_INFOAUDITING);
		}
		else
		{
			Update(_pm_infoauditingdto.PM_INFOAUDITING);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		PM_InfoAuditingDTO _pm_infoauditingdto = new PM_InfoAuditingDTO();
		_pm_infoauditingdto.PM_INFOAUDITING = FindByInstanceId<PM_INFOAUDITING>(instanceId);
		return _pm_infoauditingdto;
	}
}
