using System;
using ns84;

namespace ns73;

internal class Class3596 : Class3549<Enum556>
{
	public override string imethod_2(Enum556 value)
	{
		return value switch
		{
			Enum556.const_0 => "nowrap", 
			Enum556.const_1 => "wrap", 
			Enum556.const_2 => "wrap-reverse", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum556 value)
	{
		switch (token.ToLower())
		{
		case "wrap-reverse":
			value = Enum556.const_2;
			return true;
		case "wrap":
			value = Enum556.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "nowrap":
			value = Enum556.const_0;
			return true;
		}
	}
}
