using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x8096ed1677306b4d
{
	private const int x64ea938a3c2f22f4 = 800;

	private const int x4a5cb833f413c2b7 = 600;

	internal static void x144a519b89660993(xdcf47a8f1807f37c xbbe2f7d7c86e0379, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		Shape backgroundShape = xbbe2f7d7c86e0379.x2c8c6741422a1298.BackgroundShape;
		if (backgroundShape == null)
		{
			return;
		}
		x54b98d0096d7251a warningCallback = new xfadb51c1fcf6d0ba(x0f7b23d1c393aed9.xdeb77ea37ad74c56);
		xc958d22004253850 xc958d220042538502 = new xc958d22004253850(null, warningCallback, xbbe2f7d7c86e0379.x2c8c6741422a1298.x0b16d2d2ced2de05, x0f7b23d1c393aed9.xdeb77ea37ad74c56.x4e89abab59063fe9);
		SizeF alteredSize = xce77fcdd45cf442d(backgroundShape.Fill.xeba92971120d3e5a);
		float width = alteredSize.Width;
		float height = alteredSize.Height;
		float num = width * 0.5f;
		float num2 = height * 0.5f;
		xb8e7e788f6d59708 xb8e7e788f6d = xc958d220042538502.xe406325e56f74b46(new x7721ad963b03c6eb(backgroundShape, alteredSize), x0c7065950934043a: false);
		xb8e7e788f6d.x52dde376accdec7d = null;
		bool flag = x8b8a7e8a5f83110d(backgroundShape.Fill.xeba92971120d3e5a);
		float num3 = 0f;
		float num4 = 1f;
		while (num3 < xbbe2f7d7c86e0379.xb0f146032f47c24e)
		{
			float num5 = 0f;
			float num6 = 1f;
			while (num5 < xbbe2f7d7c86e0379.xdc1bf80853046136)
			{
				xb8e7e788f6d59708 xb8e7e788f6d2 = xb8e7e788f6d.xfe8f67360e300e88();
				xb8e7e788f6d2.x52dde376accdec7d = new x54366fa5f75a02f7();
				xb8e7e788f6d2.x52dde376accdec7d.xce92de628aa023cf(0f - num, 0f - num2, MatrixOrder.Append);
				xb8e7e788f6d2.x52dde376accdec7d.x5152a5707921c783(num6, num4, MatrixOrder.Append);
				xb8e7e788f6d2.x52dde376accdec7d.xce92de628aa023cf(num, num2, MatrixOrder.Append);
				xb8e7e788f6d2.x52dde376accdec7d.xce92de628aa023cf(num5, num3, MatrixOrder.Append);
				x0f7b23d1c393aed9.x1fa9148f6731ff24(xb8e7e788f6d2);
				num5 += width;
				if (flag)
				{
					num6 = 0f - num6;
				}
			}
			num3 += height;
			if (flag)
			{
				num4 = 0f - num4;
			}
		}
	}

	private static bool x8b8a7e8a5f83110d(xeba92971120d3e5a x6f97e5cf19b52dbd)
	{
		switch (x6f97e5cf19b52dbd)
		{
		case xeba92971120d3e5a.xb8751dec55f64252:
		case xeba92971120d3e5a.xd265a220a45d3124:
		case xeba92971120d3e5a.x7b6a6d281546db99:
		case xeba92971120d3e5a.x7f4d496937f8c24c:
		case xeba92971120d3e5a.x52578e3c8384728f:
			return false;
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.xca1af54f5cfd812d:
		case xeba92971120d3e5a.xaf29dc5ca8be8da4:
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
		case xeba92971120d3e5a.x408710144185f184:
			return true;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static SizeF xce77fcdd45cf442d(xeba92971120d3e5a x6f97e5cf19b52dbd)
	{
		float num = 1f;
		switch (x6f97e5cf19b52dbd)
		{
		case xeba92971120d3e5a.xca1af54f5cfd812d:
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
			num = 0.5f;
			break;
		default:
			throw new ArgumentOutOfRangeException("fillType");
		case xeba92971120d3e5a.xb8751dec55f64252:
		case xeba92971120d3e5a.xd265a220a45d3124:
		case xeba92971120d3e5a.x7b6a6d281546db99:
		case xeba92971120d3e5a.x7f4d496937f8c24c:
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.xaf29dc5ca8be8da4:
		case xeba92971120d3e5a.x408710144185f184:
		case xeba92971120d3e5a.x52578e3c8384728f:
			break;
		}
		float width = (float)x4574ea26106f0edb.xad2dd08366e0faf5(800.0) * num;
		float height = (float)x4574ea26106f0edb.xad2dd08366e0faf5(600.0) * num;
		return new SizeF(width, height);
	}
}
