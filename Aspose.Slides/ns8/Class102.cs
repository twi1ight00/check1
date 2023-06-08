using System;
using System.Drawing;
using ns224;
using ns56;

namespace ns8;

internal static class Class102
{
	[Flags]
	private enum Enum8
	{
		flag_0 = 0,
		flag_1 = 1,
		flag_2 = 0x10,
		flag_3 = 0x100,
		flag_4 = 0x1000
	}

	public const double double_0 = Math.PI / 180.0;

	public const double double_1 = 180.0 / Math.PI;

	public const double double_2 = 100000.0;

	private const double double_3 = 1E-07;

	private const double double_4 = 9.999999747378752E-06;

	public static Struct48 smethod_0(Struct48 area, double angle, out Struct47 bounds)
	{
		bool flag;
		if (flag = area.Width < area.Height)
		{
			area = new Struct48(area.Height, area.Width);
		}
		Struct48 @struct = smethod_14(area, angle);
		Struct48 struct2 = smethod_15(area, angle);
		Struct47 struct3 = smethod_13(@struct, angle);
		smethod_13(struct2, angle);
		Struct48 struct4 = ((struct3.Width > area.Width) ? struct2 : @struct);
		struct4 = (flag ? new Struct48(struct4.Height, struct4.Width) : struct4);
		bounds = smethod_13(struct4, angle);
		return struct4;
	}

	public static double smethod_1(Struct46 p1, Struct46 p2)
	{
		double num = p2.X - p1.X;
		double num2 = p2.Y - p1.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static int smethod_2(Struct46 segmentA, Struct46 segmentB, Struct46 rayA, Struct46 rayB, out Struct46 intrsct)
	{
		double num = (segmentA.X - segmentB.X) * (rayB.Y - rayA.Y) - (segmentA.Y - segmentB.Y) * (rayB.X - rayA.X);
		double num2 = (segmentA.X - rayA.X) * (rayB.Y - rayA.Y) - (segmentA.Y - rayA.Y) * (rayB.X - rayA.X);
		double num3 = (segmentA.X - segmentB.X) * (segmentA.Y - rayA.Y) - (segmentA.Y - segmentB.Y) * (segmentA.X - rayA.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct46);
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (-1E-07 <= num4 && num4 <= 1.0000001 && -1E-07 <= num5)
		{
			intrsct = new Struct46(segmentA.X + num4 * (segmentB.X - segmentA.X), segmentA.Y + num4 * (segmentB.Y - segmentA.Y));
			return 1;
		}
		intrsct = default(Struct46);
		return -1;
	}

	public static int smethod_3(Struct46 ray1A, Struct46 ray1B, Struct46 ray2A, Struct46 ray2B, out Struct46 intrsct)
	{
		double num = (ray1A.X - ray1B.X) * (ray2B.Y - ray2A.Y) - (ray1A.Y - ray1B.Y) * (ray2B.X - ray2A.X);
		double num2 = (ray1A.X - ray2A.X) * (ray2B.Y - ray2A.Y) - (ray1A.Y - ray2A.Y) * (ray2B.X - ray2A.X);
		double num3 = (ray1A.X - ray1B.X) * (ray1A.Y - ray2A.Y) - (ray1A.Y - ray1B.Y) * (ray1A.X - ray2A.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct46);
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (0.0 <= num5)
		{
			intrsct = new Struct46(ray1A.X + num4 * (ray1B.X - ray1A.X), ray1A.Y + num4 * (ray1B.Y - ray1A.Y));
			if (0.0 < num4)
			{
				return 1;
			}
			if (0.0 == num4)
			{
				return 2;
			}
			return 3;
		}
		intrsct = default(Struct46);
		return -1;
	}

	public static bool smethod_4(Struct46 center, double radius, Struct46 p1, Struct46 p2, out Struct46 intersection)
	{
		Struct50 @struct = new Struct50(p2.X - p1.X, p2.Y - p1.Y);
		if (smethod_5(center, new Struct46(center.X + @struct.Norm.Dx, center.Y + @struct.Norm.Dy), p1, p2, out var intersect) > 0)
		{
			double num = smethod_1(intersect, center);
			double num2 = Math.Sqrt(radius * radius - num * num);
			Struct50 struct2 = @struct.method_0();
			intersection = new Struct46(intersect.X - struct2.Dx * num2, intersect.Y - struct2.Dy * num2);
			if (smethod_8(p1, p2, intersection))
			{
				return true;
			}
		}
		intersection = default(Struct46);
		return false;
	}

	public static int smethod_5(Struct46 a1, Struct46 b1, Struct46 a2, Struct46 b2, out Struct46 intersect)
	{
		double num = (a1.X - b1.X) * (b2.Y - a2.Y) - (a1.Y - b1.Y) * (b2.X - a2.X);
		double num2 = (a1.X - a2.X) * (b2.Y - a2.Y) - (a1.Y - a2.Y) * (b2.X - a2.X);
		if (Math.Abs(num) < 1E-07)
		{
			intersect = default(Struct46);
			return 0;
		}
		double num3 = num2 / num;
		intersect = new Struct46(a1.X + num3 * (b1.X - a1.X), a1.Y + num3 * (b1.Y - a1.Y));
		return 1;
	}

	public static bool smethod_6(double x, double epsilon)
	{
		return Math.Abs(x) <= epsilon;
	}

	public static bool smethod_7(Struct46 x, Struct46 y, double epsilon)
	{
		if (Math.Abs(x.X - y.X) <= epsilon)
		{
			return Math.Abs(x.Y - y.Y) <= epsilon;
		}
		return false;
	}

	public static bool smethod_8(Struct46 segmentA, Struct46 segmentB, Struct46 target)
	{
		if (smethod_7(segmentA, target, 9.999999747378752E-06))
		{
			return true;
		}
		if (smethod_7(segmentB, target, 9.999999747378752E-06))
		{
			return true;
		}
		Struct46 @struct = new Struct46(segmentB.X - segmentA.X, segmentB.Y - segmentA.Y);
		Struct46 struct2 = new Struct46(target.X - segmentA.X, target.Y - segmentA.Y);
		Struct46 struct3 = new Struct46(target.X - segmentB.X, target.Y - segmentB.Y);
		double x = @struct.X * struct2.Y - struct2.X * @struct.Y;
		double num = @struct.X * struct2.X + @struct.Y * struct2.Y;
		double num2 = @struct.X * struct3.X + @struct.Y * struct3.Y;
		if (smethod_6(x, 1E-07) && num > -1E-07 && num2 < 1E-07)
		{
			return true;
		}
		return false;
	}

	public static double smethod_9(double value)
	{
		return value * 360.0 / 127.0;
	}

	public static double smethod_10(double value)
	{
		return value / 360.0 * 127.0;
	}

	public static Struct48 smethod_11(double ratio, double availableWidth, double availableHeight)
	{
		if (availableWidth != 0.0 && availableHeight != 0.0)
		{
			double num = availableHeight;
			double num2 = availableWidth;
			if (ratio < 1.0)
			{
				num2 = availableHeight * ratio;
			}
			else if (ratio == 1.0)
			{
				if (availableWidth < availableHeight)
				{
					num = availableWidth;
				}
				else
				{
					num2 = availableHeight;
				}
			}
			else
			{
				num = availableWidth / ratio;
			}
			double val = Math.Min(1.0, availableWidth / num2);
			double val2 = Math.Min(1.0, availableHeight / num);
			num *= Math.Min(val, val2);
			num2 *= Math.Min(val, val2);
			return new Struct48(num2, num);
		}
		return new Struct48(availableWidth, availableHeight);
	}

	public static bool smethod_12(Enum305 type)
	{
		if (type != Enum305.const_62)
		{
			return type == Enum305.const_16;
		}
		return true;
	}

	private static Struct47 smethod_13(Struct48 rect, double angle)
	{
		Class6002 @class = new Class6002();
		@class.method_14((float)angle, new PointF((float)(rect.Width / 2.0), (float)(rect.Height / 2.0)));
		RectangleF rectangleF = @class.method_4(new RectangleF(0f, 0f, (float)rect.Width, (float)rect.Height));
		return new Struct47(rectangleF.X, rectangleF.Y, rectangleF.Right, rectangleF.Bottom);
	}

	private static Struct48 smethod_14(Struct48 rect, double angle)
	{
		double a = Math.PI / 180.0 * smethod_16(angle);
		double num = rect.Height / (2.0 * Math.Sin(a));
		double height = num * Math.Tan(a);
		return new Struct48(num, height);
	}

	private static Struct48 smethod_15(Struct48 rect, double angle)
	{
		angle = smethod_16(angle);
		double dy = Math.Sin(Math.PI / 180.0 * ((angle > 45.0) ? (90.0 - angle) : angle)) * Math.Sqrt(rect.Width * rect.Width + rect.Height * rect.Height);
		Struct50 @struct = new Struct50(rect.Width, dy);
		Struct46 ray2B = new Struct46(0.0, 0.0);
		Struct46 struct2 = new Struct46(0.0, rect.Height - @struct.Dy);
		Struct46 ray1B = new Struct46(struct2.X - @struct.Norm.Dx, struct2.Y - @struct.Norm.Dy);
		new Struct46(rect.Width, rect.Height);
		Struct46 struct3 = new Struct46(rect.Width, @struct.Dy);
		if (smethod_3(struct2, ray1B, struct3, ray2B, out var intrsct) == 1)
		{
			double num = smethod_1(struct2, intrsct);
			double num2 = smethod_1(intrsct, struct3);
			if (!(angle > 45.0))
			{
				return new Struct48(num2, num);
			}
			return new Struct48(num, num2);
		}
		return default(Struct48);
	}

	private static double smethod_16(double angle)
	{
		if (angle < 0.0)
		{
			angle = 360.0 + angle;
		}
		if (angle > 270.0)
		{
			angle = 360.0 - angle;
		}
		else if (angle >= 180.0)
		{
			angle = angle - 180.0 + 0.0001;
		}
		else if (angle > 90.0)
		{
			angle = 180.0 - angle;
		}
		return angle;
	}

	public static Struct46 smethod_17(Struct47 rect, Struct46 target)
	{
		double x = rect.X;
		double right = rect.Right;
		double y = rect.Y;
		double bottom = rect.Bottom;
		double num = x + (right - x) / 2.0;
		double num2 = y + (bottom - y) / 2.0;
		double num3 = target.X;
		double num4 = target.Y;
		Enum8 @enum = smethod_19(rect, num, num2);
		Enum8 enum2 = smethod_19(rect, num3, num4);
		while ((@enum | enum2) != 0 && (@enum & enum2) == 0)
		{
			Enum8 enum3 = ((@enum != 0) ? @enum : enum2);
			double num5;
			double num6;
			if ((enum3 & Enum8.flag_4) == Enum8.flag_4)
			{
				num5 = num + (num3 - num) * (y - num2) / (num4 - num2);
				num6 = y;
			}
			else if ((enum3 & Enum8.flag_3) == Enum8.flag_3)
			{
				num5 = num + (num3 - num) * (bottom - num2) / (num4 - num2);
				num6 = bottom;
			}
			else if ((enum3 & Enum8.flag_2) == Enum8.flag_2)
			{
				num6 = num2 + (num4 - num2) * (right - num) / (num3 - num);
				num5 = right;
			}
			else if ((enum3 & Enum8.flag_1) == Enum8.flag_1)
			{
				num6 = num2 + (num4 - num2) * (x - num) / (num3 - num);
				num5 = x;
			}
			else
			{
				num5 = 0.0;
				num6 = 0.0;
			}
			if (enum3 == @enum)
			{
				num = num5;
				num2 = num6;
				@enum = smethod_19(rect, num, num2);
			}
			else
			{
				num3 = num5;
				num4 = num6;
				enum2 = smethod_19(rect, num3, num4);
			}
		}
		return new Struct46(num3, num4);
	}

	public static Struct46 smethod_18(Struct47 circle, Struct46 target)
	{
		double b = Math.Max(circle.Width, circle.Height) / 2.0;
		Struct46 center = circle.Center;
		Struct50 @struct = Struct50.smethod_0(new Struct50(target.X - center.X, target.Y - center.Y).method_0(), b);
		return new Struct46(center.X + @struct.Dx, center.Y + @struct.Dy);
	}

	private static Enum8 smethod_19(Struct47 bounds, double x, double y)
	{
		Enum8 @enum = Enum8.flag_0;
		if (x < bounds.X)
		{
			@enum |= Enum8.flag_1;
		}
		else if (x > bounds.Right)
		{
			@enum |= Enum8.flag_2;
		}
		if (y < bounds.Y)
		{
			@enum |= Enum8.flag_4;
		}
		else if (y > bounds.Bottom)
		{
			@enum |= Enum8.flag_3;
		}
		return @enum;
	}
}
