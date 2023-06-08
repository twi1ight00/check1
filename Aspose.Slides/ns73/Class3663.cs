using System;
using ns84;

namespace ns73;

internal class Class3663 : Class3549<Enum610>
{
	public override string imethod_2(Enum610 value)
	{
		return value switch
		{
			Enum610.const_0 => "xx-small", 
			Enum610.const_1 => "x-small", 
			Enum610.const_2 => "small", 
			Enum610.const_3 => "medium", 
			Enum610.const_4 => "large", 
			Enum610.const_5 => "x-large", 
			Enum610.const_6 => "xx-large", 
			Enum610.const_7 => "xxx-large", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum610 value)
	{
		switch (token.ToLower())
		{
		case "xx-small":
			value = Enum610.const_0;
			return true;
		case "x-small":
			value = Enum610.const_1;
			return true;
		case "small":
			value = Enum610.const_2;
			return true;
		case "medium":
			value = Enum610.const_3;
			return true;
		case "large":
			value = Enum610.const_4;
			return true;
		case "x-large":
			value = Enum610.const_5;
			return true;
		case "xx-large":
			value = Enum610.const_6;
			return true;
		default:
			throw new ArgumentException("token");
		case "xxx-large":
			value = Enum610.const_7;
			return true;
		}
	}
}
