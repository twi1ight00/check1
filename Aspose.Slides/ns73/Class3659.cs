using System;
using ns87;

namespace ns73;

internal class Class3659 : Class3549<Class4209.Enum588>
{
	public override string imethod_2(Class4209.Enum588 value)
	{
		return value switch
		{
			Class4209.Enum588.const_0 => "mix", 
			Class4209.Enum588.const_1 => "repeat", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Class4209.Enum588 value)
	{
		switch (token.ToLower())
		{
		case "repeat":
			value = Class4209.Enum588.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "mix":
			value = Class4209.Enum588.const_0;
			return true;
		}
	}
}
