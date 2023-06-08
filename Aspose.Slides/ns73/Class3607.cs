using System;
using ns84;

namespace ns73;

internal class Class3607 : Class3549<Enum561>
{
	public override string imethod_2(Enum561 value)
	{
		return value switch
		{
			Enum561.const_0 => "linear", 
			Enum561.const_1 => "ease", 
			Enum561.const_2 => "ease-in", 
			Enum561.const_3 => "ease-out", 
			Enum561.const_4 => "ease-in-out", 
			Enum561.const_5 => "cubic-bezier", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum561 value)
	{
		switch (token.ToLower())
		{
		case "linear":
			value = Enum561.const_0;
			return true;
		case "ease":
			value = Enum561.const_1;
			return true;
		case "ease-in":
			value = Enum561.const_2;
			return true;
		case "ease-out":
			value = Enum561.const_3;
			return true;
		case "ease-in-out":
			value = Enum561.const_4;
			return true;
		default:
			throw new ArgumentException("token");
		case "cubic-bezier":
			value = Enum561.const_5;
			return true;
		}
	}
}
