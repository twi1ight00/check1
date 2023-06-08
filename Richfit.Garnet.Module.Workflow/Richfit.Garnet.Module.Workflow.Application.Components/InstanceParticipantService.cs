using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

public class InstanceParticipantService : ServiceBase
{
	private IRepository<WF_INSTANCE_ACTIVITY> repository = null;

	/// <summary>
	/// 构造
	/// </summary> 
	public InstanceParticipantService()
	{
		repository = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE_ACTIVITY>>();
	}

	/// <summary>
	/// 获取实例活动参与人（数据库）
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <returns>WF_INSTANCE_ACTIVITY</returns>
	public List<WF_INSTANCE_ACTIVITY> GetInstanceActivityByInstanceId(Guid instanceId)
	{
		return repository.FindAll((WF_INSTANCE_ACTIVITY a) => a.INSTANCE_ID == instanceId).ToList();
	}

	/// <summary>
	/// 获取实例活动参与人（数据库）
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <returns>WF_INSTANCE_ACTIVITY</returns>
	public List<WF_INSTANCE_ACTIVITY> GetInstanceActivityByInstanceId(Guid instanceId, Guid activityId)
	{
		return repository.FindAll((WF_INSTANCE_ACTIVITY a) => a.INSTANCE_ID == instanceId && a.ACTIVITY_ID == activityId).ToList();
	}

	public void SaveInstanceActivity(List<WF_INSTANCE_ACTIVITY> INSTANCE_ACTIVITY)
	{
		if (INSTANCE_ACTIVITY.Any())
		{
			List<WF_INSTANCE_ACTIVITY> dbValue = GetInstanceActivityByInstanceId(INSTANCE_ACTIVITY[0].INSTANCE_ID);
			dbValue.ForEach(delegate(WF_INSTANCE_ACTIVITY x)
			{
				repository.Remove(x);
			});
			INSTANCE_ACTIVITY.ForEach(delegate(WF_INSTANCE_ACTIVITY x)
			{
				repository.Add(x);
			});
			repository.DbContext.Commit();
		}
	}
}
