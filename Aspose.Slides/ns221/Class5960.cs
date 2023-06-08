using System;
using ns224;

namespace ns221;

internal class Class5960
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double Hue
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = Math.Min(Math.Max(value, 0.0), 1.0);
		}
	}

	public double Sat
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = Math.Min(Math.Max(value, 0.0), 1.0);
		}
	}

	public double Lum
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = Math.Min(Math.Max(value, 0.0), 1.0);
		}
	}

	public Class5960()
	{
	}

	public Class5960(Class5998 rgb)
	{
		double num = (double)rgb.R / 255.0;
		double num2 = (double)rgb.G / 255.0;
		double num3 = (double)rgb.B / 255.0;
		double num4 = Math.Max(Math.Max(num, num2), num3);
		double num5 = Math.Min(Math.Min(num, num2), num3);
		double_1 = (double_0 = (double_2 = (num4 + num5) / 2.0));
		if (num4 == num5)
		{
			double_0 = 0.0;
			double_1 = 0.0;
		}
		else
		{
			double num6 = num4 - num5;
			double_1 = ((double_2 > 0.5) ? (num6 / (2.0 - num4 - num5)) : (num6 / (num4 + num5)));
			if (num == num4)
			{
				double_0 = (num2 - num3) / num6 + (double)((num2 < num3) ? 6 : 0);
			}
			else if (num2 == num4)
			{
				double_0 = (num3 - num) / num6 + 2.0;
			}
			else if (num3 == num4)
			{
				double_0 = (num - num2) / num6 + 4.0;
			}
		}
		double_0 /= 6.0;
	}

	public Class5998 method_0()
	{
		double num;
		double num2;
		double num3;
		if (double_2 == 0.0)
		{
			num = 0.0;
			num2 = 0.0;
			num3 = 0.0;
		}
		else if (double_1 == 0.0)
		{
			num = double_2;
			num2 = double_2;
			num3 = double_2;
		}
		else
		{
			double num4 = ((double_2 < 0.5) ? (double_2 * (1.0 + double_1)) : (double_2 + double_1 - double_2 * double_1));
			double p = 2.0 * double_2 - num4;
			num = smethod_0(p, num4, double_0 + 1.0 / 3.0);
			num2 = smethod_0(p, num4, double_0);
			num3 = smethod_0(p, num4, double_0 - 1.0 / 3.0);
		}
		return Class5998.smethod_1((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
	}

	private static double smethod_0(double p, double q, double t)
	{
		if (t < 0.0)
		{
			t += 1.0;
		}
		if (t > 1.0)
		{
			t -= 1.0;
		}
		if (t < 1.0 / 6.0)
		{
			return p + (q - p) * 6.0 * t;
		}
		if (t < 0.5)
		{
			return q;
		}
		if (t < 2.0 / 3.0)
		{
			return p + (q - p) * (2.0 / 3.0 - t) * 6.0;
		}
		return p;
	}
}
