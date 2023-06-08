using System;

namespace ns205;

internal class Class5746
{
	public static Class5746 class5746_0 = smethod_1(0);

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal object method_0()
	{
		return MemberwiseClone();
	}

	public static Class5746 smethod_0(int min, int opt, int max)
	{
		if (min > opt)
		{
			throw new ArgumentException("min (" + min + ") > opt (" + opt + ")");
		}
		if (max < opt)
		{
			throw new ArgumentException("max (" + max + ") < opt (" + opt + ")");
		}
		return new Class5746(min, opt, max);
	}

	public static Class5746 smethod_1(int value)
	{
		return new Class5746(value, value, value);
	}

	private Class5746(int min, int opt, int max)
	{
		int_0 = min;
		int_1 = opt;
		int_2 = max;
	}

	public int method_1()
	{
		return int_0;
	}

	public int method_2()
	{
		return int_1;
	}

	public int method_3()
	{
		return int_2;
	}

	public int method_4()
	{
		return int_1 - int_0;
	}

	public int method_5()
	{
		return int_2 - int_1;
	}

	public Class5746 method_6(Class5746 operand)
	{
		return new Class5746(int_0 + operand.int_0, int_1 + operand.int_1, int_2 + operand.int_2);
	}

	public Class5746 method_7(int value)
	{
		return new Class5746(int_0 + value, int_1 + value, int_2 + value);
	}

	public Class5746 method_8(Class5746 operand)
	{
		method_9(method_4(), operand.method_4(), "shrink");
		method_9(method_5(), operand.method_5(), "stretch");
		return new Class5746(int_0 - operand.int_0, int_1 - operand.int_1, int_2 - operand.int_2);
	}

	private void method_9(int thisElasticity, int operandElasticity, string msge)
	{
		if (thisElasticity < operandElasticity)
		{
			throw new ArithmeticException("Cannot subtract a MinOptMax from another MinOptMax that has less " + msge + " (" + thisElasticity + " < " + operandElasticity + ")");
		}
	}

	public Class5746 method_10(int value)
	{
		return new Class5746(int_0 - value, int_1 - value, int_2 - value);
	}

	public Class5746 method_11(int minOperand)
	{
		return smethod_0(int_0 + minOperand, int_1, int_2);
	}

	public Class5746 method_12(int minOperand)
	{
		return smethod_0(int_0 - minOperand, int_1, int_2);
	}

	public Class5746 method_13(int maxOperand)
	{
		return smethod_0(int_0, int_1, int_2 + maxOperand);
	}

	public Class5746 method_14(int maxOperand)
	{
		return smethod_0(int_0, int_1, int_2 - maxOperand);
	}

	public Class5746 method_15(int factor)
	{
		if (factor < 0)
		{
			throw new ArgumentException("factor < 0; was: " + factor);
		}
		if (factor == 1)
		{
			return this;
		}
		return smethod_0(int_0 * factor, int_1 * factor, int_2 * factor);
	}

	public bool method_16()
	{
		if (int_0 == 0)
		{
			return int_2 != 0;
		}
		return true;
	}

	public bool method_17()
	{
		return int_0 == int_2;
	}

	public bool method_18()
	{
		if (int_0 == int_1)
		{
			return int_1 != int_2;
		}
		return true;
	}

	public Class5746 method_19(int newMin)
	{
		if (int_0 < newMin)
		{
			int num = Math.Max(newMin, int_1);
			int max = Math.Max(num, int_2);
			return smethod_0(newMin, num, max);
		}
		return this;
	}

	public Class5746 method_20(int newMax)
	{
		if (int_2 < newMax)
		{
			int opt = ((int_2 == int_1) ? newMax : int_1);
			return smethod_0(int_0, opt, newMax);
		}
		return this;
	}

	public Class5746 method_21(int newOpt)
	{
		if (int_1 < newOpt)
		{
			int max = ((int_2 > newOpt) ? int_2 : newOpt);
			return smethod_0(int_0, newOpt, max);
		}
		return this;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj != null && !(GetType() != obj.GetType()))
		{
			Class5746 @class = (Class5746)obj;
			if (int_1 == @class.int_1 && int_2 == @class.int_2)
			{
				return int_0 == @class.int_0;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = int_0;
		num = 31 * num + int_1;
		return 31 * num + int_2;
	}

	public override string ToString()
	{
		return "MinOptMax[min = " + int_0 + ", opt = " + int_1 + ", max = " + int_2 + "]";
	}
}
