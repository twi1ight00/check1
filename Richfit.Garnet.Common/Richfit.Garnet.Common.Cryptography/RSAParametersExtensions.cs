using System.Numerics;
using System.Security.Cryptography;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// <see cref="T:System.Security.Cryptography.RSAParameters" /> 类型扩展方法
/// </summary>
public static class RSAParametersExtensions
{
	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.D" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.D" /> 参数</returns>
	public static BigInteger D(this RSAParameters parameters)
	{
		return parameters.D.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.D);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.DP" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.DP" /> 参数</returns>
	public static BigInteger DP(this RSAParameters parameters)
	{
		return parameters.DP.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.DP);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.DQ" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.DQ" /> 参数</returns>
	public static BigInteger DQ(this RSAParameters parameters)
	{
		return parameters.DQ.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.DQ);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Exponent" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Exponent" /> 参数</returns>
	public static BigInteger E(this RSAParameters parameters)
	{
		return parameters.Exponent();
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Exponent" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Exponent" /> 参数</returns>
	public static BigInteger Exponent(this RSAParameters parameters)
	{
		return parameters.Exponent.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.Exponent);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.InverseQ" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.InverseQ" /> 参数</returns>
	public static BigInteger IQ(this RSAParameters parameters)
	{
		return parameters.InverseQ();
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.InverseQ" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.InverseQ" /> 参数</returns>
	public static BigInteger InverseQ(this RSAParameters parameters)
	{
		return parameters.InverseQ.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.InverseQ);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数</returns>
	public static BigInteger Modulus(this RSAParameters parameters)
	{
		return parameters.Modulus.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.Modulus);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数的字节数量
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数的字节数量</returns>
	public static int ModulusOctets(this RSAParameters parameters)
	{
		return (!parameters.Modulus.IsNull()) ? parameters.Modulus.Length : 0;
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Modulus" /> 参数</returns>
	public static BigInteger N(this RSAParameters parameters)
	{
		return parameters.Modulus();
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.P" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.P" /> 参数</returns>
	public static BigInteger P(this RSAParameters parameters)
	{
		return parameters.P.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.P);
	}

	/// <summary>
	/// 获取当前RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Q" /> 参数的数值形式
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>RSA参数的 <see cref="F:System.Security.Cryptography.RSAParameters.Q" /> 参数</returns>
	public static BigInteger Q(this RSAParameters parameters)
	{
		return parameters.Q.IsNull() ? ((BigInteger)0) : new BigInteger(parameters.Q);
	}

	/// <summary>
	/// 检测当前RSA参数是否具有公共密钥
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>如果当前RSA参数具有公共密钥返回true，否则返回false。</returns>
	public static bool ContainsPublicKey(this RSAParameters parameters)
	{
		return parameters.Modulus.IsNotNull() && parameters.Exponent.IsNotNull();
	}

	/// <summary>
	/// 检测当前RSA参数是否具有私钥
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>如果当前RSA参数具有私钥返回true，否则返回false。</returns>
	public static bool ContainsPrivateKey(this RSAParameters parameters)
	{
		return parameters.D.IsNotNull();
	}

	/// <summary>
	/// 检测当前RSA参数是否具有CRT信息
	/// </summary>
	/// <param name="parameters">当前RSA参数</param>
	/// <returns>如果当前RSA参数具有CRT信息返回true，否则返回false。</returns>
	public static bool ContainsCrtInfo(this RSAParameters parameters)
	{
		return parameters.P.IsNotNull() && parameters.Q.IsNotNull() && parameters.DP.IsNotNull() && parameters.DQ.IsNotNull() && parameters.InverseQ.IsNotNull();
	}
}
