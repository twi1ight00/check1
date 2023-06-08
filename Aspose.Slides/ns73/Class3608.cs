using System;
using ns84;

namespace ns73;

internal class Class3608 : Class3549<Enum562>
{
	public override string imethod_2(Enum562 value)
	{
		return value switch
		{
			Enum562.const_0 => "scroll", 
			Enum562.const_1 => "slide", 
			Enum562.const_2 => "alternate", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum562 value)
	{
		switch (token.ToLower())
		{
		case "alternate":
			value = Enum562.const_2;
			return true;
		case "slide":
			value = Enum562.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "scroll":
			value = Enum562.const_0;
			return true;
		}
	}
}
