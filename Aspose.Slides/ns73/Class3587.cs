using System;
using ns84;

namespace ns73;

internal class Class3587 : Class3549<Enum547>
{
	public override string imethod_2(Enum547 value)
	{
		return value switch
		{
			Enum547.const_0 => "inline-line-height", 
			Enum547.const_1 => "block-line-height", 
			Enum547.const_2 => "max-height", 
			Enum547.const_3 => "grid-height", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum547 value)
	{
		switch (token.ToLower())
		{
		case "grid-height":
			value = Enum547.const_3;
			return true;
		case "max-height":
			value = Enum547.const_2;
			return true;
		case "block-line-height":
			value = Enum547.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "inline-line-height":
			value = Enum547.const_0;
			return true;
		}
	}
}
