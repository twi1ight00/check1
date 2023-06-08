using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Application.DTO;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.Service;

public class HR_Timesheet_V1_Service : RunWorkflow, IRunWorkflow
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
		HR_TimesheetDTO _hr_timesheetdto = dataJson.JsonDeserialize<HR_TimesheetDTO>(new JsonConverter[0]);
		return $"{templateName}[{_hr_timesheetdto.HR_Timesheet.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		HR_TimesheetDTO _hr_timesheetdto = dataJson.JsonDeserialize<HR_TimesheetDTO>(new JsonConverter[0]);
		if (_hr_timesheetdto.IsCreate)
		{
			Add(_hr_timesheetdto.HR_Timesheet);
			if (_hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL != null && _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL.Count > 0)
			{
				foreach (HR_TIMESHEET_DETAIL _hr_timesheet_detail in _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL)
				{
					_hr_timesheet_detail.HR_TIMESHEET_ID = _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_ID;
					Add(_hr_timesheet_detail);
				}
			}
		}
		else
		{
			Update(_hr_timesheetdto.HR_Timesheet);
			string sql = "delete from HR_TIMESHEET_DETAIL where HR_TIMESHEET_ID=:HR_TIMESHEET_ID";
			repository.ExecuteCommand(sql, _hr_timesheetdto.HR_Timesheet);
			if (_hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL.Count > 0)
			{
				foreach (HR_TIMESHEET_DETAIL _hr_timesheet_detail in _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL)
				{
					_hr_timesheet_detail.HR_TIMESHEET_ID = _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_ID;
					Add(_hr_timesheet_detail);
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
		HR_TimesheetDTO _hr_timesheetdto = new HR_TimesheetDTO();
		_hr_timesheetdto.HR_Timesheet = FindByInstanceId<HR_TIMESHEET>(instanceId);
		if (_hr_timesheetdto.HR_Timesheet != null)
		{
			_hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_DETAIL = repository.ExecuteQuery<HR_TIMESHEET_DETAIL>(new HR_TIMESHEET_DETAIL().FindByInstance, new { _hr_timesheetdto.HR_Timesheet.HR_TIMESHEET_ID });
		}
		return _hr_timesheetdto;
	}

	public QueryResult<HR_TimesheetStatDTO> GetTimesheetStatsList(HR_TimesheetStatDTO parm)
	{
		return SqlQueryPager<HR_TimesheetStatDTO>("WFForm_GetTimesheetStatsList", parm);
	}
}
