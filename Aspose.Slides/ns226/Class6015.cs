using System;

namespace ns226;

internal abstract class Class6015
{
	public enum Enum749
	{
		const_0 = 1,
		const_1 = 1,
		const_2 = 2,
		const_3 = 2,
		const_4 = 3,
		const_5 = 4,
		const_6 = 4,
		const_7 = 4,
		const_8 = 4,
		const_9 = 2,
		const_10 = 2,
		const_11 = 2,
		const_12 = 8,
		const_13 = 4,
		const_14 = 2,
		const_15 = 2
	}

	protected static int int_0 = int.MaxValue;

	internal Class6012 class6012_0;

	private int int_1;

	private int int_2 = int_0;

	protected Class6015(Class6012 ba)
	{
		ba.method_3();
		class6012_0 = ba;
	}

	protected Class6015(Class6015 data, int offset, int length)
		: this(data.class6012_0)
	{
		method_0(data.int_1 + offset, length);
	}

	protected Class6015(Class6015 data, int offset)
		: this(data.class6012_0)
	{
		method_0(data.int_1 + offset, (data.int_2 == int_0) ? int_0 : (data.int_2 - offset));
	}

	public bool method_0(int offset, int length)
	{
		if (offset + length <= method_3() && offset >= 0 && length >= 0)
		{
			int_1 += offset;
			int_2 = length;
			return true;
		}
		return false;
	}

	public bool method_1(int offset)
	{
		if (offset <= method_3() && offset >= 0)
		{
			int_1 += offset;
			return true;
		}
		return false;
	}

	public abstract Class6015 vmethod_0(int offset, int length);

	public abstract Class6015 vmethod_1(int offset);

	public int method_2()
	{
		return Math.Min(class6012_0.method_3() - int_1, int_2);
	}

	public int method_3()
	{
		return Math.Min(class6012_0.method_4() - int_1, int_2);
	}

	protected int method_4(int offset)
	{
		return offset + int_1;
	}

	protected int method_5(int offset, int length)
	{
		return Math.Min(length, int_2 - offset);
	}
}
