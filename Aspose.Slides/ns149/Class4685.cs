using System;
using System.IO;
using System.Text;

namespace ns149;

internal class Class4685 : IDisposable
{
	private Stream stream_0;

	private bool bool_0;

	public long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			stream_0.Position = value;
		}
	}

	public long StreamLength => stream_0.Length;

	public bool IsOutOfStream => Position > StreamLength - 1L;

	public Class4685(Stream stream)
		: this(stream, closeStreamOnDispose: true)
	{
	}

	public Class4685(Stream stream, bool closeStreamOnDispose)
	{
		stream_0 = stream;
		bool_0 = closeStreamOnDispose;
	}

	public void Seek(long position)
	{
		stream_0.Seek(position, SeekOrigin.Begin);
	}

	public void WriteByte(byte value)
	{
		stream_0.WriteByte(value);
	}

	public void method_0(byte value)
	{
		WriteByte(value);
	}

	public void method_1(byte[] value)
	{
		stream_0.Write(value, 0, value.Length);
	}

	public void method_2(byte[] value, int length)
	{
		stream_0.Write(value, 0, length);
	}

	public int method_3(string value)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(value);
		stream_0.Write(bytes, 0, bytes.Length);
		return bytes.Length;
	}

	public int method_4(string value, string encodingName)
	{
		byte[] bytes = Encoding.GetEncoding(encodingName).GetBytes(value);
		stream_0.Write(bytes, 0, bytes.Length);
		return bytes.Length;
	}

	public int method_5(short value)
	{
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 2;
	}

	public int method_6(ushort value)
	{
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 2;
	}

	public int method_7(int value)
	{
		stream_0.WriteByte((byte)(value >> 24));
		stream_0.WriteByte((byte)(value >> 16));
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 4;
	}

	public int method_8(uint value)
	{
		stream_0.WriteByte((byte)(value >> 24));
		stream_0.WriteByte((byte)(value >> 16));
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 4;
	}

	public int method_9(uint value)
	{
		stream_0.WriteByte((byte)(value >> 24));
		stream_0.WriteByte((byte)(value >> 16));
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 4;
	}

	public int method_10(long value)
	{
		stream_0.WriteByte((byte)(value >> 56));
		stream_0.WriteByte((byte)(value >> 48));
		stream_0.WriteByte((byte)(value >> 40));
		stream_0.WriteByte((byte)(value >> 32));
		stream_0.WriteByte((byte)(value >> 24));
		stream_0.WriteByte((byte)(value >> 16));
		stream_0.WriteByte((byte)(value >> 8));
		stream_0.WriteByte((byte)value);
		return 8;
	}

	public int method_11(float val)
	{
		method_5((short)val);
		method_5((short)((val - (float)(short)val) * 65536f));
		return 2;
	}

	public int method_12(double val)
	{
		method_5((short)Math.Round(val * 16384.0));
		return 1;
	}

	public int method_13(double val)
	{
		method_7((int)Math.Round(val * 64.0));
		return 1;
	}

	internal int method_14(DateTime date)
	{
		DateTime dateTime = new DateTime(1904, 1, 1);
		double num = (date - dateTime).TotalSeconds;
		method_10((long)num);
		return 8;
	}

	internal int method_15(short xMin)
	{
		return method_5(xMin);
	}

	internal int method_16(ushort xMin)
	{
		return method_6(xMin);
	}

	void IDisposable.Dispose()
	{
		if (bool_0)
		{
			stream_0.Close();
		}
	}
}
