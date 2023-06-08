using System;

namespace ns67;

internal struct Struct160
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public double Left => double_0;

	public double Top => double_2;

	public double Right => double_1;

	public double Bottom => double_3;

	public Struct159 TopLeft => new Struct159(double_0, double_2);

	public Struct159 BottomRight => new Struct159(double_1, double_3);

	public double Width => Math.Abs(double_1 - double_0);

	public double Height => Math.Abs(double_3 - double_2);

	public Struct159 Center => new Struct159(double_0 + Math.Abs(double_1 - double_0) / 2.0, double_2 + Math.Abs(double_3 - double_2) / 2.0);

	public Struct160(double left, double top, double right, double bottom)
	{
		double_0 = left;
		double_1 = right;
		double_2 = top;
		double_3 = bottom;
	}

	public Struct160(Struct159 topLeft, Struct159 bottomRight)
		: this(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y)
	{
	}

	public Struct160 method_0(Struct159 origin, double ratio)
	{
		Struct158 a = Struct159.smethod_0(TopLeft, origin);
		Struct158 a2 = Struct159.smethod_0(BottomRight, origin);
		return new Struct160(Struct158.smethod_3(origin, Struct158.smethod_5(a, ratio)), Struct158.smethod_3(origin, Struct158.smethod_5(a2, ratio)));
	}
}
