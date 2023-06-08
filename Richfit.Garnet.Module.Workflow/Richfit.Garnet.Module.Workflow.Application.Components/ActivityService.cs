using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

/// <summary>
/// 活动服务
/// </summary>
public class ActivityService : ServiceBase
{
	/// <summary>
	/// 构造函数
	/// </summary>
	public ActivityService()
	{
	}

	/// <summary>
	/// 获取指定活动的所有参与者(缓存)
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <returns></returns>
	public IList<WF_ACTIVITY_PARTICIPANTDTO> GetActivityParticipantByActivityId(Guid activityId)
	{
		return (from a in WorkflowCacheManager.GetParticipantByActivityId(activityId)
			where a.ISDEL == 0m
			select a).ToList();
	}

	/// <summary>
	/// 获取开始活动（缓存）
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <returns>开始活动</returns>
	public WF_ACTIVITYDTO GetStartActivity(Guid templateId)
	{
		return WorkflowCacheManager.GetActivityByTemplateId(templateId).SingleOrDefault(delegate(WF_ACTIVITYDTO a)
		{
			decimal? aCTIVITY_TYPE = a.ACTIVITY_TYPE;
			return aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue;
		});
	}

	/// <summary>
	/// 获取指定活动（缓存）
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <returns>活动</returns>
	public WF_ACTIVITYDTO GetActivityById(Guid activityId)
	{
		return WorkflowCacheManager.GetActivityById(activityId);
	}

	/// <summary>
	/// 按照某规则获取所有活动
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="rules">规则</param>
	/// <param name="activityId"></param>
	/// <returns></returns>
	public List<WF_ACTIVITYDTO> GetAllActivitys(Guid templateId, string rules, List<WF_ACTIVITYDTO> activitys = null)
	{
		List<WF_ACTIVITYDTO> activityCollection = new List<WF_ACTIVITYDTO>();
		WF_ACTIVITYDTO activity = null;
		if (activitys == null)
		{
			activity = GetStartActivity(templateId);
			GetNextActivitysInvoke(ref activityCollection, activity.ACTIVITY_ID, rules);
		}
		else
		{
			activitys.ForEach(delegate(WF_ACTIVITYDTO a)
			{
				activity = GetActivityById(a.ACTIVITY_ID);
				GetNextActivitysInvoke(ref activityCollection, activity.ACTIVITY_ID, rules);
			});
		}
		activityCollection.Reverse();
		return activityCollection;
	}

	private void GetNextActivitysInvoke(ref List<WF_ACTIVITYDTO> activityCollection, Guid activityId, string rules)
	{
		List<WF_ACTIVITYDTO> iactivityCollection = GetNextActivitys(activityId, rules);
		foreach (WF_ACTIVITYDTO iactivity in iactivityCollection)
		{
			List<WF_ACTIVITYDTO> obj = activityCollection;
			Predicate<WF_ACTIVITYDTO> match = (WF_ACTIVITYDTO a) => a.ACTIVITY_ID == iactivity.ACTIVITY_ID;
			if (obj.Find(match) != null)
			{
				break;
			}
			GetNextActivitysInvoke(ref activityCollection, iactivity.ACTIVITY_ID, rules);
			activityCollection.Add(iactivity);
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

	/// <summary>
	/// 获取前驱活动
	/// </summary>
	/// <returns></returns>
	public List<WF_ACTIVITYDTO> GetPrecursorActivitys(Guid activityId)
	{
		List<WF_RULEDTO> rules = (from a in WorkflowCacheManager.GetRuleByToActivityId(activityId)
			where a.ISDEL == 0m
			select a).ToList();
		List<WF_ACTIVITYDTO> precursorActivitys = new List<WF_ACTIVITYDTO>();
		foreach (WF_RULEDTO item in rules)
		{
			precursorActivitys.Add(WorkflowCacheManager.GetActivityById(item.FROM_ACTIVITY_ID));
		}
		return precursorActivitys;
	}

	/// <summary>
	/// 获取两节点之间的所有节点
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="fromActivityId">起始节点ID</param>
	/// <param name="endActivityId">结束节点ID</param>
	/// <returns></returns>
	public IList<WF_ACTIVITYDTO> GetBetweenActivity(Guid templateId, Guid fromActivityId, Guid endActivityId)
	{
		WF_TEMPLATEDTO currentTemplate = WorkflowCacheManager.GetTemplateById(templateId);
		IList<WF_ACTIVITYDTO> afterfromacs = GetAfterActivityInvoke(currentTemplate, fromActivityId);
		IList<WF_ACTIVITYDTO> afterendacs = GetAfterActivityInvoke(currentTemplate, endActivityId);
		IList<WF_ACTIVITYDTO> prefromacs = GetPreActivityInvoke(currentTemplate, fromActivityId);
		IList<WF_ACTIVITYDTO> preenddacs = GetPreActivityInvoke(currentTemplate, endActivityId);
		IEnumerable<WF_ACTIVITYDTO> query = afterfromacs.Except(afterendacs).Intersect(preenddacs.Except(prefromacs));
		return query.ToList();
	}

	/// <summary>
	/// 获取一个阶段所有的后继
	/// </summary>
	/// <param name="currentTemplate"></param>
	/// <param name="activityId">当前节点</param>
	/// <returns></returns>
	private IList<WF_ACTIVITYDTO> GetPreActivityInvoke(WF_TEMPLATEDTO currentTemplate, Guid activityId)
	{
		IList<WF_ACTIVITYDTO> result = new List<WF_ACTIVITYDTO>();
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result2;
			if (a.TO_ACTIVITY_ID == activityId && a.ISDEL == 0m)
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
		foreach (WF_RULEDTO rule in query)
		{
			GetPreActivity(currentTemplate, rule.FROM_ACTIVITY_ID, ref result);
		}
		return result;
	}

	private void GetPreActivity(WF_TEMPLATEDTO currentTemplate, Guid activityId, ref IList<WF_ACTIVITYDTO> result)
	{
		WF_ACTIVITYDTO activity = currentTemplate.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == activityId && a.ISDEL == 0m);
		if (activity == null)
		{
			return;
		}
		decimal? aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
		if ((aCTIVITY_TYPE.GetValueOrDefault() == -2m && aCTIVITY_TYPE.HasValue) || result.Contains(activity))
		{
			return;
		}
		result.Add(activity);
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result2;
			if (a.TO_ACTIVITY_ID == activityId && a.ISDEL == 0m)
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
		foreach (WF_RULEDTO rule in query)
		{
			GetPreActivity(currentTemplate, rule.FROM_ACTIVITY_ID, ref result);
		}
	}

	/// <summary>
	/// 获得一个节点所有的后继节点
	/// </summary>
	/// <param name="currentTemplate"></param>
	/// <param name="activityId">当前节点</param>
	/// <returns></returns>
	private IList<WF_ACTIVITYDTO> GetAfterActivityInvoke(WF_TEMPLATEDTO currentTemplate, Guid activityId)
	{
		IList<WF_ACTIVITYDTO> result = new List<WF_ACTIVITYDTO>();
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result2;
			if (a.FROM_ACTIVITY_ID == activityId && a.ISDEL == 0m)
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
		foreach (WF_RULEDTO rule in query)
		{
			GetAfterActivity(currentTemplate, rule.TO_ACTIVITY_ID, ref result);
		}
		return result;
	}

	private void GetAfterActivity(WF_TEMPLATEDTO currentTemplate, Guid activityId, ref IList<WF_ACTIVITYDTO> result)
	{
		WF_ACTIVITYDTO activity = currentTemplate.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == activityId && a.ISDEL == 0m);
		if (activity == null)
		{
			return;
		}
		decimal? aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
		if ((aCTIVITY_TYPE.GetValueOrDefault() == 100m && aCTIVITY_TYPE.HasValue) || result.Contains(activity))
		{
			return;
		}
		result.Add(activity);
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result2;
			if (a.FROM_ACTIVITY_ID == activityId && a.ISDEL == 0m)
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
		foreach (WF_RULEDTO rule in query)
		{
			GetAfterActivity(currentTemplate, rule.TO_ACTIVITY_ID, ref result);
		}
	}

	/// <summary>
	/// 获取互斥步骤
	/// </summary>
	/// <param name="instanceId">流程实例ID</param>
	/// <param name="activityId">当前工作项对应的节点ID</param>
	/// <returns></returns>
	public Dictionary<WF_ACTIVITYDTO, List<WF_ACTIVITYDTO>> GetReturnConstraintActivitys(Guid instanceId, Guid activityId)
	{
		InstanceService instanceService = new InstanceService();
		WF_INSTANCE currentInstance = instanceService.GetInstanceById(instanceId);
		WF_TEMPLATEDTO currentTemplate = WorkflowCacheManager.GetTemplateById(currentInstance.TEMPLATE_ID.Value);
		WF_ACTIVITYDTO startAc = currentTemplate.WF_ACTIVITY.SingleOrDefault(delegate(WF_ACTIVITYDTO a)
		{
			int result4;
			if (a.ISDEL == 0m)
			{
				decimal? aCTIVITY_TYPE = a.ACTIVITY_TYPE;
				result4 = ((aCTIVITY_TYPE.GetValueOrDefault() == -2m && aCTIVITY_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result4 = 0;
			}
			return (byte)result4 != 0;
		});
		IEnumerable<WF_RULEDTO> canReturnAc = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result3;
			if (a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				if (rULE_TYPE.GetValueOrDefault() == 1m && rULE_TYPE.HasValue)
				{
					result3 = ((a.FROM_ACTIVITY_ID == activityId) ? 1 : 0);
					goto IL_004f;
				}
			}
			result3 = 0;
			goto IL_004f;
			IL_004f:
			return (byte)result3 != 0;
		});
		Dictionary<WF_ACTIVITYDTO, List<WF_ACTIVITYDTO>> result = new Dictionary<WF_ACTIVITYDTO, List<WF_ACTIVITYDTO>>();
		foreach (WF_RULEDTO rule in canReturnAc)
		{
			ICollection<WF_WORKITEM> wF_WORKITEM = currentInstance.WF_WORKITEM;
			Func<WF_WORKITEM, bool> predicate = delegate(WF_WORKITEM a)
			{
				int result2;
				if (a.ISDEL == 0m && a.ACTIVITY_ID == rule.TO_ACTIVITY_ID)
				{
					decimal? hANDLE_RESULT = a.HANDLE_RESULT;
					result2 = ((hANDLE_RESULT.GetValueOrDefault() == 2m && hANDLE_RESULT.HasValue) ? 1 : 0);
				}
				else
				{
					result2 = 0;
				}
				return (byte)result2 != 0;
			};
			IEnumerable<WF_WORKITEM> query = wF_WORKITEM.Where(predicate);
			if (query == null || query.Count() <= 0)
			{
				continue;
			}
			IList<WF_ACTIVITYDTO> query2 = GetBetweenActivity(currentInstance.TEMPLATE_ID.Value, rule.TO_ACTIVITY_ID, activityId);
			IList<WF_ACTIVITYDTO> query3 = GetBetweenActivity(currentInstance.TEMPLATE_ID.Value, startAc.ACTIVITY_ID, rule.TO_ACTIVITY_ID);
			WF_ACTIVITYDTO ac = currentTemplate.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ISDEL == 0m && a.ACTIVITY_ID == rule.TO_ACTIVITY_ID);
			IEnumerable<WF_ACTIVITYDTO> query4 = query2.Union(query3).Distinct();
			if (!result.ContainsKey(ac))
			{
				if (query4 != null)
				{
					result.Add(ac, query4.ToList());
				}
				else
				{
					result.Add(ac, new List<WF_ACTIVITYDTO>());
				}
			}
		}
		return result;
	}

	public IList<WF_RULEDTO> GetRuleByFromActivityId(Guid activityId)
	{
		return WorkflowCacheManager.GetRuleByFromActivityId(activityId);
	}

	public IList<WF_RULEDTO> GetRuleByToActivityId(Guid activityId)
	{
		return WorkflowCacheManager.GetRuleByToActivityId(activityId);
	}
}
