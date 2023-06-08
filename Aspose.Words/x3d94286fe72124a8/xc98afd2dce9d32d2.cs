using System.Drawing;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class xc98afd2dce9d32d2
{
	private readonly xb8e7e788f6d59708 x9b1777152cf410e1;

	private bool x4fb3a8cc36f59f6d;

	private RectangleF xbbb61bb1f3d245fb;

	internal xb8e7e788f6d59708 xa1eafe7821eb4aab => x9b1777152cf410e1;

	internal xc98afd2dce9d32d2(xb8e7e788f6d59708 canvas)
	{
		x9b1777152cf410e1 = canvas;
		x4fb3a8cc36f59f6d = false;
		xbbb61bb1f3d245fb = RectangleF.Empty;
	}

	internal RectangleF x0858b12a935f219f(x7721ad963b03c6eb x8d3f74e5f925679c)
	{
		if (!x4fb3a8cc36f59f6d)
		{
			xf009a0b7decf37ab(x8d3f74e5f925679c);
		}
		return xbbb61bb1f3d245fb;
	}

	private void xf009a0b7decf37ab(x7721ad963b03c6eb x8d3f74e5f925679c)
	{
		x4fb3a8cc36f59f6d = true;
		xbbb61bb1f3d245fb = x77e280b75b2323b7.xae3e25d147fd1867(x8d3f74e5f925679c, x9b1777152cf410e1);
	}
}
