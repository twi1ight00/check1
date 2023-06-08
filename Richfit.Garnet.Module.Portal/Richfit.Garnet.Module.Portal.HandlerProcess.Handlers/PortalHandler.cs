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

public class PortalHandler : HandlerBase
{
	private IPortalService portalService = ServiceLocator.Instance.GetService<IPortalService>();

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
				case "Portal_GetAllPortalets":
					GetAllPortalets(handlerResult);
					break;
				case "Portal_GetMyPortalets":
					GetMyPortalets(handlerResult);
					break;
				case "Portal_UpdateMyPortalets":
					UpdateMyPortalets(handlerResult);
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

	private void GetAllPortalets(ResponseData handlerResult)
	{
		handlerResult.Data = portalService.GetPortals().ToJson();
	}

	private void UpdateMyPortalets(ResponseData handlerResult)
	{
		List<SYS_USER_PORTALDTO> dtoList = DTOBase.DeserializeListFromJson<SYS_USER_PORTALDTO>(base.RequestData.Data) as List<SYS_USER_PORTALDTO>;
		portalService.UpdateMyPortals(dtoList);
	}

	private void GetMyPortalets(ResponseData handlerResult)
	{
		handlerResult.Data = portalService.GetMyPortals().ToJson();
	}
}
