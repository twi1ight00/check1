using System;
using ns67;

namespace ns69;

internal sealed class Class3037
{
	public const double double_0 = 1E-13;

	public const double double_1 = 1E-07;

	public const float float_0 = 1E-05f;

	public const float float_1 = 0.001f;

	public static bool smethod_0(double x, double epsilon)
	{
		return Math.Abs(x) <= epsilon;
	}

	public static bool smethod_1(float x, float epsilon)
	{
		return Math.Abs(x) <= epsilon;
	}

	public static bool smethod_2(Struct159 p, double epsilon)
	{
		if (Math.Abs(p.X) <= epsilon)
		{
			return Math.Abs(p.Y) <= epsilon;
		}
		return false;
	}

	public static bool smethod_3(double x, double y, double epsilon)
	{
		double num = Math.Max(Math.Abs(x), Math.Abs(y)) * epsilon;
		return Math.Abs(x - y) <= num;
	}

	public static bool smethod_4(float x, float y, float epsilon)
	{
		float num = Math.Max(Math.Abs(x), Math.Abs(y)) * epsilon;
		return Math.Abs(x - y) <= num;
	}

	public static bool smethod_5(Struct159 x, Struct159 y, double epsilon)
	{
		double num = Math.Max(Math.Abs(x.X), Math.Abs(y.X)) * epsilon;
		double num2 = Math.Max(Math.Abs(x.Y), Math.Abs(y.Y)) * epsilon;
		if (Math.Abs(x.X - y.X) <= num)
		{
			return Math.Abs(x.Y - y.Y) <= num2;
		}
		return false;
	}

	public static bool smethod_6(Struct159 x, Struct159 y, double epsilon)
	{
		if (Math.Abs(x.X - y.X) <= epsilon)
		{
			return Math.Abs(x.Y - y.Y) <= epsilon;
		}
		return false;
	}

	public static int smethod_7(Struct159 linePoint1, Struct159 linePoint2, Struct159 refPoint, Struct159 testPoint)
	{
		double num = (linePoint1.X - refPoint.X) * (linePoint2.Y - refPoint.Y) - (linePoint2.X - refPoint.X) * (linePoint1.Y - refPoint.Y);
		double num2 = (linePoint1.X - testPoint.X) * (linePoint2.Y - testPoint.Y) - (linePoint2.X - testPoint.X) * (linePoint1.Y - testPoint.Y);
		if (smethod_0(num2, 1E-07))
		{
			return 0;
		}
		if (num2 * num > 0.0)
		{
			return 1;
		}
		if (num2 * num < 0.0)
		{
			return -1;
		}
		return 0;
	}

	public static bool smethod_8(Struct159 segmentA, Struct159 segmentB, Struct159 testPointC)
	{
		if (smethod_6(segmentA, testPointC, 9.999999747378752E-06))
		{
			return true;
		}
		if (smethod_6(segmentB, testPointC, 9.999999747378752E-06))
		{
			return true;
		}
		Struct159 @struct = new Struct159(segmentB.X - segmentA.X, segmentB.Y - segmentA.Y);
		Struct159 struct2 = new Struct159(testPointC.X - segmentA.X, testPointC.Y - segmentA.Y);
		Struct159 struct3 = new Struct159(testPointC.X - segmentB.X, testPointC.Y - segmentB.Y);
		double x = @struct.X * struct2.Y - struct2.X * @struct.Y;
		double num = @struct.X * struct2.X + @struct.Y * struct2.Y;
		double num2 = @struct.X * struct3.X + @struct.Y * struct3.Y;
		if (smethod_0(x, 1E-07) && num > -1E-07 && num2 < 1E-07)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_9(Struct159 rayA, Struct159 rayB, Struct159 testPointC)
	{
		if (smethod_6(rayA, testPointC, 9.999999747378752E-06))
		{
			return true;
		}
		Struct159 @struct = new Struct159(rayB.X - rayA.X, rayB.Y - rayA.Y);
		Struct159 struct2 = new Struct159(testPointC.X - rayA.X, testPointC.Y - rayA.Y);
		double x = @struct.X * struct2.Y - struct2.X * @struct.Y;
		double num = @struct.X * struct2.X + @struct.Y * struct2.Y;
		if (smethod_0(x, 1E-07) && num > -1E-07)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_10(Struct159 point1, Struct159 point, Struct159 point2)
	{
		double x = (point1.X - point.X) * (point2.Y - point.Y) - (point2.X - point.X) * (point1.Y - point.Y);
		return smethod_0(x, 1E-07);
	}

	public static bool smethod_11(Class3059 point, Class3040 triangle, out int insideStatus)
	{
		insideStatus = -1;
		int num = smethod_7(triangle.Edges[0].Vertices[0].AsPlanePoint, triangle.Edges[0].Vertices[1].AsPlanePoint, triangle.method_3(0).AsPlanePoint, point.AsPlanePoint);
		int num2 = smethod_7(triangle.Edges[1].Vertices[0].AsPlanePoint, triangle.Edges[1].Vertices[1].AsPlanePoint, triangle.method_3(1).AsPlanePoint, point.AsPlanePoint);
		int num3 = smethod_7(triangle.Edges[2].Vertices[0].AsPlanePoint, triangle.Edges[2].Vertices[1].AsPlanePoint, triangle.method_3(2).AsPlanePoint, point.AsPlanePoint);
		if ((num != 0 && num != 1) || (num2 != 0 && num2 != 1) || (num3 != 0 && num3 != 1))
		{
			return false;
		}
		insideStatus = 3 - (num + num2 + num3);
		return true;
	}

	public static int smethod_12(Class3059 a1, Class3059 b1, Class3059 a2, Class3059 b2, out Class3059 intersect)
	{
		double num = (a1.X - b1.X) * (b2.Y - a2.Y) - (a1.Y - b1.Y) * (b2.X - a2.X);
		double num2 = (a1.X - a2.X) * (b2.Y - a2.Y) - (a1.Y - a2.Y) * (b2.X - a2.X);
		double num3 = (a1.X - b1.X) * (a1.Y - a2.Y) - (a1.Y - b1.Y) * (a1.X - a2.X);
		intersect = null;
		if (Math.Abs(num) < 1E-07)
		{
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (-1E-07 <= num4 && num4 <= 1.0000001 && -1E-07 <= num5 && num5 <= 1.0000001)
		{
			intersect = new Class3059(a1.X + num4 * (b1.X - a1.X), a1.Y + num4 * (b1.Y - a1.Y));
			return 1;
		}
		return -1;
	}

	public static int smethod_13(Struct159 a1, Struct159 b1, Struct159 a2, Struct159 b2, out Struct159 intersect)
	{
		double num = (a1.X - b1.X) * (b2.Y - a2.Y) - (a1.Y - b1.Y) * (b2.X - a2.X);
		double num2 = (a1.X - a2.X) * (b2.Y - a2.Y) - (a1.Y - a2.Y) * (b2.X - a2.X);
		double num3 = (a1.X - b1.X) * (a1.Y - a2.Y) - (a1.Y - b1.Y) * (a1.X - a2.X);
		intersect = default(Struct159);
		if (Math.Abs(num) < 1E-07)
		{
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (-1E-07 <= num4 && num4 <= 1.0000001 && -1E-07 <= num5 && num5 <= 1.0000001)
		{
			intersect = new Struct159(a1.X + num4 * (b1.X - a1.X), a1.Y + num4 * (b1.Y - a1.Y));
			return 1;
		}
		return -1;
	}

	public static int smethod_14(Struct159 a1, Struct159 b1, Struct159 a2, Struct159 b2, out Struct159 intersect)
	{
		double num = (a1.X - b1.X) * (b2.Y - a2.Y) - (a1.Y - b1.Y) * (b2.X - a2.X);
		double num2 = (a1.X - a2.X) * (b2.Y - a2.Y) - (a1.Y - a2.Y) * (b2.X - a2.X);
		if (Math.Abs(num) < 1E-07)
		{
			intersect = default(Struct159);
			return 0;
		}
		double num3 = num2 / num;
		intersect = new Struct159(a1.X + num3 * (b1.X - a1.X), a1.Y + num3 * (b1.Y - a1.Y));
		return 1;
	}

	public static int smethod_15(Struct159 segmentA, Struct159 segmentB, Struct159 lineA, Struct159 lineB, out Struct159 intrsct)
	{
		double num = (segmentA.X - segmentB.X) * (lineB.Y - lineA.Y) - (segmentA.Y - segmentB.Y) * (lineB.X - lineA.X);
		double num2 = (segmentA.X - lineA.X) * (lineB.Y - lineA.Y) - (segmentA.Y - lineA.Y) * (lineB.X - lineA.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct159);
			return 0;
		}
		double num3 = num2 / num;
		if (-1E-07 <= num3 && num3 <= 1.0000001)
		{
			intrsct = new Struct159(segmentA.X + num3 * (segmentB.X - segmentA.X), segmentA.Y + num3 * (segmentB.Y - segmentA.Y));
			return 1;
		}
		intrsct = default(Struct159);
		return -1;
	}

	public static int smethod_16(Struct159 segmentA, Struct159 segmentB, Struct159 rayA, Struct159 rayB, out Struct159 intrsct)
	{
		double num = (segmentA.X - segmentB.X) * (rayB.Y - rayA.Y) - (segmentA.Y - segmentB.Y) * (rayB.X - rayA.X);
		double num2 = (segmentA.X - rayA.X) * (rayB.Y - rayA.Y) - (segmentA.Y - rayA.Y) * (rayB.X - rayA.X);
		double num3 = (segmentA.X - segmentB.X) * (segmentA.Y - rayA.Y) - (segmentA.Y - segmentB.Y) * (segmentA.X - rayA.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct159);
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (-1E-07 <= num4 && num4 <= 1.0000001 && -1E-07 <= num5)
		{
			intrsct = new Struct159(segmentA.X + num4 * (segmentB.X - segmentA.X), segmentA.Y + num4 * (segmentB.Y - segmentA.Y));
			return 1;
		}
		intrsct = default(Struct159);
		return -1;
	}

	public static int smethod_17(Struct159 lineA, Struct159 lineB, Struct159 rayA, Struct159 rayB, out Struct159 intrsct)
	{
		double num = (lineA.X - lineB.X) * (rayB.Y - rayA.Y) - (lineA.Y - lineB.Y) * (rayB.X - rayA.X);
		double num2 = (lineA.X - rayA.X) * (rayB.Y - rayA.Y) - (lineA.Y - rayA.Y) * (rayB.X - rayA.X);
		double num3 = (lineA.X - lineB.X) * (lineA.Y - rayA.Y) - (lineA.Y - lineB.Y) * (lineA.X - rayA.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct159);
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (0.0 <= num5)
		{
			intrsct = new Struct159(lineA.X + num4 * (lineB.X - lineA.X), lineA.Y + num4 * (lineB.Y - lineA.Y));
			return 1;
		}
		intrsct = default(Struct159);
		return -1;
	}

	public static int smethod_18(Struct159 ray1A, Struct159 ray1B, Struct159 ray2A, Struct159 ray2B, out Struct159 intrsct)
	{
		double num = (ray1A.X - ray1B.X) * (ray2B.Y - ray2A.Y) - (ray1A.Y - ray1B.Y) * (ray2B.X - ray2A.X);
		double num2 = (ray1A.X - ray2A.X) * (ray2B.Y - ray2A.Y) - (ray1A.Y - ray2A.Y) * (ray2B.X - ray2A.X);
		double num3 = (ray1A.X - ray1B.X) * (ray1A.Y - ray2A.Y) - (ray1A.Y - ray1B.Y) * (ray1A.X - ray2A.X);
		if (Math.Abs(num) < 1E-07)
		{
			intrsct = default(Struct159);
			return 0;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (0.0 <= num5)
		{
			intrsct = new Struct159(ray1A.X + num4 * (ray1B.X - ray1A.X), ray1A.Y + num4 * (ray1B.Y - ray1A.Y));
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
		intrsct = default(Struct159);
		return -1;
	}

	public static Struct159 smethod_19(Struct159 lineA, Struct159 lineB, Struct159 c)
	{
		Struct159 @struct = new Struct159(lineB.X - lineA.X, lineB.Y - lineA.Y);
		Struct159 struct2 = new Struct159(c.X - lineA.X, c.Y - lineA.Y);
		double num = @struct.X * @struct.X + @struct.Y * @struct.Y;
		double num2 = @struct.X * struct2.X + @struct.Y * struct2.Y;
		return new Struct159(lineA.X + num2 * @struct.X / num, lineA.Y + num2 * @struct.Y / num);
	}

	public static double smethod_20(Struct159 p1, Struct159 p2)
	{
		return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
	}

	public static double smethod_21(Struct159 p1, Struct159 p2)
	{
		return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
	}

	public static bool smethod_22(Class3059 p0, Class3059 p1, Class3059 p2, Class3059 p3)
	{
		double num = Math.Abs((p0.X - p1.X) * (p0.Y - p3.Y) - (p0.X - p3.X) * (p0.Y - p1.Y)) * ((p2.X - p1.X) * (p2.X - p3.X) + (p2.Y - p1.Y) * (p2.Y - p3.Y));
		double num2 = ((p0.X - p1.X) * (p0.X - p3.X) + (p0.Y - p1.Y) * (p0.Y - p3.Y)) * Math.Abs((p2.X - p1.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p2.Y - p1.Y));
		double num3 = Math.Max(Math.Abs(num), Math.Abs(num2)) * 1E-13;
		return num + num2 >= 0.0 - num3;
	}

	public static bool smethod_23(Class3059 p0, Class3040 T, out double diff)
	{
		return !T.method_0(p0, out diff);
	}
}
