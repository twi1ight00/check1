using System;
using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;

namespace x06e283fdfa5dc5f0;

internal class x5f887a65c13f569c
{
	private const float x36c14602fa2a2eeb = 0.005f;

	private readonly x9ec6ce5404580fa7 xccf841029b555fe2;

	private readonly xaadf1ef8176ba89f x93f1c9bb52801bce;

	private xe841d221096c0643 x92be23f9da255ff5;

	private xe841d221096c0643 x19e42c97f4227a7a;

	private xe841d221096c0643 x7264a27427003a4e;

	private xe841d221096c0643 xc770c88ee3b92fca;

	private xe841d221096c0643 xf05382f34c1daced;

	internal xe841d221096c0643 xaf4e0fbe61814cf5 => x92be23f9da255ff5;

	internal bool x72d46409b45c5b53 => x92be23f9da255ff5 != null;

	internal x5f887a65c13f569c(x9ec6ce5404580fa7 gridType)
	{
		xccf841029b555fe2 = gridType;
		x93f1c9bb52801bce = new xaadf1ef8176ba89f();
	}

	internal void xc28dff9f03c0d48f()
	{
		if (x19e42c97f4227a7a != null)
		{
			x19e42c97f4227a7a = xf05382f34c1daced;
			x7264a27427003a4e = x19e42c97f4227a7a.x6d763e63b9853d90;
			xc770c88ee3b92fca = null;
		}
	}

	internal void xb1e2c9a68308ad60(RectangleF xdc901b9828d8600c, Border xdb200d0a72bd656e, Border xc55498ae473c1804, Border x39d4d9d592924ac5, Border xd1516a9a5bb6b163)
	{
		RectangleF rectangleF = x6b0123441d954662(xdc901b9828d8600c, xdb200d0a72bd656e, xc55498ae473c1804, x39d4d9d592924ac5, xd1516a9a5bb6b163);
		PointF pointF = new PointF(rectangleF.X, rectangleF.Y);
		xc14e33dcc753f606(pointF);
		xc1a6038e4b87b3d8(pointF);
		xa3dd1988280d6df6(rectangleF.Right, x39d4d9d592924ac5);
		x413b45190f5b64bc(rectangleF.X, x39d4d9d592924ac5);
		x8fce20973946da29(rectangleF.Right, x39d4d9d592924ac5);
		x4490450816683433(rectangleF.Height, xdb200d0a72bd656e);
		xe841d221096c0643 xe841d221096c644 = xa00dfd5fd5cda50f(xd1516a9a5bb6b163, xc55498ae473c1804);
		x19e42c97f4227a7a = x7264a27427003a4e;
		x7264a27427003a4e = x19e42c97f4227a7a.x6d763e63b9853d90;
		xc770c88ee3b92fca = xe841d221096c644;
	}

	private static RectangleF x6b0123441d954662(RectangleF x7066b566c8758907, Border xdb200d0a72bd656e, Border xc55498ae473c1804, Border x39d4d9d592924ac5, Border xd1516a9a5bb6b163)
	{
		float num = x7066b566c8758907.X;
		float num2 = x7066b566c8758907.Y;
		float num3 = x7066b566c8758907.Width;
		float num4 = x7066b566c8758907.Height;
		if (xdb200d0a72bd656e.Shadow)
		{
			num += xdb200d0a72bd656e.xeae235558dc44397;
			num3 -= xdb200d0a72bd656e.xeae235558dc44397;
		}
		if (xc55498ae473c1804.Shadow)
		{
			num3 -= xc55498ae473c1804.xeae235558dc44397;
		}
		if (x39d4d9d592924ac5.Shadow)
		{
			num2 += x39d4d9d592924ac5.xeae235558dc44397;
			num4 -= x39d4d9d592924ac5.xeae235558dc44397;
		}
		if (xd1516a9a5bb6b163.Shadow)
		{
			num4 -= xd1516a9a5bb6b163.xeae235558dc44397;
		}
		return new RectangleF(num, num2, num3, num4);
	}

	private void xc14e33dcc753f606(PointF x0e977b9618532e4e)
	{
		if (x19e42c97f4227a7a == null)
		{
			x19e42c97f4227a7a = new xe841d221096c0643();
			x19e42c97f4227a7a.xab07b26048f600ba = x0e977b9618532e4e;
			x92be23f9da255ff5 = x19e42c97f4227a7a;
		}
	}

	private void xc1a6038e4b87b3d8(PointF x3164ec511a22f3e0)
	{
		float num = x3164ec511a22f3e0.Y - x19e42c97f4227a7a.xab07b26048f600ba.Y;
		if (num > 0.005f)
		{
			xf05382f34c1daced = new xe841d221096c0643();
			xf05382f34c1daced.xab07b26048f600ba = x3164ec511a22f3e0;
			x19e42c97f4227a7a.x7b87db4ce3a626e3 = xf05382f34c1daced;
			xf05382f34c1daced.x147f463035f13e8c = x19e42c97f4227a7a;
			xf05382f34c1daced.x9d329a00f2c534a8 = Border.x45260ad4b94166f2;
			xc28dff9f03c0d48f();
		}
	}

	private void xa3dd1988280d6df6(float x0ebc9dd5d631ae42, Border x39d4d9d592924ac5)
	{
		if (x7264a27427003a4e == null)
		{
			x7264a27427003a4e = new xe841d221096c0643();
			x7264a27427003a4e.xab07b26048f600ba = new PointF(x0ebc9dd5d631ae42, x19e42c97f4227a7a.xab07b26048f600ba.Y);
			x7264a27427003a4e.x92e7e5f35452590d = x39d4d9d592924ac5;
			x19e42c97f4227a7a.x6d763e63b9853d90 = x7264a27427003a4e;
			x7264a27427003a4e.xbf581ee863adbec5 = x19e42c97f4227a7a;
		}
	}

	private void x413b45190f5b64bc(float x56807c4768855de3, Border x3b886490b22eee28)
	{
		xe841d221096c0643 xe841d221096c644 = x19e42c97f4227a7a;
		while (x56807c4768855de3 - xe841d221096c644.xab07b26048f600ba.X > 0.005f && !xe841d221096c644.x08c2d887a8477d25)
		{
			xe841d221096c644 = xe841d221096c644.x6d763e63b9853d90;
		}
		xe841d221096c0643 xe841d221096c645;
		if (Math.Abs(x56807c4768855de3 - xe841d221096c644.xab07b26048f600ba.X) < 0.005f)
		{
			xe841d221096c645 = xe841d221096c644;
			xe841d221096c644 = xe841d221096c644.x6d763e63b9853d90;
		}
		else if (x56807c4768855de3 > xe841d221096c644.xab07b26048f600ba.X)
		{
			xe841d221096c645 = xe841d221096c644.x2729186e1a0b4aeb(x56807c4768855de3);
			xe841d221096c645.x92e7e5f35452590d = Border.x45260ad4b94166f2;
			xe841d221096c644 = null;
		}
		else if (xe841d221096c644.x0cbb90e1280f5639)
		{
			xe841d221096c645 = xe841d221096c644.xefe78abe23c23f7a(x56807c4768855de3);
			xe841d221096c644.x92e7e5f35452590d = Border.x45260ad4b94166f2;
		}
		else
		{
			xe841d221096c645 = xe841d221096c644.xefe78abe23c23f7a(x56807c4768855de3);
			xe841d221096c645.x92e7e5f35452590d = xe841d221096c644.x92e7e5f35452590d;
		}
		x19e42c97f4227a7a = xe841d221096c645;
		x7264a27427003a4e = xe841d221096c644;
	}

	private void x8fce20973946da29(float x0ebc9dd5d631ae42, Border x333c373e7a4f08c4)
	{
		xe841d221096c0643 x6d763e63b9853d = x7264a27427003a4e;
		xe841d221096c0643 xe841d221096c644 = x19e42c97f4227a7a;
		while (x6d763e63b9853d != null && x0ebc9dd5d631ae42 - x6d763e63b9853d.xab07b26048f600ba.X > 0.005f)
		{
			x6d763e63b9853d.x92e7e5f35452590d = Border.x1daeb1be8fb55a2f(x6d763e63b9853d.x92e7e5f35452590d, x333c373e7a4f08c4);
			xe841d221096c644 = x6d763e63b9853d;
			x6d763e63b9853d = x6d763e63b9853d.x6d763e63b9853d90;
		}
		xe841d221096c0643 xe841d221096c645;
		if (x6d763e63b9853d == null)
		{
			xe841d221096c645 = xe841d221096c644.x2729186e1a0b4aeb(x0ebc9dd5d631ae42);
			xe841d221096c645.x92e7e5f35452590d = x333c373e7a4f08c4;
		}
		else if (Math.Abs(x0ebc9dd5d631ae42 - x6d763e63b9853d.xab07b26048f600ba.X) < 0.005f)
		{
			xe841d221096c645 = x6d763e63b9853d;
			x6d763e63b9853d.x92e7e5f35452590d = Border.x1daeb1be8fb55a2f(x6d763e63b9853d.x92e7e5f35452590d, x333c373e7a4f08c4);
		}
		else
		{
			xe841d221096c645 = xe841d221096c644.x2729186e1a0b4aeb(x0ebc9dd5d631ae42);
			xe841d221096c645.x92e7e5f35452590d = Border.x1daeb1be8fb55a2f(x6d763e63b9853d.x92e7e5f35452590d, x333c373e7a4f08c4);
		}
		x7264a27427003a4e = xe841d221096c645;
	}

	private void x4490450816683433(float xd3f2e0aa29e1f6c9, Border xb46aad1109700227)
	{
		if (xc770c88ee3b92fca == null)
		{
			xc770c88ee3b92fca = new xe841d221096c0643();
			xc770c88ee3b92fca.xab07b26048f600ba = new PointF(x19e42c97f4227a7a.xab07b26048f600ba.X, x19e42c97f4227a7a.xab07b26048f600ba.Y + xd3f2e0aa29e1f6c9);
			xc770c88ee3b92fca.x9d329a00f2c534a8 = xb46aad1109700227;
			x19e42c97f4227a7a.x7b87db4ce3a626e3 = xc770c88ee3b92fca;
			xc770c88ee3b92fca.x147f463035f13e8c = x19e42c97f4227a7a;
			xf05382f34c1daced = xc770c88ee3b92fca;
		}
		else
		{
			xc770c88ee3b92fca.x9d329a00f2c534a8 = Border.x1daeb1be8fb55a2f(xc770c88ee3b92fca.x9d329a00f2c534a8, xb46aad1109700227);
		}
	}

	private xe841d221096c0643 xa00dfd5fd5cda50f(Border xd1516a9a5bb6b163, Border x48512116691531d5)
	{
		xe841d221096c0643 xe841d221096c644 = new xe841d221096c0643();
		xe841d221096c644.xab07b26048f600ba = new PointF(x7264a27427003a4e.xab07b26048f600ba.X, xc770c88ee3b92fca.xab07b26048f600ba.Y);
		xe841d221096c644.x92e7e5f35452590d = xd1516a9a5bb6b163;
		xe841d221096c644.x9d329a00f2c534a8 = x48512116691531d5;
		x7264a27427003a4e.x7b87db4ce3a626e3 = xe841d221096c644;
		xe841d221096c644.x147f463035f13e8c = x7264a27427003a4e;
		xc770c88ee3b92fca.x6d763e63b9853d90 = xe841d221096c644;
		xe841d221096c644.xbf581ee863adbec5 = xc770c88ee3b92fca;
		return xe841d221096c644;
	}

	internal void xb0770b4ea658e78d(xb8e7e788f6d59708 xbb8fc393a5ea44bc)
	{
		if (x72d46409b45c5b53)
		{
			xe6a5f3ec802a6d51 x0f7b23d1c393aed = new xe6a5f3ec802a6d51(xbb8fc393a5ea44bc, new xdeb77ea37ad74c56());
			xba4c012ec9d55eee();
			x9a222521d4850354(x0f7b23d1c393aed);
			x5418830ebb60f095(x0f7b23d1c393aed);
			xd586e0c16bdae7fc();
		}
	}

	internal void xb0770b4ea658e78d(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		if (x72d46409b45c5b53)
		{
			xba4c012ec9d55eee();
			x9a222521d4850354(x0f7b23d1c393aed9);
			x5418830ebb60f095(x0f7b23d1c393aed9);
			xd586e0c16bdae7fc();
		}
	}

	internal xb8e7e788f6d59708 xb0770b4ea658e78d()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = null;
		if (x72d46409b45c5b53)
		{
			xb8e7e788f6d = new xb8e7e788f6d59708();
			xe6a5f3ec802a6d51 x0f7b23d1c393aed = new xe6a5f3ec802a6d51(xb8e7e788f6d, new xdeb77ea37ad74c56());
			xba4c012ec9d55eee();
			x9a222521d4850354(x0f7b23d1c393aed);
			x5418830ebb60f095(x0f7b23d1c393aed);
			xd586e0c16bdae7fc();
		}
		return xb8e7e788f6d;
	}

	internal void x9e19f5bd0a6dd5b7(float x92613a3abb80a04d, float x0f449ca2bfc8fe3f)
	{
		for (xe841d221096c0643 xe841d221096c644 = x92be23f9da255ff5; xe841d221096c644 != null; xe841d221096c644 = x9192da99054a9dbb(xe841d221096c644))
		{
			for (xe841d221096c0643 xe841d221096c645 = xe841d221096c644; xe841d221096c645 != null; xe841d221096c645 = xe841d221096c645.x6d763e63b9853d90)
			{
				xe841d221096c645.x9e19f5bd0a6dd5b7(x92613a3abb80a04d, x0f449ca2bfc8fe3f);
			}
		}
	}

	private static xe841d221096c0643 x9192da99054a9dbb(xe841d221096c0643 x2f7096dac971d6ec)
	{
		xe841d221096c0643 xe841d221096c644 = x2f7096dac971d6ec;
		xe841d221096c0643 x7b87db4ce3a626e;
		do
		{
			x7b87db4ce3a626e = xe841d221096c644.x7b87db4ce3a626e3;
			xe841d221096c644 = xe841d221096c644.x6d763e63b9853d90;
		}
		while (x7b87db4ce3a626e == null && xe841d221096c644 != null);
		return x7b87db4ce3a626e?.xd66a9ebae0fffd51();
	}

	private void xba4c012ec9d55eee()
	{
		xb23d0813bd573186();
		for (xe841d221096c0643 xe841d221096c644 = x92be23f9da255ff5; xe841d221096c644 != null; xe841d221096c644 = x9192da99054a9dbb(xe841d221096c644))
		{
			for (xe841d221096c0643 xe841d221096c645 = xe841d221096c644; xe841d221096c645 != null; xe841d221096c645 = xe841d221096c645.x6d763e63b9853d90)
			{
				xe841d221096c645.xba4c012ec9d55eee();
			}
		}
	}

	private void xb23d0813bd573186()
	{
		if (xccf841029b555fe2 == x9ec6ce5404580fa7.xfdc1a17f479acc42)
		{
			float num = 2.1474836E+09f;
			float num2 = -2.1474836E+09f;
			for (xe841d221096c0643 x7b87db4ce3a626e = x92be23f9da255ff5; x7b87db4ce3a626e != null; x7b87db4ce3a626e = x7b87db4ce3a626e.x7b87db4ce3a626e3)
			{
				num = Math.Min(num, x7b87db4ce3a626e.xab07b26048f600ba.X);
				num2 = Math.Max(num2, x7b87db4ce3a626e.x6d763e63b9853d90.xab07b26048f600ba.X - num);
			}
			for (xe841d221096c0643 x7b87db4ce3a626e2 = x92be23f9da255ff5; x7b87db4ce3a626e2 != null; x7b87db4ce3a626e2 = x7b87db4ce3a626e2.x7b87db4ce3a626e3)
			{
				x7b87db4ce3a626e2.xab07b26048f600ba = new PointF(num, x7b87db4ce3a626e2.xab07b26048f600ba.Y);
				x7b87db4ce3a626e2.x6d763e63b9853d90.xab07b26048f600ba = new PointF(num + num2, x7b87db4ce3a626e2.xab07b26048f600ba.Y);
			}
		}
	}

	private void xd586e0c16bdae7fc()
	{
		x92be23f9da255ff5 = null;
		x19e42c97f4227a7a = null;
		x7264a27427003a4e = null;
		xc770c88ee3b92fca = null;
		xf05382f34c1daced = null;
	}

	private void x9a222521d4850354(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		for (xe841d221096c0643 xe841d221096c644 = x92be23f9da255ff5; xe841d221096c644 != null; xe841d221096c644 = x9192da99054a9dbb(xe841d221096c644))
		{
			for (xe841d221096c0643 xe841d221096c645 = xe841d221096c644; xe841d221096c645 != null; xe841d221096c645 = xe841d221096c645.x6d763e63b9853d90)
			{
				if (xe841d221096c645.xbbb7728c0d3a91f6)
				{
					xe841d221096c0643 xe841d221096c646 = xe841d221096c645;
					for (xe841d221096c0643 x7b87db4ce3a626e = xe841d221096c645.x7b87db4ce3a626e3; x7b87db4ce3a626e != null; x7b87db4ce3a626e = x7b87db4ce3a626e.x7b87db4ce3a626e3)
					{
						if (!xe841d221096c646.x3903fbc9023c861c.IsVisible)
						{
							xe841d221096c646 = x7b87db4ce3a626e;
						}
						else if (!x7b87db4ce3a626e.xc5ba672e20f97d35)
						{
							x93f1c9bb52801bce.xe406325e56f74b46(xe841d221096c646, x7b87db4ce3a626e, xccf841029b555fe2 == x9ec6ce5404580fa7.x25af49e7b49ea0bc, xe51c6c8096b26a1f: true, x0f7b23d1c393aed9);
							xe841d221096c646 = x7b87db4ce3a626e;
						}
					}
				}
			}
		}
	}

	private void x5418830ebb60f095(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		for (xe841d221096c0643 xe841d221096c644 = x92be23f9da255ff5; xe841d221096c644 != null; xe841d221096c644 = x9192da99054a9dbb(xe841d221096c644))
		{
			xe841d221096c0643 xe841d221096c645 = xe841d221096c644;
			for (xe841d221096c0643 x6d763e63b9853d = xe841d221096c645.x6d763e63b9853d90; x6d763e63b9853d != null; x6d763e63b9853d = x6d763e63b9853d.x6d763e63b9853d90)
			{
				if (!xe841d221096c645.x0924cade9dc2d296.IsVisible)
				{
					xe841d221096c645 = x6d763e63b9853d;
				}
				else if (!x6d763e63b9853d.x38e386f9e4c783e6)
				{
					x93f1c9bb52801bce.xe406325e56f74b46(xe841d221096c645, x6d763e63b9853d, xccf841029b555fe2 == x9ec6ce5404580fa7.x25af49e7b49ea0bc, xe51c6c8096b26a1f: false, x0f7b23d1c393aed9);
					xe841d221096c645 = x6d763e63b9853d;
				}
			}
		}
	}
}
