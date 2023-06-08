using System;
using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal class x01f74f175f4a1d3d
{
	private double x2587bd395eda0985;

	private double xe88a525bb17689c2;

	private double x7d0be3576f602fee;

	public double x771e11bd2ca66cba
	{
		get
		{
			return x2587bd395eda0985;
		}
		set
		{
			x2587bd395eda0985 = x15e971129fd80714.xe193c76ba76a5afc(value, 0.0, 1.0);
		}
	}

	public double xcf8335d0074a503e
	{
		get
		{
			return xe88a525bb17689c2;
		}
		set
		{
			xe88a525bb17689c2 = x15e971129fd80714.xe193c76ba76a5afc(value, 0.0, 1.0);
		}
	}

	public double x7140fff2ddcc94a1
	{
		get
		{
			return x7d0be3576f602fee;
		}
		set
		{
			x7d0be3576f602fee = x15e971129fd80714.xe193c76ba76a5afc(value, 0.0, 1.0);
		}
	}

	public x01f74f175f4a1d3d(double hue, double sat, double lum)
	{
		x771e11bd2ca66cba = hue;
		xcf8335d0074a503e = sat;
		x7140fff2ddcc94a1 = lum;
	}

	public x01f74f175f4a1d3d(x26d9ecb4bdf0456d rgb)
	{
		double num = (double)rgb.xc613adc4330033f3 / 255.0;
		double num2 = (double)rgb.x26463655896fd90a / 255.0;
		double num3 = (double)rgb.x8e8f6cc6a0756b05 / 255.0;
		double num4 = Math.Max(Math.Max(num, num2), num3);
		double num5 = Math.Min(Math.Min(num, num2), num3);
		xe88a525bb17689c2 = (x2587bd395eda0985 = (x7d0be3576f602fee = (num4 + num5) / 2.0));
		if (num4 == num5)
		{
			x2587bd395eda0985 = 0.0;
			xe88a525bb17689c2 = 0.0;
		}
		else
		{
			double num6 = num4 - num5;
			xe88a525bb17689c2 = ((x7d0be3576f602fee > 0.5) ? (num6 / (2.0 - num4 - num5)) : (num6 / (num4 + num5)));
			if (num == num4)
			{
				x2587bd395eda0985 = (num2 - num3) / num6 + (double)((num2 < num3) ? 6 : 0);
			}
			else if (num2 == num4)
			{
				x2587bd395eda0985 = (num3 - num) / num6 + 2.0;
			}
			else if (num3 == num4)
			{
				x2587bd395eda0985 = (num - num2) / num6 + 4.0;
			}
		}
		x2587bd395eda0985 /= 6.0;
	}

	public x26d9ecb4bdf0456d x1659cb35054965d4()
	{
		double num;
		double num2;
		double num3;
		if (x7d0be3576f602fee == 0.0)
		{
			num = 0.0;
			num2 = 0.0;
			num3 = 0.0;
		}
		else if (xe88a525bb17689c2 == 0.0)
		{
			num = x7d0be3576f602fee;
			num2 = x7d0be3576f602fee;
			num3 = x7d0be3576f602fee;
		}
		else
		{
			double num4 = ((x7d0be3576f602fee < 0.5) ? (x7d0be3576f602fee * (1.0 + xe88a525bb17689c2)) : (x7d0be3576f602fee + xe88a525bb17689c2 - x7d0be3576f602fee * xe88a525bb17689c2));
			double x9c79b5ad7b769b = 2.0 * x7d0be3576f602fee - num4;
			num = x5a78dfeabb029fc1(x9c79b5ad7b769b, num4, x2587bd395eda0985 + 1.0 / 3.0);
			num2 = x5a78dfeabb029fc1(x9c79b5ad7b769b, num4, x2587bd395eda0985);
			num3 = x5a78dfeabb029fc1(x9c79b5ad7b769b, num4, x2587bd395eda0985 - 1.0 / 3.0);
		}
		return x26d9ecb4bdf0456d.xd378227c730f388c((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
	}

	private static double x5a78dfeabb029fc1(double x9c79b5ad7b769b12, double x5885c7b0b05b341e, double x3201d6d15a947682)
	{
		if (x3201d6d15a947682 < 0.0)
		{
			x3201d6d15a947682 += 1.0;
		}
		if (x3201d6d15a947682 > 1.0)
		{
			x3201d6d15a947682 -= 1.0;
		}
		if (x3201d6d15a947682 < 1.0 / 6.0)
		{
			return x9c79b5ad7b769b12 + (x5885c7b0b05b341e - x9c79b5ad7b769b12) * 6.0 * x3201d6d15a947682;
		}
		if (x3201d6d15a947682 < 0.5)
		{
			return x5885c7b0b05b341e;
		}
		if (x3201d6d15a947682 < 2.0 / 3.0)
		{
			return x9c79b5ad7b769b12 + (x5885c7b0b05b341e - x9c79b5ad7b769b12) * (2.0 / 3.0 - x3201d6d15a947682) * 6.0;
		}
		return x9c79b5ad7b769b12;
	}
}
