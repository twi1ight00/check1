using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Migration;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

/// <summary>
/// 工作流服务 
/// </summary>
public class WorkflowService : ServiceBase, IWorkflowService
{
	private readonly IRepository<WF_INSTANCE> repositoryInstance = null;

	private IRunWorkflow runWorkflow;

	public WorkflowService()
	{
		repositoryInstance = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE>>();
	}

	/// <summary>
	/// 创建流程
	/// </summary>
	/// <param name="user">用户DTO</param>
	/// <param name="instanceId">当前实例ID</param>
	/// <param name="templateId"></param>
	/// <param name="formId"></param>
	/// <param name="instanceTitle">实例名称</param>
	/// <param name="instanceTableName">实例表名称</param>
	/// <param name="parentInstanceId">父模板ID</param>
	/// <param name="parentActivityId">父活动id</param>
	/// <returns>工作项ID</returns>
	public WF_INSTANCE CreateWorkflow(WF_INSTANCE instance, SubmitDTO submitDto)
	{
		return new InstanceService_v2().CreateWorkflow(instance, submitDto);
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
	/// <param name="customNext">自定义活动</param>
	/// <returns>提交结果</returns>
	public WF_INSTANCE Submit(SubmitDTO dto)
	{
		return new InstanceService_v2().Submit(dto);
	}

	/// <summary>
	/// 重置已完成流程
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <param name="user">用户ID</param>
	/// <returns></returns>
	public void ResetWorkflow(Guid instanceId, User user)
	{
		new InstanceService().ResetWorkflow(instanceId, user);
	}

	/// <summary>
	/// 流程调整
	/// </summary>
	/// <param name="workItemId">调整工作项的ID</param>
	/// <param name="users">调整至的人</param>
	public WF_INSTANCE Adjust(Guid workItemId, List<User> users)
	{
		return new InstanceService().Adjust(workItemId, users);
	}

	/// <summary>
	/// 更新实例名称
	/// </summary>
	/// <param name="instanceId"></param>
	/// <param name="instanceName"></param>
	public void UpdateInstanceName(Guid instanceId, string instanceName)
	{
		new InstanceService().UpdateInstanceName(instanceId, instanceName);
	}

	/// <summary>
	/// 删除流程
	/// </summary>
	/// <param name="instanceIds">要删除的实例ID</param>
	public void DeleteInstance(string instanceIds)
	{
		new InstanceService().DeleteInstance(instanceIds);
	}

	/// <summary>
	/// 根据ID获取一个活动（缓存）
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <returns>活动DTO</returns>
	public WF_ACTIVITYDTO GetActivityById(Guid activityId)
	{
		return WorkflowCacheManager.GetActivityById(activityId);
	}

	/// <summary>
	/// 获取开始活动
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <returns>开始活动</returns>
	public WF_ACTIVITYDTO GetStartActivity(Guid templateId)
	{
		return new ActivityService().GetStartActivity(templateId);
	}

	/// <summary>
	/// 获取退回步骤
	/// </summary>
	/// <param name="activityId"></param>
	/// <returns></returns>
	public List<WF_ACTIVITYDTO> GetGoBackNextActivity(Guid activityId)
	{
		return new ActivityService().GetNextActivitys(activityId, string.Empty, HANDLE_RESULT.Return);
	}

	/// <summary>
	/// 根据规则，获取某个活动的后继规则表达式
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <param name="rules">规则，格式为state:1|money:500</param>
	/// <returns></returns>
	public List<NEXT_ACTIVITY> GetPostActivitys(Guid activityId, string rules)
	{
		ActivityService activityService = new ActivityService();
		List<NEXT_ACTIVITY> postActivitys = new List<NEXT_ACTIVITY>();
		WF_ACTIVITYDTO currentActivity = WorkflowCacheManager.GetActivityById(activityId);
		decimal? aCTIVITY_TYPE = currentActivity.ACTIVITY_TYPE;
		if (aCTIVITY_TYPE.GetValueOrDefault() == 1m && aCTIVITY_TYPE.HasValue)
		{
			currentActivity = activityService.GetPrecursorActivitys(activityId)[0];
		}
		List<WF_ACTIVITYDTO> nextcollection = new ActivityService().GetNextActivitys(currentActivity.ACTIVITY_ID, rules);
		get(postActivitys, currentActivity, nextcollection, rules);
		return postActivitys;
	}

	private void get(List<NEXT_ACTIVITY> postActivitys, WF_ACTIVITYDTO currentActivity, List<WF_ACTIVITYDTO> nextActivity, string rules)
	{
		foreach (WF_ACTIVITYDTO item in nextActivity)
		{
			NEXT_ACTIVITY next = new NEXT_ACTIVITY();
			next.ACTIVITY = item;
			next.PARENT_ACTIVITY = currentActivity;
			postActivitys.Add(next);
			decimal? aCTIVITY_TYPE = item.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == 3m) || !aCTIVITY_TYPE.HasValue)
			{
				aCTIVITY_TYPE = item.ACTIVITY_TYPE;
				if (!(aCTIVITY_TYPE.GetValueOrDefault() == 6m) || !aCTIVITY_TYPE.HasValue)
				{
					continue;
				}
			}
			List<WF_ACTIVITYDTO> nexts = new ActivityService().GetNextActivitys(item.ACTIVITY_ID, rules);
			get(postActivitys, item, nexts, rules);
		}
	}

	/// <summary>
	/// 获取所有步骤
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="orgId"></param>
	/// <param name="rules"></param>
	/// <param name="instanceId"></param>
	/// <param name="activityId"></param>
	/// <returns></returns>
	public List<WF_ACTIVITYDTO> GetAllActivitys(Guid templateId, Guid orgId, string rules, Guid instanceId, List<WF_ACTIVITYDTO> activitys)
	{
		List<WF_ACTIVITYDTO> nextActivitys = new ActivityService().GetAllActivitys(templateId, rules, activitys);
		List<SYS_USERDTO> users = new ParticipantService().GetTemplateActivityParticipantOnlyUser(templateId, orgId);
		foreach (WF_ACTIVITYDTO nextActivity in nextActivitys)
		{
			nextActivity.HANDLERUSER = GetActivityParticipantOnlyUser(users, nextActivity.ACTIVITY_ID, orgId, instanceId);
		}
		return nextActivitys;
	}

	/// <summary>
	/// 获取流程处理参与人（仅仅人）
	/// </summary>
	/// <returns></returns>
	public List<User> GetActivityParticipantOnlyUser(List<SYS_USERDTO> sysusers, Guid activityId, Guid orgId, Guid? instanceId, string submitType = "0")
	{
		ActivityService activityService = new ActivityService();
		List<Guid> normalRoleIds = new List<Guid>();
		List<Guid> globalRoleIds = new List<Guid>();
		List<Guid> activitys = new List<Guid>();
		List<SYS_USERDTO> userDTO = new List<SYS_USERDTO>();
		if (submitType == "1")
		{
			activitys.Add(activityId);
		}
		else
		{
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
		QueryCondition queryCondition = new QueryCondition();
		if (normalRoleIds.Count > 0 || globalRoleIds.Count > 0)
		{
			foreach (Guid normalRoleId in normalRoleIds)
			{
				Func<SYS_USERDTO, bool> predicate = (SYS_USERDTO a) => a.ORG_ID == orgId && a.ROLE_ID == normalRoleId;
				userDTO.AddRange(sysusers.Where(predicate).ToList());
			}
			foreach (Guid globalRoleId in globalRoleIds)
			{
				Func<SYS_USERDTO, bool> predicate2 = (SYS_USERDTO a) => !a.ORG_ID.HasValue && a.ROLE_ID == globalRoleId;
				userDTO.AddRange(sysusers.Where(predicate2).ToList());
			}
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
		List<User> users = new List<User>();
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
	/// 增加模板
	/// </summary>
	/// <param name="templateDTO">新增DTO</param>
	/// <returns></returns>
	public void AddTemplate(WF_TEMPLATEDTO templateDTO)
	{
		new TemplateService().AddTemplate(templateDTO);
	}

	public WF_TEMPLATEDTO SaveTemplate(WF_TEMPLATEDTO templateDTO)
	{
		return new TemplateService().SaveTemplate(templateDTO);
	}

	/// <summary>
	/// 更新模板
	/// </summary>
	/// <param name="templateDTO">更新DTO</param>
	/// <returns></returns>
	public void UpdateTemplate(WF_TEMPLATEDTO templateDTO)
	{
		new TemplateService().UpdateTemplate(templateDTO);
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	public WF_TEMPLATEDTO GetTemplateById(Guid templateId)
	{
		return new TemplateService().GetTemplateById(templateId).AdaptAsDTO<WF_TEMPLATEDTO>();
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="templateFormId">模板表单ID</param>
	/// <returns></returns>
	public WF_TEMPLATEDTO GetTemplateByTemplateFormID(Guid templateFormId)
	{
		return new TemplateService().GetTemplateByTemplateFormID(templateFormId);
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <param name="parameter">查询模板</param>
	/// <returns></returns>
	public QueryResult<WF_TEMPLATEDTO> GetTemplateByParameter(TemplateParameter parameter)
	{
		if (parameter.IsNull())
		{
			return new QueryResult<WF_TEMPLATEDTO>();
		}
		return new TemplateService().GetTemplateByQueryCondition(parameter.ToQueryCondition());
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="url"></param>
	/// <returns></returns>
	public IList<WF_TEMPLATE_FORMDTO> GetTemplateFormByUrl(string url)
	{
		return new TemplateService().GetTemplateFormByUrl(url);
	}

	/// <summary>
	/// 获取互斥步骤
	/// </summary>
	/// <param name="instanceId">流程实例ID</param>
	/// <param name="activityId">当前工作项对应的节点ID</param>
	/// <returns></returns>
	public List<ReturnConstraintActivitys> GetReturnConstraintActivitys(Guid instanceId, Guid activityId)
	{
		List<ReturnConstraintActivitys> returnConstraintActivitys = new List<ReturnConstraintActivitys>();
		Dictionary<WF_ACTIVITYDTO, List<WF_ACTIVITYDTO>> returnActivitys = new ActivityService().GetReturnConstraintActivitys(instanceId, activityId);
		foreach (KeyValuePair<WF_ACTIVITYDTO, List<WF_ACTIVITYDTO>> returnActivity in returnActivitys)
		{
			ReturnConstraintActivitys returnConstraintActivity = new ReturnConstraintActivitys();
			returnConstraintActivity.Activity = returnActivity.Key;
			returnConstraintActivity.ConstraintActivitys = returnActivity.Value;
			returnConstraintActivitys.Add(returnConstraintActivity);
		}
		return returnConstraintActivitys;
	}

	/// <summary>
	/// 获取指定用户参与的流程集合
	/// </summary>
	/// <param name="userId"></param>
	/// <returns></returns>
	public List<WF_TEMPLATEDTO> GetTemplateByUserId(Guid userId)
	{
		List<WF_TEMPLATEDTO> templates = null;
		List<TREE_NODE> nodes = new ParticipantService().getParticipaintByUser(userId);
		string roleIds = string.Empty;
		foreach (TREE_NODE item in nodes)
		{
			if (item.IS_CHECK == 1m)
			{
				roleIds = roleIds + Utility.GetGuidString(item.ID) + ",";
			}
		}
		if (roleIds.Length > 0)
		{
			roleIds = roleIds.Remove(roleIds.Length - 1);
		}
		if (!string.IsNullOrWhiteSpace(roleIds))
		{
			templates = SqlQuery<WF_TEMPLATEDTO>("GetTemplateByUserId", null, null, null, new string[1] { roleIds }).List.ToList();
		}
		return templates;
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	public List<WF_TEMPLATEDTO> GetTemplateNameAndVersions()
	{
		return new TemplateService().GetTemplateNameAndVersions();
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="version_id"></param>
	/// <param name="form_id"></param>
	/// <returns></returns>
	public List<WF_FORMDTO> GetTemplateForms(Guid? version_id, Guid? form_id)
	{
		return new FormService().GetTemplateForms(version_id, form_id);
	}

	public List<WF_TEMPLATEDTO> GetTemplateByPackage(WF_TEMPLATEDTO dto)
	{
		return new TemplateService().GetTemplateByPackage(dto);
	}

	public List<WF_TEMPLATEDTO> GetActiveTemplateByPackageid(WF_TEMPLATEDTO dto)
	{
		return new TemplateService().GetActiveTemplateByPackageid(dto);
	}

	public IList<Driver> GetBackDrivers(WF_TEMPLATEDTO template, WF_ACTIVITYDTO activity)
	{
		IEnumerable<WF_RULEDTO> nextRules = template.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result;
			if (a.FROM_ACTIVITY_ID == activity.ACTIVITY_ID && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 1m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		IList<Driver> drivers = new List<Driver>();
		foreach (WF_RULEDTO rule in nextRules)
		{
			Driver driver = new Driver();
			driver.RuleId = rule.RULE_ID;
			drivers.Add(driver);
		}
		return drivers;
	}

	public IList<Driver> GetNextDrivers(WF_TEMPLATEDTO template, WF_ACTIVITYDTO activity, string ruleExpress = null)
	{
		Dictionary<string, string> rules = null;
		if (!string.IsNullOrEmpty(ruleExpress))
		{
			rules = ruleExpress.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		}
		if (rules != null)
		{
			rules = rules.OrderByDescending((KeyValuePair<string, string> p) => p.Key.Length).ToDictionary((KeyValuePair<string, string> p) => p.Key, (KeyValuePair<string, string> o) => o.Value);
		}
		IEnumerable<WF_RULEDTO> nextRules = template.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result;
			if (a.FROM_ACTIVITY_ID == activity.ACTIVITY_ID && a.ISDEL == 0m)
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
		IList<Driver> drivers = new List<Driver>();
		foreach (WF_RULEDTO rule in nextRules)
		{
			Driver driver = new Driver();
			driver.RuleId = rule.RULE_ID;
			driver.ActivityType = (int)activity.ACTIVITY_TYPE.Value;
			drivers.Add(driver);
			GetDrivers(template, driver, rule, rules);
		}
		return drivers;
	}

	private void GetDrivers(WF_TEMPLATEDTO template, Driver driver, WF_RULEDTO ruleDto, Dictionary<string, string> rules = null)
	{
		WF_ACTIVITYDTO ac = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO A) => A.ACTIVITY_ID == ruleDto.TO_ACTIVITY_ID);
		int activityType = (int)ac.ACTIVITY_TYPE.Value;
		Driver next = new Driver();
		next.RuleId = ruleDto.RULE_ID;
		next.ActivityType = activityType;
		if (!canRun(ruleDto, rules))
		{
			return;
		}
		driver.Next.Add(next);
		switch (activityType)
		{
		case 6:
		{
			List<WF_RULEDTO> nextRules = template.WF_RULE.Where(delegate(WF_RULEDTO a)
			{
				int result;
				if (a.FROM_ACTIVITY_ID == ac.ACTIVITY_ID && a.ISDEL == 0m)
				{
					decimal? rULE_TYPE = a.RULE_TYPE;
					result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).ToList();
			{
				foreach (WF_RULEDTO wfRule in nextRules)
				{
					GetDrivers(template, next, wfRule, rules);
				}
				break;
			}
		}
		case 3:
		{
			List<WF_RULEDTO> nextRules = template.WF_RULE.Where(delegate(WF_RULEDTO a)
			{
				int result2;
				if (a.FROM_ACTIVITY_ID == ac.ACTIVITY_ID && a.ISDEL == 0m)
				{
					decimal? rULE_TYPE2 = a.RULE_TYPE;
					result2 = ((rULE_TYPE2.GetValueOrDefault() == 0m && rULE_TYPE2.HasValue) ? 1 : 0);
				}
				else
				{
					result2 = 0;
				}
				return (byte)result2 != 0;
			}).ToList();
			{
				foreach (WF_RULEDTO wfRule in nextRules)
				{
					GetDrivers(template, next, wfRule, rules);
				}
				break;
			}
		}
		}
	}

	private void addDriver(WF_TEMPLATEDTO template, IList<WF_RULEDTO> nextRules, Driver driver, int activityType, Dictionary<string, string> rules = null)
	{
		foreach (WF_RULEDTO wfRule in nextRules)
		{
			if (canRun(wfRule, rules))
			{
				Driver nextDriver = new Driver();
				nextDriver.ActivityType = activityType;
				nextDriver.RuleId = wfRule.RULE_ID;
				driver.Next.Add(nextDriver);
				GetDrivers(template, nextDriver, wfRule, rules);
			}
		}
	}

	private bool canRun(WF_RULEDTO rule, Dictionary<string, string> rulesArray)
	{
		if (rulesArray == null || rulesArray.Count == 0)
		{
			return true;
		}
		string ruleContent = rule.RULE_CONDITION;
		if (string.IsNullOrEmpty(ruleContent))
		{
			return true;
		}
		ruleContent = ruleContent.Replace("\r", "").Replace("\n", "");
		foreach (KeyValuePair<string, string> keyValuePair in rulesArray)
		{
			ruleContent = ruleContent.Replace(keyValuePair.Key, keyValuePair.Value);
		}
		ruleContent = ruleContent.Replace("!=", "<>");
		try
		{
			return bool.Parse(new DataTable().Compute(ruleContent, "true").ToString());
		}
		catch
		{
			return false;
		}
	}

	/// <summary>
	/// 根据规则，获取某个活动的后继活动
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <param name="rules">规则，格式为state:1|money:500</param>
	/// <param name="handleResult">处理结果</param>
	/// <example><![CDATA[
	/// 设计器规则表达式：5000>=money and money<=10000 and state=1，前端传入规则为：state:1|money:500
	/// ]]></example>
	/// <returns></returns>
	public List<WF_ACTIVITYDTO> GetNextActivitys(Guid activityId, string rules, HANDLE_RESULT handleResult = HANDLE_RESULT.Adopt)
	{
		List<WF_RULEDTO> wfrules = WorkflowCacheManager.GetRuleByFromActivityId(activityId).Where(delegate(WF_RULEDTO a)
		{
			decimal? rULE_TYPE = a.RULE_TYPE;
			decimal num = (int)handleResult;
			return rULE_TYPE.GetValueOrDefault() == num && rULE_TYPE.HasValue && a.ISDEL == 0m;
		}).ToList();
		List<WF_ACTIVITYDTO> nextActivity = new List<WF_ACTIVITYDTO>();
		if (!string.IsNullOrEmpty(rules))
		{
			string[] rulesArray = rules.Split('|');
			bool result = false;
			foreach (WF_RULEDTO rule in wfrules)
			{
				string ruleContent = rule.RULE_CONDITION;
				if (!(result = string.IsNullOrEmpty(ruleContent)))
				{
					for (int flag = 0; flag < rulesArray.Length; flag++)
					{
						string tmp = rulesArray[flag];
						for (int i = flag + 1; i < rulesArray.Length; i++)
						{
							if (rulesArray[i].Split(':')[0].Length > tmp.Split(':')[0].Length)
							{
								rulesArray[flag] = rulesArray[i];
								rulesArray[i] = tmp;
								tmp = rulesArray[flag];
							}
						}
						ruleContent = ruleContent.Replace(rulesArray[flag].Split(':')[0], rulesArray[flag].Split(':')[1]);
					}
					try
					{
						result = bool.Parse(new DataTable().Compute(ruleContent, "true").ToString());
					}
					catch
					{
						result = false;
					}
				}
				if (result)
				{
					WF_ACTIVITYDTO activityDTO = WorkflowCacheManager.GetActivityById(rule.TO_ACTIVITY_ID);
					if (!nextActivity.Contains(activityDTO))
					{
						nextActivity.Add(activityDTO);
					}
				}
			}
		}
		else
		{
			foreach (WF_RULEDTO rule in wfrules)
			{
				WF_ACTIVITYDTO activity = WorkflowCacheManager.GetActivityById(rule.TO_ACTIVITY_ID);
				if (activity != null && !nextActivity.Contains(activity))
				{
					nextActivity.Add(activity);
				}
			}
		}
		return nextActivity;
	}

	public List<WF_TEMPLATEDTO> GetTemplateVersionList(Guid? parentTemplateId)
	{
		return new TemplateService().GetTemplateVersionList(parentTemplateId);
	}

	public bool ActiveTemplate(WF_TEMPLATEDTO template)
	{
		try
		{
			return new TemplateService().ActiveTemplate(template);
		}
		catch (Exception ex)
		{
			throw new CustomCodeException(ex.Message);
		}
	}

	public bool DeleteTemplate(WF_TEMPLATEDTO template)
	{
		try
		{
			return new TemplateService().DeleteTemplate(template);
		}
		catch (Exception ex)
		{
			throw new CustomCodeException(ex.Message);
		}
	}

	public object GetMyTemplate(string action = null)
	{
		try
		{
			return new PackageService().GetMyTemplate(action);
		}
		catch (Exception ex)
		{
			throw new CustomCodeException(ex.Message);
		}
	}

	public object WorkflowDataMigration(IList<DataMigrationDTO> list)
	{
		try
		{
			return new InstanceService_v2().WorkflowDataMigration(list);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public IDTO GetAccountDataByInstanceId(Guid instanceId, Guid? pId = null)
	{
		try
		{
			return new InstanceService_v2().GetAccountDataByInstanceId(instanceId, pId);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public void EditAccount(Guid instanceId, string formData)
	{
		try
		{
			new InstanceService_v2().EditAccount(instanceId, formData);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public QueryResult<WF_INSTANCEDTO> GetWorkflowMonitorByUser(WorkflowMonitorParameter parameter)
	{
		string action = ((parameter.SearchType == 0) ? "GetWorkflowMonitorByUser" : "GetWorkflowMonitorByUserAdvance");
		parameter.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<WF_INSTANCEDTO>(action, parameter, delegate(string sql)
		{
			if (SessionContext.UserInfo.IsSuperUser)
			{
				return sql.Replace("@ORG_ID", "");
			}
			string newValue = " INNER JOIN  (SELECT  T3.ORG_ID FROM WF_TEMPLATE_AUTHORIZATION T1 INNER JOIN  SYS_USER_ROLE T2 ON T1.ROLE_ID=T2.ROLE_ID \r\n          INNER JOIN VIEW_SYS_ORG T3 ON T2.ORG_ID=T3.ROOT_ORG_ID\r\n          WHERE T1.TEMPLATE_ID=@TEMPLATE_ID AND T2.USER_ID=@USER_ID  GROUP BY T3.ORG_ID) T4 ON T4.ORG_ID=T1.ORG_ID";
			return sql.Replace("@ORG_ID", newValue);
		});
	}

	public bool Authentication(WF_WORKITEMDTO workItem)
	{
		return new InstanceService_v2().Authentication(workItem);
	}

	public IList<WF_ACTIVITYDTO> GetFutureDriversInvoke(WF_TEMPLATEDTO template, Guid orgId, Driver driver, string ruleExpress = null)
	{
		List<WF_ACTIVITYDTO> driverList = new List<WF_ACTIVITYDTO>();
		if (driver.Next.Count() > 0)
		{
			foreach (Driver item in driver.Next)
			{
				driverList.AddRange(GetFutureDriversInvoke(template, orgId, item, ruleExpress));
			}
		}
		else
		{
			WF_RULEDTO rule = template.WF_RULE.Single((WF_RULEDTO a) => a.RULE_ID == driver.RuleId);
			WF_ACTIVITYDTO ac = template.WF_ACTIVITY.Single((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID);
			IList<Driver> drivers = GetNextDrivers(template, ac, ruleExpress);
			foreach (Driver dr in drivers)
			{
				driverList.AddRange(GetFutureDrivers(template, orgId, dr, ruleExpress));
			}
		}
		return driverList;
	}

	private IList<WF_ACTIVITYDTO> GetFutureDrivers(WF_TEMPLATEDTO template, Guid orgId, Driver driver, string ruleExpress = null)
	{
		List<WF_ACTIVITYDTO> driverList = new List<WF_ACTIVITYDTO>();
		if (driver.Next.Count() > 0)
		{
			foreach (Driver item in driver.Next)
			{
				driverList.AddRange(GetFutureDrivers(template, orgId, item, ruleExpress));
			}
		}
		else
		{
			WF_RULEDTO rule = template.WF_RULE.Single((WF_RULEDTO a) => a.RULE_ID == driver.RuleId);
			WF_ACTIVITYDTO ac = template.WF_ACTIVITY.Single((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID);
			WF_ACTIVITYDTO query = driverList.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == ac.ACTIVITY_ID);
			if (query == null)
			{
				decimal? aCTIVITY_TYPE = ac.ACTIVITY_TYPE;
				if (aCTIVITY_TYPE.GetValueOrDefault() == 0m && aCTIVITY_TYPE.HasValue)
				{
					ResponseData responseData = AccessManager.ServiceAccess("Workflow", "Workflow_Participant_GetActivityParticipant", new
					{
						ACTIVITY_ID = ac.ACTIVITY_ID,
						ORG_ID = orgId,
						TEMPLATE_ID = template.TEMPLATE_ID
					}.JsonSerialize());
					if (!string.IsNullOrEmpty(responseData.Data))
					{
						ac.HANDLER_USER = responseData.Data.JsonDeserialize<List<TREE_NODE>>(new JsonConverter[0]);
					}
					driverList.Add(ac);
					IList<Driver> drivers = GetNextDrivers(template, ac, ruleExpress);
					foreach (Driver dr in drivers)
					{
						driverList.AddRange(GetFutureDrivers(template, orgId, dr, ruleExpress));
					}
				}
			}
		}
		return driverList;
	}

	public WF_TEMPLATEDTO GetFuture(WF_ACTIVITYDTO activityDto)
	{
		IRepository<WF_INSTANCE> repositoryInstance = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE>>();
		WF_TEMPLATE templateDto = WorkflowCacheManager.GetTemplateById(activityDto.TEMPLATE_ID).AdaptAsEntity<WF_TEMPLATE>();
		Type t = Type.GetType($"{templateDto.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
		runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
		runWorkflow.InstanceId = ((!activityDto.INSTANCE_ID.HasValue) ? Guid.Empty : activityDto.INSTANCE_ID.Value);
		WF_INSTANCE instance = repositoryInstance.GetByKey(runWorkflow.InstanceId);
		WF_TEMPLATEDTO wF_TEMPLATEDTO = new WF_TEMPLATEDTO();
		wF_TEMPLATEDTO.WF_ACTIVITY = new List<WF_ACTIVITYDTO>();
		wF_TEMPLATEDTO.WF_RULE = new List<WF_RULEDTO>();
		WF_TEMPLATEDTO result = wF_TEMPLATEDTO;
		Dictionary<string, string> rules = null;
		if (!string.IsNullOrEmpty(activityDto.RULE_COORDINATE))
		{
			rules = activityDto.RULE_COORDINATE.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		}
		if (rules != null)
		{
			rules = rules.OrderByDescending((KeyValuePair<string, string> p) => p.Key.Length).ToDictionary((KeyValuePair<string, string> p) => p.Key, (KeyValuePair<string, string> o) => o.Value);
		}
		GetFuture(templateDto, instance, ref result, activityDto, rules, instance?.ORG_ID ?? SessionContext.UserInfo.BelongToOrgID);
		return result;
	}

	public void GetFuture(WF_TEMPLATE template, WF_INSTANCE instance, ref WF_TEMPLATEDTO result, WF_ACTIVITYDTO activity, Dictionary<string, string> rules, Guid orgId)
	{
		if (result.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == activity.ACTIVITY_ID) != null)
		{
			return;
		}
		result.WF_ACTIVITY.Add(activity);
		activity.HANDLERUSER = runWorkflow.GetNextHandler(template, instance, activity.AdaptAsEntity<WF_ACTIVITY>(), orgId, null);
		IEnumerable<WF_RULE> nextRules = template.WF_RULE.Where(delegate(WF_RULE a)
		{
			int result2;
			if (a.FROM_ACTIVITY_ID == activity.ACTIVITY_ID && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result2 = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		});
		foreach (WF_RULE rule in nextRules)
		{
			GetFuture(template, instance, ref result, rule, rules, orgId);
		}
	}

	private void GetFuture(WF_TEMPLATE template, WF_INSTANCE instance, ref WF_TEMPLATEDTO result, WF_RULE ruleDto, Dictionary<string, string> rules, Guid orgId)
	{
		if (result.WF_RULE.SingleOrDefault((WF_RULEDTO a) => a.RULE_ID == ruleDto.RULE_ID) == null)
		{
			WF_ACTIVITY ac = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY A) => A.ACTIVITY_ID == ruleDto.TO_ACTIVITY_ID);
			int activityType = (int)ac.ACTIVITY_TYPE.Value;
			if (canRun(ruleDto.AdaptAsDTO<WF_RULEDTO>(), rules))
			{
				result.WF_RULE.Add(ruleDto.AdaptAsDTO<WF_RULEDTO>());
				GetFuture(template, instance, ref result, ac.AdaptAsDTO<WF_ACTIVITYDTO>(), rules, orgId);
			}
		}
	}
}
