using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6048 : Class6042
{
	internal class Class6080 : Class6074
	{
		internal Class6080(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_1, cmapId)
		{
		}

		internal Class6080(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_1, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6048(data, method_16());
		}
	}

	protected Class6048(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 2, cmapId)
	{
	}

	private int method_11(int subHeaderIndex)
	{
		return class6016_0.method_16(6 + subHeaderIndex * 2);
	}

	private int method_12(int subHeaderIndex)
	{
		int num = method_11(subHeaderIndex);
		return class6016_0.method_16(num + 6);
	}

	private int method_13(int subHeaderIndex)
	{
		int num = method_11(subHeaderIndex);
		return class6016_0.method_16(num + 6 + 2);
	}

	private int method_14(int subHeaderIndex)
	{
		int num = method_11(subHeaderIndex);
		return class6016_0.method_16(num + 6 + 6);
	}

	private int method_15(int subHeaderIndex)
	{
		int num = method_11(subHeaderIndex);
		return class6016_0.method_17(num + 6 + 4);
	}

	public int method_16(int character)
	{
		int subHeaderIndex = (character >> 8) & 0xFF;
		if (method_11(subHeaderIndex) == 0)
		{
			return 1;
		}
		return 2;
	}

	public override int vmethod_2(int character)
	{
		if (character > 65535)
		{
			return Class6028.int_0;
		}
		int num = (character >> 8) & 0xFF;
		int num2 = character & 0xFF;
		int num3 = method_11(num);
		if (num3 == 0)
		{
			num2 = num;
			num = 0;
		}
		int num4 = method_12(num);
		int num5 = method_13(num);
		if (num2 >= num4 && num2 < num4 + num5)
		{
			int num6 = method_14(num);
			int index = num3 + 6 + num6 + (num2 - num4) * 2;
			int num7 = class6016_0.method_16(index);
			if (num7 == 0)
			{
				return Class6028.int_0;
			}
			if (num3 == 0)
			{
				return num7;
			}
			int num8 = method_15(num);
			return (num7 + num8) % 65536;
		}
		return Class6028.int_0;
	}

	public override int vmethod_1()
	{
		return class6016_0.method_16(4);
	}

	public override Interface256 imethod_0()
	{
		return new Class6087(0, 65535);
	}
}
