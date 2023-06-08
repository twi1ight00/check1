using System;
using ns176;

namespace ns186;

internal class Class5747
{
	private Class5747()
	{
	}

	public static Interface181 smethod_0(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_1(op1, op2, null);
		}
		return new Class5049(1, op1, op2);
	}

	public static Interface181 smethod_1(Interface181 op1, Interface181 op2, Interface172 context)
	{
		if (op1.imethod_3() != op2.imethod_3())
		{
			throw new Exception55("Can't subtract Numerics of different dimensions");
		}
		return smethod_18(op1.imethod_2(context) + op2.imethod_2(context), op1.imethod_3());
	}

	public static Interface181 smethod_2(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_3(op1, op2, null);
		}
		return new Class5049(2, op1, op2);
	}

	public static Interface181 smethod_3(Interface181 op1, Interface181 op2, Interface172 context)
	{
		if (op1.imethod_3() != op2.imethod_3())
		{
			throw new Exception55("Can't subtract Numerics of different dimensions");
		}
		return smethod_18(op1.imethod_2(context) - op2.imethod_2(context), op1.imethod_3());
	}

	public static Interface181 smethod_4(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_5(op1, op2, null);
		}
		return new Class5049(3, op1, op2);
	}

	public static Interface181 smethod_5(Interface181 op1, Interface181 op2, Interface172 context)
	{
		return smethod_18(op1.imethod_2(context) * op2.imethod_2(context), op1.imethod_3() + op2.imethod_3());
	}

	public static Interface181 smethod_6(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_7(op1, op2, null);
		}
		return new Class5049(4, op1, op2);
	}

	public static Interface181 smethod_7(Interface181 op1, Interface181 op2, Interface172 context)
	{
		return smethod_18(op1.imethod_2(context) / op2.imethod_2(context), op1.imethod_3() - op2.imethod_3());
	}

	public static Interface181 smethod_8(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_9(op1, op2, null);
		}
		return new Class5049(5, op1, op2);
	}

	public static Interface181 smethod_9(Interface181 op1, Interface181 op2, Interface172 context)
	{
		return smethod_18(op1.imethod_2(context) % op2.imethod_2(context), op1.imethod_3());
	}

	public static Interface181 smethod_10(Interface181 op)
	{
		if (op.imethod_4())
		{
			return smethod_11(op, null);
		}
		return new Class5049(7, op);
	}

	public static Interface181 smethod_11(Interface181 op, Interface172 context)
	{
		return smethod_18(Math.Abs(op.imethod_2(context)), op.imethod_3());
	}

	public static Interface181 smethod_12(Interface181 op)
	{
		if (op.imethod_4())
		{
			return smethod_13(op, null);
		}
		return new Class5049(6, op);
	}

	public static Interface181 smethod_13(Interface181 op, Interface172 context)
	{
		return smethod_18(0.0 - op.imethod_2(context), op.imethod_3());
	}

	public static Interface181 smethod_14(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_15(op1, op2, null);
		}
		return new Class5049(8, op1, op2);
	}

	public static Interface181 smethod_15(Interface181 op1, Interface181 op2, Interface172 context)
	{
		if (op1.imethod_3() != op2.imethod_3())
		{
			throw new Exception55("Arguments to max() must have same dimensions");
		}
		if (!(op1.imethod_2(context) > op2.imethod_2(context)))
		{
			return op2;
		}
		return op1;
	}

	public static Interface181 smethod_16(Interface181 op1, Interface181 op2)
	{
		if (op1.imethod_4() && op2.imethod_4())
		{
			return smethod_17(op1, op2, null);
		}
		return new Class5049(9, op1, op2);
	}

	public static Interface181 smethod_17(Interface181 op1, Interface181 op2, Interface172 context)
	{
		if (op1.imethod_3() != op2.imethod_3())
		{
			throw new Exception55("Arguments to min() must have same dimensions");
		}
		if (!(op1.imethod_2(context) <= op2.imethod_2(context)))
		{
			return op2;
		}
		return op1;
	}

	private static Interface181 smethod_18(double value, int dimension)
	{
		return new Class5026(value, dimension);
	}
}
