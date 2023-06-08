using System;
using ns84;

namespace ns73;

internal class Class3610 : Class3549<Enum564>
{
	public override string imethod_2(Enum564 value)
	{
		return value switch
		{
			Enum564.const_0 => "reverse", 
			Enum564.const_1 => "forward", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum564 value)
	{
		switch (token.ToLower())
		{
		case "forward":
			value = Enum564.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "reverse":
			value = Enum564.const_0;
			return true;
		}
	}
}
