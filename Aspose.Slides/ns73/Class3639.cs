using System;
using ns84;

namespace ns73;

internal class Class3639 : Class3549<Enum612>
{
	public override string imethod_2(Enum612 value)
	{
		return value switch
		{
			Enum612.const_0 => "visible", 
			Enum612.const_1 => "hidden", 
			Enum612.const_2 => "collapse", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum612 value)
	{
		switch (token.ToLower())
		{
		case "visible":
			value = Enum612.const_0;
			return true;
		case "hidden":
			value = Enum612.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "collapse":
			value = Enum612.const_2;
			return true;
		}
	}
}
