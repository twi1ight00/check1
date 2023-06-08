using System;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x1a62aaf14e3c5909;

internal class x5a479118db43fa5e
{
	internal double x72d92bd1aff02e37;

	internal double xe360b1885d8d4a41;

	internal double xdc1bf80853046136;

	internal double xb0f146032f47c24e;

	internal x5a479118db43fa5e(double left, double top, double width, double height)
	{
		x72d92bd1aff02e37 = left;
		xe360b1885d8d4a41 = top;
		xdc1bf80853046136 = width;
		xb0f146032f47c24e = height;
	}

	internal void x9b92b7e74232e394()
	{
		x72d92bd1aff02e37 += (xdc1bf80853046136 - xb0f146032f47c24e) / 2.0;
		xe360b1885d8d4a41 += (xb0f146032f47c24e - xdc1bf80853046136) / 2.0;
		double num = xdc1bf80853046136;
		xdc1bf80853046136 = xb0f146032f47c24e;
		xb0f146032f47c24e = num;
	}

	internal static bool x9a9096acffd23a72(double xcb83cdf6822fc99d)
	{
		xcb83cdf6822fc99d %= 360.0;
		if (xcb83cdf6822fc99d < 0.0)
		{
			xcb83cdf6822fc99d += 360.0;
		}
		if (xcb83cdf6822fc99d >= 0.0 && xcb83cdf6822fc99d < 45.0)
		{
			return false;
		}
		if (xcb83cdf6822fc99d >= 45.0 && xcb83cdf6822fc99d < 135.0)
		{
			return true;
		}
		if (xcb83cdf6822fc99d >= 135.0 && xcb83cdf6822fc99d < 225.0)
		{
			return false;
		}
		if (xcb83cdf6822fc99d >= 225.0 && xcb83cdf6822fc99d < 315.0)
		{
			return true;
		}
		if (xcb83cdf6822fc99d >= 315.0)
		{
			return false;
		}
		throw new InvalidOperationException("Unexpected angle.");
	}

	internal static void x45e7e197dcc9dd27(ShapeBase x5770cdefd8931aa9, double xa447fc54e41dfe06, double xfc2074a859a5db8c, double xc941868c59399d3e, double xaf9a0436a70689de)
	{
		double num = xa447fc54e41dfe06;
		if (xa447fc54e41dfe06 > xfc2074a859a5db8c)
		{
			xa447fc54e41dfe06 = xfc2074a859a5db8c;
			xfc2074a859a5db8c = num;
		}
		num = xc941868c59399d3e;
		if (xc941868c59399d3e > xaf9a0436a70689de)
		{
			xc941868c59399d3e = xaf9a0436a70689de;
			xaf9a0436a70689de = num;
		}
		xe63b9d2198d90be1(x5770cdefd8931aa9, x4574ea26106f0edb.x0e1fdb362561ddb2(xa447fc54e41dfe06), x4574ea26106f0edb.x0e1fdb362561ddb2(xc941868c59399d3e), x4574ea26106f0edb.x0e1fdb362561ddb2(xfc2074a859a5db8c - xa447fc54e41dfe06), x4574ea26106f0edb.x0e1fdb362561ddb2(xaf9a0436a70689de - xc941868c59399d3e));
	}

	internal static void xe63b9d2198d90be1(ShapeBase x5770cdefd8931aa9, double xa447fc54e41dfe06, double xc941868c59399d3e, double x9b0739496f8b5475, double x4d5aabc7a55b12ba)
	{
		x5a479118db43fa5e x5a479118db43fa5e2 = new x5a479118db43fa5e(xa447fc54e41dfe06, xc941868c59399d3e, x9b0739496f8b5475, x4d5aabc7a55b12ba);
		if (x9a9096acffd23a72(x5770cdefd8931aa9.Rotation))
		{
			x5a479118db43fa5e2.x9b92b7e74232e394();
		}
		x5770cdefd8931aa9.Left = x5a479118db43fa5e2.x72d92bd1aff02e37;
		x5770cdefd8931aa9.Top = x5a479118db43fa5e2.xe360b1885d8d4a41;
		x5770cdefd8931aa9.xf524ccc95fe8e714(x5a479118db43fa5e2.xdc1bf80853046136);
		x5770cdefd8931aa9.x404ab2fc377ad1ed(x5a479118db43fa5e2.xb0f146032f47c24e);
	}

	internal static x5a479118db43fa5e xf648b77e8172fa16(ShapeBase x5770cdefd8931aa9)
	{
		x5a479118db43fa5e x5a479118db43fa5e2 = new x5a479118db43fa5e(x5770cdefd8931aa9.Left, x5770cdefd8931aa9.Top, x5770cdefd8931aa9.Width, x5770cdefd8931aa9.Height);
		if (x9a9096acffd23a72(x5770cdefd8931aa9.Rotation))
		{
			x5a479118db43fa5e2.x9b92b7e74232e394();
		}
		return x5a479118db43fa5e2;
	}
}
