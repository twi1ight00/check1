using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

/// <summary>
/// 流程流转路径
/// </summary>
public class ItemPath
{
	private IList<WF_WORKITEM> allItems;

	/// <summary>
	/// 当前流程所有的工作项
	/// </summary>
	public ICollection<WF_WORKITEM> effectiveItems;

	/// <summary>
	/// 当前模版所有的节点
	/// </summary>
	public ICollection<WF_ACTIVITYDTO> activitys;

	/// <summary>
	///  当前模版所有的规则
	/// </summary>
	public ICollection<WF_RULEDTO> wfRule;

	private IList<Guid> handlerActivitys;

	/// <summary>
	/// 根路径
	/// </summary>
	public Stack<WF_WORKITEM> RootPath { get; set; }

	public ItemPath ParentPath { get; set; }

	/// <summary>
	/// 子路径
	/// </summary>
	public ItemPath ChildPath { get; set; }

	public List<Stack<WF_WORKITEM>> BranchingPath { get; set; }

	public ItemPath(ICollection<WF_ACTIVITYDTO> activitys, ICollection<WF_RULEDTO> wfRule, ICollection<WF_WORKITEM> allItems)
	{
		BranchingPath = new List<Stack<WF_WORKITEM>>();
		handlerActivitys = new List<Guid>();
		RootPath = new Stack<WF_WORKITEM>();
		this.activitys = activitys;
		this.wfRule = wfRule;
		this.allItems = allItems.Where((WF_WORKITEM a) => a.ISDEL == 0m).ToList();
		effectiveItems = this.allItems.Where(delegate(WF_WORKITEM a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue && a.ISDEL == 0m;
		}).ToList();
	}

	public ItemPath(Guid templateId, ICollection<WF_WORKITEM> allItems)
	{
		BranchingPath = new List<Stack<WF_WORKITEM>>();
		handlerActivitys = new List<Guid>();
		RootPath = new Stack<WF_WORKITEM>();
		WF_TEMPLATEDTO currentTemplate = WorkflowCacheManager.GetTemplateById(templateId);
		activitys = currentTemplate.WF_ACTIVITY.Where((WF_ACTIVITYDTO a) => a.ISDEL == 0m).ToList();
		wfRule = currentTemplate.WF_RULE.Where((WF_RULEDTO a) => a.ISDEL == 0m).ToList();
		this.allItems = allItems.Where((WF_WORKITEM a) => a.ISDEL == 0m).ToList();
		effectiveItems = this.allItems.Where(delegate(WF_WORKITEM a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue && a.ISDEL == 0m;
		}).ToList();
	}

	public ItemPath(WF_TEMPLATEDTO tempLate, WF_INSTANCE instance)
	{
		BranchingPath = new List<Stack<WF_WORKITEM>>();
		handlerActivitys = new List<Guid>();
		RootPath = new Stack<WF_WORKITEM>();
		activitys = tempLate.WF_ACTIVITY.Where((WF_ACTIVITYDTO a) => a.ISDEL == 0m).ToList();
		wfRule = tempLate.WF_RULE.Where((WF_RULEDTO a) => a.ISDEL == 0m).ToList();
		allItems = instance.WF_WORKITEM.Where((WF_WORKITEM a) => a.ISDEL == 0m).ToList();
		effectiveItems = allItems.Where(delegate(WF_WORKITEM a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			int result;
			if (hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue && a.ISDEL == 0m)
			{
				hANDLE_RESULT = a.WORKITEM_RUN_STATE;
				result = ((hANDLE_RESULT.GetValueOrDefault() != 0m || !hANDLE_RESULT.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public void GenerateWorkItemPath(ref ItemPath itemPath)
	{
		WF_ACTIVITYDTO draft = activitys.SingleOrDefault(delegate(WF_ACTIVITYDTO a)
		{
			decimal? aCTIVITY_TYPE = a.ACTIVITY_TYPE;
			return aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue;
		});
		GenerateWorkItemPath(ref itemPath, itemPath.RootPath, draft, null);
	}

	private void GenerateWorkItemPath(ref ItemPath itemPath, Stack<WF_WORKITEM> currentPath, WF_ACTIVITYDTO currentActivity, WF_ACTIVITYDTO fromActivity)
	{
		if (handlerActivitys.Contains(currentActivity.ACTIVITY_ID) || (fromActivity != null && !IsNextActivity(fromActivity, currentActivity)))
		{
			return;
		}
		handlerActivitys.Add(currentActivity.ACTIVITY_ID);
		IEnumerable<WF_RULEDTO> rules = wfRule.Where((WF_RULEDTO a) => a.FROM_ACTIVITY_ID == currentActivity.ACTIVITY_ID);
		IEnumerable<WF_WORKITEM> items = effectiveItems.Where((WF_WORKITEM a) => a.ACTIVITY_ID == currentActivity.ACTIVITY_ID);
		decimal? wORKITEM_RUN_STATE;
		if (items.Count() > 0)
		{
			WF_WORKITEM item;
			if (items.Count() == 1)
			{
				item = items.ToList()[0];
			}
			else
			{
				items = items.OrderByDescending((WF_WORKITEM a) => a.CREATETIME);
				item = items.ToList()[0];
			}
			currentPath.Push(item);
			wORKITEM_RUN_STATE = item.WORKITEM_RUN_STATE;
			if (wORKITEM_RUN_STATE.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE.HasValue)
			{
				return;
			}
			{
				foreach (WF_RULEDTO rule3 in rules)
				{
					ICollection<WF_ACTIVITYDTO> source = activitys;
					Func<WF_ACTIVITYDTO, bool> predicate = (WF_ACTIVITYDTO a) => a.ACTIVITY_ID == rule3.TO_ACTIVITY_ID;
					foreach (WF_ACTIVITYDTO toActivity in source.Where(predicate))
					{
						GenerateWorkItemPath(ref itemPath, currentPath, toActivity, currentActivity);
					}
				}
				return;
			}
		}
		wORKITEM_RUN_STATE = currentActivity.ACTIVITY_TYPE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 3m && wORKITEM_RUN_STATE.HasValue)
		{
			foreach (WF_RULEDTO rule2 in rules)
			{
				ICollection<WF_ACTIVITYDTO> source2 = activitys;
				Func<WF_ACTIVITYDTO, bool> predicate2 = (WF_ACTIVITYDTO a) => a.ACTIVITY_ID == rule2.TO_ACTIVITY_ID;
				IEnumerable<WF_ACTIVITYDTO> toActivitys = source2.Where(predicate2);
				Stack<WF_WORKITEM> branchingPath = new Stack<WF_WORKITEM>();
				BranchingPath.Add(branchingPath);
				foreach (WF_ACTIVITYDTO toActivity in toActivitys)
				{
					GenerateWorkItemPath(ref itemPath, branchingPath, toActivity, currentActivity);
				}
			}
			return;
		}
		wORKITEM_RUN_STATE = currentActivity.ACTIVITY_TYPE;
		if (!(wORKITEM_RUN_STATE.GetValueOrDefault() == 4m) || !wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		ItemPath path = new ItemPath(activitys, wfRule, effectiveItems);
		path.ParentPath = itemPath;
		itemPath.ChildPath = path;
		foreach (WF_RULEDTO rule in rules)
		{
			ICollection<WF_ACTIVITYDTO> source3 = activitys;
			Func<WF_ACTIVITYDTO, bool> predicate3 = (WF_ACTIVITYDTO a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID;
			foreach (WF_ACTIVITYDTO toActivity in source3.Where(predicate3))
			{
				GenerateWorkItemPath(ref path, path.RootPath, toActivity, currentActivity);
			}
		}
	}

	private bool IsNextActivity(WF_ACTIVITYDTO fromActivity, WF_ACTIVITYDTO currentActivity)
	{
		decimal? aCTIVITY_TYPE = currentActivity.ACTIVITY_TYPE;
		IEnumerable<WF_RULEDTO> fromRules;
		if (!(aCTIVITY_TYPE.GetValueOrDefault() == 3m) || !aCTIVITY_TYPE.HasValue)
		{
			aCTIVITY_TYPE = currentActivity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == 4m) || !aCTIVITY_TYPE.HasValue)
			{
				IEnumerable<WF_WORKITEM> items = effectiveItems.Where((WF_WORKITEM a) => a.ACTIVITY_ID == currentActivity.ACTIVITY_ID);
				if (items.Count() > 0)
				{
					foreach (WF_WORKITEM item in items)
					{
						Guid ac = GetEffectivePrecursor(item);
						if (ac == fromActivity.ACTIVITY_ID)
						{
							return true;
						}
						aCTIVITY_TYPE = fromActivity.ACTIVITY_TYPE;
						if (!(aCTIVITY_TYPE.GetValueOrDefault() == 3m) || !aCTIVITY_TYPE.HasValue)
						{
							aCTIVITY_TYPE = fromActivity.ACTIVITY_TYPE;
							if (!(aCTIVITY_TYPE.GetValueOrDefault() == 4m) || !aCTIVITY_TYPE.HasValue)
							{
								continue;
							}
						}
						fromRules = wfRule.Where((WF_RULEDTO a) => a.TO_ACTIVITY_ID == fromActivity.ACTIVITY_ID);
						foreach (WF_RULEDTO rule2 in fromRules)
						{
							if (ac == rule2.FROM_ACTIVITY_ID)
							{
								return true;
							}
						}
					}
				}
				goto IL_0324;
			}
		}
		fromRules = wfRule.Where((WF_RULEDTO a) => a.FROM_ACTIVITY_ID == currentActivity.ACTIVITY_ID);
		foreach (WF_RULEDTO rule in fromRules)
		{
			ICollection<WF_WORKITEM> source = effectiveItems;
			Func<WF_WORKITEM, bool> predicate = (WF_WORKITEM a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID;
			foreach (WF_WORKITEM item in source.Where(predicate))
			{
				Guid ac = GetEffectivePrecursor(item);
				if (ac == fromActivity.ACTIVITY_ID)
				{
					return true;
				}
			}
		}
		goto IL_0324;
		IL_0324:
		return false;
	}

	private Guid GetEffectivePrecursor(WF_WORKITEM item)
	{
		WF_WORKITEM query = allItems.SingleOrDefault(delegate(WF_WORKITEM a)
		{
			Guid wORKITEM_ID2 = a.WORKITEM_ID;
			Guid? pARENT_WORKITEM_ID2 = item.PARENT_WORKITEM_ID;
			return wORKITEM_ID2 == pARENT_WORKITEM_ID2;
		});
		while (true)
		{
			decimal? hANDLE_RESULT = query.HANDLE_RESULT;
			if (!(hANDLE_RESULT.GetValueOrDefault() != 0m) && hANDLE_RESULT.HasValue)
			{
				break;
			}
			query = allItems.SingleOrDefault(delegate(WF_WORKITEM a)
			{
				Guid wORKITEM_ID = a.WORKITEM_ID;
				Guid? pARENT_WORKITEM_ID = query.PARENT_WORKITEM_ID;
				return wORKITEM_ID == pARENT_WORKITEM_ID;
			});
		}
		return query.ACTIVITY_ID;
	}

	public bool IsContainActivity(Stack<WF_WORKITEM> items, Guid activityId)
	{
		bool flag = false;
		Stack<WF_WORKITEM> tmp = new Stack<WF_WORKITEM>();
		while (items.Count > 0)
		{
			WF_WORKITEM item = items.Pop();
			tmp.Push(item);
			if (item.ACTIVITY_ID == activityId)
			{
				flag = true;
				break;
			}
		}
		while (tmp.Count > 0)
		{
			items.Push(tmp.Pop());
		}
		return flag;
	}
}
