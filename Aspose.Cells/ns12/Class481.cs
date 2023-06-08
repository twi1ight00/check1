using System;

namespace ns12;

internal abstract class Class481
{
	public abstract double vmethod_0(double double_0);

	public Class481()
	{
	}

	public double method_0(double double_0, double double_1, double double_2)
	{
		double num = 0.0;
		double[] array = new double[14];
		double num2 = double_1 - double_0;
		array[0] = num2 * (vmethod_0(double_0) + vmethod_0(double_1)) / 2.0;
		int num3 = 1;
		int num4 = 1;
		double num5 = double_2 + 1.0;
		while (!(num5 < double_2) && num3 <= 13)
		{
			double num6 = 0.0;
			for (int i = 0; i <= num4 - 1; i++)
			{
				double double_3 = double_0 + ((double)i + 0.5) * num2;
				num6 += vmethod_0(double_3);
			}
			num6 = (array[0] + num2 * num6) / 2.0;
			double num7 = 1.0;
			for (int j = 1; j <= num3; j++)
			{
				num7 = 4.0 * num7;
				num = (num7 * num6 - array[j - 1]) / (num7 - 1.0);
				array[j - 1] = num6;
				num6 = num;
			}
			num5 = Math.Abs(num - array[num3 - 1]);
			num3++;
			array[num3 - 1] = num;
			num4 += num4;
			num2 /= 2.0;
		}
		return num;
	}
}
