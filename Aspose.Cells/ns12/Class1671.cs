using System;

namespace ns12;

internal class Class1671
{
	private double[] double_0;

	private double[] double_1;

	public double method_0(double xnew, double tolerance, int imax, out bool flag)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num += double_1[i];
		}
		if (num == 0.0)
		{
			flag = true;
			return 0.0;
		}
		for (int j = 0; j < imax; j++)
		{
			num3 = method_2(xnew);
			if (num3 != 0.0)
			{
				if ((!(num > 0.0) || !(num3 < 0.0)) && (!(num < 0.0) || !(num3 > 0.0)))
				{
					break;
				}
				xnew /= 2.0;
				continue;
			}
			flag = true;
			return xnew;
		}
		flag = false;
		for (int k = 0; k < imax; k++)
		{
			num2 = xnew;
			xnew = num2 - method_2(num2) / method_1(num2);
			if (!(Math.Abs(xnew - num2) > tolerance))
			{
				flag = true;
				break;
			}
		}
		return xnew;
	}

	public double method_1(double double_2)
	{
		double num = 0.0;
		double num2 = 0.0;
		double_2 += 1.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 = (double)((int)double_0[i] - (int)double_0[0]) / 365.0;
			num = ((!(double_2 >= 0.0)) ? (((int)num2 % 2 != 0) ? (num + num2 * double_1[i] * Class1374.smethod_2(0.0 - double_2, 0.0 - num2 - 1.0)) : (num + (0.0 - num2) * double_1[i] * Class1374.smethod_2(0.0 - double_2, 0.0 - num2 - 1.0))) : (num + (0.0 - num2) * double_1[i] * Class1374.smethod_2(double_2, 0.0 - num2 - 1.0)));
		}
		return num;
	}

	public double method_2(double double_2)
	{
		double num = 0.0;
		double num2 = 0.0;
		double_2 += 1.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 = (double)((int)double_0[i] - (int)double_0[0]) / 365.0;
			num = ((!(double_2 >= 0.0)) ? (((int)num2 % 2 != 0) ? (num - double_1[i] * Class1374.smethod_2(0.0 - double_2, 0.0 - num2)) : (num + double_1[i] * Class1374.smethod_2(0.0 - double_2, 0.0 - num2))) : (num + double_1[i] * Class1374.smethod_2(double_2, 0.0 - num2)));
		}
		return num;
	}

	internal object Calculate(double[] double_2, double[] double_3, double double_4)
	{
		double_1 = double_2;
		double_0 = double_3;
		bool flag = false;
		double num = method_0(double_4, 1E-08, 100, out flag);
		if (flag)
		{
			return num;
		}
		if (double_4 == 0.1)
		{
			return "#NUM!";
		}
		return Calculate(double_2, double_3, 0.1);
	}
}
