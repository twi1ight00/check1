using System;
using ns84;

namespace ns73;

internal class Class3558 : Class3549<Enum528>
{
	public override string imethod_2(Enum528 value)
	{
		return value switch
		{
			Enum528.const_0 => "baseline", 
			Enum528.const_1 => "use-script", 
			Enum528.const_2 => "before-edge", 
			Enum528.const_3 => "text-before-edge", 
			Enum528.const_4 => "after-edge", 
			Enum528.const_5 => "text-after-edge", 
			Enum528.const_6 => "central", 
			Enum528.const_7 => "middle", 
			Enum528.const_8 => "ideographic", 
			Enum528.const_9 => "alphabetic", 
			Enum528.const_10 => "hanging", 
			Enum528.const_11 => "mathematical", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum528 value)
	{
		switch (token.ToLower())
		{
		case "baseline":
			value = Enum528.const_0;
			return true;
		case "use-script":
			value = Enum528.const_1;
			return true;
		case "before-edge":
			value = Enum528.const_2;
			return true;
		case "text-before-edge":
			value = Enum528.const_3;
			return true;
		case "after-edge":
			value = Enum528.const_4;
			return true;
		case "text-after-edge":
			value = Enum528.const_5;
			return true;
		case "central":
			value = Enum528.const_6;
			return true;
		case "middle":
			value = Enum528.const_7;
			return true;
		case "ideographic":
			value = Enum528.const_8;
			return true;
		case "alphabetic":
			value = Enum528.const_9;
			return true;
		case "hanging":
			value = Enum528.const_10;
			return true;
		default:
			throw new ArgumentException("token");
		case "mathematical":
			value = Enum528.const_11;
			return true;
		}
	}
}
