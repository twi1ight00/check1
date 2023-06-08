using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Workflow.Application.Components;

namespace Richfit.Garnet.Module.Workflow.HandlerProcess.Handlers;

/// <summary>
/// ParticipantHandler 的摘要说明
/// </summary>
public class ParticipantHandler : HandlerBase
{
	/// <summary>
	/// 组接口实例化
	/// </summary>
	private ParticipantService ParticipantService = new ParticipantService();

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
				case "Workflow_Participant_GetOrgTree":
					GetOrgTree(ref handlerResult);
					break;
				case "Workflow_Participant_GetRoleList":
					GetRoleList(ref handlerResult);
					break;
				case "Workflow_Participant_GetActivityParticipant":
					GetActivityParticipant(ref handlerResult);
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

	private void GetRoleList(ref ResponseData handlerResult)
	{
		handlerResult.Data = ParticipantService.GetRoleList(base.RequestData).JsonSerialize();
	}

	private void GetOrgTree(ref ResponseData handlerResult)
	{
		handlerResult.Data = ParticipantService.GetOrgTree(base.RequestData).JsonSerialize();
	}

	/// <summary>
	/// 获取当前活动参与人
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetActivityParticipant(ref ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (!dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ACTIVITY_ID"))
		{
			return;
		}
		Guid activityId = Guid.Parse(dictionary["ACTIVITY_ID"]);
		Guid? instanceId = null;
		if (dictionary.ContainsKey("INSTANCE_ID") && !string.IsNullOrEmpty(dictionary["INSTANCE_ID"]))
		{
			instanceId = Guid.Parse(dictionary["INSTANCE_ID"]);
		}
		Guid orgId;
		if (!dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ORG_ID"))
		{
			if (instanceId.HasValue)
			{
				return;
			}
			orgId = SessionContext.UserInfo.BelongToOrgID;
		}
		else
		{
			orgId = Guid.Parse(dictionary["ORG_ID"]);
		}
		string submitType = "0";
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "SUBMIT_TYPE"))
		{
			submitType = dictionary["SUBMIT_TYPE"];
		}
		string participantType = "0";
		if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "PARTICIPANT_TYPE"))
		{
			participantType = dictionary["PARTICIPANT_TYPE"];
		}
		if (participantType == "0")
		{
			handlerResult.Data = ParticipantService.GetActivityParticipantOrgAndUser(activityId, orgId, instanceId, submitType, dictionary["TEMPLATE_ID"], dictionary.ContainsKey("FORMDATA") ? dictionary["FORMDATA"] : "").JsonSerialize();
		}
		else
		{
			handlerResult.Data = ParticipantService.GetActivityParticipantOnlyUser(activityId, orgId, instanceId, submitType).JsonSerialize();
		}
	}
}
