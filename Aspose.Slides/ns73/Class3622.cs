using System;
using ns84;

namespace ns73;

internal class Class3622 : Class3549<Enum577>
{
	public override string imethod_2(Enum577 value)
	{
		return value switch
		{
			Enum577.const_0 => "auto", 
			Enum577.const_1 => "start", 
			Enum577.const_2 => "end", 
			Enum577.const_3 => "left", 
			Enum577.const_4 => "right", 
			Enum577.const_5 => "center", 
			Enum577.const_6 => "justify", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum577 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum577.const_0;
			return true;
		case "center":
			value = Enum577.const_5;
			return true;
		case "end":
			value = Enum577.const_2;
			return true;
		case "justify":
			value = Enum577.const_6;
			return true;
		case "left":
			value = Enum577.const_3;
			return true;
		case "right":
			value = Enum577.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "Start":
			value = Enum577.const_1;
			return true;
		}
	}
}
