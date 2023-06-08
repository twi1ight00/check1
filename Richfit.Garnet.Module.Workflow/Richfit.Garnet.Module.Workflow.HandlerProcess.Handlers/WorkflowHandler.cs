#define DEBUG
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Migration;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.HandlerProcess.Handlers;

/// <summary>
/// 工作流服务
/// </summary>
public class WorkflowHandler : HandlerBase
{
	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				DateTime dtNow = DateTime.Now;
				Type[] params_type = new Type[1] { typeof(ResponseData) };
				MethodInfo methodInfo = GetType().GetMethod(action.Replace("Workflow_", ""), BindingFlags.Instance | BindingFlags.NonPublic);
				methodInfo.Invoke(this, new object[1] { handlerResult });
				TraceDebug.Write($"ActionCode:{action},执行时间:{DateTime.Now - dtNow}");
			}
		}
		catch (Exception ex)
		{
			handlerResult = ((ex.InnerException == null) ? HandleException(ex) : HandleException(ex.InnerException));
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void Authentication(ResponseData handlerResult)
	{
		WF_WORKITEMDTO workItem = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().Authentication(workItem).JsonSerialize();
	}

	private void EditAccount(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		ServiceLocator.Instance.GetService<IWorkflowService>().EditAccount(new Guid(dictionary["INSTANCE_ID"]), dictionary["dataJson"]);
	}

	private void WorkflowDataMigration(ResponseData handlerResult)
	{
		IList<DataMigrationDTO> list = base.RequestData.Data.JsonDeserialize<IList<DataMigrationDTO>>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().WorkflowDataMigration(list).JsonSerialize();
	}

	private void Active_Template(ResponseData handlerResult)
	{
		WF_TEMPLATEDTO template = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().ActiveTemplate(template).JsonSerialize();
	}

	private void Delete_Template(ResponseData handlerResult)
	{
		WF_TEMPLATEDTO template = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().DeleteTemplate(template).JsonSerialize();
	}

	private void GetAccountDataByInstanceId(ResponseData handlerResult)
	{
		Dictionary<string, Guid> parm = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		Guid? pid = null;
		if (parm.ContainsKey("PID"))
		{
			pid = parm["PID"];
		}
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetAccountDataByInstanceId(parm["INSTANCE_ID"], pid).JsonSerialize();
	}

	private void Test(ResponseData handlerResult)
	{
		string path = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0])["FilePath"];
		SqlRepository repository = new SqlRepository(null);
		StreamReader sr = new StreamReader(path, Encoding.Default);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			repository.ExecuteCommand(line);
		}
		sr.Dispose();
	}

	private void GetTemplateVersionList(ResponseData handlerResult)
	{
		WF_TEMPLATEDTO template = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateVersionList(template.PARENT_TEMPLATE_ID).JsonSerialize();
	}

	private void GetTemplateByPackageid(ResponseData handlerResult)
	{
		WF_TEMPLATEDTO dto = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
		dto.PARENT_TEMPLATE_ID = Guid.Empty;
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateByPackage(dto).JsonSerialize();
	}

	private void GetActiveTemplateByPackageid(ResponseData handlerResult)
	{
		WF_TEMPLATEDTO dto = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
		dto.PARENT_TEMPLATE_ID = Guid.Empty;
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetActiveTemplateByPackageid(dto).JsonSerialize();
	}

	private void GetTemplateForms(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			FormParameter parameter = base.RequestData.Data.JsonDeserialize<FormParameter>(new JsonConverter[0]);
			List<WF_FORMDTO> templates = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateForms(parameter.VERSION_ID, parameter.FORM_ID);
			handlerResult.Data = templates.JsonSerialize();
		}
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	private void GetTemplateNameAndVersions(ResponseData handlerResult)
	{
		List<WF_TEMPLATEDTO> templates = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateNameAndVersions();
		handlerResult.Data = templates.JsonSerialize();
	}

	private void GetPackageTemplate(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			string orgId = (string.IsNullOrEmpty(dictionary["ORG_ID"]) ? string.Empty : dictionary["ORG_ID"]);
			string formId = (string.IsNullOrEmpty(dictionary["FORM_ID"]) ? string.Empty : dictionary["FORM_ID"]);
			IList<TREE_NODE> data = ServiceLocator.Instance.GetService<IPackageService>().GetPackageTemplate(formId, orgId);
			handlerResult.Data = data.JsonSerialize();
		}
	}

	private void RemovePackage(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ID"))
			{
				ServiceLocator.Instance.GetService<IPackageService>().DeletePackage(dictionary["ID"]);
			}
		}
	}

	private void SavePackage(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_PACKAGEDTO dto = base.RequestData.Data.JsonDeserialize<WF_PACKAGEDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				ServiceLocator.Instance.GetService<IPackageService>().SavePackage(dto);
			}
		}
	}

	private void GetPackageByParameter(ResponseData handlerResult)
	{
		PackageParameter parameter = base.RequestData.Data.JsonDeserialize<PackageParameter>(new JsonConverter[0]);
		if (!parameter.IsNull())
		{
			handlerResult.Data = ServiceLocator.Instance.GetService<IPackageService>().GetPackageByParameter(parameter.ToQueryCondition()).ToJson();
		}
	}

	private void Output(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			handlerResult.Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(dictionary["Template"])).JsonSerialize();
		}
	}

	private void Input(ResponseData handlerResult)
	{
	}

	private void GetMyTemplate(ResponseData handlerResult)
	{
		string action = "";
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary != null && dictionary.ContainsKey("ACTION"))
			{
				action = dictionary["ACTION"];
			}
		}
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetMyTemplate(action).JsonSerialize();
	}

	private void AddTemplate(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_TEMPLATEDTO dto = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().AddTemplate(dto);
			}
		}
	}

	private void SaveTemplate(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_TEMPLATEDTO dto = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().SaveTemplate(dto).JsonSerialize();
			}
		}
	}

	private void UpdateTemplate(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_TEMPLATEDTO dto = base.RequestData.Data.JsonDeserialize<WF_TEMPLATEDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().UpdateTemplate(dto);
			}
		}
	}

	private void GetTemplateByTemplateFormID(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "TEMPLATE_FORM_ID"))
			{
				WF_TEMPLATEDTO data = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateByTemplateFormID(new Guid(dictionary["TEMPLATE_FORM_ID"]));
				handlerResult.Data = data.JsonSerialize();
			}
		}
	}

	private void GetTemplateByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			TemplateParameter parameter = base.RequestData.Data.JsonDeserialize<TemplateParameter>(new JsonConverter[0]);
			QueryResult<WF_TEMPLATEDTO> collection = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateByParameter(parameter);
			handlerResult.Data = collection.JsonSerialize();
		}
	}

	private void GetTemplateById(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (!dictionary.Any((KeyValuePair<string, string> a) => a.Key == "TEMPLATE_ID"))
		{
			return;
		}
		IWorkflowService workflowService = ServiceLocator.Instance.GetService<IWorkflowService>();
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(Guid.Parse(dictionary["TEMPLATE_ID"]));
		if (single == null)
		{
			single = workflowService.GetTemplateById(Guid.Parse(dictionary["TEMPLATE_ID"]));
		}
		single.WF_ACTIVITY = single.WF_ACTIVITY.Where((WF_ACTIVITYDTO a) => a.ISDEL == 0m).ToList();
		single.WF_RULE = single.WF_RULE.Where((WF_RULEDTO a) => a.ISDEL == 0m).ToList();
		foreach (WF_ACTIVITYDTO ac in single.WF_ACTIVITY)
		{
			ac.WF_ACTIVITY_PARTICIPANT = ac.WF_ACTIVITY_PARTICIPANT.Where((WF_ACTIVITY_PARTICIPANTDTO a) => a.ISDEL == 0m).ToList();
		}
		if (dictionary.ContainsKey("INSTANCE_ID"))
		{
			string INSTANCE_ID = dictionary["INSTANCE_ID"];
			if (!string.IsNullOrEmpty(INSTANCE_ID))
			{
				Guid instanceId = new Guid(INSTANCE_ID);
				Type t = Type.GetType($"{single.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
				IRunWorkflow runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
				runWorkflow.InstanceId = instanceId;
				WF_INSTANCEDTO instanceDto = new InstanceService_v2().GetInstanceById(instanceId);
				instanceDto.FORM_DATA = runWorkflow.FindByInstanceId(instanceId).JsonSerialize();
				single.WF_INSTANCEDTO = instanceDto;
			}
		}
		handlerResult.Data = single.JsonSerialize();
	}

	private void GetNextDriver(ResponseData handlerResult)
	{
		IWorkflowService workflowService = ServiceLocator.Instance.GetService<IWorkflowService>();
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid activityId = default(Guid);
		ref Guid reference = ref activityId;
		reference = new Guid(dictionary["ACTIVITY_ID"]);
		Guid templateId = new Guid(dictionary["TEMPLATE_ID"]);
		Guid orgId = new Guid(dictionary["ORG_ID"]);
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(templateId);
		WF_ACTIVITYDTO activity = single.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == activityId);
		string ruleExpress = (dictionary.ContainsKey("RULE_CONDITION") ? dictionary["RULE_CONDITION"] : null);
		IList<Driver> next = workflowService.GetNextDrivers(single, activity, ruleExpress);
		IList<WF_ACTIVITYDTO> list = new List<WF_ACTIVITYDTO>();
		if (Bit.pro((long)activity.STATUS.Value, "9|1") == 1)
		{
			foreach (Driver driver in next)
			{
				list.AddRange(workflowService.GetFutureDriversInvoke(single, orgId, driver, ruleExpress));
			}
		}
		object obj = new
		{
			BACK_DRIVER = workflowService.GetBackDrivers(single, activity),
			NEXT_DRIVER = next,
			FUTURE = list
		};
		handlerResult.Data = obj.JsonSerialize();
	}

	private void GetFuture(ResponseData handlerResult)
	{
		WF_ACTIVITYDTO activityDto = base.RequestData.Data.JsonDeserialize<WF_ACTIVITYDTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetFuture(activityDto).JsonSerialize();
	}

	private DriverParameter GetNextDrivers(Guid templateId, Guid activityId, string condition = null)
	{
		IWorkflowService workflowService = ServiceLocator.Instance.GetService<IWorkflowService>();
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(templateId);
		WF_ACTIVITYDTO activity = single.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == activityId);
		DriverParameter driverParameter = new DriverParameter();
		driverParameter.BACK_DRIVER = workflowService.GetBackDrivers(single, activity);
		driverParameter.NEXT_DRIVER = workflowService.GetNextDrivers(single, activity, condition);
		return driverParameter;
	}

	private void GetTemplateFormByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "URL"))
			{
				handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateFormByUrl(dictionary["URL"]).JsonSerialize();
			}
		}
	}

	private void GetGoBackNextActivity(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			string rule = string.Empty;
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID"))
			{
				List<WF_ACTIVITYDTO> collection = ServiceLocator.Instance.GetService<IWorkflowService>().GetGoBackNextActivity(Guid.Parse(dictionary["ACTIVITY_ID"]));
				handlerResult.Data = collection.JsonSerialize();
			}
		}
	}

	private void GetNextActivity(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		string rule = string.Empty;
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID"))
		{
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "RULE"))
			{
				rule = dictionary["RULE"];
			}
			List<NEXT_ACTIVITY> collection = ServiceLocator.Instance.GetService<IWorkflowService>().GetPostActivitys(Guid.Parse(dictionary["ACTIVITY_ID"]), rule);
			handlerResult.Data = collection.JsonSerialize();
		}
	}

	private void GetAllActivitys(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		string rule = string.Empty;
		Guid templateId = Guid.Empty;
		Guid instanceId = Guid.Empty;
		Guid orgId = Guid.Empty;
		List<WF_ACTIVITYDTO> activitys = null;
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "TEMPLATE_ID"))
		{
			templateId = Guid.Parse(dictionary["TEMPLATE_ID"]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ORG_ID"))
			{
				orgId = Guid.Parse(dictionary["ORG_ID"]);
			}
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_ID"))
			{
				instanceId = Guid.Parse(dictionary["INSTANCE_ID"]);
			}
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "RULE"))
			{
				rule = dictionary["RULE"];
			}
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITYS") && dictionary["ACTIVITYS"] != null)
			{
				activitys = dictionary["ACTIVITYS"].JsonDeserialize<List<WF_ACTIVITYDTO>>(new JsonConverter[0]);
			}
			List<WF_ACTIVITYDTO> collection = ServiceLocator.Instance.GetService<IWorkflowService>().GetAllActivitys(templateId, orgId, rule, instanceId, activitys);
			handlerResult.Data = collection.JsonSerialize();
		}
	}

	private void GetActivityById(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID"))
			{
				WF_ACTIVITYDTO single = ServiceLocator.Instance.GetService<IWorkflowService>().GetActivityById(Guid.Parse(dictionary["ACTIVITY_ID"]));
				handlerResult.Data = single.ToJson();
			}
		}
	}

	private void GetStartActivity(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "TEMPLATE_ID"))
			{
				WF_ACTIVITYDTO single = ServiceLocator.Instance.GetService<IWorkflowService>().GetStartActivity(Guid.Parse(dictionary["TEMPLATE_ID"]));
				handlerResult.Data = single.ToJson();
			}
		}
	}

	/// <summary>
	/// 创建工作流
	/// </summary>
	/// <param name="handlerResult"></param>
	/// <returns></returns>
	private void CreateWorkflow(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			CreateParameter_V2 parameter = base.RequestData.Data.JsonDeserialize<CreateParameter_V2>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().CreateWorkflow(parameter.WF_INSTANCE, parameter.SUBMIT).AdaptAsDTO<WF_INSTANCEDTO>()
					.JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 提交工作流
	/// </summary>
	/// <param name="handlerResult"></param>
	private void Submit(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			SubmitDTO parameter = base.RequestData.Data.JsonDeserialize<SubmitDTO>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().Submit(parameter).AdaptAsDTO<WF_INSTANCEDTO>()
					.JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 批量提交工作流
	/// </summary>
	/// <param name="handlerResult"></param>
	private void Submit_Batch(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		BatchCommitParamter batchCommit = base.RequestData.Data.JsonDeserialize<BatchCommitParamter>(new JsonConverter[0]);
		IList<WF_WORKITEMDTO> workitems = batchCommit.WF_WORKITEMDTOS;
		if (workitems.IsNull())
		{
			return;
		}
		User user2 = new User();
		user2.CURRENT_ORG_ID = SessionContext.UserInfo.BelongToOrgID;
		user2.CURRENT_USER_ID = SessionContext.UserInfo.UserID;
		user2.CURRENT_USER_NAME = SessionContext.UserInfo.UserName;
		user2.CURRENT_ORG_NAME = batchCommit.ORG_NAME;
		user2.PROXY_ORG_ID = SessionContext.UserInfo.BelongToOrgID;
		user2.PROXY_ORG_NAME = batchCommit.ORG_NAME;
		user2.PROXY_USER_ID = SessionContext.UserInfo.UserID;
		user2.PROXY_USER_NAME = SessionContext.UserInfo.UserName;
		user2.CLIENT_TYPE = 0m;
		User user = user2;
		foreach (WF_WORKITEMDTO item in workitems)
		{
			if (batchCommit.HANDLE_RESULT == HANDLE_RESULT.Adopt)
			{
				agree(item, user);
			}
			else if (batchCommit.HANDLE_RESULT == HANDLE_RESULT.Return)
			{
				disagree(item, user);
			}
		}
	}

	private void agree(WF_WORKITEMDTO item, User user)
	{
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(item.TEMPLATE_ID.Value);
		WF_INSTANCEDTO instanceDto = new InstanceService_v2().GetInstanceById(item.INSTANCE_ID.Value);
		SubmitDTO submitDto = new SubmitDTO();
		submitDto.HandleResult = HANDLE_RESULT.Adopt;
		submitDto.Suggestion = "";
		submitDto.WorkItemId = item.WORKITEM_ID;
		submitDto.CurrentActivity = single.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == item.ACTIVITY_ID).AdaptAsEntity<WF_ACTIVITY>();
		submitDto.InstanceId = item.INSTANCE_ID.Value;
		DriverParameter obj = GetNextDrivers(item.TEMPLATE_ID.Value, item.ACTIVITY_ID);
		submitDto.Drivers = obj.NEXT_DRIVER[0].Next[0];
		submitDto.Handler = user;
		ServiceLocator.Instance.GetService<IWorkflowService>().Submit(submitDto);
	}

	private void disagree(WF_WORKITEMDTO item, User user)
	{
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(item.TEMPLATE_ID.Value);
		WF_INSTANCEDTO instanceDto = new InstanceService_v2().GetInstanceById(item.INSTANCE_ID.Value);
		SubmitDTO submitDto = new SubmitDTO();
		submitDto.HandleResult = HANDLE_RESULT.Return;
		submitDto.Suggestion = "";
		submitDto.WorkItemId = item.WORKITEM_ID;
		submitDto.CurrentActivity = single.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == item.ACTIVITY_ID).AdaptAsEntity<WF_ACTIVITY>();
		submitDto.InstanceId = item.INSTANCE_ID.Value;
		DriverParameter obj = GetNextDrivers(item.TEMPLATE_ID.Value, item.ACTIVITY_ID);
		submitDto.Drivers = obj.BACK_DRIVER[0];
		submitDto.Handler = user;
		ServiceLocator.Instance.GetService<IWorkflowService>().Submit(submitDto);
	}

	/// <summary>
	/// 任务调整
	/// </summary>
	/// <param name="handlerResult"></param>
	private void Adjust(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			AdjustParameter parameter = base.RequestData.Data.JsonDeserialize<AdjustParameter>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().Adjust(parameter.WORKITEM_ID, parameter.HANDLE_USER);
				handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().Adjust(parameter.WORKITEM_ID, parameter.HANDLE_USER).AdaptAsDTO<WF_INSTANCEDTO>()
					.JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 重置流程
	/// </summary>
	/// <param name="handlerResult"></param>
	private void ResetWorkflow(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			ResetWorkflowParameter parameter = base.RequestData.Data.JsonDeserialize<ResetWorkflowParameter>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().ResetWorkflow(parameter.INSTANCE_ID, parameter.USER_ID);
				handlerResult.Data = new object().JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 重置流程
	/// </summary>
	/// <param name="handlerResult"></param>
	private void DeleteInstance(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ID"))
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().DeleteInstance(dictionary["ID"]);
				handlerResult.Data = new object().JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 更新实例名称
	/// </summary>
	/// <param name="handlerResult"></param>
	private void UpdateInstanceName(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_ID") && dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_NAME"))
			{
				ServiceLocator.Instance.GetService<IWorkflowService>().UpdateInstanceName(Guid.Parse(dictionary["INSTANCE_ID"]), dictionary["INSTANCE_NAME"]);
				handlerResult.Data = new object().JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 获取互斥步骤
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetReturnConstraintActivitys(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_ID") && dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID"))
			{
				List<ReturnConstraintActivitys> result = ServiceLocator.Instance.GetService<IWorkflowService>().GetReturnConstraintActivitys(Guid.Parse(dictionary["INSTANCE_ID"]), Guid.Parse(dictionary["ACTIVITY_ID"]));
				handlerResult.Data = result.JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 获取指定用户参与的流程集合
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetTemplateByUserId(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "USER_ID"))
			{
				List<WF_TEMPLATEDTO> result = ServiceLocator.Instance.GetService<IWorkflowService>().GetTemplateByUserId(Guid.Parse(dictionary["USER_ID"]));
				handlerResult.Data = result.JsonSerialize();
			}
		}
	}

	private void GetWorkflowMonitorByUser(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WorkflowMonitorParameter parameter = base.RequestData.Data.JsonDeserialize<WorkflowMonitorParameter>(new JsonConverter[0]);
			handlerResult.Data = ServiceLocator.Instance.GetService<IWorkflowService>().GetWorkflowMonitorByUser(parameter).JsonSerialize();
		}
	}
}
