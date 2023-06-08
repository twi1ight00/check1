using System;
using ns84;

namespace ns73;

internal class Class3654 : Class3549<Enum592>
{
	public override string imethod_2(Enum592 value)
	{
		return value switch
		{
			Enum592.const_0 => "x-slow", 
			Enum592.const_1 => "slow", 
			Enum592.const_2 => "medium", 
			Enum592.const_3 => "fast", 
			Enum592.const_4 => "x-fast", 
			Enum592.const_5 => "faster", 
			Enum592.const_6 => "slower", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum592 value)
	{
		switch (token.ToLower())
		{
		case "x-slow":
			value = Enum592.const_0;
			return true;
		case "slow":
			value = Enum592.const_1;
			return true;
		case "medium":
			value = Enum592.const_2;
			return true;
		case "fast":
			value = Enum592.const_3;
			return true;
		case "x-fast":
			value = Enum592.const_4;
			return true;
		case "faster":
			value = Enum592.const_5;
			return true;
		default:
			throw new ArgumentException("token");
		case "slower":
			value = Enum592.const_6;
			return true;
		}
	}
}
