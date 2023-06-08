using System;
using ns84;

namespace ns73;

internal class Class3626 : Class3549<Enum581>
{
	public override string imethod_2(Enum581 value)
	{
		return value switch
		{
			Enum581.const_0 => "none", 
			Enum581.const_1 => "first", 
			Enum581.const_2 => "last", 
			Enum581.const_3 => "force-end", 
			Enum581.const_4 => "allow-end", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum581 value)
	{
		switch (token.ToLower())
		{
		case "allow-end":
			value = Enum581.const_4;
			return true;
		case "force-end":
			value = Enum581.const_3;
			return true;
		case "last":
			value = Enum581.const_2;
			return true;
		case "first":
			value = Enum581.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "none":
			value = Enum581.const_0;
			return true;
		}
	}
}
