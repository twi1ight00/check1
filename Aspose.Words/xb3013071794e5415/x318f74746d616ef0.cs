using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using x4dc96876c552a593;
using x5794c252ba25e723;
using x5f5ca2a37b849b4a;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class x318f74746d616ef0
{
	private const int xa8885d7d5757feeb = 5;

	private const int xbd731dfe86b60904 = 1;

	private static Regex xe2995e73650e0332 = new Regex("(\".*\")|(\\\\\\S)", RegexOptions.Compiled);

	private static Regex xa3583de55bf5dff4 = new Regex("K|[ghHmst]{1,2}|z{1,3}|[dM]{1,4}|y{1,5}|[fF]{1,7}", RegexOptions.Compiled);

	private static Regex x43e1530420f14e6e = new Regex("(h{1,2}([-\\$\\+\\(:\\^'\\{<=/\\)!&~}>\\s]|(\".*\")|(\\\\\\S))*)(M{1,2})", RegexOptions.Compiled);

	private static Regex x273bc6091e9207bc = new Regex("(M{1,2})(([-\\$\\+\\(:\\^'\\{<=/\\)!&~}>\\s]|(\".*\")|(\\\\\\S))*s{1,2})", RegexOptions.Compiled);

	private x318f74746d616ef0()
	{
	}

	internal static xcc8c7739d82c63ba x67e197bbfa6da21d(string xb41faee6912a2313, PointF x9c3c185e7046dc72, x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9, bool x461bfa5b6ec21819)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = xdc2247c8d4648ae8(x5d73ec97767a1b0c, x461bfa5b6ec21819, x0f7b23d1c393aed9);
		x26d9ecb4bdf0456d color = xc9e6b27cab90a4f6(x5d73ec97767a1b0c, x0f7b23d1c393aed9);
		x26d9ecb4bdf0456d outlineColor = xf703086956193672(x5d73ec97767a1b0c, x0f7b23d1c393aed9);
		x9c3c185e7046dc72 = new PointF(x9c3c185e7046dc72.X, x9c3c185e7046dc72.Y + (float)x4574ea26106f0edb.x3aa08882c9feaf96(xe39d06eee35dd23d.xd9ac1486133b5a4e));
		return new xcc8c7739d82c63ba(xe39d06eee35dd23d, color, outlineColor, x9c3c185e7046dc72, xb41faee6912a2313, 0f);
	}

	internal static float xce9adc25a876be06(string xb41faee6912a2313, x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9, bool x461bfa5b6ec21819)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = xdc2247c8d4648ae8(x5d73ec97767a1b0c, x461bfa5b6ec21819, x0f7b23d1c393aed9);
		return x4574ea26106f0edb.x3aa08882c9feaf96(xe39d06eee35dd23d.xee2b4ba51feab3ca(xb41faee6912a2313));
	}

	internal static float xa9c9583c571d7dc3(x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9, bool x461bfa5b6ec21819)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = xdc2247c8d4648ae8(x5d73ec97767a1b0c, x461bfa5b6ec21819, x0f7b23d1c393aed9);
		return x4574ea26106f0edb.x3aa08882c9feaf96(xe39d06eee35dd23d.x53531537bb3331e6);
	}

	private static xe39d06eee35dd23d xdc2247c8d4648ae8(x4694a3400bb4849a x5d73ec97767a1b0c, bool x461bfa5b6ec21819, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x7423ef514d81c23e xe11545499171cc = (x461bfa5b6ec21819 ? x0f7b23d1c393aed9.x5e969e12ada2aab2.xc2d4efc42998d87b.xbf72f566c4f69fb6 : x0f7b23d1c393aed9.x5e969e12ada2aab2.xc2d4efc42998d87b.xa52e32074afc58c7);
		x5d73ec97767a1b0c.xeedad81aaed42a76.x81b5ab71da5b7ae4(xe11545499171cc);
		return x0f7b23d1c393aed9.xdf9285c24d089295.xef51a39b06006bb9(x5d73ec97767a1b0c.xeedad81aaed42a76);
	}

	internal static x26d9ecb4bdf0456d xc9e6b27cab90a4f6(x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x7423ef514d81c23e x7423ef514d81c23e = ((x5d73ec97767a1b0c != null) ? x5d73ec97767a1b0c.xeedad81aaed42a76 : new x7423ef514d81c23e());
		x7423ef514d81c23e.x81b5ab71da5b7ae4(x0f7b23d1c393aed9.x5e969e12ada2aab2.xc2d4efc42998d87b.xa52e32074afc58c7);
		return x7423ef514d81c23e.x6a81a30bcaf20a97.GetSingleColor(x0f7b23d1c393aed9.x5e969e12ada2aab2.xa42a8eb21319f8e0.xe209e476a780d1b4);
	}

	internal static x26d9ecb4bdf0456d xf703086956193672(x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x7423ef514d81c23e x7423ef514d81c23e = ((x5d73ec97767a1b0c != null) ? x5d73ec97767a1b0c.xeedad81aaed42a76 : new x7423ef514d81c23e());
		x7423ef514d81c23e.x81b5ab71da5b7ae4(x0f7b23d1c393aed9.x5e969e12ada2aab2.xc2d4efc42998d87b.xa52e32074afc58c7);
		x26d9ecb4bdf0456d result = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		if (x7423ef514d81c23e.x93e68a44438355fd != null && x7423ef514d81c23e.x93e68a44438355fd.x6a81a30bcaf20a97 != null)
		{
			result = x7423ef514d81c23e.x93e68a44438355fd.x6a81a30bcaf20a97.GetSingleColor(x0f7b23d1c393aed9.x5e969e12ada2aab2.xa42a8eb21319f8e0.xe209e476a780d1b4);
		}
		return result;
	}

	internal static x31c19fcb724dfaf5 x2f0c16e51db81725(xbc46977eebea4733 x82f66163e01f713f, xcd38be6e82bc4732 x85449f0299df03c4, int xc0c4c459c6ccbd00)
	{
		x31c19fcb724dfaf5 x31c19fcb724dfaf = x85449f0299df03c4.x4066f02a899a3f58(xc0c4c459c6ccbd00);
		if (x82f66163e01f713f.x93e68a44438355fd != null)
		{
			x85449f0299df03c4.xd8466ede46721ede(x82f66163e01f713f.x93e68a44438355fd, xc0c4c459c6ccbd00);
			x31c19fcb724dfaf = x82f66163e01f713f.x93e68a44438355fd.x2f0c16e51db81725(x85449f0299df03c4.xe209e476a780d1b4);
		}
		if (x31c19fcb724dfaf == null)
		{
			x31c19fcb724dfaf = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x45260ad4b94166f2, 0f);
		}
		return x31c19fcb724dfaf;
	}

	internal static x845d6a068e0b03c5 xa3fa1ce4ffca3dc3(xbc46977eebea4733 x82f66163e01f713f, xcd38be6e82bc4732 x85449f0299df03c4, int xc0c4c459c6ccbd00, x4fdf549af9de6b97 xce40e23f89e248c8)
	{
		x845d6a068e0b03c5 x845d6a068e0b03c = x85449f0299df03c4.x5186c65b9c8cb4c4(xc0c4c459c6ccbd00, xce40e23f89e248c8);
		if (x82f66163e01f713f.x6a81a30bcaf20a97 != null)
		{
			x85449f0299df03c4.xe209e476a780d1b4.x4b34cc8966adf8f7 = null;
			x845d6a068e0b03c = x82f66163e01f713f.x6a81a30bcaf20a97.CreateBrush(x85449f0299df03c4.xe209e476a780d1b4);
		}
		x99abbb429861fb9d(x845d6a068e0b03c, x85449f0299df03c4.xe209e476a780d1b4.x6a1f9e96254c40aa);
		return x845d6a068e0b03c;
	}

	private static void x99abbb429861fb9d(x845d6a068e0b03c5 xd8f1949f8950238a, RectangleF xd7f0d3d971623a27)
	{
		if (xd8f1949f8950238a != null && xd8f1949f8950238a.x4bc21f84846f912d == x0b257a9fb413b6c3.x7b6a6d281546db99)
		{
			x5e9754e56a4f759f x5e9754e56a4f759f = (x5e9754e56a4f759f)xd8f1949f8950238a;
			if (x5e9754e56a4f759f.xaccac17571a8d9fa == null)
			{
				x5e9754e56a4f759f.xaccac17571a8d9fa = new x54366fa5f75a02f7();
			}
			x5e9754e56a4f759f.xaccac17571a8d9fa.xce92de628aa023cf(xd7f0d3d971623a27.X, xd7f0d3d971623a27.Y, MatrixOrder.Append);
		}
	}

	internal static void x5bd690fbaae89142(xab391c46ff9a0a38 xe125219852864557, xbc46977eebea4733 x82f66163e01f713f, xcd38be6e82bc4732 x85449f0299df03c4, int xc0c4c459c6ccbd00)
	{
		xe125219852864557.x60465f602599d327 = xa3fa1ce4ffca3dc3(x82f66163e01f713f, x85449f0299df03c4, xc0c4c459c6ccbd00, xe125219852864557);
		xe125219852864557.x9e5d5f9128c69a8f = x2f0c16e51db81725(x82f66163e01f713f, x85449f0299df03c4, xc0c4c459c6ccbd00);
	}

	internal static float[] xfdf7ff990b986a85(x958ddf7e6db1ce94 xe640ebcce83ddadc)
	{
		float[] array = new float[xe640ebcce83ddadc.x28627c25cb262062];
		foreach (x9b87766ad1dbe8d6 item in xe640ebcce83ddadc.xc869533ad93d98d3)
		{
			for (int i = 0; i < array.Length; i++)
			{
				x86270791cf6a92b9 x86270791cf6a92b = item.x141ab7d3c1198e04.x2206903f9421fd4b(i);
				if (x86270791cf6a92b != null)
				{
					array[i] += x86270791cf6a92b.FloatValue;
				}
			}
		}
		return array;
	}

	internal static int x2e4333c9c4cb20bb(float x7d4cdf301067fefb, x4694a3400bb4849a x5d73ec97767a1b0c, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = xdc2247c8d4648ae8(x5d73ec97767a1b0c, x461bfa5b6ec21819: false, x0f7b23d1c393aed9);
		float num = x4574ea26106f0edb.x3aa08882c9feaf96(xe39d06eee35dd23d.xd9ac1486133b5a4e);
		if (x7d4cdf301067fefb >= num)
		{
			return 1;
		}
		return (int)(num / x7d4cdf301067fefb + 1f);
	}

	internal static string x8658aec77e6fb580(string xb400313f3c752847)
	{
		string xcdaeea7afaf570ff = xb400313f3c752847.Replace('m', 'M');
		xcdaeea7afaf570ff = x13bbe4992ba59d6d(xcdaeea7afaf570ff, x44e147cf24761c32: true);
		return x13bbe4992ba59d6d(xcdaeea7afaf570ff, x44e147cf24761c32: false);
	}

	private static string x13bbe4992ba59d6d(string xcdaeea7afaf570ff, bool x44e147cf24761c32)
	{
		Regex regex = (x44e147cf24761c32 ? x43e1530420f14e6e : x273bc6091e9207bc);
		int groupnum = ((!x44e147cf24761c32) ? 1 : 5);
		Match match = regex.Match(xcdaeea7afaf570ff);
		if (x0d299f323d241756.x5959bccb67bbf051(match.Value))
		{
			string value = match.Groups[groupnum].Value;
			return xcdaeea7afaf570ff.Replace(match.Value, match.Value.Replace(value, value.ToLower()));
		}
		return xcdaeea7afaf570ff;
	}

	internal static bool x770aa0cb67e3d6bc(string x92f10ef6823bd0cb)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x92f10ef6823bd0cb))
		{
			return false;
		}
		string input = xe2995e73650e0332.Replace(x92f10ef6823bd0cb, "");
		return xa3583de55bf5dff4.IsMatch(input);
	}

	internal static RectangleF x8dae03a2613b9b6c(RectangleF x96569c15adb59cae, xa4d912a00c540cf0 x2612f62f94df47de, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		if (x2612f62f94df47de != null)
		{
			float num = (float)((double)x0f7b23d1c393aed9.x43e348908d6e68da.Width * x2612f62f94df47de.x72d92bd1aff02e37);
			float num2 = (float)((double)x0f7b23d1c393aed9.x43e348908d6e68da.Height * x2612f62f94df47de.xe360b1885d8d4a41);
			float num3 = (float)((double)x0f7b23d1c393aed9.x43e348908d6e68da.Width * x2612f62f94df47de.xdc1bf80853046136);
			float num4 = (float)((double)x0f7b23d1c393aed9.x43e348908d6e68da.Height * x2612f62f94df47de.xb0f146032f47c24e);
			if (x2612f62f94df47de.x076d70d185480532 == xb835a4c3060ff213.x99befc15cc07a198)
			{
				num3 -= num;
			}
			if (x2612f62f94df47de.x940b2e5d94bf3627 == xb835a4c3060ff213.x99befc15cc07a198)
			{
				num4 -= num2;
			}
			if (num3 <= 0f)
			{
				num3 = x0f7b23d1c393aed9.x43e348908d6e68da.Width - num;
			}
			if (num4 <= 0f)
			{
				num4 = x0f7b23d1c393aed9.x43e348908d6e68da.Height - num2;
			}
			return new RectangleF(num, num2, num3, num4);
		}
		return x96569c15adb59cae;
	}
}
