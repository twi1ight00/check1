using System;
using System.Reflection;
using System.Security.Cryptography;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 加解密辅助类
/// </summary>
public static class Cryptographer
{
	/// <summary>
	/// 生成器初始种子
	/// </summary>
	private static string seed = "A0T7Fho9vXODDn7x+v4msybH2zOkgPwMshyH03AqxGuMJ2C9LjDG+2uStv32nJueyiupJt8sjMk0JW31fDoifDS4zXQecJ8pfrN7mJNtqHJCaYeEGeOX1T6qfBuLuZIAJd6/7Q97Z4MfjNp2ew6UWcC2GN4pJ5ByZixciySHX+CP5rsUGOzNdIEnioidK6n6Qpj7tgXE2MkS3KFxfdfV4kg1CHvvaN1k9m8qxIEnAKxQdaqb5QXR8KI5J7rF9J1xMKwF1AmXJ4Ur69ZBpXwORz1JNablnFcsP40Np6ZslbnzlOAlmY4HJaHsC4Z1c5b0lQ71+7XxgvgP358tsVY+sA==";

	/// <summary>
	/// 生成器初始向量
	/// </summary>
	private static string salt = "Dk48aRcO9Hcd+QDXAiZrmpZD6zcIP8SKC0njhZESWCL2/pLgOYvd5MLLpLbKJeJ0/f5WS81UN7U23XG7/hbfTQySO/1kjVcmYT2nTcCjmaQllMSF59ySxFadVdra/Ocd2xoqgjGfPOYB4M/lNBG2xJ6EAKDnobe4LvOndu4lN7v+4DpNq/x7QuoKcpItL8405hXaVMoJ/3H1gqFVSnw5AfAjzqyaC3fZlJ5b+Dek96SuCUCpCMHMAYYdZHzIOKdo9B50OyZKi++7jiY61V/3+YMOqjdM9nZMe/G5fDWzvq1ehltwOLK25FsJOqtOq5o4NJq3LTRRJJx5KLDjoNWJNA==";

	/// <summary>
	/// 使用默认密码创建 <paramref name="algorithmType" /> 类型的加密算法
	/// </summary>
	/// <param name="algorithmType">对称加密算法类型</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法类型 <paramref name="algorithmType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmType" /> 指定的加密算法类型。</exception>
	public static SymmetricAlgorithm CreateSymmetricAlgorithm(Type algorithmType)
	{
		algorithmType.GuardNotNull("algorithm type");
		SymmetricAlgorithm algorithm = null;
		if (!typeof(SymmetricAlgorithm).IsAssignableFrom(algorithmType) && (algorithm = CreateAlgorithm(algorithmType) as SymmetricAlgorithm).IsNull())
		{
			throw new NotSupportedException(Literals.MSG_EncryptionAlgorithmNotSupport_1.FormatValue(algorithmType.FullName));
		}
		algorithm.Mode = CipherMode.CBC;
		algorithm.KeySize = algorithm.MaxKeySize();
		algorithm.BlockSize = algorithm.MinBlockSize();
		byte[][] raws = CreateRaws(new int[2] { algorithm.KeySize, algorithm.BlockSize });
		algorithm.Key = raws[0];
		algorithm.IV = raws[1];
		return algorithm;
	}

	/// <summary>
	/// 使用指定的密钥创建 <paramref name="algorithmType" /> 类型的加密算法
	/// </summary>
	/// <param name="algorithmType">对称加密算法类型</param>
	/// <param name="password">算法密钥</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法类型 <paramref name="algorithmType" /> 为空；或者算法密钥 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmType" /> 指定的加密算法类型。</exception>
	public static SymmetricAlgorithm CreateSymmetricAlgorithm(Type algorithmType, string password)
	{
		algorithmType.GuardNotNull("algorithm type");
		password.GuardNotNull("password");
		SymmetricAlgorithm algorithm = null;
		if (!typeof(SymmetricAlgorithm).IsAssignableFrom(algorithmType) && (algorithm = CreateAlgorithm(algorithmType) as SymmetricAlgorithm).IsNull())
		{
			throw new NotSupportedException(Literals.MSG_EncryptionAlgorithmNotSupport_1.FormatValue(algorithmType.FullName));
		}
		algorithm.Mode = CipherMode.CBC;
		algorithm.KeySize = algorithm.MaxKeySize();
		algorithm.BlockSize = algorithm.MinBlockSize();
		algorithm.Key = CreatePasswordBytes(password, algorithm.KeySize);
		algorithm.IV = CreateRaw(algorithm.BlockSize);
		return algorithm;
	}

	/// <summary>
	/// 使用默认密码创建 <typeparamref name="T" /> 类型的加密算法
	/// </summary>
	/// <typeparam name="T">对称加密算法类型</typeparam>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.NotSupportedException">不支持 <typeparamref name="T" /> 指定的加密算法类型。</exception>
	public static T CreateSymmetricAlgorithm<T>() where T : SymmetricAlgorithm
	{
		return (T)CreateSymmetricAlgorithm(typeof(T));
	}

	/// <summary>
	/// 使用默认密钥创建 <typeparamref name="T" /> 类型的加密算法
	/// </summary>
	/// <typeparam name="T">对称加密算法类型</typeparam>
	/// <param name="password">算法密钥</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <typeparamref name="T" /> 指定的加密算法类型。</exception>
	public static T CreateSymmetricAlgorithm<T>(string password) where T : SymmetricAlgorithm
	{
		return (T)CreateSymmetricAlgorithm(typeof(T), password);
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.Aes" /> 算法对象
	/// </summary>
	/// <returns>Aes 算法对象</returns>
	public static Aes GetAES()
	{
		return GetSymmetricAlgorithm<Aes>("AES");
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.Aes" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>Aes 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static Aes GetAES(string password)
	{
		return GetSymmetricAlgorithm<Aes>("AES", password);
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.DES" /> 算法对象
	/// </summary>
	/// <returns>DES 算法对象</returns>
	public static DES GetDES()
	{
		return GetSymmetricAlgorithm<DES>("DES");
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.DES" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>DES 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static DES GetDES(string password)
	{
		return GetSymmetricAlgorithm<DES>("DES", password);
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.Rijndael" /> 算法对象
	/// </summary>
	/// <returns>Rijndael 算法对象</returns>
	public static Rijndael GetRijndael()
	{
		return GetSymmetricAlgorithm<Rijndael>("Rijndael");
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.Rijndael" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>Rijndael 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static Rijndael GetRijndael(string password)
	{
		return GetSymmetricAlgorithm<Rijndael>("Rijndael", password);
	}

	/// <summary>
	/// 获取默认密码初始化的 <see cref="T:System.Security.Cryptography.TripleDES" /> 算法对象
	/// </summary>
	/// <returns>3DES 算法对象</returns>
	public static TripleDES Get3DES()
	{
		return GetSymmetricAlgorithm<TripleDES>("3DES");
	}

	/// <summary>
	/// 获取指定密码初始化的 <see cref="T:System.Security.Cryptography.TripleDES" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>3DES 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static TripleDES Get3DES(string password)
	{
		return GetSymmetricAlgorithm<TripleDES>("3DES", password);
	}

	/// <summary>
	/// 获取使用默认密码初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmName)
	{
		algorithmName.GuardNotNull("algorithm name");
		SymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as SymmetricAlgorithm;
		if (algorithm.IsNull())
		{
			throw new NotSupportedException(Literals.MSG_EncryptionAlgorithmNotSupport_1.FormatValue(algorithmName));
		}
		algorithm.Mode = CipherMode.CBC;
		algorithm.KeySize = algorithm.MaxKeySize();
		algorithm.BlockSize = algorithm.MinBlockSize();
		byte[][] raws = CreateRaws(new int[2] { algorithm.KeySize, algorithm.BlockSize });
		algorithm.Key = raws[0];
		algorithm.IV = raws[1];
		return algorithm;
	}

	/// <summary>
	/// 获取使用指定密码初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="password">算法密码</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法密码 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmName, string password)
	{
		algorithmName.GuardNotNull("algorithm name");
		password.GuardNotNull("password");
		SymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as SymmetricAlgorithm;
		if (algorithm.IsNull())
		{
			throw new NotSupportedException(Literals.MSG_EncryptionAlgorithmNotSupport_1.FormatValue(algorithmName));
		}
		algorithm.Mode = CipherMode.CBC;
		algorithm.KeySize = algorithm.MaxKeySize();
		algorithm.BlockSize = algorithm.MinBlockSize();
		algorithm.Key = CreatePasswordBytes(password, algorithm.KeySize);
		algorithm.IV = CreateRaw(algorithm.BlockSize);
		return algorithm;
	}

	/// <summary>
	/// 获取使用默认密码初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <typeparam name="T">对称加密算法类型</typeparam>
	/// <param name="algorithmName">加密算法名称</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static T GetSymmetricAlgorithm<T>(string algorithmName) where T : SymmetricAlgorithm
	{
		return (T)GetSymmetricAlgorithm(algorithmName);
	}

	/// <summary>
	/// 获取使用指定密码初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <typeparam name="T">对称加密算法类型</typeparam>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="password">算法密码</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法密码 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static T GetSymmetricAlgorithm<T>(string algorithmName, string password) where T : SymmetricAlgorithm
	{
		return (T)GetSymmetricAlgorithm(algorithmName, password);
	}

	/// <summary>
	/// 获取指定长度的原始密码
	/// </summary>
	/// <param name="keySize">获取的密码长度，密钥长度单位：位</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的原始密码</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密码长度 <paramref name="keySize" /> 小于0；或者迭代次数 <paramref name="iterations" /> 小于1。</exception>
	private static byte[] CreateRaw(int keySize, int iterations = 4)
	{
		keySize.GuardGreaterThanOrEqualTo(0, "key size");
		iterations.GuardGreaterThanOrEqualTo(1, "iterations");
		using Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(seed.Base64Decode(), salt.Base64Decode(), iterations);
		return GetDeriveBytes(deriver, keySize);
	}

	/// <summary>
	/// 获取指定长度的多个原始密码
	/// </summary>
	/// <param name="keySize">获取的密码长度，密钥长度单位：位</param>
	/// <param name="keyCount">获取的密码的数量</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的多个原始密码</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密码长度 <paramref name="keySize" /> 小于0；或者获取的密码数量 <paramref name="keyCount" /> 小于1。</exception>
	private static byte[][] CreateRaws(int keySize, int keyCount, int iterations = 4)
	{
		keySize.GuardGreaterThanOrEqualTo(0, "key size");
		keyCount.GuardGreaterThanOrEqualTo(1, "key count");
		iterations.GuardGreaterThanOrEqualTo(1, "iterations");
		byte[][] raws = new byte[keyCount][];
		using (Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(seed.Base64Decode(), salt.Base64Decode(), iterations))
		{
			for (int i = 0; i < keyCount; i++)
			{
				raws[i] = GetDeriveBytes(deriver, keySize);
			}
		}
		return raws;
	}

	/// <summary>
	/// 获取指定长度的多个原始密码
	/// </summary>
	/// <param name="keySizes">获取的密码长度数组，密钥长度单位：位</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的多个原始密码</returns>
	/// <exception cref="T:System.ArgumentNullException">密码长度数组 <paramref name="keySizes" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密码长度小于0；或者获密码长度数组 <paramref name="keySizes" /> 的元素数量小于1；或者迭代次数 <paramref name="iterations" /> 小于1。</exception>
	private static byte[][] CreateRaws(int[] keySizes, int iterations = 4)
	{
		keySizes.GuardNotNull("key sizes");
		keySizes.Length.GuardGreaterThanOrEqualTo(1, "key size length");
		iterations.GuardGreaterThanOrEqualTo(1, "iterations");
		int keyCount = keySizes.Length;
		byte[][] raws = new byte[keyCount][];
		using (Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(seed.Base64Decode(), salt.Base64Decode(), iterations))
		{
			for (int i = 0; i < keyCount; i++)
			{
				raws[i] = GetDeriveBytes(deriver, keySizes[i]);
			}
		}
		return raws;
	}

	/// <summary>
	/// 创建指定类型的算法对象
	/// </summary>
	/// <param name="algorithmType">算法类型对象</param>
	/// <returns>创建的算法类型对象，如果无法创建则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">算法类型对象为空。</exception>
	private static object CreateAlgorithm(Type algorithmType)
	{
		algorithmType.GuardNotNull("algorithm type");
		object algorithm = null;
		MethodInfo minfo = algorithmType.GetMethod("Create");
		if (minfo.IsNotNull() && (algorithm = minfo.Invoke(null, null)).IsNotNull())
		{
			return algorithm;
		}
		ConstructorInfo cinfo = algorithmType.GetConstructor(Type.EmptyTypes);
		if (cinfo.IsNotNull())
		{
			algorithm = cinfo.Invoke(null, null);
		}
		return algorithm;
	}

	/// <summary>
	/// 根据给定的密码文本创建字节密钥
	/// </summary>
	/// <param name="password">密码文本</param>
	/// <param name="passwordSize">密钥长度，长度单位：位</param>
	/// <returns>根据给定密码文本生成的密钥字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">密码文本 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">密钥长度 <paramref name="passwordSize" /> 小于等于0。</exception>
	private static byte[] CreatePasswordBytes(string password, int passwordSize)
	{
		password.GuardNotNull("password");
		passwordSize.GuardGreaterThan(0, "password size");
		using Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(password, CreateRaw(passwordSize + 64));
		return GetDeriveBytes(derive, passwordSize);
	}

	private static byte[] GetDeriveBytes(Rfc2898DeriveBytes derive, int size)
	{
		size /= 8;
		int count = ((size > 4096) ? size : 4096);
		byte[] bytes = derive.GetBytes(count);
		if (size < count)
		{
			byte[] newBytes = new byte[size];
			Array.Copy(bytes, 0, newBytes, 0, size);
			return newBytes;
		}
		return bytes;
	}
}
