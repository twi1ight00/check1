using System;

namespace ns67;

internal sealed class Class3362 : ICloneable
{
	private Class3453 class3453_0 = new Class3453(0f, 0f, 0f, 0f);

	private double double_0;

	public Class3453 Color
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (class3453_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3453_0 = value.method_1();
			}
		}
	}

	public double Radius
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

	public object Clone()
	{
		return method_0();
	}

	public Class3362 method_0()
	{
		Class3362 @class = new Class3362();
		@class.Color = class3453_0;
		@class.Radius = double_0;
		return @class;
	}
}
