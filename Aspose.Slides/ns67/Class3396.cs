using System;

namespace ns67;

internal sealed class Class3396 : Class3394
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
			if (value < 25000.0 || value > 400000.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public Class3396(double value)
	{
		Value = value;
	}

	public override Class3394 vmethod_0()
	{
		return new Class3396(double_0);
	}
}
