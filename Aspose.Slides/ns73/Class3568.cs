using System;
using ns84;

namespace ns73;

internal class Class3568 : Class3549<Enum508>
{
	public override string imethod_2(Enum508 value)
	{
		return value switch
		{
			Enum508.const_0 => "left", 
			Enum508.const_1 => "center", 
			Enum508.const_2 => "right", 
			Enum508.const_3 => "leftwards", 
			Enum508.const_4 => "rightwards", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum508 value)
	{
		switch (token.ToLower())
		{
		case "rightwards":
			value = Enum508.const_4;
			return true;
		case "leftwards":
			value = Enum508.const_3;
			return true;
		case "right":
			value = Enum508.const_2;
			return true;
		case "center":
			value = Enum508.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "left":
			value = Enum508.const_0;
			return true;
		}
	}
}
