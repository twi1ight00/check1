using System;
using ns84;

namespace ns73;

internal class Class3603 : Class3549<Enum518>
{
	public override string imethod_2(Enum518 value)
	{
		return value switch
		{
			Enum518.const_0 => "normal", 
			Enum518.const_1 => "reverse", 
			Enum518.const_2 => "alternate", 
			Enum518.const_3 => "alternate-reverse", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum518 value)
	{
		switch (token.ToLower())
		{
		case "alternate-reverse":
			value = Enum518.const_3;
			return true;
		case "alternate":
			value = Enum518.const_2;
			return true;
		case "reverse":
			value = Enum518.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "normal":
			value = Enum518.const_0;
			return true;
		}
	}
}
