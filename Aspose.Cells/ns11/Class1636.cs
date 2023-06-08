using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ns11;

internal class Class1636
{
	public byte[] byte_0 = new byte[20];

	private byte[] byte_1 = new byte[20];

	private uint uint_0 = 24u;

	private uint uint_1;

	private uint uint_2 = 32772u;

	private uint uint_3 = 26126u;

	private byte[] byte_2;

	private byte[] byte_3;

	private byte[] byte_4;

	private byte[] byte_5;

	private byte[] byte_6;

	private Class1635 class1635_0;

	private SHA1 sha1_0;

	public Class1636(string string_0, byte[] byte_7, byte[] byte_8, byte[] byte_9, string string_1, uint uint_4, uint uint_5, uint uint_6, uint uint_7)
	{
		byte_4 = Encoding.Unicode.GetBytes(string_0);
		if (byte_4.Length >= 1 && byte_4 != null)
		{
			switch (uint_7)
			{
			default:
				throw new ArgumentException("Do not support such  keyAlgId ");
			case 26126u:
			case 26127u:
			case 26128u:
				uint_3 = uint_7;
				uint_0 = uint_4;
				uint_1 = uint_5;
				uint_2 = uint_6;
				byte_2 = byte_8;
				byte_3 = byte_9;
				byte_5 = byte_7;
				sha1_0 = new SHA1CryptoServiceProvider();
				byte_1 = method_2(byte_4, byte_5);
				break;
			}
			return;
		}
		throw new ArgumentException("The password could not be null or empty ");
	}

	public Class1636(string string_0, int int_0)
	{
		byte_4 = Encoding.Unicode.GetBytes(string_0);
		switch (int_0)
		{
		default:
			throw new ArgumentException("Do not support such  key length ");
		case 256:
			uint_3 = 26128u;
			break;
		case 192:
			uint_3 = 26127u;
			break;
		case 128:
			uint_3 = 26126u;
			break;
		}
		if (byte_4.Length < 1 || byte_4 == null)
		{
			throw new ArgumentException("The password could not be null or empty ");
		}
		byte_5 = Guid.NewGuid().ToByteArray();
		sha1_0 = new SHA1CryptoServiceProvider();
		byte_1 = method_2(byte_4, byte_5);
	}

	private void method_0(byte[] byte_7)
	{
		byte[] array = new byte[20];
		byte[] array2 = new byte[24];
		Array.Copy(byte_7, 0, array2, 0, byte_7.Length);
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
		switch (uint_3)
		{
		case 26126u:
			byte_6 = new byte[16];
			Array.Copy(array5, 0, byte_6, 0, 16);
			class1635_0 = new Class1635(Class1635.Enum219.const_0, byte_6, CipherMode.ECB);
			break;
		case 26127u:
			byte_6 = new byte[24];
			Array.Copy(array5, 0, byte_6, 0, 24);
			class1635_0 = new Class1635(Class1635.Enum219.const_1, byte_6, CipherMode.ECB);
			break;
		case 26128u:
			byte_6 = new byte[24];
			Array.Copy(array5, 0, byte_6, 0, 32);
			class1635_0 = new Class1635(Class1635.Enum219.const_2, byte_6, CipherMode.ECB);
			break;
		}
	}

	public bool method_1()
	{
		method_0(byte_1);
		byte[] buffer = new byte[16];
		class1635_0.method_1(byte_2, buffer);
		byte[] array = sha1_0.ComputeHash(buffer);
		class1635_0.method_1(byte_3, byte_3);
		int num = 0;
		while (true)
		{
			if (num < 14)
			{
				if (byte_3[num] != array[num])
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

	private byte[] method_2(byte[] byte_7, byte[] byte_8)
	{
		byte[] array = new byte[byte_7.Length + byte_8.Length];
		Array.Copy(byte_8, 0, array, 0, byte_8.Length);
		Array.Copy(byte_7, 0, array, byte_8.Length, byte_7.Length);
		byte_0 = sha1_0.ComputeHash(array);
		array = new byte[24];
		byte[] array2 = new byte[4];
		for (uint num = 0u; num < 50000; num++)
		{
			array2 = BitConverter.GetBytes(num);
			Array.Copy(array2, 0, array, 0, 4);
			Array.Copy(byte_0, 0, array, 4, 20);
			byte_0 = sha1_0.ComputeHash(array);
		}
		return byte_0;
	}

	public MemoryStream method_3(MemoryStream memoryStream_0)
	{
		method_0(byte_1);
		BinaryReader binaryReader = new BinaryReader(memoryStream_0);
		MemoryStream memoryStream = new MemoryStream((int)((memoryStream_0.Length + 15) / 16) * 16);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryReader.BaseStream.Seek(8L, SeekOrigin.Begin);
		byte[] buffer = new byte[16];
		for (int i = 0; i < (memoryStream_0.Length + 15) / 16; i++)
		{
			binaryReader.Read(buffer, 0, 16);
			class1635_0.method_1(buffer, buffer);
			binaryWriter.Write(buffer);
		}
		binaryReader.Close();
		memoryStream.Seek(0L, SeekOrigin.Begin);
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
			(byte)(uint_3 & 0xFFu),
			(byte)((uint_3 & 0xFF00) >> 8),
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
		method_2(byte_4, byte_5);
		byte[] buffer = new byte[16]
		{
			0, 17, 17, 34, 34, 50, 51, 67, 68, 84,
			85, 69, 36, 60, 68, 4
		};
		binaryWriter.Write(new byte[4] { 16, 0, 0, 0 }, 0, 4);
		binaryWriter.Write(byte_5);
		byte_3 = new byte[32];
		Array.Copy(sha1_0.ComputeHash(buffer), byte_3, 20);
		method_0(byte_1);
		class1635_0.method_0(buffer, buffer);
		binaryWriter.Write(buffer);
		binaryWriter.Write(new byte[4] { 20, 0, 0, 0 }, 0, 4);
		byte[] array2 = new byte[16];
		Array.Copy(byte_3, array2, 16);
		class1635_0.method_0(array2, array2);
		Array.Copy(array2, byte_3, 16);
		Array.Copy(byte_3, 16, array2, 0, 16);
		class1635_0.method_0(array2, array2);
		Array.Copy(array2, 0, byte_3, 16, 16);
		binaryWriter.Write(byte_3);
		binaryWriter.Seek(0, SeekOrigin.Begin);
		return memoryStream;
	}

	public MemoryStream method_5(MemoryStream memoryStream_0)
	{
		method_0(byte_1);
		BinaryReader binaryReader = new BinaryReader(memoryStream_0);
		MemoryStream memoryStream = new MemoryStream((int)(memoryStream_0.Length / 16) * 16 + 8);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(new byte[8]
		{
			(byte)(memoryStream_0.Length & 0xFF),
			(byte)((memoryStream_0.Length & 0xFF00) >> 8),
			(byte)((memoryStream_0.Length & 0xFF0000) >> 16),
			(byte)((memoryStream_0.Length & 0xFF000000u) >> 24),
			0,
			0,
			0,
			0
		});
		for (int i = 0; i < (memoryStream_0.Length + 15) / 16; i++)
		{
			byte[] buffer = new byte[16];
			binaryReader.Read(buffer, 0, 16);
			class1635_0.method_0(buffer, buffer);
			binaryWriter.Write(buffer);
		}
		binaryReader.Close();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}
}
