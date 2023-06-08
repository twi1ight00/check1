using System;
using ns84;

namespace ns73;

internal class Class3614 : Class3549<Enum569>
{
	public override string imethod_2(Enum569 value)
	{
		return value switch
		{
			Enum569.const_0 => "auto", 
			Enum569.const_1 => "compress", 
			Enum569.const_2 => "use-glyphs", 
			Enum569.const_3 => "no-compress", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum569 value)
	{
		switch (token.ToLower())
		{
		case "no-compress":
			value = Enum569.const_3;
			return true;
		case "use-glyphs":
			value = Enum569.const_2;
			return true;
		case "compress":
			value = Enum569.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "auto":
			value = Enum569.const_0;
			return true;
		}
	}
}
