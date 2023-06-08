using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x0097836593a6a96a;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;

namespace xa7850104c8d8c135;

internal class x48cb59b8ec3b78c9
{
	private readonly Hashtable x8bb8b8fee1c7164a = new Hashtable();

	private readonly x6edb191c4eaef585 x4e9b4fd5da885654;

	public x6edb191c4eaef585 xf6ec7b82bbd3210e => x4e9b4fd5da885654;

	public x48cb59b8ec3b78c9(x6edb191c4eaef585 renderingOptions)
	{
		x4e9b4fd5da885654 = renderingOptions;
	}

	public xb8e7e788f6d59708 x5b81632e5b71b64c(x72c34b8dbaec3734 xaf3288ddace2264d, xb0d8039f74776744 x0f7b23d1c393aed9)
	{
		int num = x02df97c06afacbf3.x1c3a4a07dc224a14(xaf3288ddace2264d.xcc18177a965e0313, null);
		if (!x8bb8b8fee1c7164a.ContainsKey(num))
		{
			byte[] xcc18177a965e = xaf3288ddace2264d.xcc18177a965e0313;
			SizeF size = new SizeF(21600f, 21600f);
			x776d392443cca64d x776d392443cca64d = x776d392443cca64d.xebcf83b00134300b(xcc18177a965e, x0f7b23d1c393aed9);
			xb8e7e788f6d59708 value = x776d392443cca64d.Play(size, x4e9b4fd5da885654);
			x8bb8b8fee1c7164a.Add(num, value);
		}
		xb8e7e788f6d59708 xb8e7e788f6d = (xb8e7e788f6d59708)x8bb8b8fee1c7164a[num];
		if (xb8e7e788f6d == null)
		{
			return null;
		}
		xb8e7e788f6d = (xb8e7e788f6d59708)xb8e7e788f6d.DeepCopy();
		xb8e7e788f6d59708 xb8e7e788f6d2 = new xb8e7e788f6d59708();
		xb8e7e788f6d2.xd6b6ed77479ef68c(xb8e7e788f6d);
		RectangleF rectangleF = new RectangleF(0f, 0f, 21600f, 21600f);
		if (!x02df97c06afacbf3.x1c140bd1078ddda1(xaf3288ddace2264d.x4d7261a5f7f6e09c))
		{
			rectangleF = xaf3288ddace2264d.x4d7261a5f7f6e09c.xb46e282eca4aff93(rectangleF);
			xb8e7e788f6d2.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(rectangleF);
		}
		xb8e7e788f6d2.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d2.x52dde376accdec7d.xce92de628aa023cf(xaf3288ddace2264d.xc22eade24b085d91.X, xaf3288ddace2264d.xc22eade24b085d91.Y, MatrixOrder.Prepend);
		xb8e7e788f6d2.x52dde376accdec7d.x5152a5707921c783(xaf3288ddace2264d.x437e3b626c0fdd43.Width / rectangleF.Width, xaf3288ddace2264d.x437e3b626c0fdd43.Height / rectangleF.Height, MatrixOrder.Prepend);
		xb8e7e788f6d2.x52dde376accdec7d.xce92de628aa023cf(0f - rectangleF.X, 0f - rectangleF.Y, MatrixOrder.Prepend);
		xb8e7e788f6d2.xc9bcfb2d9630b0c7 = xaf3288ddace2264d.xc9bcfb2d9630b0c7;
		return xb8e7e788f6d2;
	}
}
