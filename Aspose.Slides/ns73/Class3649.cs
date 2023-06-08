using System;
using ns84;

namespace ns73;

internal class Class3649 : Class3549<Enum628>
{
	public override string imethod_2(Enum628 value)
	{
		return value switch
		{
			Enum628.const_0 => "show", 
			Enum628.const_1 => "hide", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum628 value)
	{
		switch (token.ToLower())
		{
		case "show":
			value = Enum628.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "hide":
			value = Enum628.const_1;
			return true;
		}
	}
}
