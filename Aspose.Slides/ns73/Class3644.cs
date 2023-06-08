using System;
using ns84;

namespace ns73;

internal class Class3644 : Class3549<Enum618>
{
	public override string imethod_2(Enum618 value)
	{
		return value switch
		{
			Enum618.const_0 => "auto", 
			Enum618.const_1 => "always", 
			Enum618.const_2 => "avoid", 
			Enum618.const_3 => "left", 
			Enum618.const_4 => "right", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum618 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum618.const_4;
			return true;
		case "left":
			value = Enum618.const_3;
			return true;
		case "avoid":
			value = Enum618.const_2;
			return true;
		case "auto":
			value = Enum618.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "always":
			value = Enum618.const_1;
			return true;
		}
	}
}
