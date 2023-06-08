using System;
using ns84;

namespace ns73;

internal class Class3565 : Class3549<Enum505>
{
	public override string imethod_2(Enum505 value)
	{
		return value switch
		{
			Enum505.const_0 => "window", 
			Enum505.const_1 => "tab", 
			Enum505.const_2 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum505 value)
	{
		switch (token.ToLower())
		{
		case "none":
			value = Enum505.const_2;
			return true;
		case "tab":
			value = Enum505.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "window":
			value = Enum505.const_0;
			return true;
		}
	}
}
