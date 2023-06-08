using System;
using ns84;

namespace ns73;

internal class Class3560 : Class3549<Enum530>
{
	public override string imethod_2(Enum530 value)
	{
		return value switch
		{
			Enum530.const_0 => "auto", 
			Enum530.const_1 => "baseline", 
			Enum530.const_2 => "before-edge", 
			Enum530.const_3 => "text-before-edge", 
			Enum530.const_4 => "central", 
			Enum530.const_5 => "middle", 
			Enum530.const_6 => "after-edge", 
			Enum530.const_7 => "text-after-edge", 
			Enum530.const_8 => "ideographic", 
			Enum530.const_9 => "alphabetic", 
			Enum530.const_10 => "hanging", 
			Enum530.const_11 => "mathematical", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum530 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum530.const_0;
			return true;
		case "baseline":
			value = Enum530.const_1;
			return true;
		case "before-edge":
			value = Enum530.const_2;
			return true;
		case "text-before-edge":
			value = Enum530.const_3;
			return true;
		case "central":
			value = Enum530.const_4;
			return true;
		case "middle":
			value = Enum530.const_5;
			return true;
		case "after-edge":
			value = Enum530.const_6;
			return true;
		case "text-after-edge":
			value = Enum530.const_7;
			return true;
		case "ideographic":
			value = Enum530.const_8;
			return true;
		case "alphabetic":
			value = Enum530.const_9;
			return true;
		case "hanging":
			value = Enum530.const_10;
			return true;
		default:
			throw new ArgumentException("token");
		case "mathematical":
			value = Enum530.const_11;
			return true;
		}
	}
}
