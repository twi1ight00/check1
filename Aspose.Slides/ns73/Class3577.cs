using System;
using ns84;

namespace ns73;

internal class Class3577 : Class3549<Enum537>
{
	public override string imethod_2(Enum537 value)
	{
		return value switch
		{
			Enum537.const_0 => "normal", 
			Enum537.const_1 => "small-caps", 
			Enum537.const_2 => "all-small-caps", 
			Enum537.const_3 => "petite-caps", 
			Enum537.const_4 => "all-petite-caps", 
			Enum537.const_5 => "titling-caps", 
			Enum537.const_6 => "unicase", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum537 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum537.const_0;
			return true;
		case "small-caps":
			value = Enum537.const_1;
			return true;
		case "all-small-caps":
			value = Enum537.const_2;
			return true;
		case "petite-caps":
			value = Enum537.const_3;
			return true;
		case "all-petite-caps":
			value = Enum537.const_4;
			return true;
		case "titling-caps":
			value = Enum537.const_5;
			return true;
		default:
			throw new ArgumentException("value");
		case "unicase":
			value = Enum537.const_6;
			return true;
		}
	}
}
