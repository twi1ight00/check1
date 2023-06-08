using System;
using ns84;

namespace ns73;

internal class Class3617 : Class3549<Enum572>
{
	public override string imethod_2(Enum572 value)
	{
		return value switch
		{
			Enum572.const_0 => "horizontal-tb", 
			Enum572.const_1 => "vertical-rl", 
			Enum572.const_2 => "vertical-lr", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum572 value)
	{
		switch (token.ToLower())
		{
		case "vertical-lr":
			value = Enum572.const_2;
			return true;
		case "vertical-rl":
			value = Enum572.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "horizontal-tb":
			value = Enum572.const_0;
			return true;
		}
	}
}
