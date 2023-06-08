using System;
using ns84;

namespace ns73;

internal class Class3598 : Class3549<Enum558>
{
	public override string imethod_2(Enum558 value)
	{
		return value switch
		{
			Enum558.const_0 => "flat", 
			Enum558.const_1 => "preserve-3d", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum558 value)
	{
		switch (token.ToLower())
		{
		case "preserve-3d":
			value = Enum558.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "flat":
			value = Enum558.const_0;
			return true;
		}
	}
}
