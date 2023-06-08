using System;
using ns84;

namespace ns73;

internal class Class3556 : Class3549<Enum526>
{
	public override string imethod_2(Enum526 value)
	{
		return value switch
		{
			Enum526.const_0 => "none", 
			Enum526.const_1 => "all", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum526 value)
	{
		switch (token.ToLower())
		{
		case "all":
			value = Enum526.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum526.const_0;
			return true;
		}
	}
}
