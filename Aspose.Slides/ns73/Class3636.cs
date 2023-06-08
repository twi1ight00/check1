using System;
using ns84;

namespace ns73;

internal class Class3636 : Class3549<Enum605>
{
	public override string imethod_2(Enum605 value)
	{
		return value switch
		{
			Enum605.const_0 => "none", 
			Enum605.const_1 => "hidden", 
			Enum605.const_2 => "dotted", 
			Enum605.const_3 => "dashed", 
			Enum605.const_4 => "solid", 
			Enum605.const_5 => "double", 
			Enum605.const_6 => "groove", 
			Enum605.const_7 => "ridge", 
			Enum605.const_8 => "inset", 
			Enum605.const_9 => "outset", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum605 value)
	{
		switch (token.ToLower())
		{
		case "dashed":
			value = Enum605.const_3;
			return true;
		case "dotted":
			value = Enum605.const_2;
			return true;
		case "double":
			value = Enum605.const_5;
			return true;
		case "groove":
			value = Enum605.const_6;
			return true;
		case "hidden":
			value = Enum605.const_1;
			return true;
		case "inset":
			value = Enum605.const_8;
			return true;
		case "none":
			value = Enum605.const_0;
			return true;
		case "outset":
			value = Enum605.const_9;
			return true;
		case "ridge":
			value = Enum605.const_7;
			return true;
		default:
			throw new ArgumentException("value");
		case "solid":
			value = Enum605.const_4;
			return true;
		}
	}
}
