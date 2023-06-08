using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Cryptography;

/// <summary>
/// 算法辅助类
/// </summary>
public static class AlgorithmHelper
{
	/// <summary>
	/// 生成器初始种子
	/// </summary>
	private const string seed = "A0T7Fho9vXODDn7x+v4msybH2zOkgPwMshyH03AqxGuMJ2C9LjDG+2uStv32nJueyiupJt8sjMk0JW31fDoifDS4zXQecJ8pfrN7mJNtqHJCaYeEGeOX1T6qfBuLuZIAJd6/7Q97Z4MfjNp2ew6UWcC2GN4pJ5ByZixciySHX+CP5rsUGOzNdIEnioidK6n6Qpj7tgXE2MkS3KFxfdfV4kg1CHvvaN1k9m8qxIEnAKxQdaqb5QXR8KI5J7rF9J1xMKwF1AmXJ4Ur69ZBpXwORz1JNablnFcsP40Np6ZslbnzlOAlmY4HJaHsC4Z1c5b0lQ71+7XxgvgP358tsVY+sA==";

	/// <summary>
	/// 生成器初始向量
	/// </summary>
	private const string salt = "Dk48aRcO9Hcd+QDXAiZrmpZD6zcIP8SKC0njhZESWCL2/pLgOYvd5MLLpLbKJeJ0/f5WS81UN7U23XG7/hbfTQySO/1kjVcmYT2nTcCjmaQllMSF59ySxFadVdra/Ocd2xoqgjGfPOYB4M/lNBG2xJ6EAKDnobe4LvOndu4lN7v+4DpNq/x7QuoKcpItL8405hXaVMoJ/3H1gqFVSnw5AfAjzqyaC3fZlJ5b+Dek96SuCUCpCMHMAYYdZHzIOKdo9B50OyZKi++7jiY61V/3+YMOqjdM9nZMe/G5fDWzvq1ehltwOLK25FsJOqtOq5o4NJq3LTRRJJx5KLDjoNWJNA==";

	private const string rsaKeyXml = "n2CXeRLJGs3ZSO73ImK9LfV8mqT/B4Q430oklD7qFpfD464E6U2ugkI7QnNPVyPqqFhyX8qonDqUn2EXZdAbNo1h0jCME8HzIHMsTOujXZDicFKGNSHhOHeRJ5vnv2IMzz3erzzfkVd5QqUzDWm+ZrmADZ3dqZxdNUUC4y/XZPtS/5fcZzB2OwSSuvOc4zYmLxvDCV+39jlTTJtyJuJs1zlB/puzF6sbYW/lxHYGsqTaWelfSLJdeEuQfDwwQ/C5wzqOWNVkyvjy7UCIwRRMFBexTK7zooFpYQtKCTYqY3QdlaJwwLuhEuG/9MkDzBUCxjIBumUyvefVJy1kVEDQjEeEMVHgSbbQkrFo8U6gigcYBJcyI5x3AyWkRi5DFuVxBX2N/Pt+VtmREkx/MCHFKCEf7uPHlHBWQmaRmVQMrEbja37U2/ZxAAJOffCH2Bsyqabhvl+HU/02o0uEYRuKSi0DcF5Fl1QEm8r0w0gKJY0zphJG6XVGRZus3a6eA9/S7YzNQb172Z4XgfYV07RtvXcUVooCYmVEMOmzgMYvoRa/WLtUdeaPgOqpdO7h/EAw72RL8ovNWsu5S+YdBTcIk44hrHl99sMW46STcm4Vqqa6uj53SF7U7wbtPrnZPnyKs+YVwiwsBdD88aloHxBPjSlp+60yYPTAbW6PCkRoWOLkhtrQFH5xHwHpGfL3aR+pxYlMMxO69GMY2M6oh1ks8AzfIGJrUWJzxIeMiSirNZislslFOuageGHizeagoUWxDXDTkI0z1FYZ2dTdlwqREEmUrUeyhPWXXjLzKQKMn8EyKNThHdw3OnxquTWAJHVE7Z3AgQWNQJG/e9r0D/DziXgAnArT6UKPhuhR6Bcic/7t5m2KRyy26COlo0ZdWoo9nbuIzg1JNHWToN4JtFMv6oEdIYuAgUSFchy7E2UuJ+/j12WHT8mNBoUZkF3L6JnNEDRD+yfyPTg6Dao4y8V5kLxF7I/bmni3VJTsiShyzKa9+czan5PfyfPZ/BzH9aLM5IJAJYh+h2mVUOf4g4Bo+RN524y2W6OQeRi4+N7it6R3wkGYxhBlV9PGypx2X5Pdh43oT1/Sj1WnfCYP3ynPd81ZO5zaVkVpjta9W4WEJY+iUKoCsxeaksPgbor6+FWHk5GYfhYhbu9E1zjmTqX/uhrd7p0cVAk79JaKqT/QO5gWgIMmoMd/JP14UfaXs8aD/rJ+MY1Cq7ustsKuGHo8+w==";

	/// <summary>
	/// 非对称解密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="decrypting"></param>
	/// <returns></returns>
	internal static byte[] AsymmetricDecrypt(byte[] data, Func<byte[], byte[]> decrypting)
	{
		if (data.Length < 4)
		{
			throw new ArgumentException(Literals.MSG_EncryptedDataFormatError);
		}
		int encodedPasswordLength = ~ConvertHelper.GetInt32(data);
		if (data.Length <= encodedPasswordLength + 4)
		{
			throw new ArgumentException(Literals.MSG_EncryptedDataFormatError);
		}
		string password = Encoding.ASCII.GetString(decrypting(ConvertHelper.GetBytes(data, 4, encodedPasswordLength)));
		return GetSymmetricAlgorithm(password).Decrypt(ConvertHelper.GetBytes(data, encodedPasswordLength + 4));
	}

	/// <summary>
	/// 非对称解密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="result"></param>
	/// <param name="decrypting"></param>
	/// <returns></returns>
	internal static int AsymmetricDecrypt(Stream data, Stream result, Func<byte[], byte[]> decrypting)
	{
		int encodedPasswordLength = ConvertHelper.GetInt32(IOHelper.ReadBytes(data, 4L));
		string password = Encoding.ASCII.GetString(decrypting(IOHelper.ReadBytes(data, encodedPasswordLength)));
		return GetSymmetricAlgorithm(password).DecryptStream(data, result);
	}

	/// <summary>
	/// 非对称加密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="encrypting"></param>
	/// <returns></returns>
	internal static byte[] AsymmetricEncrypt(byte[] data, Func<byte[], byte[]> encrypting)
	{
		Random random = new Random((int)DateTime.Now.Ticks);
		string password = RandomHelper.GetAlphabetDigitText(random, 32);
		byte[] encryptedPassword = encrypting(Encoding.ASCII.GetBytes(password));
		byte[] encryptedData = GetSymmetricAlgorithm(password).Encrypt(data);
		return ConvertHelper.GetBytes(~encryptedPassword.Length).Concat(encryptedPassword).Concat(encryptedData)
			.ToArray();
	}

	/// <summary>
	/// 非对称加密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="result"></param>
	/// <param name="encrypting"></param>
	/// <returns></returns>
	internal static int AsymmetricEncrypt(Stream data, Stream result, Func<byte[], byte[]> encrypting)
	{
		Random random = new Random((int)DateTime.Now.Ticks);
		string password = RandomHelper.GetAlphabetDigitText(random, 32);
		int count = 0;
		byte[] encryptedPassword = encrypting(Encoding.ASCII.GetBytes(password));
		byte[] encodedLength = ConvertHelper.GetBytes(~encryptedPassword.Length);
		count += encodedLength.Length;
		IOHelper.WriteBytes(result, encodedLength);
		count += encryptedPassword.Length;
		IOHelper.WriteBytes(result, encryptedPassword);
		return count + GetSymmetricAlgorithm(password).DecryptStream(data, result);
	}

	/// <summary>
	/// 更改当前对称加解密算法的密钥
	/// </summary>
	/// <param name="algorithm">当前加密算法对象</param>
	/// <param name="password">变更的新密钥</param>
	/// <exception cref="T:System.ArgumentNullException">当前加密算法对象为空；或者变更的新密钥为空。</exception>
	public static void ChangePassword(SymmetricAlgorithm algorithm, string password)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(password, "password");
		KeyIVPair pair = CreateKeyIV(algorithm, password);
		algorithm.KeySize = pair.Key.Length;
		algorithm.Key = pair.Key;
		algorithm.BlockSize = pair.IV.Length;
		algorithm.IV = pair.IV;
	}

	/// <summary>
	/// 获取使用默认参数初始化的名称为 <paramref name="algorithmName" /> 的非对称加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static AsymmetricAlgorithm CreateAsymmetricAlgorithm(string algorithmName)
	{
		Guard.EnsureNotNull(algorithmName, "algorithm name");
		AsymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as AsymmetricAlgorithm;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmName));
		}
		return algorithm;
	}

	/// <summary>
	/// 使用默认参数创建 <paramref name="algorithmType" /> 类型的非对称加密算法
	/// </summary>
	/// <param name="algorithmType">非对称加密算法类型</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法类型 <paramref name="algorithmType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmType" /> 指定的加密算法类型。</exception>
	public static AsymmetricAlgorithm CreateAsymmetricAlgorithm(Type algorithmType)
	{
		Guard.EnsureNotNull(algorithmType, "algorithm type");
		AsymmetricAlgorithm algorithm = null;
		if (!typeof(AsymmetricAlgorithm).IsAssignableFrom(algorithmType) || ObjectHelper.IsNull(algorithm = CreateAlgorithm(algorithmType) as AsymmetricAlgorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmType.FullName));
		}
		return algorithm;
	}

	/// <summary>
	/// 获取使用指定参数初始化的名称为 <paramref name="algorithmName" /> 的非对称加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法参数 <paramref name="parameter" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static AsymmetricAlgorithm CreateAsymmetricAlgorithm(string algorithmName, string parameter)
	{
		Guard.EnsureNotNull(algorithmName, "algorithm name");
		Guard.EnsureNotNull(parameter, "parameters");
		AsymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as AsymmetricAlgorithm;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmName));
		}
		algorithm.FromXmlString(parameter);
		return algorithm;
	}

	/// <summary>
	/// 使用指定参数创建 <paramref name="algorithmType" /> 类型的非对称加密算法
	/// </summary>
	/// <param name="algorithmType">非对称加密算法类型</param>
	/// <param name="parameter">加密算法参数字符串</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法类型 <paramref name="algorithmType" /> 为空；或者加密算法参数字符串 <paramref name="parameter" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmType" /> 指定的加密算法类型。</exception>
	public static AsymmetricAlgorithm CreateAsymmetricAlgorithm(Type algorithmType, string parameter)
	{
		Guard.EnsureNotNull(algorithmType, "algorithm type");
		Guard.EnsureNotNull(parameter, "parameters");
		AsymmetricAlgorithm algorithm = CreateAsymmetricAlgorithm(algorithmType);
		algorithm.FromXmlString(parameter);
		return algorithm;
	}

	/// <summary>
	/// 使用指定参数创建 <typeparamref name="T" /> 类型的非对称加密算法
	/// </summary>
	/// <typeparam name="T">加密算法类型</typeparam>
	/// <param name="parameter">加密算法参数字符串</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法参数字符串 <paramref name="parameter" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <typeparamref name="T" /> 指定的加密算法类型。</exception>
	public static T CreateAsymmetricAlgorithm<T>(string parameter) where T : AsymmetricAlgorithm
	{
		return (T)CreateAsymmetricAlgorithm(typeof(T), parameter);
	}

	/// <summary>
	/// 获取使用指定参数初始化的名称为 <paramref name="algorithmName" /> 的非对称加密算法
	/// </summary>
	/// <typeparam name="T">加密算法类型</typeparam>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="parameter">算法参数</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法参数 <paramref name="parameter" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static T CreateAsymmetricAlgorithm<T>(string algorithmName, string parameter) where T : AsymmetricAlgorithm
	{
		T algorithm = CreateAsymmetricAlgorithm(algorithmName, parameter) as T;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmTypeError_2, algorithmName, typeof(T).FullName));
		}
		return algorithm;
	}

	/// <summary>
	/// 创建使用随机密钥初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static SymmetricAlgorithm CreateSymmetricAlgorithm(string algorithmName)
	{
		Guard.EnsureNotNull(algorithmName, "algorithm name");
		SymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as SymmetricAlgorithm;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmName));
		}
		return algorithm;
	}

	/// <summary>
	/// 使用随机密钥创建 <paramref name="algorithmType" /> 类型的加密算法
	/// </summary>
	/// <param name="algorithmType">对称加密算法类型</param>
	/// <returns>创建的算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法类型 <paramref name="algorithmType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmType" /> 指定的加密算法类型。</exception>
	public static SymmetricAlgorithm CreateSymmetricAlgorithm(Type algorithmType)
	{
		Guard.EnsureNotNull(algorithmType, "algorithm type");
		SymmetricAlgorithm algorithm = null;
		if (!typeof(SymmetricAlgorithm).IsAssignableFrom(algorithmType) || ObjectHelper.IsNull(algorithm = CreateAlgorithm(algorithmType) as SymmetricAlgorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmType.FullName));
		}
		return algorithm;
	}

	/// <summary>
	/// 创建使用指定密钥初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="password">算法密钥</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法密钥 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static SymmetricAlgorithm CreateSymmetricAlgorithm(string algorithmName, string password)
	{
		Guard.EnsureNotNull(algorithmName, "algorithm name");
		Guard.EnsureNotNull(password, "password");
		SymmetricAlgorithm algorithm = CryptoConfig.CreateFromName(algorithmName) as SymmetricAlgorithm;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmName));
		}
		InitializeSymmetricAlgorithm(algorithm, password);
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
		Guard.EnsureNotNull(algorithmType, "algorithm type");
		Guard.EnsureNotNull(password, "password");
		SymmetricAlgorithm algorithm = null;
		if (!typeof(SymmetricAlgorithm).IsAssignableFrom(algorithmType) || ObjectHelper.IsNull(algorithm = CreateAlgorithm(algorithmType) as SymmetricAlgorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmNotSupport_1, algorithmType.FullName));
		}
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 使用指定的密钥创建 <typeparamref name="T" /> 类型的加密算法
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
	/// 创建使用指定密钥初始化的名称为 <paramref name="algorithmName" /> 的加密算法
	/// </summary>
	/// <typeparam name="T">对称加密算法类型</typeparam>
	/// <param name="algorithmName">加密算法名称</param>
	/// <param name="password">算法密钥</param>
	/// <returns>指定名称的加密算法</returns>
	/// <exception cref="T:System.ArgumentNullException">加密算法名称 <paramref name="algorithmName" /> 为空；或者算法密钥 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持 <paramref name="algorithmName" /> 指定的加密算法。</exception>
	public static T CreateSymmetricAlgorithm<T>(string algorithmName, string password) where T : SymmetricAlgorithm
	{
		T algorithm = CreateSymmetricAlgorithm(algorithmName, password) as T;
		if (ObjectHelper.IsNull(algorithm))
		{
			throw new NotSupportedException(string.Format(Literals.MSG_EncryptionAlgorithmTypeError_2, algorithmName, typeof(T).FullName));
		}
		return algorithm;
	}

	private static void InitializeSymmetricAlgorithm(SymmetricAlgorithm algorithm, string password)
	{
		algorithm.Mode = CipherMode.CBC;
		algorithm.KeySize = GetMaxKeySize(algorithm);
		algorithm.BlockSize = GetMinBlockSize(algorithm);
		KeyIVPair pair = (ObjectHelper.IsNull(password) ? CreateKeyIV(algorithm) : CreateKeyIV(algorithm, password));
		algorithm.Key = pair.Key;
		algorithm.IV = pair.IV;
	}

	/// <summary>
	/// 为指定的对称算法对象创建原始密钥和初始化向量
	/// </summary>
	/// <param name="algorithm"></param>
	/// <returns></returns>
	internal static KeyIVPair CreateKeyIV(SymmetricAlgorithm algorithm)
	{
		byte[][] raws = CreateRaws(new int[2] { algorithm.KeySize, algorithm.BlockSize });
		return new KeyIVPair(raws[0], raws[1]);
	}

	/// <summary>
	/// 根据指定的密码为当前对称算法创建原始密钥和初始化向量
	/// </summary>
	/// <param name="algorithm">当前算法对象</param>
	/// <param name="password">算法密码</param>
	/// <returns>为当前算法创建的原始密钥和初始化向量。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前算法对象为空；或者给定的算法密码为空。</exception>
	internal static KeyIVPair CreateKeyIV(SymmetricAlgorithm algorithm, string password)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(password, "password");
		byte[][] raws = CreatePasswordRaws(password, new int[2] { algorithm.KeySize, algorithm.BlockSize });
		return new KeyIVPair(raws[0], raws[1]);
	}

	/// <summary>
	/// 获取指定长度的原始密钥
	/// </summary>
	/// <param name="keySize">获取的密钥长度，密钥长度单位：位</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的原始密钥</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密钥长度 <paramref name="keySize" /> 小于0；或者迭代次数 <paramref name="iterations" /> 小于1。</exception>
	private static byte[] CreateRaw(int keySize, int iterations = 4)
	{
		Guard.EnsureGreaterThanOrEqualTo(keySize, 0, "key size");
		Guard.EnsureGreaterThanOrEqualTo(iterations, 1, "iterations");
		using Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(Convert.FromBase64String("A0T7Fho9vXODDn7x+v4msybH2zOkgPwMshyH03AqxGuMJ2C9LjDG+2uStv32nJueyiupJt8sjMk0JW31fDoifDS4zXQecJ8pfrN7mJNtqHJCaYeEGeOX1T6qfBuLuZIAJd6/7Q97Z4MfjNp2ew6UWcC2GN4pJ5ByZixciySHX+CP5rsUGOzNdIEnioidK6n6Qpj7tgXE2MkS3KFxfdfV4kg1CHvvaN1k9m8qxIEnAKxQdaqb5QXR8KI5J7rF9J1xMKwF1AmXJ4Ur69ZBpXwORz1JNablnFcsP40Np6ZslbnzlOAlmY4HJaHsC4Z1c5b0lQ71+7XxgvgP358tsVY+sA=="), Convert.FromBase64String("Dk48aRcO9Hcd+QDXAiZrmpZD6zcIP8SKC0njhZESWCL2/pLgOYvd5MLLpLbKJeJ0/f5WS81UN7U23XG7/hbfTQySO/1kjVcmYT2nTcCjmaQllMSF59ySxFadVdra/Ocd2xoqgjGfPOYB4M/lNBG2xJ6EAKDnobe4LvOndu4lN7v+4DpNq/x7QuoKcpItL8405hXaVMoJ/3H1gqFVSnw5AfAjzqyaC3fZlJ5b+Dek96SuCUCpCMHMAYYdZHzIOKdo9B50OyZKi++7jiY61V/3+YMOqjdM9nZMe/G5fDWzvq1ehltwOLK25FsJOqtOq5o4NJq3LTRRJJx5KLDjoNWJNA=="), iterations);
		return GetDeriveBytes(deriver, keySize);
	}

	/// <summary>
	/// 获取指定长度的多个原始密钥
	/// </summary>
	/// <param name="keySize">获取的密钥长度，密钥长度单位：位</param>
	/// <param name="keyCount">获取的密钥的数量</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的多个原始密钥</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密钥长度 <paramref name="keySize" /> 小于0；或者获取的密钥数量 <paramref name="keyCount" /> 小于1。</exception>
	private static byte[][] CreateRaws(int keySize, int keyCount, int iterations = 4)
	{
		Guard.EnsureGreaterThanOrEqualTo(keySize, 0, "key size");
		Guard.EnsureGreaterThanOrEqualTo(keyCount, 1, "key count");
		Guard.EnsureGreaterThanOrEqualTo(iterations, 1, "iterations");
		byte[][] raws = new byte[keyCount][];
		using (Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(Convert.FromBase64String("A0T7Fho9vXODDn7x+v4msybH2zOkgPwMshyH03AqxGuMJ2C9LjDG+2uStv32nJueyiupJt8sjMk0JW31fDoifDS4zXQecJ8pfrN7mJNtqHJCaYeEGeOX1T6qfBuLuZIAJd6/7Q97Z4MfjNp2ew6UWcC2GN4pJ5ByZixciySHX+CP5rsUGOzNdIEnioidK6n6Qpj7tgXE2MkS3KFxfdfV4kg1CHvvaN1k9m8qxIEnAKxQdaqb5QXR8KI5J7rF9J1xMKwF1AmXJ4Ur69ZBpXwORz1JNablnFcsP40Np6ZslbnzlOAlmY4HJaHsC4Z1c5b0lQ71+7XxgvgP358tsVY+sA=="), Convert.FromBase64String("Dk48aRcO9Hcd+QDXAiZrmpZD6zcIP8SKC0njhZESWCL2/pLgOYvd5MLLpLbKJeJ0/f5WS81UN7U23XG7/hbfTQySO/1kjVcmYT2nTcCjmaQllMSF59ySxFadVdra/Ocd2xoqgjGfPOYB4M/lNBG2xJ6EAKDnobe4LvOndu4lN7v+4DpNq/x7QuoKcpItL8405hXaVMoJ/3H1gqFVSnw5AfAjzqyaC3fZlJ5b+Dek96SuCUCpCMHMAYYdZHzIOKdo9B50OyZKi++7jiY61V/3+YMOqjdM9nZMe/G5fDWzvq1ehltwOLK25FsJOqtOq5o4NJq3LTRRJJx5KLDjoNWJNA=="), iterations))
		{
			for (int i = 0; i < keyCount; i++)
			{
				raws[i] = GetDeriveBytes(deriver, keySize);
			}
		}
		return raws;
	}

	/// <summary>
	/// 获取指定长度的多个原始密钥
	/// </summary>
	/// <param name="keySizes">获取的密钥长度数组，密钥长度单位：位</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>指定长度的多个原始密钥</returns>
	/// <exception cref="T:System.ArgumentNullException">密钥长度数组 <paramref name="keySizes" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的密钥长度小于0；或者获密钥长度数组 <paramref name="keySizes" /> 的元素数量小于1；或者迭代次数 <paramref name="iterations" /> 小于1。</exception>
	private static byte[][] CreateRaws(int[] keySizes, int iterations = 4)
	{
		Guard.EnsureNotNull(keySizes, "key sizes");
		Guard.EnsureGreaterThanOrEqualTo(keySizes.Length, 1, "key size length");
		Guard.EnsureGreaterThanOrEqualTo(iterations, 1, "iterations");
		int keyCount = keySizes.Length;
		byte[][] raws = new byte[keyCount][];
		using (Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(Convert.FromBase64String("A0T7Fho9vXODDn7x+v4msybH2zOkgPwMshyH03AqxGuMJ2C9LjDG+2uStv32nJueyiupJt8sjMk0JW31fDoifDS4zXQecJ8pfrN7mJNtqHJCaYeEGeOX1T6qfBuLuZIAJd6/7Q97Z4MfjNp2ew6UWcC2GN4pJ5ByZixciySHX+CP5rsUGOzNdIEnioidK6n6Qpj7tgXE2MkS3KFxfdfV4kg1CHvvaN1k9m8qxIEnAKxQdaqb5QXR8KI5J7rF9J1xMKwF1AmXJ4Ur69ZBpXwORz1JNablnFcsP40Np6ZslbnzlOAlmY4HJaHsC4Z1c5b0lQ71+7XxgvgP358tsVY+sA=="), Convert.FromBase64String("Dk48aRcO9Hcd+QDXAiZrmpZD6zcIP8SKC0njhZESWCL2/pLgOYvd5MLLpLbKJeJ0/f5WS81UN7U23XG7/hbfTQySO/1kjVcmYT2nTcCjmaQllMSF59ySxFadVdra/Ocd2xoqgjGfPOYB4M/lNBG2xJ6EAKDnobe4LvOndu4lN7v+4DpNq/x7QuoKcpItL8405hXaVMoJ/3H1gqFVSnw5AfAjzqyaC3fZlJ5b+Dek96SuCUCpCMHMAYYdZHzIOKdo9B50OyZKi++7jiY61V/3+YMOqjdM9nZMe/G5fDWzvq1ehltwOLK25FsJOqtOq5o4NJq3LTRRJJx5KLDjoNWJNA=="), iterations))
		{
			for (int i = 0; i < keyCount; i++)
			{
				raws[i] = GetDeriveBytes(deriver, keySizes[i]);
			}
		}
		return raws;
	}

	/// <summary>
	/// 根据给定的密钥文本创建字节密钥
	/// </summary>
	/// <param name="password">密钥文本</param>
	/// <param name="keySizes">获取的密钥长度数组，密钥长度单位：位</param>
	/// <param name="iterations">迭代次数</param>
	/// <returns>根据给定密钥文本生成指定长度的多个原始密钥</returns>
	/// <exception cref="T:System.ArgumentNullException">密钥文本 <paramref name="password" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">密钥长度 <paramref name="keySizes" /> 小于等于0。</exception>
	private static byte[][] CreatePasswordRaws(string password, int[] keySizes, int iterations = 4)
	{
		Guard.EnsureNotNull(password, "password");
		Guard.EnsureNotNull(keySizes, "key sizes");
		Guard.EnsureGreaterThanOrEqualTo(keySizes.Length, 1, "key size length");
		Guard.EnsureGreaterThanOrEqualTo(iterations, 1, "iterations");
		byte[] salt;
		using (SHA1 sha1 = new SHA1Managed())
		{
			salt = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
		}
		int keyCount = keySizes.Length;
		byte[][] raws = new byte[keyCount][];
		using (Rfc2898DeriveBytes deriver = new Rfc2898DeriveBytes(password, salt, iterations))
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
		Guard.EnsureNotNull(algorithmType, "algorithm type");
		object algorithm = null;
		if (TypeHelper.IsInstance(algorithmType))
		{
			ConstructorInfo cinfo = algorithmType.GetConstructor(Type.EmptyTypes);
			if (ObjectHelper.IsNotNull(cinfo))
			{
				algorithm = cinfo.Invoke(null, null);
			}
		}
		MethodInfo minfo = algorithmType.GetMethod("Create", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
		if (ObjectHelper.IsNotNull(minfo) && ObjectHelper.IsNotNull(algorithm = minfo.Invoke(null, null)))
		{
			return algorithm;
		}
		return algorithm;
	}

	private static byte[] GetDeriveBytes(Rfc2898DeriveBytes derive, int minSize)
	{
		minSize /= 8;
		int count = ((minSize > 4096) ? minSize : 4096);
		byte[] bytes = derive.GetBytes(count);
		if (minSize < count)
		{
			byte[] newBytes = new byte[minSize];
			Array.Copy(bytes, 0, newBytes, 0, minSize);
			return newBytes;
		}
		return bytes;
	}

	/// <summary>
	/// 使用指定的解密算法解密字节数据
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="data">待解密的字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前解密算法为空；或者待解密的字节数据为空。</exception>
	public static byte[] DecryptBytes(SymmetricAlgorithm algorithm, byte[] data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		byte[] result = null;
		using (ICryptoTransform decryptor = algorithm.CreateDecryptor())
		{
			using MemoryStream ms = new MemoryStream(data);
			using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
			result = IOHelper.ReadAllBytes(cs);
			cs.Close();
			ms.Close();
		}
		return result;
	}

	/// <summary>
	/// 使用对称解密算法解密Base64编码的字节数据
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="data">待解密的Base64编码的字节数据</param>
	/// <returns>解密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的对称解密算法为空；或者待解密的Base64编码的字节数据为空。</exception>
	public static byte[] DecryptBytesFromBase64(SymmetricAlgorithm algorithm, string data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		return DecryptBytes(algorithm, Convert.FromBase64String(data));
	}

	/// <summary>
	/// 使用对称解密方法解密指定的文件，并用解密后的数据覆盖该文件。
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="file">待解密的数据文件全名</param>
	/// <exception cref="T:System.ArgumentNullException">对称解密算法为空；或者待解密的数据文件全名为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待解密的数据文件不存在。</exception>
	public static void DecryptFile(SymmetricAlgorithm algorithm, string file)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		DecryptFile(algorithm, new FileInfo(file));
	}

	/// <summary>
	/// 使用指定的对称解密算法解密文件，并将解密后的数据覆盖写入该文件
	/// </summary>
	/// <param name="algorithm">指定的对称解密算法</param>
	/// <param name="file">待解密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">对称解密算法为空，或者待解密的文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待解密的文件不存在。</exception>
	public static void DecryptFile(SymmetricAlgorithm algorithm, FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			DecryptStream(algorithm, i, o);
		});
	}

	/// <summary>
	/// 使用对称解密方法解密输入文件，并将解密后的数据覆盖输出文件
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="input">待解密的输入文件</param>
	/// <param name="output">解密后数据写入的输出文件</param>
	/// <exception cref="T:System.ArgumentNullException">对称解密算法为空；或者待解密的输入文件为空；或者数据输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待解密的输入文件不存在。</exception>
	public static void DecryptFile(SymmetricAlgorithm algorithm, string input, string output)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		DecryptFile(algorithm, new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用对称解密方法解密输入文件，并将解密后的数据覆盖输出文件
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="input">待解密的输入文件</param>
	/// <param name="output">解密后数据写入的输出文件</param>
	/// <exception cref="T:System.ArgumentNullException">对称解密算法为空；或者待解密的输入文件为空；或者数据输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待解密的输入文件不存在。</exception>
	public static void DecryptFile(SymmetricAlgorithm algorithm, FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(input, "input");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output");
		ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			DecryptStream(algorithm, i, o);
		});
	}

	/// <summary>
	/// 使用对称解密算法解密字节流，并返回解密后的新字节流
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="data">待解密的字节流</param>
	/// <returns>解密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">使用的对称解密算法为空；待解密的字节流为空。</exception>
	public static Stream DecryptStream(SymmetricAlgorithm algorithm, Stream data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		MemoryStream result = new MemoryStream();
		DecryptStream(algorithm, data, result);
		return result;
	}

	/// <summary>
	/// 使用对称解密算法解密字节流，并将解密后的数据写入结果流中
	/// </summary>
	/// <param name="algorithm">对称解密算法</param>
	/// <param name="data">待解密的字节流</param>
	/// <param name="result">解密后数据写入的结果字节流</param>
	/// <returns>实际解密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">使用的对称解密算法为空；待解密的字节流为空；写入的结果字节流为空。</exception>
	public static int DecryptStream(SymmetricAlgorithm algorithm, Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		int count = 0;
		byte[] buff = new byte[1024];
		int readCount = 0;
		using (ICryptoTransform decryptor = algorithm.CreateDecryptor())
		{
			using CryptoStream cs = new CryptoStream(data, decryptor, CryptoStreamMode.Read);
			while ((readCount = cs.Read(buff, 0, buff.Length)) > 0)
			{
				count += readCount;
				result.Write(buff, 0, readCount);
			}
			cs.Close();
		}
		return count;
	}

	/// <summary>
	/// 使用指定的对称解密算法解密字节数据，并按指定的文本编码编码为文本
	/// </summary>
	/// <param name="algorithm">使用的对称解密算法</param>
	/// <param name="data">待解密的字节数据</param>
	/// <param name="encoding">文本编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的对称解密算法为空；或者待解密的字节数据为空。</exception>
	public static string DecryptText(SymmetricAlgorithm algorithm, byte[] data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetString(DecryptBytes(algorithm, data));
	}

	/// <summary>
	/// 使用指定对称解密算法解密Base64编码的字节数据，并按指定字符编码解码为文本。
	/// </summary>
	/// <param name="algorithm">指定的对称解密算法</param>
	/// <param name="data">待解密的Base64编码的字节数据</param>
	/// <param name="encoding">解密文本的字符编码，默认为UTF-8编码</param>
	/// <returns>解密后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">对称解密算法为空；或者Base64编码的字节数据为空。</exception>
	public static string DecryptTextFromBase64(SymmetricAlgorithm algorithm, string data, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		return DecryptText(algorithm, Convert.FromBase64String(data), encoding);
	}

	/// <summary>
	/// 使用指定的对称加密算法加密字节数据
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="data">当前字节数据</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法为空；当前字节数据为空。</exception>
	public static byte[] EncryptBytes(SymmetricAlgorithm algorithm, byte[] data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
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
	/// 使用指定的对称加密算法加密字节数据，并返回Base64编码的加密字节
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="data">待加密的字节数据</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	public static string EncryptBytesToBase64(SymmetricAlgorithm algorithm, byte[] data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		return Convert.ToBase64String(EncryptBytes(algorithm, data));
	}

	/// <summary>
	/// 使用指定的对称加密算法加密当前文件的数据，加密后的数据覆盖当前文件
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="file">待加密的文件全名</param>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法为空；或者待加密的文件全名为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待加密的文件不存在。</exception>
	public static void EncryptFile(SymmetricAlgorithm algorithm, string file)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		EncryptFile(algorithm, new FileInfo(file));
	}

	/// <summary>
	/// 使用指定对称加密算法加密当前文件的数据， 加密后的数据覆盖当前文件。
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="file">待加密的文件</param>
	/// <exception cref="T:System.ArgumentNullException">指定的对称加密算法为空；或者待加密的文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待加密的文件不存在。</exception>
	public static void EncryptFile(SymmetricAlgorithm algorithm, FileInfo file)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(file, "file");
		Guard.EnsureFileExistence(file);
		ProcessFile(file, null, delegate(Stream i, Stream o)
		{
			EncryptStream(algorithm, i, o);
		});
	}

	/// <summary>
	/// 使用指定的对称加密算法加密输入文件的数据，加密后的数据覆盖输出文件
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="input">待加密的输入文件全名</param>
	/// <param name="output">输出文件全名</param>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法为空；或者待加密的输入文件全名为空；或者输出文件全名为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待加密的文件不存在。</exception>
	public static void EncryptFile(SymmetricAlgorithm algorithm, string input, string output)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(input, "input file");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output file");
		EncryptFile(algorithm, new FileInfo(input), new FileInfo(output));
	}

	/// <summary>
	/// 使用指定的对称加密算法加密输入文件，加密后的数据覆盖输入文件
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="input">待加密的输入文件</param>
	/// <param name="output">解密后的输入文件</param>
	/// <exception cref="T:System.ArgumentNullException">指定的对称加密算法为空；或者待加密的输入文件为空；或者加密后的输出文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">待加密的输入文件不存在。</exception>
	public static void EncryptFile(SymmetricAlgorithm algorithm, FileInfo input, FileInfo output)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(input, "input");
		Guard.EnsureFileExistence(input);
		Guard.EnsureNotNull(output, "output");
		ProcessFile(input, output, delegate(Stream i, Stream o)
		{
			EncryptStream(algorithm, i, o);
		});
	}

	/// <summary>
	/// 使用指定的对称加密算法加密字节流，返回加密后的字节流
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="data">待加密的字节流</param>
	/// <returns>加密后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的对称加密算法为空；待加密的字节流为空。</exception>
	public static Stream EncryptStream(SymmetricAlgorithm algorithm, Stream data)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		Stream result = new MemoryStream();
		EncryptStream(algorithm, data, result);
		return result;
	}

	/// <summary>
	/// 使用指定的对称加密算法加密字节流，并写入结果字节流中。
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="data">待加密的字节流</param>
	/// <param name="result">加密后的结果字节流</param>
	/// <returns>实际加密的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的对称加密算法为空；或者待加密的字节流为空；或者加密后的结果字节流为空。</exception>
	public static int EncryptStream(SymmetricAlgorithm algorithm, Stream data, Stream result)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(data, "data");
		Guard.EnsureNotNull(result, "result");
		int count = 0;
		byte[] buff = new byte[1024];
		int readCount = 0;
		using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
		{
			using CryptoStream cs = new CryptoStream(result, encryptor, CryptoStreamMode.Write);
			while ((readCount = data.Read(buff, 0, buff.Length)) > 0)
			{
				count += readCount;
				cs.Write(buff, 0, readCount);
			}
			cs.Close();
		}
		return count;
	}

	/// <summary>
	/// 使用指定的对称加密算法加密文本
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="text">待加密的文本</param>
	/// <param name="encoding">加密的文本时使用的字符编码，默认为UTF-8编码</param>
	/// <returns>加密后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的对称加密算法为空；或者待加密的文本为空。</exception>
	public static byte[] EncryptText(SymmetricAlgorithm algorithm, string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(text, "text");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return EncryptBytes(algorithm, encoding.GetBytes(text));
	}

	/// <summary>
	/// 使用指定的对称加密算法加密文本，并返回Base64编码的加密字节数据
	/// </summary>
	/// <param name="algorithm">指定的对称加密算法</param>
	/// <param name="text">待加密的文本</param>
	/// <param name="encoding">加密文本时使用的字符编码</param>
	/// <returns>加密后的Base64编码的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">对称加密算法为空；或者待加密的文本为空。</exception>
	public static string EncryptTextToBase64(SymmetricAlgorithm algorithm, string text, Encoding encoding = null)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(text, "text");
		return Convert.ToBase64String(EncryptText(algorithm, text, encoding));
	}

	/// <summary>
	/// 导出当前对称算法的参数对象
	/// </summary>
	/// <param name="algorithm">当前对称算法</param>
	/// <returns>导出的参数对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空。</exception>
	public static SymmetricParameter ExportParameter(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		SymmetricParameter parameter = new SymmetricParameter();
		parameter.BlockSize = algorithm.BlockSize;
		parameter.FeedbackSize = algorithm.FeedbackSize;
		parameter.IV = algorithm.IV;
		parameter.Key = algorithm.Key;
		parameter.KeySize = algorithm.KeySize;
		parameter.Mode = algorithm.Mode;
		parameter.Padding = parameter.Padding;
		return parameter;
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.TripleDES" /> 算法对象
	/// </summary>
	/// <returns>3DES 算法对象</returns>
	private static ISymmetricAlgorithm Get3DES()
	{
		GenericSymmetricAlgorithm<TripleDES> algorithm = new GenericSymmetricAlgorithm<TripleDES>((TripleDES)CreateSymmetricAlgorithm("3DES"));
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.TripleDES" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>3DES 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static ISymmetricAlgorithm Get3DES(string password)
	{
		GenericSymmetricAlgorithm<TripleDES> algorithm = new GenericSymmetricAlgorithm<TripleDES>((TripleDES)CreateSymmetricAlgorithm("3DES"));
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.Aes" /> 算法对象
	/// </summary>
	/// <returns>Aes 算法对象</returns>
	private static ISymmetricAlgorithm GetAES()
	{
		GenericSymmetricAlgorithm<Aes> algorithm = new GenericSymmetricAlgorithm<Aes>((Aes)CreateSymmetricAlgorithm("AES"));
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.Aes" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>Aes 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static ISymmetricAlgorithm GetAES(string password)
	{
		GenericSymmetricAlgorithm<Aes> algorithm = new GenericSymmetricAlgorithm<Aes>((Aes)CreateSymmetricAlgorithm("AES"));
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.DES" /> 算法对象
	/// </summary>
	/// <returns>DES 算法对象</returns>
	private static ISymmetricAlgorithm GetDES()
	{
		GenericSymmetricAlgorithm<DES> algorithm = new GenericSymmetricAlgorithm<DES>((DES)CreateSymmetricAlgorithm("DES"));
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.DES" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>DES 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static ISymmetricAlgorithm GetDES(string password)
	{
		GenericSymmetricAlgorithm<DES> algorithm = new GenericSymmetricAlgorithm<DES>((DES)CreateSymmetricAlgorithm("DES"));
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取默认密钥初始化的 <see cref="T:System.Security.Cryptography.Rijndael" /> 算法对象
	/// </summary>
	/// <returns>Rijndael 算法对象</returns>
	private static ISymmetricAlgorithm GetRijndael()
	{
		GenericSymmetricAlgorithm<Rijndael> algorithm = new GenericSymmetricAlgorithm<Rijndael>((Rijndael)CreateSymmetricAlgorithm("Rijndael"));
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的 <see cref="T:System.Security.Cryptography.Rijndael" /> 算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>Rijndael 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static ISymmetricAlgorithm GetRijndael(string password)
	{
		GenericSymmetricAlgorithm<Rijndael> algorithm = new GenericSymmetricAlgorithm<Rijndael>((Rijndael)CreateSymmetricAlgorithm("Rijndael"));
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取指定参数初始化的 <see cref="T:System.Security.Cryptography.RSA" /> 算法对象
	/// </summary>
	/// <returns>RSA 算法对象</returns>
	private static IAsymmetricAlgorithm GetRSA()
	{
		RSAAlgorithm algorithm = new RSAAlgorithm();
		algorithm.FromXmlString(GetRSAKeyXml());
		return algorithm;
	}

	/// <summary>
	/// 获取指定参数初始化的 <see cref="T:System.Security.Cryptography.RSA" /> 算法对象
	/// </summary>
	/// <param name="parameters">算法参数</param>
	/// <returns>RSA 算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法参数 <paramref name="parameters" /> 为空。</exception>
	public static IAsymmetricAlgorithm GetRSA(string parameters)
	{
		Guard.EnsureNotNull(parameters, "RSA parameters");
		RSAAlgorithm algorithm = new RSAAlgorithm();
		algorithm.FromXmlString(parameters);
		return algorithm;
	}

	/// <summary>
	/// 获取默认参数初始化的默认非对称算法对象
	/// </summary>
	/// <returns>默认的非对称算法对象</returns>
	public static IAsymmetricAlgorithm GetAsymmetricAlgorithm()
	{
		return new RSAAlgorithm(GetRSAKeyXml());
	}

	/// <summary>
	/// 获取指定参数初始化的默认非对称算法对象
	/// </summary>
	/// <param name="parameter">算法参数</param>
	/// <returns>默认的非对称算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法参数 <paramref name="parameter" /> 为空。</exception>
	public static IAsymmetricAlgorithm GetAsymmetricAlgorithm(string parameter)
	{
		Guard.EnsureNotNull(parameter, "parameter");
		return new RSAAlgorithm(parameter);
	}

	/// <summary>
	/// 获取指定参数初始化的指定类型的非对称算法对象
	/// </summary>
	/// <typeparam name="A">算法实现的类型</typeparam>
	/// <param name="parameter">算法参数</param>
	/// <returns>算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法参数 <paramref name="parameter" /> 为空。</exception>
	public static IAsymmetricAlgorithm GetAsymmetricAlgorithm<A>(string parameter) where A : AsymmetricAlgorithm
	{
		Guard.EnsureNotNull(parameter, "parameter");
		GenericAsymmetricAlgorithm<A> algorithm = new GenericAsymmetricAlgorithm<A>();
		algorithm.FromXmlString(parameter);
		return algorithm;
	}

	private static string GetRSAKeyXml()
	{
		using ISymmetricAlgorithm algorithm = GetSymmetricAlgorithm();
		return Encoding.UTF8.GetString(algorithm.Decrypt(Convert.FromBase64String("n2CXeRLJGs3ZSO73ImK9LfV8mqT/B4Q430oklD7qFpfD464E6U2ugkI7QnNPVyPqqFhyX8qonDqUn2EXZdAbNo1h0jCME8HzIHMsTOujXZDicFKGNSHhOHeRJ5vnv2IMzz3erzzfkVd5QqUzDWm+ZrmADZ3dqZxdNUUC4y/XZPtS/5fcZzB2OwSSuvOc4zYmLxvDCV+39jlTTJtyJuJs1zlB/puzF6sbYW/lxHYGsqTaWelfSLJdeEuQfDwwQ/C5wzqOWNVkyvjy7UCIwRRMFBexTK7zooFpYQtKCTYqY3QdlaJwwLuhEuG/9MkDzBUCxjIBumUyvefVJy1kVEDQjEeEMVHgSbbQkrFo8U6gigcYBJcyI5x3AyWkRi5DFuVxBX2N/Pt+VtmREkx/MCHFKCEf7uPHlHBWQmaRmVQMrEbja37U2/ZxAAJOffCH2Bsyqabhvl+HU/02o0uEYRuKSi0DcF5Fl1QEm8r0w0gKJY0zphJG6XVGRZus3a6eA9/S7YzNQb172Z4XgfYV07RtvXcUVooCYmVEMOmzgMYvoRa/WLtUdeaPgOqpdO7h/EAw72RL8ovNWsu5S+YdBTcIk44hrHl99sMW46STcm4Vqqa6uj53SF7U7wbtPrnZPnyKs+YVwiwsBdD88aloHxBPjSlp+60yYPTAbW6PCkRoWOLkhtrQFH5xHwHpGfL3aR+pxYlMMxO69GMY2M6oh1ks8AzfIGJrUWJzxIeMiSirNZislslFOuageGHizeagoUWxDXDTkI0z1FYZ2dTdlwqREEmUrUeyhPWXXjLzKQKMn8EyKNThHdw3OnxquTWAJHVE7Z3AgQWNQJG/e9r0D/DziXgAnArT6UKPhuhR6Bcic/7t5m2KRyy26COlo0ZdWoo9nbuIzg1JNHWToN4JtFMv6oEdIYuAgUSFchy7E2UuJ+/j12WHT8mNBoUZkF3L6JnNEDRD+yfyPTg6Dao4y8V5kLxF7I/bmni3VJTsiShyzKa9+czan5PfyfPZ/BzH9aLM5IJAJYh+h2mVUOf4g4Bo+RN524y2W6OQeRi4+N7it6R3wkGYxhBlV9PGypx2X5Pdh43oT1/Sj1WnfCYP3ynPd81ZO5zaVkVpjta9W4WEJY+iUKoCsxeaksPgbor6+FWHk5GYfhYhbu9E1zjmTqX/uhrd7p0cVAk79JaKqT/QO5gWgIMmoMd/JP14UfaXs8aD/rJ+MY1Cq7ustsKuGHo8+w==")));
	}

	/// <summary>
	/// 获取默认密钥初始化的默认对称算法对象
	/// </summary>
	/// <returns>默认的对称算法对象</returns>
	public static ISymmetricAlgorithm GetSymmetricAlgorithm()
	{
		RijndaelAlgorithm algorithm = new RijndaelAlgorithm();
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的默认对称算法对象
	/// </summary>
	/// <param name="password">算法密钥</param>
	/// <returns>默认的对称算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">算法密钥 <paramref name="password" /> 为空。</exception>
	public static ISymmetricAlgorithm GetSymmetricAlgorithm(string password)
	{
		Guard.EnsureNotNull(password, "password");
		RijndaelAlgorithm algorithm = new RijndaelAlgorithm();
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取默认密钥初始化的指定类型的对称加解密算法对象
	/// </summary>
	/// <typeparam name="A">算法实现的类型，不接受基类型</typeparam>
	/// <returns>算法对象</returns>
	public static ISymmetricAlgorithm GetSymmetricAlgorithm<A>() where A : SymmetricAlgorithm
	{
		GenericSymmetricAlgorithm<A> algorithm = new GenericSymmetricAlgorithm<A>();
		InitializeSymmetricAlgorithm(algorithm, null);
		return algorithm;
	}

	/// <summary>
	/// 获取指定密钥初始化的指定类型的对称加解密算法对象
	/// </summary>
	/// <typeparam name="A">算法实现的类型，不接受基类型</typeparam>
	/// <param name="password">指定的算法密钥</param>
	/// <returns>算法对象</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的算法密钥为空。</exception>
	public static ISymmetricAlgorithm GetSymmetricAlgorithm<A>(string password) where A : SymmetricAlgorithm
	{
		Guard.EnsureNotNull(password, "password");
		GenericSymmetricAlgorithm<A> algorithm = new GenericSymmetricAlgorithm<A>();
		InitializeSymmetricAlgorithm(algorithm, password);
		return algorithm;
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最小数据块长度；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小数据块长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int GetMinBlockSize(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidBlockSizes(algorithm).First();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最小密钥长度；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int GetMinKeySize(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidKeySizes(algorithm).First();
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的最小密钥长度；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的最小密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前非对称加密算法为空。</exception>
	public static int GetMinKeySize(AsymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidKeySizes(algorithm).First();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最大数据块长度；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最小数据块长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int GetMaxBlockSize(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidBlockSizes(algorithm).Last();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的最大密钥长度，密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的最大密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int GetMaxKeySize(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidKeySizes(algorithm).Last();
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的最大密钥长度，密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的最大密钥长度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前非对称加密算法为空。</exception>
	public static int GetMaxKeySize(AsymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetValidKeySizes(algorithm).Last();
	}

	/// <summary>
	/// 获取当前对称加密算法支持的数据块大小；数据库长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的数据块大小列表</returns>
	public static int[] GetValidBlockSizes(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetSizes(algorithm.LegalBlockSizes);
	}

	/// <summary>
	/// 获取当前对称加密算法支持的密钥长度的数组；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前对称加密算法</param>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int[] GetValidKeySizes(SymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		return GetSizes(algorithm.LegalKeySizes);
	}

	/// <summary>
	/// 获取当前非对称加密算法支持的密钥大小；密钥长度单位：位。
	/// </summary>
	/// <param name="algorithm">当前非对称加密算法</param>
	/// <returns>支持的密钥大小列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对称加密算法为空。</exception>
	public static int[] GetValidKeySizes(AsymmetricAlgorithm algorithm)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
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
	/// 导入当前对称算法的参数对象
	/// </summary>
	/// <param name="algorithm">当前对称算法</param>
	/// <param name="parameter">导入的参数对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前对称算法对象为空；或者导入的参数对象为空。</exception>
	public static void ImportParameter(SymmetricAlgorithm algorithm, SymmetricParameter parameter)
	{
		Guard.EnsureNotNull(algorithm, "algorithm");
		Guard.EnsureNotNull(parameter, "parameter");
		algorithm.BlockSize = parameter.BlockSize;
		algorithm.FeedbackSize = parameter.FeedbackSize;
		algorithm.IV = parameter.IV;
		algorithm.Key = parameter.Key;
		algorithm.KeySize = parameter.KeySize;
		algorithm.Mode = parameter.Mode;
		algorithm.Padding = parameter.Padding;
	}

	/// <summary>
	/// 处理文件
	/// </summary>
	/// <param name="input"></param>
	/// <param name="output"></param>
	/// <param name="processing"></param>
	internal static void ProcessFile(FileInfo input, FileInfo output, Action<Stream, Stream> processing)
	{
		if (ObjectHelper.IsNull(output))
		{
			output = new FileInfo(IOHelper.CreateTempFile());
			using (FileStream fileStream = output.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None))
			{
				using (FileStream arg = input.OpenRead())
				{
					processing(arg, fileStream);
				}
				fileStream.Position = 0L;
				using FileStream arg = input.Open(FileMode.Create, FileAccess.Write, FileShare.None);
				fileStream.CopyTo(arg);
			}
			output.Delete();
			return;
		}
		if (input.FullName == output.FullName)
		{
			FileInfo temp = new FileInfo(IOHelper.CreateTempFile());
			using FileStream tempFs = temp.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None);
			using (FileStream arg = input.OpenRead())
			{
				processing(arg, tempFs);
			}
			tempFs.Position = 0L;
			using FileStream fileStream = output.Open(FileMode.Create, FileAccess.Write, FileShare.None);
			tempFs.CopyTo(fileStream);
			return;
		}
		using FileStream fileStream = output.Open(FileMode.Create, FileAccess.Write, FileShare.None);
		using FileStream arg = input.OpenRead();
		processing(arg, fileStream);
	}
}
