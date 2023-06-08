using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.Service;

public class IT_PURCHASING_APPLY_V1_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			IT_PURCHASING_APPLYDTO _it_purchasing_applydto = dataJson.JsonDeserialize<IT_PURCHASING_APPLYDTO>(new JsonConverter[0]);
		}
		else
		{
			IT_PURCHASING_APPLYDTO _it_purchasing_applydto = (IT_PURCHASING_APPLYDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"HCCG_SQ" => true, 
			"HCCG_XXCLD" => true, 
			"HCCG_END" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		StringBuilder instancename = new StringBuilder("耗材采购-");
		IT_PURCHASING_APPLYDTO _it_material_applydto = dataJson.JsonDeserialize<IT_PURCHASING_APPLYDTO>(new JsonConverter[0]);
		foreach (IT_PURCHASING_APPLY_DETAIL _it_material_apply_detail in _it_material_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL)
		{
			_it_material_apply_detail.IT_PURCHASING_APPLY_ID = _it_material_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_ID;
			instancename.Append(_it_material_apply_detail.MATERIAL_NAME + "(" + _it_material_apply_detail.MATERIAL_NUMBER + ")");
		}
		return instancename.ToString();
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		IT_PURCHASING_APPLYDTO _it_purchasing_applydto = dataJson.JsonDeserialize<IT_PURCHASING_APPLYDTO>(new JsonConverter[0]);
		if (_it_purchasing_applydto.IsCreate)
		{
			Add(_it_purchasing_applydto.IT_PURCHASING_APPLY);
			if (_it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL != null && _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL.Count > 0)
			{
				foreach (IT_PURCHASING_APPLY_DETAIL _it_purchasing_apply_detail in _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL)
				{
					_it_purchasing_apply_detail.IT_PURCHASING_APPLY_ID = _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_ID;
					Add(_it_purchasing_apply_detail);
				}
			}
		}
		else
		{
			Update(_it_purchasing_applydto.IT_PURCHASING_APPLY);
			string sql = "delete from IT_PURCHASING_APPLY_DETAIL where IT_PURCHASING_APPLY_ID=:IT_PURCHASING_APPLY_ID";
			repository.ExecuteCommand(sql, _it_purchasing_applydto.IT_PURCHASING_APPLY);
			if (_it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL.Count > 0)
			{
				foreach (IT_PURCHASING_APPLY_DETAIL _it_purchasing_apply_detail in _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL)
				{
					_it_purchasing_apply_detail.IT_PURCHASING_APPLY_ID = _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_ID;
					Add(_it_purchasing_apply_detail);
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
		IT_PURCHASING_APPLYDTO _it_purchasing_applydto = new IT_PURCHASING_APPLYDTO();
		_it_purchasing_applydto.IT_PURCHASING_APPLY = FindByInstanceId<Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.DTO.IT_PURCHASING_APPLY>(instanceId);
		if (_it_purchasing_applydto.IT_PURCHASING_APPLY != null)
		{
			_it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_DETAIL = repository.ExecuteQuery<IT_PURCHASING_APPLY_DETAIL>(new IT_PURCHASING_APPLY_DETAIL().FindByInstance, new { _it_purchasing_applydto.IT_PURCHASING_APPLY.IT_PURCHASING_APPLY_ID });
		}
		return _it_purchasing_applydto;
	}
}
