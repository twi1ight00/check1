using System;
using ns84;

namespace ns73;

internal class Class3655 : Class3549<Enum593>
{
	public override string imethod_2(Enum593 value)
	{
		return value switch
		{
			Enum593.const_0 => "none", 
			Enum593.const_1 => "normal", 
			Enum593.const_2 => "spell-out", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum593 value)
	{
		switch (token.ToLower())
		{
		case "spell-out":
			value = Enum593.const_2;
			return true;
		case "normal":
			value = Enum593.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum593.const_0;
			return true;
		}
	}
}
