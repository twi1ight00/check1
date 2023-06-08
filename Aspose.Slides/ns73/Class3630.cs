using System;
using ns84;

namespace ns73;

internal class Class3630 : Class3549<Enum585>
{
	public override string imethod_2(Enum585 value)
	{
		return value switch
		{
			Enum585.const_0 => "dotted", 
			Enum585.const_1 => "dashed", 
			Enum585.const_2 => "solid", 
			Enum585.const_3 => "double", 
			Enum585.const_4 => "wavy", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum585 value)
	{
		switch (token.ToLower())
		{
		case "wavy":
			value = Enum585.const_4;
			return true;
		case "solid":
			value = Enum585.const_2;
			return true;
		case "double":
			value = Enum585.const_3;
			return true;
		case "dotted":
			value = Enum585.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "dashed":
			value = Enum585.const_1;
			return true;
		}
	}
}
