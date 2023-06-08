using System;

namespace ns67;

internal sealed class Class3365 : Class3364
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double BlurRadius
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

	public double Direction
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

	public double Distance
	{
		get
		{
			return double_2;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_2 = value;
		}
	}

	public Class3365()
	{
	}

	public override Class3364 vmethod_0()
	{
		return new Class3365(this);
	}

	private Class3365(Class3365 src)
		: base(src)
	{
		double_0 = src.double_0;
		double_1 = src.double_1;
		double_2 = src.double_2;
	}
}
