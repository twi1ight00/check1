using System;
using System.Security.Cryptography;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// RSA 算法接口
/// </summary>
public interface IRSA : IAsymmetricAlgorithm, IAlgorithm, IDisposable
{
	/// <summary>
	/// 获取或者设置填充模式
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	RSAFillMode FillMode { get; set; }

	/// <summary>
	/// 导出RSA参数
	/// </summary>
	/// <param name="includePrivateParameters">要包括私有参数，则为 true；否则为 false。</param>
	/// <returns>导出的RSA参数</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	RSAParameters ExportParameters(bool includePrivateParameters);

	/// <summary>
	/// 导入指定的RSA参数
	/// </summary>
	/// <param name="parameters">RSA参数</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	void ImportParameters(RSAParameters parameters);
}
