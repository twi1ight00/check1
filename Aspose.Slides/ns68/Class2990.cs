using System;
using ns67;
using ns69;

namespace ns68;

internal class Class2990
{
	internal static Class2992 smethod_0(Class2994 current, Class2994 paired)
	{
		Struct159 a = current.A;
		Struct159 b = current.B;
		Struct159 a2 = paired.A;
		Struct159 b2 = paired.B;
		if (Class3037.smethod_6(a, a2, 1E-13))
		{
			return smethod_1(b, a, b2, checkConcavity: true);
		}
		if (Class3037.smethod_6(a, b2, 1E-13))
		{
			return smethod_1(b, a, a2, checkConcavity: true);
		}
		if (Class3037.smethod_6(b, a2, 1E-13))
		{
			return smethod_1(a, b, b2, checkConcavity: true);
		}
		if (Class3037.smethod_6(b, b2, 1E-13))
		{
			return smethod_1(a, b, a2, checkConcavity: true);
		}
		if (Class3037.smethod_14(a, b, a2, b2, out var intersect) != 0)
		{
			return smethod_1(new Struct159(intersect.X - (b.X - a.X), intersect.Y - (b.Y - a.Y)), c: new Struct159(intersect.X + (b2.X - a2.X), intersect.Y + (b2.Y - a2.Y)), b: intersect, checkConcavity: false);
		}
		if ((b.X - a.X) * (b2.X - a2.X) >= 0.0 && (b.Y - a.Y) * (b2.Y - a2.Y) >= 0.0)
		{
			return null;
		}
		return new Class2992(new Struct159((b.X + a2.X) / 2.0, (b.Y + a2.Y) / 2.0), new Struct159((a.X + b2.X) / 2.0, (a.Y + b2.Y) / 2.0));
	}

	public static Class2992 smethod_1(Struct159 a, Struct159 b, Struct159 c, bool checkConcavity)
	{
		double num = Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
		double num2 = Math.Sqrt((b.X - c.X) * (b.X - c.X) + (b.Y - c.Y) * (b.Y - c.Y));
		Struct159 @struct = ((num > num2) ? a : c);
		Struct159 struct2 = new Struct159((num > num2) ? (b.X + (c.X - b.X) * num / num2) : (b.X + (a.X - b.X) * num2 / num), (num > num2) ? (b.Y + (c.Y - b.Y) * num / num2) : (b.Y + (a.Y - b.Y) * num2 / num));
		Struct159 b2 = new Struct159(@struct.X + struct2.X - b.X, @struct.Y + struct2.Y - b.Y);
		if (checkConcavity && (b.X - a.X) * (c.Y - b.Y) - (b.Y - a.Y) * (c.X - b.X) > 0.0)
		{
			b2 = new Struct159(b.X - (b2.X - b.X), b.Y - (b2.Y - b.Y));
		}
		return new Class2992(b, b2);
	}

	public static double smethod_2(Class2994 currentEd, Struct159 c)
	{
		Struct159 @struct = new Struct159(currentEd.B.X - currentEd.A.X, currentEd.B.Y - currentEd.A.Y);
		Struct159 struct2 = new Struct159(c.X - currentEd.A.X, c.Y - currentEd.A.Y);
		double num = Math.Sqrt(@struct.X * @struct.X + @struct.Y * @struct.Y);
		double num2 = @struct.X * struct2.X + @struct.Y * struct2.Y;
		return num2 / num;
	}

	public static double smethod_3(double pX, double pY, double aX, double aY, double bX, double bY)
	{
		double num = bX - aX;
		double num2 = bY - aY;
		double num3 = pX - aX;
		double num4 = pY - aY;
		double num5 = num3 * num + num4 * num2;
		if (num5 <= 0.0)
		{
			return Math.Sqrt((pX - aX) * (pX - aX) + (pY - aY) * (pY - aY));
		}
		double num6 = num * num + num2 * num2;
		if (num6 <= num5)
		{
			return Math.Sqrt((pX - bX) * (pX - bX) + (pY - bY) * (pY - bY));
		}
		double num7 = num5 / num6;
		double num8 = aX + num7 * num;
		double num9 = aY + num7 * num2;
		return Math.Sqrt((pX - num8) * (pX - num8) + (pY - num9) * (pY - num9));
	}

	public static double smethod_4(Struct159 p, Struct159 a, Struct159 b)
	{
		double num = p.X - a.X;
		double num2 = p.Y - a.Y;
		double num3 = b.X - a.X;
		double num4 = b.Y - a.Y;
		double num5 = num * num4 - num2 * num3;
		return Math.Abs(num5 / Math.Sqrt(num3 * num3 + num4 * num4));
	}

	public static double smethod_5(double pX, double pY, double aX, double aY, double bX, double bY)
	{
		double num = pX - aX;
		double num2 = pY - aY;
		double num3 = bX - aX;
		double num4 = bY - aY;
		double num5 = num * num4 - num2 * num3;
		return Math.Abs(num5 / Math.Sqrt(num3 * num3 + num4 * num4));
	}

	public static double smethod_6(double pX, double pY, double aX, double aY, double bX, double bY)
	{
		double num = pX - aX;
		double num2 = pY - aY;
		double num3 = bX - aX;
		double num4 = bY - aY;
		double num5 = num * num4 - num2 * num3;
		return (0.0 - num5) / Math.Sqrt(num3 * num3 + num4 * num4);
	}
}
