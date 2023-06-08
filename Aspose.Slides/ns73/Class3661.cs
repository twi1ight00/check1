using System;
using ns84;

namespace ns73;

internal class Class3661 : Class3549<Enum598>
{
	public override string imethod_2(Enum598 value)
	{
		return value switch
		{
			Enum598.const_0 => "below", 
			Enum598.const_1 => "level", 
			Enum598.const_2 => "above", 
			Enum598.const_3 => "higher", 
			Enum598.const_4 => "lower", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum598 value)
	{
		switch (token.ToLower())
		{
		case "lower":
			value = Enum598.const_4;
			return true;
		case "higher":
			value = Enum598.const_3;
			return true;
		case "above":
			value = Enum598.const_2;
			return true;
		case "level":
			value = Enum598.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "below":
			value = Enum598.const_0;
			return true;
		}
	}
}
