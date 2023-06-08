using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;
using xf269d97e8a02e911;

namespace x64e9a8098b90b398;

internal class xa3c1321313fe9f8e : x9bef3b1e893f7f2e
{
	private readonly x3fa09e8d7b952fbc x44bb21011b34eca8;

	private xab391c46ff9a0a38 x680ab99924e08cb1;

	private bool xa41d0000655af070;

	private x1cab6af0a41b70e2 xd16a8c9589630813;

	private xb8e7e788f6d59708 x7a8a30505eb89f6e;

	private readonly SizeF x3a87d31afc876b0f;

	internal xb8e7e788f6d59708 x5fe28c2b4826581d
	{
		get
		{
			float m = x3a87d31afc876b0f.Width / x44bb21011b34eca8.xee6354c7044d841a.Width;
			float m2 = x3a87d31afc876b0f.Height / x44bb21011b34eca8.xee6354c7044d841a.Height;
			x7a8a30505eb89f6e.x52dde376accdec7d = new x54366fa5f75a02f7(m, 0f, 0f, m2, 0f, 0f);
			x7a8a30505eb89f6e.x52dde376accdec7d.xce92de628aa023cf(0f - x44bb21011b34eca8.xee6354c7044d841a.X, 0f - x44bb21011b34eca8.xee6354c7044d841a.Y, MatrixOrder.Prepend);
			return x7a8a30505eb89f6e;
		}
	}

	internal xb8e7e788f6d59708 x2194e74ed40dc190
	{
		get
		{
			x7a8a30505eb89f6e.x52dde376accdec7d = null;
			return x7a8a30505eb89f6e;
		}
	}

	internal xa3c1321313fe9f8e(x3fa09e8d7b952fbc metafileInfo, SizeF dstSize, bool isEmf)
		: base(metafileInfo, isEmf)
	{
		x44bb21011b34eca8 = metafileInfo;
		x3a87d31afc876b0f = dstSize;
		xb3822a1656f9ced7();
	}

	public void xce9cd359282e266c()
	{
		xb3822a1656f9ced7();
	}

	private void xb3822a1656f9ced7()
	{
		x7a8a30505eb89f6e = new xb8e7e788f6d59708();
		x7a8a30505eb89f6e.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x44bb21011b34eca8.xee6354c7044d841a);
	}

	internal override void x73f725cce5fe5602(PointF x96963e0bda556306, string xb41faee6912a2313)
	{
		x2037c969f8f81f97(x96963e0bda556306, xb41faee6912a2313, null, xf88a862828c50d65.x48dc718a4eaee04d, base.x28fcdc775a1d069c.x145e3af29556cafe.x182ac7607832b44d, base.x28fcdc775a1d069c.x145e3af29556cafe.xe8b1b98fa9f9c5f3);
	}

	internal override void x5240cbb3533fe5f3(PointF x96963e0bda556306, string xb41faee6912a2313, SizeF[] x5d99229d139019a0, xf88a862828c50d65 x02a27ffbdedc338b, float x12e386b4209a70fe, float x23d72da5bb9ca78e)
	{
		x2037c969f8f81f97(x96963e0bda556306, xb41faee6912a2313, x5d99229d139019a0, x02a27ffbdedc338b, x12e386b4209a70fe, x23d72da5bb9ca78e);
	}

	private void x2037c969f8f81f97(PointF x96963e0bda556306, string xb41faee6912a2313, SizeF[] x5d99229d139019a0, xf88a862828c50d65 x02a27ffbdedc338b, float x12e386b4209a70fe, float x23d72da5bb9ca78e)
	{
		x620a827d91bf9cfe x145e3af29556cafe = base.x28fcdc775a1d069c.x145e3af29556cafe;
		bool flag = (x145e3af29556cafe.x2f4602b24218079d & x3bd09d63c3e0d655.xe706b8e230b9dc91) != 0;
		xb41faee6912a2313 = xcb4d1b7268331057(xb41faee6912a2313);
		if (x5d99229d139019a0 == null)
		{
			x5d99229d139019a0 = x618c17d8afe02451(xb41faee6912a2313);
		}
		SizeF sizeF = x90dd2398e9d98a0a(x5d99229d139019a0);
		SizeF sizeF2 = xedcdc30f6e8d1cbe(sizeF);
		if (flag)
		{
			x96963e0bda556306 = base.x28fcdc775a1d069c.x180f9c8380162d4e;
			base.x28fcdc775a1d069c.x180f9c8380162d4e = x0d299f323d241756.x7c91cffb7e0460c1(x96963e0bda556306, sizeF);
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = x145e3af29556cafe.x5f07ecdc32c49655(x96963e0bda556306, sizeF2, x02a27ffbdedc338b, x12e386b4209a70fe, x23d72da5bb9ca78e);
		x322ecd245184c2b3(sizeF2, x54366fa5f75a02f);
		xc7234004e9b72a7e(xb41faee6912a2313, x5d99229d139019a0, x54366fa5f75a02f, x02a27ffbdedc338b, x12e386b4209a70fe, x23d72da5bb9ca78e);
	}

	private string xcb4d1b7268331057(string xb41faee6912a2313)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			stringBuilder.Append(xd0f7d6bb829c47bd(item) ? " " : xdf3a1f89dca325a3.x251dbcb3221739c5(item));
		}
		return stringBuilder.ToString();
	}

	private bool xd0f7d6bb829c47bd(int x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 < 0 || x3c4da2980d043c95 > 31)
		{
			if (x3c4da2980d043c95 >= 128)
			{
				return x3c4da2980d043c95 <= 159;
			}
			return false;
		}
		return true;
	}

	private SizeF[] x618c17d8afe02451(string xb41faee6912a2313)
	{
		ArrayList arrayList = new ArrayList();
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			arrayList.Add(new SizeF(base.x28fcdc775a1d069c.x145e3af29556cafe.xd2c0fde191305c0a(xdf3a1f89dca325a3.x251dbcb3221739c5(item)).Width, 0f));
		}
		return (SizeF[])arrayList.ToArray(typeof(SizeF));
	}

	private SizeF x90dd2398e9d98a0a(SizeF[] x46bd0c2d36461df6)
	{
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < x46bd0c2d36461df6.Length; i++)
		{
			result += x46bd0c2d36461df6[i];
		}
		return result;
	}

	private SizeF xedcdc30f6e8d1cbe(SizeF x8c467b94153a488d)
	{
		return new SizeF(x8c467b94153a488d.Width, x8c467b94153a488d.Height + base.x28fcdc775a1d069c.x145e3af29556cafe.xc2d4efc42998d87b.xad4d3652239d8aaa);
	}

	private void xc7234004e9b72a7e(string xb41faee6912a2313, SizeF[] x5d99229d139019a0, x54366fa5f75a02f7 x58a039df54e31d32, xf88a862828c50d65 x02a27ffbdedc338b, float x12e386b4209a70fe, float x23d72da5bb9ca78e)
	{
		x620a827d91bf9cfe x145e3af29556cafe = base.x28fcdc775a1d069c.x145e3af29556cafe;
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x52dde376accdec7d = x58a039df54e31d32;
		PointF pointF = default(PointF);
		int num = 0;
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			xcc8c7739d82c63ba xcc8c7739d82c63ba = new xcc8c7739d82c63ba(x145e3af29556cafe.xc2d4efc42998d87b, x145e3af29556cafe.x0cd10c3b6c8154d6, x26d9ecb4bdf0456d.x45260ad4b94166f2, default(PointF), xdf3a1f89dca325a3.x251dbcb3221739c5(item), 0f);
			xcc8c7739d82c63ba.x52dde376accdec7d = x145e3af29556cafe.xefc84eec2d945482(pointF, x02a27ffbdedc338b, x12e386b4209a70fe, x23d72da5bb9ca78e);
			xb8e7e788f6d.xd6b6ed77479ef68c(xcc8c7739d82c63ba);
			pointF = x0d299f323d241756.x7c91cffb7e0460c1(pointF, x5d99229d139019a0[num++]);
		}
		x51d3a13ecd447601(xb8e7e788f6d);
	}

	private void x322ecd245184c2b3(SizeF x06a0ebcbd750b7f0, x54366fa5f75a02f7 x678241938de24d81)
	{
		if (base.x28fcdc775a1d069c.x145e3af29556cafe.x83729c7ebf48ae24.xda71bf6f7c07c3bc != 0)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = x42e9b5316eecf9e9(default(PointF), x06a0ebcbd750b7f0);
			xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(base.x28fcdc775a1d069c.x145e3af29556cafe.x83729c7ebf48ae24);
			xab391c46ff9a0a.x52dde376accdec7d = x678241938de24d81.x8b61531c8ea35b85();
			x51d3a13ecd447601(xab391c46ff9a0a);
		}
	}

	private xab391c46ff9a0a38 x42e9b5316eecf9e9(PointF x9c3c185e7046dc72, SizeF x0ceec69a97f73617)
	{
		return xab391c46ff9a0a38.x7c89cd07f845b8e1(new RectangleF(new PointF(x9c3c185e7046dc72.X, x9c3c185e7046dc72.Y - base.x28fcdc775a1d069c.x145e3af29556cafe.xc2d4efc42998d87b.xd9ac1486133b5a4e), x0ceec69a97f73617));
	}

	internal override void xd9c8acf0e5a12504(PointF x13d4cb8d1bd20347, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x13d4cb8d1bd20347, x13d4cb8d1bd20347);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x6c50a99faab7d741);
		xead6ee21c504466a(xab391c46ff9a0a, x103863f095353be0: false, x2263d5f36cc49ece: false);
	}

	internal override void xd0baff30d99dc152(PointF xa2da454aa40879d2)
	{
		if (xa41d0000655af070)
		{
			x31c7ae4d986df847();
			PointF[] x6fa2570084b2ad = new PointF[2]
			{
				base.x28fcdc775a1d069c.x180f9c8380162d4e,
				xa2da454aa40879d2
			};
			xd16a8c9589630813.x8992595b6d42d9bd(x6fa2570084b2ad);
		}
		else
		{
			xab391c46ff9a0a38 xe125219852864557 = xab391c46ff9a0a38.xb471d14948c54f27(base.x28fcdc775a1d069c.x180f9c8380162d4e, xa2da454aa40879d2);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: false);
		}
	}

	internal override void x404d528fe2f10961(RectangleF xda73fcb97c77d998)
	{
		xab391c46ff9a0a38 xe125219852864557 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xda73fcb97c77d998);
		xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
	}

	internal override void x7cfc143904bcbd0a(RectangleF xda73fcb97c77d998)
	{
		xab391c46ff9a0a38 xe125219852864557 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xda73fcb97c77d998);
		xead6ee21c504466a(xe125219852864557, x103863f095353be0: false, x2263d5f36cc49ece: true);
	}

	internal override void xe281a5e162365979(RectangleF xda73fcb97c77d998)
	{
		xab391c46ff9a0a38 xe125219852864557 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xda73fcb97c77d998);
		xead6ee21c504466a(xe125219852864557, x103863f095353be0: false, x2263d5f36cc49ece: true, x511b26b1ea07f3f8: true);
	}

	internal override void x1915e1f68bab8628(xfc986ef9bf7fc434 xa4d52e34b62b5495, x31c19fcb724dfaf5 x90279591611601bc, x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		for (int i = 0; i < xa4d52e34b62b5495.x58efbacd665a3e59.Count; i++)
		{
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.x7c89cd07f845b8e1((RectangleF)xa4d52e34b62b5495.x58efbacd665a3e59[i]));
		}
		xead6ee21c504466a(xab391c46ff9a0a, x90279591611601bc, xd8f1949f8950238a);
	}

	internal override void xdc17f546fee300d3(PointF[] x6fa2570084b2ad39)
	{
		if (x6fa2570084b2ad39.Length > 0)
		{
			if (xa41d0000655af070)
			{
				x31c7ae4d986df847();
				xd16a8c9589630813.x8992595b6d42d9bd(x6fa2570084b2ad39);
			}
			else
			{
				xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x21aa036e347a1063(x6fa2570084b2ad39, x1fc037832f61c313: false);
				xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: false);
			}
		}
	}

	internal override void x7d80352ee17f7010(PointF[] x6fa2570084b2ad39)
	{
		if (x6fa2570084b2ad39.Length > 0)
		{
			if (xa41d0000655af070)
			{
				x31c7ae4d986df847();
				xd16a8c9589630813.x7a07af5ab8d9b424(x6fa2570084b2ad39);
			}
			else
			{
				xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x59169d12d1b8bb60(x6fa2570084b2ad39);
				xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: false);
			}
		}
	}

	internal override void xd9dec91b880628fb(PointF[][] x40b3b42fa08d1aa5)
	{
		if (x40b3b42fa08d1aa5.Length < 0)
		{
			return;
		}
		if (xa41d0000655af070)
		{
			foreach (PointF[] x6fa2570084b2ad in x40b3b42fa08d1aa5)
			{
				x31c7ae4d986df847();
				xd16a8c9589630813.x8992595b6d42d9bd(x6fa2570084b2ad);
				AddCurrentFigure(closed: false);
			}
		}
		else
		{
			xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x3f8cb31cced9caeb(x40b3b42fa08d1aa5, x1fc037832f61c313: false);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: false);
		}
	}

	internal override void x03d68de1c2f74051(PointF[] x6fa2570084b2ad39)
	{
		if (x6fa2570084b2ad39.Length > 0)
		{
			if (xa41d0000655af070)
			{
				x31c7ae4d986df847();
				xd16a8c9589630813.x8992595b6d42d9bd(x6fa2570084b2ad39);
				AddCurrentFigure(closed: true);
			}
			else
			{
				xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x21aa036e347a1063(x6fa2570084b2ad39, x1fc037832f61c313: true);
				xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
			}
		}
	}

	internal override void xd245cbaa83c34942(PointF[][] x40b3b42fa08d1aa5)
	{
		if (x40b3b42fa08d1aa5.Length <= 0)
		{
			return;
		}
		if (xa41d0000655af070)
		{
			foreach (PointF[] x6fa2570084b2ad in x40b3b42fa08d1aa5)
			{
				x31c7ae4d986df847();
				xd16a8c9589630813.x8992595b6d42d9bd(x6fa2570084b2ad);
				AddCurrentFigure(closed: true);
			}
		}
		else
		{
			xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x3f8cb31cced9caeb(x40b3b42fa08d1aa5, x1fc037832f61c313: true);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
		}
	}

	internal override void x26a9b6a08a70bcb9(RectangleF xda73fcb97c77d998, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		if (!xda73fcb97c77d998.IsEmpty)
		{
			xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x8038eafd1bbbb846(xda73fcb97c77d998, x10aaa7cdfa38f254, xca09b6c2b5b18485);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: false);
		}
	}

	internal override void xc72009430f04e936(RectangleF xda73fcb97c77d998)
	{
		if (!xda73fcb97c77d998.IsEmpty)
		{
			xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.xfe86f193b918ca9c(xda73fcb97c77d998);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
		}
	}

	internal override void x9c41f408fac0860b(RectangleF xda73fcb97c77d998, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		if (!xda73fcb97c77d998.IsEmpty)
		{
			xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.xe72c1200ca4479dc(xda73fcb97c77d998, x10aaa7cdfa38f254, xca09b6c2b5b18485);
			xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
		}
	}

	internal override void xbde68cf069398941(RectangleF xda73fcb97c77d998, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.xe8e4e4223b7f79d9(xda73fcb97c77d998, x10aaa7cdfa38f254, xca09b6c2b5b18485);
		xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
	}

	internal override void x627d6ea467c20240(RectangleF xda73fcb97c77d998, SizeF x9c1283b780bba3a6)
	{
		xab391c46ff9a0a38 xe125219852864557 = x0a0cd856a9385c87.x73e467b463f05527(xda73fcb97c77d998, x9c1283b780bba3a6);
		xead6ee21c504466a(xe125219852864557, x103863f095353be0: true, x2263d5f36cc49ece: true);
	}

	internal override void xf1c59e95a2a1c03b(RectangleF x4522b57e50ea54a2, RectangleF x334178e22916b6db, byte[] x43e181e083db6cdf)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		PointF origin = new PointF(x334178e22916b6db.Left, x334178e22916b6db.Top);
		SizeF size = new SizeF(x334178e22916b6db.Width, x334178e22916b6db.Height);
		x72c34b8dbaec3734 xda5bf54deb817e = new x72c34b8dbaec3734(origin, size, x43e181e083db6cdf);
		xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
		xb8e7e788f6d.x52dde376accdec7d = base.x28fcdc775a1d069c.x145e3af29556cafe.xf30a67c117fb87d6.xaccac17571a8d9fa.x8b61531c8ea35b85();
		x51d3a13ecd447601(xb8e7e788f6d);
	}

	internal override void x61c79166c1e90b77(RectangleF x4522b57e50ea54a2, RectangleF x334178e22916b6db, x54366fa5f75a02f7 xa801ccff44b0c7eb, byte[] x43e181e083db6cdf)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		PointF origin = new PointF(x334178e22916b6db.Left, x334178e22916b6db.Top);
		SizeF size = new SizeF(x334178e22916b6db.Width, x334178e22916b6db.Height);
		x72c34b8dbaec3734 xda5bf54deb817e = new x72c34b8dbaec3734(origin, size, x43e181e083db6cdf);
		xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
		xb8e7e788f6d.x52dde376accdec7d = base.x28fcdc775a1d069c.x145e3af29556cafe.xf30a67c117fb87d6.xaccac17571a8d9fa.x8b61531c8ea35b85();
		xb8e7e788f6d.x52dde376accdec7d.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Prepend);
		x51d3a13ecd447601(xb8e7e788f6d);
	}

	private void xead6ee21c504466a(xab391c46ff9a0a38 xe125219852864557, bool x103863f095353be0, bool x2263d5f36cc49ece)
	{
		xead6ee21c504466a(xe125219852864557, x103863f095353be0, x2263d5f36cc49ece, x511b26b1ea07f3f8: false);
	}

	private void xead6ee21c504466a(xab391c46ff9a0a38 xe125219852864557, bool x103863f095353be0, bool x2263d5f36cc49ece, bool x511b26b1ea07f3f8)
	{
		x620a827d91bf9cfe x145e3af29556cafe = base.x28fcdc775a1d069c.x145e3af29556cafe;
		x31c19fcb724dfaf5 x90279591611601bc = (x103863f095353be0 ? x145e3af29556cafe.x9e5d5f9128c69a8f : null);
		x845d6a068e0b03c5 x845d6a068e0b03c = (x2263d5f36cc49ece ? x145e3af29556cafe.x60465f602599d327 : null);
		if (x511b26b1ea07f3f8 && x845d6a068e0b03c != null)
		{
			x845d6a068e0b03c = new xc020fa2f5133cba8(x145e3af29556cafe.x83729c7ebf48ae24);
		}
		xead6ee21c504466a(xe125219852864557, x90279591611601bc, x845d6a068e0b03c);
	}

	private void xead6ee21c504466a(xab391c46ff9a0a38 xe125219852864557, x31c19fcb724dfaf5 x90279591611601bc, x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		if (x90279591611601bc != null || xd8f1949f8950238a != null)
		{
			xe125219852864557.x9e5d5f9128c69a8f = x90279591611601bc;
			xe125219852864557.x60465f602599d327 = xd8f1949f8950238a;
			x620a827d91bf9cfe x145e3af29556cafe = base.x28fcdc775a1d069c.x145e3af29556cafe;
			xe125219852864557.x4eada1f74f43bddb = x1b141b1f738926df.x3249302a2f0cd947(x145e3af29556cafe.x4eada1f74f43bddb);
			xe125219852864557.x52dde376accdec7d = x145e3af29556cafe.xf30a67c117fb87d6.xaccac17571a8d9fa.x8b61531c8ea35b85();
			x51d3a13ecd447601(xe125219852864557);
		}
	}

	internal override void x7725ad02c2c2b58a(x1e707bbc21c4527d xa4aa8b4150b11435)
	{
		if (xa41d0000655af070)
		{
			x680ab99924e08cb1.x4eada1f74f43bddb = x1b141b1f738926df.x3249302a2f0cd947(base.x28fcdc775a1d069c.x145e3af29556cafe.x4eada1f74f43bddb);
		}
	}

	private void x31c7ae4d986df847()
	{
		if (xd16a8c9589630813 == null)
		{
			xd16a8c9589630813 = new x1cab6af0a41b70e2();
		}
	}

	internal override void x7aeec455c69bcb61()
	{
		AddCurrentFigure(closed: true);
	}

	internal override void x3c0540ae9cb1631d()
	{
		xa41d0000655af070 = true;
		x680ab99924e08cb1 = new xab391c46ff9a0a38();
	}

	internal override void x7daa8e160444e6e7()
	{
		AddCurrentFigure(closed: false);
		xf50129d49459ace9();
		xa41d0000655af070 = false;
	}

	internal override void x64e906091e8e818c()
	{
		xf50129d49459ace9();
	}

	private void xf50129d49459ace9()
	{
		if (xa41d0000655af070 && x680ab99924e08cb1.x52dde376accdec7d == null)
		{
			x680ab99924e08cb1.x52dde376accdec7d = base.x28fcdc775a1d069c.x145e3af29556cafe.xf30a67c117fb87d6.xaccac17571a8d9fa.x8b61531c8ea35b85();
		}
	}

	public override void AddCurrentFigure(bool closed)
	{
		if (xd16a8c9589630813 != null)
		{
			xd16a8c9589630813.x5e6c52cb3256cc85 = closed;
			x680ab99924e08cb1.xd6b6ed77479ef68c(xd16a8c9589630813);
			xd16a8c9589630813 = null;
		}
	}

	internal override void x31f5bfff81fe1f68()
	{
		x845d6a068e0b03c5 x60465f602599d = base.x28fcdc775a1d069c.x145e3af29556cafe.x60465f602599d327;
		if (x680ab99924e08cb1 != null && x60465f602599d != null)
		{
			AddCurrentFigure(closed: true);
			x680ab99924e08cb1.x60465f602599d327 = x60465f602599d;
			x1a698b7602f4053a();
		}
	}

	internal override void x273b71f8a2416707()
	{
		x31c19fcb724dfaf5 x9e5d5f9128c69a8f = base.x28fcdc775a1d069c.x145e3af29556cafe.x9e5d5f9128c69a8f;
		if (x680ab99924e08cb1 != null && x9e5d5f9128c69a8f != null)
		{
			AddCurrentFigure(closed: false);
			x680ab99924e08cb1.x9e5d5f9128c69a8f = x9e5d5f9128c69a8f;
			x1a698b7602f4053a();
		}
	}

	internal override void x30a87f4f6034bea4()
	{
		x845d6a068e0b03c5 x60465f602599d = base.x28fcdc775a1d069c.x145e3af29556cafe.x60465f602599d327;
		x31c19fcb724dfaf5 x9e5d5f9128c69a8f = base.x28fcdc775a1d069c.x145e3af29556cafe.x9e5d5f9128c69a8f;
		if (x680ab99924e08cb1 != null && (x60465f602599d != null || x9e5d5f9128c69a8f != null))
		{
			AddCurrentFigure(closed: false);
			x680ab99924e08cb1.x60465f602599d327 = x60465f602599d;
			x680ab99924e08cb1.x9e5d5f9128c69a8f = x9e5d5f9128c69a8f;
			x1a698b7602f4053a();
		}
	}

	private void x1a698b7602f4053a()
	{
		x51d3a13ecd447601(x680ab99924e08cb1);
		x680ab99924e08cb1 = null;
	}

	internal override void x178c13a3817cb210(x209db13a33ccc536 xa4aa8b4150b11435)
	{
		if (x680ab99924e08cb1 != null)
		{
			AddCurrentFigure(closed: true);
			base.x28fcdc775a1d069c.x145e3af29556cafe.x5f80e37a7e055fe0(x680ab99924e08cb1, xa4aa8b4150b11435);
			x680ab99924e08cb1 = null;
		}
	}

	private void x51d3a13ecd447601(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x0e1bf8242ad10272 = base.x28fcdc775a1d069c.x145e3af29556cafe.x385638247aa8a54b;
		xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e37);
		x7a8a30505eb89f6e.xd6b6ed77479ef68c(xb8e7e788f6d);
	}
}
