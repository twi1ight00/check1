using System;

namespace ns67;

internal sealed class Class3367 : Class3364
{
	private double double_0;

	private double double_1;

	private Enum464 enum464_0 = Enum464.const_16;

	public double Direction
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

	public double Distance
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Enum464 PresetShadow
	{
		get
		{
			return enum464_0;
		}
		set
		{
			enum464_0 = value;
		}
	}

	public Class3367()
	{
	}

	public override Class3364 vmethod_0()
	{
		return new Class3367(this);
	}

	private Class3367(Class3367 src)
	{
		double_0 = src.double_0;
		double_1 = src.double_1;
		enum464_0 = src.enum464_0;
	}
}
