using System;
using System.Text;

namespace ns183;

internal class Class5602
{
	private int int_0;

	private int[] int_1;

	private int int_2;

	private int int_3;

	private Class5602(int capacity)
	{
		int_3 = (int_0 = capacity);
		int_1 = new int[capacity];
	}

	internal static Class5602 smethod_0(int capacity)
	{
		return new Class5602(capacity);
	}

	internal int method_0()
	{
		return int_2;
	}

	internal int method_1()
	{
		return int_0;
	}

	internal void method_2()
	{
		int_2 = 0;
	}

	internal Class5602 method_3(int i)
	{
		int_1[int_2++] = i;
		return this;
	}

	internal Class5602 method_4(int[] src)
	{
		method_6(src, 0, src.Length);
		return this;
	}

	internal Class5602 method_5(int pos, int i)
	{
		int_2 = pos;
		method_3(i);
		return this;
	}

	internal Class5602 method_6(int[] src, int offset, int length)
	{
		Array.Copy(src, offset, int_1, int_2, length);
		int_2 += length;
		return this;
	}

	internal Class5602 method_7(Class5602 src)
	{
		int num = src.method_13();
		Array.Copy(src.int_1, src.int_2, int_1, int_2, num);
		src.int_2 = src.int_3 - 1;
		int_2 += num;
		return this;
	}

	internal int method_8()
	{
		return int_1[int_2++];
	}

	internal int method_9(int index)
	{
		int_2 = index;
		return method_8();
	}

	public Class5602 method_10(int[] dst, int offset, int length)
	{
		for (int i = offset; i < offset + length; i++)
		{
			dst[i] = method_8();
		}
		return this;
	}

	internal void method_11()
	{
		int_2--;
	}

	internal void method_12(int pos)
	{
		int_2 = pos;
	}

	public int method_13()
	{
		return int_3 - method_0() - 1;
	}

	public int method_14()
	{
		return method_13();
	}

	internal void method_15(int val)
	{
		int_3 = val;
		if (int_2 > int_3)
		{
			int_2 = int_3;
		}
	}

	internal int method_16()
	{
		return int_3;
	}

	internal void method_17()
	{
		int[] destinationArray = new int[int_0 - 1];
		Array.Copy(int_1, 0, destinationArray, 0, method_0());
		Array.Copy(int_1, method_0(), destinationArray, method_0() + 1, int_0 - method_0() + 1);
		int_2--;
		int_3--;
		int_0--;
		int_1 = destinationArray;
	}

	internal bool method_18()
	{
		return method_13() > 0;
	}

	public void method_19()
	{
		int_3 = int_2;
		int_2 = 0;
	}

	public static Class5602 smethod_1(int[] array, int offset, int length)
	{
		Class5602 @class = new Class5602(array.Length);
		@class.int_1 = array;
		@class.int_2 = offset;
		@class.int_3 = offset + length;
		return @class;
	}

	public int[] method_20()
	{
		return int_1;
	}

	public override string ToString()
	{
		int[] array = new int[method_13()];
		Array.Copy(int_1, method_0(), array, 0, array.Length);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < int_1.Length; i++)
		{
			stringBuilder.Append(int_1[i]);
			if (i != int_1.Length - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		return stringBuilder.ToString();
	}
}
