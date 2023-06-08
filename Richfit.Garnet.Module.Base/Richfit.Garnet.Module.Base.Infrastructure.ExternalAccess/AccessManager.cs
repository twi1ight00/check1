using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;

namespace Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;

/// <summary>
/// 访问管理
/// </summary>
public static class AccessManager
{
	/// <summary>
	/// 外部访问配置列表
	/// </summary>
	private static List<AccessConfig> accessConfigCache;

	/// <summary>
	/// 初始化
	/// </summary>
	static AccessManager()
	{
		accessConfigCache = new List<AccessConfig>();
		string externalAccessConfig = ConfigurationManager.System.Settings.ExternalAccessConfig;
		accessConfigCache = externalAccessConfig.JsonDeserialize<List<AccessConfig>>(new JsonConverter[0]);
	}

	/// <summary>
	/// 根据配置的Key值，得到服务地址
	/// </summary>
	/// <param name="systemConfigKey"></param>
	/// <returns></returns>
	public static AccessConfig GetConfig(string systemConfigKey)
	{
		return accessConfigCache.Where((AccessConfig x) => x.ConfigKey.Equals(systemConfigKey)).FirstOrDefault();
	}

	/// <summary>
	/// 服务访问
	/// </summary>
	/// <param name="systemConfigKey">配置文件中指定的外部系统的名称，如PMIS</param>
	/// <param name="actionCode">调用的ActionCode名称</param>
	/// <param name="data">调用的数据</param>
	/// <returns></returns>
	public static ResponseData ServiceAccess(string systemConfigKey, string actionCode, string data, Guid? userToken = null, Type type = null)
	{
		ResponseData responseData = null;
		if (!string.IsNullOrEmpty(systemConfigKey) && !string.IsNullOrEmpty(actionCode))
		{
			AccessConfig acccessConfig = GetConfig(systemConfigKey);
			if (acccessConfig != null)
			{
				string token = acccessConfig.Token;
				if (userToken.HasValue)
				{
					token = userToken.ToString();
				}
				string serviceUri = acccessConfig.AccessInfo.Url;
				if (string.IsNullOrEmpty(serviceUri))
				{
					serviceUri = SessionContext.ServerUrl + "/Handlers/do.ashx";
					acccessConfig.AccessInfo.Url = serviceUri;
				}
				if (!string.IsNullOrEmpty(token) || acccessConfig.IsShake == "0")
				{
					RequestData requestData2 = new RequestData();
					requestData2.TokenGuid = token;
					requestData2.ActionCode = actionCode;
					requestData2.Data = data;
					RequestData requestData = requestData2;
					responseData = AccessProvider.Access(serviceUri, requestData);
					if (responseData != null && responseData.Code.Equals("Public.E_0006"))
					{
						acccessConfig.Token = string.Empty;
						responseData = ServiceAccess(systemConfigKey, actionCode, data);
					}
				}
				else
				{
					token = SystemShake(acccessConfig);
					if (!string.IsNullOrEmpty(token))
					{
						acccessConfig.Token = token;
						responseData = ServiceAccess(systemConfigKey, actionCode, data);
					}
					else
					{
						responseData.Code = "Public.E_0012";
						responseData.Message = "系统握手发生错误错误！";
					}
				}
			}
			else
			{
				responseData.Code = "Public.E_0011";
				responseData.Message = "外部访问配置错误！";
			}
		}
		return responseData;
	}

	/// <summary>
	/// 系统握手
	/// </summary>
	/// <param name="acccessConfig"></param>
	/// <returns></returns>
	private static string SystemShake(AccessConfig acccessConfig)
	{
		if (acccessConfig != null)
		{
			Dictionary<string, string> loginDic = new Dictionary<string, string>();
			loginDic.Add("User", acccessConfig.AccessInfo.User);
			loginDic.Add("Password", acccessConfig.AccessInfo.Password);
			RequestData requestData2 = new RequestData();
			requestData2.TokenGuid = string.Empty;
			requestData2.ActionCode = "SystemLogin_ExternalSystemLogin";
			requestData2.Data = loginDic.JsonSerialize();
			RequestData requestData = requestData2;
			string serviceUri = acccessConfig.AccessInfo.Url;
			if (string.IsNullOrEmpty(serviceUri))
			{
				serviceUri = SessionContext.ServerUrl + "/Handlers/do.ashx";
				acccessConfig.AccessInfo.Url = serviceUri;
			}
			ResponseData responseData = null;
			responseData = AccessProvider.Access(serviceUri, requestData);
			if (responseData.Code.Equals("Public.I_0001"))
			{
				return responseData.Data;
			}
		}
		return null;
	}
}
