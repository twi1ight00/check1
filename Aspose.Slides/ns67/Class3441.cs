using System;

namespace ns67;

internal sealed class Class3441 : ICloneable
{
	private Enum491 enum491_0 = Enum491.const_0;

	private Enum486 enum486_0 = Enum486.const_2;

	private Enum490 enum490_0 = Enum490.const_0;

	private double double_0 = DefaultMeterJoinLimit;

	private double double_1 = DefaultLineWidth;

	private Enum485 enum485_0;

	private Class3437 class3437_0 = new Class3439(Enum484.const_0);

	private Class3440 class3440_0 = new Class3440();

	private Class3440 class3440_1 = new Class3440();

	public static double DefaultMeterJoinLimit => 800000.0;

	public static int DefaultLineWidth => 25400;

	public Enum491 StrokeAlignment
	{
		get
		{
			return enum491_0;
		}
		set
		{
			enum491_0 = value;
		}
	}

	public Enum486 LineEndingCapType
	{
		get
		{
			return enum486_0;
		}
		set
		{
			enum486_0 = value;
		}
	}

	public Enum490 LineJoinType
	{
		get
		{
			return enum490_0;
		}
		set
		{
			enum490_0 = value;
		}
	}

	public double MeterJoinLimit
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

	public double LineWidth
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
			double num = 9525.0;
			if (double_1 < num)
			{
				double_1 = num;
			}
		}
	}

	public Enum485 CompoundLineType
	{
		get
		{
			return enum485_0;
		}
		set
		{
			enum485_0 = value;
		}
	}

	public Class3437 LineDash
	{
		get
		{
			return class3437_0;
		}
		set
		{
			if (class3437_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3437_0 = value.vmethod_0();
			}
		}
	}

	public Class3440 HeadEnd
	{
		get
		{
			return class3440_0;
		}
		set
		{
			if (value != class3440_0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3440_0 = value.method_0();
			}
		}
	}

	public Class3440 TailEnd
	{
		get
		{
			return class3440_1;
		}
		set
		{
			if (value != class3440_1)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3440_1 = value.method_0();
			}
		}
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3441 method_0()
	{
		Class3441 @class = new Class3441();
		@class.enum491_0 = enum491_0;
		@class.enum486_0 = enum486_0;
		@class.enum490_0 = enum490_0;
		@class.double_0 = double_0;
		@class.double_1 = double_1;
		@class.enum485_0 = enum485_0;
		@class.class3437_0 = class3437_0.vmethod_0();
		@class.class3440_0 = class3440_0.method_0();
		@class.class3440_1 = class3440_1.method_0();
		return @class;
	}

	public static Enum491 smethod_0(string param)
	{
		return param switch
		{
			"in" => Enum491.const_2, 
			"ctr" => Enum491.const_1, 
			_ => throw new ArgumentOutOfRangeException(param), 
		};
	}

	public static Enum486 smethod_1(string param)
	{
		return param switch
		{
			"sq" => Enum486.const_2, 
			"rnd" => Enum486.const_1, 
			"flat" => Enum486.const_3, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}

	public static Enum485 smethod_2(string param)
	{
		return param switch
		{
			"tri" => Enum485.const_5, 
			"thinThick" => Enum485.const_4, 
			"thickThin" => Enum485.const_3, 
			"sng" => Enum485.const_1, 
			"dbl" => Enum485.const_2, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}
}
