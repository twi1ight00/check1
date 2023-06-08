using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

/// <summary>
/// 实例服务
/// </summary>
public class InstanceService : ServiceBase
{
	private IRepository<WF_INSTANCE> repository = null;

	private DateTime dt = DateTime.Now;

	/// <summary>
	/// 构造
	/// </summary> 
	public InstanceService()
	{
		repository = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE>>();
	}

	/// <summary>
	/// 获取实例（数据库）
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <returns>WF_INSTANCE</returns>
	public WF_INSTANCE GetInstanceById(Guid instanceId)
	{
		return repository.GetByKey(instanceId);
	}

	/// <summary>
	/// 获取工作项
	/// </summary>
	/// <param name="workItemId">工作项</param>
	/// <returns></returns>
	public WF_WORKITEM GetWorkItemById(Guid workItemId)
	{
		return ServiceLocator.Instance.GetService<IRepository<WF_WORKITEM>>().GetByKey(workItemId);
	}

	/// <summary>
	/// 更新实例名称
	/// </summary>
	/// <param name="instanceId"></param>
	/// <param name="instanceName"></param>
	public void UpdateInstanceName(Guid instanceId, string instanceName)
	{
		WF_INSTANCE instance = repository.GetByKey(instanceId);
		instance.INSTANCE_NAME = instanceName;
		repository.UpdateCommit(instance);
	}

	/// <summary>
	/// 删除实例
	/// </summary>
	public void DeleteInstance(string instanceIds)
	{
		repository.LogicRemoveCommit(instanceIds);
	}

	/// <summary>
	/// 创建流程
	/// </summary>
	/// <param name="user">用户DTO</param>
	/// <param name="instanceId">当前实例ID</param>
	/// <param name="instanceTitle">实例名称</param>
	/// <param name="instanceTableName">实例表名称</param>
	/// <param name="templateId">模板ID</param>
	/// <param name="formId">表单ID</param>
	/// <param name="parentInstanceId">父模板ID</param>
	/// <param name="parentActivityId">父活动id</param>
	/// <returns>工作项ID</returns>
	public object CreateWorkflow(User user, Guid instanceId, Guid templateId, Guid formId, string instanceTitle, string instanceTableName, Guid? parentInstanceId, Guid? parentActivityId)
	{
		if (user.CURRENT_USER_ID == Guid.Empty || user == null)
		{
			throw new CustomCodeException("当前用户不能为空!");
		}
		if (!user.CURRENT_ORG_ID.HasValue || user.CURRENT_ORG_ID == Guid.Empty)
		{
			throw new CustomCodeException("组织机构ID不能为空!");
		}
		if (instanceId == Guid.Empty)
		{
			throw new CustomCodeException("实例ID不能为空");
		}
		if (string.IsNullOrEmpty(instanceTitle))
		{
			throw new CustomCodeException("实例标题不能为空");
		}
		if (templateId == Guid.Empty)
		{
			throw new CustomCodeException("模板ID不能为空");
		}
		if (formId == Guid.Empty)
		{
			throw new CustomCodeException("模板ID不能为空");
		}
		WF_FORMDTO form = WorkflowCacheManager.GetFormById(formId);
		if (form == null)
		{
			throw new CustomCodeException("请配置模板表单信息！");
		}
		WF_ACTIVITYDTO startActivity = new ActivityService().GetStartActivity(templateId);
		if (startActivity == null)
		{
			throw new CustomCodeException("没找到开始活动!");
		}
		WF_INSTANCE instance = new WF_INSTANCE();
		instance.INSTANCE_ID = instanceId;
		instance.INSTANCE_NAME = (string.IsNullOrEmpty(instanceTitle) ? string.Empty : instanceTitle);
		instance.TEMPLATE_ID = templateId;
		instance.ORG_ID = user.CURRENT_ORG_ID.Value;
		instance.ORG_NAME = OrgUserCacheManager.GetOrgByKey(user.CURRENT_ORG_ID.Value).ORG_NAME;
		instance.TABLE_NAME = (string.IsNullOrEmpty(instanceTableName) ? string.Empty : instanceTableName);
		instance.RUN_STATE = 0m;
		instance.START_USER_ID = user.CURRENT_USER_ID;
		instance.START_USER_NAME = user.CURRENT_USER_NAME;
		if (parentActivityId.HasValue)
		{
		}
		if (parentInstanceId.HasValue)
		{
			instance.PARENT_INSTANCE_ID = parentInstanceId.Value;
		}
		instance.START_TIME = DateTime.Now;
		WF_WORKITEM workItem = new WF_WORKITEM();
		workItem.WORKITEM_ID = Guid.NewGuid();
		workItem.INSTANCE_ID = instance.INSTANCE_ID;
		workItem.ACTIVITY_ID = startActivity.ACTIVITY_ID;
		workItem.WORKITEM_NAME = startActivity.ACTIVITY_NAME;
		workItem.WORKITEM_RUN_STATE = 0m;
		workItem.GENERATE_TYPE = 0m;
		workItem.HANDLE_RESULT = 0m;
		workItem.SENDER_USER_ID = user.CURRENT_USER_ID;
		workItem.SENDER_USER_NAME = user.CURRENT_USER_NAME;
		workItem.SEND_TIME = DateTime.Now.AddSeconds(-1.0);
		workItem.WF_WORKITEM_HANDLER.Add(new WF_WORKITEM_HANDLER
		{
			WORKITEM_HANDLER_ID = Guid.NewGuid(),
			WORKITEM_ID = workItem.WORKITEM_ID,
			USER_ID = user.CURRENT_USER_ID,
			USER_NAME = user.CURRENT_USER_NAME,
			HANDLE_RESULT = 0m,
			SIGNATURE_MODE = Bit.pro((long)startActivity.STATUS.Value, "8|2")
		});
		instance.WF_WORKITEM.Add(workItem);
		repository.AddCommit(instance);
		return new
		{
			WORKITEM_ID = workItem.WORKITEM_ID,
			INSTANCE_ID = instanceId
		};
	}

	/// <summary>
	/// 重置已完成流程
	/// </summary>
	/// <param name="instanceId">实例</param>
	/// <param name="user">用户</param>
	public void ResetWorkflow(Guid instanceId, User user)
	{
		WF_INSTANCE instance = GetInstanceById(instanceId);
		WF_WORKITEM firstWorkItem = instance.WF_WORKITEM.SingleOrDefault((WF_WORKITEM a) => !a.PARENT_WORKITEM_ID.HasValue);
		WF_WORKITEM workItem = new WF_WORKITEM();
		workItem.WORKITEM_NAME = firstWorkItem.WORKITEM_NAME;
		workItem.ACTIVITY_ID = firstWorkItem.ACTIVITY_ID;
		instance.RUN_STATE = 0m;
		workItem.WORKITEM_ID = Guid.NewGuid();
		workItem.INSTANCE_ID = instanceId;
		workItem.WORKITEM_RUN_STATE = 0m;
		workItem.HANDLE_RESULT = 0m;
		workItem.SENDER_USER_ID = instance.START_USER_ID;
		workItem.SEND_TIME = DateTime.Now;
		workItem.ISDEL = 0m;
		workItem.CREATOR = user.CURRENT_USER_ID;
		workItem.CREATETIME = DateTime.Now;
		workItem.MODIFIER = user.CURRENT_USER_ID;
		workItem.MODIFYTIME = DateTime.Now;
		WF_WORKITEM_HANDLER handler = new WF_WORKITEM_HANDLER();
		handler.WORKITEM_HANDLER_ID = Guid.NewGuid();
		handler.WORKITEM_ID = workItem.WORKITEM_ID;
		handler.USER_ID = instance.START_USER_ID;
		handler.HANDLE_RESULT = 0m;
		handler.ISDEL = 0m;
		handler.CREATETIME = DateTime.Now;
		handler.CREATOR = user.CURRENT_USER_ID;
		handler.MODIFIER = user.CURRENT_USER_ID;
		handler.MODIFYTIME = DateTime.Now;
		workItem.WF_WORKITEM_HANDLER.Add(handler);
		repository.RemoveChild(instance.WF_WORKITEM);
		instance.WF_WORKITEM.Add(workItem);
		repository.UpdateCommit(instance);
	}

	/// <summary>
	/// 提交工作流
	/// </summary>
	/// <param name="instanceId">当前实例</param>
	/// <param name="workItemId">当前工作项</param>
	/// <param name="user">提交用户信息</param>
	/// <param name="handleResult">处理结果</param>
	/// <param name="handleSuggestion">处理意见</param>
	/// <param name="rules">规则</param>
	/// <param name="customNext">自定义活动参与</param>
	/// <returns>提交结果</returns>
	public void Submit(Guid instanceId, Guid workItemId, User user, int handleResult, string handleSuggestion, string rules, List<NEXT_ACTIVITY> customNext = null)
	{
		WF_INSTANCE currentInstance = GetInstanceById(instanceId);
		WF_WORKITEM currentWorkItem = null;
		WF_ACTIVITYDTO currentActivity = null;
		if (!(workItemId == Guid.Empty))
		{
			currentWorkItem = currentInstance.WF_WORKITEM.Single((WF_WORKITEM a) => a.WORKITEM_ID == workItemId);
			currentActivity = WorkflowCacheManager.GetActivityById(currentWorkItem.ACTIVITY_ID);
		}
		if (handleResult == 8192 || handleResult == 4096 || handleResult == 0)
		{
			Do(currentInstance, currentWorkItem, user, (HANDLE_RESULT)handleResult, handleSuggestion);
		}
		else
		{
			if (handleResult != 4 && handleResult != 8 && handleResult != 16)
			{
				decimal? wORKITEM_RUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
				if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 2m) || !wORKITEM_RUN_STATE.HasValue)
				{
					wORKITEM_RUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
					if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 1024m) || !wORKITEM_RUN_STATE.HasValue)
					{
						wORKITEM_RUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
						if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 2048m) || !wORKITEM_RUN_STATE.HasValue)
						{
							wORKITEM_RUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
							if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 4096m) || !wORKITEM_RUN_STATE.HasValue)
							{
								wORKITEM_RUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
								if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 8192m) || !wORKITEM_RUN_STATE.HasValue)
								{
									wORKITEM_RUN_STATE = currentInstance.RUN_STATE;
									if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 2m) || !wORKITEM_RUN_STATE.HasValue)
									{
										Do(currentInstance, currentWorkItem, currentActivity, user, handleResult, handleSuggestion, rules, customNext);
										goto IL_0235;
									}
								}
							}
						}
					}
				}
				throw new ValidationException("SystemManagement.Public.E_0001", new string[1] { "当前工作项已被处理" });
			}
			Do(currentInstance, currentWorkItem, currentActivity, customNext?[0].USER_IDS, user, (HANDLE_RESULT)handleResult, handleSuggestion);
		}
		goto IL_0235;
		IL_0235:
		repository.DbContext.Commit();
	}

	/// <summary>
	/// 多个活动提交
	/// </summary>
	private void Do(WF_INSTANCE currentInstance, WF_WORKITEM currentWorkItem, WF_ACTIVITYDTO currentActivity, User user, int handleResult, string handleSuggestion, string rules, List<NEXT_ACTIVITY> customNextActivitys = null)
	{
		IList<WF_ACTIVITYDTO> nextActivitys = GetNextActivity((HANDLE_RESULT)handleResult, currentActivity, rules, customNextActivitys);
		foreach (WF_ACTIVITYDTO nextActivity in nextActivitys)
		{
			List<User> handler = new List<User>();
			if (customNextActivitys != null)
			{
				NEXT_ACTIVITY customNextActivity = customNextActivitys.FirstOrDefault((NEXT_ACTIVITY a) => a.ACTIVITY.ACTIVITY_ID == nextActivity.ACTIVITY_ID);
				if (customNextActivity == null)
				{
					continue;
				}
				handler = customNextActivity.USER_IDS;
			}
			switch ((HANDLE_RESULT)handleResult)
			{
			default:
				return;
			case HANDLE_RESULT.Adopt:
				if (handler == null || handler.Count == 0)
				{
					if ((int)nextActivity.ACTIVITY_TYPE.Value == 0 || (int)nextActivity.ACTIVITY_TYPE.Value == -1 || (int)nextActivity.ACTIVITY_TYPE.Value == 1)
					{
						handler = new ParticipantService().GetActivityParticipantOnlyUser(nextActivity.ACTIVITY_ID, currentInstance.ORG_ID, currentInstance.INSTANCE_ID);
					}
					if (handler == null || handler.Count == 0)
					{
						new CustomCodeException("提交到下一步没有审批人");
					}
				}
				break;
			case HANDLE_RESULT.Return:
				handler = GetUserByActivityId(currentInstance, nextActivity.ACTIVITY_ID);
				RemarkWorkItem(currentInstance, nextActivity, currentWorkItem, HANDLE_RESULT.Return);
				break;
			case HANDLE_RESULT.Retrieve:
				handler = GetUserByActivityId(currentInstance, nextActivity.ACTIVITY_ID);
				RemarkWorkItem(currentInstance, nextActivity, currentWorkItem, HANDLE_RESULT.Retrieve);
				break;
			}
			Do(currentInstance, currentWorkItem, currentActivity, nextActivity, handler, user, (HANDLE_RESULT)handleResult, handleSuggestion, rules, customNextActivitys);
		}
	}

	/// <summary>
	/// 单个活动驱动
	/// </summary>
	private void Do(WF_INSTANCE currentInstance, WF_WORKITEM currentWorkItem, WF_ACTIVITYDTO currentActivity, WF_ACTIVITYDTO nextActivity, List<User> toUser, User user, HANDLE_RESULT handleResult, string handleSuggestion, string rules = "", List<NEXT_ACTIVITY> customNext = null)
	{
		if (!DoWorkItem(currentWorkItem, currentActivity, user, handleResult, handleSuggestion))
		{
			return;
		}
		currentInstance.RUN_STATE = 0m;
		switch ((ACTIVITY_TYPE)(int)nextActivity.ACTIVITY_TYPE.Value)
		{
		case ACTIVITY_TYPE.Drafting:
			currentInstance.WF_WORKITEM.Add(GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			break;
		case ACTIVITY_TYPE.Approval:
		{
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			if (Bit.pro((long)nextActivity.STATUS.Value, "12|2") == 1 && toUser.Where((User a) => a.PROXY_USER_ID == user.PROXY_USER_ID).Count() > 0)
			{
				Do(currentInstance, newWorkItem, nextActivity, user, (int)handleResult, handleSuggestion, rules, customNext);
			}
			break;
		}
		case ACTIVITY_TYPE.Condition:
		{
			toUser = new List<User>();
			toUser.Add(user);
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			Do(currentInstance, newWorkItem, nextActivity, user, (int)handleResult, handleSuggestion, rules, customNext);
			break;
		}
		case ACTIVITY_TYPE.Branching:
		{
			toUser = new List<User>();
			toUser.Add(user);
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			Do(currentInstance, newWorkItem, nextActivity, user, (int)handleResult, handleSuggestion, rules, customNext);
			break;
		}
		case ACTIVITY_TYPE.Merging:
		{
			if (!EnableGenerateWorkItem(currentInstance, nextActivity))
			{
				break;
			}
			IList<WF_ACTIVITYDTO> activitys = new ActivityService().GetBetweenActivity(currentInstance.TEMPLATE_ID.Value, nextActivity.BRANCH_ACTIVITY_ID.Value, nextActivity.ACTIVITY_ID);
			List<Guid> activityIds = new List<Guid>();
			foreach (WF_ACTIVITYDTO activity in activitys)
			{
				activityIds.Add(activity.ACTIVITY_ID);
			}
			activitys.ForEach(delegate(WF_ACTIVITYDTO a)
			{
				activityIds.Add(a.ACTIVITY_ID);
			});
			IEnumerable<WF_WORKITEM> workitems = currentInstance.WF_WORKITEM.Where((WF_WORKITEM a) => a.ISDEL == 0m && activityIds.Contains(a.ACTIVITY_ID));
			foreach (WF_WORKITEM workitem in workitems)
			{
				decimal? hANDLE_RESULT = workitem.HANDLE_RESULT;
				if (hANDLE_RESULT.GetValueOrDefault() != 0m || !hANDLE_RESULT.HasValue)
				{
					continue;
				}
				workitem.HANDLE_RESULT = 16384m;
				foreach (WF_WORKITEM_HANDLER handler in workitem.WF_WORKITEM_HANDLER)
				{
					hANDLE_RESULT = handler.HANDLE_RESULT;
					if (hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue)
					{
						handler.HANDLE_RESULT = 16384m;
					}
				}
			}
			toUser = new List<User>();
			toUser.Add(user);
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			Do(currentInstance, newWorkItem, nextActivity, user, (int)handleResult, handleSuggestion, rules);
			break;
		}
		case ACTIVITY_TYPE.Freedom:
		{
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			break;
		}
		case ACTIVITY_TYPE.End:
		{
			currentInstance.RUN_STATE = 2m;
			currentInstance.FINISH_TIME = DateTime.Now;
			WF_WORKITEM newWorkItem;
			currentInstance.WF_WORKITEM.Add(newWorkItem = GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, nextActivity, user, toUser, handleResult));
			DoWorkItem(newWorkItem, currentActivity, user, handleResult, handleSuggestion);
			break;
		}
		}
	}

	/// <summary>
	/// 终止或挂起或恢复
	/// </summary>
	private void Do(WF_INSTANCE currentInstance, WF_WORKITEM currentWorkItem, User user, HANDLE_RESULT handleResult, string handleSuggestion)
	{
		List<WF_WORKITEM> workitems = null;
		HANDLE_RESULT currentHandleResult = HANDLE_RESULT.None;
		WORKITEM_RUN_STATE currentWIRunState = WORKITEM_RUN_STATE.None;
		switch (handleResult)
		{
		case HANDLE_RESULT.Transfer:
			workitems = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? wORKITEM_RUN_STATE3 = a.WORKITEM_RUN_STATE;
				decimal num4 = (int)currentWIRunState;
				int result3;
				if (wORKITEM_RUN_STATE3.GetValueOrDefault() == num4 && wORKITEM_RUN_STATE3.HasValue)
				{
					wORKITEM_RUN_STATE3 = a.HANDLE_RESULT;
					result3 = ((wORKITEM_RUN_STATE3.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE3.HasValue) ? 1 : 0);
				}
				else
				{
					result3 = 0;
				}
				return (byte)result3 != 0;
			}).ToList();
			break;
		case HANDLE_RESULT.Suspended:
			currentInstance.RUN_STATE = 4096m;
			workitems = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? wORKITEM_RUN_STATE2 = a.WORKITEM_RUN_STATE;
				decimal num3 = (int)currentWIRunState;
				int result2;
				if (wORKITEM_RUN_STATE2.GetValueOrDefault() == num3 && wORKITEM_RUN_STATE2.HasValue)
				{
					wORKITEM_RUN_STATE2 = a.HANDLE_RESULT;
					result2 = ((wORKITEM_RUN_STATE2.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE2.HasValue) ? 1 : 0);
				}
				else
				{
					result2 = 0;
				}
				return (byte)result2 != 0;
			}).ToList();
			break;
		case HANDLE_RESULT.Terminated:
			currentInstance.RUN_STATE = 8192m;
			workitems = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? wORKITEM_RUN_STATE = a.WORKITEM_RUN_STATE;
				decimal num2 = (int)currentWIRunState;
				int result;
				if (wORKITEM_RUN_STATE.GetValueOrDefault() == num2 && wORKITEM_RUN_STATE.HasValue)
				{
					wORKITEM_RUN_STATE = a.HANDLE_RESULT;
					result = ((wORKITEM_RUN_STATE.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE.HasValue) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).ToList();
			break;
		case HANDLE_RESULT.None:
		{
			decimal? rUN_STATE = currentInstance.RUN_STATE;
			if (rUN_STATE.GetValueOrDefault() == 4096m && rUN_STATE.HasValue)
			{
				currentHandleResult = HANDLE_RESULT.Suspended;
				currentWIRunState = WORKITEM_RUN_STATE.Suspended;
			}
			else
			{
				rUN_STATE = currentInstance.RUN_STATE;
				if (rUN_STATE.GetValueOrDefault() == 8192m && rUN_STATE.HasValue)
				{
					currentHandleResult = HANDLE_RESULT.Terminated;
					currentWIRunState = WORKITEM_RUN_STATE.Terminated;
				}
			}
			currentInstance.RUN_STATE = 0m;
			workitems = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? wORKITEM_RUN_STATE4 = a.WORKITEM_RUN_STATE;
				decimal num5 = (int)currentWIRunState;
				return wORKITEM_RUN_STATE4.GetValueOrDefault() == num5 && wORKITEM_RUN_STATE4.HasValue;
			}).ToList();
			break;
		}
		}
		foreach (WF_WORKITEM workitem in workitems)
		{
			workitem.WORKITEM_RUN_STATE = (int)handleResult;
			workitem.HANDLE_RESULT = (int)handleResult;
			foreach (WF_WORKITEM_HANDLER handler in workitem.WF_WORKITEM_HANDLER)
			{
				decimal? rUN_STATE = handler.HANDLE_RESULT;
				decimal num = (int)currentHandleResult;
				if (rUN_STATE.GetValueOrDefault() == num && rUN_STATE.HasValue)
				{
					handler.HANDLE_RESULT = (int)handleResult;
					handler.HANDLE_SUGGESTION = handleSuggestion;
					handler.HANDLE_USER_ID = user.CURRENT_USER_ID;
					handler.HANDLE_USER_NAME = user.CURRENT_USER_NAME;
					handler.HANDLE_TIME = DateTime.Now;
					handler.MODIFIER = user.CURRENT_USER_ID;
					handler.MODIFYTIME = DateTime.Now;
				}
			}
		}
	}

	/// <summary>
	///             转批或传阅或传阅审批
	/// </summary>
	private void Do(WF_INSTANCE currentInstance, WF_WORKITEM currentWorkItem, WF_ACTIVITYDTO currentActivity, List<User> toUser, User user, HANDLE_RESULT handleResult, string handleSuggestion)
	{
		switch (handleResult)
		{
		case HANDLE_RESULT.Transfer:
			currentWorkItem.HANDLE_RESULT = (int)handleResult;
			currentWorkItem.WORKITEM_RUN_STATE = 4m;
			GenerateWorkItemHandler(currentInstance, ref currentWorkItem, currentWorkItem.WORKITEM_ID, currentActivity, null, user, toUser);
			DoWorkItem(currentWorkItem, currentActivity, user, handleResult, handleSuggestion);
			break;
		case HANDLE_RESULT.Circulate:
			currentInstance.WF_WORKITEM.Add(GenerateWorkItem(currentInstance, currentWorkItem, currentActivity, currentActivity, user, toUser, handleResult));
			break;
		case HANDLE_RESULT.CirculateAdopt:
			currentWorkItem.HANDLE_RESULT = (int)handleResult;
			currentWorkItem.WORKITEM_RUN_STATE = 16m;
			DoWorkItem(currentWorkItem, user, handleResult, handleSuggestion);
			break;
		}
	}

	/// <summary>
	/// 处理工作项
	/// </summary>
	private bool DoWorkItem(WF_WORKITEM currentWorkItem, WF_ACTIVITYDTO currentActivity, User user, HANDLE_RESULT handleResult, string handleSuggestion)
	{
		switch ((ACTIVITY_TYPE)(int)currentActivity.ACTIVITY_TYPE.Value)
		{
		case ACTIVITY_TYPE.Drafting:
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		case ACTIVITY_TYPE.Approval:
		{
			List<WF_WORKITEM_HANDLER> handlers = currentWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
			{
				decimal? hANDLE_RESULT = a.HANDLE_RESULT;
				return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue;
			}).ToList();
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 0)
			{
				decimal? fINISH_NUMBER = currentWorkItem.WORKITEM_RUN_STATE;
				if (fINISH_NUMBER.GetValueOrDefault() != 4m || !fINISH_NUMBER.HasValue)
				{
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
					return true;
				}
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 1)
			{
				decimal? fINISH_NUMBER = currentWorkItem.WORKITEM_RUN_STATE;
				if (fINISH_NUMBER.GetValueOrDefault() != 4m || !fINISH_NUMBER.HasValue)
				{
					double finishedPercent = 1 - (handlers.Count() - 1) / currentWorkItem.WF_WORKITEM_HANDLER.Count();
					if (finishedPercent < (double)currentActivity.FINISH_NUMBER.Value / 100.0)
					{
						FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
						return false;
					}
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
					return true;
				}
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 2)
			{
				decimal? fINISH_NUMBER = currentWorkItem.WORKITEM_RUN_STATE;
				if (fINISH_NUMBER.GetValueOrDefault() != 4m || !fINISH_NUMBER.HasValue)
				{
					decimal num = currentWorkItem.WF_WORKITEM_HANDLER.Count() - handlers.Count() + 1;
					fINISH_NUMBER = currentActivity.FINISH_NUMBER;
					if (num < fINISH_NUMBER.GetValueOrDefault() && fINISH_NUMBER.HasValue)
					{
						FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
						return false;
					}
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
					return true;
				}
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") != 3)
			{
				decimal? fINISH_NUMBER = currentWorkItem.WORKITEM_RUN_STATE;
				if (!(fINISH_NUMBER.GetValueOrDefault() == 4m) || !fINISH_NUMBER.HasValue)
				{
					return true;
				}
			}
			if (handlers.Count() == 1)
			{
				FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
				return true;
			}
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
			return false;
		}
		case ACTIVITY_TYPE.Freedom:
		{
			List<WF_WORKITEM_HANDLER> handlers = currentWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
			{
				decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
				return hANDLE_RESULT2.GetValueOrDefault() == 0m && hANDLE_RESULT2.HasValue;
			}).ToList();
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 0)
			{
				FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
				return true;
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 1)
			{
				double finishedPercent = 1 - (handlers.Count() - 1) / currentWorkItem.WF_WORKITEM_HANDLER.Count();
				if (finishedPercent < (double)currentActivity.FINISH_NUMBER.Value / 100.0)
				{
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
					return false;
				}
				FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
				return true;
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 2)
			{
				decimal num = currentWorkItem.WF_WORKITEM_HANDLER.Count() - handlers.Count() + 1;
				decimal? fINISH_NUMBER = currentActivity.FINISH_NUMBER;
				if (num < fINISH_NUMBER.GetValueOrDefault() && fINISH_NUMBER.HasValue)
				{
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
					return false;
				}
				FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
				return true;
			}
			if (Bit.pro((long)currentActivity.STATUS.Value, "24|2") == 3)
			{
				if (handlers.Count() == 1)
				{
					FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
					return true;
				}
				FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
				return false;
			}
			return true;
		}
		case ACTIVITY_TYPE.Branching:
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		case ACTIVITY_TYPE.Merging:
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		case ACTIVITY_TYPE.Subprocesses:
			FinishWorkItem(currentWorkItem, user, handleResult, null, fnishWorkItem: false);
			return true;
		case ACTIVITY_TYPE.Condition:
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		case ACTIVITY_TYPE.End:
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		default:
			return true;
		}
	}

	private bool DoWorkItem(WF_WORKITEM currentWorkItem, User user, HANDLE_RESULT handleResult, string handleSuggestion)
	{
		List<WF_WORKITEM_HANDLER> handlers = currentWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue;
		}).ToList();
		if (handlers.Count() == 1)
		{
			FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: true);
			return true;
		}
		FinishWorkItem(currentWorkItem, user, handleResult, handleSuggestion, fnishWorkItem: false);
		return false;
	}

	private IList<WF_ACTIVITYDTO> GetNextActivity(HANDLE_RESULT handleResult, WF_ACTIVITYDTO currentActivity, string rules, List<NEXT_ACTIVITY> customNextActivitys)
	{
		IList<WF_ACTIVITYDTO> nextActivitys = new List<WF_ACTIVITYDTO>();
		if (handleResult == HANDLE_RESULT.Retrieve)
		{
			foreach (NEXT_ACTIVITY item2 in customNextActivitys)
			{
				nextActivitys.Add(item2.ACTIVITY);
			}
		}
		else
		{
			decimal? aCTIVITY_TYPE = currentActivity.ACTIVITY_TYPE;
			if (aCTIVITY_TYPE.GetValueOrDefault() == 1m && aCTIVITY_TYPE.HasValue)
			{
				IList<WF_ACTIVITYDTO> precursorActivitys = new ActivityService().GetPrecursorActivitys(currentActivity.ACTIVITY_ID);
				foreach (WF_ACTIVITYDTO item in precursorActivitys)
				{
					nextActivitys = new ActivityService().GetNextActivitys(item.ACTIVITY_ID, rules, handleResult);
				}
			}
			else
			{
				nextActivitys = new ActivityService().GetNextActivitys(currentActivity.ACTIVITY_ID, rules, handleResult);
			}
		}
		return nextActivitys;
	}

	/// <summary>
	/// 生成工作项
	/// </summary>
	private WF_WORKITEM GenerateWorkItem(WF_INSTANCE currentInstance, WF_WORKITEM currentWorkItem, WF_ACTIVITYDTO currentActivity, WF_ACTIVITYDTO nextActivity, User senderUser, List<User> toUsers, HANDLE_RESULT handle_Result)
	{
		WF_WORKITEM workItem = new WF_WORKITEM();
		workItem.WORKITEM_ID = Guid.NewGuid();
		workItem.ACTIVITY_ID = nextActivity.ACTIVITY_ID;
		workItem.INSTANCE_ID = currentWorkItem.INSTANCE_ID;
		workItem.WORKITEM_NAME = nextActivity.ACTIVITY_NAME;
		if (handle_Result == HANDLE_RESULT.Circulate)
		{
			workItem.WORKITEM_NAME += "传阅";
		}
		workItem.SENDER_USER_ID = senderUser.CURRENT_USER_ID;
		workItem.SENDER_USER_NAME = senderUser.CURRENT_USER_NAME;
		workItem.SEND_TIME = (dt = dt.AddSeconds(1.0));
		switch ((ACTIVITY_TYPE)(int)currentActivity.ACTIVITY_TYPE.Value)
		{
		case ACTIVITY_TYPE.Approval:
			switch (handle_Result)
			{
			case HANDLE_RESULT.Return:
				workItem.SEND_TOKEN = currentInstance.WF_WORKITEM.OrderByDescending((WF_WORKITEM a) => a.SEND_TIME).First((WF_WORKITEM a) => a.ACTIVITY_ID == nextActivity.ACTIVITY_ID).SEND_TOKEN;
				break;
			case HANDLE_RESULT.Adopt:
				if (!string.IsNullOrWhiteSpace(currentWorkItem.SEND_TOKEN))
				{
					workItem.SEND_TOKEN = currentWorkItem.SEND_TOKEN;
				}
				break;
			}
			break;
		case ACTIVITY_TYPE.Branching:
			if (!string.IsNullOrWhiteSpace(currentWorkItem.SEND_TOKEN))
			{
				workItem.SEND_TOKEN = string.Concat(currentWorkItem.SEND_TOKEN, "|", currentWorkItem.WORKITEM_ID, "_", currentActivity.ACTIVITY_ID);
			}
			else
			{
				workItem.SEND_TOKEN = string.Concat(currentWorkItem.WORKITEM_ID, "_", currentActivity.ACTIVITY_ID);
			}
			break;
		case ACTIVITY_TYPE.Merging:
			if (!string.IsNullOrWhiteSpace(currentWorkItem.SEND_TOKEN) && currentWorkItem.SEND_TOKEN.LastIndexOf("|") > 0)
			{
				workItem.SEND_TOKEN = currentWorkItem.SEND_TOKEN.Remove(currentWorkItem.SEND_TOKEN.LastIndexOf("|"), currentWorkItem.SEND_TOKEN.Length - currentWorkItem.SEND_TOKEN.LastIndexOf("|") - 1);
			}
			break;
		}
		workItem.PARENT_WORKITEM_ID = currentWorkItem.WORKITEM_ID;
		workItem.WORKITEM_RUN_STATE = 0m;
		workItem.GENERATE_TYPE = (int)handle_Result;
		workItem.HANDLE_RESULT = 0m;
		workItem.CREATOR = senderUser.CURRENT_USER_ID;
		workItem.CREATETIME = DateTime.Now;
		workItem.MODIFIER = senderUser.CURRENT_USER_ID;
		workItem.MODIFYTIME = DateTime.Now;
		GenerateWorkItemHandler(currentInstance, ref workItem, currentWorkItem.WORKITEM_ID, currentActivity, nextActivity, senderUser, toUsers);
		return workItem;
	}

	private void GenerateWorkItemHandler(WF_INSTANCE currentInstance, ref WF_WORKITEM workItem, Guid currentWorkItemId, WF_ACTIVITYDTO currentActivity, WF_ACTIVITYDTO nextActivity, User senderUser, List<User> toUsers)
	{
		decimal? enableSignature = 0m;
		if (nextActivity != null)
		{
			enableSignature = Bit.pro((long)nextActivity.STATUS.Value, "8|2");
		}
		List<MSG_CENTER_USERDTO> msuser = new List<MSG_CENTER_USERDTO>();
		List<string> userIds = new List<string>();
		foreach (User user in toUsers)
		{
			WF_WORKITEM_HANDLER handler = new WF_WORKITEM_HANDLER();
			handler.WORKITEM_HANDLER_ID = Guid.NewGuid();
			handler.WORKITEM_ID = currentWorkItemId;
			handler.HANDLE_RESULT = 0m;
			handler.USER_ID = user.CURRENT_USER_ID;
			handler.USER_NAME = user.CURRENT_USER_NAME;
			handler.HANDLE_RESULT = 0m;
			handler.SIGNATURE_MODE = enableSignature;
			handler.ISDEL = 0m;
			handler.CREATOR = senderUser.CURRENT_USER_ID;
			handler.CREATETIME = DateTime.Now;
			handler.MODIFIER = senderUser.CURRENT_USER_ID;
			handler.MODIFYTIME = DateTime.Now;
			workItem.WF_WORKITEM_HANDLER.Add(handler);
			msuser.Add(new MSG_CENTER_USERDTO
			{
				ISREAD = 0m,
				USER_ID = user.CURRENT_USER_ID,
				USER_NAME = user.CURRENT_USER_NAME,
				ISIM = 0m,
				SORT = 0m
			});
			userIds.Add(user.CURRENT_USER_ID.ToString().ToLower().Replace("-", "") + ConfigurationManager.System.Settings.GetSetting<string>("environment"));
		}
		if (nextActivity != null)
		{
			decimal? aCTIVITY_TYPE = nextActivity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() != 3m) && aCTIVITY_TYPE.HasValue)
			{
				return;
			}
			aCTIVITY_TYPE = nextActivity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() != 4m) && aCTIVITY_TYPE.HasValue)
			{
				return;
			}
			aCTIVITY_TYPE = nextActivity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() != 6m) && aCTIVITY_TYPE.HasValue)
			{
				return;
			}
		}
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		MessageCenterService.AddMessage(new MSG_CENTERDTO
		{
			SEND_USER_ID = senderUser.CURRENT_USER_ID,
			MSG_TITLE = currentInstance.INSTANCE_NAME,
			SEND_TIME = DateTime.Now,
			SEND_USER_NAME = senderUser.CURRENT_USER_NAME,
			SEND_ORG_ID = senderUser.CURRENT_ORG_ID,
			SEND_ORG_NAME = senderUser.CURRENT_ORG_NAME,
			MSG_TYPE = 1m,
			MSG_OPEN_TYPE = 2m,
			MSG_BUSINESS_ID = workItem.INSTANCE_ID,
			MSG_CENTER_USER = msuser.ToList()
		});
		Dictionary<string, string> customizedValues = new Dictionary<string, string>();
		customizedValues.Add("bcode", "1");
		customizedValues.Add("bid", workItem.WORKITEM_ID.ToString());
		List<string> userId = new List<string>(userIds);
	}

	/// <summary>
	/// 完成工作项
	/// </summary>
	private void FinishWorkItem(WF_WORKITEM currentWorkItem, User user, HANDLE_RESULT handleResult, string handleSuggestion, bool fnishWorkItem)
	{
		if (currentWorkItem == null)
		{
			throw new CustomCodeException("工作项不能为null");
		}
		if (fnishWorkItem)
		{
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			currentWorkItem.HANDLE_RESULT = (int)handleResult;
		}
		if (currentWorkItem.WF_WORKITEM_HANDLER == null || currentWorkItem.WF_WORKITEM_HANDLER.Count <= 0)
		{
			return;
		}
		foreach (WF_WORKITEM_HANDLER handler in currentWorkItem.WF_WORKITEM_HANDLER)
		{
			Guid uSER_ID = handler.USER_ID;
			Guid? pROXY_USER_ID = user.PROXY_USER_ID;
			if (uSER_ID == pROXY_USER_ID)
			{
				handler.HANDLE_USER_ID = user.CURRENT_USER_ID;
				handler.HANDLE_USER_NAME = user.CURRENT_USER_NAME;
				handler.HANDLE_RESULT = (int)handleResult;
				handler.HANDLE_SUGGESTION = handleSuggestion;
				handler.HANDLE_TIME = DateTime.Now;
				if (!fnishWorkItem)
				{
					break;
				}
			}
			else if (fnishWorkItem && handleResult != HANDLE_RESULT.Suspended && handleResult != HANDLE_RESULT.Terminated)
			{
				decimal? hANDLE_RESULT = handler.HANDLE_RESULT;
				if (hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue)
				{
					handler.HANDLE_RESULT = 16384m;
				}
			}
		}
	}

	/// <summary>
	/// 判断是否可以生成工作项
	/// </summary>
	private bool EnableGenerateWorkItem(WF_INSTANCE currentInstance, WF_ACTIVITYDTO activity)
	{
		WF_WORKITEM branchingWorkItem = currentInstance.WF_WORKITEM.FirstOrDefault(delegate(WF_WORKITEM a)
		{
			Guid aCTIVITY_ID = a.ACTIVITY_ID;
			Guid? bRANCH_ACTIVITY_ID = activity.BRANCH_ACTIVITY_ID;
			int result3;
			if (aCTIVITY_ID == bRANCH_ACTIVITY_ID)
			{
				decimal? wORKITEM_RUN_STATE3 = a.WORKITEM_RUN_STATE;
				if (!(wORKITEM_RUN_STATE3.GetValueOrDefault() == 2m) || !wORKITEM_RUN_STATE3.HasValue)
				{
					wORKITEM_RUN_STATE3 = a.WORKITEM_RUN_STATE;
					result3 = ((wORKITEM_RUN_STATE3.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE3.HasValue) ? 1 : 0);
				}
				else
				{
					result3 = 1;
				}
			}
			else
			{
				result3 = 0;
			}
			return (byte)result3 != 0;
		});
		decimal branchingCount = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
		{
			int result2;
			if (a.PARENT_WORKITEM_ID == branchingWorkItem.WORKITEM_ID)
			{
				decimal? wORKITEM_RUN_STATE2 = a.WORKITEM_RUN_STATE;
				if (!(wORKITEM_RUN_STATE2.GetValueOrDefault() == 2m) || !wORKITEM_RUN_STATE2.HasValue)
				{
					wORKITEM_RUN_STATE2 = a.WORKITEM_RUN_STATE;
					result2 = ((wORKITEM_RUN_STATE2.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE2.HasValue) ? 1 : 0);
				}
				else
				{
					result2 = 1;
				}
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		}).Count();
		IList<WF_RULEDTO> rule = WorkflowCacheManager.GetRuleByTemplateId(currentInstance.TEMPLATE_ID.Value);
		IEnumerable<Guid> fromActivityId = from t1 in rule
			where t1.TO_ACTIVITY_ID == activity.ACTIVITY_ID
			select t1.FROM_ACTIVITY_ID;
		decimal mergingCount = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
		{
			int result;
			if (fromActivityId.Contains(a.ACTIVITY_ID))
			{
				decimal? wORKITEM_RUN_STATE = a.WORKITEM_RUN_STATE;
				result = ((wORKITEM_RUN_STATE.GetValueOrDefault() == 2m && wORKITEM_RUN_STATE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Count();
		switch ((FINISH_TYPE)Bit.pro((long)activity.STATUS.Value, "24|2"))
		{
		case FINISH_TYPE.Single:
			return true;
		case FINISH_TYPE.All:
			return branchingCount == mergingCount;
		case FINISH_TYPE.Percent:
		{
			decimal? fINISH_NUMBER = activity.FINISH_NUMBER;
			decimal num = mergingCount / branchingCount * 100m;
			return fINISH_NUMBER.GetValueOrDefault() <= num && fINISH_NUMBER.HasValue;
		}
		case FINISH_TYPE.Quantity:
		{
			decimal? fINISH_NUMBER = activity.FINISH_NUMBER;
			decimal num = mergingCount;
			return fINISH_NUMBER.GetValueOrDefault() <= num && fINISH_NUMBER.HasValue;
		}
		default:
			return true;
		}
	}

	/// <summary>
	/// 获取某个节点处理人
	/// </summary>
	private List<User> GetUserByActivityId(WF_INSTANCE currentInstance, Guid activityId)
	{
		List<User> handler = new List<User>();
		IEnumerable<WF_WORKITEM_HANDLER> userCollection = currentInstance.WF_WORKITEM.First(delegate(WF_WORKITEM a)
		{
			int result2;
			if (a.ACTIVITY_ID == activityId)
			{
				decimal? wORKITEM_RUN_STATE = a.WORKITEM_RUN_STATE;
				result2 = ((wORKITEM_RUN_STATE.GetValueOrDefault() == 2m && wORKITEM_RUN_STATE.HasValue) ? 1 : 0);
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		}).WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			int result;
			if (!(hANDLE_RESULT.GetValueOrDefault() == 2m) || !hANDLE_RESULT.HasValue)
			{
				hANDLE_RESULT = a.HANDLE_RESULT;
				result = ((hANDLE_RESULT.GetValueOrDefault() == 1024m && hANDLE_RESULT.HasValue) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		});
		foreach (WF_WORKITEM_HANDLER item in userCollection)
		{
			try
			{
				handler.Add(new User
				{
					CURRENT_USER_ID = item.HANDLE_USER_ID.Value,
					CURRENT_USER_NAME = item.HANDLE_USER_NAME,
					PROXY_USER_ID = item.HANDLE_USER_ID,
					PROXY_USER_NAME = item.HANDLE_USER_NAME
				});
			}
			catch
			{
			}
		}
		return handler;
	}

	/// <summary>
	/// 取回、退回等标记工作项状态
	/// </summary>
	private void RemarkWorkItem(WF_INSTANCE currentInstance, WF_ACTIVITYDTO nextActivity, WF_WORKITEM currentWorkItem, HANDLE_RESULT handleResult)
	{
		WF_TEMPLATEDTO currentTemplate = WorkflowCacheManager.GetTemplateById(currentInstance.TEMPLATE_ID.Value);
		IDictionary<Guid, Guid> pathClass = new Dictionary<Guid, Guid>();
		currentWorkItem.HANDLE_RESULT = (int)handleResult;
		currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
		pathClass.Add(nextActivity.ACTIVITY_ID, nextActivity.ACTIVITY_ID);
		GeneratePath(currentTemplate, currentWorkItem.ACTIVITY_ID, nextActivity.ACTIVITY_ID, ref pathClass);
		MarkItem(currentInstance, pathClass, handleResult);
	}

	/// <summary>
	/// 标记状态
	/// </summary>
	private void MarkItem(WF_INSTANCE currentInstance, IDictionary<Guid, Guid> paths, HANDLE_RESULT handleResult)
	{
		foreach (KeyValuePair<Guid, Guid> activityId in paths)
		{
			ICollection<WF_WORKITEM> wF_WORKITEM = currentInstance.WF_WORKITEM;
			Func<WF_WORKITEM, bool> predicate = delegate(WF_WORKITEM a)
			{
				Guid aCTIVITY_ID = a.ACTIVITY_ID;
				KeyValuePair<Guid, Guid> keyValuePair = activityId;
				return aCTIVITY_ID == keyValuePair.Key && a.ISDEL == 0m;
			};
			IEnumerable<WF_WORKITEM> query = wF_WORKITEM.Where(predicate);
			if (query.Count() <= 0)
			{
				continue;
			}
			foreach (WF_WORKITEM item in query)
			{
				MarkItem(item, handleResult);
			}
		}
	}

	/// <summary>
	/// 标记状态
	/// </summary>
	private void MarkItem(WF_WORKITEM workItem, HANDLE_RESULT handleResult)
	{
		decimal? wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 2048m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 1024m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.HANDLE_RESULT;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 16384m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE.HasValue)
		{
			workItem.HANDLE_RESULT = 16384m;
			foreach (WF_WORKITEM_HANDLER item in workItem.WF_WORKITEM_HANDLER)
			{
				item.HANDLE_RESULT = 16384m;
			}
		}
		else
		{
			workItem.HANDLE_RESULT = (int)handleResult;
		}
		workItem.WORKITEM_RUN_STATE = (int)handleResult;
	}

	private void GeneratePath(WF_TEMPLATEDTO currentTemplate, Guid activityId, Guid currentActivityId, ref IDictionary<Guid, Guid> path)
	{
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result;
			if (a.FROM_ACTIVITY_ID == currentActivityId && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		if (query.Count() <= 0)
		{
			return;
		}
		IList<WF_RULEDTO> rules = query.ToList();
		foreach (WF_RULEDTO rule in rules)
		{
			if (!path.ContainsKey(rule.TO_ACTIVITY_ID))
			{
				path.Add(rule.TO_ACTIVITY_ID, rule.TO_ACTIVITY_ID);
				if (rule.TO_ACTIVITY_ID != activityId)
				{
					GeneratePath(currentTemplate, activityId, rule.TO_ACTIVITY_ID, ref path);
				}
			}
		}
	}

	/// <summary>
	/// 流程调整
	/// </summary>
	/// <param name="workItemId">工作项</param>
	/// <param name="handleUserCollection">处理人</param>
	public WF_INSTANCE Adjust(Guid workItemId, List<User> handleUserCollection)
	{
		IRepository<WF_WORKITEM> repository1 = ServiceLocator.Instance.GetService<IRepository<WF_WORKITEM>>();
		WF_WORKITEM workItem = repository1.GetByKey(workItemId);
		foreach (WF_WORKITEM_HANDLER item2 in workItem.WF_WORKITEM_HANDLER)
		{
			decimal? hANDLE_RESULT = item2.HANDLE_RESULT;
			if (hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue)
			{
				item2.ISDEL = 1m;
			}
		}
		handleUserCollection.ForEach(delegate(User x)
		{
			WF_WORKITEM_HANDLER item3 = new WF_WORKITEM_HANDLER
			{
				INSTANCE_ID = workItem.INSTANCE_ID,
				WORKITEM_HANDLER_ID = Guid.NewGuid(),
				WORKITEM_ID = workItemId,
				USER_ID = x.CURRENT_USER_ID,
				USER_NAME = x.CURRENT_USER_NAME,
				CLIENT_TYPE = 0m,
				HANDLE_RESULT = 0m
			};
			workItem.WF_WORKITEM_HANDLER.Add(item3);
		});
		repository1.UpdateCommit(workItem, "WF_WORKITEM", "WF_WORKITEM_HANDLER");
		WF_INSTANCE instance = repository.GetByKey(workItem.INSTANCE_ID);
		IEnumerable<WF_WORKITEM> cur_WI = instance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
		{
			decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
			return hANDLE_RESULT2.GetValueOrDefault() == 0m && hANDLE_RESULT2.HasValue;
		});
		string currentActivityName = "";
		string currentHandlerId = "";
		string currentHandlerName = "";
		if (cur_WI.Any())
		{
			foreach (WF_WORKITEM item in cur_WI)
			{
				foreach (WF_WORKITEM_HANDLER h in item.WF_WORKITEM_HANDLER)
				{
					decimal? hANDLE_RESULT = h.HANDLE_RESULT;
					if (hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue)
					{
						currentHandlerId = string.Concat(currentHandlerId, h.USER_ID, ",");
						currentHandlerName = currentHandlerName + h.USER_NAME + ",";
					}
				}
			}
		}
		repository.UpdateCommit(instance);
		return GetInstanceById(workItem.INSTANCE_ID);
	}

	public void GetBackActivity(Guid instanceId, Guid activityId, Guid? userId, int type, ref List<NEXT_ACTIVITY> backactivitys)
	{
		ActivityService activityService = new ActivityService();
		WF_INSTANCE cur_Instance = GetInstanceById(instanceId);
		WF_ACTIVITYDTO cur_activity = activityService.GetActivityById(activityId);
		if (cur_activity == null)
		{
			return;
		}
		decimal? aCTIVITY_TYPE = cur_activity.ACTIVITY_TYPE;
		if (aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue)
		{
			return;
		}
		List<WF_RULEDTO> p_rules = activityService.GetRuleByToActivityId(cur_activity.ACTIVITY_ID).Where(delegate(WF_RULEDTO a)
		{
			decimal? rULE_TYPE = a.RULE_TYPE;
			return rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue;
		}).ToList();
		foreach (WF_RULEDTO p_rule in p_rules)
		{
			WF_ACTIVITYDTO p_activity = activityService.GetActivityById(p_rule.FROM_ACTIVITY_ID);
			aCTIVITY_TYPE = p_activity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == -1m) || !aCTIVITY_TYPE.HasValue)
			{
				aCTIVITY_TYPE = p_activity.ACTIVITY_TYPE;
				if (!(aCTIVITY_TYPE.GetValueOrDefault() == 0m) || !aCTIVITY_TYPE.HasValue)
				{
					GetBackActivity(instanceId, p_activity.ACTIVITY_ID, userId, type, ref backactivitys);
					continue;
				}
			}
			List<WF_WORKITEM> p_WorkItems = (from a in cur_Instance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
				{
					int result;
					if (a.ACTIVITY_ID == p_activity.ACTIVITY_ID)
					{
						decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
						result = ((hANDLE_RESULT2.GetValueOrDefault() == 2m && hANDLE_RESULT2.HasValue) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				})
				orderby a.CREATETIME descending
				select a).ToList();
			if (p_WorkItems.Count <= 0)
			{
				continue;
			}
			WF_WORKITEM p_WorkItem = p_WorkItems[0];
			bool flag = false;
			IEnumerable<WF_WORKITEM_HANDLER> p_handlers = p_WorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
			{
				decimal? hANDLE_RESULT = a.HANDLE_RESULT;
				return hANDLE_RESULT.GetValueOrDefault() == 2m && hANDLE_RESULT.HasValue;
			});
			if (type == 1)
			{
				if (p_handlers.Where((WF_WORKITEM_HANDLER a) => a.HANDLE_USER_ID == userId).Count() > 0)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				break;
			}
			NEXT_ACTIVITY backactivity = new NEXT_ACTIVITY();
			backactivity.ACTIVITY = p_activity;
			backactivity.USER_IDS = new List<User>();
			foreach (WF_WORKITEM_HANDLER p_handler in p_handlers)
			{
				backactivity.USER_IDS.Add(new User
				{
					CURRENT_USER_ID = p_handler.HANDLE_USER_ID.Value,
					CURRENT_USER_NAME = p_handler.HANDLE_USER_NAME,
					PROXY_USER_ID = p_handler.HANDLE_USER_ID,
					PROXY_USER_NAME = p_handler.HANDLE_USER_NAME
				});
			}
			backactivitys.Add(backactivity);
			break;
		}
	}
}
