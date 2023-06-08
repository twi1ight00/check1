using System;
using System.IO;

namespace ns226;

internal class Class6018
{
	private long long_0;

	private bool bool_0;

	private StreamReader streamReader_0;

	public StreamReader Is => streamReader_0;

	public Class6018(StreamReader @is)
	{
		streamReader_0 = @is;
	}

	public Class6018(StreamReader @is, int length)
		: this(@is)
	{
		long_0 = length;
		bool_0 = true;
	}

	public Class6018(Class6018 fis, int length)
		: this(fis.Is)
	{
		long_0 = length;
		bool_0 = true;
	}

	public int Read()
	{
		if (bool_0 && streamReader_0.BaseStream.Position >= long_0)
		{
			return -1;
		}
		return (byte)Is.BaseStream.ReadByte();
	}

	public int Read(byte[] b, int off, int len)
	{
		if (bool_0 && streamReader_0.BaseStream.Position >= long_0)
		{
			return -1;
		}
		int count = (int)(bool_0 ? Math.Min(len, long_0 - streamReader_0.BaseStream.Position) : len);
		return Is.BaseStream.Read(b, off, count);
	}

	public int Read(byte[] b)
	{
		return Read(b, 0, b.Length);
	}

	public long method_0()
	{
		return streamReader_0.BaseStream.Position;
	}

	public int method_1()
	{
		return Read();
	}

	public int method_2()
	{
		return 0xFFFF & ((Read() << 8) | Read());
	}

	public int method_3()
	{
		return ((Read() << 8) | Read()) << 16 >> 16;
	}

	public int method_4()
	{
		return 0xFFFFFF & ((Read() << 16) | (Read() << 8) | Read());
	}

	public long method_5()
	{
		return 0xFFFFFFFFL & method_7();
	}

	public int method_6()
	{
		long num = method_5();
		if ((num & 0x80000000L) == 2147483648L)
		{
			throw new ArithmeticException("Long value too large to fit into an integer.");
		}
		return (int)((int)num & 0x7FFFFFFFL);
	}

	public int method_7()
	{
		return (Read() << 24) | (Read() << 16) | (Read() << 8) | Read();
	}

	public int method_8()
	{
		return method_7();
	}

	public long method_9()
	{
		return (method_5() << 32) | method_5();
	}

	public long method_10(long n)
	{
		Is.BaseStream.Position += n;
		return n;
	}
}
