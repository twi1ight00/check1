using System;

namespace ns67;

internal sealed class Class3420 : Class3418
{
	private double double_0;

	private double double_1;

	public double FontScale
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

	public double LineSpaceReduction
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Class3420(double fontScale, double lineSpaceReduction)
	{
		double_0 = fontScale;
		double_1 = lineSpaceReduction;
	}

	public override Class3418 vmethod_0()
	{
		return new Class3420(double_0, double_1);
	}
}
