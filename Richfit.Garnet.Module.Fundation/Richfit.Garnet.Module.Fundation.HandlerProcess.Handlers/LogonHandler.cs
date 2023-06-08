using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.Logon;

namespace Richfit.Garnet.Module.Fundation.HandlerProcess.Handlers;

/// <summary>
/// 系统登陆处理
/// </summary>
public class LogonHandler : HandlerBase
{
	/// <summary>
	///             登陆接口实例化
	/// </summary>
	private ILogonService logonService = ServiceLocator.Instance.GetService<ILogonService>();

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
				case "SystemLogin_Login":
					Login(responseData);
					break;
				case "SystemLogin_Logout":
					LogOut(responseData);
					break;
				case "SystemLogin_ExternalSystemLogin":
					ExternalSystemLogin(responseData);
					break;
				case "SystemLogin_GetLoginConfig":
					GetLoginConfig(responseData);
					break;
				case "SystemLogin_GetServerDateTime":
					GetServerDateTime(responseData);
					break;
				case "SystemLogin_CheckUpdate":
					CheckUpdate(responseData);
					break;
				case "SystemLogin_Unbind":
					unbind(responseData);
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

	private void GetServerDateTime(ResponseData responseData)
	{
		responseData.Data = DateTime.Now.ToString().JsonSerialize();
	}

	/// <summary>
	/// 系统登陆
	/// </summary>
	/// <param name="responseData"></param>
	private void Login(ResponseData responseData)
	{
		LogonDTO loginDTO = DTOBase.DeserializeFromJson<LogonDTO>(base.RequestData.Data);
		HandlerBase.log.Debug($"------------处理用户帐号为{loginDTO.LOGON_NAME}登陆请求开始-----------");
		LogonContext context = logonService.Login(loginDTO);
		if (context.Success)
		{
			if (loginDTO.IS_MOBILE == 1)
			{
				HandlerBase.log.Info($"------------用户帐号为{loginDTO.LOGON_NAME}通过移动设备登录系统--时间：{DateTime.Now.ToString()}---------");
			}
			Guid token = context.Token;
			if (token != Guid.Empty)
			{
				responseData.Type = ResponseDataType.Text;
				responseData.Data = new
				{
					TokenGuid = token.ToString(),
					USER_ID = SessionContext.UserInfo.UserID,
					UserName = SessionContext.UserInfo.UserName,
					OrgId = SessionContext.UserInfo.BelongToOrgID,
					EXTEND1 = SessionContext.UserInfo.EXTEND1,
					IsSuperUser = SessionContext.UserInfo.IsSuperUser
				}.JsonSerialize();
			}
			else if (!context.IsForbidden)
			{
				responseData.Code = "SystemManagement.Login.E_0001";
				responseData.Message = "登陆帐号或密码错误";
			}
			else
			{
				responseData.Code = "SystemManagement.Login.E_0003";
			}
		}
		else
		{
			responseData.Code = context.Code;
			responseData.Message = context.Messages.JoinString(";");
		}
		HandlerBase.log.Debug($"------------处理用户帐号为{loginDTO.LOGON_NAME}登陆请求结束-----------");
	}

	/// <summary>
	/// 退出登录
	/// </summary>
	private void LogOut(ResponseData responseData)
	{
		logonService.LogOut();
		responseData.Data = new object().JsonSerialize();
	}

	/// <summary>
	/// 获得登陆配置信息
	/// </summary>
	/// <param name="responseData"></param>
	private void GetLoginConfig(ResponseData responseData)
	{
		string culture = base.RequestData.Data;
		LogonConfig config = LogonConfigProvider.Read(culture);
		responseData.Data = config.JsonSerialize();
	}

	private void unbind(ResponseData responseData)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid USERID = (string.IsNullOrEmpty(dictionary["USER_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USER_ID"]));
		string DEVICEINFO = (string.IsNullOrEmpty(dictionary["DEVICEINFO"]) ? string.Empty : dictionary["DEVICEINFO"].ToString());
		responseData.Data = logonService.unbind(USERID, DEVICEINFO).ToString();
	}

	/// <summary>
	/// 外部系统登陆
	/// </summary>
	/// <param name="responseData"></param>
	private void ExternalSystemLogin(ResponseData responseData)
	{
		Dictionary<string, string> requestDic = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = requestDic["User"];
		string userPassword = requestDic["Password"];
		if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPassword))
		{
			responseData.Code = "Public.E_0003";
			return;
		}
		ILogonService logonService = ServiceLocator.Instance.GetService<ILogonService>();
		userPassword = userPassword.Base64Decode().DecryptText();
		HandlerBase.log.Debug($"------------处理外部系统帐号为{userId}登陆请求开始-----------");
		Guid token = logonService.Login(null, userId, userPassword, 0);
		if (token != Guid.Empty)
		{
			responseData.Type = ResponseDataType.Text;
			responseData.Data = token.ToString();
			HandlerBase.log.Debug($"------------处理外部系统帐号为{userId}登陆请求验证通过-----------");
		}
		else
		{
			responseData.Code = "Public.E_0006";
			HandlerBase.log.Debug($"------------处理外部系统帐号为{userId}登陆请求验证不通过-----------");
		}
	}

	/// <summary>
	/// 检查移动端更新
	/// </summary>
	/// <param name="responseData"></param>
	private void CheckUpdate(ResponseData responseData)
	{
		VersionInfoDTO currentVersion = DTOBase.DeserializeFromJson<VersionInfoDTO>(base.RequestData.Data);
		VersionInfoDTO updateVersion = logonService.GetVersionInfo(currentVersion.OS);
		if (updateVersion != null)
		{
			string[] currents = currentVersion.CURRENT_VERSION.Split(".");
			string[] updates = updateVersion.CURRENT_VERSION.Split(".");
			for (int i = 0; i < updates.Length; i++)
			{
				if (currents.Length <= i)
				{
					continue;
				}
				int c = int.Parse(currents[i]);
				int u = int.Parse(updates[i]);
				if (u > c)
				{
					if (i <= 1)
					{
						updateVersion.NEED_UPDATE = 2;
					}
					else
					{
						updateVersion.NEED_UPDATE = 1;
					}
					break;
				}
			}
			if (updateVersion.NEED_UPDATE > 0)
			{
				responseData.Data = updateVersion.JsonSerialize();
			}
			else
			{
				responseData.Data = new VersionInfoDTO().JsonSerialize();
			}
		}
		else
		{
			responseData.Data = new VersionInfoDTO().JsonSerialize();
		}
	}
}
