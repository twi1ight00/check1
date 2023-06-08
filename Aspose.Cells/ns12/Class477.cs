using System;

namespace ns12;

internal abstract class Class477
{
	internal double double_0;

	protected virtual double vmethod_0(double double_1)
	{
		return 0.0;
	}

	protected virtual void vmethod_1(double double_1, double[] double_2)
	{
	}

	public Class477()
	{
	}

	public bool method_0(ref double double_1, int int_0, double double_2)
	{
		double num = 0.0;
		double[] array = new double[2];
		int num2 = int_0;
		double num3 = double_1;
		vmethod_1(num3, array);
		double num4 = double_2 + 1.0;
		while (!(num4 < double_2) && num2 != 0)
		{
			if (array[1] == 0.0)
			{
				array[1] = Math.Abs(double.MinValue);
			}
			num = num3 - array[0] / array[1];
			if (num <= 0.0)
			{
				num = Math.Abs(0.1);
			}
			vmethod_1(num, array);
			num4 = Math.Abs(num - num3);
			double num5 = Math.Abs(array[0]);
			if (num5 > num4)
			{
				num4 = num5;
			}
			num3 = num;
			num2--;
		}
		double_1 = num;
		return true;
	}

	public bool method_1(ref double double_1, double double_2, double double_3, double double_4)
	{
		double num = double_4 - double_3;
		double num2 = 1E-11;
		int num3 = 300;
		int num4 = 0;
		while (vmethod_0(double_3) > double_2 && vmethod_0(double_4) > double_2 && num4 < num3)
		{
			double_3 = double_4;
			double_4 += num;
			num4++;
		}
		while (vmethod_0(double_3) < double_2 && vmethod_0(double_4) < double_2 && num4 < num3)
		{
			double_4 = double_3;
			double_3 -= num;
			num4++;
			if (double_3 < 0.0)
			{
				double_3 = 0.0;
			}
		}
		while (!(Math.Abs(double_3 - double_4) <= num * num2) && num4 < num3)
		{
			double_1 = (double_3 + double_4) / 2.0;
			if (vmethod_0(double_1) > double_2)
			{
				double_3 = double_1;
			}
			else
			{
				double_4 = double_1;
			}
			num4++;
		}
		if (num4 == num3)
		{
			return false;
		}
		return true;
	}
}
