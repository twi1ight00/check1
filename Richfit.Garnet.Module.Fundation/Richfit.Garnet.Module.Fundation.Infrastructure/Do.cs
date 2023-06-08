using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Web.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.Services.Action;

namespace Richfit.Garnet.Module.Fundation.Infrastructure;

/// <summary>
/// 系统请求处理统一接口
/// </summary>
public class Do : IHttpHandler
{
	/// <summary>
	/// 请求数据参数名称
	/// </summary>
	public const string RequestDataName = "RequestData";

	/// <summary>
	/// 日志记录器
	/// </summary>
	private static readonly ILogger log = LoggerManager.GetLogger();

	/// <summary>
	/// 错误日志对象
	/// </summary>
	private static readonly ILogger errorLog = LoggerManager.GetLogger("Exception");

	/// <summary>
	/// 是否可重用
	/// </summary>
	public bool IsReusable => false;

	/// <summary>
	/// 处理请求
	/// </summary>
	/// <param name="context"></param>
	public void ProcessRequest(HttpContext context)
	{
		string[] super = new string[6] { "MSG_CENTER_GetMessageByCurrentUser", "System_OnlineCount", "MSG_CENTER_ReadIM", "Supervise_QueryTaskList", "MSG_GetReceiveMessage", "WorkflowExtend_GetWorkItemPager" };
		context.Response.ContentType = "text/plain";
		RequestData requestData = null;
		try
		{
			log.Debug("Do-->请求参数转化为对象开始");
			string requestDataText = string.Empty;
			string CustomerIP = context.Request.ServerVariables["REMOTE_ADDR"];
			if (context.Request.PathInfo.IsNotNullAndEmpty())
			{
				Match i = Regex.Match(context.Request.PathInfo, "/([^/]*)(/.*)?");
				if (i.IsNotNull() && i.Groups.Count >= 2)
				{
					requestDataText = Encoding.GetEncoding(936).GetString(Convert.FromBase64String(i.Groups[1].Value));
					i = Regex.Match(requestDataText, "RequestData=(.*)");
					if (i.IsNotNull() && i.Groups.Count >= 2)
					{
						requestDataText = i.Groups[1].Value;
					}
				}
			}
			else
			{
				requestDataText = context.Request.QueryParam("RequestData");
			}
			requestData = ConvertTo(requestDataText);
			string clientIp = context.Request.UserHostAddress;
			string trustedIP = ConfigurationManager.System.Settings.GetSetting<string>("trustedIP");
			string[] ips = trustedIP.Split(',');
			log.Info("客户端访问IP：" + clientIp);
			if (requestData.IsMobile != 1)
			{
				bool flag = true;
				string[] array = ips;
				foreach (string ip in array)
				{
					if (clientIp.StartsWith(ip))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					context.Response.Write(new ResponseData("Public.E_0007").ToJson());
					return;
				}
			}
			log.Debug("Do-->请求参数转化为对象结束，RequestData+" + requestData.ToString());
			UserSessionInfo userInfo = null;
			log.Debug("Do-->检测ActionCode开始");
			log.Debug("Do-->检测ActionCode成功");
			log.Debug("Do-->检测Token开始");
			if (string.IsNullOrWhiteSpace(requestData.TokenGuid) || requestData.ActionCode.StartsWith("SystemLogin_"))
			{
				if (!CacheLoaderManager.IsIncludeActionCode(requestData.ActionCode))
				{
					if (!requestData.ActionCode.StartsWith("SystemLogin_"))
					{
						log.Debug("Do-->无Token，检测失败");
						context.Response.Write(new ResponseData("Public.E_0003").ToJson());
						return;
					}
					log.Debug("Do-->检测无Token成功");
					if (requestData.ActionCode.Equals("SystemLogin_NoPwd"))
					{
						userInfo = Singleton<SessionManager>.Instance.GetUserSessionInfo(Guid.Parse(requestData.TokenGuid));
						if (userInfo == null)
						{
							log.Debug("Do-->获取用户Session信息失败");
							log.Debug("当前请求Session中的TokenGuid：" + Singleton<SessionManager>.Instance.GetCurrentSessionToken());
							log.Debug("当前请求TokenGuid：" + requestData.TokenGuid);
							log.Debug("Do-->TokenGuid与Session中记录不一致,请求ActionCode为：" + requestData.ActionCode);
							context.Response.Write(new ResponseData("Public.E_0006").ToJson());
						}
						else
						{
							ResponseData responseData = new ResponseData("Public.I_0001");
							responseData.Data = userInfo.JsonSerialize();
							context.Response.Write(responseData.JsonSerialize());
						}
						return;
					}
				}
			}
			else
			{
				log.Debug("Do-->检测有Token成功");
				log.Debug("Do-->获取用户Session信息开始");
				userInfo = Singleton<SessionManager>.Instance.GetUserSessionInfo(Guid.Parse(requestData.TokenGuid));
				if (userInfo == null)
				{
					log.Debug("Do-->获取用户Session信息失败");
					log.Debug("当前请求Session中的TokenGuid：" + Singleton<SessionManager>.Instance.GetCurrentSessionToken());
					log.Debug("当前请求TokenGuid：" + requestData.TokenGuid);
					log.Debug("Do-->TokenGuid与Session中记录不一致,请求ActionCode为：" + requestData.ActionCode);
					context.Response.Write(new ResponseData("Public.E_0006").ToJson());
					return;
				}
				userInfo.Token = Guid.Parse(requestData.TokenGuid);
				log.Debug("Do-->获取用户Session信息成功，用户名称：" + userInfo.UserName + "(" + userInfo.LogonName + ")");
				if (!userInfo.IsSuperUser && ActionManager.ActionNeedValidate(requestData.ActionCode) && !ActionManager.ActionCanDo(userInfo.UserID, userInfo.BelongToOrgID, requestData.ActionCode))
				{
					context.Response.Write(new ResponseData("Public.E_0007").ToJson());
					return;
				}
				Singleton<SessionManager>.Instance.SetCurrentSessionToken(Guid.Parse(requestData.TokenGuid));
				if (!super.Contains(requestData.ActionCode))
				{
					Singleton<SessionManager>.Instance.AdjustExpiredTime();
				}
			}
			IHandlerBase handler = ActionManager.GetBusinessHandler(requestData.ActionCode);
			if (handler == null)
			{
				context.Response.Write(new ResponseData("Public.E_0004").ToJson());
				return;
			}
			Log(requestData);
			handler.RequestData = requestData;
			log.Debug("Do-->开始执行" + handler.ToString());
			handler.ProcessRequest(context);
			log.Debug("Do-->完成执行" + handler.ToString());
		}
		catch (Exception e)
		{
			if (!super.Contains(requestData.ActionCode))
			{
				SystemLogEntry logEntry = new SystemLogEntry();
				logEntry.Action = ((requestData != null) ? requestData.ActionCode : string.Empty);
				logEntry.Data = $"RequestData:{((requestData != null) ? requestData.Data : string.Empty)}-----Error:[{e.Message}]";
				errorLog.Error(logEntry.ToJson());
				context.Response.Write(new ResponseData("系统发生未知错误，请查看错误日志！").ToJson());
			}
		}
		finally
		{
			log.Debug("清除当前线程中的Token值");
			Singleton<SessionManager>.Instance.ClearCurrentSessionToken();
		}
	}

	/// <summary>
	/// 转换请求数据
	/// </summary>
	/// <param name="requestData"></param>
	/// <returns></returns>
	private RequestData ConvertTo(string requestData)
	{
		return requestData.JsonDeserialize<RequestData>(new JsonConverter[0]);
	}

	/// <summary>
	/// 记录请求日志
	/// </summary>
	/// <param name="requestData"></param>
	private void Log(RequestData requestData)
	{
		SystemLogEntry logEntry = new SystemLogEntry();
		logEntry.Action = requestData.ActionCode;
		if (!requestData.ActionCode.Equals("SystemLogin_Login") && !requestData.ActionCode.Equals("SystemLogin_ExternalSystemLogin"))
		{
			logEntry.Data = requestData.Data;
		}
		log.Info(logEntry.ToJson());
	}
}
