using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace xe9fa6af9e1184312;

internal class x8aa17f414e2bc8c9
{
	private PointF x3cd7a9f2b7b9534f;

	private PointF x5f6999764265a823;

	private PointF xc83d0e6d4611cafd;

	private x1cab6af0a41b70e2 x452b030a6e9cfa9e;

	private readonly xab391c46ff9a0a38 xf34ef61ecae1eb73;

	private static readonly Regex xea2cc5df39609238 = new Regex("(M|m|Z|z|L|l|H|h|V|v|C|c|S|s|Q|q|T|t|A|a)([^MmZzLlHhVvCcSsQqTtAa]+)?");

	internal x8aa17f414e2bc8c9(xab391c46ff9a0a38 path)
	{
		xc83d0e6d4611cafd = default(PointF);
		x452b030a6e9cfa9e = new x1cab6af0a41b70e2();
		xf34ef61ecae1eb73 = path;
	}

	internal void xdc399cbe0b8fbc0b(string x0a657b39dd0fcfe5, x1fdc4491fb4c3ee8 x0f7b23d1c393aed9)
	{
		MatchCollection matchCollection = xea2cc5df39609238.Matches(x0a657b39dd0fcfe5);
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[1].Value;
			float[] array = xf7e2753b1f50fb2b.x18509d4eed26e020(item.Groups[2].Value);
			x129c916eaa775281(value);
			switch (value)
			{
			case "M":
				x01b2723108ff3dfe(array[0], array[1], x44c75ba56852f87a: true);
				break;
			case "m":
				x01b2723108ff3dfe(array[0], array[1], x44c75ba56852f87a: false);
				break;
			case "L":
				xb74b98ae150bc04e(array, x44c75ba56852f87a: true);
				break;
			case "l":
				xb74b98ae150bc04e(array, x44c75ba56852f87a: false);
				break;
			case "H":
				xb74b98ae150bc04e(xa454c26fed372271(array, x44c75ba56852f87a: true, xe51c6c8096b26a1f: false), x44c75ba56852f87a: true);
				break;
			case "h":
				xb74b98ae150bc04e(xa454c26fed372271(array, x44c75ba56852f87a: false, xe51c6c8096b26a1f: false), x44c75ba56852f87a: false);
				break;
			case "V":
				xb74b98ae150bc04e(xa454c26fed372271(array, x44c75ba56852f87a: true, xe51c6c8096b26a1f: true), x44c75ba56852f87a: true);
				break;
			case "v":
				xb74b98ae150bc04e(xa454c26fed372271(array, x44c75ba56852f87a: false, xe51c6c8096b26a1f: true), x44c75ba56852f87a: false);
				break;
			case "A":
				xd36175ac1fa09b26(array, x44c75ba56852f87a: true);
				break;
			case "a":
				xd36175ac1fa09b26(array, x44c75ba56852f87a: false);
				break;
			case "C":
				xbdc7e9965f95164d(array, x44c75ba56852f87a: true, x7294d5ef8f2e2c13: false);
				break;
			case "c":
				xbdc7e9965f95164d(array, x44c75ba56852f87a: false, x7294d5ef8f2e2c13: false);
				break;
			case "S":
				xbdc7e9965f95164d(array, x44c75ba56852f87a: true, x7294d5ef8f2e2c13: true);
				break;
			case "s":
				xbdc7e9965f95164d(array, x44c75ba56852f87a: false, x7294d5ef8f2e2c13: true);
				break;
			case "Q":
				xf1f2d5a4cf9d7ab6(array, x44c75ba56852f87a: true, x7294d5ef8f2e2c13: false);
				break;
			case "q":
				xf1f2d5a4cf9d7ab6(array, x44c75ba56852f87a: false, x7294d5ef8f2e2c13: false);
				break;
			case "T":
				xf1f2d5a4cf9d7ab6(array, x44c75ba56852f87a: true, x7294d5ef8f2e2c13: true);
				break;
			case "t":
				xf1f2d5a4cf9d7ab6(array, x44c75ba56852f87a: false, x7294d5ef8f2e2c13: true);
				break;
			case "Z":
			case "z":
				x452b030a6e9cfa9e.x5e6c52cb3256cc85 = true;
				break;
			default:
				x0f7b23d1c393aed9.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"'{value}' is unexpected path command and will be ignored");
				break;
			}
		}
		xf34ef61ecae1eb73.xd6b6ed77479ef68c(x452b030a6e9cfa9e);
	}

	private void x129c916eaa775281(string xfd6dd6e53b1a26d5)
	{
		switch (xfd6dd6e53b1a26d5)
		{
		case "C":
		case "c":
		case "S":
		case "s":
			x5f6999764265a823 = default(PointF);
			break;
		case "Q":
		case "q":
		case "T":
		case "t":
			x3cd7a9f2b7b9534f = default(PointF);
			break;
		default:
			x3cd7a9f2b7b9534f = default(PointF);
			x5f6999764265a823 = default(PointF);
			break;
		}
	}

	private void x01b2723108ff3dfe(float x08db3aeabb253cb1, float x1e218ceaee1bb583, bool x44c75ba56852f87a)
	{
		if (x452b030a6e9cfa9e.xd44988f225497f3a > 0)
		{
			xf34ef61ecae1eb73.xd6b6ed77479ef68c(x452b030a6e9cfa9e);
		}
		x452b030a6e9cfa9e = new x1cab6af0a41b70e2();
		xc83d0e6d4611cafd = new PointF(x44c75ba56852f87a ? x08db3aeabb253cb1 : (xc83d0e6d4611cafd.X + x08db3aeabb253cb1), x44c75ba56852f87a ? x1e218ceaee1bb583 : (xc83d0e6d4611cafd.Y + x1e218ceaee1bb583));
		x452b030a6e9cfa9e.x8992595b6d42d9bd(new PointF[1]
		{
			new PointF(xc83d0e6d4611cafd.X, xc83d0e6d4611cafd.Y)
		});
	}

	private void xb74b98ae150bc04e(float[] x399f202a31ac5420, bool x44c75ba56852f87a)
	{
		if (!x44c75ba56852f87a)
		{
			x399f202a31ac5420 = x5250eb7a7b42db99(x399f202a31ac5420);
		}
		xc83d0e6d4611cafd = new PointF(x399f202a31ac5420[^2], x399f202a31ac5420[^1]);
		x452b030a6e9cfa9e.xd6b6ed77479ef68c(new x60c040f35bb272aa(x399f202a31ac5420));
	}

	private void xbdc7e9965f95164d(float[] x399f202a31ac5420, bool x44c75ba56852f87a, bool x7294d5ef8f2e2c13)
	{
		if (!x44c75ba56852f87a)
		{
			x399f202a31ac5420 = x5250eb7a7b42db99(x399f202a31ac5420);
		}
		PointF pointF = xc83d0e6d4611cafd;
		PointF cubP = (x7294d5ef8f2e2c13 ? x7ac0bdde1b0f8d10(x3cd7a9f2b7b9534f, pointF) : new PointF(x399f202a31ac5420[0], x399f202a31ac5420[1]));
		PointF cubP2 = new PointF(x399f202a31ac5420[^4], x399f202a31ac5420[^3]);
		PointF cubP3 = new PointF(x399f202a31ac5420[^2], x399f202a31ac5420[^1]);
		x452b030a6e9cfa9e.xd6b6ed77479ef68c(new x519b1bd0625473ff(pointF, cubP, cubP2, cubP3));
		xc83d0e6d4611cafd = cubP3;
		x3cd7a9f2b7b9534f = cubP2;
	}

	private void xf1f2d5a4cf9d7ab6(float[] x399f202a31ac5420, bool x44c75ba56852f87a, bool x7294d5ef8f2e2c13)
	{
		if (!x44c75ba56852f87a)
		{
			x399f202a31ac5420 = x5250eb7a7b42db99(x399f202a31ac5420);
		}
		PointF pointF = xc83d0e6d4611cafd;
		PointF quadP = (x7294d5ef8f2e2c13 ? x7ac0bdde1b0f8d10(x5f6999764265a823, pointF) : new PointF(x399f202a31ac5420[0], x399f202a31ac5420[1]));
		PointF quadP2 = new PointF(x399f202a31ac5420[^2], x399f202a31ac5420[^1]);
		x452b030a6e9cfa9e.xd6b6ed77479ef68c(new x519b1bd0625473ff(pointF, quadP, quadP2));
		xc83d0e6d4611cafd = quadP2;
		x5f6999764265a823 = quadP;
	}

	private static PointF x7ac0bdde1b0f8d10(PointF xb87b7305ef2b2389, PointF xeeb1f7e9c2d6528d)
	{
		if (xb87b7305ef2b2389.IsEmpty)
		{
			return xeeb1f7e9c2d6528d;
		}
		float x = xeeb1f7e9c2d6528d.X * 2f - xb87b7305ef2b2389.X;
		float y = xeeb1f7e9c2d6528d.Y * 2f - xb87b7305ef2b2389.Y;
		return new PointF(x, y);
	}

	private void xd36175ac1fa09b26(float[] x399f202a31ac5420, bool x44c75ba56852f87a)
	{
		double num = xc83d0e6d4611cafd.X;
		double num2 = xc83d0e6d4611cafd.Y;
		double num3 = x399f202a31ac5420[0];
		double num4 = x399f202a31ac5420[1];
		double num5 = x15e971129fd80714.xcdc7b29a812dd7df(x399f202a31ac5420[2]);
		double num6 = x399f202a31ac5420[4];
		double num7 = (x44c75ba56852f87a ? x399f202a31ac5420[5] : (xc83d0e6d4611cafd.X + x399f202a31ac5420[5]));
		double num8 = (x44c75ba56852f87a ? x399f202a31ac5420[6] : (xc83d0e6d4611cafd.Y + x399f202a31ac5420[6]));
		if (!x15e971129fd80714.x5ab3b42bd288ad29(num3) && !x15e971129fd80714.x5ab3b42bd288ad29(num4))
		{
			double num9 = (num - num7) / 2.0;
			double num10 = (num2 - num8) / 2.0;
			double num11 = Math.Cos(num5) * num9 + Math.Sin(num5) * num10;
			double num12 = (0.0 - Math.Sin(num5)) * num9 + Math.Cos(num5) * num10;
			num3 = Math.Abs(num3);
			num4 = Math.Abs(num4);
			double num13 = num3 * num3;
			double num14 = num4 * num4;
			double num15 = num11 * num11;
			double num16 = num12 * num12;
			double num17 = num15 / num13 + num16 / num14;
			if (num17 > 1.0)
			{
				num3 *= Math.Sqrt(num17);
				num4 *= Math.Sqrt(num17);
				num13 = num3 * num3;
				num14 = num4 * num4;
			}
			double x77d17eeb695582c = x399f202a31ac5420[3];
			double num18 = ((!x15e971129fd80714.xd23801717be7f91e(x77d17eeb695582c, num6)) ? 1 : (-1));
			double num19 = (num13 * num14 - num13 * num16 - num14 * num15) / (num13 * num16 + num14 * num15);
			num19 = ((num19 < 0.0 || double.IsNaN(num19)) ? 0.0 : num19);
			double num20 = num18 * Math.Sqrt(num19);
			double num21 = num20 * (num3 * num12 / num4);
			double num22 = num20 * (0.0 - num4 * num11 / num3);
			double num23 = (num + num7) / 2.0;
			double num24 = (num2 + num8) / 2.0;
			double num25 = num23 + (Math.Cos(num5) * num21 - Math.Sin(num5) * num22);
			double num26 = num24 + (Math.Sin(num5) * num21 + Math.Cos(num5) * num22);
			double num27 = (num11 - num21) / num3;
			double num28 = (num12 - num22) / num4;
			double num29 = (0.0 - num11 - num21) / num3;
			double num30 = (0.0 - num12 - num22) / num4;
			double num31 = Math.Sqrt(num27 * num27 + num28 * num28);
			double num32 = num27;
			num18 = ((!(num28 < 0.0)) ? 1 : (-1));
			double xbdcb5f8a10694ec = num18 * Math.Acos(num32 / num31);
			xbdcb5f8a10694ec = x15e971129fd80714.xc9211137ad7bfa2a(xbdcb5f8a10694ec);
			num31 = Math.Sqrt((num27 * num27 + num28 * num28) * (num29 * num29 + num30 * num30));
			num32 = num27 * num29 + num28 * num30;
			num18 = ((!(num27 * num30 - num28 * num29 < 0.0)) ? 1 : (-1));
			double xbdcb5f8a10694ec2 = num18 * Math.Acos(num32 / num31);
			xbdcb5f8a10694ec2 = x15e971129fd80714.xc9211137ad7bfa2a(xbdcb5f8a10694ec2);
			if (num6 == 0.0 && xbdcb5f8a10694ec2 > 0.0)
			{
				xbdcb5f8a10694ec2 -= 360.0;
			}
			else if (x15e971129fd80714.xd23801717be7f91e(num6, 1.0) && xbdcb5f8a10694ec2 < 0.0)
			{
				xbdcb5f8a10694ec2 += 360.0;
			}
			xbdcb5f8a10694ec2 %= 360.0;
			xbdcb5f8a10694ec %= 360.0;
			RectangleF bounds = new RectangleF((float)(num25 - num3), (float)(num26 - num4), (float)(num3 * 2.0), (float)(num4 * 2.0));
			x1fb5d45c2d0b868a xc919e9fef7dfced = new x1fb5d45c2d0b868a(bounds, xbdcb5f8a10694ec, xbdcb5f8a10694ec2);
			x452b030a6e9cfa9e.xb6e955ab98a0878c(xc919e9fef7dfced);
			xc83d0e6d4611cafd = new PointF((float)num7, (float)num8);
		}
	}

	private float[] x5250eb7a7b42db99(float[] x0f255236e796d1b9)
	{
		float[] array = new float[x0f255236e796d1b9.Length];
		int num = x0f255236e796d1b9.Length / 2;
		for (int i = 0; i < num; i++)
		{
			xc83d0e6d4611cafd = new PointF(xc83d0e6d4611cafd.X + x0f255236e796d1b9[i * 2], xc83d0e6d4611cafd.Y + x0f255236e796d1b9[i * 2 + 1]);
			array[i * 2] = xc83d0e6d4611cafd.X;
			array[i * 2 + 1] = xc83d0e6d4611cafd.Y;
		}
		return array;
	}

	private float[] xa454c26fed372271(float[] x399f202a31ac5420, bool x44c75ba56852f87a, bool xe51c6c8096b26a1f)
	{
		float[] array = new float[x399f202a31ac5420.Length * 2];
		for (int i = 0; i < array.Length; i++)
		{
			if (xe51c6c8096b26a1f)
			{
				float num = (x44c75ba56852f87a ? xc83d0e6d4611cafd.X : 0f);
				array[i] = ((i % 2 == 0) ? num : x399f202a31ac5420[i / 2]);
			}
			else
			{
				float num2 = (x44c75ba56852f87a ? xc83d0e6d4611cafd.Y : 0f);
				array[i] = ((i % 2 == 0) ? x399f202a31ac5420[i / 2] : num2);
			}
		}
		return array;
	}
}
