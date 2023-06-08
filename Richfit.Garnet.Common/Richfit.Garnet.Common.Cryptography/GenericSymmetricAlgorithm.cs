using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 通用对称加密算法包装类
/// </summary>
/// <typeparam name="A">加密算法基础实现类型</typeparam>
public class GenericSymmetricAlgorithm<A> : SymmetricAlgorithm, ISymmetricAlgorithm, IAlgorithm, IDisposable where A : SymmetricAlgorithm
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
	/// 获取或设置加密操作的块大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的块大小无效。</exception>
	public override int BlockSize
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.BlockSize;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.BlockSize = value;
		}
	}

	/// <summary>
	/// 获取或设置加密操作的反馈大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的反馈块的大小无效。</exception>
	public override int FeedbackSize
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.FeedbackSize;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.FeedbackSize = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的初始化向量 (IV)。 
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.ArgumentNullException">设置的初始化向量为空。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的初始化向量大小无效。</exception>
	public override byte[] IV
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.IV;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.IV = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的密钥。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.ArgumentNullException">设置的密钥为空。</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥大小无效。</exception>
	public override byte[] Key
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.Key;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.Key = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法所用密钥的大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">设置的密钥大小无效。</exception>
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
	/// 获取对称算法支持的块大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override KeySizes[] LegalBlockSizes
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.LegalBlockSizes;
		}
	}

	/// <summary>
	/// 获取对称算法支持的密钥大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override KeySizes[] LegalKeySizes
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.LegalKeySizes;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的运算模式。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override CipherMode Mode
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.Mode;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.Mode = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法中使用的填充模式。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override PaddingMode Padding
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return algorithm.Padding;
		}
		set
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			algorithm.Padding = value;
		}
	}

	/// <summary>
	/// 获取当前对称加密算法支持的数据块大小；数据库长度单位：位。
	/// </summary>
	/// <returns>支持的数据块大小列表</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public int[] ValidBlockSizes
	{
		get
		{
			Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return AlgorithmHelper.GetValidBlockSizes(algorithm);
		}
	}

	/// <summary>
	/// 获取当前对称加密算法支持的密钥长度的数组；密钥长度单位：位。
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
	/// 初始化默认算法对象
	/// </summary>
	public GenericSymmetricAlgorithm()
	{
		algorithm = typeof(A).CreateInstance<A>();
	}

	/// <summary>
	/// 使用指定的密钥和初始向量初始化算法对象
	/// </summary>
	/// <param name="key">算法密码</param>
	/// <param name="iv">算法初始化向量</param>
	/// <exception cref="T:System.ArgumentNullException">算法密码 <paramref name="key" /> 为空；或者算法初始化向量 <paramref name="iv" /> 为空。</exception>
	public GenericSymmetricAlgorithm(byte[] key, byte[] iv)
		: this()
	{
		Guard.EnsureNotNull(key, "Key");
		Guard.EnsureNotNull(iv, "IV");
		algorithm.Key = key;
		algorithm.IV = iv;
	}

	/// <summary>
	/// 使用指定的基础算法创建方法进行初始化
	/// </summary>
	/// <param name="creator">基础算法创建方法</param>
	/// <exception cref="T:System.ArgumentNullException">基础算法创建方法为空。</exception>
	/// <exception cref="T:System.ArgumentException">基础算法创建方法返回空。</exception>
	public GenericSymmetricAlgorithm(Func<A> creator)
	{
		Guard.EnsureNotNull(creator, "creator");
		algorithm = Guard.EnsureNotNull(creator(), "algorithm");
	}

	/// <summary>
	/// 使用指定的基础算法对象初始化
	/// </summary>
	/// <param name="algorithm">基础算法对象</param>
	/// <exception cref="T:System.ArgumentNullException">基础算法对象为空。</exception>
	public GenericSymmetricAlgorithm(A algorithm)
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
	/// 更改当前对称加解密算法的密钥
	/// </summary>
	/// <param name="password">变更的新密钥</param>
	/// <exception cref="T:System.ArgumentNullException">当前加密算法对象为空；或者变更的新密钥为空。</exception>
	public void ChangePassword(string password)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(password, "password");
		AlgorithmHelper.ChangePassword(algorithm, password);
	}

	/// <summary>
	/// 用当前的 Key 属性和初始化向量 IV 创建对称解密器对象。
	/// </summary>
	/// <returns>对称解密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override ICryptoTransform CreateDecryptor()
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return algorithm.CreateDecryptor();
	}

	/// <summary>
	/// 当在派生类中重写时，用指定的 Key 属性和初始化向量 ( IV) 创建对称解密器对象。
	/// </summary>
	/// <param name="key">用于对称算法的密钥。</param>
	/// <param name="iv">用于对称算法的初始化向量。</param>
	/// <returns>对称解密器对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="key" /> 为空；或者初始化向量 <paramref name="iv" /> 为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override ICryptoTransform CreateDecryptor(byte[] key, byte[] iv)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(key, "Key");
		Guard.EnsureNotNull(iv, "IV");
		return algorithm.CreateDecryptor(key, iv);
	}

	/// <summary>
	/// 用当前的 Key 属性和初始化向量 ( IV) 创建对称加密器对象。
	/// </summary>
	/// <returns>对称加密器对象。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override ICryptoTransform CreateEncryptor()
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return algorithm.CreateEncryptor();
	}

	/// <summary>
	/// 当在派生类中重写时，用指定的 Key 属性和初始化向量 ( IV) 创建对称加密器对象。
	/// </summary>
	/// <param name="key">用于对称算法的密钥。</param>
	/// <param name="iv">用于对称算法的初始化向量。</param>
	/// <returns>对称加密器对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="key" /> 为空；或者初始化向量 <paramref name="iv" /> 为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override ICryptoTransform CreateEncryptor(byte[] key, byte[] iv)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(key, "Key");
		Guard.EnsureNotNull(iv, "IV");
		return algorithm.CreateEncryptor(key, iv);
	}

	/// <summary>
	/// 解密字节数据
	/// </summary>
	/// <param name="data">待解密的字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.ArgumentNullException">待解密的字节数据 <paramref name="data" />为空。</exception>
	public byte[] Decrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.DecryptBytes(this, data);
	}

	/// <summary>
	/// 解密当前字节数据
	/// </summary>
	/// <param name="data"> 当前字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前字节数据 <paramref name="data" /> 为空。</exception>
	public byte[] DecryptBytes(byte[] data)
	{
		return Decrypt(data);
	}

	/// <summary>
	/// 解密当前Base64编码的字节数据
	/// </summary>
	/// <param name="data"> 当前Base64编码的字节数据 </param>
	/// <returns> 解密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前Base64编码的字节数据 <paramref name="data" /> 为空。</exception>
	public byte[] DecryptBytesFromBase64(string data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.DecryptBytesFromBase64(this, data);
	}

	/// <summary>
	/// 解密当前文件，并将解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的文件全名 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前待解密的文件不存在。 </exception>
	public void DecryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.DecryptFile(this, file);
	}

	/// <summary>
	/// 解密当前文件，并将解密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待解密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的文件 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前待解密的文件不存在。 </exception>
	public void DecryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.DecryptFile(this, file);
	}

	/// <summary>
	/// 解密输入文件，并将解密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待解密的输入文件全名 </param>
	/// <param name="output"> 解密后的数据写入的输出文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件全名为空；或者输出文件全名为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前待解密的输入文件不存在。 </exception>
	public void DecryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.DecryptFile(this, input, output);
	}

	/// <summary>
	/// 解密输入文件，并将解密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待解密的输入文件 </param>
	/// <param name="output"> 解密后的数据写入的输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件为空；或者输出文件为空。 </exception>
	/// <exception cref="T:System.IO.FileNotFoundException"> 当前待解密的输入文件不存在。 </exception>
	public void DecryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.DecryptFile(this, input, output);
	}

	/// <summary>
	/// 解密当前字节流，并返回解密后的字节流
	/// </summary>
	/// <param name="data"> 当前待解密的字节流 </param>
	/// <returns> 解密后的新字节流 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节流为空。 </exception>
	public Stream DecryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.DecryptStream(this, data);
	}

	/// <summary>
	/// 解密当前字节流，并将解密后的数据写入结果字节流
	/// </summary>
	/// <param name="data"> 当前待解密的字节流 </param>
	/// <param name="result"> 解密后的结果字节流 </param>
	/// <returns> 实际解密后的字节数量 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节流为空；或者解密数据写入的结果字节流为空。 </exception>
	public int DecryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.DecryptStream(this, data, result);
	}

	/// <summary>
	/// 解密当前字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 当前待解密的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的字节数据为空。 </exception>
	public string DecryptText(byte[] data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.DecryptText(this, data, encoding);
	}

	/// <summary>
	/// 解密当前Base64编码的字节数据，并按指定字符编码解码为文本
	/// </summary>
	/// <param name="data"> 当前待解密的Base64编码的字节数据 </param>
	/// <param name="encoding"> 解密文本的字符编码，默认为UTF-8编码 </param>
	/// <returns> 解密后的文本 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待解密的Base64编码的字节数据为空。 </exception>
	public string DecryptTextFromBase64(string data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.DecryptTextFromBase64(this, data, encoding);
	}

	/// <summary>
	/// 加密字节数据
	/// </summary>
	/// <param name="data">待加密的字节数据</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的字节数据 <paramref name="data" />为空。</exception>
	public byte[] Encrypt(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.EncryptBytes(this, data);
	}

	/// <summary>
	/// 加密当前字节数据
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns> 加密后的字节数据 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的字节数据为空。 </exception>
	public byte[] EncryptBytes(byte[] data)
	{
		return Encrypt(data);
	}

	/// <summary>
	/// 加密当前字节数据，并将加密后的数据转换为Base64编码的字符串
	/// </summary>
	/// <param name="data"> 待加密的字节数据 </param>
	/// <returns></returns>
	public string EncryptBytesToBase64(byte[] data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.EncryptBytesToBase64(this, data);
	}

	/// <summary>
	/// 加密当前文件，并将加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文件全名 <paramref name="file" /> 为空。</exception>
	public void EncryptFile(string file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		AlgorithmHelper.EncryptFile(this, file);
	}

	/// <summary>
	/// 加密当前文件，并将加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="file"> 当前待加密的文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文件 <paramref name="file" /> 为空。</exception>
	public void EncryptFile(FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		AlgorithmHelper.EncryptFile(this, file);
	}

	/// <summary>
	/// 加密输入文件，并将加密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待加密的输入文件全名 </param>
	/// <param name="output"> 加密后的数据写入的输出文件全名 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件全名为空；或者输出文件全名为空。 </exception>
	public void EncryptFile(string input, string output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.EncryptFile(this, input, output);
	}

	/// <summary>
	/// 加密输入文件，并将加密后的数据覆盖输出文件，如果输出文件不存在则创建
	/// </summary>
	/// <param name="input"> 待加密的输入文件 </param>
	/// <param name="output"> 加密后的数据写入的输出文件 </param>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 输入文件为空；或者输出文件为空。 </exception>
	public void EncryptFile(FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		AlgorithmHelper.EncryptFile(this, input, output);
	}

	/// <summary>
	/// 加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <returns> 加密后的字节流 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流 <paramref name="data" /> 为空。</exception>
	public Stream EncryptStream(Stream data)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		return AlgorithmHelper.EncryptStream(this, data);
	}

	/// <summary>
	/// 加密字节流
	/// </summary>
	/// <param name="data"> 待加密的字节流 </param>
	/// <param name="result"> 加密后输出的字节流 </param>
	/// <returns> 实际加密的字节数量 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 待加密的字节流 <paramref name="data" /> 为空；或者加密后输出的字节流 <paramref name="result" /> 为空。 </exception>
	public int EncryptStream(Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		return AlgorithmHelper.EncryptStream(this, data, result);
	}

	/// <summary>
	/// 加密当前文本数据
	/// </summary>
	/// <param name="text"> 当前待加密的文本 </param>
	/// <param name="encoding"> 加密时使用的文本编码 </param>
	/// <returns> 加密后的字节 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文本为空。 </exception>
	public byte[] EncryptText(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		return AlgorithmHelper.EncryptText(this, text, encoding);
	}

	/// <summary>
	/// 加密当前文本数据，并将加密后的字节数据转换为Base64编码的字符串
	/// </summary>
	/// <param name="text"> 当前待加密的文本 </param>
	/// <param name="encoding"> 加密时使用的文本编码 </param>
	/// <returns> 加密后的字节的Base64编码字符串 </returns>
	/// <exception cref="T:System.ObjectDisposedException"> 当前算法对象已经被释放。 </exception>
	/// <exception cref="T:System.ArgumentNullException"> 当前待加密的文本为空。 </exception>
	public string EncryptTextToBase64(string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(text, "text");
		return AlgorithmHelper.EncryptTextToBase64(this, text, encoding);
	}

	/// <summary>
	/// 导出当前对称算法的参数对象
	/// </summary>
	/// <returns>导出的算法参数对象</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空。</exception>
	public SymmetricParameter ExportParameter()
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return AlgorithmHelper.ExportParameter(algorithm);
	}

	/// <summary>
	/// 生成用于该算法的随机初始化向量 (IV)。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override void GenerateIV()
	{
		((ISymmetricAlgorithm)this).GenerateIV();
	}

	/// <summary>
	/// 生成用于该算法的随机初始化向量 (IV)。
	/// </summary>
	/// <returns>生成的初始化向量。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	byte[] ISymmetricAlgorithm.GenerateIV()
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		algorithm.GenerateIV();
		return algorithm.IV;
	}

	/// <summary>
	/// 生成用于该算法的随机密钥 (Key)。
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override void GenerateKey()
	{
		((ISymmetricAlgorithm)this).GenerateKey();
	}

	/// <summary>
	/// 生成用于该算法的随机密钥 (Key)。
	/// </summary>
	/// <returns>生成的随机密钥。</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	byte[] ISymmetricAlgorithm.GenerateKey()
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		algorithm.GenerateKey();
		return algorithm.Key;
	}

	/// <summary>
	/// 导入当前对称算法的参数对象
	/// </summary>
	/// <param name="parameter">导入的参数对象</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空；或者导入的参数对象为空。</exception>
	public void ImportParameter(SymmetricParameter parameter)
	{
		Guard.EnsureNotNull(algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		AlgorithmHelper.ImportParameter(algorithm, parameter);
	}

	void ISymmetricAlgorithm.Clear()
	{
		Clear();
	}

	bool ISymmetricAlgorithm.ValidKeySize(int P_0)
	{
		return ValidKeySize(P_0);
	}
}
