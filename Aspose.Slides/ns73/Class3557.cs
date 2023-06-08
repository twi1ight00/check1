using System;
using ns84;

namespace ns73;

internal class Class3557 : Class3549<Enum527>
{
	public override string imethod_2(Enum527 value)
	{
		return value switch
		{
			Enum527.const_0 => "balance", 
			Enum527.const_1 => "auto", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum527 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum527.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "balance":
			value = Enum527.const_0;
			return true;
		}
	}
}
