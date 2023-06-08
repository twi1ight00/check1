using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.LM_Office_Supplies.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Office_Supplies.Service;

public class Office_Supplies_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			LM_Office_SuppliesDTO _lm_office_suppliesdto = dataJson.JsonDeserialize<LM_Office_SuppliesDTO>(new JsonConverter[0]);
		}
		else
		{
			LM_Office_SuppliesDTO _lm_office_suppliesdto = (LM_Office_SuppliesDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"OS_CZSP" => true, 
			"OS_HQBL" => true, 
			"OS_END" => true, 
			"OS_LY" => true, 
			"OS_FQ" => true, 
			"OS_HQZR" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		LM_Office_SuppliesDTO _lm_office_suppliesdto = dataJson.JsonDeserialize<LM_Office_SuppliesDTO>(new JsonConverter[0]);
		return string.Format("{0}[{1}]", templateName, DateTime.Now.ToString("yyyyMMddHHmmss"));
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		LM_Office_SuppliesDTO _lm_office_suppliesdto = dataJson.JsonDeserialize<LM_Office_SuppliesDTO>(new JsonConverter[0]);
		if (_lm_office_suppliesdto.IsCreate)
		{
			Add(_lm_office_suppliesdto.LM_OFFICE_SUPPLIES);
			if (_lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL != null && _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL.Count > 0)
			{
				foreach (LM_OFFICE_DETAIL _lm_office_detail in _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL)
				{
					_lm_office_detail.OFFICE_SUPPLIES_ID = _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.OFFICE_SUPPLIES_ID;
					Add(_lm_office_detail);
				}
			}
		}
		else
		{
			Update(_lm_office_suppliesdto.LM_OFFICE_SUPPLIES);
			string sql = "delete from LM_OFFICE_DETAIL where OFFICE_SUPPLIES_ID=:OFFICE_SUPPLIES_ID";
			repository.ExecuteCommand(sql, _lm_office_suppliesdto.LM_OFFICE_SUPPLIES);
			if (_lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL.Count > 0)
			{
				foreach (LM_OFFICE_DETAIL _lm_office_detail in _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL)
				{
					_lm_office_detail.OFFICE_SUPPLIES_ID = _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.OFFICE_SUPPLIES_ID;
					Add(_lm_office_detail);
				}
			}
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		LM_Office_SuppliesDTO _lm_office_suppliesdto = new LM_Office_SuppliesDTO();
		_lm_office_suppliesdto.LM_OFFICE_SUPPLIES = FindByInstanceId<LM_OFFICE_SUPPLIES>(instanceId);
		if (_lm_office_suppliesdto.LM_OFFICE_SUPPLIES != null)
		{
			_lm_office_suppliesdto.LM_OFFICE_SUPPLIES.LM_OFFICE_DETAIL = repository.ExecuteQuery<LM_OFFICE_DETAIL>(new LM_OFFICE_DETAIL().FindByInstance, new { _lm_office_suppliesdto.LM_OFFICE_SUPPLIES.OFFICE_SUPPLIES_ID });
		}
		return _lm_office_suppliesdto;
	}
}
