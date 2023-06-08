using System;
using ns84;

namespace ns73;

internal class Class3651 : Class3549<Enum589>
{
	public override string imethod_2(Enum589 value)
	{
		return value switch
		{
			Enum589.const_0 => "left-side", 
			Enum589.const_1 => "far-left", 
			Enum589.const_2 => "left", 
			Enum589.const_3 => "center-left", 
			Enum589.const_4 => "center", 
			Enum589.const_5 => "center-right", 
			Enum589.const_6 => "right", 
			Enum589.const_7 => "far-right", 
			Enum589.const_8 => "right-side", 
			Enum589.const_9 => "leftwards", 
			Enum589.const_10 => "rightwards", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum589 value)
	{
		switch (token.ToLower())
		{
		case "left-side":
			value = Enum589.const_0;
			return true;
		case "far-left":
			value = Enum589.const_1;
			return true;
		case "left":
			value = Enum589.const_2;
			return true;
		case "center-left":
			value = Enum589.const_3;
			return true;
		case "center":
			value = Enum589.const_4;
			return true;
		case "center-right":
			value = Enum589.const_5;
			return true;
		case "right":
			value = Enum589.const_6;
			return true;
		case "far-right":
			value = Enum589.const_7;
			return true;
		case "right-side":
			value = Enum589.const_8;
			return true;
		case "leftwards":
			value = Enum589.const_9;
			return true;
		default:
			throw new ArgumentException("token");
		case "rightwards":
			value = Enum589.const_10;
			return true;
		}
	}
}
