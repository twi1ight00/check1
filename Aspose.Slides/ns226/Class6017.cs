using System;
using System.IO;

namespace ns226;

internal class Class6017 : Class6016
{
	public static Class6017 smethod_1(int length)
	{
		Class6012 @class = null;
		if (length > 0)
		{
			@class = new Class6014(length);
			@class.method_6(length);
		}
		else
		{
			@class = new Class6013();
		}
		return new Class6017(@class);
	}

	public static Class6017 smethod_2(byte[] b)
	{
		Class6012 array = new Class6014(b);
		return new Class6017(array);
	}

	public static Class6017 smethod_3(Class6016 original)
	{
		Class6012 @class = null;
		@class = ((!original.class6012_0.method_5()) ? ((Class6012)new Class6014(original.class6012_0.method_3())) : ((Class6012)new Class6013()));
		original.class6012_0.CopyTo(@class);
		Class6017 class2 = new Class6017(@class);
		class2.method_11(original.method_12());
		return class2;
	}

	private Class6017(Class6012 array)
		: base(array)
	{
	}

	private Class6017(Class6017 data, int offset)
		: base(data, offset)
	{
	}

	private Class6017(Class6017 data, int offset, int length)
		: base(data, offset, length)
	{
	}

	public override Class6015 vmethod_0(int offset, int length)
	{
		if (offset < 0 || offset + length > method_3())
		{
			throw new IndexOutOfRangeException("Attempt to bind data outside of its limits.");
		}
		return new Class6017(this, offset, length);
	}

	public override Class6015 vmethod_1(int offset)
	{
		if (offset < 0 || offset > method_3())
		{
			throw new IndexOutOfRangeException("Attempt to bind data outside of its limits.");
		}
		return new Class6017(this, offset);
	}

	public int WriteByte(int index, byte b)
	{
		class6012_0.method_7(method_4(index), b);
		return 1;
	}

	public int method_31(int index, byte[] b, int offset, int length)
	{
		return class6012_0.method_9(method_4(index), b, offset, method_5(index, length));
	}

	public int method_32(int index, byte[] b, int offset, int length, byte pad)
	{
		int num = class6012_0.method_9(method_4(index), b, offset, method_5(index, Math.Min(length, b.Length - offset)));
		return num + method_34(num + index, length - num, pad);
	}

	public int method_33(int index, int count)
	{
		return method_34(index, count, 0);
	}

	public int method_34(int index, int count, byte pad)
	{
		for (int i = 0; i < count; i++)
		{
			class6012_0.method_7(index + i, pad);
		}
		return count;
	}

	public int method_35(int index, byte[] b)
	{
		return method_31(index, b, 0, b.Length);
	}

	public int method_36(int index, byte c)
	{
		return WriteByte(index, c);
	}

	public int method_37(int index, int us)
	{
		WriteByte(index, (byte)((uint)(us >> 8) & 0xFFu));
		WriteByte(index + 1, (byte)((uint)us & 0xFFu));
		return 2;
	}

	public int method_38(int index, int us)
	{
		class6012_0.method_7(index, (byte)((uint)us & 0xFFu));
		class6012_0.method_7(index + 1, (byte)((uint)(us >> 8) & 0xFFu));
		return 2;
	}

	public int method_39(int index, int s)
	{
		return method_37(index, s);
	}

	public int method_40(int index, int ui)
	{
		WriteByte(index, (byte)((uint)(ui >> 16) & 0xFFu));
		WriteByte(index + 1, (byte)((uint)(ui >> 8) & 0xFFu));
		WriteByte(index + 2, (byte)((uint)ui & 0xFFu));
		return 3;
	}

	public int method_41(int index, long ul)
	{
		WriteByte(index, (byte)((ulong)(ul >> 24) & 0xFFuL));
		WriteByte(index + 1, (byte)((ulong)(ul >> 16) & 0xFFuL));
		WriteByte(index + 2, (byte)((ulong)(ul >> 8) & 0xFFuL));
		WriteByte(index + 3, (byte)((ulong)ul & 0xFFuL));
		return 4;
	}

	public int method_42(int index, long ul)
	{
		class6012_0.method_7(index, (byte)((ulong)ul & 0xFFuL));
		class6012_0.method_7(index + 1, (byte)((ulong)(ul >> 8) & 0xFFuL));
		class6012_0.method_7(index + 2, (byte)((ulong)(ul >> 16) & 0xFFuL));
		class6012_0.method_7(index + 3, (byte)((ulong)(ul >> 24) & 0xFFuL));
		return 4;
	}

	public int method_43(int index, long l)
	{
		return method_41(index, l);
	}

	public int method_44(int index, int f)
	{
		return method_43(index, f);
	}

	public int method_45(int index, long date)
	{
		method_41(index, (date >> 32) & 0xFFFFFFFFL);
		method_41(index + 4, date & 0xFFFFFFFFL);
		return 8;
	}

	public void CopyFrom(StreamReader @is, int length)
	{
		class6012_0.CopyFrom(@is, length);
	}

	public void CopyFrom(StreamReader @is)
	{
		class6012_0.CopyFrom(@is);
	}
}
