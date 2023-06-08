using System;
using ns84;

namespace ns73;

internal class Class3658 : Class3549<Enum596>
{
	public override string imethod_2(Enum596 value)
	{
		return value switch
		{
			Enum596.const_0 => "once", 
			Enum596.const_1 => "always", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum596 value)
	{
		switch (token.ToLower())
		{
		case "always":
			value = Enum596.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "once":
			value = Enum596.const_0;
			return true;
		}
	}
}
