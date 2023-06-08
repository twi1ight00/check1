using System;
using ns176;
using ns187;
using ns195;

namespace ns186;

internal class Class5049 : Class5024, Interface181, Interface182
{
	public const int int_0 = 1;

	public const int int_1 = 2;

	public const int int_2 = 3;

	public const int int_3 = 4;

	public const int int_4 = 5;

	public const int int_5 = 6;

	public const int int_6 = 7;

	public const int int_7 = 8;

	public const int int_8 = 9;

	private static string string_1 = " +-*/%";

	private int int_9;

	private Interface181 interface181_0;

	private Interface181 interface181_1;

	private int int_10;

	public Class5049(int operation, Interface181 op1, Interface181 op2)
	{
		int_9 = operation;
		interface181_0 = op1;
		interface181_1 = op2;
		switch (operation)
		{
		default:
			int_10 = op1.imethod_3();
			break;
		case 3:
			int_10 = op1.imethod_3() + op2.imethod_3();
			break;
		case 4:
			int_10 = op1.imethod_3() - op2.imethod_3();
			break;
		}
	}

	public Class5049(int operation, Interface181 op)
	{
		int_9 = operation;
		interface181_0 = op;
		int_10 = op.imethod_3();
	}

	private Interface181 method_3(Interface172 context)
	{
		return int_9 switch
		{
			1 => Class5747.smethod_1(interface181_0, interface181_1, context), 
			2 => Class5747.smethod_3(interface181_0, interface181_1, context), 
			3 => Class5747.smethod_5(interface181_0, interface181_1, context), 
			4 => Class5747.smethod_7(interface181_0, interface181_1, context), 
			5 => Class5747.smethod_9(interface181_0, interface181_1, context), 
			6 => Class5747.smethod_13(interface181_0, context), 
			7 => Class5747.smethod_11(interface181_0, context), 
			8 => Class5747.smethod_15(interface181_0, interface181_1, context), 
			9 => Class5747.smethod_17(interface181_0, interface181_1, context), 
			_ => throw new Exception55("Unknown expr operation " + int_9), 
		};
	}

	public double imethod_1()
	{
		return method_3(null).imethod_2(null);
	}

	public double imethod_2(Interface172 context)
	{
		return method_3(context).imethod_2(context);
	}

	public int imethod_3()
	{
		return int_10;
	}

	public bool imethod_4()
	{
		return false;
	}

	public override Interface182 vmethod_0()
	{
		if (int_10 == 1)
		{
			return this;
		}
		return null;
	}

	public override Interface181 vmethod_10()
	{
		return this;
	}

	public int imethod_5()
	{
		try
		{
			return (int)imethod_1();
		}
		catch (Exception55)
		{
		}
		return 0;
	}

	public int imethod_6(Interface172 context)
	{
		try
		{
			return (int)imethod_2(context);
		}
		catch (Exception55)
		{
		}
		return 0;
	}

	public double method_4()
	{
		double num = 0.0;
		double num2 = 0.0;
		if (interface181_0 is Class5049)
		{
			num = ((Class5049)interface181_0).method_4();
		}
		else if (interface181_0 is Class5038)
		{
			num = ((Class5038)interface181_0).method_3();
		}
		if (interface181_1 is Class5049)
		{
			num2 = ((Class5049)interface181_1).method_4();
		}
		else if (interface181_1 is Class5038)
		{
			num2 = ((Class5038)interface181_1).method_3();
		}
		if (num != 0.0 && num2 != 0.0)
		{
			switch (int_9)
			{
			case 1:
				return num + num2;
			case 2:
				return num - num2;
			case 3:
				return num * num2;
			case 4:
				return num / num2;
			case 5:
				return num % num2;
			case 8:
				return Math.Max(num, num2);
			case 9:
				return Math.Min(num, num2);
			}
		}
		else
		{
			if (num != 0.0)
			{
				return int_9 switch
				{
					6 => 0.0 - num, 
					7 => Math.Abs(num), 
					_ => num, 
				};
			}
			if (num2 != 0.0)
			{
				return num2;
			}
		}
		return 0.0;
	}

	public override string ToString()
	{
		switch (int_9)
		{
		default:
			return "unknown operation " + int_9;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			return string.Concat("(", interface181_0, " ", string_1[int_9], interface181_1, ")");
		case 6:
			return "-" + interface181_0;
		case 7:
			return string.Concat("abs(", interface181_0, ")");
		case 8:
			return string.Concat("max(", interface181_0, ", ", interface181_1, ")");
		case 9:
			return string.Concat("min(", interface181_0, ", ", interface181_1, ")");
		}
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + int_10;
		num = 31 * num + Class5721.smethod_1(interface181_0);
		num = 31 * num + Class5721.smethod_1(interface181_1);
		return 31 * num + int_9;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5049))
		{
			return false;
		}
		Class5049 @class = (Class5049)obj;
		if (int_10 == @class.int_10 && Class5721.smethod_0(interface181_0, @class.interface181_0) && Class5721.smethod_0(interface181_1, @class.interface181_1))
		{
			return int_9 == @class.int_9;
		}
		return false;
	}

	public void method_5(Interface181 instance, Interface181 numeric)
	{
		if (interface181_0.Equals(instance))
		{
			interface181_0 = numeric;
		}
		if (interface181_1.Equals(instance))
		{
			interface181_1 = numeric;
		}
		if (interface181_0 is Class5049 @class)
		{
			@class.method_5(instance, numeric);
		}
		if (interface181_1 is Class5049 class2)
		{
			class2.method_5(instance, numeric);
		}
	}
}
