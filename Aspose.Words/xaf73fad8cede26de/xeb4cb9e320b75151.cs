using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using xf9a9481c3f63a419;

namespace xaf73fad8cede26de;

internal class xeb4cb9e320b75151
{
	private xeb4cb9e320b75151()
	{
	}

	internal static void x3a53bab86bc1dfad(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		switch (xd8f1949f8950238a.x4bc21f84846f912d)
		{
		case x0b257a9fb413b6c3.xb8751dec55f64252:
			x2d4bd958d81cf347(xd07ce4b74c5774a7, (xc020fa2f5133cba8)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x7b6a6d281546db99:
			x8b0138e3a8860975(xd07ce4b74c5774a7, x0f7b23d1c393aed9, (x5e9754e56a4f759f)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee:
			x2657b6d735e613cc(xd07ce4b74c5774a7, x0f7b23d1c393aed9, (x5bdb4ba66c23277c)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x37b6ad6b01d0c641:
			x142461a28475509c(xd07ce4b74c5774a7, (x5f55370cc09dd787)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x73039d25e580af15:
			x8b0138e3a8860975(xd07ce4b74c5774a7, x0f7b23d1c393aed9, x6fb77f4cc018ceba.xa903f8f328b4c169((xa587dcb499c221cc)xd8f1949f8950238a));
			break;
		default:
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bfjlhgamjghmigomagfnnfmnjfdojfkoifbpgeipcepplpfakdnaheebhelbceccedjcjopckdhdmdodadfeccmeiocf", 2055321852)));
		}
	}

	internal static void x927e197c87ba6884(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4, RectangleF x47807e698c6282d5, WrapMode xd3daaf20904f5daa, x54366fa5f75a02f7 x5b0b266e72247144)
	{
		xfc4b33756f599219 xfc4b33756f599220 = x0f7b23d1c393aed9.xa9557f69810d0afe(x43e181e083db6cdf, x5edc4e0499c937b4);
		xd07ce4b74c5774a7.x2307058321cdb62f("ImageBrush");
		xd07ce4b74c5774a7.xff520a0047c27122("ImageSource", xfc4b33756f599220.xb405a444ca77e2d4);
		xa2745adfabe0c674 x437e3b626c0fdd = xfc4b33756f599220.x437e3b626c0fdd43;
		RectangleF xbcea506a33cf = new RectangleF(0f, 0f, (float)x7a02f1cfc55b8a6a.xef598e966b5dee6f(x437e3b626c0fdd.xd0c3f0768d960161), (float)x7a02f1cfc55b8a6a.xef598e966b5dee6f(x437e3b626c0fdd.xeb129b9a992183c5));
		xd07ce4b74c5774a7.xff520a0047c27122("Viewbox", xbcea506a33cf);
		if (!x02df97c06afacbf3.x1c140bd1078ddda1(x5edc4e0499c937b4))
		{
			x47807e698c6282d5 = x5edc4e0499c937b4.xade9cf8b9eb86a8e(x47807e698c6282d5);
		}
		RectangleF xbcea506a33cf2 = new RectangleF(x47807e698c6282d5.X, x47807e698c6282d5.Y, (x47807e698c6282d5.Width > 0f) ? x47807e698c6282d5.Width : ((float)x437e3b626c0fdd.xd0c3f0768d960161), (x47807e698c6282d5.Height > 0f) ? x47807e698c6282d5.Height : ((float)x437e3b626c0fdd.xeb129b9a992183c5));
		xd07ce4b74c5774a7.xff520a0047c27122("Viewport", xbcea506a33cf2);
		xd07ce4b74c5774a7.xff520a0047c27122("ViewboxUnits", "Absolute");
		xd07ce4b74c5774a7.xff520a0047c27122("ViewportUnits", "Absolute");
		if (x5b0b266e72247144 != null)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("Transform", x5b0b266e72247144);
		}
		xd07ce4b74c5774a7.xff520a0047c27122("TileMode", x7a02f1cfc55b8a6a.x7fafd389d77711f2(xd3daaf20904f5daa));
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x2d4bd958d81cf347(x49c255776a98e55d xd07ce4b74c5774a7, xc020fa2f5133cba8 xd8f1949f8950238a)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("SolidColorBrush");
		xd07ce4b74c5774a7.xff520a0047c27122("Color", xd8f1949f8950238a.x9b41425268471380);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x142461a28475509c(x49c255776a98e55d xd07ce4b74c5774a7, x5f55370cc09dd787 xd8f1949f8950238a)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("LinearGradientBrush");
		xd07ce4b74c5774a7.xff520a0047c27122("MappingMode", "Absolute");
		xd07ce4b74c5774a7.xff520a0047c27122("StartPoint", xd8f1949f8950238a.x404d528fe2f10961.X, xd8f1949f8950238a.x404d528fe2f10961.Y);
		xd07ce4b74c5774a7.xff520a0047c27122("EndPoint", xd8f1949f8950238a.x404d528fe2f10961.Right, xd8f1949f8950238a.x404d528fe2f10961.Top);
		xd07ce4b74c5774a7.xff520a0047c27122("SpreadMethod", "Repeat");
		if (xd8f1949f8950238a.xaccac17571a8d9fa != null)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("Transform", xd8f1949f8950238a.xaccac17571a8d9fa);
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("LinearGradientBrush.GradientStops");
		if (xd8f1949f8950238a.xcc7b76ceb682651c == null)
		{
			xc9ea7c71f56791c6(xd07ce4b74c5774a7, xd8f1949f8950238a.x7d2dc175c2f289c5, 0f);
			xc9ea7c71f56791c6(xd07ce4b74c5774a7, xd8f1949f8950238a.xf3874816968aabd7, 1f);
		}
		else
		{
			xee3f81a88b302c10[] xcc7b76ceb682651c = xd8f1949f8950238a.xcc7b76ceb682651c;
			foreach (xee3f81a88b302c10 xee3f81a88b302c in xcc7b76ceb682651c)
			{
				xc9ea7c71f56791c6(xd07ce4b74c5774a7, xee3f81a88b302c.x9b41425268471380, xee3f81a88b302c.xbe1e23e7d5b43370);
			}
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xc9ea7c71f56791c6(x49c255776a98e55d xd07ce4b74c5774a7, x26d9ecb4bdf0456d x6c50a99faab7d741, float x374ea4fe62468d0f)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("GradientStop");
		xd07ce4b74c5774a7.xff520a0047c27122("Color", x6c50a99faab7d741);
		xd07ce4b74c5774a7.xff520a0047c27122("Offset", x374ea4fe62468d0f);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x2657b6d735e613cc(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		byte[] x43e181e083db6cdf = x973c394bd6a899a2.xb19c72971505e3ca(xd8f1949f8950238a);
		x927e197c87ba6884(xd07ce4b74c5774a7, x0f7b23d1c393aed9, x43e181e083db6cdf, null, RectangleF.Empty, WrapMode.Tile, null);
	}

	private static void x8b0138e3a8860975(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, x5e9754e56a4f759f xd8f1949f8950238a)
	{
		using x3cd5d648729cd9b6 x4e889a1a809d1ee = new x3cd5d648729cd9b6(xd8f1949f8950238a);
		byte[] x43e181e083db6cdf = x0f7b23d1c393aed9.x868ce3362de17d74.x601e9a2243ca6720(x4e889a1a809d1ee);
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(x43e181e083db6cdf);
		RectangleF x47807e698c6282d = new RectangleF(0f, 0f, xa2745adfabe0c.xdc1bf80853046136, xa2745adfabe0c.xb0f146032f47c24e);
		x927e197c87ba6884(xd07ce4b74c5774a7, x0f7b23d1c393aed9, x43e181e083db6cdf, null, x47807e698c6282d, xd8f1949f8950238a.x349ff0df1e641b4e, xd8f1949f8950238a.xaccac17571a8d9fa.x8b61531c8ea35b85());
	}
}
