using System;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆服务接口定义
/// </summary>
public interface ILogonService
{
	/// <summary>
	/// 登陆注入服务
	/// </summary>
	ILogonInject LogonInject { get; set; }

	/// <summary>
	/// 用户后台登陆
	/// </summary>
	/// <param name="domainName">域服务器名称 example:cnpc.com.cn，可为空</param>
	/// <param name="logonName">登录名</param>
	/// <param name="password">密码</param>
	Guid Login(string domainName, string logonName, string password, int isMobile);

	/// <summary>
	/// 用户界面登陆
	/// </summary>
	/// <param name="loginDTO"></param>
	/// <returns></returns>
	LogonContext Login(LogonDTO loginDTO);

	/// <summary>
	/// 用户登出
	/// </summary>
	void LogOut();

	/// <summary>
	/// 判断用户帐号是否存在
	/// </summary>
	/// <param name="logonName">用户登录名</param>
	/// <returns>是否存在标志</returns>
	bool UserAccountIsExists(string logonName);

	VersionInfoDTO GetVersionInfo(string OS);

	/// <summary>
	/// 根据登录名获取domain
	/// </summary>
	/// <param name="LogonName"></param>
	/// <returns></returns>
	string GetDomainByLogonName(string LogonName);

	/// <summary>
	/// 更新员工HR表工龄等信息
	/// </summary>
	/// <param name="userID"></param>
	void UpdateHRInfo(Guid userID);

	bool unbind(Guid userID, string DEVICEINFO);
}
