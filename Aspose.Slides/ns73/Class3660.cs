using System;
using ns84;

namespace ns73;

internal class Class3660 : Class3549<Enum597>
{
	public override string imethod_2(Enum597 value)
	{
		return value switch
		{
			Enum597.const_0 => "x-low", 
			Enum597.const_1 => "low", 
			Enum597.const_2 => "medium", 
			Enum597.const_3 => "high", 
			Enum597.const_4 => "x-high", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum597 value)
	{
		switch (token.ToLower())
		{
		case "x-high":
			value = Enum597.const_4;
			return true;
		case "high":
			value = Enum597.const_3;
			return true;
		case "medium":
			value = Enum597.const_2;
			return true;
		case "low":
			value = Enum597.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "x-low":
			value = Enum597.const_0;
			return true;
		}
	}
}
