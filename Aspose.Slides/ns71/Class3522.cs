using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns71;

internal static class Class3522
{
	public static ushort smethod_0(BinaryReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		ushort result = reader.ReadUInt16();
		reader.BaseStream.Seek(-2L, SeekOrigin.Current);
		return result;
	}

	public static byte smethod_1(BinaryReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		byte result = reader.ReadByte();
		reader.BaseStream.Seek(-1L, SeekOrigin.Current);
		return result;
	}

	public static string smethod_2(BinaryReader reader, int size, int codePage)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		return Class3524.smethod_1(reader.ReadBytes(size), codePage);
	}

	public static string smethod_3(BinaryReader reader, int size, Encoding encoding)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		return Class3524.smethod_0(reader.ReadBytes(size), encoding);
	}

	public static byte[] smethod_4(BinaryReader reader, byte mark)
	{
		List<byte> list = new List<byte>();
		for (byte b = reader.ReadByte(); b != mark; b = reader.ReadByte())
		{
			list.Add(b);
		}
		return list.ToArray();
	}
}
