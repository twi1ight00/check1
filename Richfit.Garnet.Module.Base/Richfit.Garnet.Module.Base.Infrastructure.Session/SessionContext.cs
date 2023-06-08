using System;
using System.Web;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Web.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Session;

/// <summary>
/// Session上下文
/// </summary>
public class SessionContext
{
	/// <summary>
	/// 用户信息
	/// </summary>
	public static UserSessionInfo UserInfo => Singleton<SessionManager>.Instance.GetCurrentUserSessionInfo();

	/// <summary>
	/// Http请求的IP地址
	/// </summary>
	public static string IP => (HttpContext.Current != null) ? HttpContext.Current.Request.GetUserHostAddress() : string.Empty;

	/// <summary>
	/// Http请求的Agent信息
	/// </summary>
	public static string Agent => (HttpContext.Current != null) ? HttpContext.Current.Request.UserAgent : string.Empty;

	/// <summary>
	/// 获取Http请求的服务地址
	/// </summary>
	public static string ServerUrl => (HttpContext.Current != null) ? HttpContext.Current.Request.ToRootUrlString() : string.Empty;

	/// <summary>
	/// 后台获取机构树的根节点Id
	/// </summary>
	/// <returns></returns>
	public static Guid? GetRootOrgId()
	{
		Guid? orgId = Guid.NewGuid();
		if (UserInfo != null)
		{
			orgId = UserInfo.BelongToOrgID;
			if (UserInfo.IsSuperUser)
			{
				orgId = null;
			}
		}
		return orgId;
	}
}
