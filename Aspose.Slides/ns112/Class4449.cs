using System;
using System.IO;

namespace ns112;

internal class Class4449 : IDisposable
{
	private Stream stream_0;

	private bool bool_0;

	public long Position => stream_0.Position;

	public long StreamLength => stream_0.Length;

	public bool IsOutOfStream => Position > StreamLength - 1L;

	public Class4449(Stream stream)
		: this(stream, closeStreamOnDispose: true)
	{
	}

	public Class4449(Stream stream, bool closeStreamOnDispose)
	{
		stream_0 = stream;
		bool_0 = closeStreamOnDispose;
	}

	public void Seek(long position)
	{
		stream_0.Seek(position, SeekOrigin.Begin);
	}

	public void method_0(byte value)
	{
		stream_0.WriteByte(value);
	}

	public void method_1(ushort value)
	{
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
	}

	public void method_2(ushort value)
	{
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
	}

	public void method_3(byte value)
	{
		stream_0.WriteByte(value);
	}

	public void method_4(int offsetSize, int value)
	{
		int num = offsetSize;
		while (num-- > 0)
		{
			stream_0.WriteByte((byte)(value >> 8 * (num + 1)));
		}
	}

	public void method_5(byte[] value)
	{
		stream_0.Write(value, 0, value.Length);
	}

	void IDisposable.Dispose()
	{
		if (bool_0)
		{
			stream_0.Close();
		}
	}
}
