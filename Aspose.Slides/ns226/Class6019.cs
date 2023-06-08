using System;
using System.IO;

namespace ns226;

internal class Class6019
{
	private StreamWriter streamWriter_0;

	public StreamWriter Out => streamWriter_0;

	public Class6019(StreamWriter os)
	{
		streamWriter_0 = os;
	}

	public long method_0()
	{
		return streamWriter_0.BaseStream.Position;
	}

	public void Write(int b)
	{
		streamWriter_0.BaseStream.WriteByte((byte)b);
	}

	public void Write(byte[] b)
	{
		Write(b, 0, b.Length);
	}

	public void Write(byte[] b, int off, int len)
	{
		if (off < 0 || len < 0 || off + len < 0 || off + len > b.Length)
		{
			throw new IndexOutOfRangeException();
		}
		streamWriter_0.BaseStream.Write(b, off, len);
	}

	public void method_1(byte c)
	{
		Write(c);
	}

	public void method_2(int us)
	{
		Write((byte)((us >> 8) & 0xFF));
		Write((byte)(us & 0xFF));
	}

	public void method_3(int s)
	{
		method_2(s);
	}

	public void method_4(int ui)
	{
		Write((byte)((ui >> 16) & 0xFF));
		Write((byte)((ui >> 8) & 0xFF));
		Write((byte)(ui & 0xFF));
	}

	public void method_5(long ul)
	{
		Write((byte)((ul >> 24) & 0xFFL));
		Write((byte)((ul >> 16) & 0xFFL));
		Write((byte)((ul >> 8) & 0xFFL));
		Write((byte)(ul & 0xFFL));
	}

	public void method_6(long l)
	{
		method_5(l);
	}

	public void method_7(int f)
	{
		method_5(f);
	}

	public void method_8(long date)
	{
		method_5((date >> 32) & 0xFFFFFFFFL);
		method_5(date & 0xFFFFFFFFL);
	}
}
