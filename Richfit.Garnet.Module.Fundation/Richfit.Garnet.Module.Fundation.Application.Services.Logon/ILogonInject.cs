namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 用户登录注入接口
/// </summary>
public interface ILogonInject
{
	/// <summary>
	/// 登陆验证前操作
	/// </summary>
	void BeforeLogin(LogonContext context);

	/// <summary>
	/// 登陆验证后操作
	/// </summary>
	void AfterLogin(LogonContext context);
}
