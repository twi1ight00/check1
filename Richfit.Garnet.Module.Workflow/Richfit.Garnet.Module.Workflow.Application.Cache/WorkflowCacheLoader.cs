using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Cache;

/// <summary>
/// 工作流缓存
/// </summary>
public class WorkflowCacheLoader : ICacheLoader
{
	/// <summary>
	/// 模板缓存key
	/// </summary>
	public const string TemplateKey = "TemplateKey-{0}";

	/// <summary>
	/// 活动缓存key
	/// </summary>
	public const string ActivityKey = "ActivityKey-{0}";

	/// <summary>
	/// 规则缓存key
	/// </summary>
	public const string RuleKey = "RuleKey-{0}";

	/// <summary>
	/// 参与人缓存key
	/// </summary>
	public const string RarticipantKey = "RarticipantKey-{0}";

	/// <summary>
	/// 开始活动对应规则缓存key
	/// </summary>
	public const string RuleFromKey = "RuleFromKey-{0}";

	/// <summary>
	/// 结束活动对于规则缓存key
	/// </summary>
	public const string RuleToKey = "RuleToKey-{0}";

	/// <summary>
	/// 表单缓存key
	/// </summary>
	public const string FormKey = "FormKey-{0}";

	/// <summary>
	/// 同步锁
	/// </summary>
	internal static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 加载缓存
	/// </summary>
	public void Load()
	{
		SyncLocker.Write(delegate
		{
			IList<WF_TEMPLATE> template = GetTemplate();
			template.ForEach(delegate(WF_TEMPLATE x)
			{
				InitTemplate(x);
			});
			IList<WF_FORM> form = GetForm();
			form.ForEach(delegate(WF_FORM x)
			{
				InitForm(x);
			});
		});
	}

	private static void InitTemplate(WF_TEMPLATE template)
	{
		WF_TEMPLATEDTO templateDTO = template.AdaptAsDTO<WF_TEMPLATEDTO>();
		SystemCacheBus.Instance.Set($"TemplateKey-{templateDTO.TEMPLATE_ID}", templateDTO);
		SystemCacheBus.Instance.Set($"ActivityKey-{templateDTO.TEMPLATE_ID}", templateDTO.WF_ACTIVITY.Where((WF_ACTIVITYDTO a) => a.ISDEL == 0m).ToList());
		SystemCacheBus.Instance.Set($"RuleKey-{templateDTO.TEMPLATE_ID}", templateDTO.WF_RULE.Where((WF_RULEDTO a) => a.ISDEL == 0m).ToList());
		IEnumerableTExtensions.ForEach(templateDTO.WF_ACTIVITY, delegate(WF_ACTIVITYDTO y)
		{
			if (!(y.ISDEL == 1m))
			{
				SystemCacheBus.Instance.Set($"ActivityKey-{y.ACTIVITY_ID}", y);
				SystemCacheBus.Instance.Set($"RarticipantKey-{y.ACTIVITY_ID}", y.WF_ACTIVITY_PARTICIPANT);
				SystemCacheBus.Instance.Set($"RuleFromKey-{y.ACTIVITY_ID}", templateDTO.WF_RULE.Where((WF_RULEDTO a) => a.FROM_ACTIVITY_ID == y.ACTIVITY_ID && a.ISDEL == 0m).ToList());
				SystemCacheBus.Instance.Set($"RuleToKey-{y.ACTIVITY_ID}", templateDTO.WF_RULE.Where((WF_RULEDTO a) => a.TO_ACTIVITY_ID == y.ACTIVITY_ID && a.ISDEL == 0m).ToList());
			}
		});
	}

	private static void InitForm(WF_FORM form)
	{
		WF_FORMDTO formDTO = form.AdaptAsDTO<WF_FORMDTO>();
		SystemCacheBus.Instance.Set($"FormKey-{formDTO}", formDTO);
	}

	private IList<WF_TEMPLATE> GetTemplate()
	{
		TemplateService templateService = new TemplateService();
		return templateService.GetTemplate();
	}

	private static WF_TEMPLATE GetTemplateById(Guid templateId)
	{
		TemplateService templateService = new TemplateService();
		return templateService.GetTemplateById(templateId);
	}

	private IList<WF_FORM> GetForm()
	{
		FormService formService = new FormService();
		return formService.GetForm();
	}

	private static WF_FORM GetFormById(Guid fromId)
	{
		FormService formService = new FormService();
		return formService.GetFormById(fromId);
	}

	/// <summary>
	/// 初始化指定模板缓存
	/// </summary>
	/// <param name="templateId">模板ID</param>
	public static void InitTemplateById(Guid templateId)
	{
		InitTemplate(GetTemplateById(templateId));
	}

	/// <summary>
	/// 初始化指定表单缓存
	/// </summary>
	/// <param name="formId">表单ID</param>
	public static void InitFormById(Guid formId)
	{
		InitForm(GetFormById(formId));
	}
}
