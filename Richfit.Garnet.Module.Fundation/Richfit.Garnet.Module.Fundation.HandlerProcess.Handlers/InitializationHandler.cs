using System;
using System.Collections.Generic;
using System.Web;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;
using Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

namespace Richfit.Garnet.Module.Fundation.HandlerProcess.Handlers;

/// <summary>
/// 系统初始化处理
/// </summary>
public class InitializationHandler : HandlerBase
{
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData responseData = new ResponseData();
		try
		{
			responseData.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "System_GetMyMenus":
					GetUserMenus(responseData);
					break;
				case "System_GetMyBusiness":
					GetUserBusiness(responseData);
					break;
				case "System_GetInitializationConfig":
					GetInitializationConfig(responseData);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			responseData = HandleException(ex);
		}
		context.Response.Write(responseData.ToJson());
	}

	private void GetUserMenus(ResponseData responseData)
	{
		IList<MenuDTO> userMenus = BusinessMenuManager.GetCurrentUserMenus();
		responseData.Data = userMenus.ToJson();
	}

	private void GetUserBusiness(ResponseData responseData)
	{
		IList<BusinessDTO> userBusiness = BusinessMenuManager.GetCurrentUserBusiness();
		responseData.Data = userBusiness.ToJson();
	}

	private void GetInitializationConfig(ResponseData responseData)
	{
		InitializationConfig config = InitializationConfigProvider.Read();
		responseData.Data = config.JsonSerialize();
	}
}
