using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 通用非对称加密算法包装基类
/// </summary>
/// <typeparam name="A">加密算法基础实现类型</typeparam>
public class GenericAsymmetricAlgorithm<A> : AsymmetricAlgorithm, IAsymmetricAlgorithm, IAlgorithm, IDisposable where A : AsymmetricAlgorithm
{
	/// <summary>
	/// 加密算法基础实现对象
	/// </summary>
	private A algorithm;

	/// <summary>
	/// 算法名称
	/// </summary>
	private string name;

	/// <summary>
	/// 获取或者设置算法基础实现对象
	/// </summary>
	protected A Algorithm
	{
		get
		{
			return algorithm;
		}
		set
		{
			algorithm = value;
		}
	}

	/// <summary>
	/// 获取或者设置算法名称
	/// </summary>
	public string Name
	{
		get
		{
			return name.IfNull(GetType().Name);
		}
		set
		{
			name = value;
		}
	}

	/// <summary>
	/// 获取密钥交换算法的名称
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public override string KeyExchangeAlgorithm
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.KeyExchangeAlgorithm;
		}
	}

	/// <summary>
	/// 获取或设置不对称算法所用密钥模块的大小（以位为单位）
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥模块大小无效。</exception>
	public override int KeySize
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.KeySize;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.KeySize = value;
		}
	}

	/// <summary>
	/// 获取不对称算法支持的密钥大小
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public override KeySizes[] LegalKeySizes
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.LegalKeySizes;
		}
	}

	/// <summary>
	/// 获取签名算法的名称
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public override string SignatureAlgorithm
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.SignatureAlgorithm;
		}
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的密钥大小；密钥长度单位：位。
	/// </summary>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public int[] ValidKeySizes
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return AlgorithmHelper.GetValidKeySizes(algorithm);
		}
	}

	/// <summary>
	/// 默认初始化
	/// </summary>
	public GenericAsymmetricAlgorithm()
	{
		algorithm = typeof(A).CreateInstance<A>();
	}

	/// <summary>
	/// 按指定的基础算法密钥大小初始化
	/// </summary>
	/// <param name="keySize">算法密钥大小</param>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">指定的算法密钥大小无效。</exception>
	public GenericAsymmetricAlgorithm(int keySize)
		: this()
	{
		algorithm.KeySize = keySize;
	}

	/// <summary>
	/// 使用指定的基础算法创建方法进行初始化
	/// </summary>
	/// <param name="creator">基础算法创建方法</param>
	/// <exception cref="T:System.ArgumentNullException">基础算法创建方法为空。</exception>
	/// <exception cref="T:System.ArgumentException">基础算法创建方法返回空。</exception>
	public GenericAsymmetricAlgorithm(Func<A> creator)
	{
		Guard.EnsureNotNull(creator, "creator");
		algorithm = Guard.EnsureNotNull(creator(), "algorithm");
	}

	/// <summary>
	/// 使用指定的基础算法进行初始化
	/// </summary>
	/// <param name="algorithm">指定的基础算法</param>
	/// <exception cref="T:System.ArgumentNullException">指定的基础算法为空。</exception>
	public GenericAsymmetricAlgorithm(A algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		this.algorithm = algorithm;
	}

	/// <summary>
	/// 释放由当前算法对象占用的非托管资源，还可以另外再释放托管资源。
	/// </summary>
	/// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && algorithm.IsNotNull())
		{
			algorithm.Dispose();
			algorithm = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 使用公钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待解密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] Decrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("Decrypt", data);
	}

	/// <summary>
	/// 使用私钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] Encrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("Encrypt", data);
	}

	/// <summary>
	/// 通过从XML字符串中加载的参数信息初始化RSA算法对象
	/// </summary>
	/// <param name="xml">XML参数字符串</param>
	/// <exception cref="T:System.ArgumentNullException">Xml参数字符串 <paramref name="xml" /> 为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	public override void FromXmlString(string xml)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(xml, "rsa xml");
		algorithm.FromXmlString(xml);
	}

	/// <summary>
	/// 使用私钥解密数据
	/// </summary>
	/// <param name="data">待解密数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] PrivateDecrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("PrivateDecrypt", data);
	}

	/// <summary>
	/// 使用私钥解密字节数据
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节数据为空。 </exception>
	public byte[] PrivateDecryptBytes(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.AsymmetricDecrypt(data, (byte[] x) => PrivateDecrypt(x));
	}

	/// <summary>
	/// 使用私钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待解密的Base64编码字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的Base64编码的字节数据为空。 </exception>
	public byte[] PrivateDecryptBytesFromBase64(string data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return PrivateDecryptBytes(Convert.FromBase64String(data));
	}

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateDecryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		PrivateDecryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateDecryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			PrivateDecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateDecryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureNotNull(output, "output file");
		PrivateDecryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用私钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者解密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateDecryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			PrivateDecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用私钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <returns> 解密后的字节流 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空。 </exception>
	public Stream PrivateDecryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		MemoryStream result = new MemoryStream();
		AlgorithmHelper.AsymmetricDecrypt(data, result, (byte[] x) => PrivateDecrypt(x));
		return result;
	}

	/// <summary>
	/// 使用私钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <param name="result"> 解密后输出的字节流 </param>
	/// <returns> 实际解密的字节数量 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空；或者输出字节流为空。 </exception>
	public int PrivateDecryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.AsymmetricDecrypt(data, result, (byte[] x) => PrivateDecrypt(x));
	}

	/// <summary>
	/// 使用私钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 解密的字节数据为空。 </exception>
	public string PrivateDecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetString(PrivateDecryptBytes(data));
	}

	/// <summary>
	/// 使用私钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的Base64编码的字节数据为空。 </exception>
	public string PrivateDecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return PrivateDecryptText(Convert.FromBase64String(data), encoding);
	}

	/// <summary>
	/// 使用私钥加密数据
	/// </summary>
	/// <param name="data">待加密数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] PrivateEncrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("PrivateEncrypt", data);
	}

	/// <summary>
	/// 使用私钥加密字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	public byte[] PrivateEncryptBytes(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.AsymmetricEncrypt(data, (byte[] x) => PrivateEncrypt(x));
	}

	/// <summary>
	/// 使用私钥加密字节数据，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据。 </exception>
	public string PrivateEncryptBytesToBase64(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return Convert.ToBase64String(PrivateEncryptBytes(data));
	}

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateEncryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		PrivateEncryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateEncryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			PrivateEncryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateEncryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureNotNull(output, "output file");
		PrivateEncryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用私钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者加密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PrivateEncryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			PrivateEncryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用私钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <returns> 加密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空。 </exception>
	public Stream PrivateEncryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Stream result = new MemoryStream();
		AlgorithmHelper.AsymmetricEncrypt(data, result, (byte[] x) => PrivateEncrypt(x));
		return result;
	}

	/// <summary>
	/// 使用私钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <param name="result"> 加密后输出的字节流 </param>
	/// <returns> 实际加密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空；或者输出字节流为空。 </exception>
	public int PrivateEncryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.AsymmetricEncrypt(data, result, (byte[] x) => PrivateEncrypt(x));
	}

	/// <summary>
	/// 使用私钥加密文本数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 加密的文本数据为空。 </exception>
	public byte[] PrivateEncryptText(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return PrivateEncryptBytes(encoding.GetBytes(text));
	}

	/// <summary>
	/// 使用私钥加密文本数据，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	public string PrivateEncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		return Convert.ToBase64String(PrivateEncryptText(text, encoding));
	}

	/// <summary>
	/// 使用公钥解密数据
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] PublicDecrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("PublicDecrypt", data);
	}

	/// <summary>
	/// 使用公钥解密字节数据
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节数据为空。 </exception>
	public byte[] PublicDecryptBytes(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.AsymmetricDecrypt(data, (byte[] x) => PrivateDecrypt(x));
	}

	/// <summary>
	/// 使用公钥解密Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待解密的Base64编码字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的Base64编码的字节数据为空。 </exception>
	public byte[] PublicDecryptBytesFromBase64(string data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return PublicDecryptBytes(Convert.FromBase64String(data));
	}

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicDecryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		PublicDecryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicDecryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			PublicDecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicDecryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureNotNull(output, "output file");
		PublicDecryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用公钥解密当前文件的数据，解密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待解密的文件 </param>
	/// <param name="output"> 解密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者解密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicDecryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			PublicDecryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用公钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <returns> 解密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空。 </exception>
	public Stream PublicDecryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		MemoryStream result = new MemoryStream();
		AlgorithmHelper.AsymmetricDecrypt(data, result, (byte[] x) => PublicDecrypt(x));
		return result;
	}

	/// <summary>
	/// 使用公钥解密字节流
	/// </summary>
	/// <param name="data"> 待解密的字节流 </param>
	/// <param name="result"> 解密后输出的字节流 </param>
	/// <returns> 实际解密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待解密的字节流为空；或者输出字节流为空。 </exception>
	public int PublicDecryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.AsymmetricDecrypt(data, result, (byte[] x) => PublicDecrypt(x));
	}

	/// <summary>
	/// 使用公钥解密字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的字节数据为空。 </exception>
	public string PublicDecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetString(PublicDecryptBytes(data));
	}

	/// <summary>
	/// 使用公钥解密Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 解密的Base64编码的字节数据为空。 </exception>
	public string PublicDecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return PublicDecryptText(Convert.FromBase64String(data), encoding);
	}

	/// <summary>
	/// 使用公钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] PublicEncrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("PublicEncrypt", data);
	}

	/// <summary>
	/// 使用公钥加密字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	public byte[] PublicEncryptBytes(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.AsymmetricEncrypt(data, (byte[] x) => PublicEncrypt(x));
	}

	/// <summary>
	/// 使用公钥加密字节数，并返回加密后Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节数据为空。 </exception>
	public string PublicEncryptBytesToBase64(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return Convert.ToBase64String(PublicEncryptBytes(data));
	}

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicEncryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		PublicEncryptFile(new FileInfo(file));
	}

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicEncryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			PublicEncryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据写入输出文件
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentException"> 当前文件名称无效；或者输出文件不存在。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicEncryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureNotNull(output, "output file");
		PublicEncryptFile(new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用公钥加密当前文件的数据，加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="input"> 当前待加密的文件 </param>
	/// <param name="output"> 加密后的结果文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前文件为空；或者加密结果文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前文件不存在。 </exception>
	public void PublicEncryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			PublicEncryptStream(i, o);
		});
	}

	/// <summary>
	/// 使用公钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <returns> 加密后的字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空。 </exception>
	public Stream PublicEncryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Stream result = new MemoryStream();
		AlgorithmHelper.AsymmetricEncrypt(data, result, (byte[] x) => PublicEncrypt(x));
		return result;
	}

	/// <summary>
	/// 使用公钥加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <param name="result"> 加密后输出的字节流 </param>
	/// <returns> 实际加密的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流为空；或者输出字节流为空。 </exception>
	public int PublicEncryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.AsymmetricEncrypt(data, result, (byte[] x) => PublicEncrypt(x));
	}

	/// <summary>
	/// 使用公钥加密文本数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	public byte[] PublicEncryptText(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return PublicEncryptBytes(encoding.GetBytes(text));
	}

	/// <summary>
	/// 使用公钥加密文本数据，并返回加密后的Base64编码的字节数据
	/// </summary>
	/// <param name="text"> 待加密的文本数据 </param>
	/// <param name="encoding"> 加密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 加密后的Base64编码的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的文本数据为空。 </exception>
	public string PublicEncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		return Convert.ToBase64String(PublicEncryptText(text, encoding));
	}

	/// <summary>
	/// 为指定的数据生成生成数据签名
	/// </summary>
	/// <param name="data">当前待签名的数据</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据 <paramref name="data" /> 为空。</exception>
	public virtual byte[] SignData(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("SignData", data);
	}

	/// <summary>
	/// 为指定的数据流生成生成数据签名
	/// </summary>
	/// <param name="data">当前待签名的数据流</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据流 <paramref name="data" /> 为空。</exception>
	public virtual byte[] SignData(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return (byte[])InvokeMethod("SignData", data);
	}

	/// <summary>
	/// 为指定的哈希值生成数字签名。
	/// </summary>
	/// <param name="hash">当前待签名的数据哈希值。</param>
	/// <returns>用私钥加密的数据哈希值的数字签名。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据哈希值 <paramref name="hash" /> 为空。</exception>
	public virtual byte[] SignHash(byte[] hash)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(hash, "hash");
		return (byte[])InvokeMethod("SignHash", hash);
	}

	/// <summary>
	/// 返回当前算法参数的Xml字符串
	/// </summary>
	/// <param name="includePrivateParameters">是否包含算法密钥</param>
	/// <returns>算法参数Xml字符串</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	public override string ToXmlString(bool includePrivateParameters)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return algorithm.ToXmlString(includePrivateParameters);
	}

	/// <summary>
	/// 根据指定的数字签名，验证当前数据
	/// </summary>
	/// <param name="data">当前待验证的数据</param>
	/// <param name="signature">数据的数字签名</param>
	/// <returns>如果待验证的数据与给定的数字签名匹配则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待验证的数据 <paramref name="data" /> 为空；或者数据的数字签名 <paramref name="signature" /> 为空。</exception>
	public virtual bool VerifyData(byte[] data, byte[] signature)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(signature, "signature");
		return (bool)InvokeMethod("VerifyData", data, signature);
	}

	/// <summary>
	/// 根据指定的数字签名，验证当前数据流
	/// </summary>
	/// <param name="data">待验证的数据流</param>
	/// <param name="signature">数据流的数字签名</param>
	/// <returns>如果待验证的数据流与给定的数字签名匹配则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待验证的数据流 <paramref name="data" /> 为空；或者数据流的数字签名 <paramref name="signature" /> 为空。</exception>
	public virtual bool VerifyData(Stream data, byte[] signature)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(signature, "signature");
		return (bool)InvokeMethod("VerifyData", data, signature);
	}

	/// <summary>
	/// 根据指定的数字签名，验证数据哈希值
	/// </summary>
	/// <param name="hash">当前待验证的数据哈希值</param>
	/// <param name="signature">数据哈希值的数字签名</param>
	/// <returns>如果当前待验证的数据哈希值与数字签名匹配则返回true。否则返回false。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前待签名的数据哈希值 <paramref name="hash" /> 为空；或者数据的数字签名 <paramref name="signature" /> 为空。</exception>
	public virtual bool VerifyHash(byte[] hash, byte[] signature)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(hash, "data");
		Guard.EnsureNotNull(signature, "signature");
		return (bool)InvokeMethod("VerifyHash", hash, signature);
	}

	private object InvokeMethod(string methodName, params object[] args)
	{
		MethodInfo minfo = algorithm.GetType().GetMethod(methodName, args.GetTypeArray());
		if (minfo.IsNull())
		{
			throw new NotSupportedException(Literals.MSG_MethodInvokedNotSupport_1.FormatValue(methodName));
		}
		return minfo.Invoke(algorithm, args);
	}

	void IAsymmetricAlgorithm.Clear()
	{
		Clear();
	}
}
