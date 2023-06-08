using System;
using ns84;

namespace ns73;

internal class Class3609 : Class3549<Enum563>
{
	public override string imethod_2(Enum563 value)
	{
		return value switch
		{
			Enum563.const_0 => "slow", 
			Enum563.const_1 => "normal", 
			Enum563.const_2 => "fast", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum563 value)
	{
		switch (token.ToLower())
		{
		case "fast":
			value = Enum563.const_2;
			return true;
		case "normal":
			value = Enum563.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "slow":
			value = Enum563.const_0;
			return true;
		}
	}
}
