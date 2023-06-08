using System;
using ns84;

namespace ns73;

internal class Class3674 : Class3549<Enum629>
{
	public override string imethod_2(Enum629 value)
	{
		return value switch
		{
			Enum629.const_0 => "auto", 
			Enum629.const_1 => "crosshair", 
			Enum629.const_2 => "default", 
			Enum629.const_3 => "pointer", 
			Enum629.const_4 => "move", 
			Enum629.const_5 => "e-resize", 
			Enum629.const_6 => "ne-resize", 
			Enum629.const_7 => "nw-resize", 
			Enum629.const_8 => "n-resize", 
			Enum629.const_9 => "se-resize", 
			Enum629.const_10 => "sw-resize", 
			Enum629.const_11 => "s-resize", 
			Enum629.const_12 => "w-resize", 
			Enum629.const_13 => "text", 
			Enum629.const_14 => "wait", 
			Enum629.const_15 => "progress", 
			Enum629.const_16 => "help", 
			Enum629.const_17 => "url", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum629 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum629.const_0;
			return true;
		case "crosshair":
			value = Enum629.const_1;
			return true;
		case "default":
			value = Enum629.const_2;
			return true;
		case "pointer":
			value = Enum629.const_3;
			return true;
		case "move":
			value = Enum629.const_4;
			return true;
		case "e-resize":
			value = Enum629.const_5;
			return true;
		case "ne-resize":
			value = Enum629.const_6;
			return true;
		case "nw-resize":
			value = Enum629.const_7;
			return true;
		case "n-resize":
			value = Enum629.const_8;
			return true;
		case "se-resize":
			value = Enum629.const_9;
			return true;
		case "sw-resize":
			value = Enum629.const_10;
			return true;
		case "s-resize":
			value = Enum629.const_11;
			return true;
		case "w-resize":
			value = Enum629.const_12;
			return true;
		case "text":
			value = Enum629.const_13;
			return true;
		case "wait":
			value = Enum629.const_14;
			return true;
		case "progress":
			value = Enum629.const_15;
			return true;
		case "help":
			value = Enum629.const_16;
			return true;
		default:
			throw new ArgumentException("token");
		case "url":
			value = Enum629.const_17;
			return true;
		}
	}
}
