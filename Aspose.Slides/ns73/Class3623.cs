using System;
using ns84;

namespace ns73;

internal class Class3623 : Class3549<Enum578>
{
	public override string imethod_2(Enum578 value)
	{
		return value switch
		{
			Enum578.const_0 => "auto", 
			Enum578.const_1 => "loose", 
			Enum578.const_2 => "normal", 
			Enum578.const_3 => "strict", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum578 value)
	{
		switch (token.ToLower())
		{
		case "strict":
			value = Enum578.const_3;
			return true;
		case "normal":
			value = Enum578.const_2;
			return true;
		case "loose":
			value = Enum578.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum578.const_0;
			return true;
		}
	}
}
