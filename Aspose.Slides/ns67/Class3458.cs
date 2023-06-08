using System;

namespace ns67;

internal sealed class Class3458 : ICloneable
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double Latitude
	{
		get
		{
			return double_0;
		}
		set
		{
			if (!Class3430.smethod_0(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public double Longitude
	{
		get
		{
			return double_1;
		}
		set
		{
			if (!Class3430.smethod_0(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public double Revolution
	{
		get
		{
			return double_2;
		}
		set
		{
			if (!Class3430.smethod_0(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_2 = value;
		}
	}

	public static Class3458 Default => new Class3458(0.0, 0.0, 0.0);

	public Class3458(double theLongitude, double theLatitude, double theRevolution)
	{
		double_1 = theLongitude;
		double_0 = theLatitude;
		double_2 = theRevolution;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3458 method_0()
	{
		return new Class3458(double_0, double_1, double_2);
	}

	internal void method_1(Interface53 device)
	{
		device.imethod_12(double_1 / 60000.0, double_0 / 60000.0, double_2 / 60000.0);
	}
}
