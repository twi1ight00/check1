using System;

namespace ns183;

internal class Class5707 : Interface238
{
	private int int_0;

	private char[] char_0;

	private int int_1;

	private int int_2;

	private Class5707(int capacity)
	{
		int_2 = (int_0 = capacity);
		char_0 = new char[capacity];
		int_1 = 0;
	}

	internal static Class5707 smethod_0(int capacity)
	{
		return new Class5707(capacity);
	}

	internal int method_0()
	{
		return int_1;
	}

	internal void method_1(int pos)
	{
		int_1 = pos;
	}

	internal int method_2()
	{
		return int_0;
	}

	internal void method_3()
	{
		int_1 = 0;
	}

	internal void method_4(char ch)
	{
		char_0[int_1++] = ch;
	}

	internal void method_5(int pos, char ch)
	{
		int_1 = pos;
		method_4(ch);
	}

	internal void method_6(char[] src, int offset, int length)
	{
		Array.Copy(src, offset, char_0, int_1, length);
		int_1 += length;
	}

	internal void method_7(Class5707 src)
	{
		int num = src.method_11();
		Array.Copy(src.char_0, src.int_1, char_0, int_1, num);
		src.int_1 = src.int_2 - 1;
		int_1 += num;
	}

	internal char method_8()
	{
		return char_0[int_1++];
	}

	internal char method_9(int pos)
	{
		int_1 = pos;
		return method_8();
	}

	internal void method_10()
	{
		int_1--;
	}

	public int method_11()
	{
		return int_2 - method_0();
	}

	public int imethod_0()
	{
		return method_11();
	}

	public char imethod_1(int index)
	{
		int_1 += index;
		return char_0[int_1];
	}

	Interface238 Interface238.imethod_2(int start, int end)
	{
		return method_12(start, end);
	}

	internal Class5707 method_12(int start, int end)
	{
		Class5707 @class = new Class5707(int_0);
		@class.char_0 = char_0;
		@class.int_1 = method_0() + start;
		@class.int_2 = method_0() + end;
		return @class;
	}

	internal void method_13(int val)
	{
		int_2 = val;
		if (int_1 > int_2)
		{
			int_1 = int_2;
		}
	}

	internal int method_14()
	{
		return int_2;
	}

	internal void method_15()
	{
		char[] array = new char[method_11()];
		Array.Copy(char_0, method_0(), array, 0, array.Length);
		int_1--;
		Array.Copy(array, 0, char_0, method_0(), array.Length);
		int_2--;
		int_0--;
	}

	internal bool method_16()
	{
		return method_11() > 0;
	}

	public string method_17()
	{
		return new string(char_0);
	}
}
