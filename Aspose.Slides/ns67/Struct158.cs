using System;
using System.Runtime.CompilerServices;

namespace ns67;

internal struct Struct158
{
	private readonly double double_0;

	private readonly double double_1;

	public double Dx => double_0;

	public double Dy => double_1;

	public double Norm => Math.Sqrt(double_0 * double_0 + double_1 * double_1);

	public static Struct158 Zero => new Struct158(0.0, 0.0);

	public Struct158(double dx, double dy)
	{
		if (double.IsNaN(dx))
		{
			throw new ArgumentOutOfRangeException("dx");
		}
		if (double.IsNaN(dy))
		{
			throw new ArgumentOutOfRangeException("dy");
		}
		double_0 = dx;
		double_1 = dy;
	}

	public static Struct158 smethod_0(Struct159 begin, Struct159 end)
	{
		return new Struct158(end.X - begin.X, end.Y - begin.Y);
	}

	public double method_0(Struct158 vector)
	{
		if (Norm < 1E-06 || vector.Norm < 1E-06)
		{
			throw new DivideByZeroException();
		}
		return Math.Acos(Math.Round((Dx * vector.Dx + Dy * vector.Dy) / (Norm * vector.Norm), 3));
	}

	public Struct158 method_1()
	{
		if (Norm < 1E-06)
		{
			throw new DivideByZeroException();
		}
		return smethod_6(this, Norm);
	}

	public Struct158 method_2()
	{
		Struct158 @struct = method_1();
		return new Struct158(0.0 - @struct.Dy, @struct.Dx);
	}

	[SpecialName]
	public static Struct158 smethod_1(Struct158 left, Struct158 right)
	{
		return new Struct158(left.double_0 + right.double_0, left.double_1 + right.double_1);
	}

	[SpecialName]
	public static Struct158 smethod_2(Struct158 left, Struct158 right)
	{
		return new Struct158(left.double_0 - right.double_0, left.double_1 - right.double_1);
	}

	[SpecialName]
	public static Struct159 smethod_3(Struct159 left, Struct158 right)
	{
		return new Struct159(left.X + right.double_0, left.Y + right.double_1);
	}

	[SpecialName]
	public static Struct159 smethod_4(Struct159 left, Struct158 right)
	{
		return new Struct159(left.X - right.double_0, left.Y - right.double_1);
	}

	[SpecialName]
	public static Struct158 smethod_5(Struct158 a, double b)
	{
		return new Struct158(a.double_0 * b, a.double_1 * b);
	}

	[SpecialName]
	public static Struct158 smethod_6(Struct158 a, double b)
	{
		return new Struct158(a.double_0 / b, a.double_1 / b);
	}

	[SpecialName]
	public static Struct158 smethod_7(Struct158 v)
	{
		return new Struct158(0.0 - v.double_0, 0.0 - v.double_1);
	}

	[SpecialName]
	public static double smethod_8(Struct158 a, Struct158 b)
	{
		return a.double_0 * b.double_0 + a.double_1 * b.double_1;
	}
}
