using System;
using ns84;

namespace ns73;

internal class Class3650 : Class3549<Enum632>
{
	public override string imethod_2(Enum632 value)
	{
		return value switch
		{
			Enum632.const_0 => "ltr", 
			Enum632.const_1 => "rtl", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum632 value)
	{
		switch (token.ToLower())
		{
		case "rtl":
			value = Enum632.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "ltr":
			value = Enum632.const_0;
			return true;
		}
	}
}
