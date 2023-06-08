using System;
using ns84;

namespace ns73;

internal class Class3625 : Class3549<Enum580>
{
	public override string imethod_2(Enum580 value)
	{
		return value switch
		{
			Enum580.const_0 => "normal", 
			Enum580.const_1 => "break-word", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum580 value)
	{
		switch (token.ToLower())
		{
		case "break-word":
			value = Enum580.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "normal":
			value = Enum580.const_0;
			return true;
		}
	}
}
