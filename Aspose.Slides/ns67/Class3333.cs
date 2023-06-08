using System;

namespace ns67;

internal sealed class Class3333 : Class3332
{
	private double double_0;

	private bool bool_1;

	public double Angle
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

	public bool Scaled
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class3333()
		: base(Enum459.const_0)
	{
		double_0 = 0.0;
		bool_1 = false;
	}

	public Class3333(double angle, bool scaled)
		: base(Enum459.const_0)
	{
		double_0 = angle;
		bool_1 = scaled;
	}

	public override Class3331 vmethod_0()
	{
		Class3333 @class = new Class3333(Angle, Scaled);
		method_0(@class);
		return @class;
	}
}
