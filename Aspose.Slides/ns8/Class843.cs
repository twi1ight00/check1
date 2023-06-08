using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns18;
using ns56;

namespace ns8;

internal static class Class843
{
	public static void smethod_0(GeometryShape target, Struct46 leftTop, Struct46[] points)
	{
		Class1828 @class = new Class1828();
		@class.PathLst.delegate1549_0();
		Class1894 path = @class.PathLst.PathList[0];
		smethod_6(path, new Struct46(points[0].X - leftTop.X, points[0].Y - leftTop.Y));
		for (int i = 1; i < points.Length; i++)
		{
			smethod_7(path, new Struct46(points[i].X - leftTop.X, points[i].Y - leftTop.Y));
		}
		smethod_5(target, @class);
	}

	public static void smethod_1(GeometryShape target, Struct45 arc, Class842 arrow)
	{
		Class1828 @class = new Class1828();
		@class.PathLst.delegate1549_0();
		Class1894 path = @class.PathLst.PathList[0];
		double num = (arc.IsReverse ? arc.EndAngle : arc.StartAngle);
		double num2 = (arc.IsReverse ? arc.StartAngle : arc.EndAngle);
		double num3 = ((!(num2 - num < 0.0)) ? 1 : (-1));
		if (num2 - num < 0.0 && (Math.Abs(num2 - num) >= 180.0 || arc.ForceLongCurve))
		{
			num3 *= -1.0;
		}
		double num4 = smethod_9(num);
		Struct46 @struct = new Struct46(arc.CenterX + arc.Radius * Math.Cos(num4), arc.CenterY + arc.Radius * Math.Sin(num4));
		Struct50 norm = new Struct47(arc.CenterX, arc.CenterY, @struct.X, @struct.Y).Norm;
		double num5 = smethod_9(num2);
		Struct46 struct2 = new Struct46(arc.CenterX + arc.Radius * Math.Cos(num5), arc.CenterY + arc.Radius * Math.Sin(num5));
		Struct50 norm2 = new Struct47(arc.CenterX, arc.CenterY, struct2.X, struct2.Y).Norm;
		if (arrow.HasBeginningArrowhead)
		{
			num += smethod_10(arrow.ArrowWidth, arc.Radius) * num3;
		}
		num4 = smethod_9(num);
		Struct46 struct3 = new Struct46(arc.CenterX + arc.Radius * Math.Cos(num4), arc.CenterY + arc.Radius * Math.Sin(num4));
		Struct50 norm3 = new Struct47(arc.CenterX, arc.CenterY, struct3.X, struct3.Y).Norm;
		if (arrow.HasEndingArrowhead)
		{
			num2 -= smethod_10(arrow.ArrowWidth, arc.Radius) * num3;
		}
		num5 = smethod_9(num2);
		Struct46 struct4 = new Struct46(arc.CenterX + arc.Radius * Math.Cos(num5), arc.CenterY + arc.Radius * Math.Sin(num5));
		Struct50 norm4 = new Struct47(arc.CenterX, arc.CenterY, struct4.X, struct4.Y).Norm;
		double num6 = num2 - num;
		if (num6 < 0.0 && (Math.Abs(num6) >= 180.0 || arc.ForceLongCurve))
		{
			num6 = 360.0 + num6;
		}
		smethod_6(path, new Struct46(@struct.X - arc.Left, @struct.Y - arc.Top));
		if (arrow.HasBeginningArrowhead)
		{
			smethod_7(path, new Struct46(struct3.X - norm3.Dx * arrow.ArrowHeight - arc.Left, struct3.Y - norm3.Dy * arrow.ArrowHeight - arc.Top));
			smethod_7(path, new Struct46(struct3.X - norm3.Dx * arrow.Thickness - arc.Left, struct3.Y - norm3.Dy * arrow.Thickness - arc.Top));
		}
		else
		{
			smethod_7(path, new Struct46(@struct.X - norm.Dx * arrow.Thickness - arc.Left, @struct.Y - norm.Dy * arrow.Thickness - arc.Top));
		}
		smethod_8(path, arc.Radius + arrow.Thickness, num, num6);
		if (arrow.HasEndingArrowhead)
		{
			smethod_7(path, new Struct46(struct4.X - norm4.Dx * arrow.ArrowHeight - arc.Left, struct4.Y - norm4.Dy * arrow.ArrowHeight - arc.Top));
			smethod_7(path, new Struct46(struct2.X - arc.Left, struct2.Y - arc.Top));
			smethod_7(path, new Struct46(struct4.X + norm4.Dx * arrow.ArrowHeight - arc.Left, struct4.Y + norm4.Dy * arrow.ArrowHeight - arc.Top));
			smethod_7(path, new Struct46(struct4.X + norm4.Dx * arrow.Thickness - arc.Left, struct4.Y + norm4.Dy * arrow.Thickness - arc.Top));
		}
		else
		{
			smethod_7(path, new Struct46(struct2.X + norm2.Dx * arrow.Thickness - arc.Left, struct2.Y + norm2.Dy * arrow.Thickness - arc.Top));
		}
		smethod_8(path, arc.Radius - arrow.Thickness, num2, 0.0 - num6);
		if (arrow.HasBeginningArrowhead)
		{
			smethod_7(path, new Struct46(struct3.X + norm3.Dx * arrow.ArrowHeight - arc.Left, struct3.Y + norm3.Dy * arrow.ArrowHeight - arc.Top));
		}
		smethod_7(path, new Struct46(@struct.X - arc.Left, @struct.Y - arc.Top));
		smethod_5(target, @class);
	}

	public static Struct46[] smethod_2(Class837 point, Struct47 shapeBounds, Class851 source, Class851 target, Enum126 bending)
	{
		Struct49 @struct = default(Struct49);
		Struct49 struct2 = default(Struct49);
		Struct47 struct3 = new Struct47(source.X, source.Y, source.X + source.Width, source.Y + source.Height);
		Struct47 struct4 = new Struct47(target.X, target.Y, target.X + target.Width, target.Y + target.Height);
		List<Struct49> list = struct3.method_0(shapeBounds.StartX, shapeBounds.StartY);
		List<Struct49> list2 = struct4.method_0(shapeBounds.EndX, shapeBounds.EndY);
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (flag)
			{
				break;
			}
			Struct49 struct5 = list[i];
			for (int j = 0; j < list2.Count; j++)
			{
				Struct49 struct6 = list2[j];
				int num = struct5.Dx + struct6.Dx;
				int num2 = struct5.Dy + struct6.Dy;
				if (num == 0 && num2 == 0 && ((struct5.Dx == 1 && source.X < target.X) || (struct5.Dx == -1 && source.X > target.X) || (struct5.Dy == 1 && source.Y < target.Y) || (struct5.Dy == -1 && !(source.Y <= target.Y))))
				{
					@struct = struct5;
					struct2 = struct6;
					flag2 = true;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			for (int k = 0; k < list.Count; k++)
			{
				if (flag)
				{
					break;
				}
				Struct49 struct7 = list[k];
				for (int l = 0; l < list2.Count; l++)
				{
					Struct49 struct8 = list2[l];
					sbyte b = ((shapeBounds.StartX > shapeBounds.EndX) ? struct7.Dx : struct8.Dx);
					sbyte b2 = ((shapeBounds.StartX < shapeBounds.EndX) ? struct7.Dx : struct8.Dx);
					sbyte b3 = ((shapeBounds.StartY > shapeBounds.EndY) ? struct7.Dy : struct8.Dy);
					sbyte b4 = ((shapeBounds.StartY < shapeBounds.EndY) ? struct7.Dy : struct8.Dy);
					if (b - b2 == -1 && b3 - b4 == -1)
					{
						@struct = struct7;
						struct2 = struct8;
						flag = true;
						break;
					}
				}
			}
		}
		List<Struct46> list3 = new List<Struct46>(4);
		list3.Add(new Struct46(shapeBounds.StartX, shapeBounds.StartY));
		if (flag)
		{
			if (flag2)
			{
				Struct48 struct9 = new Struct48(shapeBounds.Width / 2.0, shapeBounds.Height / 2.0);
				Struct48 struct10 = new Struct48(shapeBounds.Width / 2.0, shapeBounds.Height / 2.0);
				double num3 = point.method_30(Enum305.const_5);
				switch (bending)
				{
				case Enum126.const_1:
					struct9 = new Struct48(num3, num3);
					struct10 = new Struct48(shapeBounds.Width - num3, shapeBounds.Height - num3);
					break;
				case Enum126.const_2:
					struct9 = new Struct48(shapeBounds.Width - num3, shapeBounds.Height - num3);
					struct10 = new Struct48(num3, num3);
					break;
				}
				list3.Add(new Struct46(shapeBounds.StartX + struct9.Width * (double)@struct.Dx, shapeBounds.StartY + struct9.Height * (double)@struct.Dy));
				list3.Add(new Struct46(shapeBounds.EndX + struct10.Width * (double)struct2.Dx, shapeBounds.EndY + struct10.Height * (double)struct2.Dy));
			}
			else
			{
				list3.Add(new Struct46(shapeBounds.StartX + shapeBounds.Width * (double)@struct.Dx, shapeBounds.StartY + shapeBounds.Height * (double)@struct.Dy));
			}
		}
		list3.Add(new Struct46(shapeBounds.EndX, shapeBounds.EndY));
		return list3.ToArray();
	}

	public static Struct46[] smethod_3(Struct47 bounds, Class842 arrow)
	{
		Struct50 norm = bounds.Norm;
		Struct50 @struct = new Struct50(0.0 - norm.Dy, norm.Dx);
		bounds = new Struct47(bounds.StartX - norm.Dx * arrow.BeginPadding, bounds.StartY - norm.Dy * arrow.BeginPadding, bounds.EndX + norm.Dx * arrow.EndPadding, bounds.EndY + norm.Dy * arrow.EndPadding);
		Struct46 struct2 = new Struct46(bounds.StartX - arrow.ArrowWidth * norm.Dx, bounds.StartY - arrow.ArrowWidth * norm.Dy);
		List<Struct46> list = new List<Struct46>();
		if (arrow.HasBeginningArrowhead)
		{
			list.Add(new Struct46(bounds.StartX, bounds.StartY));
			list.Add(new Struct46(struct2.X + arrow.ArrowHeight * @struct.Dx, struct2.Y + arrow.ArrowHeight * @struct.Dy));
			list.Add(new Struct46(struct2.X + arrow.Thickness * @struct.Dx, struct2.Y + arrow.Thickness * @struct.Dy));
		}
		else
		{
			list.Add(new Struct46(bounds.StartX + arrow.Thickness * @struct.Dx, bounds.StartY + arrow.Thickness * @struct.Dy));
		}
		if (arrow.HasEndingArrowhead)
		{
			Struct46 struct3 = new Struct46(bounds.EndX + arrow.ArrowWidth * norm.Dx, bounds.EndY + arrow.ArrowWidth * norm.Dy);
			list.Add(new Struct46(struct3.X + arrow.Thickness * @struct.Dx, struct3.Y + arrow.Thickness * @struct.Dy));
			list.Add(new Struct46(struct3.X + arrow.ArrowHeight * @struct.Dx, struct3.Y + arrow.ArrowHeight * @struct.Dy));
			list.Add(new Struct46(bounds.EndX, bounds.EndY));
			list.Add(new Struct46(struct3.X - arrow.ArrowHeight * @struct.Dx, struct3.Y - arrow.ArrowHeight * @struct.Dy));
			list.Add(new Struct46(struct3.X - arrow.Thickness * @struct.Dx, struct3.Y - arrow.Thickness * @struct.Dy));
		}
		else
		{
			list.Add(new Struct46(bounds.EndX + arrow.Thickness * @struct.Dx, bounds.EndY + arrow.Thickness * @struct.Dy));
			list.Add(new Struct46(bounds.EndX - arrow.Thickness * @struct.Dx, bounds.EndY - arrow.Thickness * @struct.Dy));
		}
		if (arrow.HasBeginningArrowhead)
		{
			list.Add(new Struct46(struct2.X - arrow.Thickness * @struct.Dx, struct2.Y - arrow.Thickness * @struct.Dy));
			list.Add(new Struct46(struct2.X - arrow.ArrowHeight * @struct.Dx, struct2.Y - arrow.ArrowHeight * @struct.Dy));
		}
		else
		{
			list.Add(new Struct46(bounds.StartX - arrow.Thickness * @struct.Dx, bounds.StartY - arrow.Thickness * @struct.Dy));
		}
		return list.ToArray();
	}

	public static Struct47 smethod_4(Struct46[] points)
	{
		if (points.Length > 1)
		{
			double num = double.MinValue;
			double num2 = double.MinValue;
			double num3 = double.MaxValue;
			double num4 = double.MaxValue;
			for (int i = 0; i < points.Length; i++)
			{
				Struct46 @struct = points[i];
				num3 = Math.Min(num3, @struct.X);
				num4 = Math.Min(num4, @struct.Y);
				num = Math.Max(num, @struct.X);
				num2 = Math.Max(num2, @struct.Y);
			}
			return new Struct47(new Struct46(num3, num4), new Struct46(num, num2));
		}
		return default(Struct47);
	}

	private static void smethod_5(GeometryShape shape, Class1828 geometry)
	{
		Class1921 @class = new Class1921();
		@class.Geometry = new Class2605("custGeom", geometry);
		Class954.smethod_0(shape, @class);
	}

	private static void smethod_6(Class1894 path, Struct46 point)
	{
		Class1897 @class = new Class1897();
		@class.Pt.X = ((long)(point.X * 12700.0)).ToString();
		@class.Pt.Y = ((long)(point.Y * 12700.0)).ToString();
		path.method_4(new Class2605("moveTo", @class));
	}

	private static void smethod_7(Class1894 path, Struct46 point)
	{
		Class1895 @class = new Class1895();
		@class.Pt.X = ((long)(point.X * 12700.0)).ToString();
		@class.Pt.Y = ((long)(point.Y * 12700.0)).ToString();
		path.method_4(new Class2605("lnTo", @class));
	}

	private static void smethod_8(Class1894 path, double radius, double startAngle, double sweepAngle)
	{
		Class1891 @class = new Class1891();
		@class.WR = ((long)(radius * 12700.0)).ToString();
		@class.HR = ((long)(radius * 12700.0)).ToString();
		@class.StAng = ((long)(startAngle * 60000.0)).ToString();
		@class.SwAng = ((long)(sweepAngle * 60000.0)).ToString();
		path.method_4(new Class2605("arcTo", @class));
	}

	private static double smethod_9(double value)
	{
		return value * (Math.PI / 180.0);
	}

	private static double smethod_10(double length, double radius)
	{
		return 180.0 * length / (Math.PI * radius);
	}
}
