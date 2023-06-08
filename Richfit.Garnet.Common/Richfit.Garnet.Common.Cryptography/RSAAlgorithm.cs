using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// RSA 算法的实现，支持公钥和私钥的独立加解密
/// </summary>
public class RSAAlgorithm : GenericAsymmetricAlgorithm<RSACryptoServiceProvider>, IRSA, IAsymmetricAlgorithm, IAlgorithm, IDisposable
{
	/// <summary>
	/// RSA算法密钥结构
	/// </summary>
	private struct RSAKey
	{
		public BigInteger Exponent;

		public BigInteger Modulus;

		public int ModulusOctets;

		public BigInteger D;

		public BigInteger P;

		public BigInteger Q;

		public BigInteger DP;

		public BigInteger DQ;

		public BigInteger InverseQ;

		public bool ContainsPublicKey;

		public bool ContainsPrivateKey;

		public bool ContainsCrtInfo;

		public RSAKey(RSAParameters parameters)
		{
			Exponent = parameters.Exponent();
			Modulus = parameters.Modulus();
			ModulusOctets = parameters.ModulusOctets();
			D = parameters.D();
			P = parameters.P();
			Q = parameters.Q();
			DP = parameters.DP();
			DQ = parameters.DQ();
			InverseQ = parameters.InverseQ();
			ContainsPublicKey = parameters.ContainsPublicKey();
			ContainsPrivateKey = parameters.ContainsPrivateKey();
			ContainsCrtInfo = parameters.ContainsCrtInfo();
		}
	}

	/// <summary>
	/// 基础RSA算法参数
	/// </summary>
	private RSAKey key;

	private RSAFillMode fillMode;

	/// <summary>
	/// 加密随机数生成器
	/// </summary>
	private RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

	/// <summary>
	/// 哈希算法
	/// </summary>
	private HashAlgorithm hasher = new SHA1CryptoServiceProvider();

	/// <summary>
	/// OAEP种子
	/// </summary>
	private byte[] oaepSeed = new byte[4] { 255, 240, 202, 32 };

	/// <summary>
	/// 获取或者设置填充模式
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	public RSAFillMode FillMode
	{
		get
		{
			Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			return fillMode;
		}
		set
		{
			Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
			fillMode = value;
		}
	}

	/// <summary>
	/// 初始化默认实现
	/// </summary>
	public RSAAlgorithm()
	{
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
		FillMode = RSAFillMode.OAEP;
	}

	/// <summary>
	/// 使用指定的密钥大小初始化RSA算法实例；支持长度从384到16384，递增8的密钥。
	/// </summary>
	/// <param name="keySize">使用的密钥大小</param>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">指定的密钥大小 <paramref name="keySize" /> 无效。</exception>
	public RSAAlgorithm(int keySize)
		: base((Func<RSACryptoServiceProvider>)delegate
		{
			Guard.Ensure(keySize >= 384 && keySize <= 16384 && keySize % 8 == 0, () => new CryptographicException(Literals.MSG_ValueOutOfRange_1.FormatValue(keySize)));
			return new RSACryptoServiceProvider(keySize);
		})
	{
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
		FillMode = RSAFillMode.OAEP;
	}

	/// <summary>
	/// 使用指定的参数初始化RSA算法实例
	/// </summary>
	/// <param name="parameters">RSA参数</param>
	public RSAAlgorithm(RSAParameters parameters)
		: this()
	{
		ImportParameters(parameters);
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
		FillMode = RSAFillMode.OAEP;
	}

	/// <summary>
	/// 使用指定的Xml格式参数字符串初始化RSA算法实例
	/// </summary>
	/// <param name="xml">Xml格式参数字符串</param>
	/// <exception cref="T:System.ArgumentNullException">当前Xml格式参数字符串 <paramref name="xml" /> 为空。</exception>
	public RSAAlgorithm(string xml)
		: this()
	{
		Guard.EnsureNotNull(xml, "xml parameters");
		FromXmlString(xml);
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
		FillMode = RSAFillMode.OAEP;
	}

	/// <summary>
	/// 释放由当前算法对象占用的非托管资源，还可以另外再释放托管资源。
	/// </summary>
	/// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (hasher.IsNotNull())
			{
				hasher.Dispose();
				hasher = null;
			}
			if (rng.IsNotNull())
			{
				rng.Dispose();
				rng = null;
			}
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
	public override byte[] Decrypt(byte[] data)
	{
		Guard.EnsureNotNull(data, "data");
		return PublicDecrypt(data);
	}

	/// <summary>
	/// 使用私钥加密数据
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被释放。</exception>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据 <paramref name="data" /> 为空。</exception>
	public override byte[] Encrypt(byte[] data)
	{
		Guard.EnsureNotNull(data, "data");
		return PrivateEncrypt(data);
	}

	/// <summary>
	/// 导出RSA参数
	/// </summary>
	/// <param name="includePrivateParameters">是否包括私有参数</param>
	/// <returns>导出的RSA参数</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public RSAParameters ExportParameters(bool includePrivateParameters)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return base.Algorithm.ExportParameters(includePrivateParameters: true);
	}

	/// <summary>
	/// 通过从XML字符串中加载的参数信息初始化RSA算法对象
	/// </summary>
	/// <param name="xml">XML参数字符串</param>
	/// <exception cref="T:System.ArgumentNullException">Xml参数字符串 <paramref name="xml" /> 为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	public override void FromXmlString(string xml)
	{
		base.FromXmlString(xml);
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
	}

	/// <summary>
	/// 导入指定的RSA参数
	/// </summary>
	/// <param name="parameters">RSA参数</param>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public void ImportParameters(RSAParameters parameters)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		base.Algorithm.ImportParameters(parameters);
		key = new RSAKey(base.Algorithm.ExportParameters(includePrivateParameters: true));
	}

	/// <summary>
	/// 使用私钥加密数据
	/// </summary>
	/// <param name="rgb">待加密数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override byte[] PrivateEncrypt(byte[] rgb)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(rgb, "rgb");
		return RSAEncrypt(rgb, oaepSeed, (RSAOptions)((RSAFillMode)513 | FillMode));
	}

	/// <summary>
	/// 使用私钥解密数据
	/// </summary>
	/// <param name="rgb">待解密数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override byte[] PrivateDecrypt(byte[] rgb)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(rgb, "rgb");
		return RSADecrypt(rgb, oaepSeed, (RSAOptions)((RSAFillMode)514 | FillMode));
	}

	/// <summary>
	/// 使用公钥加密数据
	/// </summary>
	/// <param name="rgb">待加密的数据</param>
	/// <returns>加密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override byte[] PublicEncrypt(byte[] rgb)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(rgb, "rgb");
		return RSAEncrypt(rgb, oaepSeed, (RSAOptions)((RSAFillMode)257 | FillMode));
	}

	/// <summary>
	/// 使用公钥解密数据
	/// </summary>
	/// <param name="rgb">待解密的数据</param>
	/// <returns>解密后的数据</returns>
	/// <exception cref="T:System.ArgumentNullException">待加密的数据为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已被清理释放</exception>
	public override byte[] PublicDecrypt(byte[] rgb)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(rgb, "rgb");
		return RSADecrypt(rgb, oaepSeed, (RSAOptions)((RSAFillMode)258 | FillMode));
	}

	/// <summary>
	/// 为指定的数据生成生成数据签名
	/// </summary>
	/// <param name="data">被签名的数据</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	public override byte[] SignData(byte[] data)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data);
		byte[] hash = hasher.ComputeHash(data);
		return PrivateEncrypt(hash);
	}

	/// <summary>
	/// 为指定的数据流生成生成数据签名
	/// </summary>
	/// <param name="data">被签名的数据流</param>
	/// <returns>用私钥加密的指定数据的数字签名</returns>
	public override byte[] SignData(Stream data)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data);
		byte[] hash = hasher.ComputeHash(data);
		return PrivateEncrypt(hash);
	}

	/// <summary>
	/// 为指定的哈希值生成数字签名。
	/// </summary>
	/// <param name="hash">正被签名的数据的哈希值。</param>
	/// <returns>包含用私钥加密的给定哈希值的数字签名。</returns>
	/// <exception cref="T:System.ArgumentNullException">数据的哈希值 <paramref name="hash" /> 为空。</exception>
	public override byte[] SignHash(byte[] hash)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(hash, "hash");
		return PrivateEncrypt(hash);
	}

	/// <summary>
	/// 返回当前算法参数的Xml字符串
	/// </summary>
	/// <param name="includePrivateParameters">是否包含算法密钥</param>
	/// <returns>算法参数Xml字符串</returns>
	/// <exception cref="T:System.ObjectDisposedException">当前算法对象已经被清理释放。</exception>
	public override string ToXmlString(bool includePrivateParameters)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		return base.ToXmlString(includePrivateParameters);
	}

	/// <summary>
	/// 根据指定的数字签名，验证当前数据
	/// </summary>
	/// <param name="data">待验证的数据</param>
	/// <param name="signature">数据的数字签名</param>
	/// <returns>如果待验证的数据与给定的数字签名相等则返回true，否则返回false。</returns>
	public override bool VerifyData(byte[] data, byte[] signature)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(signature, "sig;nature");
		byte[] hash = hasher.ComputeHash(data);
		return PublicDecrypt(signature).SequenceEqual(hash);
	}

	/// <summary>
	/// 根据指定的数字签名验证当前数据流
	/// </summary>
	/// <param name="data">当前待验证的数据流</param>
	/// <param name="signature">数据的数字签名</param>
	/// <returns>如果待验证的数据流与给定的数字签名相同则返回true，否则返回false。</returns>
	public override bool VerifyData(Stream data, byte[] signature)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(signature, "signature");
		byte[] hash = hasher.ComputeHash(data);
		return PublicDecrypt(signature).SequenceEqual(hash);
	}

	/// <summary>
	/// 根据指定的哈希值验证数字签名。
	/// </summary>
	/// <param name="hash">数据块的哈希值。</param>
	/// <param name="signature">要验证的数字签名。</param>
	/// <returns>如果哈希值与解密的签名相等，则为 true；否则为 false。</returns>
	/// <exception cref="T:System.ArgumentNullException">数据的哈希值 <paramref name="hash" /> 为空；或者要验证的数字签名 <paramref name="signature" /> 为空。</exception>
	public override bool VerifyHash(byte[] hash, byte[] signature)
	{
		Guard.EnsureNotNull(base.Algorithm, () => new ObjectDisposedException(Literals.MSG_ObjectDisposed));
		Guard.EnsureNotNull(hash, "hash");
		Guard.EnsureNotNull(signature, "signature");
		return PublicDecrypt(signature).SequenceEqual(hash);
	}

	/// <summary>
	/// 掩码生成函数
	/// </summary>
	/// <param name="seed">初始的伪随机种子</param>
	/// <param name="length">生成的掩码长度</param>
	/// <returns>生成的掩码</returns>
	private byte[] MGF(byte[] seed, int length)
	{
		List<byte> result = new List<byte>();
		for (int i = 0; i <= length / (hasher.HashSize / 8); i++)
		{
			List<byte> data = new List<byte>();
			data.AddRange(seed);
			data.AddRange(i.GetBytes(4));
			result.AddRange(hasher.ComputeHash(data.ToArray()));
		}
		if (length == result.Count)
		{
			return result.ToArray();
		}
		if (length < result.Count)
		{
			return result.GetRange(0, length).ToArray();
		}
		throw new ArgumentException("Invalid Mask Length.");
	}

	/// <summary>
	/// RSA基础加密解密运算
	/// </summary>
	/// <param name="data">待加解密的字节数据，该数据字节长度必须小于RSA系数的字节长度</param>
	/// <param name="options">RSA参数选项</param>
	/// <returns>处理后的数据</returns>
	private byte[] RSACalc(byte[] data, RSAOptions options)
	{
		BigInteger ce;
		if (options.HasFlag(RSAOptions.Private))
		{
			if (!key.ContainsPrivateKey)
			{
				throw new CryptographicException(Literals.MSG_RSAIncompletePrivateKey);
			}
			ce = key.D;
		}
		else
		{
			if (!options.HasFlag(RSAOptions.Public))
			{
				throw new CryptographicException(Literals.MSG_RSAOptionError);
			}
			if (!key.ContainsPublicKey)
			{
				throw new CryptographicException(Literals.MSG_RSAIncompletePublicKey);
			}
			ce = key.Exponent;
		}
		BigInteger pt = new BigInteger(data);
		BigInteger i = BigInteger.ModPow(pt, ce, key.Modulus);
		if (i.Sign == -1)
		{
			return (i + key.Modulus).GetBytes(key.ModulusOctets);
		}
		return i.GetBytes(key.ModulusOctets);
	}

	/// <summary>
	/// 对数据进行OAEP编码
	/// </summary>
	/// <param name="data">待处理的数据</param>
	/// <param name="p">OAEP参数</param>
	/// <returns>编码后的数据</returns>
	private byte[] RSAEncodeForOAEP(byte[] data, byte[] p)
	{
		int dataLength = data.Length;
		int hashByteSize = hasher.HashSize / 8;
		if (dataLength > key.ModulusOctets - 2 * hashByteSize - 2)
		{
			throw new ArgumentException(Literals.MSG_RSAMessageTooLong);
		}
		byte[] ps = new byte[key.ModulusOctets - dataLength - 2 * hashByteSize - 2];
		byte[] phash = hasher.ComputeHash(p);
		List<byte> dbbuff = new List<byte>();
		dbbuff.AddRange(phash);
		dbbuff.AddRange(ps);
		dbbuff.Add(1);
		dbbuff.AddRange(data);
		byte[] db = dbbuff.ToArray();
		byte[] seed = new byte[hashByteSize];
		rng.GetBytes(seed);
		byte[] dbMask = MGF(seed, key.ModulusOctets - hashByteSize - 1);
		byte[] maskedDB = db.Xor(dbMask);
		byte[] seedMask = MGF(maskedDB, hashByteSize);
		byte[] maskedSeed = seed.Xor(seedMask);
		List<byte> buff = new List<byte>();
		buff.Add(0);
		buff.AddRange(maskedSeed);
		buff.AddRange(maskedDB);
		return buff.ToArray();
	}

	/// <summary>
	/// 对数据进行OAEP解码
	/// </summary>
	/// <param name="data">待处理的数据</param>
	/// <param name="p">OAEP参数</param>
	/// <returns>编码后的数据</returns>
	private byte[] RSADecodeForOAEP(byte[] data, byte[] p)
	{
		int hashByteSize = hasher.HashSize / 8;
		if (data.Length == key.ModulusOctets && data.Length > 2 * hashByteSize + 1)
		{
			byte[] phash = hasher.ComputeHash(p);
			if (data[0] == 0)
			{
				List<byte> dataList = data.ToList();
				byte[] maskedSeed = dataList.GetRange(1, hashByteSize).ToArray();
				byte[] maskedDB = dataList.GetRange(1 + hashByteSize, data.Length - hashByteSize - 1).ToArray();
				byte[] seedMask = MGF(maskedDB, hashByteSize);
				byte[] seed = maskedSeed.Xor(seedMask);
				byte[] dbMask = MGF(seed, key.ModulusOctets - hashByteSize - 1);
				byte[] db = maskedDB.Xor(dbMask);
				if (db.Length >= hashByteSize + 1)
				{
					List<byte> dbList = db.ToList();
					byte[] phash2 = dbList.GetRange(0, hashByteSize).ToArray();
					List<byte> psm = dbList.GetRange(hashByteSize, db.Length - hashByteSize);
					int pos = psm.IndexOf(1);
					if (pos >= 0 && pos < psm.Count)
					{
						List<byte> m = psm.GetRange(pos, psm.Count - pos);
						byte[] j = ((m.Count <= 1) ? new byte[0] : m.GetRange(1, m.Count - 1).ToArray());
						bool success = true;
						for (int i = 0; i < hashByteSize; i++)
						{
							if (phash2[i] != phash[i])
							{
								success = false;
								break;
							}
						}
						if (success)
						{
							return j;
						}
						j = new byte[hashByteSize];
						throw new CryptographicException(Literals.MSG_RSAOAEPDecodeError);
					}
					throw new CryptographicException(Literals.MSG_RSAOAEPDecodeError);
				}
				throw new CryptographicException(Literals.MSG_RSAOAEPDecodeError);
			}
			throw new CryptographicException(Literals.MSG_RSAOAEPDecodeError);
		}
		throw new CryptographicException(Literals.MSG_RSAOAEPDecodeError);
	}

	/// <summary>
	/// 对数据进行PKCS v1.5编码
	/// </summary>
	/// <param name="data">待处理的数据</param>
	/// <returns>编码后的数据</returns>
	private byte[] RSAEncodeForPKCS15(byte[] data)
	{
		if (data.Length > key.ModulusOctets - 11)
		{
			throw new ArgumentException(Literals.MSG_RSAMessageTooLong);
		}
		List<byte> buff = new List<byte>();
		buff.Add(0);
		buff.Add(2);
		int paddingLength = key.ModulusOctets - data.Length - 3;
		byte[] ps = new byte[paddingLength];
		rng.GetNonZeroBytes(ps);
		buff.AddRange(ps);
		buff.Add(0);
		buff.AddRange(data);
		return buff.ToArray();
	}

	/// <summary>
	/// 对数据进行PKCS v1.5解码
	/// </summary>
	/// <param name="data">待处理的数据</param>
	/// <returns>编码后的数据</returns>
	private byte[] RSADecodeForPKCS15(byte[] data)
	{
		if (data.Length >= 11)
		{
			if (data[0] == 0 && data[1] == 2)
			{
				int startIndex = 2;
				List<byte> ps = new List<byte>();
				for (int i = startIndex; i < data.Length && data[i] != 0; i++)
				{
					ps.Add(data[i]);
				}
				if (ps.Count >= 8)
				{
					int decodedDataIndex = startIndex + ps.Count + 1;
					if (decodedDataIndex < data.Length)
					{
						List<byte> buff2 = new List<byte>();
						for (int i = decodedDataIndex; i < data.Length; i++)
						{
							buff2.Add(data[i]);
						}
						return buff2.ToArray();
					}
					return new byte[0];
				}
				throw new CryptographicException(Literals.MSG_RSAPKCS15DecodeError);
			}
			throw new CryptographicException(Literals.MSG_RSAPKCS15DecodeError);
		}
		throw new CryptographicException(Literals.MSG_RSAPKCS15DecodeError);
	}

	/// <summary>
	/// RSA基于CRT的解密运算
	/// </summary>
	/// <param name="data">待解密的字节数据，该数据的字节长度必须小于RSA系数的字节长度</param>
	/// <returns>解密后的数据</returns>
	private byte[] RSADecryptByCRT(byte[] data)
	{
		if (key.ContainsCrtInfo)
		{
			BigInteger c = new BigInteger(data);
			BigInteger m1 = BigInteger.ModPow(c, key.DP, key.P);
			BigInteger m2 = BigInteger.ModPow(c, key.DQ, key.Q);
			BigInteger h = (m1 - m2) * key.InverseQ % key.P;
			BigInteger i = m2 + key.Q * h;
			if (i.Sign == -1)
			{
				return (i + key.Modulus).GetBytes(key.ModulusOctets);
			}
			return i.GetBytes(key.ModulusOctets);
		}
		throw new CryptographicException(Literals.MSG_RSAIncompleteCrtInfo);
	}

	/// <summary>
	/// RSA加密运算
	/// </summary>
	/// <param name="data">待加密的数据</param>
	/// <param name="p">加密参数</param>
	/// <param name="options">RSA参数选项</param>
	/// <returns>加密后的数据</returns>
	private byte[] RSAEncrypt(byte[] data, byte[] p, RSAOptions options)
	{
		p = p.IfNull(new byte[0]);
		if (options.HasFlag(RSAOptions.Encrypt))
		{
			if (options.HasFlag(RSAOptions.OAEP))
			{
				data = RSAEncodeForOAEP(data, p);
			}
			else
			{
				if (!options.HasFlag(RSAOptions.PKCS15))
				{
					throw new CryptographicException(Literals.MSG_RSAOptionError);
				}
				data = RSAEncodeForPKCS15(data);
			}
			return RSACalc(data, options);
		}
		throw new CryptographicException(Literals.MSG_RSAOptionError);
	}

	/// <summary>
	/// RSA解密运算
	/// </summary>
	/// <param name="data">待解密的数据</param>
	/// <param name="p">解密参数</param>
	/// <param name="options">RSA参数选项</param>
	/// <returns>解密后的数据</returns>
	private byte[] RSADecrypt(byte[] data, byte[] p, RSAOptions options)
	{
		if (!options.HasFlag(RSAOptions.Decrypt))
		{
			throw new CryptographicException(Literals.MSG_RSAOptionError);
		}
		byte[] em = ((!key.ContainsCrtInfo) ? RSACalc(data, options) : RSADecryptByCRT(data));
		if (options.HasFlag(RSAOptions.OAEP))
		{
			return RSADecodeForOAEP(em, p ?? new byte[0]);
		}
		if (options.HasFlag(RSAOptions.PKCS15))
		{
			return RSADecodeForPKCS15(em);
		}
		throw new CryptographicException(Literals.MSG_RSAOptionError);
	}
}
