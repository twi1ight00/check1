using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.PartyDues.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PartyDues.Service;

public class PartyDues_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			PartyDuesDTO _partyduesdto = dataJson.JsonDeserialize<PartyDuesDTO>(new JsonConverter[0]);
		}
		else
		{
			PartyDuesDTO _partyduesdto = (PartyDuesDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"PD_SQ" => true, 
			"PD_SJSP" => true, 
			"PD_SH" => true, 
			"PD_PCZSP" => true, 
			"PD_SP" => true, 
			"PD_JFQR" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		PartyDuesDTO _partyduesdto = dataJson.JsonDeserialize<PartyDuesDTO>(new JsonConverter[0]);
		return $"{templateName}[{_partyduesdto.PT_PARTY_DUES.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		PartyDuesDTO _partyduesdto = dataJson.JsonDeserialize<PartyDuesDTO>(new JsonConverter[0]);
		if (_partyduesdto.IsCreate)
		{
			Add(_partyduesdto.PT_PARTY_DUES);
		}
		else
		{
			Update(_partyduesdto.PT_PARTY_DUES);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		PartyDuesDTO _partyduesdto = new PartyDuesDTO();
		_partyduesdto.PT_PARTY_DUES = FindByInstanceId<PT_PARTY_DUES>(instanceId);
		return _partyduesdto;
	}
}
