using System;

namespace ns67;

internal sealed class Class3409 : Class3407
{
	private double double_0;

	public double Value
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public Class3409(double value)
	{
		Value = value;
	}

	public override Class3407 vmethod_0()
	{
		return new Class3409(double_0);
	}
}
