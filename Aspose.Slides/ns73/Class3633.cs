using System;
using ns84;

namespace ns73;

internal class Class3633 : Class3549<Enum604>
{
	public override string imethod_2(Enum604 value)
	{
		return value switch
		{
			Enum604.const_0 => "scroll", 
			Enum604.const_1 => "fixed", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum604 value)
	{
		switch (token.ToLower())
		{
		case "fixed":
			value = Enum604.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "scroll":
			value = Enum604.const_0;
			return true;
		}
	}
}
