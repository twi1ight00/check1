using System;
using ns84;

namespace ns73;

internal class Class3666 : Class3549<Enum613>
{
	public override string imethod_2(Enum613 value)
	{
		return value switch
		{
			Enum613.const_0 => "normal", 
			Enum613.const_1 => "embed", 
			Enum613.const_2 => "bidi-override", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum613 value)
	{
		switch (token.ToLower())
		{
		case "bidi-override":
			value = Enum613.const_2;
			return true;
		case "embed":
			value = Enum613.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "normal":
			value = Enum613.const_0;
			return true;
		}
	}
}
