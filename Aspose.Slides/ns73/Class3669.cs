using System;
using ns84;

namespace ns73;

internal class Class3669 : Class3549<Enum622>
{
	public override string imethod_2(Enum622 value)
	{
		return value switch
		{
			Enum622.const_0 => "caption", 
			Enum622.const_1 => "icon", 
			Enum622.const_2 => "menu", 
			Enum622.const_3 => "message-box", 
			Enum622.const_4 => "small-caption", 
			Enum622.const_5 => "status-bar", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum622 value)
	{
		switch (token.ToLower())
		{
		case "caption":
			value = Enum622.const_0;
			return true;
		case "icon":
			value = Enum622.const_1;
			return true;
		case "menu":
			value = Enum622.const_2;
			return true;
		case "message-box":
			value = Enum622.const_3;
			return true;
		case "small-caption":
			value = Enum622.const_4;
			return true;
		default:
			throw new ArgumentException("token");
		case "status-bar":
			value = Enum622.const_5;
			return true;
		}
	}
}
