using System;
using Aspose.Cells;

namespace ns12;

internal class Class1342
{
	internal static object smethod_0(double[] double_0, int int_0, int int_1, double[] double_1, int int_2, int int_3)
	{
		double num = smethod_3(double_0, int_0, int_1);
		double num2 = smethod_3(double_1, int_2, int_3);
		double num3 = smethod_4(double_0, int_0, int_1, double_1, int_2, int_3);
		double num4 = (num - num2) / Math.Sqrt(num3 * (1.0 / (double)int_1 + 1.0 / (double)int_3));
		return num4;
	}

	internal static object smethod_1(double double_0, double double_1, double double_2, double double_3, int int_0, int int_1)
	{
		double num = (double_0 - double_1) / Math.Sqrt(double_2 / (double)int_0 + double_3 / (double)int_1);
		return num;
	}

	internal static object smethod_2(double double_0, int int_0, double double_1, int int_1)
	{
		double num = (double_0 / (double)int_0 + double_1 / (double)int_1) * (double_0 / (double)int_0 + double_1 / (double)int_1) / (double_0 / (double)int_0 * (double_0 / (double)int_0) / (double)(int_0 - 1) + double_1 / (double)int_1 * (double_1 / (double)int_1) / (double)(int_1 - 1));
		return num;
	}

	internal static double smethod_3(double[] double_0, int int_0, int int_1)
	{
		double num = 0.0;
		for (int i = 0; i < int_1; i++)
		{
			num += (double_0[i * int_0] - num) / (double)(i + 1);
		}
		return num;
	}

	internal static double smethod_4(double[] double_0, int int_0, int int_1, double[] double_1, int int_2, int int_3)
	{
		double num = smethod_5(double_0, int_0, int_1);
		double num2 = smethod_5(double_1, int_2, int_3);
		return ((double)(int_1 - 1) * num + (double)(int_3 - 1) * num2) / (double)(int_1 + int_3 - 2);
	}

	internal static double smethod_5(double[] double_0, int int_0, int int_1)
	{
		double double_ = smethod_3(double_0, int_0, int_1);
		return smethod_6(double_0, int_0, int_1, double_);
	}

	internal static double smethod_6(double[] double_0, int int_0, int int_1, double double_1)
	{
		double num = smethod_7(double_0, int_0, int_1, double_1);
		return num * ((double)int_1 / (double)(int_1 - 1));
	}

	internal static double smethod_7(double[] double_0, int int_0, int int_1, double double_1)
	{
		double num = 0.0;
		for (int i = 0; i < int_1; i++)
		{
			double num2 = double_0[i * int_0] - double_1;
			num += (num2 * num2 - num) / (double)(i + 1);
		}
		return num;
	}

	internal static object smethod_8(double[] double_0, double[] double_1)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = double_0.Length;
		for (int i = 0; i < num4; i++)
		{
			num3 = double_0[i] - double_1[i];
			num += num3;
			num2 += num3 * num3;
		}
		double value = num / ((double)num4 * Math.Sqrt(((double)num4 * num2 - num * num) / (double)(num4 * num4 * (num4 - 1))));
		return Math.Abs(value);
	}

	internal static object smethod_9(double[] double_0, double[] double_1, int int_0, int int_1)
	{
		bool isError = false;
		double num = 0.0;
		object obj;
		if (int_1 == 1)
		{
			if (double_0.Length != double_1.Length)
			{
				return ErrorType.NA;
			}
			obj = smethod_8(double_0, double_1);
			num = double_0.Length - 1;
		}
		else if (int_1 == 2)
		{
			obj = smethod_0(double_0, 1, double_0.Length, double_1, 1, double_1.Length);
			num = double_0.Length + double_1.Length - 2;
		}
		else
		{
			if (int_1 != 3)
			{
				return ErrorType.Number;
			}
			double num2 = smethod_5(double_0, 1, double_0.Length);
			double num3 = smethod_5(double_1, 1, double_1.Length);
			double double_2 = smethod_3(double_0, 1, double_0.Length);
			double double_3 = smethod_3(double_1, 1, double_1.Length);
			obj = smethod_1(double_2, double_3, num2, num3, double_0.Length, double_1.Length);
			num = (double)smethod_2(num2, double_0.Length, num3, double_1.Length);
		}
		double num4 = Class1668.smethod_4((double)obj, num, int_0, out isError);
		return num4;
	}
}
