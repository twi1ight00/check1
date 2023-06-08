using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns67;

internal struct Struct159
{
	private readonly double double_0;

	private readonly double double_1;

	public double X => double_0;

	public double Y => double_1;

	public Struct159(double x, double y)
	{
		if (double.IsNaN(x))
		{
			throw new ArgumentOutOfRangeException("x");
		}
		if (double.IsNaN(y))
		{
			throw new ArgumentOutOfRangeException("y");
		}
		double_0 = x;
		double_1 = y;
	}

	public bool method_0(Struct159 point)
	{
		if (Math.Abs(X - point.X) < 1E-06)
		{
			return Math.Abs(Y - point.Y) < 1E-06;
		}
		return false;
	}

	[SpecialName]
	public static Struct158 smethod_0(Struct159 left, Struct159 right)
	{
		return new Struct158(left.X - right.X, left.Y - right.Y);
	}

	public override string ToString()
	{
		return $"X = {double_0:0.#} Y = {double_1:0.#}";
	}

	internal PointF method_1()
	{
		return new PointF((float)double_0, (float)double_1);
	}
}
