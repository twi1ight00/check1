using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

/// <summary>
/// 参与者服务
/// </summary>
public class ParticipantService : ServiceBase
{
	private readonly IRepository<WF_TEMPLATE> repositoryTemplate = null;

	private readonly IRepository<WF_INSTANCE> repositoryInstance = null;

	public ParticipantService()
	{
		repositoryTemplate = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
		repositoryInstance = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE>>();
	}

	/// <summary>
	/// 获取组织机构和人员
	/// </summary>
	/// <returns></returns>
	public IList<TREE_NODE> GetOrgTree(RequestData RequestData)
	{
		RequestData.ActionCode = "SystemManagement_GetOrgTree";
		Dictionary<string, string> dictionary = RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		dictionary["LEVEL"] = "-1";
		dictionary["IS_INCLUDE_SELF"] = "1";
		return AccessManager.ServiceAccess("Workflow", RequestData.ActionCode, dictionary.JsonSerialize()).Data.JsonDeserialize<IList<TREE_NODE>>(new JsonConverter[0]);
	}

	/// <summary>
	/// 查询角色信息
	/// </summary>
	/// <returns></returns>
	public QueryResult<SYS_ROLEDTO> GetRoleList(RequestData RequestData)
	{
		Dictionary<string, string> dictionary = RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		RequestData.ActionCode = "SystemManagement_QueryRoleListByParameter";
		QueryCondition condition = new QueryCondition();
		condition.Add(new QueryItem
		{
			Key = "ORG_ID",
			Value = dictionary["ORG_ID"],
			Method = " = ",
			Type = "guid"
		});
		return AccessManager.ServiceAccess("Workflow", RequestData.ActionCode, condition.JsonSerialize()).Data.JsonDeserialize<QueryResult<SYS_ROLEDTO>>(new JsonConverter[0]);
	}

	/// <summary>
	/// 获取流程处理参与人（机构和人）
	/// </summary>
	/// <returns></returns>
	public IList<TREE_NODE> GetActivityParticipantOrgAndUser(Guid activityId, Guid? orgId, Guid? instanceId, string submitType = "0", string templateId = "", string dataJson = null)
	{
		WF_TEMPLATE template = WorkflowCacheManager.GetTemplateById(new Guid(templateId)).AdaptAsEntity<WF_TEMPLATE>();
		Type t = Type.GetType($"{template.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
		IRunWorkflow runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
		WF_INSTANCE instance = null;
		if (instanceId.HasValue)
		{
			instance = repositoryInstance.GetByKey(instanceId.Value);
		}
		IList<User> userRoleOrgDTOs = runWorkflow.GetNextHandler(template, instance, template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == activityId), orgId.Value, dataJson);
		List<Guid> userIds = new List<Guid>();
		foreach (User item in userRoleOrgDTOs)
		{
			userIds.Add(item.CURRENT_USER_ID);
		}
		IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
		return orgUserService.GetOrgUserTreeByUser(userIds);
	}

	/// <summary>
	/// 获取流程处理参与人（仅仅人）
	/// </summary>
	/// <returns></returns>
	public List<User> GetActivityParticipantOnlyUser(Guid activityId, Guid? orgId, Guid? instanceId, string participantType = "0")
	{
		ActivityService activityService = new ActivityService();
		InstanceParticipantService instanceParticipantService = new InstanceParticipantService();
		List<Guid> normalRoleIds = new List<Guid>();
		List<Guid> globalRoleIds = new List<Guid>();
		List<Guid> activitys = new List<Guid>();
		List<User> users = new List<User>();
		if (participantType == "1")
		{
			activitys.Add(activityId);
		}
		else
		{
			if (instanceId.HasValue)
			{
				List<WF_INSTANCE_ACTIVITY> instanceActivitys = instanceParticipantService.GetInstanceActivityByInstanceId(instanceId.Value);
				WF_INSTANCE_ACTIVITY instanceActivity = instanceActivitys.SingleOrDefault((WF_INSTANCE_ACTIVITY a) => a.ACTIVITY_ID == activityId);
				if (instanceActivity != null && instanceActivity.WF_INSTANCE_ACTIVITY_USER != null && instanceActivity.WF_INSTANCE_ACTIVITY_USER.Count() > 0)
				{
					instanceActivity.WF_INSTANCE_ACTIVITY_USER.ForEach(delegate(WF_INSTANCE_ACTIVITY_USER a)
					{
						users.Add(new User
						{
							CURRENT_USER_ID = a.USER_ID,
							CURRENT_USER_NAME = a.USER_NAME
						});
					});
					return users;
				}
			}
			IList<WF_ACTIVITY_PARTICIPANTDTO> activityParticipantCollection = activityService.GetActivityParticipantByActivityId(activityId);
			foreach (WF_ACTIVITY_PARTICIPANTDTO item3 in activityParticipantCollection)
			{
				switch (int.Parse(item3.PARTICIPANT_TYPE.ToString()))
				{
				case 0:
					normalRoleIds.Add(item3.PARTICIPANT_ID);
					break;
				case 1:
					globalRoleIds.Add(item3.PARTICIPANT_ID);
					break;
				case 2:
					activitys.Add(item3.PARTICIPANT_ID);
					break;
				}
			}
		}
		List<SYS_USERDTO> userDTO = new List<SYS_USERDTO>();
		QueryCondition queryCondition = new QueryCondition();
		if (normalRoleIds.Count > 0 || globalRoleIds.Count > 0)
		{
			queryCondition.Add(new QueryItem
			{
				Key = "ORG_ID",
				Value = orgId.ToString(),
				Method = " = ",
				Type = "guid"
			});
			List<string> normalRoleIdList = new List<string>();
			List<string> globalRoleIdList = new List<string>();
			normalRoleIds.ForEach(delegate(Guid a)
			{
				normalRoleIdList.Add(Utility.GetGuidString(a));
			});
			globalRoleIds.ForEach(delegate(Guid a)
			{
				globalRoleIdList.Add(Utility.GetGuidString(a));
			});
			queryCondition.Add(new QueryItem
			{
				Key = "NORMAL_ROLE_IDS",
				Value = normalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			queryCondition.Add(new QueryItem
			{
				Key = "GLOBAL_ROLE_IDS",
				Value = globalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			ResponseData result = AccessManager.ServiceAccess("Workflow", "SystemManagement_GetWorkflowParticipant", queryCondition.JsonSerialize());
			userDTO.AddRange(result.Data.JsonDeserialize<IList<SYS_USERDTO>>(new JsonConverter[0]));
		}
		if (instanceId.HasValue)
		{
			foreach (Guid item2 in activitys)
			{
				queryCondition.Add(new QueryItem
				{
					Key = "ACTIVITY_ID",
					Value = item2.ToString(),
					Method = " = ",
					Type = "guid"
				});
				queryCondition.Add(new QueryItem
				{
					Key = "INSTANCE_ID",
					Value = instanceId.ToString(),
					Method = " = ",
					Type = "guid"
				});
				userDTO.AddRange(SqlQueryResult<SYS_USERDTO>("GetWorkflowParticipantByActivityID", queryCondition).List);
			}
		}
		foreach (SYS_USERDTO item in userDTO)
		{
			users.Add(new User
			{
				CURRENT_USER_ID = item.USER_ID,
				CURRENT_USER_NAME = item.DISPLAY_NAME,
				PROXY_USER_ID = item.USER_ID,
				PROXY_USER_NAME = item.DISPLAY_NAME,
				CURRENT_ORG_ID = item.ORG_ID,
				CURRENT_ORG_NAME = item.ORG_NAME,
				PROXY_ORG_ID = item.ORG_ID,
				PROXY_ORG_NAME = item.ORG_NAME
			});
		}
		return users;
	}

	/// <summary>
	/// 获取流程处理参与人（仅仅人）
	/// </summary>
	/// <returns></returns>
	public List<SYS_USERDTO> GetTemplateActivityParticipantOnlyUser(Guid templateId, Guid orgId)
	{
		WF_TEMPLATEDTO template = WorkflowCacheManager.GetTemplateById(templateId);
		List<Guid> normalRoleIds = new List<Guid>();
		List<Guid> globalRoleIds = new List<Guid>();
		foreach (WF_ACTIVITYDTO activity in template.WF_ACTIVITY)
		{
			IList<WF_ACTIVITY_PARTICIPANTDTO> activityParticipantCollection = activity.WF_ACTIVITY_PARTICIPANT.ToList();
			foreach (WF_ACTIVITY_PARTICIPANTDTO item in activityParticipantCollection)
			{
				switch (int.Parse(item.PARTICIPANT_TYPE.ToString()))
				{
				case 0:
					normalRoleIds.Add(item.PARTICIPANT_ID);
					break;
				case 1:
					globalRoleIds.Add(item.PARTICIPANT_ID);
					break;
				}
			}
		}
		List<SYS_USERDTO> userDTO = new List<SYS_USERDTO>();
		QueryCondition queryCondition = new QueryCondition();
		if (normalRoleIds.Count > 0 || globalRoleIds.Count > 0)
		{
			queryCondition.Add(new QueryItem
			{
				Key = "ORG_ID",
				Value = orgId.ToString(),
				Method = " = ",
				Type = "guid"
			});
			List<string> normalRoleIdList = new List<string>();
			List<string> globalRoleIdList = new List<string>();
			normalRoleIds.ForEach(delegate(Guid a)
			{
				normalRoleIdList.Add(Utility.GetGuidString(a));
			});
			globalRoleIds.ForEach(delegate(Guid a)
			{
				globalRoleIdList.Add(Utility.GetGuidString(a));
			});
			queryCondition.Add(new QueryItem
			{
				Key = "NORMAL_ROLE_IDS",
				Value = normalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			queryCondition.Add(new QueryItem
			{
				Key = "GLOBAL_ROLE_IDS",
				Value = globalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			ResponseData result = AccessManager.ServiceAccess("Workflow", "SystemManagement_GetWorkflowParticipant", queryCondition.JsonSerialize());
			userDTO.AddRange(result.Data.JsonDeserialize<IList<SYS_USERDTO>>(new JsonConverter[0]));
		}
		return userDTO;
	}

	public List<TREE_NODE> getParticipaintByUser(Guid userId)
	{
		Dictionary<string, string> dic = new Dictionary<string, string>();
		dic.Add("USER_ID", userId.ToString());
		ResponseData result = AccessManager.ServiceAccess("Workflow", "SystemManagement_QueryOrgRoleTree", dic.JsonSerialize());
		return result.Data.JsonDeserialize<List<TREE_NODE>>(new JsonConverter[0]);
	}
}
