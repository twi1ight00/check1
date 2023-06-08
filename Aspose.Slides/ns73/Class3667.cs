using System;
using ns84;

namespace ns73;

internal class Class3667 : Class3549<Enum615>
{
	public override string imethod_2(Enum615 value)
	{
		return value switch
		{
			Enum615.flag_0 => "none", 
			Enum615.flag_1 => "underline", 
			Enum615.flag_2 => "overline", 
			Enum615.flag_3 => "line-through", 
			Enum615.flag_4 => "blink", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum615 value)
	{
		switch (token.ToLower())
		{
		case "blink":
			value = Enum615.flag_4;
			return true;
		case "line-through":
			value = Enum615.flag_3;
			return true;
		case "overline":
			value = Enum615.flag_2;
			return true;
		case "underline":
			value = Enum615.flag_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum615.flag_0;
			return true;
		}
	}
}
