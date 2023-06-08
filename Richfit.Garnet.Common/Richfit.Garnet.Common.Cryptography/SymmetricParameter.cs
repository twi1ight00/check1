using System;
using System.Security.Cryptography;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 对称加解密算法参数
/// </summary>
public class SymmetricParameter
{
	private int blockSize;

	private int feedbackSize;

	private byte[] iv;

	private byte[] key;

	private int keySize;

	private CipherMode mode;

	private PaddingMode padding;

	/// <summary>
	/// 获取或设置加密操作的块大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的加密操作的块大小小于等于0。</exception>
	public int BlockSize
	{
		get
		{
			return blockSize;
		}
		set
		{
			Guard.EnsureGreaterThan(value, 0, "Block Size");
			blockSize = value;
		}
	}

	/// <summary>
	/// 获取或设置加密操作的反馈大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的加密反馈块的大小小于等于0。</exception>
	public int FeedbackSize
	{
		get
		{
			return feedbackSize;
		}
		set
		{
			Guard.EnsureGreaterThan(value, 0, "Feedback Size");
			feedbackSize = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的初始化向量 (IV)。
	/// </summary>
	/// <exception cref="T:System.ArgumentNullException">设置的初始化向量为空。</exception>
	public byte[] IV
	{
		get
		{
			return iv;
		}
		set
		{
			Guard.EnsureNotNull(value, "IV");
			iv = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的密钥。
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的算法密钥为空。</exception>
	public byte[] Key
	{
		get
		{
			return key;
		}
		set
		{
			Guard.EnsureNotNull(value, "Key");
			key = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法所用密钥的大小（以位为单位）。
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的算法密钥大小小于等于0。</exception>
	public int KeySize
	{
		get
		{
			return keySize;
		}
		set
		{
			Guard.EnsureGreaterThan(value, 0, "Key Size");
			keySize = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法的运算模式。
	/// </summary>
	public CipherMode Mode
	{
		get
		{
			return mode;
		}
		set
		{
			mode = value;
		}
	}

	/// <summary>
	/// 获取或设置对称算法中使用的填充模式。
	/// </summary>
	public PaddingMode Padding
	{
		get
		{
			return padding;
		}
		set
		{
			padding = value;
		}
	}

	/// <summary>
	/// 初始化默认的算法参数
	/// </summary>
	public SymmetricParameter()
	{
		BlockSize = 128;
		FeedbackSize = 128;
		KeySize = 256;
		Mode = CipherMode.CBC;
		Padding = PaddingMode.PKCS7;
		Random random = new Random((int)DateTime.Now.Ticks);
		Key = random.GetByteArray(KeySize);
		IV = random.GetByteArray(BlockSize);
	}

	/// <summary>
	/// 初始化为指定算法的默认参数
	/// </summary>
	/// <param name="algorithm">指定的算法对象</param>
	/// <exception cref="T:System.ArgumentNullException">指定的算法对象为空。</exception>
	public SymmetricParameter(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		BlockSize = AlgorithmHelper.GetMinBlockSize(algorithm);
		FeedbackSize = BlockSize;
		KeySize = AlgorithmHelper.GetMaxKeySize(algorithm);
		Mode = CipherMode.CBC;
		Padding = PaddingMode.PKCS7;
		Random random = new Random((int)DateTime.Now.Ticks);
		Key = random.GetByteArray(KeySize);
		IV = random.GetByteArray(BlockSize);
	}

	/// <summary>
	/// 初始化为指定算法的默认参数
	/// </summary>
	/// <param name="algorithm">指定的算法对象</param>
	/// <param name="password">算法密钥</param>
	/// <exception cref="T:System.ArgumentNullException">指定的算法对象为空；或者算法密钥为空。</exception>
	public SymmetricParameter(SymmetricAlgorithm algorithm, string password)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(password, "password");
		BlockSize = AlgorithmHelper.GetMinBlockSize(algorithm);
		FeedbackSize = BlockSize;
		KeySize = AlgorithmHelper.GetMaxKeySize(algorithm);
		Mode = CipherMode.CBC;
		Padding = PaddingMode.PKCS7;
		KeyIVPair pair = AlgorithmHelper.CreateKeyIV(algorithm, password);
		Key = pair.Key;
		IV = pair.IV;
	}
}
