using System;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.SiteMessage.Application.DTO;
using Richfit.Garnet.Module.SiteMessage.Application.Services;

namespace Richfit.Garnet.Module.SiteMessage.HandlerProcess.Handlers;

public class SiteMessageHandler : HandlerBase
{
	private ISiteMessageService msgService = ServiceLocator.Instance.GetService<ISiteMessageService>();

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
				case "MSG_GetSendMessage":
					GetSendMessage(handlerResult);
					break;
				case "MSG_GetReceiveMessage":
					GetReceiveMessage(handlerResult);
					break;
				case "MSG_SendMessage":
					SendMessage(handlerResult);
					break;
				case "MSG_GetAuthorizationUser":
					GetAuthorizationUser(handlerResult);
					break;
				case "MSG_GetMessageById":
					GetMessageById(handlerResult);
					break;
				case "MSG_DeleteMessage":
					DeleteMessage(handlerResult);
					break;
				case "MSG_ChangeMessageStatus":
					ChangeMessageStatus(handlerResult);
					break;
				case "MSG_GetReceiveMessage_Advance":
					GetReceiveMessageAdvance(handlerResult);
					break;
				case "MSG_SendMessage_Advance":
					SendMessageAdvance(handlerResult);
					break;
				case "MSG_GetMessageStatusByMsgId":
					GetMessageStatusByMsgId(handlerResult);
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

	private void GetMessageStatusByMsgId(ResponseData handlerResult)
	{
		MSG_MESSAGE_USERDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGE_USERDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetMessageStatusByMsgId(parameter).JsonSerialize();
	}

	private void ChangeMessageStatus(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.ChangeMessageStatus(parameter).JsonSerialize();
	}

	private void DeleteMessage(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.DeleteMessage(parameter).JsonSerialize();
	}

	private void GetMessageById(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetMessageById(parameter).JsonSerialize();
	}

	private void GetAuthorizationUser(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetAuthorizationUser(parameter).JsonSerialize();
	}

	private void GetSendMessage(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetSendMessage(parameter).JsonSerialize();
	}

	private void GetReceiveMessageAdvance(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetReceiveMessageAdvance(parameter).JsonSerialize();
	}

	private void SendMessageAdvance(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.SendMessageAdvance(parameter).JsonSerialize();
	}

	private void SendMessage(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.SendMessage(parameter).JsonSerialize();
	}

	private void GetReceiveMessage(ResponseData handlerResult)
	{
		MSG_MESSAGEDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_MESSAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = msgService.GetReceiveMessage(parameter).JsonSerialize();
	}
}
