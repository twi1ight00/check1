using System;
using ns84;

namespace ns73;

internal class Class3569 : Class3549<Enum509>
{
	public override string imethod_2(Enum509 value)
	{
		return value switch
		{
			Enum509.const_0 => "normal", 
			Enum509.const_1 => "break-word", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum509 value)
	{
		switch (token.ToLower())
		{
		case "break-word":
			value = Enum509.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "normal":
			value = Enum509.const_0;
			return true;
		}
	}
}
