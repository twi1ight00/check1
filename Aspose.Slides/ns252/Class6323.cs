using System;
using ns218;

namespace ns252;

internal class Class6323
{
	private double double_0;

	public double Value => double_0;

	public double ValueInRadians => Class5955.smethod_68(Value);

	public double ValueInDegrees => Class5955.smethod_71(Value);

	public Class6323()
	{
		double_0 = 0.0;
	}

	public Class6323(double value)
	{
		double_0 = value;
	}

	public static Class6323 smethod_0(double value)
	{
		Class6323 @class = new Class6323(value);
		@class.method_0();
		return @class;
	}

	public static Class6323 smethod_1(double degrees)
	{
		return new Class6323(Class5955.smethod_70(degrees));
	}

	public bool Equals(Class6323 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.double_0.Equals(double_0);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Class6323))
		{
			return false;
		}
		return Equals((Class6323)obj);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode();
	}

	private void method_0()
	{
		double num = Class5955.smethod_70(360.0);
		if (Math.Abs(double_0) > num)
		{
			double_0 %= num;
		}
		while (double_0 < 0.0)
		{
			double_0 += num;
		}
	}
}
