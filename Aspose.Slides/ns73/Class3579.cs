using System;
using ns84;

namespace ns73;

internal class Class3579 : Class3549<Enum539>
{
	public override string imethod_2(Enum539 value)
	{
		return value switch
		{
			Enum539.const_0 => "normal", 
			Enum539.const_1 => "stylistic", 
			Enum539.const_2 => "historical-forms", 
			Enum539.const_3 => "styleset", 
			Enum539.const_4 => "character-variant", 
			Enum539.const_5 => "swash", 
			Enum539.const_6 => "ornaments", 
			Enum539.const_7 => "annotation", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum539 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum539.const_0;
			return true;
		case "stylistic":
			value = Enum539.const_1;
			return true;
		case "historical-forms":
			value = Enum539.const_2;
			return true;
		case "styleset":
			value = Enum539.const_3;
			return true;
		case "character-variant":
			value = Enum539.const_4;
			return true;
		case "swash":
			value = Enum539.const_5;
			return true;
		case "ornaments":
			value = Enum539.const_6;
			return true;
		default:
			throw new ArgumentException("value");
		case "annotation":
			value = Enum539.const_7;
			return true;
		}
	}
}
