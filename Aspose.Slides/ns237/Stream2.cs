using System;
using System.IO;
using ns223;

namespace ns237;

internal class Stream2 : Stream1
{
	private readonly Class5985 class5985_0;

	private readonly byte[] byte_0;

	public Stream2(Stream outputStream, byte[] key)
		: this(outputStream, key, 0, key.Length)
	{
	}

	public Stream2(Stream outputStream, byte[] key, int offset, int length)
		: base(outputStream)
	{
		byte_0 = new byte[1];
		class5985_0 = new Class5985();
		class5985_0.method_5(key, offset, length);
	}

	public override void Write(byte[] b, int offset, int length)
	{
		byte[] array = new byte[Math.Min(length, 4192)];
		while (length > 0)
		{
			int num = Math.Min(length, array.Length);
			class5985_0.method_3(b, offset, num, array, 0);
			stream_0.Write(array, 0, num);
			length -= num;
			offset += num;
		}
	}

	public override void WriteByte(byte value)
	{
		byte_0[0] = value;
		Write(byte_0, 0, 1);
	}
}
