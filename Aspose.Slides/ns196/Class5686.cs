using System;
using ns171;
using ns187;

namespace ns196;

internal class Class5686
{
	private static int int_0 = int.MinValue;

	private static int int_1 = int.MaxValue;

	public static Class5686 class5686_0 = new Class5686(int_0, 9);

	public static Class5686 class5686_1 = new Class5686(int_1, 75);

	private int int_2;

	private int int_3;

	private Class5686(int strength, int context)
	{
		int_2 = strength;
		int_3 = context;
	}

	private static int smethod_0(Class5024 keep)
	{
		if (keep.method_2())
		{
			return int_0;
		}
		if (keep.imethod_0() == 7)
		{
			return int_1;
		}
		return (int)keep.vmethod_9();
	}

	public static Class5686 smethod_1(Class5043 keepProperty)
	{
		Class5686 @class = new Class5686(int_0, 9);
		@class.method_0(keepProperty.method_8(), 104);
		@class.method_0(keepProperty.method_7(), 28);
		@class.method_0(keepProperty.method_6(), 75);
		return @class;
	}

	private void method_0(Class5024 keep, int contexT)
	{
		if (!keep.method_2())
		{
			int_2 = smethod_0(keep);
			int_3 = contexT;
		}
	}

	public bool method_1()
	{
		return int_2 == int_0;
	}

	public int method_2()
	{
		return int_3;
	}

	public int method_3()
	{
		if (int_2 == int_0)
		{
			return 0;
		}
		if (int_2 == int_1)
		{
			return Class5337.int_0;
		}
		return Class5337.int_0 - 1;
	}

	private static int smethod_2(int context)
	{
		return (Enum679)context switch
		{
			Enum679.const_29 => 1, 
			Enum679.const_10 => 3, 
			Enum679.const_191 => 2, 
			Enum679.const_76 => 0, 
			_ => throw new ArgumentException(), 
		};
	}

	public Class5686 method_4(Class5686 other)
	{
		if (int_2 == int_1 && int_2 > other.int_2)
		{
			return this;
		}
		if (other.int_2 == int_1 && other.int_2 > int_2)
		{
			return other;
		}
		int num = smethod_2(int_3);
		int num2 = smethod_2(other.int_3);
		if (num == num2)
		{
			if (int_2 < other.int_2)
			{
				return other;
			}
			return this;
		}
		if (num >= num2)
		{
			return other;
		}
		return this;
	}

	public override string ToString()
	{
		if (int_2 != int_0)
		{
			if (int_2 != int_1)
			{
				return int_2.ToString();
			}
			return "always";
		}
		return "auto";
	}
}
