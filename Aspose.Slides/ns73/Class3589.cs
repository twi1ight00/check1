using System;
using ns84;

namespace ns73;

internal class Class3589 : Class3549<Enum549>
{
	public override string imethod_2(Enum549 value)
	{
		return value switch
		{
			Enum549.const_0 => "fill", 
			Enum549.const_1 => "contain", 
			Enum549.const_2 => "cover", 
			Enum549.const_3 => "none", 
			Enum549.const_4 => "scale-down", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum549 value)
	{
		switch (token.ToLower())
		{
		case "scale-down":
			value = Enum549.const_4;
			return true;
		case "none":
			value = Enum549.const_3;
			return true;
		case "cover":
			value = Enum549.const_2;
			return true;
		case "contain":
			value = Enum549.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "fill":
			value = Enum549.const_0;
			return true;
		}
	}
}
