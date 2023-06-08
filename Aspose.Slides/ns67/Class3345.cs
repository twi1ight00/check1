using System;

namespace ns67;

internal sealed class Class3345 : Class3344
{
	private bool bool_0 = true;

	private double double_0;

	public bool GrowBounds
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	public override Class3344 vmethod_0()
	{
		Class3345 @class = new Class3345();
		@class.bool_0 = bool_0;
		@class.double_0 = double_0;
		return @class;
	}
}
