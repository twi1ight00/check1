using System;
using Aspose.Cells;
using ns2;

namespace ns12;

internal class Class1668
{
	private class Class482 : Class481
	{
		private double double_0;

		public Class482(double double_1)
		{
			double_0 = double_1;
		}

		public override double vmethod_0(double double_1)
		{
			return smethod_3(double_1, double_0);
		}
	}

	private class Class478 : Class477
	{
		private double double_1;

		public Class478(double double_2)
		{
			double_1 = double_2;
		}

		protected override void vmethod_1(double double_2, double[] double_3)
		{
			bool isError = true;
			double_3[0] = smethod_4(double_2, double_1, 2, out isError) - double_0;
			double_3[1] = -2.0 * smethod_3(double_2, double_1);
		}
	}

	private class Class479 : Class477
	{
		private double double_1;

		public Class479(double double_2)
		{
			double_1 = double_2;
		}

		protected override double vmethod_0(double double_2)
		{
			bool isError = true;
			return smethod_6(double_2, double_1, out isError);
		}
	}

	private class Class480 : Class477
	{
		private double double_1;

		private double double_2;

		public Class480(double double_3, double double_4)
		{
			double_1 = double_3;
			double_2 = double_4;
		}

		protected override void vmethod_1(double double_3, double[] double_4)
		{
			bool isError = true;
			double_4[0] = smethod_9(double_3, double_1, double_2, out isError) - double_0;
			double_4[1] = 0.0 - smethod_8(double_3, double_1, double_2);
		}
	}

	private static double double_0;

	public static double smethod_0(double x, double a, double b, out bool isError)
	{
		return smethod_1(x, a, b, 0.0, 1.0, out isError);
	}

	public static double smethod_1(double x, double a, double b, double A, double B, out bool isError)
	{
		isError = true;
		if (!(x < A) && !(x > B) && B > A)
		{
			if (!(a < 0.0) && b >= 0.0)
			{
				x = (x - A) / (B - A);
				try
				{
					isError = false;
					return Class1657.smethod_15(x, a, b);
				}
				catch (Exception)
				{
					isError = true;
					return 0.0;
				}
			}
			return 0.0;
		}
		return 0.0;
	}

	public static double smethod_2(double x, double a, double b, double A, double B, out bool isError)
	{
		isError = true;
		if (!(x <= 0.0) && !(x > 1.0) && !(a <= 0.0) && !(b <= 0.0) && B > A)
		{
			double num = 0.0;
			isError = false;
			num = Class1657.smethod_20(x, a, b);
			return num * (B - A) + A;
		}
		return 0.0;
	}

	private static double smethod_3(double double_1, double double_2)
	{
		double num = Class1657.smethod_9((double_2 + 1.0) / 2.0) / Math.Sqrt(double_2 * Math.PI) / Class1657.smethod_9(double_2 / 2.0);
		double num2 = Math.Pow(1.0 + double_1 * double_1 / double_2, (0.0 - (double_2 + 1.0)) / 2.0);
		return num * num2;
	}

	public static double smethod_4(double x, double degrees_freedom, int tails, out bool isError)
	{
		isError = true;
		if (!(degrees_freedom < 1.0) && tails <= 2 && tails >= 1 && x >= 0.0)
		{
			try
			{
				Class482 @class = new Class482(degrees_freedom);
				double num;
				if (x < 5.0)
				{
					num = @class.method_0(0.0, x, 1E-20);
					isError = false;
					num = 0.5 - num;
					return num * (double)tails;
				}
				num = @class.method_0(0.0, 5.0, 1E-20) + @class.method_0(5.0, x, 1E-20);
				isError = false;
				num = 0.5 - num;
				return num * (double)tails;
			}
			catch (Exception)
			{
				isError = true;
				return double.NaN;
			}
		}
		return double.NaN;
	}

	public static double smethod_5(double x, double degrees_freedom, out bool isError)
	{
		isError = true;
		if (!(degrees_freedom < 1.0) && !(x < 0.0) && x <= 1.0)
		{
			if (x == 0.0)
			{
				isError = false;
				return 10000000.0;
			}
			if (x == 1.0)
			{
				isError = false;
				return 0.0;
			}
			try
			{
				Class478 @class = new Class478(degrees_freedom);
				@class.double_0 = x;
				double double_ = 1.0;
				if (@class.method_0(ref double_, 100, 1E-12))
				{
					isError = false;
					return double_;
				}
				return 0.0;
			}
			catch (Exception)
			{
				isError = true;
				return 0.0;
			}
		}
		return 0.0;
	}

	public static double smethod_6(double x, double degrees_freedom, out bool isError)
	{
		isError = true;
		if (!(x < 0.0) && !(degrees_freedom < 1.0) && degrees_freedom <= 10000000000.0)
		{
			try
			{
				double result = 1.0 - Class1657.smethod_10(degrees_freedom / 2.0, x / 2.0);
				isError = false;
				return result;
			}
			catch (Exception)
			{
			}
			return 0.0;
		}
		return 0.0;
	}

	public static double smethod_7(double x, double degrees_freedom, out bool isError)
	{
		isError = true;
		if (!(x <= 0.0) && !(x > 1.0) && !(degrees_freedom > 10000000000.0) && degrees_freedom >= 1.0)
		{
			double double_ = 0.0;
			try
			{
				Class479 @class = new Class479(degrees_freedom);
				if (@class.method_1(ref double_, x, 0.5 * degrees_freedom, degrees_freedom))
				{
					isError = false;
					return double_;
				}
				return double.NaN;
			}
			catch (Exception)
			{
				return 0.0;
			}
		}
		return 0.0;
	}

	public static double smethod_8(double double_1, double double_2, double double_3)
	{
		if (double_1 <= 0.0)
		{
			return 0.0;
		}
		double d = Math.Pow(double_2 * double_1, double_2) * Math.Pow(double_3, double_3) / Math.Pow(double_2 * double_1 + double_3, double_2 + double_3);
		return Math.Sqrt(d) / double_1 / Class1657.smethod_13(double_2 / 2.0, double_3 / 2.0);
	}

	public static double smethod_9(double x, double degrees_freedom1, double degrees_freedom2, out bool isError)
	{
		isError = true;
		if (!(x < 0.0) && !(degrees_freedom1 < 1.0) && !(degrees_freedom2 < 1.0) && !(degrees_freedom1 >= 10000000000.0) && degrees_freedom2 < 10000000000.0)
		{
			if (x == 0.0)
			{
				isError = false;
				return 1.0;
			}
			try
			{
				return smethod_0(degrees_freedom2 / (degrees_freedom2 + degrees_freedom1 * x), degrees_freedom2 / 2.0, degrees_freedom1 / 2.0, out isError);
			}
			catch (Exception)
			{
				isError = true;
				return 0.0;
			}
		}
		return 0.0;
	}

	public static double smethod_10(double x, double degrees_freedom1, double degrees_freedom2, out bool isError)
	{
		isError = true;
		if (!(x < 0.0) && !(x > 1.0) && !(degrees_freedom1 < 1.0) && !(degrees_freedom2 < 1.0) && !(degrees_freedom1 >= 10000000000.0) && degrees_freedom2 < 10000000000.0)
		{
			if (x == 0.0)
			{
				isError = false;
				return 1000000000.0;
			}
			if (x == 1.0)
			{
				isError = false;
				return 0.0;
			}
			try
			{
				Class480 @class = new Class480(degrees_freedom1, degrees_freedom2);
				@class.double_0 = x;
				double double_;
				if (x < 1E-05)
				{
					double_ = 2000.0;
					if (@class.method_0(ref double_, 100, 1E-10))
					{
						isError = false;
						return double_;
					}
					return double.NaN;
				}
				double_ = 1.0;
				if (@class.method_0(ref double_, 100, 1E-10))
				{
					isError = false;
					return double_;
				}
				return double.NaN;
			}
			catch (Exception)
			{
				return 0.0;
			}
		}
		return double.NaN;
	}

	private static double smethod_11(double double_1, double double_2, double double_3)
	{
		double num = 171.624376956302;
		if (double_1 <= 0.0)
		{
			return 0.0;
		}
		try
		{
			double num2 = double_1 / double_3;
			if (num2 > 1.0)
			{
				double num3 = Math.Log(double.MaxValue);
				if (Math.Log(num2) * (double_2 - 1.0) < num3 && double_2 < num)
				{
					return Math.Pow(num2, double_2 - 1.0) * Math.Exp(0.0 - num2) / double_3 / Class1657.smethod_9(double_2);
				}
				return Math.Exp((double_2 - 1.0) * Math.Log(num2) - num2 - Math.Log(double_3) - Class1657.smethod_8(double_2));
			}
			if (double_2 < num)
			{
				return Math.Pow(num2, double_2 - 1.0) * Math.Exp(0.0 - num2) / double_3 / Class1657.smethod_9(double_2);
			}
			return Math.Pow(num2, double_2 - 1.0) * Math.Exp(0.0 - num2) / double_3 / Math.Exp(Class1657.smethod_8(double_2));
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public static double smethod_12(double double_1, double double_2)
	{
		try
		{
			if (double_1 <= 0.0)
			{
				return 0.0;
			}
			return smethod_16(double_2, double_1 / 1.0);
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public static double smethod_13(double double_1, double double_2, double double_3)
	{
		try
		{
			if (double_1 <= 0.0)
			{
				return 0.0;
			}
			return smethod_16(double_2, double_1 / double_3);
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	private static double smethod_14(double double_1, double double_2)
	{
		double num = double.Epsilon;
		double num2 = 1.0 / num;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 1.0 - double_1;
		double num6 = double_2 + 2.0 - double_1;
		double num7 = 0.0;
		double num8 = double_2 + 1.0;
		double num9 = 1.0;
		double num10 = 1.0;
		double num11 = num6 * double_2;
		double num12 = double_2;
		double num13 = num8 / num11;
		bool flag = false;
		double num14 = 0.0;
		do
		{
			num3 += 1.0;
			num5 += 1.0;
			num4 = num5 * num3;
			num6 += 2.0;
			num7 = num8 * num6 - num9 * num4;
			num10 = num11 * num6 - num12 * num4;
			if (num10 != 0.0)
			{
				num14 = num7 / num10;
				flag = Math.Abs((num13 - num14) / num14) <= double_0;
				num13 = num14;
			}
			num9 = num8;
			num8 = num7;
			num12 = num11;
			num11 = num10;
			if (Math.Abs(num7) > num2)
			{
				num9 *= num;
				num8 *= num;
				num12 *= num;
				num11 *= num;
			}
		}
		while (!flag && num3 < 10000.0);
		if (!flag)
		{
			return 0.0;
		}
		return num13;
	}

	private static double smethod_15(double double_1, double double_2)
	{
		double num = double_1;
		double num2 = 1.0 / double_1;
		double num3 = num2;
		int num4 = 1;
		do
		{
			num += 1.0;
			num2 = num2 * double_2 / num;
			num3 += num2;
			num4++;
		}
		while (!(num2 / num3 <= double_0) && num4 <= 10000);
		if (num4 > 10000)
		{
			return 0.0;
		}
		return num3;
	}

	private static double smethod_16(double double_1, double double_2)
	{
		double d = double_1 * Math.Log(double_2) - double_2 - Class1657.smethod_8(double_1);
		double num = Math.Exp(d);
		if (double_2 > double_1 + 1.0)
		{
			return 1.0 - num * smethod_14(double_1, double_2);
		}
		return num * smethod_15(double_1, double_2);
	}

	public static double smethod_17(double double_1, double double_2, double double_3, bool bool_0)
	{
		if (!(double_1 < 0.0) && !(double_2 <= 0.0) && double_3 > 0.0)
		{
			if (!bool_0)
			{
				return smethod_11(double_1, double_2, double_3);
			}
			try
			{
				if (double_1 <= 0.0)
				{
					return 0.0;
				}
				return smethod_16(double_2, double_1 / double_3);
			}
			catch (Exception)
			{
				return double.NaN;
			}
		}
		return double.NaN;
	}

	public static double smethod_18(double double_1, double double_2, double double_3)
	{
		if (!(double_1 < 0.0) && !(double_1 > 1.0) && !(double_2 <= 0.0) && double_3 > 0.0)
		{
			try
			{
				return Class1657.smethod_12(double_1, double_2, double_3);
			}
			catch (Exception)
			{
				return 0.0;
			}
		}
		return double.NaN;
	}

	public static double smethod_19(double x, double lambda, bool cumulative, out bool isError)
	{
		isError = true;
		if (!(x < 0.0) && lambda > 0.0)
		{
			double num = 0.0;
			if (cumulative)
			{
				try
				{
					num = 1.0 - Math.Exp((0.0 - lambda) * x);
					isError = false;
					return num;
				}
				catch (Exception)
				{
				}
			}
			else
			{
				try
				{
					num = lambda * Math.Exp((0.0 - lambda) * x);
					isError = false;
					return num;
				}
				catch (Exception)
				{
				}
			}
			return double.NaN;
		}
		return double.NaN;
	}

	public static double smethod_20(int Number_s, int Trials, double Probability_s, bool Cumulative, out bool isError)
	{
		isError = true;
		if (Number_s >= 0 && Number_s <= Trials)
		{
			if (!(Probability_s < 0.0) && Probability_s <= 1.0)
			{
				double num = 0.0;
				if (Cumulative)
				{
					try
					{
						for (int num2 = Number_s; num2 >= 0; num2--)
						{
							num += Class1657.smethod_7(Trials, num2) * Math.Pow(Probability_s, num2) * Math.Pow(1.0 - Probability_s, Trials - num2);
						}
						isError = false;
						return num;
					}
					catch (Exception)
					{
					}
				}
				else
				{
					try
					{
						num = Class1657.smethod_7(Trials, Number_s) * Math.Pow(Probability_s, Number_s) * Math.Pow(1.0 - Probability_s, Trials - Number_s);
						isError = false;
						return num;
					}
					catch (Exception)
					{
					}
				}
				return double.NaN;
			}
			return double.NaN;
		}
		return double.NaN;
	}

	internal static double[][] smethod_21(double[] data_array, double[] bins_array, out bool isError)
	{
		Array.Sort(data_array);
		Array.Sort(bins_array);
		double[][] array = new double[bins_array.Length + 1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new double[1];
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (num2 = 0; num2 < bins_array.Length; num2++)
		{
			num = num3;
			while (num < data_array.Length && data_array[num] <= bins_array[num2])
			{
				array[num2][0] += 1.0;
				num++;
				num3++;
			}
		}
		array[bins_array.Length][0] = data_array.Length - num;
		isError = false;
		return array;
	}

	internal static object smethod_22(double double_1, double[] double_2, double[] double_3)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		for (int i = 0; i < double_2.Length; i++)
		{
			num += double_3[i];
			num2 += double_3[i] * double_3[i];
			num3 += double_3[i] * double_2[i];
			num4 += double_2[i];
		}
		double num5 = (double)double_2.Length * num2 - num * num;
		if (Math.Abs(num5) < double.Epsilon)
		{
			return ErrorType.Div;
		}
		double num6 = ((double)double_2.Length * num3 - num * num4) / num5;
		double num7 = (num4 - num6 * num) / (double)double_2.Length;
		return num6 * double_1 + num7;
	}

	internal static double smethod_23(double[] double_1)
	{
		double num = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num += double_1[i];
		}
		return num;
	}

	internal static object smethod_24(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.Div;
		}
		return smethod_23(double_1) / (double)double_1.Length;
	}

	internal static double smethod_25(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return 0.0;
		}
		double num = double_1[0];
		for (int i = 1; i < double_1.Length; i++)
		{
			if (double_1[i] < num)
			{
				num = double_1[i];
			}
		}
		return num;
	}

	internal static double smethod_26(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return 0.0;
		}
		double num = double_1[0];
		for (int i = 1; i < double_1.Length; i++)
		{
			if (double_1[i] > num)
			{
				num = double_1[i];
			}
		}
		return num;
	}

	internal static double smethod_27(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return 0.0;
		}
		double num = 1.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num *= double_1[i];
		}
		return num;
	}

	internal static object smethod_28(double[] double_1)
	{
		if (double_1.Length < 2)
		{
			return ErrorType.Div;
		}
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += double_1[i];
			num += double_1[i] * double_1[i];
		}
		return Math.Sqrt(((double)double_1.Length * num - num2 * num2) / (double)(double_1.Length * (double_1.Length - 1)));
	}

	internal static object smethod_29(double[] double_1)
	{
		if (double_1.Length < 2)
		{
			return ErrorType.Div;
		}
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += double_1[i];
			num += double_1[i] * double_1[i];
		}
		return ((double)double_1.Length * num - num2 * num2) / (double)(double_1.Length * (double_1.Length - 1));
	}

	internal static object smethod_30(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.Div;
		}
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += double_1[i];
			num += double_1[i] * double_1[i];
		}
		return Math.Sqrt(((double)double_1.Length * num - num2 * num2) / (double)(double_1.Length * double_1.Length));
	}

	internal static object smethod_31(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.Div;
		}
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += double_1[i];
			num += double_1[i] * double_1[i];
		}
		return ((double)double_1.Length * num - num2 * num2) / (double)(double_1.Length * double_1.Length);
	}

	internal static object smethod_32(double double_1, double double_2, double double_3, bool bool_0)
	{
		if (!(double_1 < 0.0) && !(double_2 <= 0.0) && double_3 > 0.0)
		{
			double num = Math.Pow(double_1 / double_3, double_2);
			num = Math.Exp(0.0 - num);
			if (bool_0)
			{
				return 1.0 - num;
			}
			return double_2 / Math.Pow(double_3, double_2) * Math.Pow(double_1, double_2 - 1.0) * num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_33(double[] double_1, double[] double_2)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = double_2.Length;
		if (double_2.Length != 0 && double_1.Length != 0 && double_2.Length == double_1.Length)
		{
			for (int i = 0; i < num6; i++)
			{
				num2 += double_2[i] * double_1[i];
				num3 += double_2[i] * double_2[i];
				num4 += double_2[i];
				num5 += double_1[i];
			}
			if ((double)num6 * num3 - num4 * num4 == 0.0)
			{
				return ErrorType.NA;
			}
			num = ((double)num6 * num2 - num4 * num5) / ((double)num6 * num3 - num4 * num4);
			return num;
		}
		return ErrorType.NA;
	}

	internal static double smethod_34(double double_1, double double_2)
	{
		return smethod_35(double_1, double_2) / smethod_35(double_2, double_2);
	}

	internal static double smethod_35(double double_1, double double_2)
	{
		double num = 1.0;
		double_1 = Math.Floor(double_1);
		double_2 = Math.Floor(double_2);
		for (double num2 = double_1; num2 > double_1 - double_2; num2 -= 1.0)
		{
			num *= num2;
		}
		return num;
	}

	internal static object smethod_36(double double_1, double double_2, double double_3)
	{
		if (double_3 <= 0.0)
		{
			return ErrorType.Number;
		}
		return (double_1 - double_2) / double_3;
	}

	internal static object smethod_37(double double_1, double double_2)
	{
		if (!(double_1 < 0.0) && !(double_2 < 0.0) && double_1 >= double_2)
		{
			double num = smethod_35(double_1, double_2);
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_38(double[] double_1, double[] double_2)
	{
		double num = 0.0;
		double num2 = smethod_39(double_1, 1, double_1.Length);
		double num3 = smethod_39(double_2, 1, double_2.Length);
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		if (double_2.Length != 0 && double_1.Length != 0 && double_2.Length == double_1.Length)
		{
			int num7 = double_2.Length;
			for (int i = 0; i < num7; i++)
			{
				num4 += (double_2[i] - num3) * (double_2[i] - num3);
				num5 += (double_1[i] - num2) * (double_1[i] - num2);
				num6 += (double_2[i] - num3) * (double_1[i] - num2);
			}
			num = num5 - num6 * num6 / num4;
			num /= (double)(num7 - 2);
			return Math.Sqrt(num);
		}
		return ErrorType.NA;
	}

	internal static double smethod_39(double[] double_1, int int_0, int int_1)
	{
		double num = 0.0;
		for (int i = 0; i < int_1; i++)
		{
			num += (double_1[i * int_0] - num) / (double)(i + 1);
		}
		return num;
	}

	internal static double smethod_40(double[] double_1)
	{
		double num = double_1[0];
		for (int i = 1; i < double_1.Length; i++)
		{
			num += double_1[i];
		}
		return num;
	}

	internal static object smethod_41(double[] double_1, double double_2)
	{
		if (!(double_2 < 0.0) && double_2 < 1.0)
		{
			Array.Sort(double_1);
			double num = 0.0;
			int num2 = double_1.Length;
			int num3 = (int)((double)double_1.Length * double_2);
			if (num3 == 0)
			{
				num = smethod_39(double_1, 1, double_1.Length);
			}
			else
			{
				int num4 = num3 / 2;
				for (int i = 0; i < num4; i++)
				{
					double_1[i] = 0.0;
					double_1[num2 - 1 - i] = 0.0;
				}
				num = smethod_23(double_1) / (double)(num2 - num4 * 2);
			}
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_42(double[] double_1, double[] double_2)
	{
		double num = smethod_39(double_1, 1, double_1.Length);
		double num2 = smethod_39(double_2, 1, double_2.Length);
		object obj = smethod_33(double_1, double_2);
		if (obj.Equals(ErrorType.NA))
		{
			return ErrorType.NA;
		}
		return num - (double)obj * num2;
	}

	internal static object smethod_43(double[] double_1)
	{
		int num = double_1.Length;
		if (num < 4)
		{
			return ErrorType.Div;
		}
		double num2 = smethod_39(double_1, 1, num);
		double num3 = Math.Sqrt(smethod_45(double_1, 1, num));
		if (num3 == 0.0)
		{
			return ErrorType.Div;
		}
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i++)
		{
			double num6 = (double_1[i] - num2) / num3;
			num4 += num6 * num6 * num6 * num6;
		}
		num5 = (double)(num * (num + 1)) / (double)((num - 1) * (num - 2) * (num - 3)) * num4 - (double)(3 * ((num - 1) * (num - 1))) / (double)((num - 2) * (num - 3));
		return num5;
	}

	internal static object smethod_44(double[] double_1)
	{
		int num = double_1.Length;
		if (num < 3)
		{
			return ErrorType.Div;
		}
		double num2 = smethod_39(double_1, 1, num);
		double num3 = Math.Sqrt(smethod_45(double_1, 1, num));
		if (num3 == 0.0)
		{
			return ErrorType.Div;
		}
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i++)
		{
			double num6 = (double_1[i] - num2) / num3;
			num4 += num6 * num6 * num6;
		}
		num5 = (double)num / (double)((num - 1) * (num - 2)) * num4;
		return num5;
	}

	internal static double smethod_45(double[] double_1, int int_0, int int_1)
	{
		double double_2 = smethod_39(double_1, int_0, int_1);
		return smethod_46(double_1, int_0, int_1, double_2);
	}

	internal static double smethod_46(double[] double_1, int int_0, int int_1, double double_2)
	{
		double num = smethod_47(double_1, int_0, int_1, double_2);
		return num * ((double)int_1 / (double)(int_1 - 1));
	}

	internal static double smethod_47(double[] double_1, int int_0, int int_1, double double_2)
	{
		double num = 0.0;
		for (int i = 0; i < int_1; i++)
		{
			double num2 = double_1[i * int_0] - double_2;
			num += (num2 * num2 - num) / (double)(i + 1);
		}
		return num;
	}

	internal static object smethod_48(double[] double_1, double[] double_2, double double_3, double double_4)
	{
		int num = double_1.Length;
		int num2 = double_2.Length;
		if (num != num2)
		{
			return ErrorType.NA;
		}
		double num3 = 0.0;
		int num4 = 0;
		while (true)
		{
			if (num4 < num2)
			{
				if (double_2[num4] <= 0.0 || !(double_2[num4] <= 1.0))
				{
					break;
				}
				num4++;
				continue;
			}
			if (smethod_23(double_2) > 1.0)
			{
				return ErrorType.Number;
			}
			for (int i = 0; i < num; i++)
			{
				if (double_1[i] <= double_4 && double_1[i] >= double_3)
				{
					num3 += double_2[i];
				}
			}
			return num3;
		}
		return ErrorType.Number;
	}

	internal static object smethod_49(double[] double_1, double[] double_2, double double_3)
	{
		int num = double_1.Length;
		int num2 = double_2.Length;
		if (num != num2)
		{
			return ErrorType.NA;
		}
		double num3 = 0.0;
		int num4 = 0;
		while (true)
		{
			if (num4 < num2)
			{
				if (double_2[num4] <= 0.0 || !(double_2[num4] <= 1.0))
				{
					break;
				}
				num4++;
				continue;
			}
			if (smethod_23(double_2) > 1.0)
			{
				return ErrorType.Number;
			}
			for (int i = 0; i < num; i++)
			{
				if (double_1[i] == double_3)
				{
					num3 = double_2[i];
					break;
				}
			}
			return num3;
		}
		return ErrorType.Number;
	}

	internal static object smethod_50(double double_1, double double_2, double double_3)
	{
		if (!(double_1 < 0.0) && !(double_1 > 1.0) && double_3 > 0.0)
		{
			double num = Class1665.smethod_0(double_1);
			return Math.Exp(double_2 + double_3 * num);
		}
		return ErrorType.Number;
	}

	internal static object smethod_51(double double_1, double double_2, double double_3)
	{
		if (!(double_1 <= 0.0) && double_3 > 0.0)
		{
			double num = (Math.Log(double_1) - double_2) / double_3;
			return Class1665.smethod_3(num);
		}
		return ErrorType.Number;
	}

	internal static object smethod_52(double double_1, double double_2, int int_0)
	{
		if (!(double_1 <= 0.0) && !(double_1 >= 1.0) && !(double_2 <= 0.0) && int_0 >= 1)
		{
			double num = Class1665.smethod_0(1.0 - double_1 / 2.0);
			return num * double_2 / Math.Sqrt(int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_53(double[] double_1, double[] double_2)
	{
		if (double_1.Length != 0 && double_2.Length != 0)
		{
			if (double_1.Length != double_2.Length)
			{
				return ErrorType.NA;
			}
			double num = smethod_39(double_1, 1, double_1.Length);
			double num2 = smethod_39(double_2, 1, double_2.Length);
			double num3 = 0.0;
			int num4 = 0;
			for (num4 = 0; num4 < double_1.Length; num4++)
			{
				double num5 = double_1[num4] - num;
				double num6 = double_2[num4] - num2;
				num3 += num5 * num6;
			}
			return num3 / (double)double_1.Length;
		}
		return ErrorType.Div;
	}

	internal static object smethod_54(int int_0, double double_1, double double_2)
	{
		if (int_0 >= 0 && !(double_1 < 0.0) && !(double_1 > 1.0) && !(double_2 < 0.0) && double_2 <= 1.0)
		{
			int num = 0;
			double num2 = 0.0;
			bool isError = false;
			for (num = 0; num <= int_0; num++)
			{
				num2 += smethod_20(num, int_0, double_1, Cumulative: false, out isError);
				if (num2 >= double_2)
				{
					break;
				}
			}
			num = ((num > int_0) ? int_0 : num);
			return (double)num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_55(double[] double_1)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.Number;
		}
		if (!(smethod_24(double_1) is double num))
		{
			return ErrorType.Number;
		}
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += Math.Abs(double_1[i] - num);
		}
		return num2 / (double)double_1.Length;
	}

	internal static object smethod_56(double[] double_1)
	{
		int num = double_1.Length;
		double num2 = smethod_39(double_1, 1, num);
		double num3 = 0.0;
		for (int i = 0; i < num; i++)
		{
			double num4 = (double_1[i] - num2) * (double_1[i] - num2);
			num3 += num4;
		}
		return num3;
	}

	internal static object smethod_57(double double_1)
	{
		if (!(double_1 <= -1.0) && double_1 < 1.0)
		{
			double num = Math.Log((1.0 + double_1) / (1.0 - double_1));
			return num / 2.0;
		}
		return ErrorType.Number;
	}

	internal static object smethod_58(double double_1)
	{
		double num = (Math.Exp(2.0 * double_1) - 1.0) / (Math.Exp(2.0 * double_1) + 1.0);
		return num;
	}

	internal static object smethod_59(double[][] double_1, double[][] double_2)
	{
		int num = double_1.Length;
		int num2 = double_2.Length;
		if (num != num2)
		{
			return ErrorType.NA;
		}
		double num3 = 0.0;
		bool isError = false;
		int num4 = (num - 1) * (double_1[0].Length - 1);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < double_1[i].Length; j++)
			{
				num3 += (double_1[i][j] - double_2[i][j]) * (double_1[i][j] - double_2[i][j]) / double_2[i][j];
			}
		}
		num3 = smethod_6(num3, num4, out isError);
		return num3;
	}

	internal static object smethod_60(double double_1)
	{
		if (double_1 < 0.0)
		{
			return ErrorType.Number;
		}
		return Class1657.smethod_8(double_1);
	}

	internal static object smethod_61(double[] double_1)
	{
		int num = double_1.Length;
		if (num <= 0)
		{
			return ErrorType.Number;
		}
		double num2 = 0.0;
		int num3 = 0;
		while (true)
		{
			if (num3 < num)
			{
				if (!(double_1[num3] > 0.0))
				{
					break;
				}
				num2 += 1.0 / double_1[num3];
				num3++;
				continue;
			}
			return (double)num / num2;
		}
		return ErrorType.Number;
	}

	internal static object smethod_62(double double_1, double double_2, double double_3, double double_4)
	{
		if (!(double_1 < 0.0) && !(double_1 > ((double_2 < double_3) ? double_2 : double_3)) && !(double_2 < 0.0) && !(double_2 > double_4) && !(double_3 < 0.0) && !(double_3 > double_4) && double_4 >= 0.0)
		{
			double_1 = Math.Floor(double_1);
			double_2 = Math.Floor(double_2);
			double_3 = Math.Floor(double_3);
			double_4 = Math.Floor(double_4);
			double num = smethod_34(double_3, double_1) * smethod_34(double_4 - double_3, double_2 - double_1) / smethod_34(double_4, double_2);
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_63(double double_1, double double_2, double double_3)
	{
		if (!(double_1 < 0.0) && !(double_2 < 0.0) && !(double_3 < 0.0) && double_3 <= 1.0)
		{
			double num = 1.0 - double_3;
			double num2 = Math.Pow(double_3, double_2);
			for (double num3 = 0.0; num3 < double_1; num3 += 1.0)
			{
				num2 *= (num3 + double_2) / (num3 + 1.0) * num;
			}
			return num2;
		}
		return ErrorType.Number;
	}

	internal static object smethod_64(double[] double_1, double double_2, double double_3)
	{
		if (double_3 < 1.0)
		{
			return ErrorType.Number;
		}
		int num = 0;
		int num2 = -1;
		bool flag = false;
		double num3 = 0.0;
		int num4 = double_1.Length;
		Array.Sort(double_1);
		for (num = 0; num < num4; num++)
		{
			if (double_1[num] < double_2)
			{
				num2++;
			}
			else if (double_1[num] == double_2)
			{
				flag = true;
				break;
			}
		}
		num3 = ((!flag) ? (((double)num2 + (double_2 - double_1[num2]) / (double_1[num2 + 1] - double_1[num2])) / (double)(num4 - 1)) : ((double)num / (double)(num4 - 1)));
		double num5 = Math.Pow(10.0, double_3);
		return (double)(int)(num5 * num3) / num5;
	}

	internal static object smethod_65(double[] double_1, double double_2)
	{
		return smethod_64(double_1, double_2, 3.0);
	}

	internal static object smethod_66(double[] double_1, double double_2, double double_3)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.NA;
		}
		double num = smethod_39(double_1, 1, double_1.Length);
		double num2 = (num - double_2) / (double_3 / Math.Sqrt(double_1.Length));
		double num3 = 1.0 - Class1665.smethod_3(num2);
		return num3;
	}

	internal static object smethod_67(double[] double_1, double double_2)
	{
		if (double_1.Length == 0)
		{
			return ErrorType.NA;
		}
		double num = smethod_39(double_1, 1, double_1.Length);
		double num2 = smethod_45(double_1, 1, double_1.Length);
		double num3 = (num - double_2) / Math.Sqrt(num2 / (double)double_1.Length);
		double num4 = 1.0 - Class1665.smethod_3(num3);
		return num4;
	}
}
