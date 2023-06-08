using ns171;
using ns195;

namespace ns176;

internal class Class5743 : Interface180
{
	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 3;

	public const int int_4 = 4;

	public const int int_5 = 5;

	public const int int_6 = 6;

	public const int int_7 = 7;

	public const int int_8 = 8;

	public const int int_9 = 9;

	public const int int_10 = 10;

	public const int int_11 = 11;

	public const int int_12 = 12;

	protected Class5094 class5094_0;

	private int int_13;

	private Interface182 interface182_0;

	public Class5743(Class5634 plist, int baseType)
	{
		class5094_0 = plist.method_0();
		int_13 = baseType;
		switch (baseType)
		{
		case 1:
			interface182_0 = plist.method_5(103).vmethod_0();
			break;
		case 2:
			interface182_0 = plist.method_4(103).vmethod_0();
			break;
		}
	}

	public int imethod_0()
	{
		return 1;
	}

	public double imethod_1()
	{
		return 1.0;
	}

	public int imethod_2(Interface172 context)
	{
		int result = 0;
		if (context != null)
		{
			if (int_13 == 1 || int_13 == 2)
			{
				return interface182_0.imethod_6(context);
			}
			result = context.imethod_0(int_13, class5094_0);
		}
		return result;
	}

	public override string ToString()
	{
		return string.Concat(string.Empty, "[fo=", class5094_0, ",baseType=", int_13, ",baseLength=", interface182_0, "]");
	}

	public Interface182 method_0()
	{
		return interface182_0;
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + Class5721.smethod_1(interface182_0);
		num = 31 * num + int_13;
		return 31 * num + Class5721.smethod_1(class5094_0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5743))
		{
			return false;
		}
		Class5743 @class = (Class5743)obj;
		if (Class5721.smethod_0(interface182_0, @class.interface182_0) && int_13 == @class.int_13)
		{
			return Class5721.smethod_0(class5094_0, @class.class5094_0);
		}
		return false;
	}
}
