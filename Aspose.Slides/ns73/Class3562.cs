using System;
using ns84;

namespace ns73;

internal class Class3562 : Class3549<Enum502>
{
	public override string imethod_2(Enum502 value)
	{
		return value switch
		{
			Enum502.const_0 => "none", 
			Enum502.const_1 => "both", 
			Enum502.const_2 => "horizontal", 
			Enum502.const_3 => "vertical", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum502 value)
	{
		switch (token.ToLower())
		{
		case "vertical":
			value = Enum502.const_3;
			return true;
		case "horizontal":
			value = Enum502.const_2;
			return true;
		case "both":
			value = Enum502.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "none":
			value = Enum502.const_0;
			return true;
		}
	}
}
