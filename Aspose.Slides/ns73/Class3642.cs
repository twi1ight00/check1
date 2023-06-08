using System;
using ns84;

namespace ns73;

internal class Class3642 : Class3549<Enum617>
{
	public override string imethod_2(Enum617 value)
	{
		return value switch
		{
			Enum617.const_0 => "fixed", 
			Enum617.const_1 => "auto", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum617 value)
	{
		switch (token.ToLower())
		{
		case "fixed":
			value = Enum617.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum617.const_1;
			return true;
		}
	}
}
