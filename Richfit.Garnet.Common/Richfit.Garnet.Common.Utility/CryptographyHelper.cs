#define DEBUG
using System;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Cryptography;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 加解密辅助类
/// </summary>
public static class CryptographyHelper
{
	/// <summary>
	/// 使用默认密钥解密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static byte[] DecryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.DecryptBytes(data);
	}

	/// <summary>
	/// 使用指定密钥解密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="password">解密密钥</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者解密密钥 <paramref name="password" /> 为空。</exception>
	public static byte[] DecryptBytes(byte[] data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.DecryptBytes(data);
	}

	/// <summary>
	/// 使用默认密钥解密Base64编码的数据
	/// </summary>
	/// <param name="data">Base64编码的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">Base64编码的数据为空。</exception>
	public static byte[] DecryptBytesFromBase64(string data)
	{
		Guard.AssertNotNull(data, "data");
		return DecryptBytes(Convert.FromBase64String(data));
	}

	/// <summary>
	/// 使用指定密钥解密Base64编码的数据
	/// </summary>
	/// <param name="data">Base64编码的数据</param>
	/// <param name="password">解密密钥</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">Base64编码的数据为空；或者解密密钥为空。</exception>
	public static byte[] DecryptBytesFromBase64(string data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		return DecryptBytes(Convert.FromBase64String(data), password);
	}

	/// <summary>
	/// 使用默认密钥解密当前文件的数据，解密后的数据将写入当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件全名</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件全名为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		DecryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用默认密钥待解密的输入文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">待解密的输入文件名称</param>
	/// <param name="output">输出文件</param>
	/// <exception cref="T:System.ArgumentException">待解密的输入文件名称无效；或者输出文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		DecryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用指定密钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">输出文件</param>
	/// <param name="password">解密密钥</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者解密密钥为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(string input, string output, string password)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		Guard.AssertNotNull(password, "password");
		DecryptFile(new FileInfo(input), new FileInfo(output), password);
	}

	/// <summary>
	/// 使用默认密钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			DecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用指定密钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <param name="password">解密密码</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者解密密码为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(FileInfo file, string password)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(password, "password");
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			DecryptStream(i, o, password);
		});
	}

	/// <summary>
	/// 使用默认密钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者解密结果文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			DecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用指定密钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <param name="password">解密密钥</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者解密结果文件为空；或者解密密钥为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void DecryptFile(FileInfo input, FileInfo output, string password)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		Guard.AssertNotNull(password, "password");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			DecryptStream(i, o, password);
		});
	}

	/// <summary>
	/// 使用默认密钥解密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static Stream DecryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.DecryptStream(data);
	}

	/// <summary>
	/// 使用默认密钥解密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <param name="password">解密密钥</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者解密密钥 <paramref name="password" /> 为空。</exception>
	public static Stream DecryptStream(Stream data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.DecryptStream(data);
	}

	/// <summary>
	/// 使用默认密钥解密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <param name="result">解密后的字节流</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流 <paramref name="data" /> 为空；或者解密后的结果字节流 <paramref name="result" /> 为空。</exception>
	public static int DecryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.DecryptStream(data, result);
	}

	/// <summary>
	/// 使用默认密钥解密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <param name="result">解密后的字节流</param>
	/// <param name="password">解密密钥</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者解密后的结果字节流 <paramref name="result" /> 为空；或者解密密钥 <paramref name="password" /> 为空。</exception>
	public static int DecryptStream(Stream data, Stream result, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.DecryptStream(data, result);
	}

	/// <summary>
	/// 使用默认密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static string DecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetString(DecryptBytes(data));
	}

	/// <summary>
	/// 使用指定的密钥解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">当前待解密的字节数据</param>
	/// <param name="password">解密密钥</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空；或者解密密钥 <paramref name="password" /> 为空。</exception>
	public static string DecryptText(byte[] data, string password, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetString(DecryptBytes(data, password));
	}

	/// <summary>
	/// 使用默认密钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的Base64编码的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空。</exception>
	public static string DecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		return DecryptText(Convert.FromBase64String(data), encoding);
	}

	/// <summary>
	/// 使用指定的密钥解密Base64编码的字节数据，并按指定字符编码编码为文本
	/// </summary>
	/// <param name="data">待解密的Base64编码的字节数据</param>
	/// <param name="password">解密密钥</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待解密的字节数据为空；或者解密密钥为空。</exception>
	public static string DecryptTextFromBase64(string data, string password, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		return DecryptText(Convert.FromBase64String(data), password, encoding);
	}

	/// <summary>
	/// 使用默认密钥加密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static byte[] EncryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.Encrypt(data);
	}

	/// <summary>
	/// 使用指定密钥加密当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="password">加密密钥</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static byte[] EncryptBytes(byte[] data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.Encrypt(data);
	}

	/// <summary>
	/// 使用默认密钥加密数据，并转换为Base64编码的字节数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	public static string EncryptBytesToBase64(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		return Convert.ToBase64String(EncryptBytes(data));
	}

	/// <summary>
	/// 使用指定密钥加密数据，并转换为Base64编码的字节数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <param name="password">加密密钥</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空；或者加密密钥为空。</exception>
	public static string EncryptBytesToBase64(byte[] data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		return Convert.ToBase64String(EncryptBytes(data, password));
	}

	/// <summary>
	/// 使用默认密钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		EncryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用默认密钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">输出文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		EncryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用指定密钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">输出文件</param>
	/// <param name="password">加密密钥</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者加密密钥为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(string input, string output, string password)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		Guard.AssertNotNull(password, "password");
		EncryptFile(new FileInfo(input), new FileInfo(output), password);
	}

	/// <summary>
	/// 使用默认密钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream input, Stream output)
		{
			EncryptStream(input, output);
		});
	}

	/// <summary>
	/// 使用指定密钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <param name="password">加密密码</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者加密密码为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(FileInfo file, string password)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(password, "password");
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream input, Stream output)
		{
			EncryptStream(input, output, password);
		});
	}

	/// <summary>
	/// 使用默认密钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">输出的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出的文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			EncryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用指定密钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">输出的文件</param>
	/// <param name="password">加密密钥</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出的文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void EncryptFile(FileInfo input, FileInfo output, string password)
	{
		Guard.AssertNotNull(input, "input file");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output file");
		Guard.AssertNotNull(password, "password");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			EncryptStream(i, o, password);
		});
	}

	/// <summary>
	/// 使用默认密钥加密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static Stream EncryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.EncryptStream(data);
	}

	/// <summary>
	/// 使用指定密钥加密当前字节流
	/// </summary>
	/// <param name="data">加密字节流</param>
	/// <param name="password">加密密钥</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static Stream EncryptStream(Stream data, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.EncryptStream(data);
	}

	/// <summary>
	/// 使用默认密钥加密当前字节流
	/// </summary>
	/// <param name="data">当前字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <returns>实际加密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空；或者待加密的字节流 <paramref name="data" /> 为空；或者加密后的结果字节流 <paramref name="result" /> 为空。</exception>
	public static int EncryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(data, "result");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm();
		return algorithm.EncryptStream(data, result);
	}

	/// <summary>
	/// 使用指定密钥加密当前字节流
	/// </summary>
	/// <param name="data">加密字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <param name="password">加密密钥</param>
	/// <returns>实际加密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者加密后的输出字节流 <paramref name="result" /> 为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static int EncryptStream(Stream data, Stream result, string password)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(password, "password");
		using ISymmetricAlgorithm algorithm = AlgorithmHelper.GetSymmetricAlgorithm(password);
		return algorithm.EncryptStream(data, result);
	}

	/// <summary>
	/// 使用默认密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] EncryptText(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return EncryptBytes(encoding.GetBytes(text));
	}

	/// <summary>
	/// 使用指定密钥加密当前文本数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="password">加密密钥</param>
	/// <param name="encoding">加密文本的使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者加密密钥 <paramref name="password" /> 为空。</exception>
	public static byte[] EncryptText(string text, string password, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(password, "password");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return EncryptBytes(encoding.GetBytes(text), password);
	}

	/// <summary>
	/// 使用模拟密钥加密当前文本数据，返回加密后的Base64编码的字节数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">加密文本使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string EncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return Convert.ToBase64String(EncryptText(text, encoding));
	}

	/// <summary>
	/// 使用指定密钥加密当前文本数据，返回加密后的Base64编码的字节数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="password">加密密钥</param>
	/// <param name="encoding">加密文本使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者加密密钥为空。</exception>
	public static string EncryptTextToBase64(string text, string password, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(password, "password");
		return Convert.ToBase64String(EncryptText(text, password, encoding));
	}

	/// <summary>
	/// 使用默认的非对称解密算法的私钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据为空。</exception>
	public static byte[] PrivateDecryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptBytes(data);
	}

	/// <summary>
	/// 使用指定的参数初始化的非对称解密算法的私钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据为空；或者算法参数为空。</exception>
	public static byte[] PrivateDecryptBytes(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptBytes(data);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的私钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data">待解密的Base64编码字节数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的Base64编码的字节数据为空。</exception>
	public static byte[] PrivateDecryptBytesFromBase64(string data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptBytesFromBase64(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data">待解密的Base64编码字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的Base64编码的字节数据为空；或者算法参数为空。</exception>
	public static byte[] PrivateDecryptBytesFromBase64(string data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptBytesFromBase64(data);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateDecryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密输出文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateDecryptFile(input, output);
	}

	/// <summary>
	/// 使用指定的算法参数初始化的非对称解密算法的私钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密输出文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(string input, string output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateDecryptFile(input, output);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateDecryptFile(file);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(FileInfo file, string parameter)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateDecryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者结果文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateDecryptFile(input, output);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateDecryptFile(FileInfo input, FileInfo output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateDecryptFile(input, output);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的私钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空。</exception>
	public static Stream PrivateDecryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptStream(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者算法参数为空。</exception>
	public static Stream PrivateDecryptStream(Stream data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptStream(data);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的私钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="result">解密后输出的字节流</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者输出字节流为空。</exception>
	public static int PrivateDecryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptStream(data, result);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="result">解密后输出的字节流</param>
	/// <param name="parameter">算法初始化参数</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者输出字节流为空；或者算法初始化参数为空。</exception>
	public static int PrivateDecryptStream(Stream data, Stream result, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptStream(data, result);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空。</exception>
	public static string PrivateDecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptText(data, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空；或者算法参数为空。</exception>
	public static string PrivateDecryptText(byte[] data, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptText(data, encoding);
	}

	/// <summary>
	/// 使用默认非对称解密算法的私钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空。</exception>
	public static string PrivateDecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateDecryptTextFromBase64(data, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的私钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空；或者算法参数为空。</exception>
	public static string PrivateDecryptTextFromBase64(string data, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateDecryptTextFromBase64(data, encoding);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的私钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	public static byte[] PrivateEncryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptBytes(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空；或者算法参数为空。</exception>
	public static byte[] PrivateEncryptBytes(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptBytes(data);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的私钥加密字节数据，并返回加密后字节数据的Base64编码文本
	/// </summary>
	/// <param name="data">待加密的字节数据</param>
	/// <returns>加密数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节数据为空。</exception>
	public static string PrivateEncryptBytesToBase64(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptBytesToBase64(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密字节数据，并返回加密后字节数据的Base64编码文本
	/// </summary>
	/// <param name="data">待加密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>待加密的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节数据为空；或者算法参数为空。</exception>
	public static string PrivateEncryptBytesToBase64(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptBytesToBase64(data);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateEncryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密输出文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateEncryptFile(input, output);
	}

	/// <summary>
	/// 使用指定的算法参数初始化的非对称加密算法的私钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密输出文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(string input, string output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateEncryptFile(input, output);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateEncryptFile(file);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(FileInfo file, string parameter)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateEncryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密后的结果文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者结果文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PrivateEncryptFile(input, output);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密后的结果文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PrivateEncryptFile(FileInfo input, FileInfo output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output);
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PrivateEncryptFile(input, output);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的私钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空。</exception>
	public static Stream PrivateEncryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptStream(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者算法参数为空。</exception>
	public static Stream PrivateEncryptStream(Stream data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptStream(data);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的私钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <returns>实际加密的字节数</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者加密后的字节流为空。</exception>
	public static int PrivateEncryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptStream(data, result);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <param name="parameter">加密参数</param>
	/// <returns>实际加密的字节数</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者加密后的字节流为空；或者加密参数为空。</exception>
	public static int PrivateEncryptStream(Stream data, Stream result, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptStream(data, result);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密文本数据
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空。</exception>
	public static byte[] PrivateEncryptText(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptText(text, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密文本数据
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空；或者算法参数为空。</exception>
	public static byte[] PrivateEncryptText(string text, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptText(text, encoding);
	}

	/// <summary>
	/// 使用默认非对称加密算法的私钥加密文本数据，并返回加密后数据的Base64编码文本
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空。</exception>
	public static string PrivateEncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PrivateEncryptTextToBase64(text, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的私钥加密文本数据，并返回加密后数据的Base64编码文本
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空；或者算法参数为空。</exception>
	public static string PrivateEncryptTextToBase64(string text, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PrivateEncryptTextToBase64(text, encoding);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的公钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据为空。</exception>
	public static byte[] PublicDecryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptBytes(data);
	}

	/// <summary>
	/// 使用指定的参数初始化的非对称解密算法的公钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据为空；或者算法参数为空。</exception>
	public static byte[] PublicDecryptBytes(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptBytes(data);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的公钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data">待解密的Base64编码字节数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的Base64编码的字节数据为空。</exception>
	public static byte[] PublicDecryptBytesFromBase64(string data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptBytesFromBase64(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data">待解密的Base64编码字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的Base64编码的字节数据为空；或者算法参数为空。</exception>
	public static byte[] PublicDecryptBytesFromBase64(string data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptBytesFromBase64(data);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicDecryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密输出文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicDecryptFile(input, output);
	}

	/// <summary>
	/// 使用指定的算法参数初始化的非对称解密算法的公钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密输出文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(string input, string output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicDecryptFile(input, output);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicDecryptFile(file);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待解密的文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(FileInfo file, string parameter)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicDecryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者结果文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicDecryptFile(input, output);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待解密的文件</param>
	/// <param name="output">解密后的结果文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicDecryptFile(FileInfo input, FileInfo output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicDecryptFile(input, output);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的公钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空。</exception>
	public static Stream PublicDecryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptStream(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者算法参数为空。</exception>
	public static Stream PublicDecryptStream(Stream data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptStream(data);
	}

	/// <summary>
	/// 使用默认的非对称解密算法的公钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="result">解密后输出的字节流</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者输出字节流为空。</exception>
	public static int PublicDecryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptStream(data, result);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密字节流
	/// </summary>
	/// <param name="data">待解密的字节流</param>
	/// <param name="result">解密后输出的字节流</param>
	/// <param name="parameter">算法初始化参数</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节流为空；或者输出字节流为空；或者算法初始化参数为空。</exception>
	public static int PublicDecryptStream(Stream data, Stream result, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptStream(data, result);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空。</exception>
	public static string PublicDecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptText(data, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空；或者算法参数为空。</exception>
	public static string PublicDecryptText(byte[] data, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptText(data, encoding);
	}

	/// <summary>
	/// 使用默认非对称解密算法的公钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空。</exception>
	public static string PublicDecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicDecryptTextFromBase64(data, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称解密算法的公钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">解密的字节数据为空；或者算法参数为空。</exception>
	public static string PublicDecryptTextFromBase64(string data, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicDecryptTextFromBase64(data, encoding);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的公钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	public static byte[] PublicEncryptBytes(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptBytes(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空；或者算法参数为空。</exception>
	public static byte[] PublicEncryptBytes(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptBytes(data);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的公钥加密字节数据，并返回加密后字节数据的Base64编码文本
	/// </summary>
	/// <param name="data">待加密的字节数据</param>
	/// <returns>加密数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节数据为空。</exception>
	public static string PublicEncryptBytesToBase64(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptBytesToBase64(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密字节数据，并返回加密后字节数据的Base64编码文本
	/// </summary>
	/// <param name="data">待加密的字节数据</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>待加密的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节数据为空；或者算法参数为空。</exception>
	public static string PublicEncryptBytesToBase64(byte[] data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptBytesToBase64(data);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(string file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicEncryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密输出文件</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(string input, string output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicEncryptFile(input, output);
	}

	/// <summary>
	/// 使用指定的算法参数初始化的非对称加密算法的公钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密输出文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentException">当前文件名称无效；或者输出文件不存在。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者输出文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(string input, string output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicEncryptFile(input, output);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicEncryptFile(file);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file">当前待加密的文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(FileInfo file, string parameter)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicEncryptFile(file);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密后的结果文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者结果文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(FileInfo input, FileInfo output)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		algorithm.PublicEncryptFile(input, output);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input">当前待加密的文件</param>
	/// <param name="output">加密后的结果文件</param>
	/// <param name="parameter">算法参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者算法参数为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void PublicEncryptFile(FileInfo input, FileInfo output, string parameter)
	{
		Guard.AssertNotNull(input, "input");
		Guard.AssertFileExistence(input);
		Guard.AssertNotNull(output, "output");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		algorithm.PublicEncryptFile(input, output);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的公钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空。</exception>
	public static Stream PublicEncryptStream(Stream data)
	{
		Guard.AssertNotNull(data, "data");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptStream(data);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者算法参数为空。</exception>
	public static Stream PublicEncryptStream(Stream data, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptStream(data);
	}

	/// <summary>
	/// 使用默认的非对称加密算法的公钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <returns>实际加密的字节数</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者加密后的字节流为空。</exception>
	public static int PublicEncryptStream(Stream data, Stream result)
	{
		Guard.AssertNotNull(data, "dat");
		Guard.AssertNotNull(result, "result");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptStream(data, result);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密字节流
	/// </summary>
	/// <param name="data">待加密的字节流</param>
	/// <param name="result">加密后的字节流</param>
	/// <param name="parameter">加密参数</param>
	/// <returns>实际加密的字节数</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节流为空；或者加密后的字节流为空；或者加密参数为空。</exception>
	public static int PublicEncryptStream(Stream data, Stream result, string parameter)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(result, "result");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptStream(data, result);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密文本数据
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空。</exception>
	public static byte[] PublicEncryptText(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptText(text, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密文本数据
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空；或者算法参数为空。</exception>
	public static byte[] PublicEncryptText(string text, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptText(text, encoding);
	}

	/// <summary>
	/// 使用默认非对称加密算法的公钥加密文本数据，并返回加密后数据的Base64编码文本
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空。</exception>
	public static string PublicEncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm();
		return algorithm.PublicEncryptTextToBase64(text, encoding);
	}

	/// <summary>
	/// 使用指定参数初始化的非对称加密算法的公钥加密文本数据，并返回加密后数据的Base64编码文本
	/// </summary>
	/// <param name="text">待加密的文本数据</param>
	/// <param name="parameter">算法参数</param>
	/// <param name="encoding">加密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据的Base64编码文本</returns>
	/// <exception cref="T:System.ArgumentNullException">加密的文本数据为空；或者算法参数为空。</exception>
	public static string PublicEncryptTextToBase64(string text, string parameter, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(parameter, "parameter");
		using IAsymmetricAlgorithm algorithm = AlgorithmHelper.GetAsymmetricAlgorithm(parameter);
		return algorithm.PublicEncryptTextToBase64(text, encoding);
	}
}
