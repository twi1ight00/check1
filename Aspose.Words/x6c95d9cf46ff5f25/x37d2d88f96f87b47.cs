using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal class x37d2d88f96f87b47
{
	public const float xb4aed8fff53d1e5a = 0.001f;

	public static PointF x0aa7e9f1585a5d1e(RectangleF x26545669838eb36e)
	{
		return new PointF(x26545669838eb36e.X + x26545669838eb36e.Width / 2f, x26545669838eb36e.Y + x26545669838eb36e.Height / 2f);
	}

	public static PointF[] x73aa13730a957b6c(RectangleF x26545669838eb36e)
	{
		return new PointF[4]
		{
			new PointF(x26545669838eb36e.Left, x26545669838eb36e.Top),
			new PointF(x26545669838eb36e.Right, x26545669838eb36e.Top),
			new PointF(x26545669838eb36e.Right, x26545669838eb36e.Bottom),
			new PointF(x26545669838eb36e.Left, x26545669838eb36e.Bottom)
		};
	}

	public static RectangleF x0e39179c0d6ed809(RectangleF x26545669838eb36e, float xcb83cdf6822fc99d)
	{
		return x37b1dbbad6246778(x803f7e17594bfa52(x26545669838eb36e, xcb83cdf6822fc99d));
	}

	public static RectangleF x37b1dbbad6246778(PointF[] x93f8a7b2acc92741)
	{
		float x = x93f8a7b2acc92741[0].X;
		float num = x;
		float y = x93f8a7b2acc92741[0].Y;
		float num2 = y;
		for (int i = 0; i < x93f8a7b2acc92741.Length; i++)
		{
			PointF pointF = x93f8a7b2acc92741[i];
			if (pointF.X > x)
			{
				x = pointF.X;
			}
			else if (pointF.X < num)
			{
				num = pointF.X;
			}
			if (pointF.Y > y)
			{
				y = pointF.Y;
			}
			else if (pointF.Y < num2)
			{
				num2 = pointF.Y;
			}
		}
		return new RectangleF(num, num2, x - num, y - num2);
	}

	public static PointF[] x803f7e17594bfa52(RectangleF x26545669838eb36e, float xcb83cdf6822fc99d)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x49d618948c467be6(xcb83cdf6822fc99d, x0aa7e9f1585a5d1e(x26545669838eb36e));
		PointF[] array = x73aa13730a957b6c(x26545669838eb36e);
		x54366fa5f75a02f.xa4b699bd47eb7372(array);
		return array;
	}

	public static PointF x446008b8673ea50c(PointF x2f7096dac971d6ec, PointF x07dd0dbdd9cbea83, float xcb83cdf6822fc99d)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x49d618948c467be6(xcb83cdf6822fc99d, x07dd0dbdd9cbea83);
		return x54366fa5f75a02f.x5c785f1d561da269(x2f7096dac971d6ec);
	}

	public static RectangleF xb79f5c307f99b920(RectangleF x6d221d87c8d977c5, RectangleF x23efac81c557d686)
	{
		PointF[] array = x73aa13730a957b6c(x6d221d87c8d977c5);
		PointF[] array2 = x73aa13730a957b6c(x23efac81c557d686);
		return x37b1dbbad6246778(new PointF[8]
		{
			array[0],
			array[1],
			array[2],
			array[3],
			array2[0],
			array2[1],
			array2[2],
			array2[3]
		});
	}

	public static PointF x2955b4a385e56d39(float xb3f3660b7784c49b, float x4c32757036d37fe2, RectangleF x399f202a31ac5420)
	{
		return new PointF(xb3f3660b7784c49b * x399f202a31ac5420.Width + x399f202a31ac5420.X, x4c32757036d37fe2 * x399f202a31ac5420.Height + x399f202a31ac5420.Y);
	}

	public static bool xb81c335b66ecc867(PointF[] x6fa2570084b2ad39)
	{
		float num = 0f;
		if (x6fa2570084b2ad39.Length == 2)
		{
			float num2 = x6fa2570084b2ad39[1].X - x6fa2570084b2ad39[0].X;
			return num2 < 0f;
		}
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			num = ((i != x6fa2570084b2ad39.Length - 1) ? (num + (x6fa2570084b2ad39[i].X * x6fa2570084b2ad39[i + 1].Y - x6fa2570084b2ad39[i + 1].X * x6fa2570084b2ad39[i].Y)) : (num + (x6fa2570084b2ad39[i].X * x6fa2570084b2ad39[0].Y - x6fa2570084b2ad39[0].X * x6fa2570084b2ad39[i].Y)));
		}
		return num < 0f;
	}

	public static bool xb81c335b66ecc867(ArrayList x6fa2570084b2ad39)
	{
		return xb81c335b66ecc867((PointF[])x6fa2570084b2ad39.ToArray(typeof(PointF)));
	}

	public static float x5af88e61b614ce62(PointF x9b61de08eafdb554, PointF x5bc3b3e534cfe6dc)
	{
		return (float)Math.Sqrt(x113cf57ce1569d99(x9b61de08eafdb554.X - x5bc3b3e534cfe6dc.X) + x113cf57ce1569d99(x9b61de08eafdb554.Y - x5bc3b3e534cfe6dc.Y));
	}

	public static bool x5a48dddfe8c0ac5b(PointF x9b61de08eafdb554, PointF x5bc3b3e534cfe6dc, float x0add632534344332)
	{
		return x5af88e61b614ce62(x9b61de08eafdb554, x5bc3b3e534cfe6dc) < x0add632534344332;
	}

	public static bool xd0fdca5aa42d16bc(PointF x9b61de08eafdb554, PointF x5bc3b3e534cfe6dc)
	{
		return x5af88e61b614ce62(x9b61de08eafdb554, x5bc3b3e534cfe6dc) < 0.001f;
	}

	public static bool xe1aec5445964a68c(float x274503c7c54fac3a, float x64bb2cef95dc215a)
	{
		return Math.Abs(x64bb2cef95dc215a - x274503c7c54fac3a) < 0.001f;
	}

	public static float x113cf57ce1569d99(float x0078185e1040c523)
	{
		return x0078185e1040c523 * x0078185e1040c523;
	}

	public static float x69e3accf817415e7(x67293147609631f8[] x51efd71b3cdcbf9c)
	{
		float num = 0f;
		for (int i = 0; i < x51efd71b3cdcbf9c.Length; i++)
		{
			num += x51efd71b3cdcbf9c[i].x1deebb03a3d03a50();
		}
		return num;
	}
}
