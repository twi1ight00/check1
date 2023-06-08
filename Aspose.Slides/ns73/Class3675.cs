using System;
using ns84;

namespace ns73;

internal class Class3675 : Class3549<Enum636>
{
	public override string imethod_2(Enum636 value)
	{
		return value switch
		{
			Enum636.const_0 => "repeat-x", 
			Enum636.const_1 => "repeat-y", 
			Enum636.const_2 => "repeat", 
			Enum636.const_3 => "no-repeat", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum636 value)
	{
		switch (token.ToLower())
		{
		case "no-repeat":
			value = Enum636.const_3;
			return true;
		case "repeat-y":
			value = Enum636.const_1;
			return true;
		case "repeat-x":
			value = Enum636.const_0;
			return true;
		default:
			throw new ArgumentException("token");
		case "repeat":
			value = Enum636.const_2;
			return true;
		}
	}
}
