using System;
using ns84;

namespace ns73;

internal class Class3599 : Class3549<Enum559>
{
	public override string imethod_2(Enum559 value)
	{
		return value switch
		{
			Enum559.const_0 => "crop", 
			Enum559.const_1 => "cross", 
			Enum559.const_2 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum559 value)
	{
		switch (token.ToLower())
		{
		case "none":
			value = Enum559.const_2;
			return true;
		case "cross":
			value = Enum559.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "crop":
			value = Enum559.const_0;
			return true;
		}
	}
}
