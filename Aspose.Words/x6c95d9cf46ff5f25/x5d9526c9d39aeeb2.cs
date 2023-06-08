using System;
using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal struct x5d9526c9d39aeeb2
{
	private float x7f0aee02ed2da884;

	private float x0ad43617ea8df845;

	private float x301c1d1c0870d859;

	private int x9cd1012a0ea83ce7;

	public float x42ebf511e363e540 => x7f0aee02ed2da884;

	public float x376fa6aec4a1bfe6 => x0ad43617ea8df845;

	public float x8e8f6cc6a0756b05
	{
		get
		{
			return x301c1d1c0870d859;
		}
		set
		{
			x301c1d1c0870d859 = value;
		}
	}

	public int xda71bf6f7c07c3bc => x9cd1012a0ea83ce7;

	public x5d9526c9d39aeeb2(float h, float s, float b)
	{
		x9cd1012a0ea83ce7 = 255;
		x7f0aee02ed2da884 = x15e971129fd80714.xe193c76ba76a5afc(h, 0f, 255f);
		x0ad43617ea8df845 = x15e971129fd80714.xe193c76ba76a5afc(s, 0f, 255f);
		x301c1d1c0870d859 = x15e971129fd80714.xe193c76ba76a5afc(b, 0f, 255f);
	}

	public x5d9526c9d39aeeb2(int a, float h, float s, float b)
	{
		x9cd1012a0ea83ce7 = a;
		x7f0aee02ed2da884 = x15e971129fd80714.xe193c76ba76a5afc(h, 0f, 255f);
		x0ad43617ea8df845 = x15e971129fd80714.xe193c76ba76a5afc(s, 0f, 255f);
		x301c1d1c0870d859 = x15e971129fd80714.xe193c76ba76a5afc(b, 0f, 255f);
	}

	public x5d9526c9d39aeeb2(x26d9ecb4bdf0456d color)
	{
		x9cd1012a0ea83ce7 = color.xda71bf6f7c07c3bc;
		x7f0aee02ed2da884 = 0f;
		x0ad43617ea8df845 = 0f;
		x301c1d1c0870d859 = 0f;
		float num = color.xc613adc4330033f3;
		float num2 = color.x26463655896fd90a;
		float num3 = color.x8e8f6cc6a0756b05;
		float num4 = Math.Max(num, Math.Max(num2, num3));
		if (num4 <= 0f)
		{
			return;
		}
		float num5 = Math.Min(num, Math.Min(num2, num3));
		float num6 = num4 - num5;
		if (num4 > num5)
		{
			if (num2 == num4)
			{
				x7f0aee02ed2da884 = (num3 - num) / num6 * 60f + 120f;
			}
			else if (num3 == num4)
			{
				x7f0aee02ed2da884 = (num - num2) / num6 * 60f + 240f;
			}
			else if (num3 > num2)
			{
				x7f0aee02ed2da884 = (num2 - num3) / num6 * 60f + 360f;
			}
			else
			{
				x7f0aee02ed2da884 = (num2 - num3) / num6 * 60f;
			}
			if (x7f0aee02ed2da884 < 0f)
			{
				x7f0aee02ed2da884 += 360f;
			}
		}
		else
		{
			x7f0aee02ed2da884 = 0f;
		}
		x7f0aee02ed2da884 *= 17f / 24f;
		x0ad43617ea8df845 = num6 / num4 * 255f;
		x301c1d1c0870d859 = num4;
	}

	public x26d9ecb4bdf0456d x1659cb35054965d4()
	{
		double xbcea506a33cf = x301c1d1c0870d859;
		double xbcea506a33cf2 = x301c1d1c0870d859;
		double xbcea506a33cf3 = x301c1d1c0870d859;
		if (x0ad43617ea8df845 != 0f)
		{
			double num = x301c1d1c0870d859;
			double num2 = x301c1d1c0870d859 * x0ad43617ea8df845 / 255f;
			double num3 = (double)x301c1d1c0870d859 - num2;
			double num4 = x7f0aee02ed2da884 * 360f / 255f;
			if (num4 < 60.0)
			{
				xbcea506a33cf = num;
				xbcea506a33cf2 = num4 * num2 / 60.0 + num3;
				xbcea506a33cf3 = num3;
			}
			else if (num4 < 120.0)
			{
				xbcea506a33cf = (0.0 - (num4 - 120.0)) * num2 / 60.0 + num3;
				xbcea506a33cf2 = num;
				xbcea506a33cf3 = num3;
			}
			else if (num4 < 180.0)
			{
				xbcea506a33cf = num3;
				xbcea506a33cf2 = num;
				xbcea506a33cf3 = (num4 - 120.0) * num2 / 60.0 + num3;
			}
			else if (num4 < 240.0)
			{
				xbcea506a33cf = num3;
				xbcea506a33cf2 = (0.0 - (num4 - 240.0)) * num2 / 60.0 + num3;
				xbcea506a33cf3 = num;
			}
			else if (num4 < 300.0)
			{
				xbcea506a33cf = (num4 - 240.0) * num2 / 60.0 + num3;
				xbcea506a33cf2 = num3;
				xbcea506a33cf3 = num;
			}
			else if (num4 <= 360.0)
			{
				xbcea506a33cf = num;
				xbcea506a33cf2 = num3;
				xbcea506a33cf3 = (0.0 - (num4 - 360.0)) * num2 / 60.0 + num3;
			}
			else
			{
				xbcea506a33cf = 0.0;
				xbcea506a33cf2 = 0.0;
				xbcea506a33cf3 = 0.0;
			}
		}
		return new x26d9ecb4bdf0456d(x9cd1012a0ea83ce7, x15e971129fd80714.x43fcc3f62534530b(x15e971129fd80714.xe193c76ba76a5afc(xbcea506a33cf, 0.0, 255.0)), x15e971129fd80714.x43fcc3f62534530b(x15e971129fd80714.xe193c76ba76a5afc(xbcea506a33cf2, 0.0, 255.0)), x15e971129fd80714.x43fcc3f62534530b(x15e971129fd80714.xe193c76ba76a5afc(xbcea506a33cf3, 0.0, 255.0)));
	}

	public static x26d9ecb4bdf0456d xd597678dc791ff8e(x26d9ecb4bdf0456d x3c4da2980d043c95, float x921cdb7a02f3a9e5)
	{
		x5d9526c9d39aeeb2 x5d9526c9d39aeeb3 = new x5d9526c9d39aeeb2(x3c4da2980d043c95);
		x5d9526c9d39aeeb3.x7f0aee02ed2da884 += x921cdb7a02f3a9e5;
		x5d9526c9d39aeeb3.x7f0aee02ed2da884 = x15e971129fd80714.xe193c76ba76a5afc(x5d9526c9d39aeeb3.x7f0aee02ed2da884, 0f, 255f);
		return x5d9526c9d39aeeb3.x1659cb35054965d4();
	}

	public static x26d9ecb4bdf0456d x18a44192f8f208b8(x26d9ecb4bdf0456d x3c4da2980d043c95, float x6ad6d04a520050bd)
	{
		x5d9526c9d39aeeb2 x5d9526c9d39aeeb3 = new x5d9526c9d39aeeb2(x3c4da2980d043c95);
		x5d9526c9d39aeeb3.x0ad43617ea8df845 += x6ad6d04a520050bd;
		x5d9526c9d39aeeb3.x0ad43617ea8df845 = x15e971129fd80714.xe193c76ba76a5afc(x5d9526c9d39aeeb3.x0ad43617ea8df845, 0f, 255f);
		return x5d9526c9d39aeeb3.x1659cb35054965d4();
	}

	public static x26d9ecb4bdf0456d x128319556e0855e3(x26d9ecb4bdf0456d x3c4da2980d043c95, float x1574fa02b4d3d8fe)
	{
		x5d9526c9d39aeeb2 x5d9526c9d39aeeb3 = new x5d9526c9d39aeeb2(x3c4da2980d043c95);
		x5d9526c9d39aeeb3.x301c1d1c0870d859 += x1574fa02b4d3d8fe;
		x5d9526c9d39aeeb3.x301c1d1c0870d859 = x15e971129fd80714.xe193c76ba76a5afc(x5d9526c9d39aeeb3.x301c1d1c0870d859, 0f, 255f);
		return x5d9526c9d39aeeb3.x1659cb35054965d4();
	}
}
