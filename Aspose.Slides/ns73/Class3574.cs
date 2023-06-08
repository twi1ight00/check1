using System;
using ns84;

namespace ns73;

internal class Class3574 : Class3549<Enum534>
{
	public override string imethod_2(Enum534 value)
	{
		return value switch
		{
			Enum534.const_0 => "normal", 
			Enum534.const_1 => "lining-nums", 
			Enum534.const_2 => "oldstyle-nums", 
			Enum534.const_3 => "proportional-nums", 
			Enum534.const_4 => "tabular-nums", 
			Enum534.const_5 => "diagonal-fractions", 
			Enum534.const_6 => "stacked-fractions", 
			Enum534.const_7 => "ordinal", 
			Enum534.const_8 => "slashed-zero", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum534 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum534.const_0;
			return true;
		case "lining-nums":
			value = Enum534.const_1;
			return true;
		case "oldstyle-nums":
			value = Enum534.const_2;
			return true;
		case "proportional-nums":
			value = Enum534.const_3;
			return true;
		case "tabular-nums":
			value = Enum534.const_4;
			return true;
		case "diagonal-fractions":
			value = Enum534.const_5;
			return true;
		case "stacked-fractions":
			value = Enum534.const_6;
			return true;
		case "ordinal":
			value = Enum534.const_7;
			return true;
		default:
			throw new ArgumentException("value");
		case "slashed-zero":
			value = Enum534.const_8;
			return true;
		}
	}
}
