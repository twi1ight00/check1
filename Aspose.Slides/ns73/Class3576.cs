using System;
using ns84;

namespace ns73;

internal class Class3576 : Class3549<Enum536>
{
	public override string imethod_2(Enum536 value)
	{
		return value switch
		{
			Enum536.const_0 => "normal", 
			Enum536.const_1 => "jis78", 
			Enum536.const_2 => "jis83", 
			Enum536.const_3 => "jis90", 
			Enum536.const_4 => "jis04", 
			Enum536.const_5 => "simplified", 
			Enum536.const_6 => "traditional", 
			Enum536.const_7 => "full-width", 
			Enum536.const_8 => "proportional-width", 
			Enum536.const_9 => "ruby", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum536 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum536.const_0;
			return true;
		case "jis78":
			value = Enum536.const_1;
			return true;
		case "jis83":
			value = Enum536.const_2;
			return true;
		case "jis90":
			value = Enum536.const_3;
			return true;
		case "jis04":
			value = Enum536.const_4;
			return true;
		case "simplified":
			value = Enum536.const_5;
			return true;
		case "traditional":
			value = Enum536.const_6;
			return true;
		case "full-width":
			value = Enum536.const_7;
			return true;
		case "proportional-width":
			value = Enum536.const_8;
			return true;
		default:
			throw new ArgumentException("value");
		case "ruby":
			value = Enum536.const_9;
			return true;
		}
	}
}
