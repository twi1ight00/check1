using System;

namespace ns67;

internal sealed class Class3427 : ICloneable
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	public double X => double_0;

	public double Y => double_1;

	public double Z => double_2;

	public Class3427(double x, double y, double z)
	{
		double_0 = x;
		double_1 = y;
		double_2 = z;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3427 method_0()
	{
		return new Class3427(double_0, double_1, double_2);
	}
}
