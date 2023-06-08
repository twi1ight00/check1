using System;
using ns84;

namespace ns73;

internal class Class3634 : Class3549<Enum635>
{
	public override string imethod_2(Enum635 value)
	{
		return value switch
		{
			Enum635.const_0 => "left", 
			Enum635.const_1 => "right", 
			Enum635.const_2 => "top", 
			Enum635.const_3 => "bottom", 
			Enum635.const_4 => "center", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum635 value)
	{
		switch (token.ToLower())
		{
		case "top":
			value = Enum635.const_2;
			return true;
		case "right":
			value = Enum635.const_1;
			return true;
		case "left":
			value = Enum635.const_0;
			return true;
		case "center":
			value = Enum635.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "bottom":
			value = Enum635.const_3;
			return true;
		}
	}
}
