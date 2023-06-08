using System;
using ns84;

namespace ns73;

internal class Class3645 : Class3549<Enum619>
{
	public override string imethod_2(Enum619 value)
	{
		return value switch
		{
			Enum619.const_0 => "visible", 
			Enum619.const_1 => "hidden", 
			Enum619.const_2 => "scroll", 
			Enum619.const_3 => "auto", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum619 value)
	{
		switch (token.ToLower())
		{
		case "visible":
			value = Enum619.const_0;
			return true;
		case "scroll":
			value = Enum619.const_2;
			return true;
		case "hidden":
			value = Enum619.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum619.const_3;
			return true;
		}
	}
}
