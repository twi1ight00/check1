using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Supervise.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.Services;

public interface ISuperviseService
{
	SUP_ASSIGN_TASKDTO AddTask(SUP_ASSIGN_TASKDTO taskDTO);

	SUP_ASSIGN_TASKDTO UpdateTask(SUP_ASSIGN_TASKDTO taskDTO);

	void RemoveTask(string taskIds);

	SUP_ASSIGN_TASKDTO GetTaskByKey(Guid taskId);

	QueryResult<SUP_ASSIGN_TASKDTO> QueryTaskList(SUP_ASSIGN_TASKDTO taskDTO);

	QueryResult<SUP_ASSIGN_TASKDTO> QueryTaskStatusList(SUP_ASSIGN_TASKDTO taskDTO);

	void ChangeTaskStatus(Guid taskId, int status);

	void ChangeChildTaskStatus(Guid taskId, int status);

	SUP_PORJECTDTO AddProject(SUP_PORJECTDTO projectDTO);

	SUP_PORJECTDTO UpdateProject(SUP_PORJECTDTO projectDTO);

	void RemoveProject(string projectIds);

	SUP_PORJECTDTO GetProjectByKey(Guid projectId);

	void ChangeProjectStatus(Guid projectId, int status);

	void ChangeProjectChildTaskStatus(Guid projectId, int status);

	QueryResult<SUP_PORJECTDTO> QueryProjectList(SUP_PORJECTDTO projectDTO);

	QueryResult<SUP_PORJECTDTO> QueryMyProcessProject(SUP_PORJECTDTO projectDTO);

	IList<TREE_NODE> GetTaskUserTree();

	QueryResult<SUP_ASSIGN_TASKDTO> QueryApprovalChangeList(SUP_ASSIGN_TASKDTO taskDTO);

	QueryResult<SUP_ASSIGN_TASKDTO> GetChildTaskByUser(SUP_ASSIGN_TASKDTO taskDTO);

	IList<SUP_FEED_BACKDTO> AddTaskFeedBack(SUP_FEED_BACKDTO feedBackDTO);

	SUP_CHANGEDTO AddTaskChange(SUP_CHANGEDTO changeDTO);

	SUP_CHANGEDTO ApproveTaskChange(SUP_CHANGEDTO changeDTO);

	SUP_CHANGEDTO VetoTaskChange(SUP_CHANGEDTO changeDTO);

	QueryResult<SUP_ASSIGN_TASKDTO> GetPortalTaskByUser(SUP_ASSIGN_TASKDTO taskDTO);

	void SendSuperviseRemindingMessage(List<SUP_ASSIGN_TASKDTO> taskList);

	IList<SUP_TASK_PROGRESSDTO> AddTaskProgress(SUP_TASK_PROGRESSDTO progressDTO);
}
