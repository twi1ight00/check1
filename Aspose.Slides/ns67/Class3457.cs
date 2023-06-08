using System;

namespace ns67;

internal sealed class Class3457 : ICloneable
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	private readonly Class3456 class3456_0;

	private readonly Class3455 class3455_0;

	public double Right => double_2;

	public double Top => double_1;

	public double Left => double_0;

	public double Bottom => double_3;

	public Class3456 Offset => class3456_0;

	public Class3455 Extents => class3455_0;

	public Class3457(double left, double top, double right, double bottom)
	{
		double_1 = top;
		double_0 = left;
		double_3 = bottom;
		double_2 = right;
		class3456_0 = new Class3456(left, top);
		class3455_0 = new Class3455(right - left, bottom - top);
	}

	public Class3457(Class3456 offset, Class3455 extents)
	{
		double_1 = offset.Y;
		double_0 = offset.X;
		double_3 = double_1 + extents.Cy;
		double_2 = double_0 + extents.Cx;
		class3456_0 = offset.method_0();
		class3455_0 = extents.method_0();
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3457 method_0()
	{
		return new Class3457(double_0, double_1, double_2, double_3);
	}
}
