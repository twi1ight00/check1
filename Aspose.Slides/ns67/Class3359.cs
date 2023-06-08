using System;

namespace ns67;

internal sealed class Class3359 : Class3344
{
	private double double_0;

	public double Amount
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

	public Class3359()
		: this(0.0)
	{
	}

	public Class3359(double amount)
	{
		double_0 = amount;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3359(double_0);
	}
}
