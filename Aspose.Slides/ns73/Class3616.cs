using System;
using ns84;

namespace ns73;

internal class Class3616 : Class3549<Enum571>
{
	public override string imethod_2(Enum571 value)
	{
		return value switch
		{
			Enum571.const_0 => "mixed", 
			Enum571.const_1 => "upright", 
			Enum571.const_2 => "sideways-right", 
			Enum571.const_3 => "sideways-left", 
			Enum571.const_4 => "sideways", 
			Enum571.const_5 => "use-glyph-orientation", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum571 value)
	{
		switch (token.ToLower())
		{
		case "mixed":
			value = Enum571.const_0;
			return true;
		case "upright":
			value = Enum571.const_1;
			return true;
		case "sideways-right":
			value = Enum571.const_2;
			return true;
		case "sideways-left":
			value = Enum571.const_3;
			return true;
		case "sideways":
			value = Enum571.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "use-glyph-orientation":
			value = Enum571.const_5;
			return true;
		}
	}
}
