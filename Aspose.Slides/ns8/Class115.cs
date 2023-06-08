using System;
using ns56;

namespace ns8;

internal class Class115
{
	private readonly Class837 class837_0;

	private readonly Enum305 enum305_0;

	private double double_0 = double.NaN;

	private double double_1 = double.NaN;

	private double double_2 = double.NaN;

	public Class837 Target => class837_0;

	public Enum305 Type => enum305_0;

	public double Value => double_1;

	private double Max
	{
		get
		{
			if (double.IsNaN(double_2))
			{
				return double.MaxValue;
			}
			return double_2;
		}
	}

	private double Min
	{
		get
		{
			if (double.IsNaN(double_0))
			{
				return double.MinValue;
			}
			return double_0;
		}
	}

	public Class115(Class837 target, Enum305 type, double maxValue, double value)
	{
		class837_0 = target;
		enum305_0 = type;
		double_2 = maxValue;
		double_1 = value;
	}

	public void method_0(double minValue)
	{
		if (Min < minValue && minValue < Max)
		{
			double_0 = minValue;
			if (double.IsNaN(double_1) || double_1 < minValue)
			{
				method_2(minValue);
			}
		}
	}

	public void method_1(double maxValue)
	{
		if (Min < maxValue && maxValue < Max)
		{
			double_2 = maxValue;
			if (double.IsNaN(double_1) || Math.Abs(double_1) > Math.Abs(maxValue))
			{
				method_2(maxValue);
			}
		}
	}

	public void method_2(double value)
	{
		if (Min <= value && value <= Max)
		{
			double_1 = value;
		}
	}
}
