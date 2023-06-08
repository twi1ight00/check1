using System;
using ns84;

namespace ns73;

internal class Class3648 : Class3549<Enum627>
{
	public override string imethod_2(Enum627 value)
	{
		return value switch
		{
			Enum627.const_0 => "left", 
			Enum627.const_1 => "right", 
			Enum627.const_2 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum627 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum627.const_1;
			return true;
		case "none":
			value = Enum627.const_2;
			return true;
		default:
			throw new ArgumentException("value");
		case "left":
			value = Enum627.const_0;
			return true;
		}
	}
}
