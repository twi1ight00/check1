using System;
using System.Web;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Web.Extensions;
using Richfit.Garnet.Module.Fundation.Application.Services.Logon;

namespace Richfit.Garnet.Module.Fundation.Infrastructure;

/// <summary>
/// 处理单点登录的HttpHandler
/// </summary>
public class SSOHandler : IHttpHandler
{
	/// <summary>
	/// 日志记录器
	/// </summary>
	private static readonly ILogger log = LoggerManager.GetLogger();

	public bool IsReusable => false;

	/// <summary>
	/// 处理请求
	/// </summary>
	/// <param name="context"></param>
	public void ProcessRequest(HttpContext context)
	{
		log.Debug("处理单点登陆请求开始");
		string userId = context.Request.QueryParam("User");
		log.Debug(userId);
		string userPassword = context.Request.QueryParam("Password");
		log.Debug(userPassword);
		string domain = context.Request.QueryParam("Domain");
		log.Debug(domain);
		string url = context.Request.QueryParam("RedirectURL");
		log.Debug(url);
		if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPassword))
		{
			context.Response.Redirect("/login.htm");
		}
		else
		{
			ILogonService logonService = ServiceLocator.Instance.GetService<ILogonService>();
			userPassword = userPassword.Base64Decode().DecryptText();
			Guid token = logonService.Login(domain, userId, userPassword, 0);
			if (token != Guid.Empty)
			{
				log.Debug("单点登陆验证成功！");
				context.Response.SetCookie("TokenGuid", token);
				if (string.IsNullOrEmpty(url))
				{
					context.Response.Redirect("/index.html");
				}
				else
				{
					context.Response.Redirect("/index.html?url={0}", url);
				}
			}
			else
			{
				log.Debug("单点登陆验证失败！");
				context.Response.Redirect("/login.html");
			}
		}
		log.Debug("处理单点登陆请求结束");
	}
}
