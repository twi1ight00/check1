using System;
using ns84;

namespace ns73;

internal class Class3657 : Class3549<Enum595>
{
	public override string imethod_2(Enum595 value)
	{
		return value switch
		{
			Enum595.const_0 => "digits", 
			Enum595.const_1 => "continuous", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum595 value)
	{
		switch (token.ToLower())
		{
		case "digits":
			value = Enum595.const_0;
			return true;
		default:
			throw new ArgumentException("token");
		case "continuous":
			value = Enum595.const_1;
			return true;
		}
	}
}
