using System;
using ns84;

namespace ns73;

internal class Class3629 : Class3549<Enum584>
{
	public override string imethod_2(Enum584 value)
	{
		return value switch
		{
			Enum584.const_0 => "none", 
			Enum584.const_1 => "objects", 
			Enum584.const_2 => "spaces", 
			Enum584.const_3 => "ink", 
			Enum584.const_4 => "edges", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum584 value)
	{
		switch (token.ToLower())
		{
		case "edges":
			value = Enum584.const_4;
			return true;
		case "ink":
			value = Enum584.const_3;
			return true;
		case "spaces":
			value = Enum584.const_2;
			return true;
		case "objects":
			value = Enum584.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "none":
			value = Enum584.const_0;
			return true;
		}
	}
}
