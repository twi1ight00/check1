using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns57;

namespace ns11;

internal class Class1115
{
	internal byte[] byte_0 = new byte[20];

	private Class1317 class1317_0;

	private byte[] byte_1 = new byte[16]
	{
		243, 37, 115, 183, 251, 176, 94, 112, 204, 43,
		218, 72, 234, 182, 124, 158
	};

	private byte[] byte_2 = new byte[16]
	{
		134, 217, 129, 105, 245, 179, 130, 51, 86, 176,
		21, 187, 51, 249, 223, 203
	};

	private byte[] byte_3 = new byte[16]
	{
		26, 147, 86, 19, 26, 94, 170, 208, 218, 36,
		185, 178, 23, 175, 183, 205
	};

	private byte[] byte_4 = new byte[32]
	{
		206, 145, 10, 82, 17, 212, 255, 18, 74, 244,
		35, 45, 219, 29, 198, 251, 184, 134, 111, 163,
		168, 191, 39, 29, 201, 230, 33, 211, 120, 206,
		24, 241
	};

	private byte[] byte_5 = new byte[16]
	{
		199, 152, 201, 222, 205, 159, 203, 184, 39, 88,
		114, 127, 238, 248, 230, 231
	};

	internal static bool smethod_0(string string_0, string string_1, byte[] byte_6, byte[] byte_7, int int_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		HashAlgorithm hashAlgorithm = null;
		switch (string_1)
		{
		case "SHA-512":
			hashAlgorithm = new SHA512Managed();
			break;
		case "SHA-1":
			hashAlgorithm = new SHA1Managed();
			break;
		case "SHA-256":
			hashAlgorithm = new SHA256Managed();
			break;
		}
		if (hashAlgorithm == null)
		{
			return false;
		}
		byte[] array = new byte[byte_7.Length + bytes.Length];
		Array.Copy(byte_7, array, byte_7.Length);
		Array.Copy(bytes, 0, array, byte_7.Length, bytes.Length);
		byte[] array2 = hashAlgorithm.ComputeHash(array);
		if (array2.Length != byte_6.Length)
		{
			return false;
		}
		byte[] array3 = new byte[array2.Length + 4];
		for (int i = 0; i < int_0; i++)
		{
			Array.Copy(array2, array3, array2.Length);
			Array.Copy(BitConverter.GetBytes(i), 0, array3, array2.Length, 4);
			array2 = hashAlgorithm.ComputeHash(array3);
		}
		bool result = true;
		for (int j = 0; j < array2.Length; j++)
		{
			if (array2[j] != byte_6[j])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	internal Class1115(Class1317 class1317_1, byte[] byte_6, byte[] byte_7)
	{
		class1317_0 = class1317_1;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(new MemoryStream(byte_6)
		{
			Position = 8L
		});
		XmlNode documentElement = xmlDocument.DocumentElement;
		XmlAttribute xmlAttribute = documentElement["keyData"].Attributes["saltValue"];
		byte_1 = Convert.FromBase64String(xmlAttribute.Value);
		XmlNode xmlNode = documentElement["keyEncryptors"];
		XmlNode xmlNode2 = xmlNode["keyEncryptor"]["p:encryptedKey"];
		XmlAttribute xmlAttribute2 = xmlNode2.Attributes["saltValue"];
		byte_2 = Convert.FromBase64String(xmlAttribute2.Value);
		XmlAttribute xmlAttribute3 = xmlNode2.Attributes["encryptedVerifierHashInput"];
		byte_3 = Convert.FromBase64String(xmlAttribute3.Value);
		XmlAttribute xmlAttribute4 = xmlNode2.Attributes["encryptedVerifierHashValue"];
		byte_4 = Convert.FromBase64String(xmlAttribute4.Value);
		XmlAttribute xmlAttribute5 = xmlNode2.Attributes["encryptedKeyValue"];
		byte_5 = Convert.FromBase64String(xmlAttribute5.Value);
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array = new byte[byte_2.Length + byte_7.Length];
		byte[] array2 = new byte[24];
		Array.Copy(byte_2, array, byte_2.Length);
		Array.Copy(byte_7, 0, array, byte_2.Length, byte_7.Length);
		byte_0 = sHA1CryptoServiceProvider.ComputeHash(array);
		for (int i = 0; i < 100000; i++)
		{
			Array.Copy(BitConverter.GetBytes(i), array2, 4);
			Array.Copy(byte_0, 0, array2, 4, 20);
			byte_0 = sHA1CryptoServiceProvider.ComputeHash(array2);
		}
	}

	private byte[] method_0(byte[] byte_6, byte[] byte_7, byte[] byte_8)
	{
		byte[] array = new byte[8] { 254, 167, 210, 118, 59, 75, 158, 121 };
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array2 = new byte[byte_6.Length + array.Length];
		Array.Copy(byte_6, array2, byte_6.Length);
		Array.Copy(array, 0, array2, byte_6.Length, array.Length);
		byte[] array3 = new byte[16];
		Array.Copy(sHA1CryptoServiceProvider.ComputeHash(array2), array3, 16);
		byte[] buffer = new byte[byte_8.Length];
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = 128;
		rijndaelManaged.Mode = CipherMode.CBC;
		rijndaelManaged.Padding = PaddingMode.Zeros;
		rijndaelManaged.IV = byte_7;
		rijndaelManaged.Key = array3;
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor();
		MemoryStream stream = new MemoryStream(byte_8);
		CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		cryptoStream.Read(buffer, 0, byte_8.Length);
		cryptoStream.Close();
		return sHA1CryptoServiceProvider.ComputeHash(buffer);
	}

	private byte[] method_1(byte[] byte_6, byte[] byte_7, byte[] byte_8)
	{
		byte[] array = new byte[8] { 215, 170, 15, 109, 48, 97, 52, 78 };
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array2 = new byte[byte_6.Length + array.Length];
		Array.Copy(byte_6, array2, byte_6.Length);
		Array.Copy(array, 0, array2, byte_6.Length, array.Length);
		byte[] array3 = new byte[16];
		Array.Copy(sHA1CryptoServiceProvider.ComputeHash(array2), array3, 16);
		byte[] array4 = new byte[32];
		byte[] array5 = new byte[32];
		Array.Copy(byte_8, array4, byte_8.Length);
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = 128;
		rijndaelManaged.Mode = CipherMode.CBC;
		rijndaelManaged.Padding = PaddingMode.Zeros;
		rijndaelManaged.IV = byte_7;
		rijndaelManaged.Key = array3;
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor();
		MemoryStream stream = new MemoryStream(array5);
		CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(array4, 0, array4.Length);
		cryptoStream.Close();
		return array5;
	}

	internal bool method_2()
	{
		byte[] byte_ = method_0(byte_0, byte_2, byte_3);
		byte[] array = method_1(byte_0, byte_2, byte_);
		bool result = true;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != byte_4[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	internal Stream method_3()
	{
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array = new byte[28];
		Array.Copy(byte_0, array, 20);
		Array.Copy(new byte[8] { 20, 110, 11, 231, 171, 172, 208, 214 }, 0, array, 20, 8);
		byte[] sourceArray = sHA1CryptoServiceProvider.ComputeHash(array);
		array = new byte[16];
		Array.Copy(sourceArray, array, 16);
		byte[] array2 = new byte[16];
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = 128;
		rijndaelManaged.Mode = CipherMode.CBC;
		rijndaelManaged.Padding = PaddingMode.Zeros;
		rijndaelManaged.IV = byte_2;
		rijndaelManaged.Key = array;
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor();
		MemoryStream stream = new MemoryStream(byte_5);
		CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		cryptoStream.Read(array2, 0, 16);
		cryptoStream.Close();
		MemoryStream stream2 = class1317_0.method_9().GetStream("EncryptedPackage");
		long length = stream2.Length;
		long num = 0L;
		MemoryStream memoryStream = new MemoryStream((int)stream2.Length);
		byte[] buffer = new byte[4096];
		byte[] buffer2 = new byte[4096];
		stream2.Position = 8L;
		array = new byte[20];
		byte[] array3 = new byte[16];
		try
		{
			int num2;
			for (; num < length - 8; num += num2)
			{
				Array.Copy(byte_1, array, 16);
				Array.Copy(BitConverter.GetBytes(num / 4096), 0, array, 16, 4);
				Array.Copy(sHA1CryptoServiceProvider.ComputeHash(array), array3, 16);
				rijndaelManaged.IV = array3;
				rijndaelManaged.Key = array2;
				transform = rijndaelManaged.CreateDecryptor();
				num2 = stream2.Read(buffer, 0, 4096);
				stream = new MemoryStream(buffer);
				cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				cryptoStream.Read(buffer2, 0, num2);
				memoryStream.Write(buffer2, 0, num2);
				cryptoStream.Close();
			}
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.InvalidData, "unkown excel content!");
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}
}
