using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x72b16d0062c5ac6b
{
	private x72b16d0062c5ac6b()
	{
	}

	private static x26d9ecb4bdf0456d x579256a7af8d4be8(x26d9ecb4bdf0456d x6c50a99faab7d741, double x1965e484c4a7c6c6)
	{
		int newAlpha = ((x6c50a99faab7d741.xda71bf6f7c07c3bc != 255) ? x6c50a99faab7d741.xda71bf6f7c07c3bc : ((int)(255.0 * x1965e484c4a7c6c6)));
		return new x26d9ecb4bdf0456d(newAlpha, x6c50a99faab7d741);
	}

	internal static x845d6a068e0b03c5 xf450254daa20a6cc(x26d9ecb4bdf0456d x6c50a99faab7d741, double x1965e484c4a7c6c6)
	{
		return new xc020fa2f5133cba8(x579256a7af8d4be8(x6c50a99faab7d741, x1965e484c4a7c6c6));
	}

	internal static x845d6a068e0b03c5 x72e575a6c02e65f9(byte[] x43e181e083db6cdf, byte[] xa2ec7a3f2d25fef0, x26d9ecb4bdf0456d x6d9a095d183b6b50, x26d9ecb4bdf0456d x60a2487f840b534c)
	{
		if (xa2ec7a3f2d25fef0 == null)
		{
			xa2ec7a3f2d25fef0 = x43e181e083db6cdf;
		}
		if (xa2ec7a3f2d25fef0 == null)
		{
			return xf450254daa20a6cc(x6d9a095d183b6b50, 1.0);
		}
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(xa2ec7a3f2d25fef0);
		x5e9754e56a4f759f.xe25bcbc1e660bc36 = new x26d9ecb4bdf0456d[4]
		{
			x26d9ecb4bdf0456d.x8f02f53f1587477d,
			x6d9a095d183b6b50,
			x26d9ecb4bdf0456d.x89fffa2751fdecbe,
			x60a2487f840b534c
		};
		x5e9754e56a4f759f.xaccac17571a8d9fa.x5152a5707921c783(0.75f, 0.75f, MatrixOrder.Prepend);
		return x5e9754e56a4f759f;
	}

	internal static x845d6a068e0b03c5 xec4f084465a18f01(Fill xd925f447ef7e00a4, byte[] xa2ec7a3f2d25fef0, xa99f8d94adfe1070 xf565f10dc33d0569)
	{
		if (xa2ec7a3f2d25fef0 == null)
		{
			xa2ec7a3f2d25fef0 = xd925f447ef7e00a4.ImageBytes;
		}
		if (xa2ec7a3f2d25fef0 == null)
		{
			return xf450254daa20a6cc(xd925f447ef7e00a4.x63b1a7c31a962459, xd925f447ef7e00a4.Opacity);
		}
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(xa2ec7a3f2d25fef0, WrapMode.Clamp);
		x5e9754e56a4f759f.xd163a712710650fc = (float)xd925f447ef7e00a4.Opacity;
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xa2ec7a3f2d25fef0);
		x5e9754e56a4f759f.xaccac17571a8d9fa = xf565f10dc33d0569.xd311686697c8cc84(xa2745adfabe0c.x437e3b626c0fdd43, xd925f447ef7e00a4.xc9cb2de01432549c);
		return x5e9754e56a4f759f;
	}

	private static bool xdbfb87c5102501e8(Fill xd925f447ef7e00a4)
	{
		if (x1245728b17d5a3c8(xd925f447ef7e00a4) && xd925f447ef7e00a4.x63b1a7c31a962459.xb2c94956116ca10a() == xd925f447ef7e00a4.x5424d51d40e7c452.xb2c94956116ca10a())
		{
			return xd925f447ef7e00a4.Opacity == xd925f447ef7e00a4.xf317e5a4f28798af;
		}
		return false;
	}

	private static bool x1245728b17d5a3c8(Fill xd925f447ef7e00a4)
	{
		if (xd925f447ef7e00a4.x7efed8bb5b845184 != null)
		{
			return xd925f447ef7e00a4.x7efed8bb5b845184.Length == 0;
		}
		return true;
	}

	internal static x845d6a068e0b03c5 x7f3743a5bb962d40(xab391c46ff9a0a38 xe125219852864557, Fill xd925f447ef7e00a4, PointF x9e8f25190daa42b1)
	{
		if (xdbfb87c5102501e8(xd925f447ef7e00a4))
		{
			return xf450254daa20a6cc(xd925f447ef7e00a4.x63b1a7c31a962459, xd925f447ef7e00a4.Opacity);
		}
		xa587dcb499c221cc xa587dcb499c221cc = new xa587dcb499c221cc(xe125219852864557, x9e8f25190daa42b1);
		x06fb51f105bd496d(xd925f447ef7e00a4, xa587dcb499c221cc);
		return xa587dcb499c221cc;
	}

	private static void x06fb51f105bd496d(Fill xd925f447ef7e00a4, xf022bb98711420db xd8f1949f8950238a)
	{
		if (x1245728b17d5a3c8(xd925f447ef7e00a4))
		{
			x08b2fcb6d6ddf5fd(xd925f447ef7e00a4, xd8f1949f8950238a);
		}
		else
		{
			xdb39adeb04b6f6f0(xd925f447ef7e00a4, xd8f1949f8950238a);
		}
	}

	private static void x08b2fcb6d6ddf5fd(Fill xd925f447ef7e00a4, xf022bb98711420db xd8f1949f8950238a)
	{
		x26d9ecb4bdf0456d x63b1a7c31a = xd925f447ef7e00a4.x63b1a7c31a962459;
		x26d9ecb4bdf0456d x6c50a99faab7d = xe94ea7ebbcdea7d1.x71b38f10fe7e82a7(xd925f447ef7e00a4.x5424d51d40e7c452, x63b1a7c31a);
		x63b1a7c31a = x579256a7af8d4be8(x63b1a7c31a, xd925f447ef7e00a4.Opacity);
		x6c50a99faab7d = x579256a7af8d4be8(x6c50a99faab7d, xd925f447ef7e00a4.xf317e5a4f28798af);
		xee3f81a88b302c10[] xeea1afd2d98fac = new xee3f81a88b302c10[2]
		{
			new xee3f81a88b302c10(x63b1a7c31a, 0f),
			new xee3f81a88b302c10(x6c50a99faab7d, 1f)
		};
		xd8f1949f8950238a.xcc7b76ceb682651c = x6255f02300acd7d4(xeea1afd2d98fac, xd925f447ef7e00a4);
	}

	private static void xdb39adeb04b6f6f0(Fill xd925f447ef7e00a4, xf022bb98711420db xd8f1949f8950238a)
	{
		x9fb6ff04f20b10d0[] x7efed8bb5b = xd925f447ef7e00a4.x7efed8bb5b845184;
		int num = x7efed8bb5b.Length;
		xee3f81a88b302c10[] array = new xee3f81a88b302c10[num];
		for (int i = 0; i < num; i++)
		{
			double num2 = (float)x4574ea26106f0edb.x97ab502db0c0e5c2(x7efed8bb5b[i].x12cb12b5d2cad53d);
			double x1965e484c4a7c6c = xd925f447ef7e00a4.xf317e5a4f28798af + (xd925f447ef7e00a4.Opacity - xd925f447ef7e00a4.xf317e5a4f28798af) * num2;
			x26d9ecb4bdf0456d color = x579256a7af8d4be8(x7efed8bb5b[i].x9b41425268471380, x1965e484c4a7c6c);
			array[i] = new xee3f81a88b302c10(color, (float)num2);
		}
		int num3 = array.Length;
		if (array[0].xbe1e23e7d5b43370 > 0f)
		{
			num3++;
		}
		if (array[^1].xbe1e23e7d5b43370 < 1f)
		{
			num3++;
		}
		xee3f81a88b302c10[] array2 = array;
		if (num3 > array.Length)
		{
			array2 = new xee3f81a88b302c10[num3];
			int num4 = 0;
			if (array[0].xbe1e23e7d5b43370 > 0f)
			{
				array2[0] = new xee3f81a88b302c10(array[0].x9b41425268471380, 0f);
				num4++;
			}
			Array.Copy(array, 0, array2, num4, array.Length);
			if (array[^1].xbe1e23e7d5b43370 < 1f)
			{
				array2[num3 - 1] = new xee3f81a88b302c10(array[^1].x9b41425268471380, 1f);
			}
		}
		xd8f1949f8950238a.xcc7b76ceb682651c = x6255f02300acd7d4(array2, xd925f447ef7e00a4);
	}

	private static xee3f81a88b302c10[] x6255f02300acd7d4(xee3f81a88b302c10[] xeea1afd2d98fac23, Fill xd925f447ef7e00a4)
	{
		float num = xd925f447ef7e00a4.xe2631b5200d4f95c;
		if (x32eb67d3dfec99ef(xd925f447ef7e00a4))
		{
			num = ((num > 0f) ? (num - 100f) : (num + 100f));
		}
		if (num == 0f)
		{
			return xeea1afd2d98fac23;
		}
		int num2 = xeea1afd2d98fac23.Length;
		xee3f81a88b302c10[] array;
		if (num == 100f)
		{
			array = new xee3f81a88b302c10[xeea1afd2d98fac23.Length];
			for (int i = 0; i < num2; i++)
			{
				array[num2 - 1 - i] = new xee3f81a88b302c10(xeea1afd2d98fac23[i].x9b41425268471380, 1f - xeea1afd2d98fac23[i].xbe1e23e7d5b43370);
			}
			return array;
		}
		num *= 0.01f;
		float num3;
		float num4;
		if (num > 0f)
		{
			num3 = 1f - num;
			num4 = num;
		}
		else
		{
			num3 = 0f - num;
			num4 = 1f + num;
		}
		array = new xee3f81a88b302c10[num2 * 2];
		for (int j = 0; j < num2; j++)
		{
			xee3f81a88b302c10 xee3f81a88b302c = xeea1afd2d98fac23[(num > 0f) ? j : (num2 - 1 - j)];
			float num5 = ((num > 0f) ? xee3f81a88b302c.xbe1e23e7d5b43370 : (1f - xee3f81a88b302c.xbe1e23e7d5b43370));
			array[j] = new xee3f81a88b302c10(xee3f81a88b302c.x9b41425268471380, num5 * num3);
			array[array.Length - 1 - j] = new xee3f81a88b302c10(xee3f81a88b302c.x9b41425268471380, 1f - num5 * num4);
		}
		return array;
	}

	internal static x845d6a068e0b03c5 x755ff959ec7c69dd(Shape x5770cdefd8931aa9, SizeF x5fe500e03a0fd24f)
	{
		Fill fill = x5770cdefd8931aa9.Fill;
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		RectangleF rectangleF = new RectangleF(0f, 0f, x5fe500e03a0fd24f.Width, x5fe500e03a0fd24f.Height);
		PointF x2f7096dac971d6ec;
		if (x5770cdefd8931aa9.x22d2b300aac1d857)
		{
			x2f7096dac971d6ec = x37d2d88f96f87b47.x2955b4a385e56d39((float)fill.xd870ef2502e0b7c6, (float)fill.xe37a18eec85366de, rectangleF);
			x2f7096dac971d6ec = x37d2d88f96f87b47.x446008b8673ea50c(x2f7096dac971d6ec, x37d2d88f96f87b47.x0aa7e9f1585a5d1e(rectangleF), (float)x5770cdefd8931aa9.Rotation);
			PointF[] x6fa2570084b2ad = x37d2d88f96f87b47.x803f7e17594bfa52(rectangleF, (float)x5770cdefd8931aa9.Rotation);
			x1cab6af0a41b70e.x8992595b6d42d9bd(x6fa2570084b2ad);
		}
		else
		{
			RectangleF rectangleF2 = x37d2d88f96f87b47.x0e39179c0d6ed809(rectangleF, (float)x5770cdefd8931aa9.Rotation);
			x2f7096dac971d6ec = x37d2d88f96f87b47.x2955b4a385e56d39((float)fill.xd870ef2502e0b7c6, (float)fill.xe37a18eec85366de, rectangleF2);
			x1cab6af0a41b70e.xb90eeef3d2a5a96b(rectangleF2);
		}
		return x7f3743a5bb962d40(xab391c46ff9a0a, fill, x2f7096dac971d6ec);
	}

	internal static x845d6a068e0b03c5 xb9d757f2231cc2a8(Shape x5770cdefd8931aa9, SizeF x5fe500e03a0fd24f)
	{
		Fill fill = x5770cdefd8931aa9.Fill;
		if (x7ad8b429df4d1783.x383bc40a65c287d0(x5fe500e03a0fd24f))
		{
			return null;
		}
		if (xdbfb87c5102501e8(fill))
		{
			return xf450254daa20a6cc(fill.x63b1a7c31a962459, fill.Opacity);
		}
		RectangleF x26545669838eb36e = new RectangleF(0f, 0f, x5fe500e03a0fd24f.Width, x5fe500e03a0fd24f.Height);
		float num = 0f - (float)fill.x6b1fe03343d9a6a4 - 90f;
		float num2 = (float)x5770cdefd8931aa9.xb494f7568f103233;
		RectangleF empty = RectangleF.Empty;
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		if (x5770cdefd8931aa9.x22d2b300aac1d857)
		{
			x54366fa5f75a02f.x49d618948c467be6(num2 + num, x37d2d88f96f87b47.x0aa7e9f1585a5d1e(x26545669838eb36e));
			empty = x37d2d88f96f87b47.x0e39179c0d6ed809(x26545669838eb36e, 0f - num);
		}
		else
		{
			x54366fa5f75a02f.x49d618948c467be6(num, x37d2d88f96f87b47.x0aa7e9f1585a5d1e(x26545669838eb36e));
			RectangleF x26545669838eb36e2 = x37d2d88f96f87b47.x0e39179c0d6ed809(x26545669838eb36e, num2);
			empty = x37d2d88f96f87b47.x0e39179c0d6ed809(x26545669838eb36e2, 0f - num);
		}
		x5f55370cc09dd787 x5f55370cc09dd = new x5f55370cc09dd787(empty);
		x5f55370cc09dd.xaccac17571a8d9fa = x54366fa5f75a02f;
		x06fb51f105bd496d(fill, x5f55370cc09dd);
		return x5f55370cc09dd;
	}

	internal static x845d6a068e0b03c5 xa903f8f328b4c169(Fill xd925f447ef7e00a4, byte[] xa2ec7a3f2d25fef0, float x5fa921135f3d5de2)
	{
		if (xa2ec7a3f2d25fef0 == null)
		{
			xa2ec7a3f2d25fef0 = xd925f447ef7e00a4.ImageBytes;
		}
		if (xa2ec7a3f2d25fef0 == null)
		{
			return xf450254daa20a6cc(xd925f447ef7e00a4.x63b1a7c31a962459, xd925f447ef7e00a4.Opacity);
		}
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(xa2ec7a3f2d25fef0);
		x5e9754e56a4f759f.xaccac17571a8d9fa.xa77087bb05d9ef76(x5fa921135f3d5de2, MatrixOrder.Prepend);
		return x5e9754e56a4f759f;
	}

	internal static bool x32eb67d3dfec99ef(Fill xd925f447ef7e00a4)
	{
		switch (xd925f447ef7e00a4.xeba92971120d3e5a)
		{
		default:
			return false;
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
		case xeba92971120d3e5a.x408710144185f184:
		{
			int num = (int)xd925f447ef7e00a4.x6b1fe03343d9a6a4;
			if (num == -135 || num == -90 || num == -45)
			{
				return true;
			}
			return false;
		}
		}
	}
}
