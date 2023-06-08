using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.SealApply.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.SealApply.Service;

public class SealApply_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			decimal? aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
			if (aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue)
			{
				SealApplyDTO _sealapplydto = dataJson.JsonDeserialize<SealApplyDTO>(new JsonConverter[0]);
				instance.ORG_ID = _sealapplydto.SEALAPPLY.ORG_ID.Value;
			}
		}
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			SealApplyDTO _sealapplydto = dataJson.JsonDeserialize<SealApplyDTO>(new JsonConverter[0]);
		}
		else
		{
			SealApplyDTO _sealapplydto = (SealApplyDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"FQSQ" => true, 
			"BMSH" => true, 
			"RECSH" => true, 
			"CWFQSQ" => true, 
			"CWBMSH" => true, 
			"JHCWCSH" => true, 
			"BGFQSQ" => true, 
			"BGBMSH" => true, 
			"BGSSH" => true, 
			"ZXZGLDSPWL" => true, 
			"ZXZGLDSPLY" => true, 
			"YZGLYQR" => true, 
			"DQFQSQ" => true, 
			"DQBMSH" => true, 
			"DQGZCSH" => true, 
			"DQZXZGLDSP" => true, 
			"HQFQSQ" => true, 
			"HQBMSH" => true, 
			"HQFWZXSP" => true, 
			"HQYZGLYQR" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		SealApplyDTO _sealapplydto = dataJson.JsonDeserialize<SealApplyDTO>(new JsonConverter[0]);
		return $"{templateName}[{_sealapplydto.SEALAPPLY.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		SealApplyDTO _sealapplydto = dataJson.JsonDeserialize<SealApplyDTO>(new JsonConverter[0]);
		if (_sealapplydto.IsCreate)
		{
			Add(_sealapplydto.SEALAPPLY);
		}
		else
		{
			Update(_sealapplydto.SEALAPPLY);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		SealApplyDTO _sealapplydto = new SealApplyDTO();
		_sealapplydto.SEALAPPLY = FindByInstanceId<SEALAPPLY>(instanceId);
		return _sealapplydto;
	}
}
