using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Extend.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Extend.Application.Services;

namespace Richfit.Garnet.Module.Workflow.Extend.HandlerProcess.Handlers;

/// <summary>
/// 工作流扩展服务
/// </summary>
public class WorkflowExtendHandler : HandlerBase
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
				switch (action)
				{
				case "WorkflowExtend_GetInstanceById":
					GetInstanceById(handlerResult);
					break;
				case "WorkflowExtend_GetWorkItemPager":
					GetWorkItemPager(handlerResult);
					break;
				case "WorkflowExtend_GetWorkItemPager_Advance":
					GetWorkItemPager_Advance(handlerResult);
					break;
				case "WorkflowExtend_GetMyApplyByParameter":
					GetMyApplyByParameter(handlerResult);
					break;
				case "WorkflowExtend_GetMyWorkflowByParameter":
					GetMyWorkflowByParameter(handlerResult);
					break;
				case "WorkflowExtend_GetMyWorkflow":
					GetMyWorkflow(handlerResult);
					break;
				case "WorkflowExtend_GetMyWorkflowForMobile":
					GetMyWorkflowForMobile(handlerResult);
					break;
				case "WorkflowExtend_GetMyWorkflow_Advance":
					GetMyWorkflow_Advance(handlerResult);
					break;
				case "WorkflowExtend_GetWorkflowSearchByParameter":
					GetWorkflowSearchByParameter(handlerResult);
					break;
				case "WorkflowExtend_GetWorkflowMonitorByParameter":
					GetWorkflowMonitorByParameter(handlerResult);
					break;
				case "WorkflowExtend_GetWorkflowMonitorByParameterAdvance":
					GetWorkflowMonitorByParameterAdvance(handlerResult);
					break;
				case "WorkflowExtend_GetInstanceActivityByInstanceId":
					GetInstanceActivityByInstanceId(handlerResult);
					break;
				case "WorkflowExtend_SaveInstanceActivity":
					SaveInstanceActivity(handlerResult);
					break;
				case "WorkflowExtend_GetAllPackage":
					GetAllPackage(handlerResult);
					break;
				case "WorkflowExtend_GetFuture":
					GetFuture(handlerResult);
					break;
				case "WorkflowExtend_GetMyApplication":
					GetMyApplication(handlerResult);
					break;
				case "WorkflowExtend_GetMyApproval":
					GetMyApproval(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void GetMyApplication(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			handlerResult.Data = new WorkflowExtendService().GetMyApplication(parameter).JsonSerialize();
		}
	}

	private void GetMyApproval(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			handlerResult.Data = new WorkflowExtendService().GetMyApproval(parameter).JsonSerialize();
		}
	}

	private void SaveInstanceActivity(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			IList<WF_INSTANCE_ACTIVITYDTO> dto = base.RequestData.Data.JsonDeserialize<IList<WF_INSTANCE_ACTIVITYDTO>>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				new WorkflowExtendService().SaveInstanceActivity(dto);
			}
		}
	}

	private void GetInstanceActivityByInstanceId(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_ID"))
		{
			IList<WF_INSTANCE_ACTIVITYDTO> single = new WorkflowExtendService().GetInstanceActivityByInstanceId(Guid.Parse(dictionary["INSTANCE_ID"]));
			if (single != null)
			{
				handlerResult.Data = single.JsonSerialize();
			}
		}
	}

	private void GetInstanceById(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		int? workitem_Type = null;
		Guid activityId = Guid.Empty;
		if (!dictionary.Any((KeyValuePair<string, string> a) => a.Key == "INSTANCE_ID"))
		{
			return;
		}
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "HANDLE_TYPE") && dictionary["HANDLE_TYPE"] != null)
		{
			workitem_Type = int.Parse(dictionary["HANDLE_TYPE"]);
		}
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID") && dictionary["ACTIVITY_ID"] != null)
		{
			ref Guid reference = ref activityId;
			reference = new Guid(dictionary["ACTIVITY_ID"]);
		}
		WF_INSTANCEDTO single = new WorkflowExtendService().GetInstanceById(Guid.Parse(dictionary["INSTANCE_ID"]), workitem_Type);
		if (single == null)
		{
			return;
		}
		try
		{
			if (activityId != Guid.Empty)
			{
				single.WF_WORKITEM = single.WF_WORKITEM.Where((WF_WORKITEMDTO a) => a.ACTIVITY_ID == activityId).ToList();
			}
		}
		catch
		{
		}
		handlerResult.Data = single.ToJson();
	}

	private void GetMyWorkflowByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			MyWorkflowParameter parameter = base.RequestData.Data.JsonDeserialize<MyWorkflowParameter>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> value = new WorkflowExtendService().GetMyWorkflowByParameter(parameter);
			handlerResult.Data = value.ToJson();
		}
	}

	private void GetMyWorkflow(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> value = new WorkflowExtendService().GetMyWorkflow(parameter);
			handlerResult.Data = value.ToJson();
		}
	}

	private void GetMyWorkflowForMobile(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> value = new WorkflowExtendService().GetMyWorkflowForMobile(parameter);
			handlerResult.Data = value.ToJson();
		}
	}

	private void GetMyWorkflow_Advance(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> value = new WorkflowExtendService().GetMyWorkflow_Advance(parameter);
			handlerResult.Data = value.ToJson();
		}
	}

	private void GetWorkItemPager(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			if (parameter.ISMOBILE == 1m)
			{
				handlerResult.Data = new WorkflowExtendService().GetWorkItemPager(parameter, isMobile: true).JsonSerialize();
			}
			else
			{
				handlerResult.Data = new WorkflowExtendService().GetWorkItemPager(parameter).JsonSerialize();
			}
		}
	}

	private void GetWorkItemPager_Advance(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_WORKITEMDTO parameter = base.RequestData.Data.JsonDeserialize<WF_WORKITEMDTO>(new JsonConverter[0]);
			QueryResult<WF_WORKITEMDTO> value = new WorkflowExtendService().GetWorkItemPager_Advance(parameter);
			handlerResult.Data = value.ToJson();
		}
	}

	private void GetWorkflowMonitorByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WorkflowMonitorParameter parameter = base.RequestData.Data.JsonDeserialize<WorkflowMonitorParameter>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> collection = new WorkflowExtendService().GetWorkflowMonitorByParameter(parameter);
			handlerResult.Data = collection.JsonSerialize();
		}
	}

	private void GetWorkflowMonitorByParameterAdvance(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WorkflowMonitorParameter parameter = base.RequestData.Data.JsonDeserialize<WorkflowMonitorParameter>(new JsonConverter[0]);
			QueryResult<WF_INSTANCEDTO> collection = new WorkflowExtendService().GetWorkflowMonitorByParameterAdvance(parameter);
			handlerResult.Data = collection.JsonSerialize();
		}
	}

	private void GetWorkflowSearchByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WorkflowSearchParameter parameter = base.RequestData.Data.JsonDeserialize<WorkflowSearchParameter>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				QueryResult<WF_INSTANCEDTO> collection = new WorkflowExtendService().GetWorkflowSearch(parameter);
				handlerResult.Data = collection.JsonSerialize();
			}
		}
	}

	private void GetMyApplyByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			MyApplyParameter parameter = base.RequestData.Data.JsonDeserialize<MyApplyParameter>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				QueryResult<WF_INSTANCEDTO> collection = new WorkflowExtendService().GetMyApply(parameter);
				handlerResult.Data = collection.JsonSerialize();
			}
		}
	}

	private void GetAllPackage(ResponseData handlerResult)
	{
		handlerResult.Data = new WorkflowExtendService().GetAllPackage().JsonSerialize();
	}

	private void GetFuture(ResponseData handlerResult)
	{
		WF_ACTIVITYDTO activityDto = base.RequestData.Data.JsonDeserialize<WF_ACTIVITYDTO>(new JsonConverter[0]);
		WF_TEMPLATEDTO templateDto = WorkflowCacheManager.GetTemplateById(activityDto.TEMPLATE_ID);
		WF_TEMPLATEDTO result = new WF_TEMPLATEDTO();
		result.WF_ACTIVITY = new List<WF_ACTIVITYDTO>();
		result.WF_RULE = new List<WF_RULEDTO>();
		GetRule(ref result, templateDto, activityDto, activityDto.CREATOR, activityDto.RULE_COORDINATE);
		handlerResult.Data = result.JsonSerialize();
	}

	private void GetRule(ref WF_TEMPLATEDTO result, WF_TEMPLATEDTO templateDto, WF_ACTIVITYDTO activityDto, Guid orgId, string ruleExpress)
	{
		ResponseData responseData = AccessManager.ServiceAccess("Workflow", "Workflow_GetNextActivity", new
		{
			ACTIVITY_ID = activityDto.ACTIVITY_ID,
			RULE = ruleExpress
		}.JsonSerialize());
		List<NEXT_ACTIVITY> nextActivity = responseData.Data.JsonDeserialize<List<NEXT_ACTIVITY>>(new JsonConverter[0]);
		for (int i = 0; i < nextActivity.Count; i++)
		{
			NEXT_ACTIVITY item = nextActivity[i];
			IEnumerable<WF_ACTIVITYDTO> query = result.WF_ACTIVITY.Where((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == item.ACTIVITY.ACTIVITY_ID);
			if (query != null && query.Count() != 0)
			{
				continue;
			}
			IEnumerable<WF_RULEDTO> rule = templateDto.WF_RULE.Where(delegate(WF_RULEDTO a)
			{
				decimal? rULE_TYPE2 = a.RULE_TYPE;
				return rULE_TYPE2.GetValueOrDefault() == 0m && rULE_TYPE2.HasValue && a.FROM_ACTIVITY_ID == activityDto.ACTIVITY_ID && a.TO_ACTIVITY_ID == item.ACTIVITY.ACTIVITY_ID && a.ISDEL == 0m;
			});
			if ((rule == null || rule.Count() == 0) && i > 0)
			{
				rule = templateDto.WF_RULE.Where(delegate(WF_RULEDTO a)
				{
					decimal? rULE_TYPE = a.RULE_TYPE;
					return rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue && a.FROM_ACTIVITY_ID == nextActivity[i - 1].ACTIVITY.ACTIVITY_ID && a.TO_ACTIVITY_ID == item.ACTIVITY.ACTIVITY_ID && a.ISDEL == 0m;
				});
			}
			if (rule != null || rule.Count() > 0)
			{
				WF_RULEDTO r = rule.ToList()[0];
				if (result.WF_RULE.SingleOrDefault((WF_RULEDTO a) => a.RULE_ID == r.RULE_ID) == null)
				{
					result.WF_RULE.Add(r);
				}
			}
			result.WF_ACTIVITY.Add(item.ACTIVITY);
			decimal? aCTIVITY_TYPE = item.ACTIVITY.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == 0m) || !aCTIVITY_TYPE.HasValue)
			{
				aCTIVITY_TYPE = item.ACTIVITY.ACTIVITY_TYPE;
				if (!(aCTIVITY_TYPE.GetValueOrDefault() == 100m) || !aCTIVITY_TYPE.HasValue)
				{
					continue;
				}
			}
			aCTIVITY_TYPE = item.ACTIVITY.ACTIVITY_TYPE;
			if (aCTIVITY_TYPE.GetValueOrDefault() == 0m && aCTIVITY_TYPE.HasValue)
			{
				responseData = AccessManager.ServiceAccess("Workflow", "Workflow_Participant_GetActivityParticipant", new
				{
					ACTIVITY_ID = item.ACTIVITY.ACTIVITY_ID,
					ORG_ID = orgId,
					PARTICIPANT_TYPE = 0,
					TEMPLATE_ID = templateDto.TEMPLATE_ID
				}.JsonSerialize());
				if (!string.IsNullOrEmpty(responseData.Data))
				{
					item.ACTIVITY.HANDLER_USER = responseData.Data.JsonDeserialize<List<TREE_NODE>>(new JsonConverter[0]);
				}
			}
			GetRule(ref result, templateDto, item.ACTIVITY, orgId, ruleExpress);
		}
	}
}
