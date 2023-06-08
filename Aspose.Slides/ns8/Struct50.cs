using System;
using System.Runtime.CompilerServices;

namespace ns8;

internal struct Struct50
{
	private double double_0;

	private double double_1;

	public double Dx => double_0;

	public double Dy => double_1;

	public double Length => Math.Sqrt(double_1 * double_1 + double_0 * double_0);

	public Struct50 Norm => new Struct50(0.0 - double_1, double_0);

	public Struct50(double dx, double dy)
	{
		double_0 = dx;
		double_1 = dy;
	}

	public Struct50 method_0()
	{
		if (Length < 1E-06)
		{
			throw new DivideByZeroException();
		}
		return smethod_1(this, Length);
	}

	[SpecialName]
	public static Struct50 smethod_0(Struct50 a, double b)
	{
		return new Struct50(a.double_0 * b, a.double_1 * b);
	}

	[SpecialName]
	public static Struct50 smethod_1(Struct50 a, double b)
	{
		return new Struct50(a.double_0 / b, a.double_1 / b);
	}

	[SpecialName]
	public static Struct50 smethod_2(Struct50 a)
	{
		return new Struct50(0.0 - a.double_0, 0.0 - a.double_1);
	}

	[SpecialName]
	public static Struct50 smethod_3(Struct50 a, Struct50 b)
	{
		return new Struct50(a.double_0 - b.double_0, a.double_1 - b.double_1);
	}

	[SpecialName]
	public static Struct50 smethod_4(Struct50 a, Struct50 b)
	{
		return new Struct50(a.double_0 + b.double_0, a.double_1 + b.double_1);
	}
}
