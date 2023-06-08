using System;

namespace ns67;

internal sealed class Class3354 : Class3344
{
	private double double_0;

	public double Threshold
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

	public Class3354()
		: this(0.0)
	{
	}

	public Class3354(double threshold)
	{
		Threshold = threshold;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3354(double_0);
	}
}
