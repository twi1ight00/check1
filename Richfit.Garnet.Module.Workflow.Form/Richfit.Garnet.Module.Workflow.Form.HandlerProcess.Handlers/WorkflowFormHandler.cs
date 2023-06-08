using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Extend.Application.Services;
using Richfit.Garnet.Module.Workflow.Form.Application.DTO;
using Richfit.Garnet.Module.Workflow.Form.Application.Services;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.Service;

namespace Richfit.Garnet.Module.Workflow.Form.HandlerProcess.Handlers;

public class WorkflowFormHandler : HandlerBase
{
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "WFForm_AccountList":
					AccountList(handlerResult);
					break;
				case "WFForm_GetTaskCountForMobile":
					GetTaskCountForMobile(handlerResult);
					break;
				case "WFForm_GetTimesheetStatsList":
					GetTimesheetStatsList(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void GetTimesheetStatsList(ResponseData handlerResult)
	{
		HR_TimesheetStatDTO parm = base.RequestData.Data.JsonDeserialize<HR_TimesheetStatDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<HR_Timesheet_V1_Service>().GetTimesheetStatsList(parm).ToJson();
	}

	private void GetTaskCountForMobile(ResponseData handlerResult)
	{
		Dictionary<string, string> dic = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid id = new Guid(dic["USER_ID"]);
		WF_WORKITEMDTO wF_WORKITEMDTO = new WF_WORKITEMDTO();
		wF_WORKITEMDTO.USER_ID = id;
		wF_WORKITEMDTO.ISMOBILE = 1m;
		wF_WORKITEMDTO.PageIndex = 0;
		wF_WORKITEMDTO.SortBy = "START_TIME DESC";
		WF_WORKITEMDTO paramTodo = wF_WORKITEMDTO;
		QueryResult<WF_WORKITEMDTO> sjzxTaskList = new WorkflowExtendService().GetWorkItemPager(paramTodo);
		SYS_USERDTO user = ServiceLocator.Instance.GetService<ISystemUserService>().GetUserById(id);
		CNPCTaskListDTO cnpcTaskList = new SendMeassageToRuiXin().GetCNPCTaskList(user.LOGON_NAME);
		handlerResult.Data = new
		{
			USER_ID = id,
			SJZXCount = (1 + sjzxTaskList.RecordCount).ToString(),
			CNPCCount = cnpcTaskList.TaskCount,
			Ht_TaskCount = cnpcTaskList.Ht_TaskCount,
			Gw_TaskCount = cnpcTaskList.Gw_TaskCount,
			Bx_TaskCount = cnpcTaskList.Bx_TaskCount
		}.JsonSerialize();
	}

	private void AccountList(ResponseData handlerResult)
	{
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowFormService>().AccountList(base.RequestData.Data);
	}
}
