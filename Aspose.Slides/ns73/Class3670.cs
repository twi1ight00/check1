using System;
using ns84;

namespace ns73;

internal class Class3670 : Class3549<Enum623>
{
	public override string imethod_2(Enum623 value)
	{
		return value switch
		{
			Enum623.const_0 => "normal", 
			Enum623.const_1 => "bold", 
			Enum623.const_2 => "bolder", 
			Enum623.const_3 => "lighter", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum623 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum623.const_0;
			return true;
		case "lighter":
			value = Enum623.const_3;
			return true;
		case "bolder":
			value = Enum623.const_2;
			return true;
		default:
			throw new ArgumentException("token");
		case "bold":
			value = Enum623.const_1;
			return true;
		}
	}
}
