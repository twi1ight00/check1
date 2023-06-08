using System;
using ns84;

namespace ns73;

internal class Class3601 : Class3549<Enum515>
{
	public override string imethod_2(Enum515 value)
	{
		return value switch
		{
			Enum515.const_0 => "border-box", 
			Enum515.const_1 => "padding-box", 
			Enum515.const_2 => "content-box", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum515 value)
	{
		switch (token.ToLower())
		{
		case "content-box":
			value = Enum515.const_2;
			return true;
		case "padding-box":
			value = Enum515.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "border-box":
			value = Enum515.const_0;
			return true;
		}
	}
}
