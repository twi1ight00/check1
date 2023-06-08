using System;
using System.Drawing;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x38a89dee67fc7a16;

internal class x02df97c06afacbf3
{
	private readonly double x8da4227161459355;

	private readonly double x324a4d4da800de4a;

	private readonly double x0532dd7a0f7d0d7f;

	private readonly double xda3af8c49890009d;

	public bool x7149c962c02931b3
	{
		get
		{
			if (x8da4227161459355 == 0.0 && x324a4d4da800de4a == 0.0 && x0532dd7a0f7d0d7f == 0.0)
			{
				return xda3af8c49890009d == 0.0;
			}
			return false;
		}
	}

	public bool x523ab7004b988e96
	{
		get
		{
			if (!(x8da4227161459355 > 0.0) && !(x324a4d4da800de4a > 0.0) && !(x0532dd7a0f7d0d7f > 0.0))
			{
				return xda3af8c49890009d > 0.0;
			}
			return true;
		}
	}

	public bool x95792759b737ca1f
	{
		get
		{
			if (!(x8da4227161459355 < 0.0) && !(x324a4d4da800de4a < 0.0) && !(x0532dd7a0f7d0d7f < 0.0))
			{
				return xda3af8c49890009d < 0.0;
			}
			return true;
		}
	}

	public x02df97c06afacbf3(double cropLeft, double cropRight, double cropTop, double cropBottom)
	{
		x8da4227161459355 = cropLeft;
		x324a4d4da800de4a = cropRight;
		x0532dd7a0f7d0d7f = cropTop;
		xda3af8c49890009d = cropBottom;
	}

	public RectangleF xb46e282eca4aff93(RectangleF x0d1d762ec380db87)
	{
		double num = (double)x0d1d762ec380db87.Left + (double)x0d1d762ec380db87.Width * x8da4227161459355;
		double num2 = (double)x0d1d762ec380db87.Left + (double)x0d1d762ec380db87.Width * (1.0 - x324a4d4da800de4a);
		double num3 = (double)x0d1d762ec380db87.Top + (double)x0d1d762ec380db87.Height * x0532dd7a0f7d0d7f;
		double num4 = (double)x0d1d762ec380db87.Top + (double)x0d1d762ec380db87.Height * (1.0 - xda3af8c49890009d);
		return RectangleF.FromLTRB((float)num, (float)num3, (float)num2, (float)num4);
	}

	public Rectangle x15f1bfbe780b919d(Rectangle x0d1d762ec380db87)
	{
		double xbcea506a33cf = (double)x0d1d762ec380db87.Left + (double)x0d1d762ec380db87.Width * Math.Max(0.0, x8da4227161459355);
		double xbcea506a33cf2 = (double)x0d1d762ec380db87.Left + (double)x0d1d762ec380db87.Width * (1.0 - Math.Max(0.0, x324a4d4da800de4a));
		double xbcea506a33cf3 = (double)x0d1d762ec380db87.Top + (double)x0d1d762ec380db87.Height * Math.Max(0.0, x0532dd7a0f7d0d7f);
		double xbcea506a33cf4 = (double)x0d1d762ec380db87.Top + (double)x0d1d762ec380db87.Height * (1.0 - Math.Max(0.0, xda3af8c49890009d));
		return Rectangle.FromLTRB(x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf), x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf3), x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf2), x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf4));
	}

	public RectangleF xade9cf8b9eb86a8e(RectangleF x47807e698c6282d5)
	{
		double num = 1.0 / (1.0 - Math.Min(0.0, x8da4227161459355 + x324a4d4da800de4a));
		double num2 = 1.0 / (1.0 - Math.Min(0.0, x0532dd7a0f7d0d7f + xda3af8c49890009d));
		double num3 = 0.0 - Math.Min(0.0, x8da4227161459355);
		double num4 = 0.0 - Math.Min(0.0, x324a4d4da800de4a);
		double num5 = 0.0 - Math.Min(0.0, x0532dd7a0f7d0d7f);
		double num6 = 0.0 - Math.Min(0.0, xda3af8c49890009d);
		double num7 = (double)x47807e698c6282d5.Left + (double)x47807e698c6282d5.Width * num3 * num;
		double num8 = (double)x47807e698c6282d5.Left + (double)x47807e698c6282d5.Width * (1.0 - num4 * num);
		double num9 = (double)x47807e698c6282d5.Top + (double)x47807e698c6282d5.Height * num5 * num2;
		double num10 = (double)x47807e698c6282d5.Top + (double)x47807e698c6282d5.Height * (1.0 - num6 * num2);
		return RectangleF.FromLTRB((float)num7, (float)num9, (float)num8, (float)num10);
	}

	public x3cd5d648729cd9b6 xa4e45e1d9e114000(byte[] x43e181e083db6cdf)
	{
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(x43e181e083db6cdf);
		Rectangle x0d1d762ec380db = x15f1bfbe780b919d(new Rectangle(0, 0, x3cd5d648729cd9b.xdc1bf80853046136, x3cd5d648729cd9b.xb0f146032f47c24e));
		return x3cd5d648729cd9b.xa4e45e1d9e114000(x0d1d762ec380db);
	}

	public override int GetHashCode()
	{
		return (xee62401c6b6a1ef3.GetHashCode(x8da4227161459355) >> 1) ^ (xee62401c6b6a1ef3.GetHashCode(x324a4d4da800de4a) << 3) ^ (xee62401c6b6a1ef3.GetHashCode(x0532dd7a0f7d0d7f) << 1) ^ (xee62401c6b6a1ef3.GetHashCode(xda3af8c49890009d) >> 3);
	}

	public static bool x1c140bd1078ddda1(x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		return x5edc4e0499c937b4?.x7149c962c02931b3 ?? true;
	}

	public static int x1c3a4a07dc224a14(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		int hashCode = x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf).GetHashCode();
		int num = ((x5edc4e0499c937b4 != null && x5edc4e0499c937b4.x523ab7004b988e96) ? x5edc4e0499c937b4.GetHashCode() : 0);
		return hashCode ^ num;
	}

	public static int x1c3a4a07dc224a14(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		int num = x1c3a4a07dc224a14(x43e181e083db6cdf, x5edc4e0499c937b4);
		if (xe4eb37da4d22423c != null)
		{
			num = (num * 397) ^ xe4eb37da4d22423c.GetHashCode();
		}
		return num;
	}
}
