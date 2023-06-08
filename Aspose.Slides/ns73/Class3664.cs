using System;
using ns84;

namespace ns73;

internal class Class3664 : Class3549<Enum611>
{
	public override string imethod_2(Enum611 value)
	{
		return value switch
		{
			Enum611.const_0 => "normal", 
			Enum611.const_1 => "pre", 
			Enum611.const_2 => "nowrap", 
			Enum611.const_3 => "pre-wrap", 
			Enum611.const_4 => "pre-line", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum611 value)
	{
		switch (token.ToLower())
		{
		case "pre-line":
			value = Enum611.const_4;
			return true;
		case "pre-wrap":
			value = Enum611.const_3;
			return true;
		case "nowrap":
			value = Enum611.const_2;
			return true;
		case "pre":
			value = Enum611.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "normal":
			value = Enum611.const_0;
			return true;
		}
	}
}
