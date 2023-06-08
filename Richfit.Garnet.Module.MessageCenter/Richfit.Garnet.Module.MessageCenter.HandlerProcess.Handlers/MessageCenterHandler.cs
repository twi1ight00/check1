using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;

namespace Richfit.Garnet.Module.MessageCenter.HandlerProcess.Handlers;

public class MessageCenterHandler : HandlerBase
{
	private IMessageCenterService messageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();

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
				case "MSG_CENTER_AddMessage":
					AddMessage(handlerResult);
					break;
				case "MSG_CENTER_GetMessageByCurrentUser":
					GetMessageByCurrentUser(handlerResult);
					break;
				case "MSG_CENTER_GetMessageByCurrentUser_Advance":
					GetMessageByCurrentUserAdvance(handlerResult);
					break;
				case "MSG_CENTER_ReadMessage":
					ReadMessage(handlerResult);
					break;
				case "MSG_CENTER_ReadIM":
					ReadIM(handlerResult);
					break;
				case "MSG_CENTER_DeleteMessage":
					DeleteMessage(handlerResult);
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

	private void DeleteMessage(ResponseData handlerResult)
	{
		MSG_CENTERDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_CENTERDTO>(new JsonConverter[0]);
		messageCenterService.DeleteMessage(parameter);
	}

	private void GetMessageByCurrentUserAdvance(ResponseData handlerResult)
	{
		MSG_CENTERDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_CENTERDTO>(new JsonConverter[0]);
		handlerResult.Data = messageCenterService.GetMessageByCurrentUserAdvance(parameter).JsonSerialize();
	}

	private void ReadIM(ResponseData handlerResult)
	{
		Dictionary<string, string> dic = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid id = new Guid(dic["ID"]);
		handlerResult.Data = messageCenterService.ReadIM(id).JsonSerialize();
	}

	private void ReadMessage(ResponseData handlerResult)
	{
		Dictionary<string, List<Guid>> dic = base.RequestData.Data.JsonDeserialize<Dictionary<string, List<Guid>>>(new JsonConverter[0]);
		List<Guid> id = dic["IDs"];
		handlerResult.Data = messageCenterService.ReadMessage(id).JsonSerialize();
	}

	private void AddMessage(ResponseData handlerResult)
	{
	}

	private void GetMessageByCurrentUser(ResponseData handlerResult)
	{
		MSG_CENTERDTO parameter = base.RequestData.Data.JsonDeserialize<MSG_CENTERDTO>(new JsonConverter[0]);
		handlerResult.Data = messageCenterService.GetMessageByCurrentUser(parameter).JsonSerialize();
	}
}
