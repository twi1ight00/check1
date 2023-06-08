using System;
using ns84;

namespace ns73;

internal class Class3553 : Class3549<Enum523>
{
	public override string imethod_2(Enum523 value)
	{
		return value switch
		{
			Enum523.const_0 => "content-box", 
			Enum523.const_1 => "padding-box", 
			Enum523.const_2 => "border-box", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum523 value)
	{
		switch (token.ToLower())
		{
		case "border-box":
			value = Enum523.const_2;
			return true;
		case "padding-box":
			value = Enum523.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "content-box":
			value = Enum523.const_0;
			return true;
		}
	}
}
