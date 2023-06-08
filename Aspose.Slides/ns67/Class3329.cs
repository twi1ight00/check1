using System;

namespace ns67;

internal sealed class Class3329 : ICloneable
{
	private Class3453 class3453_0;

	private double double_0;

	public Class3453 Color
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3453_0 = value;
		}
	}

	public double Position
	{
		get
		{
			return double_0;
		}
		set
		{
			if (!Class3430.smethod_1(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public Class3329(Class3453 color, double position)
	{
		Color = color;
		Position = position;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3329 method_0()
	{
		return new Class3329(Color.method_1(), Position);
	}
}
