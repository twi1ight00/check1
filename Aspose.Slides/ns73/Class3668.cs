using System;
using ns84;

namespace ns73;

internal class Class3668 : Class3549<Enum620>
{
	public override string imethod_2(Enum620 value)
	{
		return value switch
		{
			Enum620.const_0 => "disc", 
			Enum620.const_1 => "circle", 
			Enum620.const_2 => "square", 
			Enum620.const_3 => "decimal", 
			Enum620.const_4 => "decimal-leading-zero", 
			Enum620.const_5 => "lower-roman", 
			Enum620.const_6 => "upper-roman", 
			Enum620.const_7 => "lower-greek", 
			Enum620.const_8 => "lower-latin", 
			Enum620.const_9 => "upper-latin", 
			Enum620.const_10 => "armenian", 
			Enum620.const_11 => "georgian", 
			Enum620.const_12 => "lower-alpha", 
			Enum620.const_13 => "upper-alpha", 
			Enum620.const_14 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum620 value)
	{
		switch (token.ToLower())
		{
		case "disc":
			value = Enum620.const_0;
			return true;
		case "circle":
			value = Enum620.const_1;
			return true;
		case "square":
			value = Enum620.const_2;
			return true;
		case "decimal":
			value = Enum620.const_3;
			return true;
		case "decimal-leading-zero":
			value = Enum620.const_4;
			return true;
		case "lower-roman":
			value = Enum620.const_5;
			return true;
		case "upper-roman":
			value = Enum620.const_6;
			return true;
		case "lower-greek":
			value = Enum620.const_7;
			return true;
		case "lower-latin":
			value = Enum620.const_8;
			return true;
		case "upper-latin":
			value = Enum620.const_9;
			return true;
		case "armenian":
			value = Enum620.const_10;
			return true;
		case "georgian":
			value = Enum620.const_11;
			return true;
		case "lower-alpha":
			value = Enum620.const_12;
			return true;
		case "upper-alpha":
			value = Enum620.const_13;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum620.const_14;
			return true;
		}
	}
}
