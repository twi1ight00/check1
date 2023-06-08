using System;

namespace ns67;

internal sealed class Class3363 : ICloneable
{
	private Enum463 enum463_0 = Enum463.const_4;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private bool bool_0;

	private double double_8;

	private double double_9;

	private double double_10;

	private double double_11;

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

	public double Direction
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

	public double Distance
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

	public double EndAlpha
	{
		get
		{
			return double_3;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_3 = value;
		}
	}

	public double EndPosition
	{
		get
		{
			return double_4;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_4 = value;
		}
	}

	public double FadeDirection
	{
		get
		{
			return double_5;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_5 = value;
		}
	}

	public double HorizontalSkew
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

	public double VerticalSkew
	{
		get
		{
			return double_7;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_7 = value;
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

	public double StartOpacity
	{
		get
		{
			return double_8;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_8 = value;
		}
	}

	public double StartPosition
	{
		get
		{
			return double_9;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_9 = value;
		}
	}

	public double HorizontalRatio
	{
		get
		{
			return double_10;
		}
		set
		{
			double_10 = value;
		}
	}

	public double VerticalRatio
	{
		get
		{
			return double_11;
		}
		set
		{
			double_11 = value;
		}
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3363 method_0()
	{
		Class3363 @class = new Class3363();
		@class.enum463_0 = enum463_0;
		@class.double_0 = double_0;
		@class.double_1 = double_1;
		@class.double_2 = double_2;
		@class.double_3 = double_3;
		@class.double_4 = double_4;
		@class.double_5 = double_5;
		@class.double_6 = double_6;
		@class.double_7 = double_7;
		@class.bool_0 = bool_0;
		@class.double_8 = double_8;
		@class.double_9 = double_9;
		@class.double_10 = double_10;
		@class.double_11 = double_11;
		return @class;
	}
}
