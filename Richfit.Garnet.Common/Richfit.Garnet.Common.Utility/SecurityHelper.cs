#define DEBUG
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 安全相关辅助类
/// </summary>
public static class SecurityHelper
{
	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数组计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(byte[] data, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(data, "data");
		return Hash(data, 0, data.Length, algorithm);
	}

	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">计算的字节起始索引</param>
	/// <param name="count">计算的字节数量</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数组计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数据的索引范围</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数量。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(byte[] data, int start, int count, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "index");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		if (ObjectHelper.IsNull(algorithm))
		{
			using (HashAlgorithm hasher = new SHA1Managed())
			{
				return hasher.ComputeHash(data, start, count);
			}
		}
		return algorithm.ComputeHash(data, start, count);
	}

	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数据计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(IEnumerable<byte> data, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(data, "data");
		return Hash(data.ToArray(), algorithm);
	}

	/// <summary>
	/// 计算当前文件的哈希值
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="algorithm">使用的哈希值算法，默认为SHA1</param>
	/// <returns>文件的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static byte[] Hash(FileInfo file, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		byte[] hashedBytes;
		using (FileStream fs = file.OpenRead())
		{
			hashedBytes = Hash(fs, algorithm);
			fs.Close();
		}
		return hashedBytes;
	}

	/// <summary>
	/// 计算当前字节流的哈希值
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="algorithm">计算哈希值的哈希算法，默认为SHA1</param>
	/// <returns>计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static byte[] Hash(Stream stream, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(stream, "stream");
		byte[] hashedBytes;
		using (HashAlgorithm hasher = ObjectHelper.IfNull(algorithm, new SHA1CryptoServiceProvider()))
		{
			hashedBytes = hasher.ComputeHash(stream);
			hasher.Clear();
		}
		return hashedBytes;
	}

	/// <summary>
	/// 计算当前文本的哈希值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">将文本转换为字节使用的编码，默认是UTF-8</param>
	/// <param name="algorithm">用的哈希算法，默认为SHA1</param>
	/// <returns>字符串的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte[] Hash(string text, Encoding encoding = null, HashAlgorithm algorithm = null)
	{
		Guard.AssertNotNull(text, "text");
		return Hash(TextHelper.TextEncode(text, ObjectHelper.IfNull(encoding, Encoding.UTF8)), algorithm);
	}
}
