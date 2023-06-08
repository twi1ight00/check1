using System;
using ns84;

namespace ns73;

internal class Class3584 : Class3549<Enum544>
{
	public override string imethod_2(Enum544 value)
	{
		return value switch
		{
			Enum544.const_0 => "x-weak", 
			Enum544.const_1 => "weak", 
			Enum544.const_2 => "medium", 
			Enum544.const_3 => "strong", 
			Enum544.const_4 => "x-strong", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum544 value)
	{
		switch (token.ToLower())
		{
		case "x-strong":
			value = Enum544.const_4;
			return true;
		case "strong":
			value = Enum544.const_3;
			return true;
		case "medium":
			value = Enum544.const_2;
			return true;
		case "weak":
			value = Enum544.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "x-weak":
			value = Enum544.const_0;
			return true;
		}
	}
}
