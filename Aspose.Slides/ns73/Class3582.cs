using System;
using ns84;

namespace ns73;

internal class Class3582 : Class3549<Enum542>
{
	public override string imethod_2(Enum542 value)
	{
		return value switch
		{
			Enum542.const_0 => "central", 
			Enum542.const_1 => "middle", 
			Enum542.const_2 => "after-edge", 
			Enum542.const_3 => "text-after-edge", 
			Enum542.const_4 => "ideographic", 
			Enum542.const_5 => "alphabetic", 
			Enum542.const_6 => "hanging", 
			Enum542.const_7 => "mathematical", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum542 value)
	{
		switch (token.ToLower())
		{
		case "central":
			value = Enum542.const_0;
			return true;
		case "middle":
			value = Enum542.const_1;
			return true;
		case "after-edge":
			value = Enum542.const_2;
			return true;
		case "text-after-edge":
			value = Enum542.const_3;
			return true;
		case "ideographic":
			value = Enum542.const_4;
			return true;
		case "alphabetic":
			value = Enum542.const_5;
			return true;
		case "hanging":
			value = Enum542.const_6;
			return true;
		default:
			throw new ArgumentException("value");
		case "mathematical":
			value = Enum542.const_7;
			return true;
		}
	}
}
