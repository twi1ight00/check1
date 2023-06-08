using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// 对称加密扩展方法
/// </summary>
public static class CryptographyExtensions
{
	/// <summary>
	/// 获取当前对称加密算法支持的最小数据块长度；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小数据块长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int MinBlockSize(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidBlockSizes().First();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最小密钥长度；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int MinKeySize(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidKeySizes().First();
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的最小密钥长度；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的最小密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前非对称加密算法为空。</exception>
	public static int MinKeySize(this AsymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidKeySizes().First();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最大数据块长度；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小数据块长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int MaxBlockSize(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidBlockSizes().Last();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最大密钥长度，密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最大密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int MaxKeySize(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidKeySizes().Last();
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的最大密钥长度，密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的最大密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前非对称加密算法为空。</exception>
	public static int MaxKeySize(this AsymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return algorithm.ValidKeySizes().Last();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的数据块大小；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的数据块大小列表</returns>
	public static int[] ValidBlockSizes(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return GetSizes(algorithm.LegalBlockSizes);
	}

	/// <summary>
	/// 获取当前对称加密算法支持的密钥长度的数组；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int[] ValidKeySizes(this SymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return GetSizes(algorithm.LegalKeySizes);
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的密钥大小；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int[] ValidKeySizes(this AsymmetricAlgorithm algorithm)
	{
		algorithm.GuardNotNull("algorithm");
		return GetSizes(algorithm.LegalKeySizes);
	}

	private static int[] GetSizes(KeySizes[] keySizes)
	{
		List<int> sizes = new List<int>();
		foreach (KeySizes ks in keySizes)
		{
			for (int i = ks.MinSize; i <= ks.MaxSize; i += ks.SkipSize)
			{
				sizes.Add(i);
			}
		}
		return sizes.OrderBy((int x) => x).Distinct().ToArray();
	}

	/// <summary>
	/// 使用当前对称加密算法加密字节数据
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <param name="data">待加密的字节数据</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空；或者待加密的字节数据为空。</exception>
	public static byte[] Encrypt(this SymmetricAlgorithm algorithm, byte[] data)
	{
		algorithm.GuardNotNull("algorithm");
		data.GuardNotNull("data");
		byte[] result = null;
		using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
		{
			using MemoryStream ms = new MemoryStream();
			using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
			cs.Write(data, 0, data.Length);
			cs.Close();
			ms.Close();
			result = ms.ToArray();
		}
		return result;
	}

	/// <summary>
	/// 使用默认密钥加密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static byte[] Encrypt(this byte[] data)
	{
		data.GuardNotNull("data");
		using SymmetricAlgorithm algorithm = Cryptographer.GetRijndael();
		return algorithm.Encrypt(data);
	}

	/// <summary>
	/// 使用指定密钥加密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="password">加密密钥</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static byte[] Encrypt(this byte[] data, string password)
	{
		data.GuardNotNull("data");
		password.GuardNotNull("password");
		using SymmetricAlgorithm algorithm = Cryptographer.GetRijndael(password);
		return algorithm.Encrypt(data);
	}

	/// <summary>
	/// 使用当前对称解密算法解密字节数据
	/// </summary>
	/// <param name="algorithm">当前对称解密算法</param>
	/// <param name="data">待解密的字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称解密算法为空；或者待解密的字节数据为空。</exception>
	public static byte[] Decrypt(this SymmetricAlgorithm algorithm, byte[] data)
	{
		algorithm.GuardNotNull("algorithm");
		data.GuardNotNull("data");
		byte[] result = null;
		using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
		{
			using MemoryStream ms = new MemoryStream(data);
			using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
			result = cs.ReadAllBytes();
			cs.Close();
			ms.Close();
		}
		return result;
	}

	/// <summary>
	/// 使用默认密钥解密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static byte[] Decrypt(this byte[] data)
	{
		data.GuardNotNull("data");
		using SymmetricAlgorithm algorithm = Cryptographer.GetRijndael();
		return algorithm.Decrypt(data);
	}

	/// <summary>
	/// 使用指定密钥解密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="password">解密密钥</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的文本为空；或者解密密钥为空。</exception>
	public static byte[] Decrypt(this byte[] data, string password)
	{
		data.GuardNotNull("data");
		password.GuardNotNull("password");
		using SymmetricAlgorithm algorithm = Cryptographer.GetRijndael(password);
		return algorithm.Decrypt(data);
	}

	/// <summary>
	/// 使用默认密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] EncryptText(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		encoding = encoding.IfNull(Encoding.UTF8);
		return text.TextEncode(encoding).Encrypt();
	}

	/// <summary>
	/// 使用指定密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="password">加密密钥</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static byte[] EncryptText(this string text, string password, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		encoding = encoding.IfNull(Encoding.UTF8);
		return text.TextEncode(encoding).Encrypt(password);
	}

	/// <summary>
	/// 使用默认密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static string DecryptText(this byte[] data, Encoding encoding = null)
	{
		data.GuardNotNull("data");
		encoding = encoding.IfNull(Encoding.UTF8);
		return data.Decrypt().TextDecode(encoding);
	}

	/// <summary>
	/// 使用指定的密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="password">解密密钥</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空；或者解密密钥 <paramref name="password" /> 为空。</exception>
	public static string DecryptText(this byte[] data, string password, Encoding encoding = null)
	{
		data.GuardNotNull("data");
		encoding = encoding.IfNull(Encoding.UTF8);
		return data.Decrypt(password).TextDecode(encoding);
	}

	/// <summary>
	/// 使用默认密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int EncryptInt(this int plainText, int key = 1024)
	{
		return plainText ^ key;
	}

	/// <summary>
	/// 使用默认密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static int DecryptInt(this int cipherText, int key = 1024)
	{
		return cipherText ^ key;
	}

	/// <summary>
	/// 使用默认密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static decimal EncryptDecimal(this decimal plainText, decimal key = 1024m)
	{
		return (plainText + key) * key;
	}

	/// <summary>
	/// 使用默认密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static decimal DecryptDecimal(this decimal cipherText, decimal key = 1024m)
	{
		return cipherText / key - key;
	}
}
