using System;

namespace ns130;

internal class Class4574
{
	private byte[] byte_0;

	private int int_0;

	private bool bool_0;

	private int int_1;

	private int int_2;

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
				throw new ArgumentException("Position is out of data bounds");
			}
			int_0 = value;
			int_2 = (bool_0 ? 7 : 0);
		}
	}

	public Class4574(byte[] input, bool isReverse)
	{
		byte_0 = input;
		bool_0 = isReverse;
		int_2 = (isReverse ? 7 : 0);
	}

	public Class4574(byte[] input)
		: this(input, isReverse: false)
	{
	}

	public bool method_0()
	{
		if (!bool_0)
		{
			return method_2();
		}
		return method_3();
	}

	public int method_1(int countOfBits)
	{
		int num = 0;
		for (int num2 = countOfBits - 1; num2 >= 0; num2--)
		{
			num <<= 1;
			if (method_0())
			{
				num |= 1;
			}
		}
		return num;
	}

	private bool method_2()
	{
		int_2--;
		if (int_2 < 0)
		{
			int_1 = byte_0[int_0];
			int_0++;
			int_2 = 7;
		}
		byte b = (byte)(1 << int_2);
		return (int_1 & b) == b;
	}

	private bool method_3()
	{
		int_2++;
		if (int_2 > 7)
		{
			int_1 = byte_0[int_0];
			int_0++;
			int_2 = 0;
		}
		byte b = (byte)(1 << int_2);
		return (int_1 & b) == b;
	}
}
