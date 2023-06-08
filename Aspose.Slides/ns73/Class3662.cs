using System;
using ns84;

namespace ns73;

internal class Class3662 : Class3549<Enum599>
{
	public override string imethod_2(Enum599 value)
	{
		return value switch
		{
			Enum599.const_1 => "all", 
			Enum599.const_2 => "braille", 
			Enum599.const_3 => "embossed", 
			Enum599.const_4 => "handheld", 
			Enum599.const_5 => "print", 
			Enum599.const_6 => "projection", 
			Enum599.const_7 => "screen", 
			Enum599.const_8 => "speech", 
			Enum599.const_9 => "tty", 
			Enum599.const_10 => "tv", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum599 value)
	{
		switch (token.ToLower())
		{
		case "all":
			value = Enum599.const_1;
			return true;
		case "braille":
			value = Enum599.const_2;
			return true;
		case "embossed":
			value = Enum599.const_3;
			return true;
		case "handheld":
			value = Enum599.const_4;
			return true;
		case "print":
			value = Enum599.const_5;
			return true;
		case "projection":
			value = Enum599.const_6;
			return true;
		case "screen":
			value = Enum599.const_7;
			return true;
		case "speech":
			value = Enum599.const_8;
			return true;
		case "tty":
			value = Enum599.const_9;
			return true;
		case "tv":
			value = Enum599.const_10;
			return true;
		default:
			value = Enum599.const_0;
			return false;
		}
	}
}
