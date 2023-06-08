using System;
using Aspose.Cells;

namespace ns12;

internal class Class1341
{
	internal static double smethod_0(double double_0, double double_1, double double_2, double[] double_3)
	{
		double num = 0.0;
		double num2 = 1.0;
		for (int i = 0; i < double_3.Length; i++)
		{
			num2 = Math.Pow(double_0, double_1 + (double)i * double_2);
			num += double_3[i] * num2;
		}
		return num;
	}

	internal static double smethod_1(double[] double_0, double[] double_1)
	{
		double num = 0.0;
		for (int i = 0; i < double_0.Length; i++)
		{
			num += double_0[i] * double_0[i] - double_1[i] * double_1[i];
		}
		return num;
	}

	internal static double smethod_2(double[] double_0, double[] double_1)
	{
		double num = 0.0;
		for (int i = 0; i < double_0.Length; i++)
		{
			num += double_0[i] * double_0[i] + double_1[i] * double_1[i];
		}
		return num;
	}

	internal static double smethod_3(double[] double_0, double[] double_1)
	{
		double num = 0.0;
		for (int i = 0; i < double_0.Length; i++)
		{
			num += (double_0[i] - double_1[i]) * (double_0[i] - double_1[i]);
		}
		return num;
	}

	internal static double smethod_4(double[] double_0)
	{
		double num = 0.0;
		for (int i = 0; i < double_0.Length; i++)
		{
			num += double_0[i] * double_0[i];
		}
		return num;
	}

	internal static string smethod_5(int int_0, int int_1)
	{
		int[] array = new int[13];
		string[] array2 = new string[13];
		int num = 0;
		string text = "";
		array[0] = 1000;
		array[1] = 900;
		array[2] = 500;
		array[3] = 400;
		array[4] = 100;
		array[5] = 90;
		array[6] = 50;
		array[7] = 40;
		array[8] = 10;
		array[9] = 9;
		array[10] = 5;
		array[11] = 4;
		array[12] = 1;
		array2[0] = "M";
		array2[1] = "CM";
		array2[2] = "D";
		array2[3] = "CD";
		array2[4] = "C";
		array2[5] = "XC";
		array2[6] = "L";
		array2[7] = "XL";
		array2[8] = "X";
		array2[9] = "IX";
		array2[10] = "V";
		array2[11] = "IV";
		array2[12] = "I";
		while (int_0 > 0)
		{
			while (int_0 >= array[num])
			{
				int_0 -= array[num];
				text += array2[num];
			}
			num++;
		}
		return text;
	}

	internal static double smethod_6(int[] int_0)
	{
		int num = 0;
		double num2 = 1.0;
		for (int i = 0; i < int_0.Length; i++)
		{
			num += int_0[i];
			num2 *= smethod_14(int_0[i]);
		}
		return smethod_14(num) / num2;
	}

	internal static double smethod_7(double double_0)
	{
		if (Math.Abs(double_0 % 2.0) < 1E-14)
		{
			return double_0;
		}
		double num = ((double_0 >= 0.0) ? 1 : (-1));
		double_0 = Math.Abs(double_0);
		double_0 += 1.0;
		double_0 = Math.Floor(double_0);
		if (double_0 % 2.0 < 1E-14)
		{
			return num * double_0;
		}
		return num * (double_0 + 1.0);
	}

	internal static double smethod_8(double double_0)
	{
		double_0 = Math.Ceiling(double_0);
		double num = ((double_0 >= 0.0) ? 1 : (-1));
		double_0 = Math.Abs(double_0);
		if (double_0 % 2.0 <= 1E-14)
		{
			return num * (double_0 + 1.0);
		}
		return num * double_0;
	}

	internal static double smethod_9(int int_0, int int_1)
	{
		return (double)(int_0 * int_1) / smethod_12(int_0, int_1);
	}

	internal static double smethod_10(double[] double_0)
	{
		int num = (int)smethod_11(double_0);
		double num2 = double_0[0];
		for (int i = 1; i < double_0.Length; i++)
		{
			num2 = num2 * double_0[i] / (double)num;
		}
		return num2;
	}

	internal static double smethod_11(double[] double_0)
	{
		int num = (int)double_0[0];
		for (int i = 1; i < double_0.Length; i++)
		{
			num = (int)smethod_12(num, (int)double_0[i]);
		}
		return num;
	}

	internal static double smethod_12(int int_0, int int_1)
	{
		if (int_0 == 0)
		{
			return int_1;
		}
		if (int_1 == 0)
		{
			return int_0;
		}
		if (int_0 < int_1)
		{
			int num = int_0;
			int_0 = int_1;
			int_1 = num;
		}
		while (int_1 != 0)
		{
			int num2 = int_0 % int_1;
			int_0 = int_1;
			int_1 = num2;
		}
		return int_0;
	}

	internal static double smethod_13(int int_0)
	{
		double num = 1.0;
		for (int num2 = int_0; num2 > 1; num2 -= 2)
		{
			num *= (double)num2;
		}
		return num;
	}

	internal static double smethod_14(int int_0)
	{
		double num = 1.0;
		for (int i = 2; i <= int_0; i++)
		{
			num *= (double)i;
		}
		return num;
	}

	internal static object smethod_15(double double_0, double double_1)
	{
		if (!(double_0 < 0.0) && !(double_1 < 0.0) && double_0 >= double_1)
		{
			int num = (int)double_0;
			int num2 = (int)double_1;
			return smethod_14(num) / (smethod_14(num2) * smethod_14(num - num2));
		}
		return ErrorType.Number;
	}
}
