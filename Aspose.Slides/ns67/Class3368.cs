using System;

namespace ns67;

internal sealed class Class3368 : ICloneable
{
	private double double_0;

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

	public Class3368()
	{
		throw new NotImplementedException();
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3368 method_0()
	{
		Class3368 @class = new Class3368();
		@class.Radius = double_0;
		return @class;
	}
}
