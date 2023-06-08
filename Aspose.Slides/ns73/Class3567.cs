using System;
using ns84;

namespace ns73;

internal class Class3567 : Class3549<Enum507>
{
	public override string imethod_2(Enum507 value)
	{
		return value switch
		{
			Enum507.const_0 => "auto", 
			Enum507.const_1 => "font-size", 
			Enum507.const_2 => "text-size", 
			Enum507.const_3 => "max-size", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum507 value)
	{
		switch (token.ToLower())
		{
		case "max-size":
			value = Enum507.const_3;
			return true;
		case "text-size":
			value = Enum507.const_2;
			return true;
		case "font-size":
			value = Enum507.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum507.const_0;
			return true;
		}
	}
}
