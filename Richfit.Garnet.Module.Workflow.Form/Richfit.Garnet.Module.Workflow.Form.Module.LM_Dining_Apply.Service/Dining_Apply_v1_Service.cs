using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.LM_Dining_Apply.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Dining_Apply.Service;

public class Dining_Apply_v1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		Dining_ApplyDTO _dining_applydto = (string.IsNullOrEmpty(dataJson) ? ((Dining_ApplyDTO)FindByInstanceId(instance.INSTANCE_ID)) : dataJson.JsonDeserialize<Dining_ApplyDTO>(new JsonConverter[0]));
		switch (activity.ACTIVITY_CODE)
		{
		case "DA_FQ":
			return true;
		case "DA_END":
			_dining_applydto.LM_DINING_APPLY.CREATETIME = DateTime.Now;
			_dining_applydto.LM_DINING_APPLY.MODIFYTIME = DateTime.Now;
			repository.ExecuteCommand(new AC_LM_DINING_APPLY().AddSql, _dining_applydto.LM_DINING_APPLY);
			return true;
		case "DA_CZSP":
			return true;
		case "DA_HQSH":
			return true;
		case "DA_CPBG":
			return true;
		case "DA_GRLY":
			return true;
		case "DA_FFD":
			return true;
		default:
			return true;
		}
	}

	public string InstanceName(string templateName, string dataJson)
	{
		Dining_ApplyDTO _dining_applydto = dataJson.JsonDeserialize<Dining_ApplyDTO>(new JsonConverter[0]);
		return string.Format("{0}[{1}]", templateName, DateTime.Now.ToString("yyyyMMddHHmmss"));
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		Dining_ApplyDTO _dining_applydto = dataJson.JsonDeserialize<Dining_ApplyDTO>(new JsonConverter[0]);
		if (_dining_applydto.IsCreate)
		{
			Add(_dining_applydto.LM_DINING_APPLY);
		}
		else
		{
			Update(_dining_applydto.LM_DINING_APPLY);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		Dining_ApplyDTO _dining_applydto = new Dining_ApplyDTO();
		_dining_applydto.LM_DINING_APPLY = FindByInstanceId<LM_DINING_APPLY>(instanceId);
		return _dining_applydto;
	}
}
