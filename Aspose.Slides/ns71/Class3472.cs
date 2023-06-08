using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns71;

internal class Class3472
{
	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte[] byte_3;

	private byte[] byte_4;

	private byte[] byte_5;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private readonly byte[] byte_9;

	private Guid guid_0;

	public byte Seed
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte VersionEnc
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public byte ProjKeyEnc
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte[] IgnoredEnc
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	public byte[] DataLengthEnc
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public byte[] DataEnc
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	public byte[] Data => byte_9;

	public Class3472(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		using BinaryReader binaryReader = new BinaryReader(input);
		byte_0 = binaryReader.ReadByte();
		byte_1 = binaryReader.ReadByte();
		byte_2 = binaryReader.ReadByte();
		byte projectKey = (byte)(byte_0 ^ byte_2);
		method_2(projectKey);
		int count = (byte_0 & 6) / 2;
		byte_3 = binaryReader.ReadBytes(count);
		method_7();
		byte_4 = binaryReader.ReadBytes(4);
		uint count2 = method_8();
		byte_5 = binaryReader.ReadBytes((int)count2);
		byte_9 = method_9();
	}

	public Class3472(Guid projectId, uint length, byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		guid_0 = projectId;
		byte_9 = data;
		Encrypt(length);
	}

	public void method_0(BinaryWriter writer)
	{
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(byte_3);
		writer.Write(byte_4);
		writer.Write(byte_5);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0:x2}", byte_0);
		stringBuilder.AppendFormat("{0:x2}", byte_1);
		stringBuilder.AppendFormat("{0:x2}", byte_2);
		byte[] array = byte_3;
		foreach (byte b in array)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		byte[] array2 = byte_4;
		foreach (byte b2 in array2)
		{
			stringBuilder.AppendFormat("{0:x2}", b2);
		}
		byte[] array3 = byte_5;
		foreach (byte b3 in array3)
		{
			stringBuilder.AppendFormat("{0:x2}", b3);
		}
		return stringBuilder.ToString().ToUpper();
	}

	public byte[] method_1()
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (BinaryWriter writer = new BinaryWriter(memoryStream))
		{
			method_0(writer);
		}
		return memoryStream.ToArray();
	}

	private void method_2(byte projectKey)
	{
		byte_6 = projectKey;
		byte_7 = byte_2;
		byte_8 = byte_1;
	}

	private byte method_3()
	{
		byte b = 0;
		string text = guid_0.ToString("B").ToUpper();
		string text2 = text;
		foreach (char c in text2)
		{
			b = (byte)(b + (byte)(c & 0xFF));
		}
		return b;
	}

	private static byte smethod_0()
	{
		return (byte)((uint)DateTime.Now.Ticks.GetHashCode() & 0xFFu);
	}

	private void method_4()
	{
		byte b = (byte)((byte_0 & 6) / 2);
		List<byte> list = new List<byte>(b);
		Random random = new Random(byte_0);
		for (int i = 1; i <= b; i++)
		{
			byte b2 = (byte)((uint)random.Next(0, 255) & 0xFFu);
			byte item = (byte)(b2 ^ (byte_8 + byte_6));
			list.Add(item);
			byte_8 = byte_7;
			byte_7 = item;
			byte_6 = b2;
		}
		byte_3 = list.ToArray();
	}

	private void method_5(uint length)
	{
		byte[] array = new byte[4]
		{
			(byte)length,
			(byte)((length >> 8) & 0xFFu),
			(byte)((length >> 16) & 0xFFu),
			(byte)((length >> 24) & 0xFFu)
		};
		List<byte> list = new List<byte>(4);
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			byte item = (byte)(b ^ (byte_8 + byte_6));
			list.Add(item);
			byte_8 = byte_7;
			byte_7 = item;
			byte_6 = b;
		}
		byte_4 = list.ToArray();
	}

	private void method_6()
	{
		List<byte> list = new List<byte>(4);
		byte[] array = byte_9;
		foreach (byte b in array)
		{
			byte item = (byte)(b ^ (byte_8 + byte_6));
			list.Add(item);
			byte_8 = byte_7;
			byte_7 = item;
			byte_6 = b;
		}
		byte_5 = list.ToArray();
	}

	private void Encrypt(uint length)
	{
		byte b = method_3();
		byte_0 = smethod_0();
		byte_1 = (byte)(byte_0 ^ 2u);
		byte_2 = (byte)(byte_0 ^ b);
		method_2(b);
		method_4();
		method_5(length);
		method_6();
	}

	private void method_7()
	{
		for (int i = 0; i < byte_3.Length; i++)
		{
			byte b = (byte)(byte_3[i] ^ (byte_8 + byte_6));
			byte_8 = byte_7;
			byte_7 = byte_3[i];
			byte_6 = b;
		}
	}

	private uint method_8()
	{
		uint num = 0u;
		uint num2 = 0u;
		byte[] array = byte_4;
		foreach (byte b in array)
		{
			byte b2 = (byte)(b ^ (byte_8 + byte_6));
			byte b3 = (byte)Math.Pow(256.0, num2);
			b3 = (byte)(b3 * b2);
			num += b3;
			byte_8 = byte_7;
			byte_7 = b;
			byte_6 = b2;
			num2++;
		}
		return num;
	}

	private byte[] method_9()
	{
		List<byte> list = new List<byte>();
		byte[] array = byte_5;
		foreach (byte b in array)
		{
			byte item = (byte)(b ^ (byte_8 + byte_6));
			list.Add(item);
			byte_8 = byte_7;
			byte_7 = b;
			byte_6 = item;
		}
		return list.ToArray();
	}
}
