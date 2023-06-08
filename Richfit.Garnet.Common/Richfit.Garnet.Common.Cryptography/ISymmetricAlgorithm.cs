using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 对称加解密算法接口
/// </summary>
public interface ISymmetricAlgorithm : IAlgorithm, IDisposable
{
	/// <summary>
	/// 获取或设置加密操作的块大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的块大小无效。</exception>
	int BlockSize { get; set; }

	/// <summary>
	/// 获取或设置加密操作的反馈大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的反馈块的大小无效。</exception>
	int FeedbackSize { get; set; }

	/// <summary>
	/// 获取或设置对称算法的初始化向量 (IV)。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">设置的初始化向量为空。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的初始化向量大小无效。</exception>
	byte[] IV { get; set; }

	/// <summary>
	/// 获取或设置对称算法的密钥。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">设置的密钥为空。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥大小无效。</exception>
	byte[] Key { get; set; }

	/// <summary>
	/// 获取或设置对称算法所用密钥的大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥大小无效。</exception>
	int KeySize { get; set; }

	/// <summary>
	/// 获取对称算法支持的块大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	KeySizes[] LegalBlockSizes { get; }

	/// <summary>
	/// 获取对称算法支持的密钥大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	KeySizes[] LegalKeySizes { get; }

	/// <summary>
	/// 获取或设置对称算法的运算模式。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	CipherMode Mode { get; set; }

	/// <summary>
	/// 获取或设置对称算法中使用的填充模式。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	PaddingMode Padding { get; set; }

	/// <summary>
	/// 获取当前对称加密算法支持的数据块大小；数据库长度单位：位。
	/// </summary>
	/// <returns>支持的数据块大小列表</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	int[] ValidBlockSizes { get; }

	/// <summary>
	/// 获取当前对称加密算法支持的密钥长度的数组；密钥长度单位：位。
	/// </summary>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	int[] ValidKeySizes { get; }

	/// <summary>
	/// 更改当前对称加解密算法的密钥
	/// </summary>
	/// <param name="password">变更的新密钥</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前加密算法对象为空；或者变更的新密钥为空。</exception>
	void ChangePassword(string password);

	/// <summary>
	/// 释放由当前算法使用的所有资源。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	void Clear();

	/// <summary>
	/// 用当前的 Key 属性和初始化向量 (IV) 创建对称解密器对象。
	/// </summary>
	/// <returns>对称解密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	ICryptoTransform CreateDecryptor();

	/// <summary>
	/// 当在派生类中重写时，用指定的 Key 属性和初始化向量 (IV) 创建对称解密器对象。
	/// </summary>
	/// <param name="key">用于对称算法的密钥。</param>
	/// <param name="iv">用于对称算法的初始化向量。</param>
	/// <returns>对称解密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">算法密钥或者初始化向量为空。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">算法密钥或者初始化向量大小无效。</exception>
	ICryptoTransform CreateDecryptor(byte[] key, byte[] iv);

	/// <summary>
	/// 用当前的 Key 属性和初始化向量 ( IV) 创建对称加密器对象。
	/// </summary>
	/// <returns>对称加密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	ICryptoTransform CreateEncryptor();

	/// <summary>
	/// 当在派生类中重写时，用指定的 Key 属性和初始化向量 (IV) 创建对称加密器对象。
	/// </summary>
	/// <param name="key">用于对称算法的密钥。</param>
	/// <param name="iv">用于对称算法的初始化向量。</param>
	/// <returns>对称加密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">算法密钥或者初始化向量大小无效。</exception>
	ICryptoTransform CreateEncryptor(byte[] key, byte[] iv);

	/// <summary>
	/// 解密当前字节数据
	/// </summary>
	/// <param name="data"> 当前字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前字节数据 <paramref name="data" /> 为空。</exception>
	byte[] DecryptBytes(byte[] data);

	/// <summary>
	/// 解密当前Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 当前Base64编码的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前Base64编码的字节数据 <paramref name="data" /> 为空。</exception>
	byte[] DecryptBytesFromBase64(string data);

	/// <summary>
	/// 解密当前文件，并将解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的文件全名 <paramref name="file" /> 为空。</exception>
	void DecryptFile(string file);

	/// <summary>
	/// 解密当前文件，并将解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的文件 <paramref name="file" /> 为空。</exception>
	void DecryptFile(FileInfo file);

	/// <summary>
	/// 解密输入文件，并将解密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待解密的输入文件全名 </param>
	/// <param name="output"> 解密后的数据写入的输出文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件全名为空；或者输出文件全名为空。 </exception>
	void DecryptFile(string input, string output);

	/// <summary>
	/// 解密输入文件，并将解密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待解密的输入文件 </param>
	/// <param name="output"> 解密后的数据写入的输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件为空；或者输出文件为空。 </exception>
	void DecryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 解密当前字节流，并返回解密后的字节流
	/// </summary>
	/// <param name="data"> 当前待解密的字节流 </param>
	/// <returns> 解密后的新字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节流为空。 </exception>
	Stream DecryptStream(Stream data);

	/// <summary>
	/// 解密当前字节流，并将解密后的数据写入结果字节流
	/// </summary>
	/// <param name="data"> 当前待解密的字节流 </param>
	/// <param name="result"> 解密后的结果字节流 </param>
	/// <returns> 实际解密后的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节流为空；或者解密数据写入的结果字节流为空。 </exception>
	int DecryptStream(Stream data, Stream result);

	/// <summary>
	/// 解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 当前待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节数据为空。 </exception>
	string DecryptText(byte[] data, Encoding encoding = null);

	/// <summary>
	/// 解密当前Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 当前待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的Base64编码的字节数据为空。 </exception>
	string DecryptTextFromBase64(string data, Encoding encoding = null);

	/// <summary>
	/// 加密当前字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的字节数据为空。 </exception>
	byte[] EncryptBytes(byte[] data);

	/// <summary>
	/// 加密当前字节数据，并将加密后的数据转换为Base64编码的字符串
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns></returns>
	string EncryptBytesToBase64(byte[] data);

	/// <summary>
	/// 加密当前文件，并将加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文件全名 <paramref name="file" /> 为空。</exception>
	void EncryptFile(string file);

	/// <summary>
	/// 加密当前文件，并将加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文件 <paramref name="file" /> 为空。</exception>
	void EncryptFile(FileInfo file);

	/// <summary>
	/// 加密输入文件，并将加密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待加密的输入文件全名 </param>
	/// <param name="output"> 加密后的数据写入的输出文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件全名为空；或者输出文件全名为空。 </exception>
	void EncryptFile(string input, string output);

	/// <summary>
	/// 加密输入文件，并将加密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待加密的输入文件 </param>
	/// <param name="output"> 加密后的数据写入的输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件为空；或者输出文件为空。 </exception>
	void EncryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 加密当前字节流，并返回加密后的字节流
	/// </summary>
	/// <param name="data"> 当前待加密的字节流 </param>
	/// <returns> 加密后的新字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的字节流为空。 </exception>
	Stream EncryptStream(Stream data);

	/// <summary>
	/// 加密当前字节流，并将加密后的数据写入结果字节流
	/// </summary>
	/// <param name="data"> 当前待加密的字节流 </param>
	/// <param name="result"> 加密后的结果字节流 </param>
	/// <returns> 实际加密后的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的字节流为空；或者解密数据写入的结果字节流为空。 </exception>
	int EncryptStream(Stream data, Stream result);

	/// <summary>
	/// 加密当前文本数据
	/// </summary>
	/// <param name="text"> 当前待加密的文本 </param>
	/// <param name="encoding"> 加密时使用的文本编码 </param>
	/// <returns> 加密后的字节 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文本为空。 </exception>
	byte[] EncryptText(string text, Encoding encoding = null);

	/// <summary>
	/// 加密当前文本数据，并将加密后的字节数据转换为Base64编码的字符串
	/// </summary>
	/// <param name="text"> 当前待加密的文本 </param>
	/// <param name="encoding"> 加密时使用的文本编码 </param>
	/// <returns> 加密后的字节的Base64编码字符串 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文本为空。 </exception>
	string EncryptTextToBase64(string text, Encoding encoding = null);

	/// <summary>
	/// 导出当前对称算法的参数对象
	/// </summary>
	/// <returns>导出的算法参数对象</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空。</exception>
	SymmetricParameter ExportParameter();

	/// <summary>
	/// 当在派生类中重写时，生成用于该算法的随机初始化向量 (IV)。
	/// </summary>
	/// <returns>生成的随机初始化向量</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	byte[] GenerateIV();

	/// <summary>
	/// 当在派生类中重写时，生成用于该算法的随机密钥 (Key)。
	/// </summary>
	/// <returns>生成的随机密钥</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	byte[] GenerateKey();

	/// <summary>
	/// 导入当前对称算法的参数对象
	/// </summary>
	/// <param name="parameter">导入的参数对象</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空；或者导入的参数对象为空。</exception>
	void ImportParameter(SymmetricParameter parameter);

	/// <summary>
	/// 确定指定的密钥大小对当前算法是否有效。
	/// </summary>
	/// <param name="length">用于检查有效密钥大小的长度（以位为单位）。</param>
	/// <returns>如果指定的密钥大小对当前算法有效，则为 true；否则，为 false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	bool ValidKeySize(int length);
}
