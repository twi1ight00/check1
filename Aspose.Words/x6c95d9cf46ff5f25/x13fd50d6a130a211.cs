using System;
using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal class x13fd50d6a130a211
{
	public static double xf49df313f3311164(int x7f976b7a7a87b378)
	{
		double num = (double)x7f976b7a7a87b378 / 255.0;
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

	public static int xad84963169a664d8(double x7f976b7a7a87b378)
	{
		double num = 0.0;
		num = ((x7f976b7a7a87b378 < 0.0) ? 0.0 : ((x7f976b7a7a87b378 <= 0.0031308) ? (x7f976b7a7a87b378 * 12.92) : ((!(x7f976b7a7a87b378 < 1.0)) ? 1.0 : (1.055 * Math.Pow(x7f976b7a7a87b378, 5.0 / 12.0) - 0.055))));
		return x15e971129fd80714.x43fcc3f62534530b(num * 255.0);
	}

	public static double[] xf49df313f3311164(x26d9ecb4bdf0456d x64757caafc3acbfb)
	{
		int num = x64757caafc3acbfb.xb2c94956116ca10a();
		double[] array = new double[3];
		for (int num2 = 2; num2 >= 0; num2--)
		{
			array[num2] = xf49df313f3311164(num & 0xFF);
			num >>= 8;
		}
		return array;
	}

	public static x26d9ecb4bdf0456d xad84963169a664d8(double[] xe4c884c8c2741a60)
	{
		int num = 255;
		foreach (double x7f976b7a7a87b in xe4c884c8c2741a60)
		{
			num <<= 8;
			num |= xad84963169a664d8(x7f976b7a7a87b);
		}
		return new x26d9ecb4bdf0456d(num);
	}
}
