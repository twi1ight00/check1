using System;
using ns84;

namespace ns73;

internal class Class3671 : Class3549<Enum624>
{
	public override string imethod_2(Enum624 value)
	{
		return value switch
		{
			Enum624.const_0 => "normal", 
			Enum624.const_1 => "small-caps", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum624 value)
	{
		switch (token.ToLower())
		{
		case "small-caps":
			value = Enum624.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "normal":
			value = Enum624.const_0;
			return true;
		}
	}
}
