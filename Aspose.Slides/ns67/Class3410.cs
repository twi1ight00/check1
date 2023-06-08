using System;

namespace ns67;

internal sealed class Class3410 : ICloneable
{
	private Enum473 enum473_0;

	private double double_0;

	public Enum473 TabAlignment
	{
		get
		{
			return enum473_0;
		}
		set
		{
			enum473_0 = value;
		}
	}

	public double TabPosition
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class3410(Enum473 tabAlignment, double tabPosition)
	{
		TabAlignment = tabAlignment;
		TabPosition = tabPosition;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3410 method_0()
	{
		return new Class3410(enum473_0, double_0);
	}
}
