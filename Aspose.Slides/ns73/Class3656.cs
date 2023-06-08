using System;
using ns84;

namespace ns73;

internal class Class3656 : Class3549<Enum594>
{
	public override string imethod_2(Enum594 value)
	{
		return value switch
		{
			Enum594.const_0 => "code", 
			Enum594.const_1 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum594 value)
	{
		switch (token.ToLower())
		{
		case "none":
			value = Enum594.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "code":
			value = Enum594.const_0;
			return true;
		}
	}
}
