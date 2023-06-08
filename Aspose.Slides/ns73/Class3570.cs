using System;
using ns84;

namespace ns73;

internal class Class3570 : Class3549<Class4260.Enum500>
{
	public override string imethod_2(Class4260.Enum500 value)
	{
		return value switch
		{
			Class4260.Enum500.const_0 => "repeating", 
			Class4260.Enum500.const_1 => "numeric", 
			Class4260.Enum500.const_2 => "alphabetic", 
			Class4260.Enum500.const_3 => "symbolic", 
			Class4260.Enum500.const_4 => "additive", 
			Class4260.Enum500.const_5 => "non-repeating", 
			Class4260.Enum500.const_6 => "override", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Class4260.Enum500 value)
	{
		switch (token.ToLower())
		{
		case "additive":
			value = Class4260.Enum500.const_4;
			return true;
		case "alphabetic":
			value = Class4260.Enum500.const_2;
			return true;
		case "non-repeating":
			value = Class4260.Enum500.const_5;
			return true;
		case "numeric":
			value = Class4260.Enum500.const_1;
			return true;
		case "override":
			value = Class4260.Enum500.const_6;
			return true;
		case "repeating":
			value = Class4260.Enum500.const_0;
			return true;
		default:
			throw new ArgumentException("token");
		case "symbolic":
			value = Class4260.Enum500.const_3;
			return true;
		}
	}
}
