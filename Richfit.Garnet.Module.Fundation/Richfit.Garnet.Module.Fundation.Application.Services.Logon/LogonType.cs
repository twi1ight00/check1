namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆验证类型
/// </summary>
public enum LogonType
{
	Super = 2,
	/// <summary>
	/// 域验证登陆
	/// </summary>
	Domain = 0,
	/// <summary>
	/// 系统验证登陆
	/// </summary>
	System = 1
}
