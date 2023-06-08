using System;
using ns84;

namespace ns73;

internal class Class3571 : Class3549<Enum531>
{
	public override string imethod_2(Enum531 value)
	{
		return value switch
		{
			Enum531.const_0 => "auto", 
			Enum531.const_1 => "landscape", 
			Enum531.const_2 => "portrait", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum531 value)
	{
		switch (token.ToLower())
		{
		case "portrait":
			value = Enum531.const_2;
			return true;
		case "landscape":
			value = Enum531.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum531.const_0;
			return true;
		}
	}
}
