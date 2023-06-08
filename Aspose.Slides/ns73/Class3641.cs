using System;
using ns84;

namespace ns73;

internal class Class3641 : Class3549<Enum616>
{
	public override string imethod_2(Enum616 value)
	{
		return value switch
		{
			Enum616.const_0 => "left", 
			Enum616.const_1 => "right", 
			Enum616.const_2 => "center", 
			Enum616.const_3 => "justify", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum616 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum616.const_1;
			return true;
		case "left":
			value = Enum616.const_0;
			return true;
		case "justify":
			value = Enum616.const_3;
			return true;
		default:
			throw new ArgumentException("value");
		case "center":
			value = Enum616.const_2;
			return true;
		}
	}
}
