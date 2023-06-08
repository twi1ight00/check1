using System;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 加解密算法接口
/// </summary>
public interface IAlgorithm : IDisposable
{
	/// <summary>
	/// 获取或者设置当前算法名称
	/// </summary>
	/// <remarks>如果将算法名称设置为空，则名称自动设置为算法的默认名称。</remarks>
	string Name { get; set; }

	/// <summary>
	/// 解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据 <paramref name="data" /> 为空。</exception>
	byte[] Decrypt(byte[] data);

	/// <summary>
	/// 加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	byte[] Encrypt(byte[] data);
}
