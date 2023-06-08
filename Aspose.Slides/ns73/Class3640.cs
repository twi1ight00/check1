using System;
using ns84;

namespace ns73;

internal class Class3640 : Class3549<Enum614>
{
	public override string imethod_2(Enum614 value)
	{
		return value switch
		{
			Enum614.const_0 => "Capitalize", 
			Enum614.const_1 => "Uppercase", 
			Enum614.const_2 => "Lowercase", 
			Enum614.const_3 => "None", 
			Enum614.const_4 => "full-width", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum614 value)
	{
		switch (token.ToLower())
		{
		case "full-width":
			value = Enum614.const_4;
			return true;
		case "uppercase":
			value = Enum614.const_1;
			return true;
		case "none":
			value = Enum614.const_3;
			return true;
		case "lowercase":
			value = Enum614.const_2;
			return true;
		default:
			throw new ArgumentException("value");
		case "capitalize":
			value = Enum614.const_0;
			return true;
		}
	}
}
