using System;
using ns84;

namespace ns73;

internal class Class3595 : Class3549<Enum555>
{
	public override string imethod_2(Enum555 value)
	{
		return value switch
		{
			Enum555.const_0 => "flex-start", 
			Enum555.const_1 => "flex-end", 
			Enum555.const_2 => "center", 
			Enum555.const_3 => "space-between", 
			Enum555.const_4 => "space-around", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum555 value)
	{
		switch (token.ToLower())
		{
		case "space-around":
			value = Enum555.const_4;
			return true;
		case "space-between":
			value = Enum555.const_3;
			return true;
		case "center":
			value = Enum555.const_2;
			return true;
		case "flex-end":
			value = Enum555.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "flex-start":
			value = Enum555.const_0;
			return true;
		}
	}
}
