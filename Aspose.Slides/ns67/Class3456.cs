using System;

namespace ns67;

internal sealed class Class3456 : ICloneable
{
	private readonly double double_0;

	private readonly double double_1;

	public double X => double_0;

	public double Y => double_1;

	public Class3456(double x, double y)
	{
		double_0 = x;
		double_1 = y;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3456 method_0()
	{
		return new Class3456(double_0, double_1);
	}
}
