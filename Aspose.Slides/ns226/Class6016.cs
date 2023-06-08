using System;
using System.IO;
using System.Text;

namespace ns226;

internal class Class6016 : Class6015
{
	private volatile bool bool_0;

	private object object_0 = new object();

	private long long_0;

	private volatile int[] int_3;

	public static Class6016 smethod_0(byte[] b)
	{
		Class6012 array = new Class6014(b);
		return new Class6016(array);
	}

	protected Class6016(Class6012 array)
		: base(array)
	{
	}

	protected Class6016(Class6016 data, int offset)
		: base(data, offset)
	{
	}

	protected Class6016(Class6016 data, int offset, int length)
		: base(data, offset, length)
	{
	}

	public override Class6015 vmethod_0(int offset, int length)
	{
		if (offset < 0 || offset + length > method_3())
		{
			throw new IndexOutOfRangeException("Attempt to bind data outside of its limits.");
		}
		return new Class6016(this, offset, length);
	}

	public override Class6015 vmethod_1(int offset)
	{
		if (offset < 0 || offset > method_3())
		{
			throw new IndexOutOfRangeException("Attempt to bind data outside of its limits.");
		}
		return new Class6016(this, offset);
	}

	public string method_6(int length)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[l=" + method_2() + ", cs=" + method_8() + "]\n");
		stringBuilder.Append(class6012_0.method_10(method_4(0), method_5(0, length)));
		return stringBuilder.ToString();
	}

	public string method_7()
	{
		return method_6(0);
	}

	public long method_8()
	{
		if (!bool_0)
		{
			method_9();
		}
		return long_0;
	}

	private void method_9()
	{
		if (bool_0)
		{
			return;
		}
		long num = 0L;
		if (int_3 == null)
		{
			num = method_10(0, method_2());
		}
		else
		{
			for (int i = 0; i < int_3.Length; i += 2)
			{
				int lowBound = int_3[i];
				int highBound = ((i == int_3.Length - 1) ? method_2() : int_3[i + 1]);
				num += method_10(lowBound, highBound);
			}
		}
		long_0 = num & 0xFFFFFFFFL;
		bool_0 = true;
	}

	private long method_10(int lowBound, int highBound)
	{
		long num = 0L;
		for (int i = lowBound; i <= highBound - 4; i += 4)
		{
			num += method_19(i);
		}
		int num2 = highBound & -4;
		if (num2 < highBound)
		{
			int num3 = method_13(num2);
			int num4 = ((num2 + 1 < highBound) ? method_13(num2 + 1) : 0);
			int num5 = ((num2 + 2 < highBound) ? method_13(num2 + 2) : 0);
			num += (num3 << 24) | (num4 << 16) | (num5 << 8) | 0;
		}
		return num;
	}

	public void method_11(int[] ranges)
	{
		if (ranges != null && ranges.Length > 0)
		{
			int_3 = new int[ranges.Length];
			Array.Copy(ranges, int_3, ranges.Length);
		}
		else
		{
			int_3 = null;
		}
		bool_0 = false;
	}

	public int[] method_12()
	{
		if (int_3 != null && int_3.Length > 0)
		{
			int[] array = new int[int_3.Length];
			Array.Copy(int_3, array, int_3.Length);
			return array;
		}
		return new int[0];
	}

	public int method_13(int index)
	{
		int num = class6012_0.method_0(method_4(index));
		if (num < 0)
		{
			throw new IndexOutOfRangeException("Index attempted to be read from is out of bounds: " + $"{index:x}");
		}
		return num;
	}

	public int ReadByte(int index)
	{
		int num = class6012_0.method_0(method_4(index));
		if (num < 0)
		{
			throw new IndexOutOfRangeException("Index attempted to be read from is out of bounds: " + $"{index:x}");
		}
		return num << 24 >> 24;
	}

	public int method_14(int index, byte[] b, int offset, int length)
	{
		return class6012_0.method_2(method_4(index), b, offset, method_5(index, length));
	}

	public int method_15(int index)
	{
		return method_13(index);
	}

	public int method_16(int index)
	{
		return 0xFFFF & ((method_13(index) << 8) | method_13(index + 1));
	}

	public int method_17(int index)
	{
		return ((ReadByte(index) << 8) | method_13(index + 1)) << 16 >> 16;
	}

	public int method_18(int index)
	{
		return 0xFFFFFF & ((method_13(index) << 16) | (method_13(index + 1) << 8) | method_13(index + 2));
	}

	public long method_19(int index)
	{
		return 0xFFFFFFFFL & ((method_13(index) << 24) | (method_13(index + 1) << 16) | (method_13(index + 2) << 8) | method_13(index + 3));
	}

	public int method_20(int index)
	{
		long num = method_19(index);
		if ((num & 0x80000000L) == 2147483648L)
		{
			throw new ArithmeticException("Long value too large to fit into an integer.");
		}
		return (int)num;
	}

	public long method_21(int index)
	{
		return 0xFFFFFFFFL & (method_13(index) | (method_13(index + 1) << 8) | (method_13(index + 2) << 16) | (method_13(index + 3) << 24));
	}

	public int method_22(int index)
	{
		return (ReadByte(index) << 24) | (method_13(index + 1) << 16) | (method_13(index + 2) << 8) | method_13(index + 3);
	}

	public int method_23(int index)
	{
		return method_22(index);
	}

	public long method_24(int index)
	{
		return (method_19(index) << 32) | method_19(index + 4);
	}

	public int method_25(int index)
	{
		throw new NotSupportedException();
	}

	public int method_26(int index)
	{
		return method_17(index);
	}

	public int method_27(int index)
	{
		return method_16(index);
	}

	public int CopyTo(StreamWriter os)
	{
		return class6012_0.CopyTo(os, method_4(0), method_2());
	}

	public int CopyTo(Class6017 wfd)
	{
		return class6012_0.CopyTo(wfd.method_4(0), wfd.class6012_0, method_4(0), method_2());
	}

	public int method_28(int startIndex, int startOffset, int endIndex, int endOffset, int length, int key)
	{
		int num = 0;
		int num2 = 0;
		int num3 = length;
		while (true)
		{
			if (num3 != num2)
			{
				num = (num3 + num2) / 2;
				int num4 = method_16(startIndex + num * startOffset);
				if (key < num4)
				{
					num3 = num;
					continue;
				}
				int num5 = method_16(endIndex + num * endOffset);
				if (key <= num5)
				{
					break;
				}
				num2 = num + 1;
				continue;
			}
			return -1;
		}
		return num;
	}

	public int method_29(int startIndex, int startOffset, int endIndex, int endOffset, int length, int key)
	{
		int num = 0;
		int num2 = 0;
		int num3 = length;
		while (true)
		{
			if (num3 != num2)
			{
				num = (num3 + num2) / 2;
				int num4 = method_20(startIndex + num * startOffset);
				if (key < num4)
				{
					num3 = num;
					continue;
				}
				int num5 = method_20(endIndex + num * endOffset);
				if (key <= num5)
				{
					break;
				}
				num2 = num + 1;
				continue;
			}
			return -1;
		}
		return num;
	}

	public int method_30(int startIndex, int startOffset, int length, int key)
	{
		int num = 0;
		int num2 = 0;
		int num3 = length;
		while (true)
		{
			if (num3 != num2)
			{
				num = (num3 + num2) / 2;
				int num4 = method_16(startIndex + num * startOffset);
				if (key < num4)
				{
					num3 = num;
					continue;
				}
				if (key <= num4)
				{
					break;
				}
				num2 = num + 1;
				continue;
			}
			return -1;
		}
		return num;
	}
}
