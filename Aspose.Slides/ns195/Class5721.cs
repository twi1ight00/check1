using System;

namespace ns195;

internal class Class5721
{
	private Class5721()
	{
	}

	public static bool smethod_0(object o1, object o2)
	{
		if (o1 != null)
		{
			if (o1 != o2)
			{
				return o1.Equals(o2);
			}
			return true;
		}
		return o2 == null;
	}

	public static int smethod_1(object @object)
	{
		return @object?.GetHashCode() ?? 0;
	}

	public static bool smethod_2(double n1, double n2)
	{
		return BitConverter.DoubleToInt64Bits(n1) == BitConverter.DoubleToInt64Bits(n2);
	}

	public static int smethod_3(double number)
	{
		long num = BitConverter.DoubleToInt64Bits(number);
		return (int)(num ^ (num >> 32));
	}
}
