using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml;

namespace ns3;

internal class Class10
{
	private static readonly byte[] byte_0 = new byte[8] { 254, 167, 210, 118, 59, 75, 158, 121 };

	private static readonly byte[] byte_1 = new byte[8] { 215, 170, 15, 109, 48, 97, 52, 78 };

	private static readonly byte[] byte_2 = new byte[8] { 20, 110, 11, 231, 171, 172, 208, 214 };

	private readonly XmlNode xmlNode_0;

	private readonly Class11 class11_0 = new Class11();

	private readonly byte[] byte_3;

	private byte[] byte_4;

	private byte[] byte_5;

	private byte[] byte_6;

	private byte[] byte_7;

	private byte[] byte_8;

	private int int_0;

	private byte[] byte_9;

	public Class10(string hashAlgorithm, XmlNode encryptionDataNode, byte[] passwordBytes)
	{
		if (encryptionDataNode == null)
		{
			throw new ArgumentNullException("encryptionDataNode");
		}
		xmlNode_0 = encryptionDataNode;
		class11_0.HashAlogrithm = hashAlgorithm;
		byte_3 = passwordBytes;
		method_6();
		method_10();
		method_11();
		method_12();
	}

	public bool method_0()
	{
		if (byte_9 == byte_6)
		{
			return true;
		}
		if (byte_9 != null && byte_6 != null)
		{
			if (byte_9.Length != byte_6.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < byte_9.Length)
				{
					if (byte_9[num] != byte_6[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public MemoryStream method_1(MemoryStream encryptedPackage)
	{
		MemoryStream result = new MemoryStream();
		byte[] contentBuffer = new byte[4096];
		for (int i = method_2(encryptedPackage, result, contentBuffer, 0L); i < encryptedPackage.Length; i += method_2(encryptedPackage, result, contentBuffer, i))
		{
		}
		return result;
	}

	private int method_2(MemoryStream dataStream, MemoryStream result, byte[] contentBuffer, long newPosition)
	{
		long num = newPosition / contentBuffer.Length;
		dataStream.Position = method_4(num * contentBuffer.Length);
		int num2 = dataStream.Read(contentBuffer, 0, contentBuffer.Length);
		Class11 encryptionInfo = method_3();
		using ICryptoTransform transform = method_14(encryptionInfo, BitConverter.GetBytes((int)num), isEncryption: false);
		smethod_1(transform, contentBuffer, 0, num2);
		result.Write(contentBuffer, 0, contentBuffer.Length);
		return num2;
	}

	private Class11 method_3()
	{
		Class11 @class = new Class11();
		XmlNode xmlNode = xmlNode_0["keyData"];
		@class.SaltValue = Convert.FromBase64String(xmlNode.Attributes["saltValue"].Value);
		@class.CipherAlogrithm = xmlNode.Attributes["cipherAlgorithm"].Value;
		@class.CipherChaining = xmlNode.Attributes["cipherChaining"].Value;
		@class.HashAlogrithm = xmlNode.Attributes["cipherChaining"].Value;
		@class.KeyBits = method_8(xmlNode);
		@class.BlockSize = method_9(xmlNode);
		return @class;
	}

	private long method_4(long offset)
	{
		return offset + 8L;
	}

	private void method_5(MemoryStream input, MemoryStream output)
	{
		byte[] array = new byte[32768];
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			output.Write(array, 0, count);
		}
	}

	private void method_6()
	{
		XmlNode xmlNode = xmlNode_0["keyEncryptors"];
		if (xmlNode == null)
		{
			throw new InvalidOperationException();
		}
		XmlNode xmlNode2 = xmlNode["keyEncryptor"];
		if (xmlNode2 == null)
		{
			throw new InvalidOperationException();
		}
		XmlNode xmlNode3 = xmlNode2["p:encryptedKey"];
		method_7(xmlNode3);
		class11_0.KeyBits = method_8(xmlNode3);
		class11_0.BlockSize = method_9(xmlNode3);
		class11_0.SaltValue = Convert.FromBase64String(xmlNode3.Attributes["saltValue"].Value);
		class11_0.CipherAlogrithm = xmlNode3.Attributes["cipherAlgorithm"].Value;
		class11_0.CipherChaining = xmlNode3.Attributes["cipherChaining"].Value;
		byte_5 = Convert.FromBase64String(xmlNode3.Attributes["encryptedVerifierHashInput"].Value);
		byte_6 = Convert.FromBase64String(xmlNode3.Attributes["encryptedVerifierHashValue"].Value);
		byte_7 = Convert.FromBase64String(xmlNode3.Attributes["encryptedKeyValue"].Value);
	}

	private void method_7(XmlNode encryptedKeyNode)
	{
		if (int.TryParse(encryptedKeyNode.Attributes["spinCount"].Value, out var result))
		{
			int_0 = result;
		}
		else
		{
			int_0 = 100000;
		}
	}

	private int method_8(XmlNode keyNode)
	{
		if (int.TryParse(keyNode.Attributes["keyBits"].Value, out var result))
		{
			return result;
		}
		return 128;
	}

	private int method_9(XmlNode keyNode)
	{
		if (int.TryParse(keyNode.Attributes["blockSize"].Value, out var result))
		{
			return result * 8;
		}
		return 128;
	}

	private void method_10()
	{
		HashAlgorithm hashAlgorithm = method_16();
		using (hashAlgorithm)
		{
			hashAlgorithm.TransformBlock(class11_0.SaltValue, 0, class11_0.SaltValue.Length, null, 0);
			hashAlgorithm.TransformFinalBlock(byte_3, 0, byte_3.Length);
			byte[] hash = hashAlgorithm.Hash;
			for (int i = 0; i < int_0; i++)
			{
				byte[] bytes = BitConverter.GetBytes(i);
				hashAlgorithm.Initialize();
				hashAlgorithm.TransformBlock(bytes, 0, bytes.Length, null, 0);
				hashAlgorithm.TransformFinalBlock(hash, 0, hash.Length);
				hash = hashAlgorithm.Hash;
			}
			byte_4 = hash;
		}
	}

	private void method_11()
	{
		byte[] array = (byte[])byte_5.Clone();
		ICryptoTransform cryptoTransform = method_13(byte_0, isEncryption: false);
		using (cryptoTransform)
		{
			smethod_1(cryptoTransform, array, 0, array.Length);
		}
		byte[] array2;
		using (HashAlgorithm hashAlgorithm = method_16())
		{
			int num = hashAlgorithm.HashSize / 8;
			array2 = new byte[smethod_2(num, class11_0.BlockSize / 8)];
			hashAlgorithm.TransformFinalBlock(array, 0, array.Length);
			Buffer.BlockCopy(hashAlgorithm.Hash, 0, array2, 0, num);
		}
		using (ICryptoTransform transform = method_13(byte_1, isEncryption: true))
		{
			smethod_1(transform, array2, 0, array2.Length);
		}
		byte_9 = array2;
	}

	private void method_12()
	{
		byte[] array = (byte[])byte_7.Clone();
		using (ICryptoTransform transform = method_13(byte_2, isEncryption: false))
		{
			smethod_1(transform, array, 0, array.Length);
		}
		byte_8 = array;
	}

	private ICryptoTransform method_13(byte[] block, bool isEncryption)
	{
		HashAlgorithm hashAlgorithm = method_16();
		using (hashAlgorithm)
		{
			hashAlgorithm.TransformBlock(byte_4, 0, byte_4.Length, null, 0);
			hashAlgorithm.TransformFinalBlock(block, 0, block.Length);
			byte[] rgbKey = smethod_0(hashAlgorithm.Hash, class11_0.KeyBits / 8, 54);
			byte[] rgbIV = smethod_0(class11_0.SaltValue, class11_0.BlockSize / 8, 54);
			SymmetricAlgorithm symmetricAlgorithm = method_17(class11_0);
			using (symmetricAlgorithm)
			{
				ICryptoTransform cryptoTransform = null;
				if (isEncryption)
				{
					return symmetricAlgorithm.CreateEncryptor(rgbKey, rgbIV);
				}
				return symmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);
			}
		}
	}

	private ICryptoTransform method_14(Class11 encryptionInfo, byte[] blockKey, bool isEncryption)
	{
		HashAlgorithm hashAlgorithm = method_16();
		hashAlgorithm.TransformBlock(encryptionInfo.SaltValue, 0, encryptionInfo.SaltValue.Length, null, 0);
		hashAlgorithm.TransformFinalBlock(blockKey, 0, blockKey.Length);
		byte[] rgbIV = smethod_0(hashAlgorithm.Hash, encryptionInfo.BlockSize / 8, 54);
		SymmetricAlgorithm symmetricAlgorithm = method_17(encryptionInfo);
		if (isEncryption)
		{
			return symmetricAlgorithm.CreateEncryptor(byte_8, rgbIV);
		}
		return symmetricAlgorithm.CreateDecryptor(byte_8, rgbIV);
	}

	private static byte[] smethod_0(byte[] input, int size, byte padding)
	{
		byte[] array = new byte[size];
		Buffer.BlockCopy(input, 0, array, 0, Math.Min(input.Length, array.Length));
		for (int i = input.Length; i < array.Length; i++)
		{
			array[i] = padding;
		}
		return array;
	}

	private static void smethod_1(ICryptoTransform transform, byte[] buffer, int offset, int count)
	{
		if (count != 0)
		{
			int num = transform.TransformBlock(buffer, offset, count, buffer, offset);
			if (count != num)
			{
				throw new InvalidOperationException();
			}
		}
	}

	private static int smethod_2(int value, int round)
	{
		if (round == 0)
		{
			return round;
		}
		return (value + round - 1) / round * round;
	}

	private HashAlgorithm method_15(string hashAlgorithm)
	{
		return HashAlgorithm.Create(hashAlgorithm);
	}

	private HashAlgorithm method_16()
	{
		return method_15(class11_0.HashAlogrithm);
	}

	private SymmetricAlgorithm method_17(Class11 encryptionInfo)
	{
		SymmetricAlgorithm symmetricAlgorithm = SymmetricAlgorithm.Create(encryptionInfo.CipherAlogrithm);
		symmetricAlgorithm.BlockSize = encryptionInfo.BlockSize;
		symmetricAlgorithm.KeySize = encryptionInfo.KeyBits;
		symmetricAlgorithm.Padding = PaddingMode.None;
		switch (encryptionInfo.CipherChaining)
		{
		case "ChainingModeCBC":
			symmetricAlgorithm.Mode = CipherMode.CBC;
			break;
		case "ChainingModeCFB":
			symmetricAlgorithm.Mode = CipherMode.CFB;
			break;
		default:
			throw new InvalidOperationException();
		}
		return symmetricAlgorithm;
	}
}
