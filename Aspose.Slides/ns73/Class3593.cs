using System;
using ns84;

namespace ns73;

internal class Class3593 : Class3549<Enum553>
{
	public override string imethod_2(Enum553 value)
	{
		return value switch
		{
			Enum553.const_0 => "start", 
			Enum553.const_1 => "first", 
			Enum553.const_2 => "last", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum553 value)
	{
		switch (token.ToLower())
		{
		case "last":
			value = Enum553.const_2;
			return true;
		case "first":
			value = Enum553.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "start":
			value = Enum553.const_0;
			return true;
		}
	}
}
