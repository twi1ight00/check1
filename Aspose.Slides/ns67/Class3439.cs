using System;

namespace ns67;

internal sealed class Class3439 : Class3437
{
	private Enum484 enum484_0;

	public Enum484 Kind
	{
		get
		{
			return enum484_0;
		}
		set
		{
			enum484_0 = value;
		}
	}

	public Class3439()
		: this(Enum484.const_0)
	{
	}

	public Class3439(Enum484 kind)
	{
		enum484_0 = kind;
	}

	public override Class3437 vmethod_0()
	{
		return new Class3439(enum484_0);
	}

	public Class3438 method_0()
	{
		Class3438 @class = new Class3438();
		switch (enum484_0)
		{
		default:
			throw new NotImplementedException();
		case Enum484.const_0:
			return @class;
		case Enum484.const_1:
			@class.DashStopList.Add(new Class3341(100000, 300000));
			return @class;
		case Enum484.const_2:
			@class.DashStopList.Add(new Class3341(400000, 300000));
			return @class;
		case Enum484.const_3:
			@class.DashStopList.Add(new Class3341(800000, 300000));
			return @class;
		case Enum484.const_4:
			@class.DashStopList.Add(new Class3341(400000, 300000));
			@class.DashStopList.Add(new Class3341(100000, 300000));
			return @class;
		case Enum484.const_5:
			@class.DashStopList.Add(new Class3341(800000, 300000));
			@class.DashStopList.Add(new Class3341(100000, 300000));
			return @class;
		case Enum484.const_6:
			@class.DashStopList.Add(new Class3341(800000, 300000));
			@class.DashStopList.Add(new Class3341(100000, 300000));
			@class.DashStopList.Add(new Class3341(100000, 300000));
			return @class;
		case Enum484.const_7:
			@class.DashStopList.Add(new Class3341(300000, 100000));
			return @class;
		case Enum484.const_8:
			@class.DashStopList.Add(new Class3341(100000, 100000));
			return @class;
		case Enum484.const_9:
			@class.DashStopList.Add(new Class3341(300000, 100000));
			@class.DashStopList.Add(new Class3341(100000, 100000));
			return @class;
		case Enum484.const_10:
			@class.DashStopList.Add(new Class3341(300000, 100000));
			@class.DashStopList.Add(new Class3341(100000, 100000));
			@class.DashStopList.Add(new Class3341(100000, 100000));
			return @class;
		}
	}

	public static Enum484 smethod_0(string value)
	{
		return value switch
		{
			"dash" => Enum484.const_2, 
			"dashDot" => Enum484.const_4, 
			"dot" => Enum484.const_1, 
			"lgDash" => Enum484.const_3, 
			"lgDashDot" => Enum484.const_5, 
			"lgDashDotDot" => Enum484.const_6, 
			"solid" => Enum484.const_0, 
			"sysDash" => Enum484.const_7, 
			"sysDashDot" => Enum484.const_9, 
			"sysDashDotDot" => Enum484.const_10, 
			"sysDot" => Enum484.const_8, 
			_ => throw new ArgumentOutOfRangeException("value"), 
		};
	}
}
