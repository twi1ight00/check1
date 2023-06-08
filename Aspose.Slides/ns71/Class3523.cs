using System;
using System.IO;
using System.Text;

namespace ns71;

internal static class Class3523
{
	public static void smethod_0(BinaryWriter writer, string value, Encoding encoding)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		byte[] bytes = encoding.GetBytes(value);
		if (bytes.Length > 0)
		{
			writer.Write(bytes);
		}
	}

	public static void smethod_1(BinaryWriter writer, string value, int codePage)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		Encoding encoding = Encoding.GetEncoding(codePage);
		smethod_0(writer, value, encoding);
	}

	public static void smethod_2(BinaryWriter writer, string value, Encoding encoding)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		byte[] bytes = encoding.GetBytes(value);
		writer.Write((uint)bytes.Length);
		if (bytes.Length > 0)
		{
			writer.Write(bytes);
		}
	}

	public static void smethod_3(BinaryWriter writer, string value, int codePage)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		Encoding encoding = Encoding.GetEncoding(codePage);
		smethod_2(writer, value, encoding);
	}
}
