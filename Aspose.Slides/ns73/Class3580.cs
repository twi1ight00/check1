using System;
using ns84;

namespace ns73;

internal class Class3580 : Class3549<Enum540>
{
	public override string imethod_2(Enum540 value)
	{
		return value switch
		{
			Enum540.const_0 => "normal", 
			Enum540.const_1 => "ultra-condensed", 
			Enum540.const_2 => "extra-condensed", 
			Enum540.const_3 => "condensed", 
			Enum540.const_4 => "semi-condensed", 
			Enum540.const_5 => "semi-expanded", 
			Enum540.const_6 => "expanded", 
			Enum540.const_7 => "extra-expanded", 
			Enum540.const_8 => "ultra-expanded", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum540 value)
	{
		switch (token.ToLower())
		{
		case "normal":
			value = Enum540.const_0;
			return true;
		case "ultra-condensed":
			value = Enum540.const_1;
			return true;
		case "extra-condensed":
			value = Enum540.const_2;
			return true;
		case "condensed":
			value = Enum540.const_3;
			return true;
		case "semi-condensed":
			value = Enum540.const_4;
			return true;
		case "semi-expanded":
			value = Enum540.const_5;
			return true;
		case "expanded":
			value = Enum540.const_6;
			return true;
		case "extra-expanded":
			value = Enum540.const_7;
			return true;
		default:
			throw new ArgumentException("value");
		case "ultra-expanded":
			value = Enum540.const_8;
			return true;
		}
	}
}
