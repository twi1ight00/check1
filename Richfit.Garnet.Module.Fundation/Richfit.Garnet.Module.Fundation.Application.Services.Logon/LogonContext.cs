using System;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆上下文
/// </summary>
public class LogonContext : InjectContextBase
{
	/// <summary>
	/// 用户信息
	/// </summary>
	public UserDTO UserInfo { get; set; }

	/// <summary>
	/// 域名称
	/// </summary>
	public string DomainName { get; set; }

	/// <summary>
	/// 登陆名
	/// </summary>
	public string LogonName { get; set; }

	/// <summary>
	/// 登陆密码
	/// </summary>
	public string Password { get; set; }

	/// <summary>
	/// 登陆语言
	/// </summary>
	public string Culture { get; set; }

	/// <summary>
	/// 登陆时区偏移
	/// </summary>
	public string TimeOffset { get; set; }

	/// <summary>
	/// 登陆IP地址
	/// </summary>
	public string IP { get; set; }

	/// <summary>
	/// 登陆后的唯一标识
	/// </summary>
	public Guid Token { get; set; }

	/// <summary>
	/// 登陆帐号是否存在
	/// </summary>
	public bool IsAccountExists { get; set; }

	/// <summary>
	/// 登陆帐号是否被禁用
	/// </summary>
	public bool IsForbidden { get; set; }

	public int IsMobile { get; set; }
}
