using System;
using ns84;

namespace ns73;

internal class Class3561 : Class3549<Enum501>
{
	public override string imethod_2(Enum501 value)
	{
		return value switch
		{
			Enum501.const_0 => "auto", 
			Enum501.const_1 => "always", 
			Enum501.const_2 => "avoid", 
			Enum501.const_3 => "left", 
			Enum501.const_4 => "right", 
			Enum501.const_5 => "page", 
			Enum501.const_6 => "column", 
			Enum501.const_7 => "avoid-page", 
			Enum501.const_8 => "avoid-column", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum501 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum501.const_0;
			return true;
		case "always":
			value = Enum501.const_1;
			return true;
		case "avoid":
			value = Enum501.const_2;
			return true;
		case "left":
			value = Enum501.const_3;
			return true;
		case "right":
			value = Enum501.const_4;
			return true;
		case "page":
			value = Enum501.const_5;
			return true;
		case "column":
			value = Enum501.const_6;
			return true;
		case "avoid-page":
			value = Enum501.const_7;
			return true;
		default:
			throw new ArgumentException("value");
		case "avoid-column":
			value = Enum501.const_8;
			return true;
		}
	}
}
