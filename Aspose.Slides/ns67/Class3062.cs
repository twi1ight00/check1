using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns67;

internal class Class3062
{
	private const int int_0 = 90;

	private PointF pointF_0;

	private Struct158 struct158_0;

	private Struct158 struct158_1;

	private double double_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private List<PointF> list_0;

	private List<Enum458> list_1;

	private bool bool_3 = true;

	public PointF[] PathPoints => list_0.ToArray();

	public Enum458[] PathTypes => list_1.ToArray();

	public int PointCount => list_0.Count;

	public bool CutCurveTrailers
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class3062()
	{
		method_2();
		method_1();
	}

	public Class3062(FillMode fillMode)
	{
		method_2();
		method_1();
	}

	public Class3062(GraphicsPath path, float ratio)
	{
		method_2();
		method_1();
		for (int i = 0; i < path.PointCount; i++)
		{
			PointF pointF = path.PathPoints[i];
			list_1.Add((Enum458)path.PathTypes[i]);
			list_0.Add(new PointF(pointF.X * ratio, pointF.Y * ratio));
		}
	}

	public void Dispose()
	{
		method_1();
	}

	public RectangleF method_0()
	{
		if (list_0.Count == 0)
		{
			return default(Rectangle);
		}
		float num = float.MaxValue;
		float num2 = float.MinValue;
		float num3 = float.MaxValue;
		float num4 = float.MinValue;
		for (int i = 0; i < list_0.Count; i++)
		{
			PointF pointF = list_0[i];
			if (pointF.X < num)
			{
				num = pointF.X;
			}
			if (pointF.Y < num3)
			{
				num3 = pointF.Y;
			}
			if (pointF.X > num2)
			{
				num2 = pointF.X;
			}
			if (pointF.Y > num4)
			{
				num4 = pointF.Y;
			}
		}
		return new RectangleF(num, num3, Math.Abs(num2 - num), Math.Abs(num4 - num3));
	}

	public void method_1()
	{
		list_0 = new List<PointF>();
		list_1 = new List<Enum458>();
		bool_2 = false;
	}

	public void method_2()
	{
		struct158_0 = new Struct158(0.0, 0.0);
		struct158_1 = new Struct158(1.0, 1.0);
		double_0 = 0.0;
		method_16(horizontal: false, vertical: false);
		pointF_0 = new PointF(0f, 0f);
	}

	public void method_3(PointF pt1, PointF pt2)
	{
		method_4(pt1.X, pt1.Y, pt2.X, pt2.Y);
	}

	public void method_4(double x1, double y1, double x2, double y2)
	{
		list_0.Add(new PointF((float)x1, (float)y1));
		list_0.Add(new PointF((float)x2, (float)y2));
		method_20();
		list_1.Add(Enum458.flag_1);
	}

	public void method_5(PointF pt1, PointF pt2, PointF pt3, PointF pt4)
	{
		method_6(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
	}

	public void method_6(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
	{
		list_0.Add(new PointF((float)x1, (float)y1));
		list_0.Add(new PointF((float)x2, (float)y2));
		list_0.Add(new PointF((float)x3, (float)y3));
		list_0.Add(new PointF((float)x4, (float)y4));
		method_20();
		list_1.Add(Enum458.flag_2);
		list_1.Add(Enum458.flag_2);
		list_1.Add(Enum458.flag_2);
	}

	public PointF method_7(double x, double y, double a, double b, double start, double sweep)
	{
		return method_22(x, y, a, b, start, sweep, 1);
	}

	public PointF method_8(double x, double y, double a, double b, double start, double sweep)
	{
		return method_22(x, y, a, b, start, sweep, 2);
	}

	public void method_9(PointF[] points)
	{
		int num = points.Length - 1;
		if (num > 0)
		{
			float num2 = 0.16666f;
			list_0.Add(points[0]);
			method_20();
			list_0.Add(new PointF(points[0].X + (points[1].X - points[0].X) * num2, points[0].Y + (points[1].Y - points[0].Y) * num2));
			list_1.Add(Enum458.flag_2);
			for (int i = 1; i < num; i++)
			{
				float num3 = (points[i].X + points[i + 1].X - (points[i - 1].X + points[i].X)) * num2;
				float num4 = (points[i].Y + points[i + 1].Y - (points[i - 1].Y + points[i].Y)) * num2;
				list_0.Add(new PointF(points[i].X - num3, points[i].Y - num4));
				list_0.Add(new PointF(points[i].X, points[i].Y));
				list_0.Add(new PointF(points[i].X + num3, points[i].Y + num4));
				list_1.Add(Enum458.flag_2);
				list_1.Add(Enum458.flag_2);
				list_1.Add(Enum458.flag_2);
			}
			list_0.Add(new PointF(points[num].X + (points[num - 1].X - points[num].X) * num2, points[num].Y + (points[num - 1].Y - points[num].Y) * num2));
			list_1.Add(Enum458.flag_2);
			list_0.Add(points[num]);
			list_1.Add(Enum458.flag_2);
		}
	}

	public void method_10(string stringTest, FontFamily fontFamily, int fontstyle, double emSize, Point origin, StringFormat format)
	{
	}

	public void method_11()
	{
		bool_2 = false;
		if (list_1.Count > 0)
		{
			list_1[list_1.Count - 1] = list_1[list_1.Count - 1] | Enum458.flag_5;
		}
	}

	public void method_12()
	{
		PointF pointF = new PointF((float)((double)pointF_0.X * struct158_1.Dx), (float)((double)pointF_0.Y * struct158_1.Dy));
		sbyte b = (sbyte)((!bool_0) ? 1 : (-1));
		sbyte b2 = (sbyte)((!bool_1) ? 1 : (-1));
		double num = Math.Cos(double_0 * Math.PI / 180.0);
		double num2 = Math.Sin(double_0 * Math.PI / 180.0);
		for (int i = 0; i < list_0.Count; i++)
		{
			PointF value = list_0[i];
			value.X = (float)((double)pointF_0.X + (double)(value.X - pointF_0.X) * struct158_1.Dx * (double)b);
			value.Y = (float)((double)pointF_0.Y + (double)(value.Y - pointF_0.Y) * struct158_1.Dy * (double)b2);
			if (Math.Abs(double_0) > 1E-06)
			{
				float num3 = value.X - pointF_0.X;
				float num4 = value.Y - pointF_0.Y;
				value.X = (float)((double)pointF_0.X + (double)num3 * num - (double)num4 * num2);
				value.Y = (float)((double)pointF_0.Y + (double)num3 * num2 + (double)num4 * num);
			}
			value.X += (float)(struct158_0.Dx + (double)(pointF.X - pointF_0.X));
			value.Y += (float)(struct158_0.Dy + (double)(pointF.Y - pointF_0.Y));
			list_0[i] = value;
		}
	}

	public void method_13()
	{
		int count = list_0.Count;
		if (count < 1)
		{
			return;
		}
		List<PointF> points = new List<PointF>();
		List<Enum458> list = new List<Enum458>();
		PointF p = new PointF(0f, 0f);
		int num = 0;
		bool flag = false;
		while (num < count)
		{
			if ((list_1[num] & Enum458.flag_2) < Enum458.flag_2)
			{
				points.Add(list_0[num]);
				list.Add(list_1[num]);
				p = list_0[num];
				num++;
				continue;
			}
			flag = true;
			if (num + 2 < count)
			{
				Class3029 @class = new Class3029();
				@class.CutCurveTrailers = bool_3;
				@class.method_0(p, list_0[num], list_0[num + 1], list_0[num + 2], ref points);
				p = list_0[num + 2];
				while (list.Count < points.Count)
				{
					list.Add(Enum458.flag_1);
				}
				if ((list_1[num + 2] & Enum458.flag_5) == Enum458.flag_5)
				{
					list[list.Count - 1] = Enum458.flag_1 | Enum458.flag_5;
				}
			}
			num += 3;
		}
		if (flag)
		{
			list_0.Clear();
			list_1.Clear();
			list_0 = points;
			list_1 = list;
		}
	}

	public void method_14(double dx, double dy, bool append)
	{
		if (append)
		{
			struct158_0 = Struct158.smethod_1(struct158_0, new Struct158(dx, dy));
		}
		else
		{
			struct158_0 = new Struct158(dx, dy);
		}
	}

	public void method_15(double dx, double dy, bool append)
	{
		if (append)
		{
			struct158_1 = new Struct158(struct158_1.Dx * dx, struct158_1.Dy * dy);
		}
		else
		{
			struct158_1 = new Struct158(dx, dy);
		}
	}

	public void SetRotation(double angle, bool append)
	{
		if (append)
		{
			double_0 += angle;
		}
		else
		{
			double_0 = angle;
		}
		while (double_0 > 360.0)
		{
			double_0 -= 360.0;
		}
		while (double_0 < -360.0)
		{
			double_0 += 360.0;
		}
	}

	public void method_16(bool horizontal, bool vertical)
	{
		bool_0 = horizontal;
		bool_1 = vertical;
	}

	public void method_17(double x, double y)
	{
		pointF_0 = new PointF((float)x, (float)y);
	}

	private PointF method_18(PointF p1, double dx1, double dy1, PointF p2, double dx2, double dy2)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (Math.Abs(dy1) <= Math.Abs(dx1) && Math.Abs(dy1) < Math.Abs(dy2))
		{
			num2 = (dx1 * dy2 * (double)p1.Y - dx2 * dy1 * (double)p2.Y + dy1 * dy2 * (double)(p2.X - p1.X)) / (dx1 * dy2 - dx2 * dy1);
			return new PointF((float)(dx2 * (num2 - (double)p2.Y) / dy2 + (double)p2.X), (float)num2);
		}
		if (Math.Abs(dy2) <= Math.Abs(dx2) && Math.Abs(dy2) < Math.Abs(dy1))
		{
			num2 = (dx1 * dy2 * (double)p1.Y - dx2 * dy1 * (double)p2.Y + dy1 * dy2 * (double)(p2.X - p1.X)) / (dx1 * dy2 - dx2 * dy1);
			return new PointF((float)(dx1 * (num2 - (double)p1.Y) / dy1 + (double)p1.X), (float)num2);
		}
		if (Math.Abs(dx1) <= Math.Abs(dy1) && Math.Abs(dx1) < Math.Abs(dx2))
		{
			num = (dx1 * dy2 * (double)p2.X - dx2 * dy1 * (double)p1.X + dx2 * dx1 * (double)(p1.Y - p2.Y)) / (dx1 * dy2 - dx2 * dy1);
			return new PointF((float)num, (float)(dy2 * (num - (double)p2.X) / dx2 + (double)p2.Y));
		}
		if (Math.Abs(dx2) <= Math.Abs(dy2) && Math.Abs(dx2) < Math.Abs(dx1))
		{
			num = (dx1 * dy2 * (double)p2.X - dx2 * dy1 * (double)p1.X + dx2 * dx1 * (double)(p1.Y - p2.Y)) / (dx1 * dy2 - dx2 * dy1);
			return new PointF((float)num, (float)(dy1 * (num - (double)p1.X) / dx1 + (double)p1.Y));
		}
		return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
	}

	private PointF[] method_19(double a, double b, double start, double sweep)
	{
		PointF[] array = new PointF[4];
		double num = start * Math.PI / 180.0;
		double num2 = (start + sweep) * Math.PI / 180.0;
		double num3 = a * a;
		double num4 = b * b;
		double num5 = 1.0 - num4 / num3;
		double num6 = Math.Cos(num);
		double num7 = Math.Sqrt(num4 / (1.0 - num5 * num6 * num6));
		ref PointF reference = ref array[0];
		reference = new PointF((float)(num7 * num6), (float)(num7 * Math.Sin(num)));
		num6 = Math.Cos(num2);
		num7 = Math.Sqrt(num4 / (1.0 - num5 * num6 * num6));
		ref PointF reference2 = ref array[3];
		reference2 = new PointF((float)(num7 * num6), (float)(num7 * Math.Sin(num2)));
		PointF pointF = new PointF((array[0].X + array[3].X) / 2f, (array[0].Y + array[3].Y) / 2f);
		double num8 = Math.Sqrt(Math.Pow(b * (double)pointF.X / a, 2.0) + (double)(pointF.Y * pointF.Y));
		PointF p = ((!(Math.Abs(num8) < 1E-10)) ? new PointF((float)((double)pointF.X + 4.0 * ((double)pointF.X * b / num8 - (double)pointF.X) / 3.0), (float)((double)pointF.Y + 4.0 * ((double)pointF.Y * b / num8 - (double)pointF.Y) / 3.0)) : new PointF(0f, 0f));
		PointF pointF2 = new PointF((float)((double)array[0].X - (double)array[0].Y * a / b), (float)((double)array[0].Y + (double)array[0].X * b / a));
		PointF pointF3 = new PointF((float)((double)array[3].X + (double)array[3].Y * a / b), (float)((double)array[3].Y - (double)array[3].X * b / a));
		ref PointF reference3 = ref array[1];
		reference3 = method_18(array[0], pointF2.X - array[0].X, pointF2.Y - array[0].Y, p, array[3].X - array[0].X, array[3].Y - array[0].Y);
		ref PointF reference4 = ref array[2];
		reference4 = method_18(array[3], pointF3.X - array[3].X, pointF3.Y - array[3].Y, p, array[3].X - array[0].X, array[3].Y - array[0].Y);
		return array;
	}

	private void method_20()
	{
		if (bool_2)
		{
			list_1.Add(Enum458.flag_1);
			return;
		}
		bool_2 = true;
		list_1.Add(Enum458.flag_0);
	}

	private PointF[] method_21(double rx, double ry, double start, double sweep)
	{
		double num = start;
		bool flag = true;
		while (num > 360.0)
		{
			num -= 360.0;
		}
		for (; num < -360.0; num += 360.0)
		{
		}
		List<PointF> list = new List<PointF>();
		int num2 = (int)Math.Abs(sweep) / 90;
		if ((double)(num2 * 90) < Math.Abs(sweep))
		{
			num2++;
		}
		double num3 = sweep / (double)num2;
		for (int i = 0; i < num2; i++)
		{
			PointF[] array = method_19(rx, ry, num + (double)i * num3, num3);
			if (flag)
			{
				list.Add(array[0]);
				flag = false;
			}
			for (byte b = 1; b < 4; b = (byte)(b + 1))
			{
				list.Add(array[b]);
			}
		}
		return list.ToArray();
	}

	private PointF method_22(double x, double y, double a, double b, double start, double sweep, byte postype)
	{
		PointF result = new PointF((float)x, (float)y);
		PointF[] array = method_21(Math.Abs(a), Math.Abs(b), start, sweep);
		if (array.Length < 4)
		{
			return result;
		}
		PointF pointF = new PointF(array[0].X, array[0].Y);
		PointF pointF2 = new PointF(array[array.Length - 1].X, array[array.Length - 1].Y);
		double num = x + a;
		double num2 = y + b;
		switch (postype)
		{
		case 1:
			num = x - (double)pointF2.X;
			num2 = y - (double)pointF2.Y;
			result = new PointF((float)((double)pointF.X + num), (float)((double)pointF.Y + num2));
			break;
		case 2:
			num = x - (double)pointF.X;
			num2 = y - (double)pointF.Y;
			result = new PointF((float)((double)pointF2.X + num), (float)((double)pointF2.Y + num2));
			break;
		}
		list_0.Add(new PointF((float)((double)pointF.X + num), (float)((double)pointF.Y + num2)));
		method_20();
		for (int i = 1; i + 1 < array.Length; i++)
		{
			list_0.Add(new PointF((float)((double)array[i].X + num), (float)((double)array[i].Y + num2)));
			list_1.Add(Enum458.flag_2);
		}
		list_0.Add(new PointF((float)((double)pointF2.X + num), (float)((double)pointF2.Y + num2)));
		if (Math.Abs(sweep) >= 360.0)
		{
			list_1.Add(Enum458.flag_2 | Enum458.flag_5);
		}
		else
		{
			list_1.Add(Enum458.flag_2);
		}
		return result;
	}
}
