using System.Runtime.CompilerServices;

namespace ns14;

internal class Class511
{
	private double double_0 = 1.0;

	private byte byte_0;

	private byte byte_1 = byte.MaxValue;

	private byte byte_2 = byte.MaxValue;

	private byte byte_3 = 3;

	[SpecialName]
	internal double method_0()
	{
		return double_0;
	}

	[SpecialName]
	internal void method_1(double double_1)
	{
		double_0 = double_1;
	}

	[SpecialName]
	internal int method_2()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_3(int int_0)
	{
		byte_0 = (byte)int_0;
	}

	[SpecialName]
	internal int method_4()
	{
		if (byte_1 != byte.MaxValue)
		{
			return byte_1;
		}
		return -1;
	}

	[SpecialName]
	internal void method_5(int int_0)
	{
		byte_1 = (byte)int_0;
	}

	[SpecialName]
	internal bool method_6()
	{
		return method_12(4);
	}

	[SpecialName]
	internal void method_7(bool bool_0)
	{
		method_13(4, bool_0);
	}

	[SpecialName]
	internal int method_8()
	{
		if (byte_2 != byte.MaxValue)
		{
			return byte_2;
		}
		return -1;
	}

	[SpecialName]
	internal void method_9(int int_0)
	{
		byte_2 = (byte)int_0;
	}

	[SpecialName]
	internal void method_10(bool bool_0)
	{
		method_13(1, bool_0);
	}

	[SpecialName]
	internal void method_11(bool bool_0)
	{
		method_13(2, bool_0);
	}

	private bool method_12(int int_0)
	{
		return (byte_3 & int_0) != 0;
	}

	private void method_13(int int_0, bool bool_0)
	{
		if (bool_0)
		{
			byte_3 |= (byte)int_0;
		}
		else
		{
			byte_3 &= (byte)(~int_0);
		}
	}
}
