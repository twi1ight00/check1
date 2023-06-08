using System;
using ns84;

namespace ns73;

internal class Class3620 : Class3549<Enum575>
{
	public override string imethod_2(Enum575 value)
	{
		return value switch
		{
			Enum575.const_0 => "collapse", 
			Enum575.const_1 => "preserve", 
			Enum575.const_2 => "preserve-breaks", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum575 value)
	{
		switch (token.ToLower())
		{
		case "preserve-breaks":
			value = Enum575.const_2;
			return true;
		case "preserve":
			value = Enum575.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "collapse":
			value = Enum575.const_0;
			return true;
		}
	}
}
