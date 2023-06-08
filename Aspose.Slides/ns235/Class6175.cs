using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns235;

internal class Class6175
{
	private int int_0;

	private double[] double_0 = new double[4];

	public RectangleF method_0(Class6222 segment)
	{
		if (segment == null)
		{
			return RectangleF.Empty;
		}
		Struct219 curve = segment.Curve;
		return method_1(curve.StartPoint, curve.ControlPoint1, curve.ControlPoint2, curve.EndPoint);
	}

	public RectangleF method_1(PointF p1, PointF c1, PointF c2, PointF p2)
	{
		if (p1 == c1 && p1 == c2 && p1 == p2)
		{
			return new RectangleF(p1, SizeF.Empty);
		}
		int_0 = 0;
		method_2(p1, c1, c2, p2);
		List<PointF> bbox = method_3(p1, c1, c2, p2);
		return smethod_6(bbox);
	}

	private static double smethod_0(double p0, double p1, double p2, double p3, double t)
	{
		return (p3 - 3.0 * p2 + 3.0 * p1 - p0) * Math.Pow(t, 3.0) + (3.0 * p2 - 6.0 * p1 + 3.0 * p0) * Math.Pow(t, 2.0) + (3.0 * p1 - 3.0 * p0) * t + p0;
	}

	private static double smethod_1(double p0, double p1, double p2, double p3)
	{
		return 3.0 * p3 - 9.0 * p2 + 9.0 * p1 - 3.0 * p0;
	}

	private static double smethod_2(double p0, double p1, double p2)
	{
		return 6.0 * p2 - 12.0 * p1 + 6.0 * p0;
	}

	private static double smethod_3(double p0, double p1)
	{
		return 3.0 * p1 - 3.0 * p0;
	}

	private static double smethod_4(double a, double b, double c)
	{
		return Math.Pow(b, 2.0) - 4.0 * a * c;
	}

	private static double smethod_5(double a, double b, double c, bool s)
	{
		double d = smethod_4(a, b, c);
		return (0.0 - b + Math.Sqrt(d) * (s ? 1.0 : (-1.0))) / (2.0 * a);
	}

	private void method_2(PointF p1, PointF c1, PointF c2, PointF p2)
	{
		double a = smethod_1(p1.X, c1.X, c2.X, p2.X);
		double b = smethod_2(p1.X, c1.X, c2.X);
		double c3 = smethod_3(p1.X, c1.X);
		double a2 = smethod_1(p1.Y, c1.Y, c2.Y, p2.Y);
		double b2 = smethod_2(p1.Y, c1.Y, c2.Y);
		double c4 = smethod_3(p1.Y, c1.Y);
		method_4(a, b, c3);
		method_4(a2, b2, c4);
	}

	private List<PointF> method_3(PointF p1, PointF c1, PointF c2, PointF p2)
	{
		List<PointF> list = new List<PointF>();
		list.Add(p1);
		list.Add(p2);
		for (int i = 0; i < int_0; i++)
		{
			double t = double_0[i];
			double num = smethod_0(p1.X, c1.X, c2.X, p2.X, t);
			double num2 = smethod_0(p1.Y, c1.Y, c2.Y, p2.Y, t);
			PointF item = new PointF((float)num, (float)num2);
			list.Add(item);
		}
		return list;
	}

	private static RectangleF smethod_6(List<PointF> bbox)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		foreach (PointF item in bbox)
		{
			num = Math.Min(item.X, num);
			num2 = Math.Min(item.Y, num2);
			num3 = Math.Max(item.X, num3);
			num4 = Math.Max(item.Y, num4);
		}
		return new RectangleF(num, num2, num3 - num, num4 - num2);
	}

	private void method_4(double a, double b, double c)
	{
		double num = smethod_4(a, b, c);
		if (num < 0.0)
		{
			return;
		}
		if (a == 0.0)
		{
			if (b != 0.0)
			{
				method_5((0.0 - c) / b);
			}
		}
		else if (num == 0.0)
		{
			method_5(smethod_5(a, b, c, s: true));
		}
		else
		{
			method_5(smethod_5(a, b, c, s: true));
			method_5(smethod_5(a, b, c, s: false));
		}
	}

	private void method_5(double root)
	{
		if (!(root < 0.0) && 1.0 >= root)
		{
			double_0[int_0] = root;
			int_0++;
		}
	}
}
