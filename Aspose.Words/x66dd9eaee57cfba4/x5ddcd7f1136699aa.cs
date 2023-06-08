using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x5ddcd7f1136699aa
{
	private const int x26cdd3a6c72781fa = 1024;

	private xf50d3346568ee59f x8dae185bf7c363f8;

	private readonly x2a59e7d832edc719 xc72926de6b6361e2;

	public x2a59e7d832edc719 x4d7474e8f1849803 => xc72926de6b6361e2;

	public x5ddcd7f1136699aa(int EMHeight)
	{
		xc72926de6b6361e2 = new x2a59e7d832edc719(1024f / (float)EMHeight);
	}

	public xab391c46ff9a0a38 x77be53ce49261911()
	{
		return x77be53ce49261911(xbd085ec798f2ed62: true);
	}

	public xab391c46ff9a0a38 x77be53ce49261911(bool xbd085ec798f2ed62)
	{
		int num = ((!xbd085ec798f2ed62) ? 1 : (-1));
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x8dae185bf7c363f8 = xc72926de6b6361e2.get_xe6d4b1b411ed94b5(0);
		x8dae185bf7c363f8.xc5d85e3237ac7ff9 = true;
		xf50d3346568ee59f xf50d3346568ee59f2 = x8dae185bf7c363f8;
		x1cab6af0a41b70e.xd6b6ed77479ef68c(new x60c040f35bb272aa(new float[2]
		{
			x8dae185bf7c363f8.x8df91a2f90079e88,
			num * x8dae185bf7c363f8.xc821290d7ecc08bf
		}));
		for (int i = 1; i <= xc72926de6b6361e2.xd44988f225497f3a; i++)
		{
			xf50d3346568ee59f xf50d3346568ee59f3 = ((i >= xc72926de6b6361e2.xd44988f225497f3a || xf50d3346568ee59f2.x4792a30c8e2cad0a) ? xeaff1ceb3b128e85(xc72926de6b6361e2.get_xe6d4b1b411ed94b5(i)) : xc72926de6b6361e2.get_xe6d4b1b411ed94b5(i));
			if (xf50d3346568ee59f3.x3608e1d09b3fd55d || xf50d3346568ee59f3.xc5d85e3237ac7ff9)
			{
				x1cab6af0a41b70e.xd6b6ed77479ef68c(new x60c040f35bb272aa(new float[2]
				{
					xf50d3346568ee59f3.x8df91a2f90079e88,
					num * xf50d3346568ee59f3.xc821290d7ecc08bf
				}));
			}
			else
			{
				xf50d3346568ee59f xf50d3346568ee59f4 = ((i + 1 >= xc72926de6b6361e2.xd44988f225497f3a || xf50d3346568ee59f3.x4792a30c8e2cad0a) ? xeaff1ceb3b128e85(xc72926de6b6361e2.get_xe6d4b1b411ed94b5(i + 1)) : xc72926de6b6361e2.get_xe6d4b1b411ed94b5(i + 1));
				if (xf50d3346568ee59f4.x3608e1d09b3fd55d)
				{
					x1cab6af0a41b70e.xd6b6ed77479ef68c(new x519b1bd0625473ff(new PointF(xf50d3346568ee59f2.x8df91a2f90079e88, num * xf50d3346568ee59f2.xc821290d7ecc08bf), new PointF(xf50d3346568ee59f3.x8df91a2f90079e88, num * xf50d3346568ee59f3.xc821290d7ecc08bf), new PointF(xf50d3346568ee59f4.x8df91a2f90079e88, num * xf50d3346568ee59f4.xc821290d7ecc08bf)));
					xf50d3346568ee59f2 = xf50d3346568ee59f3;
					xf50d3346568ee59f3 = xf50d3346568ee59f4;
					i++;
				}
				else
				{
					int num2 = x15e971129fd80714.x43fcc3f62534530b((float)(xf50d3346568ee59f4.x8df91a2f90079e88 - xf50d3346568ee59f3.x8df91a2f90079e88) / 2f);
					int num3 = x15e971129fd80714.x43fcc3f62534530b((float)(xf50d3346568ee59f4.xc821290d7ecc08bf - xf50d3346568ee59f3.xc821290d7ecc08bf) / 2f);
					xf50d3346568ee59f xf50d3346568ee59f5 = new xf50d3346568ee59f(num2, num3, xf50d3346568ee59f3.x8df91a2f90079e88 + num2, xf50d3346568ee59f3.xc821290d7ecc08bf + num3, isOnCurve: true, isEndOfContour: false);
					x1cab6af0a41b70e.xd6b6ed77479ef68c(new x519b1bd0625473ff(new PointF(xf50d3346568ee59f2.x8df91a2f90079e88, num * xf50d3346568ee59f2.xc821290d7ecc08bf), new PointF(xf50d3346568ee59f3.x8df91a2f90079e88, num * xf50d3346568ee59f3.xc821290d7ecc08bf), new PointF(xf50d3346568ee59f5.x8df91a2f90079e88, num * xf50d3346568ee59f5.xc821290d7ecc08bf)));
					xf50d3346568ee59f2 = xf50d3346568ee59f3;
					xf50d3346568ee59f3 = xf50d3346568ee59f5;
				}
			}
			if (xf50d3346568ee59f2.x4792a30c8e2cad0a)
			{
				x1cab6af0a41b70e = xed972eaa463667ac(x1cab6af0a41b70e, xab391c46ff9a0a);
				if (i < xc72926de6b6361e2.xd44988f225497f3a)
				{
					xf50d3346568ee59f3 = xc72926de6b6361e2.get_xe6d4b1b411ed94b5(i);
				}
			}
			xf50d3346568ee59f2 = xf50d3346568ee59f3;
		}
		if (x8dae185bf7c363f8 != null)
		{
			x1cab6af0a41b70e.xd6b6ed77479ef68c(new x60c040f35bb272aa(new float[2]
			{
				x8dae185bf7c363f8.x8df91a2f90079e88,
				num * x8dae185bf7c363f8.xc821290d7ecc08bf
			}));
		}
		xed972eaa463667ac(x1cab6af0a41b70e, xab391c46ff9a0a);
		return xab391c46ff9a0a;
	}

	private static x1cab6af0a41b70e2 xed972eaa463667ac(x1cab6af0a41b70e2 x6ac16bf6efd00832, xab391c46ff9a0a38 xe125219852864557)
	{
		x6ac16bf6efd00832.x5e6c52cb3256cc85 = true;
		xe125219852864557.xd6b6ed77479ef68c(x6ac16bf6efd00832);
		return new x1cab6af0a41b70e2();
	}

	private xf50d3346568ee59f xeaff1ceb3b128e85(xf50d3346568ee59f x61ae3384fa596bd5)
	{
		xf50d3346568ee59f result = x8dae185bf7c363f8;
		if (x61ae3384fa596bd5 != null)
		{
			x8dae185bf7c363f8 = x61ae3384fa596bd5;
			x8dae185bf7c363f8.xc5d85e3237ac7ff9 = true;
		}
		return result;
	}
}
