using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Base.Infrastructure.Session;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 系统日志条目，系统日志条目写入文件目录日志文件
/// </summary>
public class SystemLogEntry
{
	/// <summary>
	/// Token
	/// </summary>
	public string Token { get; set; }

	/// <summary>
	/// 用户名
	/// </summary>
	public string User { get; set; }

	/// <summary>
	/// IP地址
	/// </summary>
	public string IP { get; set; }

	/// <summary>
	/// 请求的Agent信息
	/// </summary>
	public string Agent { get; set; }

	/// <summary>
	/// 执行动作
	/// </summary>
	public string Action { get; set; }

	/// <summary>
	/// log数据
	/// </summary>
	public string Data { get; set; }

	/// <summary>
	/// 构造函数
	/// </summary>
	public SystemLogEntry()
	{
		UserSessionInfo userInfo = SessionContext.UserInfo;
		if (userInfo != null)
		{
			IP = SessionContext.IP;
			Agent = SessionContext.Agent;
			User = string.Concat(userInfo.UserName, "[", userInfo.UserID, "]");
			Token = Singleton<SessionManager>.Instance.GetCurrentSessionToken().ToString();
		}
		else
		{
			IP = "::1";
			Agent = "System";
			User = "System[null]";
			Token = "(null)";
		}
	}

	/// <summary>
	/// 序列化为JSON字符串
	/// </summary>
	/// <returns></returns>
	public string ToJson()
	{
		return this.JsonSerialize();
	}
}
