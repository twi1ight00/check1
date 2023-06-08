using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;
using xf9a9481c3f63a419;

namespace x24e0e4e48dc84bd8;

internal class xa00620cbf72482ab
{
	public const int x4d04427ffb621c31 = int.MaxValue;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	public xf67b8f3d5352fefb x9deec9457dc2451d => xd995695f8e3419d6.x9deec9457dc2451d;

	public xa00620cbf72482ab(x4e88096751fad171 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public xb8e7e788f6d59708 x044fc87d6c0611b7(x273fb960e2b0a823 xe058541ca798c059, int x7a1ab02e747a8dd2, RectangleF x0d1d762ec380db87, x60f0a0028c81b61c xb4169e5863031add, RectangleF x47807e698c6282d5)
	{
		x0d1d762ec380db87 = xd995695f8e3419d6.x5b13e3ca46964e0d.x645cd44df6f04941(x0d1d762ec380db87, xb4169e5863031add);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.xd6b6ed77479ef68c(xe058541ca798c059.xca1273758a917434());
		xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f7.x6698fc0971e66ffb(x0d1d762ec380db87, x47807e698c6282d5);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x0d1d762ec380db87);
		return xb8e7e788f6d;
	}

	public xb8e7e788f6d59708 x044fc87d6c0611b7(x273fb960e2b0a823 xe058541ca798c059, int x7a1ab02e747a8dd2, RectangleF x0d1d762ec380db87, x60f0a0028c81b61c xb4169e5863031add, PointF[] xe5be0219e97bc6c9)
	{
		x0d1d762ec380db87 = xd995695f8e3419d6.x5b13e3ca46964e0d.x645cd44df6f04941(x0d1d762ec380db87, xb4169e5863031add);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.xd6b6ed77479ef68c(xe058541ca798c059.xca1273758a917434());
		xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f7.xed1284b895d73140(x0d1d762ec380db87, xe5be0219e97bc6c9);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x0d1d762ec380db87);
		return xb8e7e788f6d;
	}

	public xb8e7e788f6d59708 x7c25ad656b516c85(string xb41faee6912a2313, RectangleF x573f10cfae8c57b2, int x115120198ec39b12, x278c5f28f6803529 xe382e485a6865e2e, int xcb4cd906ca3eb6fe)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = (xe39d06eee35dd23d)x9deec9457dc2451d.x38758cbbee49e4cb(xcb4cd906ca3eb6fe);
		if (xe39d06eee35dd23d == null)
		{
			return null;
		}
		x030508d4549c7599 x030508d4549c7600 = (x030508d4549c7599)x9deec9457dc2451d.x38758cbbee49e4cb(x115120198ec39b12);
		if (x030508d4549c7600 == null)
		{
			x030508d4549c7600 = new x030508d4549c7599();
		}
		SizeF size = xe39d06eee35dd23d.x6e21842ebf5f70df(xb41faee6912a2313);
		RectangleF rectangleF = (x573f10cfae8c57b2.IsEmpty ? new RectangleF(x573f10cfae8c57b2.Location, size) : x573f10cfae8c57b2);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		if (x030508d4549c7600.xfe855daf0c2c927d)
		{
			x54366fa5f75a02f.xa77087bb05d9ef76(90f);
			x54366fa5f75a02f.xce92de628aa023cf(rectangleF.X + rectangleF.Height, rectangleF.Y, MatrixOrder.Append);
		}
		else
		{
			x54366fa5f75a02f.xce92de628aa023cf(rectangleF.X, rectangleF.Y);
		}
		string xe88104aeaa19b45d = x402d9b5f181ddd8c.x66e064f27f7afe14(xb1d54f2a80cb4dfb.xd24a26dfe580d2b3);
		if (x030508d4549c7600.x097960ea288b2feb)
		{
			xd995695f8e3419d6.x5e3cfff57135d485("Right to left direction for '{0}' record is not supported.", xe88104aeaa19b45d);
		}
		float num = (float)x030508d4549c7600.x7c9f71283253e177 * xe39d06eee35dd23d.x53531537bb3331e6;
		float num2 = (float)x030508d4549c7600.x3d1656d05c05afb5 * xe39d06eee35dd23d.x53531537bb3331e6;
		rectangleF = new RectangleF(new PointF(num, 0f), new SizeF(rectangleF.Width - num - num2, rectangleF.Height));
		if (!x573f10cfae8c57b2.IsEmpty)
		{
			if (rectangleF.Width > size.Width)
			{
				switch (x030508d4549c7600.xade2575399cddd2d)
				{
				case xdddf00507e66b745.x58d2ccae3c5cfd08:
				{
					float x = (rectangleF.Width - size.Width) / 2f;
					rectangleF.Offset(x, 0f);
					break;
				}
				case xdddf00507e66b745.x1d95d654f3ac5ef8:
				{
					float x = rectangleF.Width - size.Width;
					rectangleF.Offset(x, 0f);
					break;
				}
				}
			}
			else if (!x030508d4549c7600.xd13a588829d84a35)
			{
				xd995695f8e3419d6.x5e3cfff57135d485("Text wrapping for '{0}' record is not supported.", xe88104aeaa19b45d);
			}
		}
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f;
		x845d6a068e0b03c5 brush = xe382e485a6865e2e.xa3fa1ce4ffca3dc3();
		xcc8c7739d82c63ba xda5bf54deb817e = new xcc8c7739d82c63ba(xe39d06eee35dd23d, brush, rectangleF, xb41faee6912a2313, 0f);
		xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
		return xb8e7e788f6d;
	}

	public xb8e7e788f6d59708 x40b96308a5c749d1(string xb41faee6912a2313, xe39d06eee35dd23d x26094932cf7a9139, PointF[] xc3026669cd660bea, x278c5f28f6803529 xe382e485a6865e2e, x2410d07540cef09e xdfde339da46db651, x54366fa5f75a02f7 x678241938de24d81)
	{
		if (x678241938de24d81.x3122d79fa5906409 == 0.0)
		{
			return null;
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return null;
		}
		x845d6a068e0b03c5 brush = xe382e485a6865e2e.xa3fa1ce4ffca3dc3();
		if ((xdfde339da46db651 & x2410d07540cef09e.x61c108cc44ef385a) != 0)
		{
			x678241938de24d81.xa77087bb05d9ef76(90f);
			new x54366fa5f75a02f7(1f, 0f, 0f, 1f, 0f - x26094932cf7a9139.x6b0006bdae665f50, 0f).xa4b699bd47eb7372(xc3026669cd660bea);
		}
		x678241938de24d81.x437786253537a519().xa4b699bd47eb7372(xc3026669cd660bea);
		ArrayList arrayList = new ArrayList();
		if ((xdfde339da46db651 & x2410d07540cef09e.xc9f067f483b14b3b) != 0)
		{
			PointF pointF = xc3026669cd660bea[0];
			foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
			{
				arrayList.Add(pointF);
				float num = x26094932cf7a9139.x30e45ef93fedb4ba(item);
				pointF = new PointF(pointF.X + num, pointF.Y);
			}
		}
		else
		{
			int num2 = 0;
			foreach (int item2 in new x115139807e6482f7(xb41faee6912a2313))
			{
				arrayList.Add(xc3026669cd660bea[num2]);
				num2 += ((!xdf3a1f89dca325a3.x3a26b5f116985446(item2)) ? 1 : 2);
			}
		}
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x52dde376accdec7d = x678241938de24d81;
		int num3 = 0;
		foreach (int item3 in new x115139807e6482f7(xb41faee6912a2313))
		{
			PointF origin = (PointF)arrayList[num3++];
			xcc8c7739d82c63ba xda5bf54deb817e = new xcc8c7739d82c63ba(x26094932cf7a9139, brush, origin, xdf3a1f89dca325a3.x251dbcb3221739c5(item3), 0f);
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
		}
		return xb8e7e788f6d;
	}

	public xab391c46ff9a0a38 x8d65dd427d9f1032(PointF[] x6fa2570084b2ad39, int xd4cdb2d1cdb13454, int xd0a80f4cb245fd62, float xe1cf08c4fd1c0f20, int x1345d7804b1bedd7)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.x9faec380d0a9917e(x6fa2570084b2ad39, xd4cdb2d1cdb13454, xd0a80f4cb245fd62, xe1cf08c4fd1c0f20);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, null);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 x9511dabeb619a1f9(PointF[] x6fa2570084b2ad39, float xe1cf08c4fd1c0f20, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.xfcd495f72983d2dc(x6fa2570084b2ad39, xe1cf08c4fd1c0f20);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xa8555875131ef259(PointF[] x6fa2570084b2ad39, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.x59169d12d1b8bb60(x6fa2570084b2ad39);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xb82c6b14852077e9(RectangleF xda73fcb97c77d998, float x32bf744f8e9a8c29, float x4b7a727a9fc82698, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.x8038eafd1bbbb846(xda73fcb97c77d998, x32bf744f8e9a8c29, x4b7a727a9fc82698);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xb5bbf5dc79bae0cf(RectangleF xda73fcb97c77d998, float x32bf744f8e9a8c29, float x4b7a727a9fc82698, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.xe72c1200ca4479dc(xda73fcb97c77d998, x32bf744f8e9a8c29, x4b7a727a9fc82698);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 x8b8e40a8d42e4c69(RectangleF xda73fcb97c77d998, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.xfe86f193b918ca9c(xda73fcb97c77d998);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xd118bdfd155d71de(int x1b17d2598850aa3a, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)x9deec9457dc2451d.x38758cbbee49e4cb(x1b17d2598850aa3a);
		if (xab391c46ff9a0a == null)
		{
			return null;
		}
		xab391c46ff9a0a = xab391c46ff9a0a.x8b61531c8ea35b85();
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xa2498ec14d12aaf5(int x5f821c736ab57440, x278c5f28f6803529 xe382e485a6865e2e)
	{
		Region region = (Region)x9deec9457dc2451d.x38758cbbee49e4cb(x5f821c736ab57440);
		if (region == null)
		{
			return null;
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = x8ebf543aaab29d16.x2ffd000f9d74db27(region);
		xab391c46ff9a0a.x60465f602599d327 = xa3fa1ce4ffca3dc3(xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 x76fd4418ef6e0ad9(PointF[] x6fa2570084b2ad39, bool x7a848427f2a9a3b5, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x0a0cd856a9385c87.x21aa036e347a1063(x6fa2570084b2ad39, x7a848427f2a9a3b5);
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 x530eb28229985474(RectangleF[] x09d9444f882ac964, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		foreach (RectangleF x26545669838eb36e in x09d9444f882ac964)
		{
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.x7c89cd07f845b8e1(x26545669838eb36e));
		}
		xf24ff62545dc230e(xab391c46ff9a0a, x1345d7804b1bedd7, xe382e485a6865e2e);
		return xab391c46ff9a0a;
	}

	private void xf24ff62545dc230e(xab391c46ff9a0a38 xe125219852864557, int x1345d7804b1bedd7, x278c5f28f6803529 xe382e485a6865e2e)
	{
		if (xe125219852864557 != null)
		{
			xe125219852864557.x9e5d5f9128c69a8f = x2f0c16e51db81725(x1345d7804b1bedd7);
			xe125219852864557.x60465f602599d327 = xa3fa1ce4ffca3dc3(xe382e485a6865e2e);
		}
	}

	private x845d6a068e0b03c5 xa3fa1ce4ffca3dc3(x278c5f28f6803529 xe382e485a6865e2e)
	{
		return xe382e485a6865e2e?.xa3fa1ce4ffca3dc3();
	}

	private x31c19fcb724dfaf5 x2f0c16e51db81725(int x1345d7804b1bedd7)
	{
		if (x1345d7804b1bedd7 == int.MaxValue)
		{
			return null;
		}
		return (x31c19fcb724dfaf5)x9deec9457dc2451d.x38758cbbee49e4cb(x1345d7804b1bedd7);
	}
}
