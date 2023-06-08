using System;
using ns84;

namespace ns73;

internal class Class3550 : Class3549<Enum560>
{
	public override string imethod_2(Enum560 value)
	{
		return value switch
		{
			Enum560.const_0 => "open", 
			Enum560.const_1 => "closed", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum560 value)
	{
		switch (token.ToLower())
		{
		case "closed":
			value = Enum560.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "open":
			value = Enum560.const_0;
			return true;
		}
	}
}
