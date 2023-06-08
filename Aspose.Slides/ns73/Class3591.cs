using System;
using ns84;

namespace ns73;

internal class Class3591 : Class3549<Enum551>
{
	public override string imethod_2(Enum551 value)
	{
		return value switch
		{
			Enum551.const_0 => "auto", 
			Enum551.const_1 => "start", 
			Enum551.const_2 => "end", 
			Enum551.const_3 => "none", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum551 value)
	{
		switch (token.ToLower())
		{
		case "none":
			value = Enum551.const_3;
			return true;
		case "end":
			value = Enum551.const_2;
			return true;
		case "start":
			value = Enum551.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "auto":
			value = Enum551.const_0;
			return true;
		}
	}
}
