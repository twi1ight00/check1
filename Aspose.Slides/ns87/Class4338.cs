using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4338 : Class4337
{
	private bool bool_0;

	private bool bool_1;

	public bool Auto => bool_0;

	public bool None => bool_1;

	public Class4338(float unitValue, Enum634 unitType)
		: base(unitValue, unitType)
	{
	}

	public override string ToString()
	{
		if (Auto)
		{
			return "auto";
		}
		if (None)
		{
			return "none";
		}
		return base.ToString();
	}

	internal static Class4338 smethod_0()
	{
		Class4338 @class = new Class4338(0f, Enum634.const_0);
		@class.bool_0 = true;
		return @class;
	}

	internal static Class4338 smethod_1()
	{
		Class4338 @class = new Class4338(0f, Enum634.const_0);
		@class.bool_1 = true;
		return @class;
	}

	internal static Class4338 smethod_2(Class4337 value)
	{
		return new Class4338(value.Value, value.Type);
	}

	internal static Class4338 smethod_3(Class3681 size)
	{
		return size.PrimitiveType switch
		{
			2 => new Class4338(size.vmethod_1(2), Enum634.const_1), 
			3 => new Class4338(size.vmethod_1(3), Enum634.const_2), 
			4 => new Class4338(size.vmethod_1(4), Enum634.const_3), 
			5 => new Class4338(size.vmethod_1(5), Enum634.const_4), 
			6 => new Class4338(size.vmethod_1(6), Enum634.const_5), 
			7 => new Class4338(size.vmethod_1(7), Enum634.const_6), 
			8 => new Class4338(size.vmethod_1(8), Enum634.const_7), 
			9 => new Class4338(size.vmethod_1(9), Enum634.const_8), 
			10 => new Class4338(size.vmethod_1(10), Enum634.const_9), 
			11 => new Class4338(size.vmethod_1(10), Enum634.const_10), 
			12 => new Class4338(size.vmethod_1(10), Enum634.const_11), 
			13 => new Class4338(size.vmethod_1(10), Enum634.const_12), 
			14 => new Class4338(size.vmethod_1(10), Enum634.const_13), 
			15 => new Class4338(size.vmethod_1(10), Enum634.const_14), 
			16 => new Class4338(size.vmethod_1(10), Enum634.const_15), 
			17 => new Class4338(size.vmethod_1(10), Enum634.const_16), 
			26 => new Class4338(size.vmethod_1(10), Enum634.const_17), 
			27 => new Class4338(size.vmethod_1(10), Enum634.const_18), 
			28 => new Class4338(size.vmethod_1(10), Enum634.const_19), 
			_ => new Class4338(size.vmethod_1(1), Enum634.const_0), 
		};
	}

	internal static Class4338 smethod_4(Class3679 value)
	{
		Class3680 @class = (Class3680)value;
		short primitiveType = @class.PrimitiveType;
		if (primitiveType == 21)
		{
			if (Class3700.Class3702.class3689_3 == @class)
			{
				return smethod_0();
			}
			if (Class3700.Class3702.class3689_318 == @class)
			{
				return new Class4338(float.PositiveInfinity, Enum634.const_0);
			}
			if (Class3700.Class3702.class3689_4 == @class)
			{
				return smethod_1();
			}
		}
		return smethod_3((Class3681)value);
	}
}
