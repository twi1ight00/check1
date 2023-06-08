using System;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// RSA 算法参数选项
/// </summary>
[Flags]
public enum RSAOptions
{
	/// <summary>
	/// 未指定参数选项
	/// </summary>
	None = 0,
	/// <summary>
	/// 执行加密处理
	/// </summary>
	Encrypt = 1,
	/// <summary>
	/// 执行解密处理
	/// </summary>
	Decrypt = 2,
	/// <summary>
	/// 使用公钥进行处理
	/// </summary>
	Public = 0x100,
	/// <summary>
	/// 使用私钥进行处理
	/// </summary>
	Private = 0x200,
	/// <summary>
	/// 使用OAEP填充方式
	/// </summary>
	OAEP = 0x10000,
	/// <summary>
	/// 使用PKCS v1.5填充方式
	/// </summary>
	PKCS15 = 0x20000
}
