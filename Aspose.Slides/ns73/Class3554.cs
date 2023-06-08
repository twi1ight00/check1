using System;
using ns84;

namespace ns73;

internal class Class3554 : Class3549<Enum524>
{
	public override string imethod_2(Enum524 value)
	{
		return value switch
		{
			Enum524.const_0 => "flex-start", 
			Enum524.const_1 => "flex-end", 
			Enum524.const_2 => "center", 
			Enum524.const_3 => "space-between", 
			Enum524.const_4 => "space-around", 
			Enum524.const_5 => "stretch", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum524 value)
	{
		switch (token.ToLower())
		{
		case "flex-start":
			value = Enum524.const_0;
			return true;
		case "flex-end":
			value = Enum524.const_1;
			return true;
		case "center":
			value = Enum524.const_2;
			return true;
		case "space-between":
			value = Enum524.const_3;
			return true;
		case "space-around":
			value = Enum524.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "stretch":
			value = Enum524.const_5;
			return true;
		}
	}
}
