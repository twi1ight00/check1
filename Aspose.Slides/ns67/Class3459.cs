using System;

namespace ns67;

internal sealed class Class3459 : ICloneable
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	public double Bottom => double_0;

	public double Left => double_1;

	public double Right => double_2;

	public double Top => double_3;

	public Class3459()
	{
		double_0 = 0.0;
		double_1 = 0.0;
		double_2 = 0.0;
		double_3 = 0.0;
	}

	public Class3459(double left, double top, double right, double bottom)
	{
		double_1 = left;
		double_3 = top;
		double_2 = right;
		double_0 = bottom;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3459 method_0()
	{
		return new Class3459(Left, Top, Right, Bottom);
	}
}
