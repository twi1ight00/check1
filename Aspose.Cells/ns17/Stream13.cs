using System;
using System.IO;
using ns22;

namespace ns17;

internal class Stream13 : Stream
{
	private long long_0;

	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	public override bool CanRead => !bool_3;

	public override bool CanSeek => !bool_3;

	public override bool CanWrite
	{
		get
		{
			if (bool_1)
			{
				return !bool_3;
			}
			return false;
		}
	}

	public override long Length
	{
		get
		{
			method_0();
			return int_3 - int_0;
		}
	}

	public override long Position
	{
		get
		{
			method_0();
			return long_0 + int_2 - int_0;
		}
		set
		{
			method_0();
			if (value >= 0 && value <= int.MaxValue)
			{
				try
				{
					int_2 = int_0 + (int)value;
					return;
				}
				catch (OverflowException)
				{
					throw new IOException("IO_InvalidSeekPosition");
				}
			}
			throw new IOException("IO_InvalidSeekPosition");
		}
	}

	public Stream13()
		: this(0)
	{
	}

	[Attribute0(true)]
	public Stream13(int int_4)
	{
		if (int_4 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "ArgRange_NonNegative");
		}
		byte_0 = new byte[int_4];
		int_0 = 0;
		int_1 = int_4;
		int_2 = 0;
		int_3 = 0;
		bool_0 = true;
		bool_1 = true;
		bool_2 = true;
		bool_3 = false;
	}

	public override void Close()
	{
		bool_3 = true;
	}

	public override void Flush()
	{
	}

	[Attribute0(true)]
	private void method_0()
	{
		if (bool_3)
		{
			throw new IOException("IO_StreamClosed");
		}
	}

	[Attribute0(true)]
	private void method_1()
	{
		if (bool_3)
		{
			throw new IOException("IO_StreamClosed");
		}
		if (!bool_1)
		{
			throw new IOException("IO_NotSupp_Write");
		}
	}

	[Attribute0(true)]
	private void method_2(int int_4)
	{
		if (!bool_0)
		{
			throw new IOException("IO_FixedCapacity");
		}
		int_4 -= int_0;
		if (int_4 < 256)
		{
			int_4 = 256;
		}
		if (int_4 < (int_1 - int_0) * 2)
		{
			int_4 = (int_1 - int_0) * 2;
		}
		byte[] destinationArray = new byte[int_4];
		if (int_3 > int_0)
		{
			Array.Copy(byte_0, int_0, destinationArray, 0, int_3 - int_0);
		}
		byte_0 = destinationArray;
		int_1 = int_4;
		int_2 -= int_0;
		int_3 -= int_0;
		int_0 = 0;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		method_0();
		int num = int_3 - int_2;
		if (num > count)
		{
			num = count;
		}
		if (num <= 0)
		{
			return 0;
		}
		Array.Copy(byte_0, int_2, buffer, offset, num);
		int_2 += num;
		return num;
	}

	[Attribute0(true)]
	public override int ReadByte()
	{
		if (!bool_3)
		{
			if (int_2 < int_3)
			{
				return byte_0[int_2++];
			}
			return -1;
		}
		throw new IOException("IO_StreamClosed");
	}

	[Attribute0(true)]
	public override long Seek(long offset, SeekOrigin origin)
	{
		method_0();
		if (offset > int.MaxValue)
		{
			throw new IOException("IO_InvalidSeekPosition");
		}
		switch (origin)
		{
		case SeekOrigin.Begin:
			if (offset < 0)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			try
			{
				int_2 = int_0 + (int)offset;
			}
			catch (OverflowException)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			break;
		case SeekOrigin.Current:
			if (offset + int_2 < int_0)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			try
			{
				int_2 += (int)offset;
			}
			catch (OverflowException)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			break;
		case SeekOrigin.End:
			if (offset + int_3 < int_0)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			try
			{
				int_2 = int_3 + (int)offset;
			}
			catch (OverflowException)
			{
				throw new IOException("IO_InvalidSeekPosition");
			}
			break;
		default:
			throw new ArgumentException("IO_InvalidWhence");
		}
		return int_2;
	}

	[Attribute0(true)]
	public override void SetLength(long value)
	{
		if (!bool_3 && bool_1)
		{
			if (value >= 0 && value <= int.MaxValue - int_0)
			{
				int num = int_0 + (int)value;
				if (num > int_1)
				{
					method_2(num);
				}
				else if (num > int_3)
				{
					Array.Clear(byte_0, int_3, num - int_3);
				}
				int_3 = num;
				if (int_2 > num)
				{
					int_2 = num;
				}
				return;
			}
			throw new IOException("IO_InvalidLength");
		}
		throw new IOException("IO_NotSupp_SetLength");
	}

	[Attribute0(true)]
	public override void Write(byte[] buffer, int offset, int count)
	{
		method_1();
		int num = int_2 + count;
		if (num < 0)
		{
			throw new IOException("IO_WriteFailed");
		}
		if (num > int_3)
		{
			if (num > int_1)
			{
				method_2(num);
			}
			else if (int_2 > int_3)
			{
				Array.Clear(byte_0, int_3, int_2 - int_3);
			}
			int_3 = num;
		}
		Array.Copy(buffer, offset, byte_0, int_2, count);
		int_2 = num;
	}

	[Attribute0(true)]
	public override void WriteByte(byte value)
	{
		method_1();
		if (int_2 == int.MaxValue)
		{
			throw new IOException("IO_WriteFailed");
		}
		if (int_2 >= int_3)
		{
			if (int_2 >= int_1)
			{
				method_2(int_2 + 1);
			}
			else if (int_2 > int_3)
			{
				Array.Clear(byte_0, int_3, int_2 - int_3);
			}
			int_3 = int_2 + 1;
		}
		byte_0[int_2++] = value;
	}

	public virtual void vmethod_0(Stream stream_0)
	{
		method_0();
		if (stream_0 == null)
		{
			throw new IOException("stream");
		}
		stream_0.Write(byte_0, int_0, int_3 - int_0);
	}

	public void method_3()
	{
		long_0 += Length;
		int_0 = 0;
		int_2 = 0;
		int_3 = 0;
	}
}
