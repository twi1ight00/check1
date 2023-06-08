using System;
using ns84;

namespace ns73;

internal class Class3592 : Class3549<Enum552>
{
	public override string imethod_2(Enum552 value)
	{
		return value switch
		{
			Enum552.const_0 => "auto", 
			Enum552.const_1 => "left", 
			Enum552.const_2 => "center", 
			Enum552.const_3 => "right", 
			Enum552.const_4 => "distribute-letter", 
			Enum552.const_5 => "distribute-space", 
			Enum552.const_6 => "line-edge", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum552 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum552.const_0;
			return true;
		case "left":
			value = Enum552.const_1;
			return true;
		case "center":
			value = Enum552.const_2;
			return true;
		case "right":
			value = Enum552.const_3;
			return true;
		case "distribute-letter":
			value = Enum552.const_4;
			return true;
		case "distribute-space":
			value = Enum552.const_5;
			return true;
		default:
			throw new ArgumentException("token");
		case "line-edge":
			value = Enum552.const_6;
			return true;
		}
	}
}
