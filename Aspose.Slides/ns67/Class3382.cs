using System;

namespace ns67;

internal class Class3382 : ICloneable
{
	private readonly double double_0;

	public double Value => double_0;

	public Class3382(double value)
	{
		if (-51206400.0 > value || 51206400.0 < value)
		{
			throw new ArgumentOutOfRangeException("value", "Value should be between -51206400 and 51206400.");
		}
		double_0 = value;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3382 method_0()
	{
		return new Class3382(double_0);
	}
}
