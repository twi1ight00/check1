using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns8;

internal struct Struct46
{
	private double double_0;

	private double double_1;

	public double X => double_0;

	public double Y => double_1;

	public Struct46(double x, double y)
	{
		double_0 = x;
		double_1 = y;
	}

	public override string ToString()
	{
		return $"X = {double_0:0.#} Y = {double_1:0.#}";
	}

	[SpecialName]
	public static PointF smethod_0(Struct46 point)
	{
		return new PointF((float)point.double_0, (float)point.double_1);
	}

	[SpecialName]
	public static Struct46 smethod_1(PointF point)
	{
		return new Struct46(point.X, point.Y);
	}
}
