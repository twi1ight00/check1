using System;
using ns171;
using ns192;

namespace ns197;

internal abstract class Class5711
{
	protected const int int_0 = 0;

	protected const int int_1 = 1;

	protected const int int_2 = 2;

	protected const int int_3 = 3;

	private static Class5711 class5711_0;

	private static Class5711 class5711_1;

	public static Class5711 smethod_0(int borderCollapse)
	{
		switch ((Enum679)borderCollapse)
		{
		default:
			throw new ArgumentException("Illegal border-collapse mode.");
		case Enum679.const_27:
			if (class5711_0 == null)
			{
				class5711_0 = new Class5712();
			}
			return class5711_0;
		case Enum679.const_28:
			return class5711_1;
		}
	}

	public static int smethod_1(int side)
	{
		return side switch
		{
			0 => 1, 
			1 => 0, 
			2 => 3, 
			3 => 2, 
			_ => throw new ArgumentException("Illegal parameter: side"), 
		};
	}

	protected bool method_0(int side)
	{
		if (side != 0)
		{
			return side == 1;
		}
		return true;
	}

	private static int smethod_2(int value1, int value2)
	{
		if (value1 < value2)
		{
			return -1;
		}
		if (value1 == value2)
		{
			return 0;
		}
		return 1;
	}

	private static int smethod_3(int style)
	{
		return (Enum679)style switch
		{
			Enum679.const_56 => -6, 
			Enum679.const_37 => -3, 
			Enum679.const_38 => 0, 
			Enum679.const_32 => -2, 
			Enum679.const_188 => -5, 
			Enum679.const_68 => -7, 
			Enum679.const_220 => -1, 
			Enum679.const_206 => -4, 
			_ => throw new InvalidOperationException("Illegal border style: " + style), 
		};
	}

	internal static int smethod_4(int style1, int style2)
	{
		int value = smethod_3(style1);
		int value2 = smethod_3(style2);
		return smethod_2(value, value2);
	}

	private static int smethod_5(int id)
	{
		switch ((Enum679)id)
		{
		case Enum679.const_72:
			return -4;
		default:
			throw new InvalidOperationException();
		case Enum679.const_76:
			return 0;
		case Enum679.const_77:
			return -3;
		case Enum679.const_74:
		case Enum679.const_78:
		case Enum679.const_79:
			return -2;
		case Enum679.const_80:
			return -1;
		}
	}

	internal static int smethod_6(int id1, int id2)
	{
		int value = smethod_5(id1);
		int value2 = smethod_5(id2);
		return smethod_2(value, value2);
	}

	public abstract Class5706 vmethod_0(Class5706 border1, Class5706 border2, bool discard);

	public abstract Class5706 vmethod_1(Class5706 border1, Class5706 border2);
}
