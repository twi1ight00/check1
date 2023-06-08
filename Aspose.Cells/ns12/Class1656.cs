using System;

namespace ns12;

internal class Class1656
{
	public static readonly double double_0 = smethod_0(1.0);

	public static readonly double double_1 = smethod_1(1.0);

	public static readonly double double_2 = 10.0 * double_1;

	public static double smethod_0(double double_3)
	{
		if (!double.IsInfinity(double_3) && !double.IsNaN(double_3))
		{
			long num = BitConverter.DoubleToInt64Bits(double_3);
			if (num == 0)
			{
				num++;
				return BitConverter.Int64BitsToDouble(num) - double_3;
			}
			if (num-- < 0)
			{
				return BitConverter.Int64BitsToDouble(num) - double_3;
			}
			return double_3 - BitConverter.Int64BitsToDouble(num);
		}
		return double.NaN;
	}

	public static double smethod_1(double double_3)
	{
		return 2.0 * smethod_0(double_3);
	}

	public static bool smethod_2(double double_3, double double_4, double double_5, double double_6)
	{
		if ((double_3 == 0.0 && Math.Abs(double_4) < double_6) || (double_4 == 0.0 && Math.Abs(double_3) < double_6))
		{
			return true;
		}
		return Math.Abs(double_5) < double_6 * Math.Max(Math.Abs(double_3), Math.Abs(double_4));
	}

	public static bool smethod_3(double double_3, double double_4)
	{
		return smethod_2(double_3, double_4, double_3 - double_4, double_2);
	}
}
