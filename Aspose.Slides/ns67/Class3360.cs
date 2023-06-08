using System;

namespace ns67;

internal sealed class Class3360 : Class3344
{
	private double double_0;

	public double Alpha
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

	public Class3360()
		: this(0.0)
	{
	}

	public Class3360(double alpha)
	{
		Alpha = alpha;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3360(double_0);
	}
}
