using System;

namespace ns67;

internal sealed class Class3366 : Class3364
{
	private Enum463 enum463_0 = Enum463.const_4;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private bool bool_0;

	private double double_5;

	private double double_6;

	public Enum463 ShadowAlignment
	{
		get
		{
			return enum463_0;
		}
		set
		{
			enum463_0 = value;
		}
	}

	public double BlurRadius
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

	public double ShadowDirection
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

	public double ShadowOffsetDistance
	{
		get
		{
			return double_2;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_2 = value;
		}
	}

	public double HorizontalSkew
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public double VerticalSkew
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public bool RotateWithShape
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

	public double HorizontalScalingFactor
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double VerticalScalingFactor
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public Class3366()
	{
	}

	public override Class3364 vmethod_0()
	{
		return new Class3366(this);
	}

	private Class3366(Class3366 src)
		: base(src)
	{
		enum463_0 = src.enum463_0;
		double_0 = src.double_0;
		double_1 = src.double_1;
		double_2 = src.double_2;
		double_3 = src.double_3;
		double_4 = src.double_4;
		bool_0 = src.bool_0;
		double_5 = src.double_5;
		double_6 = src.double_6;
	}
}
