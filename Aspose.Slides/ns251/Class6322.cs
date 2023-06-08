using System;

namespace ns251;

internal class Class6322
{
	public static double smethod_0(int component)
	{
		double num = (double)component / 255.0;
		if (num < 0.0)
		{
			return 0.0;
		}
		if (num <= 0.04045)
		{
			return num / 12.92;
		}
		if (num <= 1.0)
		{
			return Math.Pow((num + 0.055) / 1.055, 2.4);
		}
		return 1.0;
	}

	public static int smethod_1(double value)
	{
		double num = 0.0;
		num = ((value < 0.0) ? 0.0 : ((value <= 0.0031308) ? (value * 12.92) : ((!(value < 1.0)) ? 1.0 : (1.055 * Math.Pow(value, 5.0 / 12.0) - 0.055))));
		return (int)Math.Round(num * 255.0);
	}
}
