using System;

namespace ns130;

internal class Class4573
{
	private byte[] byte_0;

	private int int_0;

	public int Position
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Position cannot be less than zero");
			}
			if (value > byte_0.Length)
			{
				throw new ArgumentException("Position is out of output bounds");
			}
			int_0 = value;
		}
	}

	public int OutputLength => byte_0.Length;

	public Class4573(byte[] output)
	{
		byte_0 = output;
	}

	public void Write(int value)
	{
		byte_0[int_0] = (byte)((uint)(value >> 24) & 0xFFu);
		byte_0[int_0 + 1] = (byte)((uint)(value >> 16) & 0xFFu);
		byte_0[int_0 + 2] = (byte)((uint)(value >> 8) & 0xFFu);
		byte_0[int_0 + 3] = (byte)((uint)value & 0xFFu);
		int_0 += 4;
	}

	public void Write(uint value)
	{
		byte_0[int_0] = (byte)((value >> 24) & 0xFFu);
		byte_0[int_0 + 1] = (byte)((value >> 16) & 0xFFu);
		byte_0[int_0 + 2] = (byte)((value >> 8) & 0xFFu);
		byte_0[int_0 + 3] = (byte)(value & 0xFFu);
		int_0 += 4;
	}

	public void Write(short value)
	{
		byte_0[int_0] = (byte)((uint)(value >> 8) & 0xFFu);
		byte_0[int_0 + 1] = (byte)((uint)value & 0xFFu);
		int_0 += 2;
	}

	public void method_0(ushort value)
	{
		byte_0[int_0] = (byte)((uint)(value >> 8) & 0xFFu);
		byte_0[int_0 + 1] = (byte)(value & 0xFFu);
		int_0 += 2;
	}

	public void Write(byte value)
	{
		byte_0[int_0] = value;
		int_0++;
	}
}
