using System;
using ns84;

namespace ns73;

internal class Class3627 : Class3549<Enum582>
{
	public override string imethod_2(Enum582 value)
	{
		return value switch
		{
			Enum582.const_0 => "none", 
			Enum582.const_1 => "filled", 
			Enum582.const_2 => "open", 
			Enum582.const_3 => "dot", 
			Enum582.const_4 => "circle", 
			Enum582.const_5 => "double-circle", 
			Enum582.const_6 => "triangle", 
			Enum582.const_7 => "sesame", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum582 value)
	{
		switch (token.ToLower())
		{
		case "circle":
			value = Enum582.const_4;
			return true;
		case "dot":
			value = Enum582.const_3;
			return true;
		case "double-circle":
			value = Enum582.const_5;
			return true;
		case "filled":
			value = Enum582.const_1;
			return true;
		case "none":
			value = Enum582.const_0;
			return true;
		case "open":
			value = Enum582.const_2;
			return true;
		case "sesame":
			value = Enum582.const_7;
			return true;
		default:
			throw new ArgumentException("value");
		case "triangle":
			value = Enum582.const_6;
			return true;
		}
	}
}
