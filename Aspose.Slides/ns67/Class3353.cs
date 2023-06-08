using System;

namespace ns67;

internal sealed class Class3353 : Class3344
{
	private double double_0;

	private double double_1;

	public double Amount
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Hue
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Class3353(double amount, double hue)
	{
		double_0 = amount;
		double_1 = hue;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3353(double_0, double_1);
	}
}
