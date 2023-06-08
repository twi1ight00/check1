using System;
using ns84;

namespace ns73;

internal class Class3575 : Class3549<Enum535>
{
	public override string imethod_2(Enum535 value)
	{
		return value switch
		{
			Enum535.const_0 => "normal", 
			Enum535.const_1 => "none", 
			Enum535.const_2 => "common-ligatures", 
			Enum535.const_3 => "no-common-ligatures", 
			Enum535.const_4 => "discretionary-ligatures", 
			Enum535.const_5 => "no-discretionary-ligatures", 
			Enum535.const_6 => "historical-ligatures", 
			Enum535.const_7 => "no-historical-ligatures", 
			Enum535.const_8 => "contextual", 
			Enum535.const_9 => "no-contextual", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum535 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum535.const_0;
			return true;
		case "none":
			value = Enum535.const_1;
			return true;
		case "common-ligatures":
			value = Enum535.const_2;
			return true;
		case "no-common-ligatures":
			value = Enum535.const_3;
			return true;
		case "discretionary-ligatures":
			value = Enum535.const_4;
			return true;
		case "no-discretionary-ligatures":
			value = Enum535.const_5;
			return true;
		case "historical-ligatures":
			value = Enum535.const_6;
			return true;
		case "no-historical-ligatures":
			value = Enum535.const_7;
			return true;
		case "contextual":
			value = Enum535.const_8;
			return true;
		default:
			throw new ArgumentException("value");
		case "no-contextual":
			value = Enum535.const_9;
			return true;
		}
	}
}
