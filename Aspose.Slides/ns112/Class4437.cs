using System;
using System.IO;
using ns119;

namespace ns112;

internal class Class4437 : IDisposable
{
	private Stream stream_0;

	private Class4487 class4487_0;

	private long long_0;

	public Stream Stream => stream_0;

	public long Position => stream_0.Position;

	public long StreamLength => stream_0.Length;

	public bool IsOutOfStream => Position > StreamLength - 1L;

	public Class4437(Class4487 streamSource, long baseOffset)
	{
		stream_0 = streamSource.vmethod_0();
		class4487_0 = streamSource;
		long_0 = baseOffset;
		Seek(0L);
	}

	public void Seek(long position)
	{
		stream_0.Seek(position + long_0, SeekOrigin.Begin);
	}

	public byte method_0()
	{
		int num = stream_0.ReadByte();
		if (num == -1)
		{
			throw new EndOfStreamException();
		}
		return (byte)num;
	}

	public ushort method_1()
	{
		byte[] array = new byte[2];
		int num = stream_0.Read(array, 0, 2);
		if (num == 0 || num < 2)
		{
			throw new EndOfStreamException();
		}
		return (ushort)((array[0] << 8) + array[1]);
	}

	public ushort method_2()
	{
		byte[] array = new byte[2];
		int num = stream_0.Read(array, 0, 2);
		if (num == 0 || num < 2)
		{
			throw new EndOfStreamException();
		}
		return (ushort)((array[0] << 8) + array[1]);
	}

	public byte method_3()
	{
		int num = stream_0.ReadByte();
		if (num == -1)
		{
			throw new EndOfStreamException();
		}
		return (byte)num;
	}

	public int method_4(int offsetSize)
	{
		int num = 0;
		int num2 = offsetSize;
		while (num2-- > 0)
		{
			num <<= 8;
			num |= method_0();
		}
		return num;
	}

	public byte[] method_5(int bytesCount)
	{
		byte[] array = new byte[bytesCount];
		int num = Stream.Read(array, 0, bytesCount);
		if (num != bytesCount)
		{
			byte[] array2 = new byte[num];
			Array.Copy(array, array2, num);
			return array2;
		}
		return array;
	}

	void IDisposable.Dispose()
	{
		if (class4487_0.vmethod_1())
		{
			stream_0.Close();
		}
	}
}
