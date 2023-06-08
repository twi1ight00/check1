using System;

namespace ns67;

internal sealed class Class3350 : Class3344
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double Hue
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

	public double Luminance
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Saturation
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public Class3350(double hue, double luminance, double saturation)
	{
		double_0 = hue;
		double_1 = luminance;
		double_2 = saturation;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3350(double_0, double_1, double_2);
	}
}
