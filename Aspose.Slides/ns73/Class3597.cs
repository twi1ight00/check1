using System;
using ns84;

namespace ns73;

internal class Class3597 : Class3549<Enum557>
{
	public override string imethod_2(Enum557 value)
	{
		return value switch
		{
			Enum557.const_0 => "row", 
			Enum557.const_1 => "row-reverse", 
			Enum557.const_2 => "column", 
			Enum557.const_3 => "column-reverse", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum557 value)
	{
		switch (token.ToLower())
		{
		case "column-reverse":
			value = Enum557.const_3;
			return true;
		case "column":
			value = Enum557.const_2;
			return true;
		case "row-reverse":
			value = Enum557.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "row":
			value = Enum557.const_0;
			return true;
		}
	}
}
