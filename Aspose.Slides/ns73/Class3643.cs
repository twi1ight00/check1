using System;
using ns84;

namespace ns73;

internal class Class3643 : Class3549<Enum633>
{
	public override string imethod_2(Enum633 value)
	{
		return value switch
		{
			Enum633.const_0 => "static", 
			Enum633.const_1 => "relative", 
			Enum633.const_2 => "absolute", 
			Enum633.const_3 => "fixed", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum633 value)
	{
		switch (token.ToLower())
		{
		case "static":
			value = Enum633.const_0;
			return true;
		case "relative":
			value = Enum633.const_1;
			return true;
		case "fixed":
			value = Enum633.const_3;
			return true;
		default:
			throw new ArgumentException("value");
		case "absolute":
			value = Enum633.const_2;
			return true;
		}
	}
}
