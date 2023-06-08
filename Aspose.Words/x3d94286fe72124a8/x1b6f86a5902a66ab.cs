using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x1b6f86a5902a66ab
{
	internal static xb8e7e788f6d59708 xe406325e56f74b46(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		TextPath textPath = x0f7b23d1c393aed9.xa9993ed2e0c64574.TextPath;
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		if (!x0d299f323d241756.x5959bccb67bbf051(textPath.Text))
		{
			return xb8e7e788f6d;
		}
		x31c19fcb724dfaf5 xa0640346645809ad = x0f7b23d1c393aed9.xa0640346645809ad;
		xc020fa2f5133cba8 xc020fa2f5133cba = x0f7b23d1c393aed9.x8dc20c37aa4b28ef as xc020fa2f5133cba8;
		xc020fa2f5133cba8 xc020fa2f5133cba2 = ((xa0640346645809ad == null) ? null : (xa0640346645809ad.x60465f602599d327 as xc020fa2f5133cba8));
		SizeF sizeInPoints = x0f7b23d1c393aed9.xa9993ed2e0c64574.SizeInPoints;
		float width = sizeInPoints.Width;
		float height = sizeInPoints.Height;
		float num = (float)x0f7b23d1c393aed9.xa9993ed2e0c64574.Rotation;
		int x44ecfea61c937b8e = x659bc4263aa7ef66(textPath.Bold, textPath.Italic, textPath.Underline);
		xe39d06eee35dd23d xe39d06eee35dd23d = x0f7b23d1c393aed9.xa9993ed2e0c64574.Document.FontInfos.x26ee10d60756aeab.x491f5a7224612753(textPath.FontFamily, height, (FontStyle)x44ecfea61c937b8e, textPath.FontFamily);
		PointF origin = new PointF(0f, xe39d06eee35dd23d.x53531537bb3331e6 - (xe39d06eee35dd23d.x8a25c402b95f9dea - xe39d06eee35dd23d.xd9ac1486133b5a4e));
		x26d9ecb4bdf0456d color = ((xc020fa2f5133cba == null || xc020fa2f5133cba.x9b41425268471380 == null) ? x26d9ecb4bdf0456d.x45260ad4b94166f2 : xc020fa2f5133cba.x9b41425268471380);
		x26d9ecb4bdf0456d outlineColor = ((xc020fa2f5133cba2 == null || xc020fa2f5133cba2.x9b41425268471380 == null) ? x26d9ecb4bdf0456d.x45260ad4b94166f2 : xc020fa2f5133cba2.x9b41425268471380);
		xcc8c7739d82c63ba xcc8c7739d82c63ba = new xcc8c7739d82c63ba(xe39d06eee35dd23d, color, outlineColor, origin, textPath.Text, SizeF.Empty, (float)textPath.Spacing);
		float m = width / xe39d06eee35dd23d.x6e21842ebf5f70df(textPath.Text).Width;
		xcc8c7739d82c63ba.x52dde376accdec7d = new x54366fa5f75a02f7(m, 0f, 0f, 1f, 0f, 0f);
		if (num != 0f)
		{
			float x = width * 0.5f;
			float y = height * 0.5f;
			xcc8c7739d82c63ba.x52dde376accdec7d.x49d618948c467be6(num, new PointF(x, y), MatrixOrder.Append);
		}
		xb8e7e788f6d.xd6b6ed77479ef68c(xcc8c7739d82c63ba);
		return xb8e7e788f6d;
	}

	private static int x659bc4263aa7ef66(bool xfb7d9aaaa3bb766b, bool xe8c0bbd4d5297920, bool x98e3d870f2952584)
	{
		int num = 0;
		if (xfb7d9aaaa3bb766b)
		{
			num |= 1;
		}
		if (xe8c0bbd4d5297920)
		{
			num |= 2;
		}
		if (x98e3d870f2952584)
		{
			num |= 4;
		}
		return num;
	}
}
