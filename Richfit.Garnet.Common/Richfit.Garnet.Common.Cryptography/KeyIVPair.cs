namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 密钥和初始向量组合
/// </summary>
public struct KeyIVPair
{
	/// <summary>
	/// 密钥
	/// </summary>
	public byte[] Key;

	/// <summary>
	/// 初始向量
	/// </summary>
	public byte[] IV;

	/// <summary>
	/// 初始化密钥和初始向量组合
	/// </summary>
	/// <param name="key">密钥</param>
	/// <param name="vi">初始向量</param>
	public KeyIVPair(byte[] key, byte[] vi)
	{
		Key = key;
		IV = vi;
	}
}
