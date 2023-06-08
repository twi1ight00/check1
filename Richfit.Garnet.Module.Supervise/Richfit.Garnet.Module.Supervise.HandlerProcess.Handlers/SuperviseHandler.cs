using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Supervise.Application.DTO;
using Richfit.Garnet.Module.Supervise.Application.Services;

namespace Richfit.Garnet.Module.Supervise.HandlerProcess.Handlers;

public class SuperviseHandler : HandlerBase
{
	private ISuperviseService superviseService = ServiceLocator.Instance.GetService<ISuperviseService>();

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
				case "Supervise_AddProject":
					AddProject(handlerResult);
					break;
				case "Supervise_UpdateProject":
					UpdateProject(handlerResult);
					break;
				case "Supervise_RemoveProject":
					RemoveProject(handlerResult);
					break;
				case "Supervise_GetProjectByKey":
					GetProjectByKey(handlerResult);
					break;
				case "Supervise_QueryProjectList":
					QueryProjectList(handlerResult);
					break;
				case "Supervise_QueryMyProcessProject":
					QueryMyProcessProject(handlerResult);
					break;
				case "Supervise_AddTask":
					AddTask(handlerResult);
					break;
				case "Supervise_UpdateTask":
					UpdateTask(handlerResult);
					break;
				case "Supervise_RemoveTask":
					RemoveTask(handlerResult);
					break;
				case "Supervise_GetTaskByKey":
					GetTaskByKey(handlerResult);
					break;
				case "Supervise_ChangeProjectStatus":
					ChangeProjectStatus(handlerResult);
					break;
				case "Supervise_ChangeProjectChildTaskStatus":
					ChangeProjectChildTaskStatus(handlerResult);
					break;
				case "Supervise_QueryTaskList":
					QueryTaskList(handlerResult);
					break;
				case "Supervise_QueryTaskStatusList":
					QueryTaskStatusList(handlerResult);
					break;
				case "Supervise_ChangeTaskStatus":
					ChangeTaskStatus(handlerResult);
					break;
				case "Supervise_ChangeChildTaskStatus":
					ChangeChildTaskStatus(handlerResult);
					break;
				case "Supervise_GetTaskUserTree":
					GetTaskUserTree(handlerResult);
					break;
				case "Supervise_QueryApprovalChangeList":
					QueryApprovalChangeList(handlerResult);
					break;
				case "Supervise_GetChildTaskByUser":
					GetChildTaskByUser(handlerResult);
					break;
				case "Supervise_AddTaskChange":
					AddTaskChange(handlerResult);
					break;
				case "Supervise_AddTaskFeedBack":
					AddTaskFeedBack(handlerResult);
					break;
				case "Supervise_ApproveTaskChange":
					ApproveTaskChange(handlerResult);
					break;
				case "Supervise_VetoTaskChange":
					VetoTaskChange(handlerResult);
					break;
				case "Supervise_GetPortalTaskByUser":
					GetPortalTaskByUser(handlerResult);
					break;
				case "Supervise_SendSuperviseRemindingMessage":
					SendSuperviseRemindingMessage(handlerResult);
					break;
				case "Supervise_AddTaskProgress":
					AddTaskProgress(handlerResult);
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

	private void AddTaskProgress(ResponseData handlerResult)
	{
		SUP_TASK_PROGRESSDTO progressDTO = DTOBase.DeserializeFromJson<SUP_TASK_PROGRESSDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.AddTaskProgress(progressDTO).ToJson();
	}

	private void SendSuperviseRemindingMessage(ResponseData handlerResult)
	{
		List<SUP_ASSIGN_TASKDTO> taskList = base.RequestData.Data.JsonDeserialize<List<SUP_ASSIGN_TASKDTO>>(new JsonConverter[0]);
		superviseService.SendSuperviseRemindingMessage(taskList);
	}

	private void GetPortalTaskByUser(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = base.RequestData.Data.JsonDeserialize<SUP_ASSIGN_TASKDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.GetPortalTaskByUser(taskDTO).ToJson();
	}

	private void VetoTaskChange(ResponseData handlerResult)
	{
		SUP_CHANGEDTO changeDTO = DTOBase.DeserializeFromJson<SUP_CHANGEDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.VetoTaskChange(changeDTO).ToJson();
	}

	private void ApproveTaskChange(ResponseData handlerResult)
	{
		SUP_CHANGEDTO changeDTO = DTOBase.DeserializeFromJson<SUP_CHANGEDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.ApproveTaskChange(changeDTO).ToJson();
	}

	private void AddTaskChange(ResponseData handlerResult)
	{
		SUP_CHANGEDTO changeDTO = DTOBase.DeserializeFromJson<SUP_CHANGEDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.AddTaskChange(changeDTO).ToJson();
	}

	private void AddTaskFeedBack(ResponseData handlerResult)
	{
		SUP_FEED_BACKDTO feedBackDTO = DTOBase.DeserializeFromJson<SUP_FEED_BACKDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.AddTaskFeedBack(feedBackDTO).ToJson();
	}

	private void GetChildTaskByUser(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = base.RequestData.Data.JsonDeserialize<SUP_ASSIGN_TASKDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.GetChildTaskByUser(taskDTO).ToJson();
	}

	private void QueryApprovalChangeList(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = base.RequestData.Data.JsonDeserialize<SUP_ASSIGN_TASKDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.QueryApprovalChangeList(taskDTO).ToJson();
	}

	private void GetTaskUserTree(ResponseData handlerResult)
	{
		handlerResult.Data = superviseService.GetTaskUserTree().JsonSerialize();
	}

	private void QueryTaskList(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = base.RequestData.Data.JsonDeserialize<SUP_ASSIGN_TASKDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.QueryTaskList(taskDTO).ToJson();
	}

	private void QueryTaskStatusList(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = base.RequestData.Data.JsonDeserialize<SUP_ASSIGN_TASKDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.QueryTaskStatusList(taskDTO).ToJson();
	}

	private void GetTaskByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid taskId = (string.IsNullOrEmpty(Dict["ASSIGN_TASK_ID"]) ? Guid.Empty : Guid.Parse(Dict["ASSIGN_TASK_ID"]));
		handlerResult.Data = superviseService.GetTaskByKey(taskId).ToJson();
	}

	private void RemoveTask(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		superviseService.RemoveTask(Dict["ASSIGN_TASK_ID"]);
	}

	private void UpdateTask(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = DTOBase.DeserializeFromJson<SUP_ASSIGN_TASKDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.UpdateTask(taskDTO).ToJson();
	}

	private void AddTask(ResponseData handlerResult)
	{
		SUP_ASSIGN_TASKDTO taskDTO = DTOBase.DeserializeFromJson<SUP_ASSIGN_TASKDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.AddTask(taskDTO).ToJson();
	}

	private void ChangeTaskStatus(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid taskID = Guid.Parse(Dict["ASSIGN_TASK_ID"]);
		int taskStatus = int.Parse(Dict["TASK_STATUS"]);
		superviseService.ChangeTaskStatus(taskID, taskStatus);
	}

	private void ChangeChildTaskStatus(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid taskID = Guid.Parse(Dict["ASSIGN_TASK_ID"]);
		int taskStatus = int.Parse(Dict["TASK_STATUS"]);
		superviseService.ChangeChildTaskStatus(taskID, taskStatus);
	}

	private void QueryProjectList(ResponseData handlerResult)
	{
		SUP_PORJECTDTO condition = base.RequestData.Data.JsonDeserialize<SUP_PORJECTDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.QueryProjectList(condition).ToJson();
	}

	private void QueryMyProcessProject(ResponseData handlerResult)
	{
		SUP_PORJECTDTO condition = base.RequestData.Data.JsonDeserialize<SUP_PORJECTDTO>(new JsonConverter[0]);
		handlerResult.Data = superviseService.QueryMyProcessProject(condition).ToJson();
	}

	private void AddProject(ResponseData handlerResult)
	{
		SUP_PORJECTDTO projectDTO = DTOBase.DeserializeFromJson<SUP_PORJECTDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.AddProject(projectDTO).ToJson();
	}

	private void UpdateProject(ResponseData handlerResult)
	{
		SUP_PORJECTDTO projectDTO = DTOBase.DeserializeFromJson<SUP_PORJECTDTO>(base.RequestData.Data);
		handlerResult.Data = superviseService.UpdateProject(projectDTO).ToJson();
	}

	private void RemoveProject(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		superviseService.RemoveProject(Dict["PORJECT_ID"]);
	}

	private void GetProjectByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid projectId = (string.IsNullOrEmpty(Dict["PORJECT_ID"]) ? Guid.Empty : Guid.Parse(Dict["PORJECT_ID"]));
		handlerResult.Data = superviseService.GetProjectByKey(projectId).ToJson();
	}

	private void ChangeProjectStatus(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid projectId = (string.IsNullOrEmpty(Dict["PORJECT_ID"]) ? Guid.Empty : Guid.Parse(Dict["PORJECT_ID"]));
		int status = int.Parse(Dict["SUPERVISE_STATUS"]);
		superviseService.ChangeProjectStatus(projectId, status);
	}

	private void ChangeProjectChildTaskStatus(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid projectId = (string.IsNullOrEmpty(Dict["PORJECT_ID"]) ? Guid.Empty : Guid.Parse(Dict["PORJECT_ID"]));
		int status = int.Parse(Dict["SUPERVISE_STATUS"]);
		superviseService.ChangeProjectChildTaskStatus(projectId, status);
	}
}
