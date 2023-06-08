using System;
using ns84;

namespace ns73;

internal class Class3619 : Class3549<Enum574>
{
	public override string imethod_2(Enum574 value)
	{
		return value switch
		{
			Enum574.const_0 => "auto", 
			Enum574.const_1 => "alphabetic", 
			Enum574.const_2 => "below", 
			Enum574.const_3 => "left", 
			Enum574.const_4 => "right", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum574 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum574.const_4;
			return true;
		case "left":
			value = Enum574.const_3;
			return true;
		case "below":
			value = Enum574.const_2;
			return true;
		case "alphabetic":
			value = Enum574.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum574.const_0;
			return true;
		}
	}
}
