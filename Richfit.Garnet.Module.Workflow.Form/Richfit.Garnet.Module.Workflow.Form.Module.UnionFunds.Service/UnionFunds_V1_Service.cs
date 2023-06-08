using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.UnionFunds.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.UnionFunds.Service;

public class UnionFunds_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			UnionFundsDTO _unionfundsdto = dataJson.JsonDeserialize<UnionFundsDTO>(new JsonConverter[0]);
		}
		else
		{
			UnionFundsDTO _unionfundsdto = (UnionFundsDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"UF_JFQR" => true, 
			"UF_ZXSP" => true, 
			"UF_PCZSP" => true, 
			"UF_SQ" => true, 
			"UF_SP" => true, 
			"END" => true, 
			"UF_SH" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		UnionFundsDTO _unionfundsdto = dataJson.JsonDeserialize<UnionFundsDTO>(new JsonConverter[0]);
		return $"{templateName}[{_unionfundsdto.PT_UNION_FUNDS.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		UnionFundsDTO _unionfundsdto = dataJson.JsonDeserialize<UnionFundsDTO>(new JsonConverter[0]);
		if (_unionfundsdto.IsCreate)
		{
			Add(_unionfundsdto.PT_UNION_FUNDS);
		}
		else
		{
			Update(_unionfundsdto.PT_UNION_FUNDS);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		UnionFundsDTO _unionfundsdto = new UnionFundsDTO();
		_unionfundsdto.PT_UNION_FUNDS = FindByInstanceId<PT_UNION_FUNDS>(instanceId);
		return _unionfundsdto;
	}
}
