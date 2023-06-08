using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 非对称加解密算法接口
/// </summary>
public interface IAsymmetricAlgorithm : IAlgorithm, IDisposable
{
	/// <summary>
	/// 获取密钥交换算法的名称
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	string KeyExchangeAlgorithm { get; }

	/// <summary>
	/// 获取或设置不对称算法所用密钥模块的大小（以位为单位）
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥模块大小无效。</exception>
	int KeySize { get; set; }

	/// <summary>
	/// 获取不对称算法支持的密钥大小
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	KeySizes[] LegalKeySizes { get; }

	/// <summary>
	/// 获取签名算法的名称
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	string SignatureAlgorithm { get; }

	/// <summary>
	/// 获取当前非对称加密算法支持的密钥大小；密钥长度单位：位。
	/// </summary>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	int[] ValidKeySizes { get; }

	/// <summary>
	/// 释放当前算法使用的所有资源
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	void Clear();

	/// <summary>
	/// 通过从XML字符串中加载的参数信息初始化RSA算法对象
	/// </summary>
	/// <param name="xml">XML参数字符串</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">Xml参数字符串 <paramref name="xml" /> 为空。</exception>
	void FromXmlString(string xml);

	/// <summary>
	/// 使用私钥解密数据
	/// </summary>
	/// <param name="data">待解密数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	byte[] PrivateDecrypt(byte[] data);

	/// <summary>
	/// 使用私钥解密字节数据
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节数据为空。 </exception>
	byte[] PrivateDecryptBytes(byte[] data);

	/// <summary>
	/// 使用私钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待解密的Base64编码字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的Base64编码的字节数据为空。 </exception>
	byte[] PrivateDecryptBytesFromBase64(string data);

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateDecryptFile(string file);

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateDecryptFile(FileInfo file);

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateDecryptFile(string input, string output);

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者解密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateDecryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 使用私钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <returns> 解密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空。 </exception>
	Stream PrivateDecryptStream(Stream data);

	/// <summary>
	/// 使用私钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <param name="result"> 解密后输出的字节流 </param>
	/// <returns> 实际解密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空；或者输出字节流为空。 </exception>
	int PrivateDecryptStream(Stream data, Stream result);

	/// <summary>
	/// 使用私钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的字节数据为空。 </exception>
	string PrivateDecryptText(byte[] data, Encoding encoding = null);

	/// <summary>
	/// 使用私钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的Base64编码的字节数据为空。 </exception>
	string PrivateDecryptTextFromBase64(string data, Encoding encoding = null);

	/// <summary>
	/// 使用私钥加密数据
	/// </summary>
	/// <param name="data">待加密数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	byte[] PrivateEncrypt(byte[] data);

	/// <summary>
	/// 使用私钥加密字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	byte[] PrivateEncryptBytes(byte[] data);

	/// <summary>
	/// 使用私钥加密字节数据，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据。 </exception>
	string PrivateEncryptBytesToBase64(byte[] data);

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateEncryptFile(string file);

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateEncryptFile(FileInfo file);

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateEncryptFile(string input, string output);

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者加密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PrivateEncryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 使用私钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <returns> 加密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空。 </exception>
	Stream PrivateEncryptStream(Stream data);

	/// <summary>
	/// 使用私钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <param name="result"> 加密后输出的字节流 </param>
	/// <returns> 实际加密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空；或者输出字节流为空。 </exception>
	int PrivateEncryptStream(Stream data, Stream result);

	/// <summary>
	/// 使用私钥加密文本数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 加密的文本数据为空。 </exception>
	byte[] PrivateEncryptText(string text, Encoding encoding = null);

	/// <summary>
	/// 使用私钥加密文本数据，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	string PrivateEncryptTextToBase64(string text, Encoding encoding = null);

	/// <summary>
	/// 使用公钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	byte[] PublicDecrypt(byte[] data);

	/// <summary>
	/// 使用公钥解密字节数据
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节数据为空。 </exception>
	byte[] PublicDecryptBytes(byte[] data);

	/// <summary>
	/// 使用公钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待解密的Base64编码字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的Base64编码的字节数据为空。 </exception>
	byte[] PublicDecryptBytesFromBase64(string data);

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicDecryptFile(string file);

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicDecryptFile(FileInfo file);

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicDecryptFile(string input, string output);

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者解密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicDecryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 使用公钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <returns> 解密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空。 </exception>
	Stream PublicDecryptStream(Stream data);

	/// <summary>
	/// 使用公钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <param name="result"> 解密后输出的字节流 </param>
	/// <returns> 实际解密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空；或者输出字节流为空。 </exception>
	int PublicDecryptStream(Stream data, Stream result);

	/// <summary>
	/// 使用公钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的字节数据为空。 </exception>
	string PublicDecryptText(byte[] data, Encoding encoding = null);

	/// <summary>
	/// 使用公钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的Base64编码的字节数据为空。 </exception>
	string PublicDecryptTextFromBase64(string data, Encoding encoding = null);

	/// <summary>
	/// 使用公钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	byte[] PublicEncrypt(byte[] data);

	/// <summary>
	/// 使用公钥加密字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	byte[] PublicEncryptBytes(byte[] data);

	/// <summary>
	/// 使用公钥加密字节数，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	string PublicEncryptBytesToBase64(byte[] data);

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicEncryptFile(string file);

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicEncryptFile(FileInfo file);

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicEncryptFile(string input, string output);

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者加密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	void PublicEncryptFile(FileInfo input, FileInfo output);

	/// <summary>
	/// 使用公钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <returns> 加密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空。 </exception>
	Stream PublicEncryptStream(Stream data);

	/// <summary>
	/// 使用公钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <param name="result"> 加密后输出的字节流 </param>
	/// <returns> 实际加密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空；或者输出字节流为空。 </exception>
	int PublicEncryptStream(Stream data, Stream result);

	/// <summary>
	/// 使用公钥加密文本数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	byte[] PublicEncryptText(string text, Encoding encoding = null);

	/// <summary>
	/// 使用公钥加密文本数据，并返回加密后的Base64编码的字节数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	string PublicEncryptTextToBase64(string text, Encoding encoding = null);

	/// <summary>
	/// 为指定的数据生成生成数据签名
	/// </summary>
	/// <param name="data">当前待签名的数据</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据 <paramref name="data" /> 为空。</exception>
	byte[] SignData(byte[] data);

	/// <summary>
	/// 为指定的数据流生成生成数据签名
	/// </summary>
	/// <param name="data">当前待签名的数据流</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据流 <paramref name="data" /> 为空。</exception>
	byte[] SignData(Stream data);

	/// <summary>
	/// 为指定的哈希值生成数字签名。
	/// </summary>
	/// <param name="hash">当前待签名的数据哈希值。</param>
	/// <returns>用私钥加密的数据哈希值的数字签名。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据哈希值 <paramref name="hash" /> 为空。</exception>
	byte[] SignHash(byte[] hash);

	/// <summary>
	/// 返回当前算法参数的Xml字符串
	/// </summary>
	/// <param name="includePrivateParameters">是否包含算法密钥</param>
	/// <returns>算法参数Xml字符串</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	string ToXmlString(bool includePrivateParameters);

	/// <summary>
	/// 根据指定的数字签名，验证当前数据
	/// </summary>
	/// <param name="data">当前待验证的数据</param>
	/// <param name="signature">数据的数字签名</param>
	/// <returns>如果待验证的数据与给定的数字签名匹配则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待验证的数据 <paramref name="data" /> 为空；或者数据的数字签名 <paramref name="signature" /> 为空。</exception>
	bool VerifyData(byte[] data, byte[] signature);

	/// <summary>
	/// 根据指定的数字签名，验证当前数据流
	/// </summary>
	/// <param name="data">待验证的数据流</param>
	/// <param name="signature">数据流的数字签名</param>
	/// <returns>如果待验证的数据流与给定的数字签名匹配则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待验证的数据流 <paramref name="data" /> 为空；或者数据流的数字签名 <paramref name="signature" /> 为空。</exception>
	bool VerifyData(Stream data, byte[] signature);

	/// <summary>
	/// 根据指定的数字签名，验证数据哈希值
	/// </summary>
	/// <param name="hash">当前待验证的数据哈希值</param>
	/// <param name="signature">数据哈希值的数字签名</param>
	/// <returns>如果当前待验证的数据哈希值与数字签名匹配则返回true。否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据哈希值 <paramref name="hash" /> 为空；或者数据的数字签名 <paramref name="signature" /> 为空。</exception>
	bool VerifyHash(byte[] hash, byte[] signature);
}
