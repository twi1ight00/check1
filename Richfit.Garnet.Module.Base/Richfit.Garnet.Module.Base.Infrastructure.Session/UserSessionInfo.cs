using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.Session;

/// <summary>
/// Session中的用户的信息
/// </summary>
[Serializable]
public class UserSessionInfo
{
	/// <summary>
	/// 用户选用的语言
	/// </summary>
	public string LanguageCulture { get; set; }

	/// <summary>
	/// Token
	/// </summary>
	public Guid Token { get; set; }

	/// <summary>
	/// 用户登陆名称
	/// </summary>
	public string LogonName { get; set; }

	/// <summary>
	/// 登陆密码，SSO用到密码，需要加密
	/// </summary>
	public string LogonPassword { get; set; }

	/// <summary>
	/// 用户ID
	/// </summary>
	public Guid UserID { get; set; }

	/// <summary>
	/// 用户名称
	/// </summary>
	public string UserName { get; set; }

	/// <summary>
	/// 是否超级用户
	/// </summary>
	public bool IsSuperUser { get; set; }

	/// <summary>
	/// 用户所在时区时间偏移量
	/// </summary>
	public int TimeOffset { get; set; }

	/// <summary>
	/// 是否移动端
	/// </summary>
	public int IsMobile { get; set; }

	/// <summary>
	/// 用户当前所在的OrgID
	/// </summary>
	public Guid BelongToOrgID { get; set; }

	/// <summary>
	/// Http请求的IP地址
	/// </summary>
	public string IP { get; set; }

	/// <summary>
	/// Http请求的IP地址
	/// </summary>
	public string EXTEND1 { get; set; }

	/// <summary>
	/// 屏蔽Sesison的重要信息
	/// </summary>
	/// <returns></returns>
	public UserSessionInfo MaskInfo()
	{
		UserSessionInfo sessionVisible = new UserSessionInfo();
		sessionVisible.UserName = UserName;
		sessionVisible.LogonName = LogonName;
		sessionVisible.LogonPassword = LogonPassword;
		sessionVisible.IsSuperUser = IsSuperUser;
		sessionVisible.BelongToOrgID = BelongToOrgID;
		sessionVisible.UserID = UserID;
		sessionVisible.EXTEND1 = EXTEND1;
		return sessionVisible;
	}
}
