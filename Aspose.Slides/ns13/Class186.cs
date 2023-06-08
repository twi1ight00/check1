using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Slides;

namespace ns13;

internal class Class186
{
	private byte[] byte_0 = new byte[20];

	private uint uint_0 = 24u;

	private uint uint_1 = 32772u;

	private uint uint_2 = 26126u;

	private byte[] byte_1;

	private byte[] byte_2;

	private byte[] byte_3;

	private byte[] byte_4;

	private byte[] byte_5;

	private Class185 class185_0;

	private SHA1 sha1_0;

	public Class186(byte[] recordData, string strPassword)
	{
		int num = 8;
		int num2 = BitConverter.ToInt32(recordData, 8);
		uint num3 = BitConverter.ToUInt32(recordData, 20);
		uint num4 = BitConverter.ToUInt32(recordData, 24);
		BitConverter.ToUInt32(recordData, 28);
		uint num5 = BitConverter.ToUInt32(recordData, 32);
		Encoding.Unicode.GetString(recordData, 44, num2 - 34);
		num = 12 + num2;
		num2 = BitConverter.ToInt32(recordData, num);
		num += 4;
		byte[] destinationArray = new byte[num2];
		byte[] destinationArray2 = new byte[num2];
		Array.Copy(recordData, num, destinationArray, 0, num2);
		num += num2;
		Array.Copy(recordData, num, destinationArray2, 0, num2);
		num += num2;
		num += 4;
		byte[] array = new byte[recordData.Length - num];
		Array.Copy(recordData, num, array, 0, array.Length);
		num += num2;
		byte_3 = Encoding.Unicode.GetBytes(strPassword);
		if (byte_3.Length >= 1 && byte_3 != null)
		{
			switch (num3)
			{
			default:
				throw new PptxReadException("Do not support such  keyAlgId ");
			case 26126u:
			case 26127u:
			case 26128u:
				uint_2 = num3;
				uint_0 = num5;
				uint_1 = num4;
				byte_1 = destinationArray2;
				byte_2 = array;
				byte_4 = destinationArray;
				sha1_0 = new SHA1CryptoServiceProvider();
				byte_0 = method_2(byte_3, byte_4);
				break;
			}
			return;
		}
		throw new InvalidPasswordException("The password could not be null or empty ");
	}

	public Class186(string strPassword, int keyLen)
	{
		byte_3 = Encoding.Unicode.GetBytes(strPassword);
		switch (keyLen)
		{
		default:
			throw new PptxReadException("Do not support such  key length ");
		case 256:
			uint_2 = 26128u;
			break;
		case 192:
			uint_2 = 26127u;
			break;
		case 128:
			uint_2 = 26126u;
			break;
		}
		if (byte_3.Length < 1 || byte_3 == null)
		{
			throw new InvalidPasswordException("The password could not be null or empty ");
		}
		byte_4 = Guid.NewGuid().ToByteArray();
		sha1_0 = new SHA1CryptoServiceProvider();
		byte_0 = method_2(byte_3, byte_4);
	}

	private void method_0(byte[] hashdata)
	{
		byte[] array = new byte[20];
		byte[] array2 = new byte[24];
		Array.Copy(hashdata, 0, array2, 0, hashdata.Length);
		SHA1 sHA = new SHA1CryptoServiceProvider();
		array = sHA.ComputeHash(array2);
		byte[] array3 = new byte[64];
		for (int i = 0; i < 64; i++)
		{
			array3[i] = 54;
		}
		for (int j = 0; j < 20; j++)
		{
			array3[j] ^= array[j];
		}
		byte[] array4 = new byte[64];
		for (int k = 0; k < 64; k++)
		{
			array4[k] = 92;
		}
		for (int l = 0; l < 20; l++)
		{
			array4[l] ^= array[l];
		}
		byte[] array5 = new byte[40];
		Array.Copy(sHA.ComputeHash(array3), 0, array5, 0, 20);
		Array.Copy(sHA.ComputeHash(array4), 0, array5, 20, 20);
		switch (uint_2)
		{
		case 26126u:
			byte_5 = new byte[16];
			Array.Copy(array5, 0, byte_5, 0, 16);
			class185_0 = new Class185(Class185.Enum15.const_0, byte_5, CipherMode.ECB);
			break;
		case 26127u:
			byte_5 = new byte[24];
			Array.Copy(array5, 0, byte_5, 0, 24);
			class185_0 = new Class185(Class185.Enum15.const_1, byte_5, CipherMode.ECB);
			break;
		case 26128u:
			byte_5 = new byte[24];
			Array.Copy(array5, 0, byte_5, 0, 32);
			class185_0 = new Class185(Class185.Enum15.const_2, byte_5, CipherMode.ECB);
			break;
		}
	}

	public bool method_1()
	{
		method_0(byte_0);
		byte[] array = new byte[16];
		class185_0.method_1(byte_1, array);
		byte[] array2 = sha1_0.ComputeHash(array);
		class185_0.method_1(byte_2, byte_2);
		int num = 0;
		while (true)
		{
			if (num < 14)
			{
				if (byte_2[num] != array2[num])
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

	private byte[] method_2(byte[] password, byte[] documentID)
	{
		byte[] array = new byte[20];
		byte[] array2 = new byte[password.Length + documentID.Length];
		Array.Copy(documentID, 0, array2, 0, documentID.Length);
		Array.Copy(password, 0, array2, documentID.Length, password.Length);
		array = sha1_0.ComputeHash(array2);
		array2 = new byte[24];
		byte[] array3 = new byte[4];
		for (uint num = 0u; num < 50000; num++)
		{
			array3 = BitConverter.GetBytes(num);
			Array.Copy(array3, 0, array2, 0, 4);
			Array.Copy(array, 0, array2, 4, 20);
			array = sha1_0.ComputeHash(array2);
		}
		return array;
	}

	public MemoryStream method_3(MemoryStream input)
	{
		method_0(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		byte[] array = new byte[8];
		input.Read(array, 0, 8);
		long num = BitConverter.ToInt64(array, 0);
		MemoryStream memoryStream = new MemoryStream((int)((input.Length + 15L) / 16L) * 16);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryReader.BaseStream.Seek(8L, SeekOrigin.Begin);
		byte[] array2 = new byte[16];
		for (int i = 0; i < (input.Length + 15L) / 16L; i++)
		{
			binaryReader.Read(array2, 0, 16);
			class185_0.method_1(array2, array2);
			binaryWriter.Write(array2);
		}
		binaryReader.Close();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		if (memoryStream.Length > num)
		{
			memoryStream.SetLength(num);
		}
		return memoryStream;
	}

	public MemoryStream method_4()
	{
		MemoryStream memoryStream = new MemoryStream(248);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(new byte[16]
		{
			3, 0, 2, 0, 36, 0, 0, 0, 164, 0,
			0, 0, 36, 0, 0, 0
		});
		binaryWriter.Write(new byte[16]
		{
			0,
			0,
			0,
			0,
			(byte)(uint_2 & 0xFFu),
			(byte)((uint_2 & 0xFF00) >> 8),
			0,
			0,
			4,
			128,
			0,
			0,
			128,
			0,
			0,
			0
		});
		binaryWriter.Write(new byte[16]
		{
			(byte)(uint_0 & 0xFFu),
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		}, 0, 12);
		byte[] array = new byte[16];
		binaryWriter.Write(Encoding.Unicode.GetBytes("Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype)\0"));
		method_2(byte_3, byte_4);
		byte[] array2 = new byte[16]
		{
			0, 17, 17, 34, 34, 50, 51, 67, 68, 84,
			85, 69, 36, 60, 68, 4
		};
		binaryWriter.Write(new byte[4] { 16, 0, 0, 0 }, 0, 4);
		binaryWriter.Write(byte_4);
		byte_2 = new byte[32];
		Array.Copy(sha1_0.ComputeHash(array2), byte_2, 20);
		method_0(byte_0);
		class185_0.method_0(array2, array2);
		binaryWriter.Write(array2);
		binaryWriter.Write(new byte[4] { 20, 0, 0, 0 }, 0, 4);
		byte[] array3 = new byte[16];
		Array.Copy(byte_2, array3, 16);
		class185_0.method_0(array3, array3);
		Array.Copy(array3, byte_2, 16);
		Array.Copy(byte_2, 16, array3, 0, 16);
		class185_0.method_0(array3, array3);
		Array.Copy(array3, 0, byte_2, 16, 16);
		binaryWriter.Write(byte_2);
		binaryWriter.Seek(0, SeekOrigin.Begin);
		return memoryStream;
	}

	public MemoryStream method_5(Stream input)
	{
		method_0(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		MemoryStream memoryStream = new MemoryStream((int)(input.Length / 16L) * 16 + 8);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(new byte[8]
		{
			(byte)((ulong)input.Length & 0xFFuL),
			(byte)((input.Length & 0xFF00L) >> 8),
			(byte)((input.Length & 0xFF0000L) >> 16),
			(byte)((input.Length & 0xFF000000L) >> 24),
			0,
			0,
			0,
			0
		});
		for (int i = 0; i < (input.Length + 15L) / 16L; i++)
		{
			byte[] array = new byte[16];
			binaryReader.Read(array, 0, 16);
			class185_0.method_0(array, array);
			binaryWriter.Write(array);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}
}
