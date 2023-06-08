using System;
using ns84;

namespace ns73;

internal class Class3653 : Class3549<Enum591>
{
	public override string imethod_2(Enum591 value)
	{
		return value switch
		{
			Enum591.const_0 => "silent", 
			Enum591.const_1 => "x-soft", 
			Enum591.const_2 => "soft", 
			Enum591.const_3 => "medium", 
			Enum591.const_4 => "loud", 
			Enum591.const_5 => "x-loud", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum591 value)
	{
		switch (token.ToLower())
		{
		case "silent":
			value = Enum591.const_0;
			return true;
		case "x-soft":
			value = Enum591.const_1;
			return true;
		case "soft":
			value = Enum591.const_2;
			return true;
		case "medium":
			value = Enum591.const_3;
			return true;
		case "loud":
			value = Enum591.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "x-loud":
			value = Enum591.const_5;
			return true;
		}
	}
}
