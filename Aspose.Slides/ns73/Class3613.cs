using System;
using ns84;

namespace ns73;

internal class Class3613 : Class3549<Enum567>
{
	public override string imethod_2(Enum567 value)
	{
		return value switch
		{
			Enum567.const_0 => "scrollbar", 
			Enum567.const_1 => "panner", 
			Enum567.const_2 => "move", 
			Enum567.const_3 => "marquee", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum567 value)
	{
		switch (token.ToLower())
		{
		case "marquee":
			value = Enum567.const_3;
			return true;
		case "move":
			value = Enum567.const_2;
			return true;
		case "panner":
			value = Enum567.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "scrollbar":
			value = Enum567.const_0;
			return true;
		}
	}
}
