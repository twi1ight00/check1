using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.Cache;

/// <summary>
/// 工作流缓存管理
/// </summary>
public class WorkflowCacheManager
{
	public static WF_TEMPLATEDTO GetTemplateById(Guid templateId)
	{
		WF_TEMPLATEDTO value = new WF_TEMPLATEDTO();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"TemplateKey-{templateId}") as WF_TEMPLATEDTO;
		});
		return value;
	}

	public static IList<WF_ACTIVITYDTO> GetActivityByTemplateId(Guid templateId)
	{
		IList<WF_ACTIVITYDTO> value = new List<WF_ACTIVITYDTO>();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"ActivityKey-{templateId}") as IList<WF_ACTIVITYDTO>;
		});
		return value;
	}

	public static WF_ACTIVITYDTO GetActivityById(Guid activityId)
	{
		WF_ACTIVITYDTO value = new WF_ACTIVITYDTO();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"ActivityKey-{activityId}") as WF_ACTIVITYDTO;
		});
		return value;
	}

	public static IList<WF_RULEDTO> GetRuleByTemplateId(Guid templateId)
	{
		IList<WF_RULEDTO> value = new List<WF_RULEDTO>();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"RuleKey-{templateId}") as IList<WF_RULEDTO>;
		});
		return value;
	}

	public static IList<WF_RULEDTO> GetRuleByFromActivityId(Guid activityId)
	{
		IList<WF_RULEDTO> value = new List<WF_RULEDTO>();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"RuleFromKey-{activityId}") as List<WF_RULEDTO>;
		});
		return value;
	}

	public static IList<WF_RULEDTO> GetRuleByToActivityId(Guid activityId)
	{
		IList<WF_RULEDTO> value = new List<WF_RULEDTO>();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"RuleToKey-{activityId}") as List<WF_RULEDTO>;
		});
		return value;
	}

	public static IList<WF_ACTIVITY_PARTICIPANTDTO> GetParticipantByActivityId(Guid activityId)
	{
		IList<WF_ACTIVITY_PARTICIPANTDTO> value = new List<WF_ACTIVITY_PARTICIPANTDTO>();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"RarticipantKey-{activityId}") as IList<WF_ACTIVITY_PARTICIPANTDTO>;
		});
		return value;
	}

	public static WF_FORMDTO GetFormById(Guid formId)
	{
		WF_FORMDTO value = new WF_FORMDTO();
		WorkflowCacheLoader.SyncLocker.Read(delegate
		{
			value = SystemCacheBus.Instance.Get($"FormKey-{formId}") as WF_FORMDTO;
		});
		return value;
	}

	public static void RefusedForm(Guid formId)
	{
		WF_FORMDTO form = GetFormById(formId);
		if (form != null)
		{
			WorkflowCacheLoader.SyncLocker.Write(delegate
			{
				SystemCacheBus.Instance.Remove($"FormKey-{formId}");
			});
		}
		WorkflowCacheLoader.InitFormById(formId);
	}

	public static void Refused(Guid templateId)
	{
		WF_TEMPLATEDTO tmplate = GetTemplateById(templateId);
		if (tmplate != null)
		{
			WorkflowCacheLoader.SyncLocker.Write(delegate
			{
				tmplate.WF_ACTIVITY.ForEach(delegate(WF_ACTIVITYDTO a)
				{
					SystemCacheBus.Instance.Remove($"ActivityKey-{a.ACTIVITY_ID}");
					SystemCacheBus.Instance.Remove($"RarticipantKey-{a.ACTIVITY_ID}");
					SystemCacheBus.Instance.Remove($"RuleFromKey-{a.ACTIVITY_ID}");
					SystemCacheBus.Instance.Remove($"RuleToKey-{a.ACTIVITY_ID}");
				});
				SystemCacheBus.Instance.Remove($"TemplateKey-{templateId}");
				SystemCacheBus.Instance.Remove($"ActivityKey-{templateId}");
				SystemCacheBus.Instance.Remove($"RuleKey-{templateId}");
			});
		}
		WorkflowCacheLoader.InitTemplateById(templateId);
	}
}
