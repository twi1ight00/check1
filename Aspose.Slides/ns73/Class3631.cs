using System;
using ns84;

namespace ns73;

internal class Class3631 : Class3549<Enum514>
{
	public override string imethod_2(Enum514 value)
	{
		return value switch
		{
			Enum514.const_1 => "first-line", 
			Enum514.const_2 => "first-letter", 
			Enum514.const_3 => "after", 
			Enum514.const_4 => "before", 
			Enum514.const_5 => "marker", 
			Enum514.const_6 => "first", 
			Enum514.const_7 => "left", 
			Enum514.const_8 => "right", 
			Enum514.const_9 => "link", 
			Enum514.const_10 => "visited", 
			Enum514.const_11 => "focus", 
			Enum514.const_12 => "active", 
			Enum514.const_13 => "hover", 
			Enum514.const_14 => "target", 
			Enum514.const_15 => "default", 
			Enum514.const_16 => "selection", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum514 value)
	{
		switch (token)
		{
		case "first-line":
			value = Enum514.const_1;
			return true;
		case "first-letter":
			value = Enum514.const_2;
			return true;
		case "before":
			value = Enum514.const_4;
			return true;
		case "after":
			value = Enum514.const_3;
			return true;
		case "first":
			value = Enum514.const_6;
			return true;
		case "left":
			value = Enum514.const_7;
			return true;
		case "right":
			value = Enum514.const_8;
			return true;
		case "link":
			value = Enum514.const_9;
			return true;
		case "visited":
			value = Enum514.const_10;
			return true;
		case "focus":
			value = Enum514.const_11;
			return true;
		case "active":
			value = Enum514.const_12;
			return true;
		case "hover":
			value = Enum514.const_13;
			return true;
		case "target":
			value = Enum514.const_14;
			return true;
		case "default":
			value = Enum514.const_15;
			return true;
		case "selection":
			value = Enum514.const_16;
			return true;
		case "marker":
			value = Enum514.const_5;
			return true;
		default:
			value = Enum514.const_0;
			return false;
		}
	}
}
