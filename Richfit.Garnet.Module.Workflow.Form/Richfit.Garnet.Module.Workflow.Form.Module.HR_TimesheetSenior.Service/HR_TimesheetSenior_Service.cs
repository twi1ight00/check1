using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_TimesheetSenior.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_TimesheetSenior.Service;

public class HR_TimesheetSenior_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public string InstanceName(string templateName, string dataJson)
	{
		HR_TimesheetSeniorDTO _hr_timesheetseniordto = dataJson.JsonDeserialize<HR_TimesheetSeniorDTO>(new JsonConverter[0]);
		return $"{templateName}[{_hr_timesheetseniordto.HR_TIMESHEETSENIOR.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		HR_TimesheetSeniorDTO _hr_timesheetseniordto = dataJson.JsonDeserialize<HR_TimesheetSeniorDTO>(new JsonConverter[0]);
		if (_hr_timesheetseniordto.IsCreate)
		{
			Add(_hr_timesheetseniordto.HR_TIMESHEETSENIOR);
			if (_hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL != null && _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL.Count > 0)
			{
				foreach (HR_TIMESHEETSENIOR_DETAIL _hr_timesheetsenior_detail in _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL)
				{
					_hr_timesheetsenior_detail.HR_TIMESHEETSENIOR_ID = _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_ID;
					Add(_hr_timesheetsenior_detail);
				}
			}
		}
		else
		{
			Update(_hr_timesheetseniordto.HR_TIMESHEETSENIOR);
			string sql = "delete from HR_TIMESHEETSENIOR_DETAIL where HR_TIMESHEETSENIOR_ID=:HR_TIMESHEETSENIOR_ID";
			repository.ExecuteCommand(sql, _hr_timesheetseniordto.HR_TIMESHEETSENIOR);
			if (_hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL.Count > 0)
			{
				foreach (HR_TIMESHEETSENIOR_DETAIL _hr_timesheetsenior_detail in _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL)
				{
					_hr_timesheetsenior_detail.HR_TIMESHEETSENIOR_ID = _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_ID;
					Add(_hr_timesheetsenior_detail);
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
		HR_TimesheetSeniorDTO _hr_timesheetseniordto = new HR_TimesheetSeniorDTO();
		_hr_timesheetseniordto.HR_TIMESHEETSENIOR = FindByInstanceId<HR_TIMESHEETSENIOR>(instanceId);
		if (_hr_timesheetseniordto.HR_TIMESHEETSENIOR != null)
		{
			_hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_DETAIL = repository.ExecuteQuery<HR_TIMESHEETSENIOR_DETAIL>(new HR_TIMESHEETSENIOR_DETAIL().FindByInstance, new { _hr_timesheetseniordto.HR_TIMESHEETSENIOR.HR_TIMESHEETSENIOR_ID });
		}
		return _hr_timesheetseniordto;
	}
}
