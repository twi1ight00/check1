using System;
using ns84;

namespace ns73;

internal class Class3604 : Class3549<Enum519>
{
	public override string imethod_2(Enum519 value)
	{
		return value switch
		{
			Enum519.const_0 => "none", 
			Enum519.const_1 => "forwards", 
			Enum519.const_2 => "backwards", 
			Enum519.const_3 => "both", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum519 value)
	{
		switch (token.ToLower())
		{
		case "both":
			value = Enum519.const_3;
			return true;
		case "backwards":
			value = Enum519.const_2;
			return true;
		case "forwards":
			value = Enum519.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum519.const_0;
			return true;
		}
	}
}
