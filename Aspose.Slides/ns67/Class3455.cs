using System;

namespace ns67;

internal sealed class Class3455 : ICloneable
{
	private double double_0;

	private double double_1;

	public double Cx => double_0;

	public double Cy => double_1;

	public Class3455(double cx, double cy)
	{
		double_0 = cx;
		double_1 = cy;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3455 method_0()
	{
		return new Class3455(double_0, double_1);
	}
}
