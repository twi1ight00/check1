using System;

namespace ns67;

internal sealed class Class3440 : ICloneable
{
	private Enum488 enum488_0;

	private Enum487 enum487_0;

	private Enum489 enum489_0;

	public Enum487 Kind
	{
		get
		{
			return enum487_0;
		}
		set
		{
			enum487_0 = value;
		}
	}

	public Enum488 Length
	{
		get
		{
			return enum488_0;
		}
		set
		{
			enum488_0 = value;
		}
	}

	public Enum489 Width
	{
		get
		{
			return enum489_0;
		}
		set
		{
			enum489_0 = value;
		}
	}

	public Class3440()
		: this(Enum487.const_0, Enum488.const_0, Enum489.const_0)
	{
	}

	public Class3440(Enum487 kind, Enum488 length, Enum489 width)
	{
		enum487_0 = kind;
		enum488_0 = length;
		enum489_0 = width;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3440 method_0()
	{
		return new Class3440(enum487_0, enum488_0, enum489_0);
	}

	public static Enum488 smethod_0(string value)
	{
		return value switch
		{
			"sm" => Enum488.const_1, 
			"med" => Enum488.const_2, 
			"lg" => Enum488.const_3, 
			_ => throw new ArgumentOutOfRangeException("value"), 
		};
	}

	public static Enum487 smethod_1(string value)
	{
		return value switch
		{
			"arrow" => Enum487.const_6, 
			"diamond" => Enum487.const_4, 
			"none" => Enum487.const_1, 
			"oval" => Enum487.const_5, 
			"stealth" => Enum487.const_3, 
			"triangle" => Enum487.const_2, 
			_ => throw new ArgumentOutOfRangeException("value"), 
		};
	}

	public static Enum489 smethod_2(string value)
	{
		return value switch
		{
			"sm" => Enum489.const_1, 
			"med" => Enum489.const_2, 
			"lg" => Enum489.const_3, 
			_ => throw new ArgumentOutOfRangeException("value"), 
		};
	}
}
