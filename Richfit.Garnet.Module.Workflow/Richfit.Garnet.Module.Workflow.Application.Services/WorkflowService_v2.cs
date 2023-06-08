using System;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public class WorkflowService_v2 : ServiceBase
{
	/// <summary>
	///
	/// </summary>
	/// <param name="user">发起人</param>
	/// <param name="instanceId"></param>
	/// <param name="templateId"></param>
	/// <param name="formId"></param>
	/// <param name="instanceTitle"></param>
	/// <param name="instanceTableName"></param>
	/// <param name="parentInstanceId"></param>
	/// <param name="parentActivityId"></param>
	/// <returns></returns>
	public object CreateWorkflow(User user, WF_INSTANCE instance, Guid? parentInstanceId)
	{
		return null;
	}

	public void SubmitWorkflow()
	{
	}
}
