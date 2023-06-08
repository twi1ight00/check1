using System;
using ns84;

namespace ns73;

internal class Class3573 : Class3549<Enum533>
{
	public override string imethod_2(Enum533 value)
	{
		return value switch
		{
			Enum533.const_0 => "normal", 
			Enum533.const_1 => "sub", 
			Enum533.const_2 => "super", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum533 value)
	{
		switch (token.ToLower())
		{
		case "super":
			value = Enum533.const_2;
			return true;
		case "sub":
			value = Enum533.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "normal":
			value = Enum533.const_0;
			return true;
		}
	}
}
