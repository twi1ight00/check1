using System;
using ns84;

namespace ns73;

internal class Class3563 : Class3549<Enum503>
{
	public override string imethod_2(Enum503 value)
	{
		return value switch
		{
			Enum503.const_0 => "auto", 
			Enum503.const_1 => "normal", 
			Enum503.const_2 => "active", 
			Enum503.const_3 => "inactive", 
			Enum503.const_4 => "disabled", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum503 value)
	{
		switch (token.ToLower())
		{
		case "disabled":
			value = Enum503.const_4;
			return true;
		case "inactive":
			value = Enum503.const_3;
			return true;
		case "active":
			value = Enum503.const_2;
			return true;
		case "normal":
			value = Enum503.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum503.const_0;
			return true;
		}
	}
}
