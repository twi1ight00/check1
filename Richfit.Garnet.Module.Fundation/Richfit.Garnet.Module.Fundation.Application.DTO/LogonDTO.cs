using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

/// <summary>
/// 登陆对象
/// </summary>
[Serializable]
public class LogonDTO : DTOBase
{
	/// <summary>
	/// 登陆名
	/// </summary>
	public string LOGON_NAME { get; set; }

	/// <summary>
	/// 登陆密码
	/// </summary>
	public string PASSWORD { get; set; }

	/// <summary>
	/// 登陆域名
	/// </summary>
	public string DOMAIN_NAME { get; set; }

	/// <summary>
	/// 登陆语言
	/// </summary>
	public string CULTURE { get; set; }

	/// <summary>
	/// 登陆时区偏移
	/// </summary>
	public string TIMEOFFSET { get; set; }

	/// <summary>
	/// 登陆时区偏移
	/// </summary>
	public int IS_MOBILE { get; set; }

	/// <summary>
	/// 密码加密秘钥Token
	/// </summary>
	public string SECRETTOKEN { get; set; }

	/// <summary>
	/// 对称加密后的密钥
	/// </summary>
	public string ENCRYPTEDKEY { get; set; }

	/// <summary>
	/// 登录方式
	/// </summary>
	public decimal LOGON_WAY { get; set; }

	public string DEVICEINFO { get; set; }
}
