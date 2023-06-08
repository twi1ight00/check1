using System;

namespace ns67;

internal sealed class Class3397 : Class3394
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
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public Class3397(double value)
	{
		Value = value;
	}

	public override Class3394 vmethod_0()
	{
		return new Class3397(double_0);
	}
}
