using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

namespace webapp.Handlers;

public class IAMPushAccount : IHttpHandler
{
	private static readonly ILogger logger = LoggerManager.GetLogger();

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		IAMPushAccountRespondData respondData = new IAMPushAccountRespondData();
		try
		{
			StreamReader reader = new StreamReader(context.Request.InputStream);
			string requestBody = reader.ReadToEnd();
			reader.Close();
			IAMPushAccountRequestData requestData = requestBody.JsonDeserialize<IAMPushAccountRequestData>(new JsonConverter[0]);
			string accountName = requestData.accountName;
			switch (requestData.status)
			{
			case "DELETE":
				deleteAccount(accountName, out respondData);
				break;
			case "UPSERT":
				upsertAccount(requestData, out respondData);
				break;
			case "FROZEN":
			{
				bool enabled = requestData.enabled;
				frozenAccount(accountName, enabled, out respondData);
				break;
			}
			}
		}
		catch (ValidationException ve)
		{
			respondData.code = "APP_ERROR";
			respondData.message = ve.ValidateMessages.ToString();
		}
		catch (Exception e)
		{
			respondData.code = "APP_ERROR";
			respondData.message = "系统发生未知错误";
			logger.Error("IAM推送用户账户发生错误: " + e.Message);
		}
		finally
		{
			context.Response.ContentType = "application/json";
			context.Response.Write(JsonConvert.SerializeObject(respondData));
		}
	}

	private void deleteAccount(string accountName, out IAMPushAccountRespondData respondData)
	{
		ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
		UserDTO sysUser = service.GetUserBySapId(accountName);
		if (sysUser != null)
		{
			service.RemoveUserFromIAM(sysUser.USER_ID);
			respondData = new IAMPushAccountRespondData
			{
				code = "SUCCESS"
			};
		}
		else
		{
			respondData = new IAMPushAccountRespondData
			{
				code = "APP_ERROR",
				message = "用户不存在"
			};
		}
	}

	private void frozenAccount(string accountName, bool enabled, out IAMPushAccountRespondData respondData)
	{
		ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
		UserDTO sysUser = service.GetUserBySapId(accountName);
		if (sysUser != null)
		{
			if (enabled)
			{
				service.EnableUserUser(sysUser.USER_ID.ToString());
			}
			else
			{
				service.ForbiddenUser(sysUser.USER_ID.ToString());
			}
			respondData = new IAMPushAccountRespondData
			{
				code = "SUCCESS"
			};
		}
		else
		{
			respondData = new IAMPushAccountRespondData
			{
				code = "APP_ERROR",
				message = "用户不存在"
			};
		}
	}

	private void upsertAccount(IAMPushAccountRequestData requestData, out IAMPushAccountRespondData respondData)
	{
		Dictionary<string, string> attributes = requestData.mappingAttr.Union(requestData.extAttr).ToDictionary((KeyValuePair<string, string> k) => k.Key, (KeyValuePair<string, string> v) => v.Value);
		ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
		UserDTO sysUser = service.GetUserBySapId(requestData.accountName);
		if (sysUser != null)
		{
			respondData = new IAMPushAccountRespondData
			{
				code = "SUCCESS"
			};
		}
		else
		{
			service.AddUserFromIAM(requestData.accountName, attributes);
			respondData = new IAMPushAccountRespondData
			{
				code = "SUCCESS"
			};
		}
	}
}
