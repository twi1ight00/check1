using System;
using ns84;

namespace ns73;

internal class Class3624 : Class3549<Enum579>
{
	public override string imethod_2(Enum579 value)
	{
		return value switch
		{
			Enum579.const_0 => "none", 
			Enum579.const_1 => "manual", 
			Enum579.const_2 => "auto", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum579 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum579.const_2;
			return true;
		case "manual":
			value = Enum579.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "none":
			value = Enum579.const_0;
			return true;
		}
	}
}
