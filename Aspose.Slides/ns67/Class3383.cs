using System;

namespace ns67;

internal class Class3383 : ICloneable
{
	private readonly double double_0;

	public double Value => double_0;

	public Class3383(double value)
	{
		if (0.0 > value || 51206400.0 < value)
		{
			throw new ArgumentOutOfRangeException("value", "Value should be between 0 and 51206400.");
		}
		double_0 = value;
	}

	public object Clone()
	{
		return vmethod_0();
	}

	public virtual Class3383 vmethod_0()
	{
		return new Class3383(double_0);
	}
}
