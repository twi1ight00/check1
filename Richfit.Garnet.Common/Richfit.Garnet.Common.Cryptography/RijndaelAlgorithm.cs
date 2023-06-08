using System;
using System.Security.Cryptography;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// Rijndael 算法
/// </summary>
public class RijndaelAlgorithm : GenericSymmetricAlgorithm<RijndaelManaged>, IRijndael, ISymmetricAlgorithm, IAlgorithm, IDisposable
{
	/// <summary>
	/// 初始化默认算法对象
	/// </summary>
	public RijndaelAlgorithm()
	{
	}

	/// <summary>
	/// 使用指定的密钥和初始向量初始化算法对象
	/// </summary>
	/// <param name="key">算法密码</param>
	/// <param name="iv">算法初始化向量</param>
	/// <exception cref="T:System.ArgumentNullException">算法密码 <paramref name="key" /> 为空；或者算法初始化向量 <paramref name="iv" /> 为空。</exception>
	public RijndaelAlgorithm(byte[] key, byte[] iv)
		: base(key, iv)
	{
	}
}
