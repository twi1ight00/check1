using System;
using ns84;

namespace ns73;

internal class Class3652 : Class3549<Enum590>
{
	public override string imethod_2(Enum590 value)
	{
		return value switch
		{
			Enum590.const_0 => "male", 
			Enum590.const_1 => "female", 
			Enum590.const_2 => "child", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum590 value)
	{
		switch (token.ToLower())
		{
		case "male":
			value = Enum590.const_0;
			return true;
		case "female":
			value = Enum590.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "child":
			value = Enum590.const_2;
			return true;
		}
	}
}
