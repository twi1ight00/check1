using System;
using ns84;

namespace ns73;

internal class Class3588 : Class3549<Enum548>
{
	public override string imethod_2(Enum548 value)
	{
		return value switch
		{
			Enum548.const_0 => "auto", 
			Enum548.const_1 => "use-script", 
			Enum548.const_2 => "no-change", 
			Enum548.const_3 => "reset-size", 
			Enum548.const_4 => "alphabetic", 
			Enum548.const_5 => "hanging", 
			Enum548.const_6 => "ideographic", 
			Enum548.const_7 => "mathematical", 
			Enum548.const_8 => "central", 
			Enum548.const_9 => "middle", 
			Enum548.const_10 => "text-after-edge", 
			Enum548.const_11 => "text-before-edge", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum548 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum548.const_0;
			return true;
		case "use-script":
			value = Enum548.const_1;
			return true;
		case "no-change":
			value = Enum548.const_2;
			return true;
		case "reset-size":
			value = Enum548.const_3;
			return true;
		case "alphabetic":
			value = Enum548.const_4;
			return true;
		case "hanging":
			value = Enum548.const_5;
			return true;
		case "ideographic":
			value = Enum548.const_6;
			return true;
		case "mathematical":
			value = Enum548.const_7;
			return true;
		case "central":
			value = Enum548.const_8;
			return true;
		case "middle":
			value = Enum548.const_9;
			return true;
		case "text-after-edge":
			value = Enum548.const_10;
			return true;
		default:
			throw new ArgumentException("token");
		case "text-before-edge":
			value = Enum548.const_11;
			return true;
		}
	}
}
