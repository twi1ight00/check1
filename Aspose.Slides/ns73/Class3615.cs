using System;
using ns84;

namespace ns73;

internal class Class3615 : Class3549<Enum570>
{
	public override string imethod_2(Enum570 value)
	{
		return value switch
		{
			Enum570.const_0 => "numeric", 
			Enum570.const_1 => "digits", 
			Enum570.const_2 => "alpha", 
			Enum570.const_3 => "latin", 
			Enum570.const_4 => "alphanumeric", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum570 value)
	{
		switch (token.ToLower())
		{
		case "numeric":
			value = Enum570.const_0;
			return true;
		case "latin":
			value = Enum570.const_3;
			return true;
		case "digits":
			value = Enum570.const_1;
			return true;
		case "alphanumeric":
			value = Enum570.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "alpha":
			value = Enum570.const_2;
			return true;
		}
	}
}
