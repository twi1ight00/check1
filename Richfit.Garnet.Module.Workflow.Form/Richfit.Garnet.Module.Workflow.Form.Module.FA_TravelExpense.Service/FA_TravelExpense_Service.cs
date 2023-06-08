using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.FA_TravelExpense.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.FA_TravelExpense.Service;

public class FA_TravelExpense_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			FA_TravelExpenseDTO _fa_travelexpensedto = dataJson.JsonDeserialize<FA_TravelExpenseDTO>(new JsonConverter[0]);
		}
		else
		{
			FA_TravelExpenseDTO _fa_travelexpensedto = (FA_TravelExpenseDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		_ = activity.ACTIVITY_CODE;
		return true;
	}

	public string InstanceName(string templateName, string dataJson)
	{
		FA_TravelExpenseDTO _fa_travelexpensedto = dataJson.JsonDeserialize<FA_TravelExpenseDTO>(new JsonConverter[0]);
		return $"{templateName}[{_fa_travelexpensedto.FA_TRAVELEXPENSE.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		FA_TravelExpenseDTO _fa_travelexpensedto = dataJson.JsonDeserialize<FA_TravelExpenseDTO>(new JsonConverter[0]);
		if (_fa_travelexpensedto.IsCreate)
		{
			Add(_fa_travelexpensedto.FA_TRAVELEXPENSE);
			if (_fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL != null && _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL.Count > 0)
			{
				foreach (FA_TRAVELEXPENSE_DETAIL _fa_travelexpense_detail in _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL)
				{
					_fa_travelexpense_detail.FA_TRAVELEXPENSE_ID = _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_ID;
					Add(_fa_travelexpense_detail);
				}
			}
		}
		else
		{
			Update(_fa_travelexpensedto.FA_TRAVELEXPENSE);
			string sql = "delete from FA_TRAVELEXPENSE_DETAIL where FA_TRAVELEXPENSE_ID=:FA_TRAVELEXPENSE_ID";
			repository.ExecuteCommand(sql, _fa_travelexpensedto.FA_TRAVELEXPENSE);
			if (_fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL.Count > 0)
			{
				foreach (FA_TRAVELEXPENSE_DETAIL _fa_travelexpense_detail in _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL)
				{
					_fa_travelexpense_detail.FA_TRAVELEXPENSE_ID = _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_ID;
					Add(_fa_travelexpense_detail);
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
		FA_TravelExpenseDTO _fa_travelexpensedto = new FA_TravelExpenseDTO();
		_fa_travelexpensedto.FA_TRAVELEXPENSE = FindByInstanceId<FA_TRAVELEXPENSE>(instanceId);
		if (_fa_travelexpensedto.FA_TRAVELEXPENSE != null)
		{
			_fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_DETAIL = repository.ExecuteQuery<FA_TRAVELEXPENSE_DETAIL>(new FA_TRAVELEXPENSE_DETAIL().FindByInstance, new { _fa_travelexpensedto.FA_TRAVELEXPENSE.FA_TRAVELEXPENSE_ID });
		}
		return _fa_travelexpensedto;
	}
}
