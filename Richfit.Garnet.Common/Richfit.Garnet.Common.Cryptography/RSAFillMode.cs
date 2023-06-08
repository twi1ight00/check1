namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// RSA 算法填充模式
/// </summary>
public enum RSAFillMode
{
	/// <summary>
	/// 使用 OAEP 填充方式
	/// </summary>
	OAEP = 0x10000,
	/// <summary>
	/// 使用 PKCS v1.5 填充方式
	/// </summary>
	PKCS15 = 0x20000
}
