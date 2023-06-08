using System;
using System.Collections.Generic;
using System.Web;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Portal.Application.DTO;
using Richfit.Garnet.Module.Portal.Application.Services;

namespace Richfit.Garnet.Module.Portal.HandlerProcess.Handlers;

public class ShortCutHandler : HandlerBase
{
	private IShortCutService shortcutService = ServiceLocator.Instance.GetService<IShortCutService>();

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
				case "Portal_GetMyShortcuts":
					GetMyShortcuts(handlerResult);
					break;
				case "Portal_UpdateMyShortcuts":
					UpdateMyShortcuts(handlerResult);
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

	private void GetMyShortcuts(ResponseData handlerResult)
	{
		handlerResult.Data = shortcutService.GetShortcuts().ToJson();
	}

	private void UpdateMyShortcuts(ResponseData handlerResult)
	{
		List<SYS_SHORTCUTDTO> dtoList = DTOBase.DeserializeListFromJson<SYS_SHORTCUTDTO>(base.RequestData.Data) as List<SYS_SHORTCUTDTO>;
		shortcutService.UpdateShortcuts(dtoList);
	}
}
