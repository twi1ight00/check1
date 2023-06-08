using System;
using ns84;

namespace ns73;

internal class Class3665 : Class3549<Enum631>
{
	public override string imethod_2(Enum631 value)
	{
		return value switch
		{
			Enum631.const_0 => "baseline", 
			Enum631.const_1 => "sub", 
			Enum631.const_2 => "super", 
			Enum631.const_3 => "top", 
			Enum631.const_4 => "text-top", 
			Enum631.const_5 => "middle", 
			Enum631.const_6 => "bottom", 
			Enum631.const_7 => "text-bottom", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum631 value)
	{
		switch (token.ToLower())
		{
		case "baseline":
			value = Enum631.const_0;
			return true;
		case "middle":
			value = Enum631.const_5;
			return true;
		case "sub":
			value = Enum631.const_1;
			return true;
		case "super":
			value = Enum631.const_2;
			return true;
		case "text-top":
			value = Enum631.const_4;
			return true;
		case "text-bottom":
			value = Enum631.const_7;
			return true;
		case "top":
			value = Enum631.const_3;
			return true;
		default:
			throw new ArgumentException("value");
		case "bottom":
			value = Enum631.const_6;
			return true;
		}
	}
}
