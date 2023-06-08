using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

namespace Richfit.Garnet.Module.Fundation.HandlerProcess.Handlers;

/// <summary>
/// 系统服务处理
/// </summary>
public class SystemServiceHandler : HandlerBase
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
				case "System_OnlineCount":
					responseData.Type = ResponseDataType.Text;
					responseData.Data = Singleton<SessionManager>.Instance.SessionCount.ToString();
					break;
				case "System_GetUserSessionInfo":
					GetUserSessionInfo(responseData);
					break;
				case "System_GetUserOrganization":
					GetUserOrganization(responseData);
					break;
				case "System_ChangeOrganization":
					ChangeOrganization(responseData);
					break;
				case "System_CreateGuid":
					CreateGuid(responseData);
					break;
				case "System_GetReloadCache":
					GetReloadCache(responseData);
					break;
				case "System_CacheReload":
					CacheReload(responseData);
					break;
				case "System_GetWeather":
					GetWeather(responseData);
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

	private void GetWeather(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		var obj = new
		{
			Html = HttpPost(dictionary["URL"], dictionary.ContainsKey("CODE") ? dictionary["CODE"] : "")
		};
		handlerResult.Data = obj.JsonSerialize();
	}

	private string HttpPost(string Url, string code)
	{
		try
		{
			if (code == "")
			{
				code = "GB2312";
			}
			WebRequest wReq = WebRequest.Create(Url);
			WebResponse wResp = wReq.GetResponse();
			Stream respStream = wResp.GetResponseStream();
			using StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding(code));
			return GlobalObject.escape(reader.ReadToEnd());
		}
		catch (Exception)
		{
		}
		return "";
	}

	private void GetUserSessionInfo(ResponseData responseData)
	{
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			userSessionInfo = userSessionInfo.MaskInfo();
			responseData.Data = userSessionInfo.JsonSerialize();
		}
	}

	private void GetUserOrganization(ResponseData responseData)
	{
		IInitializationService initialService = ServiceLocator.Instance.GetService<IInitializationService>();
		responseData.Data = initialService.GetUserOrganization(SessionContext.UserInfo.UserID).ToJson();
	}

	private void ChangeOrganization(ResponseData responseData)
	{
		string orgId = base.RequestData.Data;
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			userSessionInfo.BelongToOrgID = Guid.Parse(orgId);
		}
		responseData.Type = ResponseDataType.Text;
		responseData.Data = orgId;
	}

	/// <summary>
	/// 创建新的Guid (pingxi fang Add 2012-04-24)
	/// </summary>
	/// <param name="responseData"></param>
	private void CreateGuid(ResponseData responseData)
	{
		responseData.Data = Guid.NewGuid().JsonSerialize();
	}

	private void GetReloadCache(ResponseData responseData)
	{
		string cacheMappingConfig = ConfigurationManager.System.Settings.GetValue("CacheMappingConfig");
		responseData.Data = cacheMappingConfig;
	}

	private void CacheReload(ResponseData responseData)
	{
		string cacheFullName = base.RequestData.Data;
		CacheLoaderManager.ReLoad(cacheFullName);
	}
}
