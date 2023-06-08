using System;

namespace ns130;

internal class Class4572
{
	private int int_0;

	private byte[] byte_0;

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
				throw new ArgumentException("Position is out of input bounds");
			}
			int_0 = value;
		}
	}

	public int InputLength => byte_0.Length;

	public Class4572(byte[] input)
	{
		byte_0 = input;
	}

	public long method_0()
	{
		long num = method_1();
		num <<= 32;
		return num | method_1();
	}

	public uint method_1()
	{
		uint num = method_3();
		num <<= 16;
		return num | method_3();
	}

	public int method_2()
	{
		int result = (byte_0[int_0] << 24) | (byte_0[int_0 + 1] << 16) | (byte_0[int_0 + 2] << 8) | byte_0[int_0 + 3];
		int_0 += 4;
		return result;
	}

	public ushort method_3()
	{
		ushort result = (ushort)((byte_0[int_0] << 8) | byte_0[int_0 + 1]);
		int_0 += 2;
		return result;
	}

	public short method_4()
	{
		short result = (short)((byte_0[int_0] << 8) | byte_0[int_0 + 1]);
		int_0 += 2;
		return result;
	}

	public byte ReadByte()
	{
		byte result = byte_0[int_0];
		int_0++;
		return result;
	}
}
