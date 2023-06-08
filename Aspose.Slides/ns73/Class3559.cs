using System;
using ns84;

namespace ns73;

internal class Class3559 : Class3549<Enum529>
{
	public override string imethod_2(Enum529 value)
	{
		return value switch
		{
			Enum529.const_0 => "baseline", 
			Enum529.const_1 => "sub", 
			Enum529.const_2 => "super", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum529 value)
	{
		switch (token.ToLower())
		{
		case "super":
			value = Enum529.const_2;
			return true;
		case "sub":
			value = Enum529.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "baseline":
			value = Enum529.const_0;
			return true;
		}
	}
}
