using System;
using ns84;

namespace ns73;

internal class Class3676 : Class3549<Enum634>
{
	public override string imethod_2(Enum634 value)
	{
		return value switch
		{
			Enum634.const_0 => string.Empty, 
			Enum634.const_1 => "%", 
			Enum634.const_2 => "em", 
			Enum634.const_3 => "ex", 
			Enum634.const_4 => "px", 
			Enum634.const_5 => "cm", 
			Enum634.const_6 => "mm", 
			Enum634.const_7 => "in", 
			Enum634.const_8 => "pt", 
			Enum634.const_9 => "pc", 
			Enum634.const_10 => "deg", 
			Enum634.const_11 => "rad", 
			Enum634.const_12 => "grad", 
			Enum634.const_13 => "ms", 
			Enum634.const_14 => "s", 
			Enum634.const_15 => "Hz", 
			Enum634.const_16 => "kHz", 
			Enum634.const_17 => "dpi", 
			Enum634.const_18 => "dpcm", 
			Enum634.const_19 => "dppx", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum634 value)
	{
		switch (token.ToLower())
		{
		case "em":
			value = Enum634.const_2;
			return true;
		case "ex":
			value = Enum634.const_3;
			return true;
		case "px":
			value = Enum634.const_4;
			return true;
		case "cm":
			value = Enum634.const_5;
			return true;
		case "mm":
			value = Enum634.const_6;
			return true;
		case "in":
			value = Enum634.const_7;
			return true;
		case "pt":
			value = Enum634.const_8;
			return true;
		case "pc":
			value = Enum634.const_9;
			return true;
		case "deg":
			value = Enum634.const_10;
			return true;
		case "rad":
			value = Enum634.const_11;
			return true;
		case "grad":
			value = Enum634.const_12;
			return true;
		case "ms":
			value = Enum634.const_13;
			return true;
		case "s":
			value = Enum634.const_14;
			return true;
		case "Hz":
			value = Enum634.const_15;
			return true;
		case "khz":
			value = Enum634.const_16;
			return true;
		case "dpi":
			value = Enum634.const_17;
			return true;
		case "dpcm":
			value = Enum634.const_18;
			return true;
		case "dppx":
			value = Enum634.const_19;
			return true;
		case "%":
			value = Enum634.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "":
			value = Enum634.const_0;
			return true;
		}
	}
}
