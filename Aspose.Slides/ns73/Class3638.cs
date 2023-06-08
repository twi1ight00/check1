using System;
using ns84;

namespace ns73;

internal class Class3638 : Class3549<Enum609>
{
	public override string imethod_2(Enum609 value)
	{
		return value switch
		{
			Enum609.const_0 => "left", 
			Enum609.const_1 => "right", 
			Enum609.const_2 => "both", 
			Enum609.const_3 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum609 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum609.const_1;
			return true;
		case "none":
			value = Enum609.const_3;
			return true;
		case "left":
			value = Enum609.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "both":
			value = Enum609.const_2;
			return true;
		}
	}
}
